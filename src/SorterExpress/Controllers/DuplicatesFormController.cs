using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Threading;
using System.Windows.Forms;
using GChan.Controls;
using Microsoft.VisualBasic.FileIO;
using SorterExpress.Controls;
using SorterExpress.Properties;
using SorterExpress.Forms;
using System.Runtime.CompilerServices;
using SorterExpress.Classes.Actions.SortActions;
using System.Security.Policy;
using SorterExpress.Classes.Actions.DuplicateActions;
using System.Windows.Forms.VisualStyles;
using Vlc.DotNet.Forms;
using Vlc.DotNet.Core;
using Shortcut = SorterExpress.Classes.Shortcut;

namespace SorterExpress.Controllers
{
    public class DuplicatesFormModel : INotifyPropertyChanged
    {
        public enum FormState { NoDirectoryOpen, DirectoryOpen, Searching, Sorting };

        public FormState State { get { return FindState(); } }

        private FormState FindState()
        {
            if (String.IsNullOrWhiteSpace(directory))
            {
                //Console.WriteLine("FindState returns NoDirectoryOpen.");
                return FormState.NoDirectoryOpen;
            }

            // A directory is open from this point down.

            if (searching)
            {
                Console.WriteLine("FindState returns Searching.");
                return FormState.Searching;
            }
            
            if (Duplicates.Count > 0)
            {
                //Console.WriteLine("FindState returns Sorting.");
                return FormState.Sorting;
            }

            //Console.WriteLine("FindState returns DirectoryOpen.");
            return FormState.DirectoryOpen;
        }

        private void UpdateVisibiliyAndEnabledProperties()
        {
            string[] propertyNames = {
                nameof(StateDirectoryOpen),
                nameof(StateSearching),
                nameof(StateNotSearching),
                nameof(StateSorting),
                nameof(StateDirectoryOpenOrSorting),
                nameof(EnableOnlyKeepTagsInLibraryButton)
            };

            for (int i = 0; i < propertyNames.Length; i++)
            {
                NotifyPropertyChanged(propertyNames[i]);
            }
        }

        public bool StateDirectoryOpen { get { return State == FormState.DirectoryOpen; } }

        public bool StateDirectoryOpenOrSorting { get { return State == FormState.DirectoryOpen || State == FormState.Sorting; } }

        public bool StateSearching { get { return State == FormState.Searching; } }

        public bool StateNotSearching { get { return State != FormState.Searching; } }

        public bool StateSorting { get { return State == FormState.Sorting; } }

        private string directory;
        public string Directory { get { return directory; } set { directory = value; /*NotifyPropertyChanged();*/ UpdateVisibiliyAndEnabledProperties(); } }

        public Stack<DuplicateAction> DoneActions { get; set; } = new Stack<DuplicateAction>();

        public bool EnableUndoButton { get { return DoneActions.Count > 0; } }//{ get { return DoneActions != null ? DoneActions.Count > 0 : false; } }

        public Stack<DuplicateAction> UndoneActions { get; set; } = new Stack<DuplicateAction>();

        public bool EnableRedoButton { get { return UndoneActions.Count > 0; } }//{ get { return UndoneActions != null ? UndoneActions.Count > 0 : false; } }

        private bool searching = false;

        public bool Searching { get { return searching; } set { searching = value; NotifyPropertyChanged(); UpdateVisibiliyAndEnabledProperties(); } }

        public List<string> Files = new List<string>();

        public SortableBindingList<Duplicate> Duplicates { get; set; } = new SortableBindingList<Duplicate>();

        public enum SearchScope
        {
            [Description("Immediate Directory Only")] ImmediateOnly,
            [Description("Subdirectories Only")] SubdirsOnly,
            [Description("Between Immediate and Subdirectories")] BetweenImmediateAndSubdirs,
            [Description("Search All Files")] All
        }

        private SearchScope searchScopeSelectedValue = SearchScope.ImmediateOnly;
        private bool searchImages = Settings.Default.DuplicatesSearchImages;
        private bool searchVideos = Settings.Default.DuplicatesSearchVideos;
        private bool onlyMatchSameFileTypes = Settings.Default.DuplicatesOnlyMatchSameFileTypes;
        private bool cropLeftAndRight = Settings.Default.DuplicatesCropLeftRightSides;
        private bool cropTopAndBottom = Settings.Default.DuplicatesCropTopBottomSides;
        private int threadCount = Settings.Default.DuplicatesSearchThreadCount == 0 ? Environment.ProcessorCount : Settings.Default.DuplicatesSearchThreadCount;
        private int similarity = Settings.Default.DuplicatesSearchSimilarityPercentage;
        private bool mergeFileTags = Settings.Default.DuplicatesMergeFileTags;
        private bool onlyKeepTagsThatAreInLibrary = Settings.Default.DuplicatesOnlyKeepTagsInLibrary;

        public event PropertyChangedEventHandler PropertyChanged;

        public void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            Console.WriteLine($"NotifyPropertyChanged! propertyName: {propertyName}");
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #region View Variables

        public int FileCount => Files == null ? 0 : Files.Count;

        public string FileAndMatchesCountText => $"Files: {(Files == null ? 0 : Files.Count)} Matches: {(Duplicates == null ? 0 : Duplicates.Count)}";

        public bool EnableOnlyKeepTagsInLibraryButton => StateDirectoryOpenOrSorting && MergeFileTags;

        #endregion

        //User options in form
        public SearchScope SearchScopeSelectedValue { get { return searchScopeSelectedValue; } set { searchScopeSelectedValue = value; NotifyPropertyChanged(); } }
        public bool SearchImages { get { return searchImages; } set { searchImages = value; NotifyPropertyChanged(); } }
        public bool SearchVideos { get { return searchVideos; } set { searchVideos = value; NotifyPropertyChanged(); } }
        public bool OnlyMatchSameFileTypes { get { return onlyMatchSameFileTypes; } set { onlyMatchSameFileTypes = value; NotifyPropertyChanged(); } }
        public bool CropLeftAndRight { get { return cropLeftAndRight; } set { cropLeftAndRight = value; NotifyPropertyChanged(); } }
        public bool CropTopAndBottom { get { return cropTopAndBottom; } set { cropTopAndBottom = value; NotifyPropertyChanged(); } }
        public int ThreadCount { get { return threadCount; } set { threadCount = value; NotifyPropertyChanged(); } }
        public int Similarity { get { return similarity; } set { similarity = value; NotifyPropertyChanged(); } }
        public bool MergeFileTags { get { return mergeFileTags; } set { mergeFileTags = value; NotifyPropertyChanged(); NotifyPropertyChanged(nameof(EnableOnlyKeepTagsInLibraryButton)); } }
        public bool OnlyKeepTagsThatAreInLibrary { get { return onlyKeepTagsThatAreInLibrary; } set { onlyKeepTagsThatAreInLibrary = value; NotifyPropertyChanged(); } }

        //public SearchScope SearchScopeSelectedEnum => EnumHelper.GetEnumFromDescription<SearchScope>(SearchScopeSelectedValue);

        public DuplicatesFormModel()
        {
            Duplicates.ListChanged += (o, e) => { NotifyPropertyChanged(nameof(this.FileAndMatchesCountText)); };
        }
    }

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

        public enum Side { Left, Right };

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

        public DuplicatesFormController(DuplicatesForm duplicatesForm, DirectoryInfo dirInfo)
        {
            form = duplicatesForm;
            model = new DuplicatesFormModel();
            model.Duplicates = new SortableBindingList<Duplicate>();
            //form.duplicatesFormModelBindingSource.DataSource = model;
            //form.searchScopeComboBox.DataSource = EnumHelper.GetEnumDescriptions(typeof(DuplicatesFormModel.SearchScope));

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

        internal void VlcControl_Playing(object sender, Vlc.DotNet.Core.VlcMediaPlayerPlayingEventArgs e)
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
                (side == Side.Left ? inspectingDuplicate.fileprint1 : inspectingDuplicate.fileprint2).size = size;

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

        private void SearchSubfoldersCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }

        internal void OpenDirectoryDialog()
        {
            var dirInfo = Utilities.OpenDirectory();

            if (dirInfo == null)
                Logs.Log(true, "Directory open cancelled.");
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

            Logs.Log(true, $"Opened '{model.Directory}' and found { model.Files.Count} files.");

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
            Settings.Default.DuplicatesCropLeftRightSides = model.CropLeftAndRight;
            Settings.Default.DuplicatesCropTopBottomSides = model.CropTopAndBottom;

            printsWorker.RunWorkerAsync();
        }

        public void CancelSearch()
        {
            Console.WriteLine("Cancelling duplicate search worker!");
            cancelTokenSource.Cancel();
        }

        private List<string> GetSearchScope(List<string> files)
        {
            return files.Where(
                t => (model.SearchImages && Utilities.FileIsImage(t)) ||
                (model.SearchVideos && Utilities.FileIsVideo(t)))
                .ToList();
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
            prints.RemoveAll(t => !scope.Contains(t.filepath.Replace(model.Directory, "")));

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
                            FilePrint print = null;

                            //try
                            //{
                            if (!prints.Exists(t => t.filepath.Replace(model.Directory, "") == filename))
                            {
                                print = new FilePrint(Path.Combine(model.Directory, filename));
                                prints.Add(print);
                            }
                            else
                            {
                                //This should never get hit...
                                Console.WriteLine("The thing that should never get hit got hit.");
                                print = prints.Find(t => t.filepath.Replace(model.Directory, "") == filename);
                            }
                            /*}
                            catch //Exceptions can occur from accessing files.
                            {
                                Console.WriteLine($"Error occured while generating print for file {Path.Combine(directory, filename)}.");
                                print = null;
                            }*/

                            if (print != null)
                            {
                                // For each print that is currently generated
                                for (int i = 0; i < prints.Count; i++)
                                {
                                    try
                                    {
                                        // Don't match with self
                                        if (print != prints[i])
                                        {
                                            // If similarity is above threshold
                                            if (FilePrint.GetSimilarityPercentage(print, prints[i]) >= model.Similarity)
                                            {
                                                // If the duplicate hasn't already been found or found in reverse (x is like y |or| y is like x)
                                                if (!model.OnlyMatchSameFileTypes || (model.OnlyMatchSameFileTypes && print.fileType == prints[i].fileType)) 
                                                {

                                                    //Check for "between immediate and subdirectories" filter.
                                                    bool ok = false;

                                                    if (model.SearchScopeSelectedValue != DuplicatesFormModel.SearchScope.BetweenImmediateAndSubdirs)
                                                        ok = true;
                                                    else if (print.directory == model.Directory ^ prints[i].directory == model.Directory)
                                                        ok = true;

                                                    if (ok)
                                                    { 
                                                        if (!model.Duplicates.Any(t => t.File2Path == print.filepath && t.File1Path == prints[i].filepath))
                                                        { 
                                                            form.Invoke((MethodInvoker)delegate()
                                                            {
                                                                model.Duplicates.Add(new Duplicate(print, prints[i]));
                                                            });
                                                        }
                                                    }
                                                }
                                            }
                                        }
                                    }
                                    catch (InvalidOperationException ioe)
                                    {
                                        Console.WriteLine($"Encountered InvalidOperationException while generating prints. {ioe.Message} - {ioe.StackTrace}");
                                    }
                                    catch (IndexOutOfRangeException ioore)
                                    {
                                        Console.WriteLine($"Encountered IndexOutOfRangeException while generating prints. {ioore.Message} - {ioore.StackTrace}");
                                        // Catching the if statement "if (print.file != prints[i].file)". Can occasionally get ahead of itself (2% chance).
                                    }
                                    catch (NullReferenceException nre)
                                    {
                                        Console.WriteLine($"Encountered NullReferenceException while generating prints. {nre.Message} - {nre.StackTrace}");
                                    }
                                }

                                finishedThreads++;
                                worker.ReportProgress(finishedThreads * 100 / files.Count);
                            }
                        }
                    });
            }
            catch (OperationCanceledException oce)
            {
                Console.WriteLine($"Encountered OperationCanceledException while generating prints, this is probably intentional. {oce.Message} - {oce.StackTrace}");
            }
            catch (NullReferenceException nre)
            {
                Console.WriteLine($"Encountered NullReferenceException while generating prints. {nre.Message} - {nre.StackTrace}");
            }

            return prints;
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
                ShowFileInfo(side, (side == Side.Left ? inspectingDuplicate.fileprint1 : inspectingDuplicate.fileprint2).size);
            }
            else if (Utilities.FileIsVideo(filePath))
            {
                mediaViewer.LoadMedia(filePath);
                //ShowFileInfo will occur in the vlcControl.Playing event which also grabs the video's size.
            }
        }

        #region Actions

        public void KeepSide(Side side, int index = -1)
        {
            if (index >= 0)
                Do(new KeepSide(this, model.Duplicates[index], index, side));
            else
                Do(new KeepSide(this, inspectingDuplicate, MatchesGridViewSelectedRowIndex, side));
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
            Settings.Default.DuplicatesSearchImages = model.SearchImages;
            Settings.Default.DuplicatesSearchVideos = model.SearchVideos;
            Settings.Default.DuplicatesOnlyMatchSameFileTypes = model.OnlyMatchSameFileTypes;
            Settings.Default.DuplicatesCropLeftRightSides = model.CropLeftAndRight;
            Settings.Default.DuplicatesCropTopBottomSides = model.CropTopAndBottom;
            Settings.Default.DuplicatesSearchThreadCount = model.ThreadCount;
            Settings.Default.DuplicatesSearchSimilarityPercentage = model.Similarity;
            Settings.Default.DuplicatesMergeFileTags = model.MergeFileTags;
            Settings.Default.DuplicatesOnlyKeepTagsInLibrary = model.OnlyKeepTagsThatAreInLibrary;
            Settings.Default.Save();
        }
    }
}
