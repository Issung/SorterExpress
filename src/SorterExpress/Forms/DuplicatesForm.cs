using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using GChan.Controls;
using Microsoft.VisualBasic.FileIO;
using SorterExpress.Controls;
using SorterExpress.Properties;

namespace SorterExpress.Forms
{
    public partial class DuplicatesForm : Form
    {
        public static DuplicatesForm form;
        public string directory;
        public List<string> files;

        public List<FilePrint> prints;
        //public List<Duplicate> duplicates;
        public SortableBindingList<Duplicate> duplicates;

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

        /// <summary>
        /// Indicates whether the user has agreed to deleting files or not.
        /// </summary>
        private bool deletingOK = false;

        Duplicate inspectingDuplicate;

        public bool MergeFileTags { get { return mergeFileTagsCheckBox.Checked; } }
        public bool OnlyKeepLibraryTags { get { return onlyKeepLibraryTagsCheckBox.Checked; } }

        public int MatchesGridViewSelectedRow { get { return matchesDataGridView?.CurrentCell?.RowIndex ?? -1; } }

        public DuplicatesForm(DirectoryInfo dirInfo)
        {
            InitializeComponent();
            form = this;

            ///Stuff designer can't do
            
            matchesDataGridView.AutoGenerateColumns = false;
            duplicates = new SortableBindingList<Duplicate>();
            matchesDataGridView.DataSource = duplicates;
            duplicates.ListChanged += Duplicates_ListChanged;

            ///Stuff designer can't do

            this.FormClosed += ApplicationExit;

            threadCountNumeric.Value = Environment.ProcessorCount;

            printsWorker = new BackgroundWorker {
                WorkerReportsProgress = true,
                WorkerSupportsCancellation = true
            };
            printsWorker.DoWork += Worker_DoWork;
            printsWorker.ProgressChanged += Worker_ProgressChanged;
            printsWorker.RunWorkerCompleted += Worker_Completed;

            imagesCheckBox.Checked = Settings.Default.DuplicatesSearchImages;
            videosCheckBox.Checked = Settings.Default.DuplicatesSearchVideos;
            cropLeftRightCheckBox.Checked = Settings.Default.DuplicatesCropLeftRightSides;
            cropTopBottomCheckBox.Checked = Settings.Default.DuplicatesCropTopBottomSides;
            similarityNumeric.Value = Settings.Default.DuplicatesSearchSimilarityPercentage;

            mergeFileTagsCheckBox.Checked = Settings.Default.DuplicatesMergeFileTags;
            onlyKeepLibraryTagsCheckBox.Checked = Settings.Default.DuplicatesOnlyKeepTagsInLibrary;
            onlyKeepLibraryTagsCheckBox.Enabled = mergeFileTagsCheckBox.Checked;

            if (Settings.Default.DuplicatesSearchThreadCount == 0)
                threadCountNumeric.Value = Environment.ProcessorCount;
            else
                threadCountNumeric.Value = Settings.Default.DuplicatesSearchThreadCount;

            if (dirInfo != null)
            {
                LoadDirectory(dirInfo);
            }
        }

        private void Duplicates_ListChanged(object sender, ListChangedEventArgs e)
        {
            UpdateFileCountLabel();
        }

        private void LoadDirectory(DirectoryInfo dirInfo)
        {
            this.directory = dirInfo.FullName;

            if (files != null)
                files.Clear();

            if (duplicates != null)
                duplicates.Clear();

            if (prints != null)
                prints.Clear();

            if (searchSubfoldersCheckBox.Checked)
                this.files = Utilities.RecursivelyGetFileNames(dirInfo.FullName);
            else
                this.files = dirInfo.GetFileNamesList();

            Logs.Log(true, "Opened '" + directory + "' and found " + files.Count + " files.");

            Utilities.PrintExtensionCounts(files);

            UpdateFileCountLabel();
            Console.WriteLine("Image file count: " + files.Where(t => Utilities.FileIsImage(t)).Count());
            Console.WriteLine("Video file count: " + files.Where(t => Utilities.FileIsVideo(t)).Count());

            searchSubfoldersCheckBox.Enabled = true;
            similarityNumeric.Enabled = true;
            imagesCheckBox.Enabled = true;
            videosCheckBox.Enabled = true;
            cropLeftRightCheckBox.Enabled = true;
            cropTopBottomCheckBox.Enabled = true;
            threadCountNumeric.Enabled = true;
            searchButton.Enabled = true;
        }

        public List<string> GetSearchScope(List<string> files)
        {
            return files.Where(
                t => (imagesCheckBox.Checked && Utilities.FileIsImage(t)) ||
                (videosCheckBox.Checked && Utilities.FileIsVideo(t)))
                .ToList();
        }

        private void Worker_DoWork(object sender, DoWorkEventArgs e)
        {
            if (prints == null)
                prints = new List<FilePrint>();

            Console.WriteLine("Starting to generate prints...");
            var scope = GetSearchScope(files);
            scopeCount = scope.Count;

            Invoke((MethodInvoker)delegate () { 
                duplicates.Clear();
            });
            prints.RemoveAll(t => !scope.Contains(t.file.Replace(directory, "")));

            GeneratePrints(scope, prints, sender as BackgroundWorker, e);

            Console.WriteLine("Prints generated.");
        }

        private void Worker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            loadingLabel.Text = $"Searching..\n{finishedThreads}/{scopeCount}";
            progressBar.Value = e.ProgressPercentage;

            /*for (int i = matchesDataGridView.Items.Count; i < duplicates.Count; i++)
            {
                matchesListBox.Items.Add($"{matchesListBox.Items.Count + 1}. Chance: {Math.Round(duplicates[i].Chance * 100)}%");
            }*/
        }

        private void Worker_Completed(object sender, RunWorkerCompletedEventArgs e)
        {
            Console.WriteLine("Worker_Completed!");

            searchSubfoldersCheckBox.Enabled = true;
            similarityNumeric.Enabled = true;
            imagesCheckBox.Enabled = true;
            videosCheckBox.Enabled = true;
            cropLeftRightCheckBox.Enabled = true;
            cropTopBottomCheckBox.Enabled = true;
            threadCountNumeric.Enabled = true;
            searchButton.Enabled = true;
            cancelButton.Enabled = false;
            matchesDataGridView.Height += 26;
            loadingLabel.Hide();
            progressBar.Hide();

            stopwatch.Stop();
            Console.WriteLine($"Processed {finishedThreads} files in {stopwatch.ElapsedMilliseconds}ms ({stopwatch.ElapsedMilliseconds / 1000}s) and found {duplicates.Count} duplicates at or above {similarityNumeric.Value}% similarity.");
        }

        private List<FilePrint> GeneratePrints(List<string> files, List<FilePrint> prints, BackgroundWorker worker, DoWorkEventArgs dwea)
        {
            if (!Directory.Exists(Program.THUMBS_PATH))
                Directory.CreateDirectory(Program.THUMBS_PATH);

            if (files == null)
            {
                loadingLabel.Hide();
                return null;
            }

            finishedThreads = 0;

            cancelTokenSource = new CancellationTokenSource();

            var options = new ParallelOptions {
                MaxDegreeOfParallelism = (int)threadCountNumeric.Value,
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
                                if (!prints.Exists(t => t.file.Replace(directory, "") == filename))
                                {
                                    print = new FilePrint(Path.Combine(directory, filename));
                                    prints.Add(print);
                                }
                                else
                                {
                                    //This should never get hit...
                                    Console.WriteLine("The thing that should never get hit got hit.");
                                    print = prints.Find(t => t.file.Replace(directory, "") == filename);
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
                                        //if (print.file != prints[i].file)
                                        if (print != prints[i])
                                        {
                                            // If similarity is above threshold
                                            if (FilePrint.GetSimilarityPercentage(print, prints[i]) >= similarityNumeric.Value)
                                            {
                                                try
                                                {
                                                    // If the duplicate hasn't already been found or found in reverse (x is like y |or| y is like x)
                                                    if (!duplicates.Any(t => t.File2Path == print.file && t.File1Path == prints[i].file))
                                                    {
                                                        Invoke((MethodInvoker)delegate()
                                                        {
                                                            duplicates.Add(new Duplicate(print, prints[i]));
                                                        });
                                                    }
                                                }
                                                catch (InvalidOperationException ioe)
                                                {
                                                    Console.WriteLine($"Encountered InvalidOperationException while generating prints. {ioe.Message} - {ioe.StackTrace}");
                                                }
                                            }
                                        }
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

        private void LoadFile(Side side, string filePath)
        {
            RichTextBox filenameBox, infoBox;
            MediaViewer mediaViewer;

            if (side == Side.Left)
            {
                filenameBox = filenameRichTextBoxLeft;
                infoBox = infoRichTextBoxLeft;
                mediaViewer = mediaViewerLeft;
            }
            else
            {
                filenameBox = filenameRichTextBoxRight;
                infoBox = infoRichTextBoxRight;
                mediaViewer = mediaViewerRight;
            }

            if (filePath == null)
            {
                filenameBox.Text = null;
                infoBox.Text = null;
                mediaViewer.UnloadMedia();
                return;
            }

            filenameBox.Text = filePath.Replace(directory, "");
            filenameBox.Text += $"\n\nThumbnail: {(side == Side.Left ? inspectingDuplicate.File1ThumbPath : inspectingDuplicate.File2ThumbPath)}";
            infoBox.Text = "";

            if (Utilities.FileIsImage(filePath))
            {
                //string location = (filePath.Contains("/") || filePath.Contains("\\") ? filePath : directory + "/" + filePath);
                //mediaViewer.LoadMedia(location);
                mediaViewer.LoadMedia(filePath);
                ShowFileInfo(side, mediaViewer.PictureBox.Image.Size);
            }
            else if (Utilities.FileIsVideo(filePath))
            {
                mediaViewer.LoadMedia(filePath);

                Size size = prints.Find(t => t.file == filePath)?.size ?? new Size(0, 0);

                mediaViewer.VlcControl.Playing += (o, ea) =>
                {
                    //Console.WriteLine("Playing!");

                    infoBox.Invoke(() => {
                        if (!infoBox.Text.Contains("Width"))
                        {
                            var media = mediaViewer.VlcControl.GetCurrentMedia();

                            // Currently grabbing tracksinformation 0, could be wrong in some cases.
                            string width = media.TracksInformations.Length > 0 ? media.TracksInformations[0].Video.Width.ToString() : "?";
                            string height = media.TracksInformations.Length > 0 ? media.TracksInformations[0].Video.Height.ToString() : "?";

                            infoBox.AppendText($"Width: {width}\n" +
                                $"Height: {height}\n" +
                                $"Duration: {media.Duration.Seconds}s\n");

                            ShowFileInfo(side, size, false);
                        }
                    });
                };
            }
        }

        private void ShowFileInfo(Side side, Size size, bool clear = true)
        {
            int selectedRowIndex = MatchesGridViewSelectedRow;
            var filename = side == Side.Left ? duplicates[selectedRowIndex].File1Path : duplicates[selectedRowIndex].File2Path;
            RichTextBox infoBox = (side == Side.Left) ? infoRichTextBoxLeft : infoRichTextBoxRight;

            if (clear)
                infoBox.Text = "";

            if (size.Width != 0 && size.Height != 0)
            {
                infoBox.AppendText($"Width: {size.Width}\n");
                infoBox.AppendText($"Height: {size.Height}\n");
            }

            var tags = Utilities.GetTags(filename);
            var otherFileTags = Utilities.GetTags(side == Side.Left ? duplicates[selectedRowIndex].File2Path : duplicates[selectedRowIndex].File1Path);

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

        private void UpdateFileCountLabel()
        {
            int count = 0;

            if (files != null)
            {
                if (imagesCheckBox.Checked)
                    count += files.Where(t => Utilities.FileIsImage(t)).Count();

                if (videosCheckBox.Checked)
                    count += files.Where(t => Utilities.FileIsVideo(t)).Count();
            }

            fileCountLabel.Text = $"Files: {count} Matches: {duplicates.Count}";
        }

        private void BeginSearch()
        {
            stopwatch = new System.Diagnostics.Stopwatch();
            stopwatch.Start();

            duplicates.Clear();
            searchButton.Enabled = false;
            cancelButton.Enabled = true;
            loadingLabel.Show();
            progressBar.Show();
            matchesDataGridView.Height -= 26;
            searchSubfoldersCheckBox.Enabled = false;
            similarityNumeric.Enabled = false;
            threadCountNumeric.Enabled = false;
            imagesCheckBox.Enabled = false;
            videosCheckBox.Enabled = false;
            Settings.Default.DuplicatesCropLeftRightSides = cropLeftRightCheckBox.Checked;
            cropLeftRightCheckBox.Enabled = false;
            Settings.Default.DuplicatesCropTopBottomSides = cropTopBottomCheckBox.Checked;
            cropTopBottomCheckBox.Enabled = false;

            printsWorker.RunWorkerAsync();
        }

        private bool CheckDeletingFilesOkay()
        {
            if (deletingOK)
            {
                return true;
            }
            else
            {
                DialogResult result = MessageBox.Show(
                    "This action will delete the other image that you do not want, is that okay?\n"
                  + "The deleted files will be moved to the Recycle Bin, where they can be manually recovered if desired.",
                    "Deletion Warning", 
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning
                );

                if (result == DialogResult.Yes)
                {
                    deletingOK = true;
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        /// <summary>
        /// Delete a file and remove and duplicates that contain that file.
        /// UNLOAD REQUIRED MEDIA BEFORE CALLING THIS METHOD.
        /// </summary>
        void DeleteFile(string filePath)
        {
            //const bool DELETE_THUMB = true;

            //UNLOAD REQUIRED MEDIA BEFORE CALLING THIS METHOD.
            //mediaViewerLeft.UnloadMedia();
            //mediaViewerRight.UnloadMedia();

            FileSystem.DeleteFile(filePath, UIOption.OnlyErrorDialogs, RecycleOption.SendToRecycleBin, UICancelOption.ThrowException);

            for (int i = 0; i < duplicates.Count; i++)
            {
                if (duplicates[i].File1Path == filePath || duplicates[i].File2Path == filePath)
                {
                    duplicates.RemoveAt(i);

                    // Go back an index because future objects will move down an index.
                    i--;
                }
            }

            for (int i = 0; i < prints.Count; i++)
            {
                if (prints[i].file == filePath)
                {
                    prints.RemoveAt(i);

                    // Go back an index because future objects will move down an index.
                    i--;
                }
            }

            //matchesDataGridView.Refresh();
            //matchesDataGridView.Update();

            //Disabled because it currently has errors with the file being in use. Probably by the duplicates grid view?
            /*if (DELETE_THUMB)
            {
               File.Delete(Path.Combine(Program.THUMBS_PATH, Utilities.MD5(Path.GetFileName(filePath)) + ".jpg"));
            }*/
        }

        private void KeepSide(Side side)
        {
            if (CheckDeletingFilesOkay())
            {
                if (side == Side.Left)
                    mediaViewerRight.UnloadMedia();
                else
                    mediaViewerLeft.UnloadMedia();

                string fileToKeep = (side == Side.Left) ? inspectingDuplicate.File1Path : inspectingDuplicate.File2Path;
                string fileToDelete = (side == Side.Left) ? inspectingDuplicate.File2Path : inspectingDuplicate.File1Path;

                if (MergeFileTags)
                {
                    var mergedTags = Utilities.GetTags(fileToKeep).ToList();
                    mergedTags.AddRange(Utilities.GetTags(fileToDelete));
                    mergedTags = mergedTags.GroupBy(t => t).Select(t => t.Key).ToList();

                    if (OnlyKeepLibraryTags)
                    {
                        mergedTags.RemoveAll(t => !Settings.Default.Tags.Contains(t));
                    }

                    mergedTags.Sort();

                    string fileToKeepNewName = string.Join(" ", mergedTags) + Path.GetExtension(fileToKeep).ToLower();

                    Utilities.MoveFile(fileToKeep, Path.Combine(Path.GetDirectoryName(fileToKeep), fileToKeepNewName));

                    Console.WriteLine($"Renamed {fileToKeep.Replace(directory, "")} to {fileToKeepNewName}");
                }

                DeleteFile(fileToDelete);
            }
        }

        #region Form Events

        private void KeepLeftButton_Click(object sender, EventArgs e)
        {
            KeepSide(Side.Left);
        }

        private void KeepRightButton_Click(object sender, EventArgs e)
        {
            KeepSide(Side.Right);
        }

        private void KeepBothButton_Click(object sender, EventArgs e)
        {
            int selectedIndex = MatchesGridViewSelectedRow;
            if (selectedIndex < duplicates.Count - 1)
            {
                selectedIndexOverride = selectedIndex + 1;
                matchesDataGridView.CurrentCell = matchesDataGridView.Rows[selectedIndex + 1].Cells[0];
            }
        }

        private void matchesDataGridView_SelectionChanged(object sender, EventArgs e)
        {
            Console.WriteLine($"matchesDataGridView_SelectedIndexChanged, MatchesGridViewSelectedRow: {MatchesGridViewSelectedRow}");

            int index = (selectedIndexOverride != -1) ? selectedIndexOverride : MatchesGridViewSelectedRow;

            if (selectedIndexOverride != -1)
                selectedIndexOverride = -1;

            if (index >= 0)
            {
                inspectingDuplicate = duplicates[index];

                if (mediaViewerLeft.CurrentMedia == inspectingDuplicate.File2Path)
                    mediaViewerLeft.UnloadMedia();

                if (mediaViewerRight.CurrentMedia == inspectingDuplicate.File1Path)
                    mediaViewerRight.UnloadMedia();

                LoadFile(Side.Left, inspectingDuplicate.File1Path);
                LoadFile(Side.Right, inspectingDuplicate.File2Path);
            }
            else
            {
                inspectingDuplicate = null;
            }
        }

        private void OpenDirectoryButton_Click(object sender, EventArgs e)
        {
            var dirInfo = Utilities.OpenDirectory();

            if (dirInfo == null)
                Logs.Log(true, "Directory open cancelled.");
            else
            {
                LoadDirectory(dirInfo);
            }
        }

        private void SearchButton_Click(object sender, EventArgs e)
        {
            BeginSearch();
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            cancelTokenSource.Cancel();
        }

        private void ImagesCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            UpdateFileCountLabel();
        }

        private void VideosCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            UpdateFileCountLabel();
        }

        private void SearchSubfoldersCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            //TODO: Refactor this code somewhere else, also use in constructor/load methods.
            if (directory != null && !String.IsNullOrWhiteSpace(directory))
            {
                if (searchSubfoldersCheckBox.Checked)
                {
                    files = Utilities.RecursivelyGetFileNames(directory).Select(t => t.Replace(directory, "").Substring(1)).ToList();
                }
                else
                    files = Directory.GetFiles(directory)
                        .Select(t => Path.GetFileName(t))
                        .ToList();
            }

            UpdateFileCountLabel();
        }

        private void keepNeitherButton_Click(object sender, EventArgs e)
        {
            if (CheckDeletingFilesOkay())
            {
                mediaViewerLeft.UnloadMedia();
                mediaViewerRight.UnloadMedia();

                // Can't do DeleteFile(inspectingDuplicate.fileX) because the duplicate object will be deleted after the first operation.
                string file1 = inspectingDuplicate.File1Path;
                string file2 = inspectingDuplicate.File2Path;

                DeleteFile(file1);
                DeleteFile(file2);
            }
        }

        private void mergeFileTagsCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            onlyKeepLibraryTagsCheckBox.Enabled = mergeFileTagsCheckBox.Checked;
        }

        #endregion

        private void ApplicationExit(object sender, FormClosedEventArgs e)
        {
            Settings.Default.DuplicatesSearchSimilarityPercentage = (int)similarityNumeric.Value;
            Settings.Default.DuplicatesSearchImages = imagesCheckBox.Checked;
            Settings.Default.DuplicatesSearchVideos = videosCheckBox.Checked;
            Settings.Default.DuplicatesCropLeftRightSides = cropLeftRightCheckBox.Checked;
            Settings.Default.DuplicatesCropTopBottomSides = cropTopBottomCheckBox.Checked;
            Settings.Default.DuplicatesSearchThreadCount = (int)threadCountNumeric.Value;
            Settings.Default.DuplicatesMergeFileTags = MergeFileTags;
            Settings.Default.DuplicatesOnlyKeepTagsInLibrary = OnlyKeepLibraryTags;

            Settings.Default.Save();
        }
    }
}
