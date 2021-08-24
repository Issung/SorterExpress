using Microsoft.WindowsAPICodePack.Dialogs;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using Newtonsoft.Json;
using System.Linq;
using SorterExpress.Properties;
using System.Diagnostics;
using System.ComponentModel;
using System.Threading.Tasks;
using System.Threading;
using Microsoft.Win32;

namespace SorterExpress.Forms
{
    public partial class SettingsForm : Form
    {
        /// <summary>
        /// Contains the dot (.).
        /// </summary>
        public const string TAGS_FILE_EXTENSION = "tgs";

        Action<bool> setDisplayAllTagsAction = null;
        Action<List<string>> setTagsAction = null;
        Func<List<string>> getTagsFunc = null;
        bool seperateWindow;

        BackgroundWorker thumbsSizeWorker;
        CancellationTokenSource thumbsSizeWorkerCancelToken;
        long thumbSizeTotalBytes = 0;
        string thumbSizeLabelText(int? fileCount, int size) => $"Thumbnail Cache Storage: {size}Mb" + ((fileCount != null) ? $" ({String.Format("{0:n0}", fileCount)} files)" : string.Empty);

        public delegate void TagsSavedEvent(IEnumerable<string> currentTags);
        public event TagsSavedEvent TagsSaved;

        /// <summary>
        /// TODO: Implement the callbacks and funcs everywhere that the SettingsForm constructor is used.
        /// </summary>
        /// <param name="seperateWindow">Open the settings in a seperate window, this should always be true except in the case
        /// of the AllInOneForm.</param>
        public SettingsForm(
            Action<bool> setDisplayAllTagsAction = null,
            Action<List<string>> setTagsAction = null,
            Func<List<string>> getTagsFunc = null,
            bool seperateWindow = true)
        {
            InitializeComponent();
            this.setDisplayAllTagsAction = setDisplayAllTagsAction;
            this.setTagsAction = setTagsAction;
            this.getTagsFunc = getTagsFunc;

            this.seperateWindow = seperateWindow;

            this.FormClosing += FormIsClosing;
        }

        private void SettingsForm_Shown(object sender, EventArgs e)
        {
            LoadSettings();
            StartThumbsSizeDisplay();
        }

        private void StartThumbsSizeDisplay()
        {
            thumbsSizeWorker = new BackgroundWorker
            {
                WorkerReportsProgress = true,
                WorkerSupportsCancellation = true
            };
            thumbsSizeWorker.DoWork += ThumbsSizeWorker_DoWork;
            thumbsSizeWorker.ProgressChanged += ThumbsSizeWorker_ProgressChanged;
            thumbsSizeWorker.RunWorkerAsync();
        }

        int? fileCount = 0;

        private void ThumbsSizeWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            var worker = (BackgroundWorker)sender;

            string[] files = Directory.GetFiles(Program.THUMBS_PATH, "*.*");
            fileCount = files.Length;

            thumbSizeTotalBytes = 0;
            List<int> sizes = new List<int>();

            thumbsSizeWorkerCancelToken = new CancellationTokenSource();
            
            var options = new ParallelOptions {
                MaxDegreeOfParallelism = Math.Min(1, Environment.ProcessorCount / 2),
                CancellationToken = thumbsSizeWorkerCancelToken.Token
            };

            Parallel.ForEach(files, options, (filename, state) => 
            {
                if (options.CancellationToken.IsCancellationRequested)
                { 
                    state.Stop();
                }
                else
                { 
                    FileInfo info = new FileInfo(filename);
                    Interlocked.Add(ref thumbSizeTotalBytes, info.Length);
                    worker.ReportProgress((int)(thumbSizeTotalBytes / 1000000));
                }
            });
        }

        private void ThumbsSizeWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            thumbsStorageSizeLabel.Text = thumbSizeLabelText(fileCount, e.ProgressPercentage);
        }

        public void LoadSettings()
        {
            tagSearchNumeric.Value = Settings.Default.TagSearchStart;
            tagSearchStartLabel.Text = $"Begin tag searching at {tagSearchNumeric.Value} amount of characters";
            autoResetTagSearchCheckBox.Checked = Settings.Default.AutoResetTagSearchBox;
            autoResetSubfolderSearchCheckBox.Checked = Settings.Default.AutoResetSubfolderSearchBox;
            displayAllTagsCheckbox.Checked = Settings.Default.DisplayAllTags;

            moveSortedFilesCheckbox.Checked = Settings.Default.MoveSortedFiles;
            fastResizingCheckbox.Checked = Settings.Default.FastResizing;
            UpdateIgnoredDirectoriesAndFilesLabel();

            LoadVLCLocation();
            UpdateContextMenuButton();
        }

        private void UpdateIgnoredDirectoriesAndFilesLabel()
        {
            ignoredFilesCountLabel.Text = $"Ignored Directories: {Settings.Default.DuplicatesIgnoreDirectories?.Count ?? 0}, Ignored Files: {Settings.Default.DuplicatesIgnoreFiles?.Count ?? 0}";
        }

        string currentVlcLocationText(string path) => $"Current VLC Location: {path}";

        private void LoadVLCLocation()
        {
            string location = Settings.Default.VlcLocation;

            if (String.IsNullOrWhiteSpace(location))
            {
                currentVlcLocationLabel.Text = currentVlcLocationText("Unknown");
                locateVlcButton.Text = "Locate";
            }
            else
            {
                currentVlcLocationLabel.Text = currentVlcLocationText(location);
                locateVlcButton.Text = "Change";
            }
        }

        private void saveSettingsButton_Click(object sender, System.EventArgs e)
        {
            Settings.Default.TagSearchStart = (int)tagSearchNumeric.Value;
            Settings.Default.AutoResetTagSearchBox = autoResetTagSearchCheckBox.Checked;
            Settings.Default.AutoResetSubfolderSearchBox = autoResetSubfolderSearchCheckBox.Checked;
            Settings.Default.DisplayAllTags = displayAllTagsCheckbox.Checked;

            //Settings.Default.DuplicatesCropLeftRightSides = cropFilesLeftRightCheckBox.Checked;
            //Settings.Default.DuplicatesCropTopBottomSides = cropFilesTopBottomCheckBox.Checked;

            Settings.Default.MoveSortedFiles = moveSortedFilesCheckbox.Checked;
            Settings.Default.FastResizing = fastResizingCheckbox.Checked;

            Settings.Default.Save();

            if (seperateWindow)
            {
                FormClosing -= FormIsClosing;
                this.Close();
            }
        }

        private void websiteButton_Click(object sender, EventArgs e)
        {
            Process.Start("https://github.com/Issung/SorterExpress");
        }

        private void manageTagLibraryButton_Click(object sender, EventArgs e)
        {
            TagsListForm tagsListForm = new TagsListForm();
            tagsListForm.TagsSaved += (newCurrentTags) =>
            {
                TagsSaved?.Invoke(newCurrentTags);
            };
            tagsListForm.ShowDialog();
        }

        private void ExportTagsButton_Click(object sender, System.EventArgs e)
        {
            var dialog = new CommonSaveFileDialog();
            dialog.DefaultFileName = "tags";
            dialog.Filters.Add(new CommonFileDialogFilter("Tags file", TAGS_FILE_EXTENSION));

            if (dialog.ShowDialog() == CommonFileDialogResult.Ok && !string.IsNullOrWhiteSpace(dialog.FileName))
            {
                string json = null;

                if (getTagsFunc == null)
                {
                    json = JsonConvert.SerializeObject(Settings.Default.Tags.Cast<string>());
                }
                else
                {
                    json = JsonConvert.SerializeObject(getTagsFunc.Invoke());
                }

                File.WriteAllText(dialog.FileName + TAGS_FILE_EXTENSION, json);
            }
        }

        private void ImportTagsButton_Click(object sender, System.EventArgs e)
        {
            var dialog = new CommonOpenFileDialog();
            dialog.Filters.Add(new CommonFileDialogFilter("Tags file", TAGS_FILE_EXTENSION));

            if (dialog.ShowDialog() == CommonFileDialogResult.Ok && !string.IsNullOrWhiteSpace(dialog.FileName))
            {
                var tags = JsonConvert.DeserializeObject<List<string>>(File.ReadAllText(dialog.FileName));

                Settings.Default.Tags = tags;

                if (setTagsAction != null)
                    setTagsAction.Invoke(tags);
            }
        }

        private void ViewLogsButton_Click(object sender, EventArgs e)
        {
            Process.Start(Logs.LOGS_FILE_PATH);
        }

        private void TagSearchNumeric_ValueChanged(object sender, EventArgs e)
        {
            tagSearchStartLabel.Text = $"Begin tag searching at {tagSearchNumeric.Value} amount of characters";
        }

        private void DisplayAllTagsCheckbox_CheckedChanged(object sender, EventArgs e)
        {
            if (setDisplayAllTagsAction != null)
                setDisplayAllTagsAction.Invoke(displayAllTagsCheckbox.Checked);
        }

        private void FormIsClosing(object sender, FormClosingEventArgs e)
        {
            if (seperateWindow)
            {
                DialogResult result = MessageBox.Show("Do you really want to close settings without saving?", 
                    "Are you sure?", 
                    MessageBoxButtons.YesNo, 
                    MessageBoxIcon.Exclamation);

                if (result == DialogResult.No)
                {
                    e.Cancel = true;
                }
                else
                {
                    if (thumbsSizeWorkerCancelToken != null)
                        thumbsSizeWorkerCancelToken.Cancel();
                    e.Cancel = false;
                }
            }
        }

        private void thumbsStorageInfoButton_Click(object sender, EventArgs e)
        {
            string thumbsStorageMoreInfoMessage = $"When using the duplicate searcher feature of {Program.NAME} the program while searching stores small " +
                $"thumbnails of images in order to use them to compare to other images to check similarity." +
                $"\r\r" +
                $"These thumbnails are stored for later use which greatly increases duplicate searching speed in future searches." +
                $"\r\r" +
                $"The number to the left shows how large your thumbnail storage is in Megabytes." +
                $"\r\r" +
                $"The \"Empty\" button to the right allows you to delete all of these if you wish, but be aware that if you use duplicate image searching again images " +
                $"will be generated again.";

            MessageBox.Show(thumbsStorageMoreInfoMessage, "Thumbs Storage Info", MessageBoxButtons.OK, MessageBoxIcon.Question);
        }

        BackgroundWorker thumbnailsDeleteWorker;

        private void thumbsStorageEmptyButton_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to delete cached thumbnails?\rBe sure to read the \"What's This?\" information to be informed.",
                "Are you sure?", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);

            if (result == DialogResult.OK)
            {
                Utilities.DeleteAllInDirectory(Program.THUMBS_PATH);

                thumbnailsDeleteWorker = new BackgroundWorker { 
                    WorkerReportsProgress = true
                };
                thumbnailsDeleteWorker.DoWork += thumbnailsDeleteWorker_DoWork;
                thumbnailsDeleteWorker.ProgressChanged += thumbnailsDeleteWorker_ProgressChanged;
                thumbnailsDeleteWorker.RunWorkerCompleted += thumbnailsDeleteWorker_Complete;
                thumbnailsDeleteWorker.RunWorkerAsync();
            }
        }

        private void thumbnailsDeleteWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            BackgroundWorker worker = sender as BackgroundWorker;
            thumbsSizeWorkerCancelToken.Cancel();

            string[] files = Directory.GetFiles(Program.THUMBS_PATH);

            ParallelOptions PO = new ParallelOptions {
                MaxDegreeOfParallelism = Environment.ProcessorCount
            };

            Parallel.ForEach(files, PO, (filename) =>
            {
                FileInfo fi = new FileInfo(filename);
                File.Delete(filename);
                Interlocked.Add(ref thumbSizeTotalBytes, -fi.Length);
                worker.ReportProgress((int)(thumbSizeTotalBytes / 1000000));
            });
        }

        private void thumbnailsDeleteWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            thumbsStorageSizeLabel.Text = thumbSizeLabelText(fileCount, e.ProgressPercentage);
        }

        private void thumbnailsDeleteWorker_Complete(object sender, RunWorkerCompletedEventArgs e)
        {
            thumbsStorageSizeLabel.Text = thumbSizeLabelText(0, 0);
        }

        private void locateVlcButton_Click(object sender, EventArgs e)
        {
            if (locateVlcButton.Text == "Locate")
            {
                Utilities.FindVlcLibDirectory();
            }
            else // locateVlcButton.Text == "Change"
            {
                using (LocateVLCForm locateForm = new LocateVLCForm())
                {
                    if (locateForm.ShowDialog() == DialogResult.OK)
                    {
                        Settings.Default.VlcLocation = Path.GetDirectoryName(locateForm.vlcPath);
                        Settings.Default.Save();
                    }
                    else //DialogResult.Ignore
                    {
                        Settings.Default.VlcLocation = null;
                        Settings.Default.Save();
                    }
                }
            }

            LoadVLCLocation();
        }

        bool isContextMenuSetup = false;

        private void UpdateContextMenuButton()
        {
            string keyName = @"Directory\Background\shell\SorterExpress";
            using (RegistryKey key = Registry.ClassesRoot.OpenSubKey(keyName, false))
            {
                if (key == null)
                { 
                    isContextMenuSetup = false;
                    toggleContextMenuOptionsButton.Text = "Add Context Menu Options To Windows";
                }
                else
                { 
                    isContextMenuSetup = true;
                    toggleContextMenuOptionsButton.Text = "Remove Context Menu Options From Windows";
                }
            }

        }

        private void toggleContextMenuOptionsButton_Click(object sender, EventArgs e)
        {
            if (isContextMenuSetup)
                RemoveContextMenuOptions();
            else
                SetupContextMenuOptions();

            UpdateContextMenuButton();
        }

        private void SetupContextMenuOptions()
        {
            const string TEMPLATE_FILENAME = "SetupContextMenuOptionsTemplate.reg";     //The name of the template registry file.
            const string TEMPLATE_REPLACE_TOKEN = "PROGRAM_PATH";                       //The reoccuring string in the template file to be replaced with the program path.
            const string OUTPUT_FILENAME = "ContextMenuUpdated.reg";                    //The output registry file with updated paths, to be run.

            string regFileContents = File.ReadAllText(TEMPLATE_FILENAME);
            string currentAppPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, AppDomain.CurrentDomain.FriendlyName).Replace("\\", "\\\\") + "\\";

            regFileContents = regFileContents.Replace(TEMPLATE_REPLACE_TOKEN, currentAppPath);

            File.Delete(OUTPUT_FILENAME);
            File.WriteAllText(OUTPUT_FILENAME, regFileContents);

            Process regeditProcess = Process.Start("regedit.exe", $"/s \"{Path.Combine(AppDomain.CurrentDomain.BaseDirectory, OUTPUT_FILENAME)}\"");
            regeditProcess.WaitForExit();

            if (regeditProcess.ExitCode == 0)
                MessageBox.Show($"{Program.NAME} Context Menu options succesfully added to windows.", "Success", MessageBoxButtons.OK, MessageBoxIcon.None);
            else
                MessageBox.Show($"An error occured while adding context menu options. Exit Code: {regeditProcess.ExitCode}.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void RemoveContextMenuOptions()
        {
            /*string keyName = @"Directory\Background\shell";
            using (RegistryKey key = Registry.ClassesRoot.OpenSubKey(keyName, true))
            {
                if (key.GetSubKeyNames().Contains("SorterExpress"))
                {
                    //key.DeleteSubKey("SorterExpress");
                    key.DeleteSubKeyTree("SorterExpress");
                }
            }*/

            const string REMOVE_REGEDIT_SCRIPT = "RemoveContextMenuOptions.reg";

            Process regeditProcess = Process.Start("regedit.exe", $"/s \"{Path.Combine(AppDomain.CurrentDomain.BaseDirectory, REMOVE_REGEDIT_SCRIPT)}\"");
            regeditProcess.WaitForExit();

            if (regeditProcess.ExitCode == 0)
                MessageBox.Show($"{Program.NAME} Context Menu options succesfully removed.", "Success", MessageBoxButtons.OK, MessageBoxIcon.None);
            else
                MessageBox.Show($"An error occured while removing context menu options. Exit Code: {regeditProcess.ExitCode}.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        }

        private void toggleContextMenuOptionsInfoButton_Click(object sender, EventArgs e)
        {
            string thumbsStorageMoreInfoMessage = $"By adding context menu options to Windows you will be able to right click in a folder in windows explorer " +
                $"and be able to quickly launch different {Program.NAME} functionalities in that folder.\r\r" +
                $"Once added context menu options can be removed if desired through these settings, and added back again if desired too.\r\r" +
                $"The registry files used can be viewed at {AppDomain.CurrentDomain.BaseDirectory}";

            MessageBox.Show(thumbsStorageMoreInfoMessage, "Thumbs Storage Info", MessageBoxButtons.OK, MessageBoxIcon.Question);
        }

        private void thumbsStorageViewButton_Click(object sender, EventArgs e)
        {
            Process.Start(Program.THUMBS_PATH);
        }

        private void ignoredFilesInfoButton_Click(object sender, EventArgs e)
        {
            string ignoredFilesInfoMessage = $"Files or directories that contain files with a high false-positive rates in the duplicates searcher can be manually ignored by the user.\r\r" +
                $"These directories/files are ignored by their absolute filepath, so if they are moved or renamed then the ignoring will no longer work.\r\r" +
                $"In the manage screen you can add or remove files and directories from being ignored.";

            MessageBox.Show(ignoredFilesInfoMessage, "Duplicates Search Ignored Files Info", MessageBoxButtons.OK, MessageBoxIcon.Question);
        }

        private void ignoredFilesManageButton_Click(object sender, EventArgs e)
        {
            var form = new DuplicateSearchIgnoredForm();
            form.ShowDialog();
            UpdateIgnoredDirectoriesAndFilesLabel();
        }
    }
}