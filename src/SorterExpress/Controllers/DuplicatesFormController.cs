using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Threading;
using System.Windows.Forms;
using GChan.Controls;
using SorterExpress.Controls;
using SorterExpress.Properties;
using SorterExpress.Forms;
using SorterExpress.Classes.Actions.DuplicateActions;
using SorterExpress.Models;
using Vlc.DotNet.Forms;
using Vlc.DotNet.Core;
using Shortcut = SorterExpress.Classes.Shortcut;
using SorterExpress.Model.Duplicates;
using SorterExpress.Classes.SettingsData;

namespace SorterExpress.Controllers
{
    public class DuplicatesFormController
    {
        public DuplicatesForm form;

        public DuplicatesFormModel model;

        Dictionary<Shortcut, Func<bool>> shortcuts = null;

        public List<FilePrint> prints;

        /// <summary>
        /// When changing the selected index of matchesDataGridView programmatically
        /// like in KeepBoth(), MatchesGridViewSelectedRow returns the index of the previously
        /// selected column, can't figure out why, so we're currently using this to override that.
        /// If this is NOT -1, then we're using it as the index to load the next duplicate.
        /// TODO: Figure out this behaviour and get rid of this awful hack.
        /// </summary>
        int selectedIndexOverride = -1;

        public int finishedThreads = 0;

        BackgroundWorker printsWorker;
        CancellationTokenSource cancelTokenSource;
        System.Diagnostics.Stopwatch stopwatch;
        int scopeCount;

        // TODO: Add DeletingOK checks to this new form. Add a "Don't ask me again" option.
        /// <summary>
        /// Indicates whether the user has agreed to deleting files or not.
        /// </summary>
        private bool deletingOK = false;

        public Duplicate inspectingDuplicate { get; private set; }

        public int MatchesGridViewSelectedRowIndex { get { return form.matchesDataGridView?.CurrentCell?.RowIndex ?? -1; } }

        private object duplicatesLock = new object();

        private bool fileTypesMustMatch => model.SearchImages && model.SearchVideos && model.OnlyMatchSameFileTypes;

        public DuplicatesFormController(DuplicatesForm duplicatesForm, DirectoryInfo dirInfo)
        {
            form = duplicatesForm;
            model = new DuplicatesFormModel();

            printsWorker = new BackgroundWorker
            {
                WorkerReportsProgress = true,
                WorkerSupportsCancellation = true
            };

            printsWorker.DoWork += PrintsWorker_DoWork;
            printsWorker.ProgressChanged += PrintsWorker_ProgressChanged;
            printsWorker.RunWorkerCompleted += PrintsWorker_Completed;

            if (dirInfo != null)
            {
                LoadDirectory(dirInfo);
            }
        }

        public void HandleShortcut(KeyEventArgs e)
        {
            // Create shortcuts dictionary if not initialised.
            if (shortcuts == null)
            {
                shortcuts = new Dictionary<Shortcut, Func<bool>>() {
                    //{ new Shortcut(key: Keys.Up), () => { return ChangeMatchesGridViewIndex(-1); }},
                    //{ new Shortcut(key: Keys.Down), () => { return ChangeMatchesGridViewIndex(+1); }},
                    { new Shortcut(key: Keys.L), () => { KeepSide(Side.Left); return true; }},
                    { new Shortcut(key: Keys.R), () => { KeepSide(Side.Right); return true; }},
                    { new Shortcut(key: Keys.B), () => { return KeepBoth(); }},
                    { new Shortcut(key: Keys.N), () => { KeepNeither(); return true; }},
                    { new Shortcut(ctrl: true, key: Keys.Z), () => { return Undo(); }},
                    { new Shortcut(ctrl: true, key: Keys.Y), () => { return Redo(); }},
                };
            }

            Shortcut input = new Shortcut(e.Control, e.Alt, e.KeyCode);

            if (shortcuts.ContainsKey(input))
            {
                bool ok = shortcuts[input].Invoke();

                if (ok)
                {
                    e.Handled = true;
                    e.SuppressKeyPress = true;
                }
                else
                {
                    System.Media.SystemSounds.Beep.Play();
                }
            }

            bool KeepBoth()
            {
                if (form.matchesDataGridView.Focused)
                {
                    this.Skip();
                    return true;
                }
                else
                    return false;
            }

            bool ChangeMatchesGridViewIndex(int changeAmount)
            {
                int newIndex = form.matchesDataGridView.CurrentCell.RowIndex;

                if (newIndex >= 0 && newIndex < form.matchesDataGridView.RowCount)
                {
                    form.matchesDataGridView.CurrentCell = form.matchesDataGridView.Rows[newIndex].Cells[0];
                    MatchSelectionChanged();
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        internal void VlcControl_Playing(object sender, VlcMediaPlayerPlayingEventArgs e)
        {
            VlcControl control = (VlcControl)sender;

            Size size = new Size(-1, -1);
            Side side = (control == form.mediaViewerLeft.VlcControl) ? Side.Left : Side.Right;
            RichTextBox infoBox = (side == Side.Left) ? form.infoRichTextBoxLeft : form.infoRichTextBoxRight;

            VlcMedia media = control.GetCurrentMedia();

            // Currently grabbing tracksinformation 0, could be wrong in some cases.
            size.Width = media.TracksInformations.Length > 0 ? (int)media.TracksInformations[0].Video.Width : -1;
            size.Height = media.TracksInformations.Length > 0 ? (int)media.TracksInformations[0].Video.Height : -1;

            if (size != new Size(-1, -1))
            {
                // Update appropriate fileprint with the new found size, just incase it's needed later.
                (side == Side.Left ? inspectingDuplicate.fileprint1 : inspectingDuplicate.fileprint2).SetVideoSize(size);

                infoBox.Invoke(() =>
                {
                    if (!infoBox.Text.Contains("Width"))
                    {
                        infoBox.AppendText($"Duration: {media.Duration.Seconds}s\n");

                        ShowFileInfo(side, size, false);
                    }
                });
            }
        }

        internal void OpenDirectoryDialog()
        {
            var dirInfo = Utilities.OpenDirectory();

            if (dirInfo == null)
            { 
                Logs.Log("Directory open cancelled.");
            }
            else
            {
                LoadDirectory(dirInfo);
            }
        }

        private void LoadDirectory(DirectoryInfo dirInfo)
        {
            model.Directory = dirInfo.FullName;

            if (model.Files != null)
                model.Files.Clear();

            if (model.Duplicates != null)
                model.Duplicates.Clear();

            if (prints != null)
                prints.Clear();

            //if (model.SearchSubfolders)
            //    model.Files = Utilities.RecursivelyGetFileNames(dirInfo.FullName);
            //else
            //    model.Files = dirInfo.GetFileNamesList();

            UpdateSearchFilesScope();

            Logs.Log($"Opened '{model.Directory}' and found { model.Files.Count} files.");

            Utilities.PrintExtensionCounts(model.Files);

            //UpdateFileCountLabel();
            Console.WriteLine("Image file count: " + model.Files.Where(t => Utilities.FileIsImage(t)).Count());
            Console.WriteLine("Video file count: " + model.Files.Where(t => Utilities.FileIsVideo(t)).Count());
        }

        public void OpenMassOperationForm()
        {
            DuplicatesMassOperationForm form = new DuplicatesMassOperationForm(this);
            form.ShowDialog();
        }

        /// <summary>
        /// Pop an action from the doneActions stack and exeucutes it. Returns false if there was no action on the stack to undo.
        /// </summary>
        public bool Undo()
        {
            bool ret = false;

            if (model.DoneActions.Count > 0)
            {
                DuplicateAction action = model.DoneActions.Pop();

                action.Undo();

                if (action.Successful)
                    model.UndoneActions.Push(action);

                ret = true;
            }

            model.NotifyPropertyChanged(nameof(model.EnableRedoButton));
            model.NotifyPropertyChanged(nameof(model.EnableUndoButton));
            return ret;
        }

        /// <summary>
        /// Pop an action from the undoneActions stack and executes it. Returns false if there was no action on the stack to redo.
        /// </summary>
        public bool Redo()
        {
            bool ret = false;

            if (model.UndoneActions.Count > 0)
            {
                DuplicateAction action = model.UndoneActions.Pop();

                action.Do();

                if (action.Successful)
                    model.DoneActions.Push(action);

                model.UndoneActions.Clear();

                ret = true;
            }

            model.NotifyPropertyChanged(nameof(model.EnableRedoButton));
            model.NotifyPropertyChanged(nameof(model.EnableUndoButton));
            return ret;
        }

        private void Do(DuplicateAction action)
        {
            action.Do();

            if (action.Successful)
                model.DoneActions.Push(action);

            model.UndoneActions.Clear();

            model.NotifyPropertyChanged(nameof(model.EnableRedoButton));
            model.NotifyPropertyChanged(nameof(model.EnableUndoButton));
        }

        public void UpdateSearchFilesScope()
        {
            Console.WriteLine($"UpdateSearchFilesScope! SearchScopeSelectedValue: {model.SearchScopeSelectedValue}");

            if (string.IsNullOrWhiteSpace(model.Directory))
                return;

            if (model.SearchScopeSelectedValue == DuplicatesFormModel.SearchScope.ImmediateOnly)
            {
                model.Files = new DirectoryInfo(model.Directory).GetFileNamesList();
            }
            else if (model.SearchScopeSelectedValue == DuplicatesFormModel.SearchScope.SubdirsOnly)
            {
                model.Files = Utilities.RecursivelyGetFileNames(model.Directory);
                var immediates = Directory.GetFiles(model.Directory);//new DirectoryInfo(model.Directory).GetFileNamesList();
                model.Files.RemoveAll(t => immediates.Contains(t));
            }
            else //`BetweenImmediateAndSubs` & `All`
            {
                model.Files = Utilities.RecursivelyGetFileNames(model.Directory);
            }

            model.Files.RemoveAll(t => !TypeOK(t));

            model.NotifyPropertyChanged(nameof(model.FileAndMatchesCountText));

            bool TypeOK(string t)
            {
                FileType type = Utilities.GetFileType(t);

                return (type == FileType.Image && model.SearchImages) || (type == FileType.Video && model.SearchVideos);
            }
        }

        public void BeginSearch()
        {
            stopwatch = new System.Diagnostics.Stopwatch();
            stopwatch.Start();

            model.Duplicates.Clear();
            model.Searching = true;
            Settings.Default.DuplicateSearch.CropLeftRightSides = model.CropLeftAndRight;
            Settings.Default.DuplicateSearch.CropTopBottomSides = model.CropTopAndBottom;

            printsWorker.RunWorkerAsync();
        }

        public void CancelSearch()
        {
            Console.WriteLine("Cancelling duplicate search worker!");
            cancelTokenSource.Cancel();
        }

        private List<string> GetSearchScope(List<string> files)
        {
            var scope = files.ToList();
            scope.RemoveAll(t => ShouldBeExcluded(t));

            scope.Where(
                t => (model.SearchImages && Utilities.FileIsImage(t)) ||
                (model.SearchVideos && Utilities.FileIsVideo(t)))
                .ToList();

            return scope;

            bool ShouldBeExcluded(string str)
            {
                foreach (var dir in Settings.Default.DuplicateSearch.IgnoreDirectories ?? Enumerable.Empty<string>())
                {
                    if (str.StartsWith(dir))
                    {
                        return true;
                    }
                }

                foreach (var dir in Settings.Default.DuplicateSearch.IgnoreFiles ?? Enumerable.Empty<string>())
                {
                    if (str == dir)
                    {
                        return true;
                    }
                }

                return false;
            }
        }

        private void PrintsWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            if (prints == null)
                prints = new List<FilePrint>();

            Console.WriteLine("Starting to generate prints...");
            var scope = GetSearchScope(model.Files);
            scopeCount = scope.Count;

            form.Invoke((MethodInvoker)delegate () {
                model.Duplicates.Clear();
            });
            prints.RemoveAll(t => t == null || !scope.Contains(t.Filepath.Replace(model.Directory, "")));

            GeneratePrints(scope, prints, sender as BackgroundWorker, e);

            Console.WriteLine("Prints generated.");
        }

        private void PrintsWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            //TODO: Change these to variables in Model and use data binding.
            form.loadingLabel.Text = $"Searching..\n{finishedThreads}/{scopeCount}";
            form.progressBar.Value = e.ProgressPercentage;
        }

        private void PrintsWorker_Completed(object sender, RunWorkerCompletedEventArgs e)
        {
            Console.WriteLine("Worker_Completed!");

            model.Searching = false;

            stopwatch.Stop();
            Console.WriteLine($"Processed {finishedThreads} files in {stopwatch.ElapsedMilliseconds}ms ({stopwatch.ElapsedMilliseconds / 1000}s) and found {model.Duplicates.Count} duplicates at or above {model.Similarity}% similarity.");
        }

        private List<FilePrint> GeneratePrints(List<string> files, List<FilePrint> prints, BackgroundWorker worker, DoWorkEventArgs dwea)
        {
            if (!Directory.Exists(Program.THUMBS_PATH))
                Directory.CreateDirectory(Program.THUMBS_PATH);

            if (files == null)
            {
                return null;
            }

            bool fileTypesNeedMatch = model.SearchImages && model.SearchVideos && model.OnlyMatchSameFileTypes;

            finishedThreads = 0;

            cancelTokenSource = new CancellationTokenSource();

            var options = new ParallelOptions
            {
                MaxDegreeOfParallelism = (int)model.ThreadCount,
                CancellationToken = cancelTokenSource.Token
            };

            try
            {
                Parallel.ForEach(
                    files,
                    options,
                    (filename, state) =>
                    {
                        if (options.CancellationToken.IsCancellationRequested)
                        {
                            state.Break();
                        }
                        else
                        {
                            FilePrint print = CreatePrint(prints, filename);

                            if (print != null)
                            { 
                                CheckForMatches(print, prints);

                                // Add print to prints list *after* checking for matches, then don't have to worry about matching self, genius.
                                prints.Add(print);
                            }

                            finishedThreads++;
                            worker.ReportProgress(finishedThreads * 100 / files.Count);
                        }
                    });
            }
            catch (Exception e)
            {
                Console.WriteLine($"Exception in GeneratingPrints: {e.Message} - {e.StackTrace}");
            }

            return prints;
        }

        private FilePrint CreatePrint(List<FilePrint> prints, string filename)
        {
            FilePrint print;

            try
            {
                print = new FilePrint(Path.Combine(model.Directory, filename));
            }
            catch (Exception e)
            {
                Logs.Log($"Error occured getting print for {filename}", e.GetType().Name, e.Message, e.StackTrace);
                print = null;
            }

            return print;
        }

        private void CheckForMatches(FilePrint print, List<FilePrint> prints)
        {
            // For each print that is currently generated
            for (int i = 0; i < prints.Count; i++)
            {
                try
                {
                    bool isMatch = CheckPrintsAreMatch(print, prints[i]);

                    if (isMatch)
                    {
                        form.Invoke(delegate ()
                        {
                            lock (duplicatesLock)
                            {
                                model.Duplicates.Add(new Duplicate(print, prints[i]));
                            }
                        });
                    }
                }
                catch (Exception e)
                {
                    Console.WriteLine("Error occured in GeneratePrints");
                }
            }
        }

        private bool CheckPrintsAreMatch(FilePrint print1, FilePrint print2)
        {
            if (print1 != null && print2 != null)
            {
                // If the duplicate hasn't already been found or found in reverse (x is like y |or| y is like x)
                if (!fileTypesMustMatch || (fileTypesMustMatch && print1.FileType == print2.FileType))
                {
                    bool dirOK = CheckDirectoriesOk(print1, print2);

                    if (dirOK)
                    {
                        // If above similarity threshold set by user.
                        if (FilePrint.GetSimilarityPercentage(print1, print2) >= model.Similarity)
                        {
                            return true;
                        }
                    }
                }
            }

            return false;
        }

        private bool CheckDirectoriesOk(FilePrint print1, FilePrint print2)
        {
            // Check for "between immediate and subdirectories" filter.
            // Other filters are taken care of before this method by only passing in the required files.

            if (model.SearchScopeSelectedValue != DuplicatesFormModel.SearchScope.BetweenImmediateAndSubdirs)
                return true;
            else if (print1.Directory == model.Directory ^ print2.Directory == model.Directory)
                return true;
            else
                return false;
        }

        public int IgnoreMatchSelectionChanged = 0;

        internal void MatchSelectionChanged()
        {
            if (IgnoreMatchSelectionChanged > 0)
            {
                IgnoreMatchSelectionChanged--;
                Console.WriteLine($"IGNORING MatchSelectionChanged, IgnoreMatchSelectionChanged: {IgnoreMatchSelectionChanged}");
                return;
            }
            else
                Console.WriteLine($"MatchSelectionChanged, MatchesGridViewSelectedRow: {MatchesGridViewSelectedRowIndex}");

            int index = (selectedIndexOverride != -1) ? selectedIndexOverride : MatchesGridViewSelectedRowIndex;

            if (selectedIndexOverride != -1)
                selectedIndexOverride = -1;

            if (index >= 0)
            {
                inspectingDuplicate = model.Duplicates[index];

                if (form.mediaViewerLeft.CurrentMedia == inspectingDuplicate.File2Path)
                    form.mediaViewerLeft.UnloadMedia();

                if (form.mediaViewerRight.CurrentMedia == inspectingDuplicate.File1Path)
                    form.mediaViewerRight.UnloadMedia();

                LoadFile(Side.Left, inspectingDuplicate.File1Path);
                LoadFile(Side.Right, inspectingDuplicate.File2Path);
            }
            else
            {
                inspectingDuplicate = null;
                LoadFile(Side.Left, null);
                LoadFile(Side.Right, null);
            }
        }

        private void LoadFile(Side side, string filePath)
        {
            RichTextBox filenameBox, infoBox;
            MediaViewer mediaViewer;

            if (side == Side.Left)
            {
                filenameBox = form.filenameRichTextBoxLeft;
                infoBox = form.infoRichTextBoxLeft;
                mediaViewer = form.mediaViewerLeft;
            }
            else
            {
                filenameBox = form.filenameRichTextBoxRight;
                infoBox = form.infoRichTextBoxRight;
                mediaViewer = form.mediaViewerRight;
            }

            if (filePath == null)
            {
                filenameBox.Text = null;
                infoBox.Text = null;
                mediaViewer.UnloadMedia();
                return;
            }

            filenameBox.Text = filePath.Replace(model.Directory, "");
            filenameBox.Text += $"\n\nThumbnail: {(side == Side.Left ? inspectingDuplicate.File1ThumbPath : inspectingDuplicate.File2ThumbPath)}";
            //infoBox.Text = "";

            if (Utilities.FileIsImage(filePath))
            {
                mediaViewer.LoadMedia(filePath);
                ShowFileInfo(side, (side == Side.Left ? inspectingDuplicate.fileprint1 : inspectingDuplicate.fileprint2).Size);
            }
            else if (Utilities.FileIsVideo(filePath))
            {
                mediaViewer.LoadMedia(filePath);
                //ShowFileInfo will occur in the vlcControl.Playing event which also grabs the video's size.
            }
        }

        #region Actions

        public void KeepSide(Side side, int? index = null)
        {
            if (index != null && index >= 0)
            {
                Do(new KeepSide(this, model.Duplicates[index.Value], index.Value, side));
            }
            else
            { 
                Do(new KeepSide(this, inspectingDuplicate, MatchesGridViewSelectedRowIndex, side));
            }
        }

        public void Skip(int index = -1)
        {
            Duplicate dupe = index >= 0 ? model.Duplicates[index] : inspectingDuplicate;
            int dupeIndex = index >= 0 ? index : MatchesGridViewSelectedRowIndex;

            Do(new Skip(this, dupe, dupeIndex));
        }

        public void KeepNeither(int index = -1)
        {
            Duplicate dupe = index >= 0 ? model.Duplicates[index] : inspectingDuplicate;
            int dupeIndex = index >= 0 ? index : MatchesGridViewSelectedRowIndex;

            Do(new DeleteBothSides(this, dupe, dupeIndex));
        }

        public void IgnoreFileOrDirectory(int? index, IgnoreType ignoreType, Side side)
        {
            Duplicate duplicate = (index != null && index >= 0) ? model.Duplicates[index.Value] : inspectingDuplicate;
            IgnoreSide ignoreAction = new IgnoreSide(this, duplicate, ignoreType, side);

            Do(ignoreAction);
        }

        #endregion

        private void ShowFileInfo(Side side, Size size, bool clear = true)
        {
            int selectedRowIndex = MatchesGridViewSelectedRowIndex;
            var filename = side == Side.Left ? model.Duplicates[selectedRowIndex].File1Path : model.Duplicates[selectedRowIndex].File2Path;
            RichTextBox infoBox = (side == Side.Left) ? form.infoRichTextBoxLeft : form.infoRichTextBoxRight;

            if (clear)
                infoBox.Text = "";

            if (size.Width != 0 && size.Height != 0)
            {
                infoBox.AppendText($"Width: {size.Width}\n");
                infoBox.AppendText($"Height: {size.Height}\n");
            }

            var tags = Utilities.GetTags(filename);
            var otherFileTags = Utilities.GetTags(side == Side.Left ? model.Duplicates[selectedRowIndex].File2Path : model.Duplicates[selectedRowIndex].File1Path);

            infoBox.AppendText($"'Tags': {tags.Length}\n");

            for (int i = 0; i < tags.Length; i++)
            {
                infoBox.SelectionFont = new Font(infoBox.Font, FontStyle.Regular);

                if (!otherFileTags.Contains(tags[i]))
                    infoBox.SelectionFont = new Font(infoBox.Font, infoBox.SelectionFont.Style | FontStyle.Bold);

                if (Settings.Default.Tags?.Contains(tags[i]) ?? false)
                    infoBox.SelectionFont = new Font(infoBox.Font, infoBox.SelectionFont.Style | FontStyle.Italic);

                //if (!otherFileTags.Contains(tags[i]) && Settings.Default.Tags.Contains(tags[i]))
                //infoBox.SelectionFont = new Font(infoBox.Font, FontStyle.Bold | FontStyle.Italic);

                infoBox.AppendText($"{tags[i]}\n");
            }

            infoBox.SelectionFont = new Font(infoBox.Font, FontStyle.Regular);
        }

        internal void OpenSettings()
        {
            SettingsForm settingsForm = new SettingsForm();
            settingsForm.Show();
        }

        internal void Closing()
        {
            SaveSettingsPreferences();
        }

        private void SaveSettingsPreferences()
        {
            Settings.Default.DuplicateSearch.SearchImages = model.SearchImages;
            Settings.Default.DuplicateSearch.SearchVideos = model.SearchVideos;
            Settings.Default.DuplicateSearch.OnlyMatchSameFileTypes = model.OnlyMatchSameFileTypes;
            Settings.Default.DuplicateSearch.CropLeftRightSides = model.CropLeftAndRight;
            Settings.Default.DuplicateSearch.CropTopBottomSides = model.CropTopAndBottom;
            Settings.Default.DuplicateSearch.SearchThreadCount = model.ThreadCount;
            Settings.Default.DuplicateSearch.SearchSimilarityPercentage = model.Similarity;
            Settings.Default.DuplicateSearch.MergeFileTags = model.MergeFileTags;
            Settings.Default.DuplicateSearch.OnlyKeepTagsInLibrary = model.OnlyKeepTagsThatAreInLibrary;
            Settings.Save();
        }
    }
}
