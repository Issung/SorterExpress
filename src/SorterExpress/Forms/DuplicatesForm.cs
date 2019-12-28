using Microsoft.VisualBasic.FileIO;
using SorterExpress.Controls;
using SorterExpress.Properties;
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
using Vlc.DotNet.Forms;

namespace SorterExpress.Forms
{
    public partial class DuplicatesForm : Form
    {
        public static DuplicatesForm form;
        public string directory;
        public List<string> files;

        public List<FilePrint> prints;
        public List<Duplicate> duplicates;

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

        public DuplicatesForm(DirectoryInfo dirInfo)
        {
            InitializeComponent();
            form = this;

            this.FormClosed += ApplicationExit;

            ///

            threadCountNumeric.Value = System.Environment.ProcessorCount;

            printsWorker = new BackgroundWorker();
            printsWorker.WorkerReportsProgress = true;
            printsWorker.WorkerSupportsCancellation = true;
            printsWorker.DoWork += Worker_DoWork;
            printsWorker.ProgressChanged += Worker_ProgressChanged;
            printsWorker.RunWorkerCompleted += Worker_Completed;

            similarityNumeric.Value = Settings.Default.DuplicatesSearchSimilarityPercentage;
            imagesCheckBox.Checked = Settings.Default.DuplicatesSearchImages;
            videosCheckBox.Checked = Settings.Default.DuplicatesSearchVideos;

            if (Settings.Default.DuplicatesSearchThreadCount == 0)
                threadCountNumeric.Value = System.Environment.ProcessorCount;
            else
                threadCountNumeric.Value = Settings.Default.DuplicatesSearchThreadCount;

            if (dirInfo != null)
            {
                LoadDirectory(dirInfo);
                BeginSearch();
            }
        }

        public List<string> GetSearchScope(List<string> files)
        {
            return files.Where(
                t =>
                (imagesCheckBox.Checked && Utilities.FileIsImage(t)) ||
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

            duplicates = new List<Duplicate>();
            //prints.RemoveAll(t => !scope.Contains(Path.GetFileName(t.file)));
            prints.RemoveAll(t => !scope.Contains(t.file.Replace(directory + "\\", "")));

            GeneratePrints(scope, prints, sender as BackgroundWorker, e);

            Console.WriteLine("Prints generated.");
        }

        private void Worker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            loadingLabel.Text = $"Searching..\n{finishedThreads}/{scopeCount}";
            progressBar.Value = e.ProgressPercentage;

            for (int i = matchesListBox.Items.Count; i < duplicates.Count; i++)
            {
                matchesListBox.Items.Add($"{matchesListBox.Items.Count + 1}. Chance: {Math.Round(duplicates[i].chance * 100)}%");
            }
        }

        private void Worker_Completed(object sender, RunWorkerCompletedEventArgs e)
        {
            Console.WriteLine("Worker_Completed!");

            searchSubfoldersCheckBox.Enabled = true;
            similarityNumeric.Enabled = true;
            imagesCheckBox.Enabled = true;
            videosCheckBox.Enabled = true;
            threadCountNumeric.Enabled = true;
            searchButton.Enabled = true;
            cancelButton.Enabled = false;
            matchesListBox.Height += 26;
            loadingLabel.Hide();
            progressBar.Hide();

            stopwatch.Stop();
            Console.WriteLine($"Processed {finishedThreads} files in {stopwatch.ElapsedMilliseconds}ms ({stopwatch.ElapsedMilliseconds / 1000}s) and found {duplicates.Count} duplicates at or above {similarityNumeric.Value}% similarity.");
        }

        private List<FilePrint> GeneratePrints(List<string> files, List<FilePrint> prints, BackgroundWorker worker, DoWorkEventArgs dwea)
        {
            if (!Directory.Exists(Program.VIDEO_THUMBS_PATH))
                Directory.CreateDirectory(Program.VIDEO_THUMBS_PATH);

            if (files == null)
            {
                loadingLabel.Hide();
                return null;
            }

            finishedThreads = 0;

            cancelTokenSource = new CancellationTokenSource();
            var options = new ParallelOptions();
            options.MaxDegreeOfParallelism = (int)threadCountNumeric.Value;
            options.CancellationToken = cancelTokenSource.Token;

            try
            {
                Parallel.ForEach(
                    files,
                    options,
                    (filename, state) =>
                    {
                        if (options.CancellationToken.IsCancellationRequested)
                            state.Stop();
                        else
                        {
                            FilePrint print;
                            
                            if (!prints.Exists(t => t.file.Replace(directory + "\\", "") == filename))
                            {
                                print = new FilePrint(directory + "\\" + filename);
                                prints.Add(print);
                            }
                            else
                            {
                                print = prints.Find(t => t.file.Replace(directory + "\\", "") == filename);
                            }

                            for (int i = 0; i < prints.Count; i++)
                            {
                                if (print.file != prints[i].file)
                                {
                                    if (FilePrint.GetSimilarityPercentage(print, prints[i]) >= similarityNumeric.Value)
                                    {
                                        try
                                        {
                                            //if (duplicates.Where(t => t.file2 == print.file && t.file1 == prints[i].file).Count() == 0)
                                            if (!duplicates.Exists(t => t.file2 == print.file && t.file1 == prints[i].file))
                                            {
                                                Duplicate duplicate = new Duplicate(print, prints[i]);
                                                duplicates.Add(duplicate);
                                            }
                                        }
                                        catch (InvalidOperationException ioe)
                                        {
                                            Console.WriteLine("InvalidOperationException generating prints. " + ioe.ToString());
                                        }
                                    }
                                }
                            }

                            finishedThreads++;
                            worker.ReportProgress(finishedThreads * 100 / files.Count);
                        }
                    }
                );
            }
            catch (OperationCanceledException)
            {

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
            infoBox.Text = "";

            if (Utilities.FileIsImage(filePath))
            {
                string location = (filePath.Contains("/") || filePath.Contains("\\") ? filePath : directory + "/" + filePath);
                mediaViewer.LoadMedia(location);
                ShowFileInfo(side, mediaViewer.PictureBox.Image.Size);
                
            }
            else if (Utilities.FileIsVideo(filePath))
            {
                mediaViewer.LoadMedia(filePath);

                Size size = prints.Find(t => t.file == filePath)?.size ?? new Size(0, 0);
                ShowFileInfo(side, size);

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

                            infoBox.Text = $"Width: {width}\nHeight: {height}\nDuration: {media.Duration.Seconds}s\n" + infoBox.Text;
                        }
                    });
                };
            }
        }

        private void ShowFileInfo(Side side, Size size)
        {
            var filename = side == Side.Left ? duplicates[matchesListBox.SelectedIndex].file1 : duplicates[matchesListBox.SelectedIndex].file2;
            var vlcControl = side == Side.Left ? mediaViewerLeft.VlcControl : mediaViewerLeft.VlcControl;
            RichTextBox infoBox = (side == Side.Left) ? infoRichTextBoxLeft : infoRichTextBoxRight;

            infoBox.Text = "";

            if (size.Width != 0 && size.Height != 0)
            {
                infoBox.Text += $"Width: {size.Width}\n";
                infoBox.Text += $"Height: {size.Height}\n";
            }

            var tags = Utilities.GetTags(filename);
            var vsTags = Utilities.GetTags(side == Side.Left ? duplicates[matchesListBox.SelectedIndex].file2 : duplicates[matchesListBox.SelectedIndex].file1);

            infoBox.Text += $"'Tags': {tags.Length}\n";

            for (int i = 0; i < tags.Length; i++)
            {
                if (vsTags.Contains(tags[i]))
                    infoBox.SelectionFont = new Font(infoBox.Font, FontStyle.Regular);
                else
                    infoBox.SelectionFont = new Font(infoBox.Font, FontStyle.Bold);

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

            fileCountLabel.Text = $"Files: {count}";
        }

        private void LoadDirectory(DirectoryInfo dirInfo)
        {
            this.directory = dirInfo.FullName;

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
            threadCountNumeric.Enabled = true;
            searchButton.Enabled = true;
        }

        private void BeginSearch()
        {
            stopwatch = new System.Diagnostics.Stopwatch();
            stopwatch.Start();

            matchesListBox.Items.Clear();
            searchButton.Enabled = false;
            cancelButton.Enabled = true;
            loadingLabel.Show();
            progressBar.Show();
            matchesListBox.Height -= 26;
            searchSubfoldersCheckBox.Enabled = false;
            similarityNumeric.Enabled = false;
            threadCountNumeric.Enabled = false;
            imagesCheckBox.Enabled = false;
            videosCheckBox.Enabled = false;

            printsWorker.RunWorkerAsync();
        }

        private void FindDuplicates()
        {
            var options = new ParallelOptions();
            options.MaxDegreeOfParallelism = (int)threadCountNumeric.Value;
            options.CancellationToken = cancelTokenSource.Token;

            duplicates.Clear();
            matchesListBox.Items.Clear();

            for (int i = 0; i < prints.Count; i++)
            {
                for (int j = 0; j < prints.Count; j++)
                {
                    if (i != j)
                    {
                        if (FilePrint.GetSimilarityPercentage(prints[i], prints[j]) >= similarityNumeric.Value)
                        {
                            if (duplicates.Where(t => t.file2 == prints[i].file && t.file1 == prints[i].file).Count() == 0)
                            {
                                Duplicate duplicate = new Duplicate(prints[i], prints[j]);
                                duplicates.Add(duplicate);
                                matchesListBox.Items.Add($"{matchesListBox.Items.Count + 1}. Chance: {duplicate.chance * 100}%");
                            }
                        }
                    }
                }
            }
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
        /// </summary>
        void DeleteFile(string filePath)
        {
            mediaViewerLeft.UnloadMedia();
            mediaViewerRight.UnloadMedia();

            FileSystem.DeleteFile(filePath, UIOption.OnlyErrorDialogs, RecycleOption.SendToRecycleBin, UICancelOption.ThrowException);

            for (int i = 0; i < duplicates.Count; i++)
            {
                if (duplicates[i].file1 == filePath || duplicates[i].file2 == filePath)
                {
                    duplicates.RemoveAt(i);
                    matchesListBox.Items.RemoveAt(i);

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
        }

        #region Form Events

        private void KeepLeftButton_Click(object sender, EventArgs e)
        {
            if (CheckDeletingFilesOkay())
            {
                int selectedIndex = matchesListBox.SelectedIndex;

                DeleteFile(inspectingDuplicate.file2);

                if (matchesListBox.Items.Count > selectedIndex)
                    matchesListBox.SelectedIndex = selectedIndex;
                else if (matchesListBox.Items.Count != 0)
                    matchesListBox.SelectedIndex = matchesListBox.Items.Count - 1;
            }
        }

        private void KeepRightButton_Click(object sender, EventArgs e)
        {
            if (CheckDeletingFilesOkay())
            {
                int selectedIndex = matchesListBox.SelectedIndex;

                DeleteFile(inspectingDuplicate.file1);

                if (matchesListBox.Items.Count > selectedIndex)
                    matchesListBox.SelectedIndex = selectedIndex;
                else if (matchesListBox.Items.Count != 0)
                    matchesListBox.SelectedIndex = matchesListBox.Items.Count - 1;
            }
        }

        private void KeepBothButton_Click(object sender, EventArgs e)
        {
            if (matchesListBox.SelectedIndex < matchesListBox.Items.Count - 1)
            {
                matchesListBox.SelectedIndex++;
            }
                
        }

        private void matchesListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (matchesListBox.SelectedIndex >= 0)
            {
                Console.WriteLine("matchesListBox_SelectedIndexChanged");
                inspectingDuplicate = duplicates[matchesListBox.SelectedIndex];

                LoadFile(Side.Left, inspectingDuplicate.file1);
                LoadFile(Side.Right, inspectingDuplicate.file2);
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

        /*private void videoScrubUpdate(object sender, EventArgs e)
        {
            if (vlcControlLeft.IsPlaying)
                videoPositionTrackBarLeft.Value = (int)(vlcControlLeft.Position * 100);

            if (vlcControlRight.IsPlaying)
                videoPositionTrackBarRight.Value = (int)(vlcControlRight.Position * 100);
        }

        private void videoPositionTrackbar_MouseDown(object sender, MouseEventArgs e)
        {
            var vlc = sender == videoPositionTrackBarLeft ? vlcControlLeft : vlcControlRight;
            vlc.Pause();
        }

        private void videoPositionTrackbar_ValueScrolled(object sender, EventArgs e)
        {
            var trackBar = (MACTrackBar)sender;
            var vlc = sender == videoPositionTrackBarLeft ? vlcControlLeft : vlcControlRight;
            vlc.Position = (trackBar.Value / 100f);
        }

        private void videoPositionTrackbar_MouseUp(object sender, MouseEventArgs e)
        {
            var trackBar = (MACTrackBar)sender;
            var vlc = sender == videoPositionTrackBarLeft ? vlcControlLeft : vlcControlRight;
            vlc.Position = (trackBar.Value / 100f);
            vlc.Play();
        }*/

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
            if (directory != null && !String.IsNullOrWhiteSpace(directory))
            {
                if (searchSubfoldersCheckBox.Checked)
                {
                    /*files = Directory.GetFiles(directory, "*", SearchOption.AllDirectories)
                        .Select(t => t.Replace(directory, ""))
                        .ToList();*/
                    files = Utilities.RecursivelyGetFileNames(directory).Select(t => t.Replace(directory, "")).ToList();
                }
                else
                    files = Directory.GetFiles(directory)
                        .Select(t => Path.GetFileName(t))
                        .ToList();
            }

            UpdateFileCountLabel();
        }

        #endregion

        private void DuplicatesForm_Load(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// AKA Delete Both
        /// </summary>
        private void keepNeitherButton_Click(object sender, EventArgs e)
        {
            if (CheckDeletingFilesOkay())
            {
                int selectedIndex = matchesListBox.SelectedIndex;

                // Can't do DeleteFile(inspectingDuplicate.fileX) because the duplicate object will be deleted after the first operation.
                string file1 = inspectingDuplicate.file1, file2 = inspectingDuplicate.file2;

                DeleteFile(file1);
                DeleteFile(file2);

                if (matchesListBox.Items.Count > selectedIndex)
                    matchesListBox.SelectedIndex = selectedIndex;
                else if (matchesListBox.Items.Count != 0)
                    matchesListBox.SelectedIndex = matchesListBox.Items.Count - 1;
            }
        }

        private void ApplicationExit(object sender, FormClosedEventArgs e)
        {
            Settings.Default.DuplicatesSearchSimilarityPercentage = (int)similarityNumeric.Value;
            Settings.Default.DuplicatesSearchImages = imagesCheckBox.Checked;
            Settings.Default.DuplicatesSearchVideos = videosCheckBox.Checked;
            Settings.Default.DuplicatesSearchThreadCount = (int)threadCountNumeric.Value;

            Settings.Default.Save();
        }
    }
}
