using Microsoft.WindowsAPICodePack.Dialogs;
using System;
using System.Collections.Generic;
using System.IO;
using System.Windows.Forms;
using Newtonsoft.Json;
using System.Linq;
using SorterExpress.Properties;

namespace SorterExpress
{
    public partial class SettingsForm : Form
    {
        /// <summary>
        /// Contains the dot (.).
        /// </summary>
        public const string TAGS_FILE_EXTENSION = ".tgs";

        Action<bool> setDisplayAllTagsAction = null;
        Action<List<string>> setTagsAction = null;
        Func<List<string>> getTagsFunc = null;
        bool seperateWindow;

        /// <summary>
        /// TODO: Implement the callbacks and funcs everywhere that the SettingsForm constructor is used.
        /// </summary>
        /// <param name="mainForm"></param>
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

            LoadSettings();

            this.FormClosing += FormIsClosing;
        }

        public void LoadSettings()
        {
            tagSearchNumeric.Value = Settings.Default.TagSearchStart;
            tagSearchStartLabel.Text = $"Begin tag searching at {tagSearchNumeric.Value} amount of characters";
            autoResetTagSearchCheckBox.Checked = Settings.Default.AutoResetTagSearchBox;
            displayAllTagsCheckbox.Checked = Settings.Default.DisplayAllTags;

            moveSortedFilesCheckbox.Checked = Settings.Default.MoveSortedFiles;

            fastResizingCheckbox.Checked = Settings.Default.FastResizing;
        }

        private void saveSettingsButton_Click(object sender, System.EventArgs e)
        {
            Settings.Default.TagSearchStart = (int)tagSearchNumeric.Value;
            Settings.Default.AutoResetTagSearchBox = autoResetTagSearchCheckBox.Checked;
            Settings.Default.DisplayAllTags = displayAllTagsCheckbox.Checked;
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
            //open website
        }

        private void ClearTagsButton_Click(object sender, EventArgs e)
        {
            var answer = MessageBox.Show("Really delete all tags? This is irreversible.", "Really delete all tags?", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);

            if (answer == DialogResult.Yes)
            {
                Settings.Default.Tags = new List<string>();

                if (setDisplayAllTagsAction != null)
                    setTagsAction.Invoke(new List<string>());
            }
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
            System.Diagnostics.Process.Start(Directory.GetCurrentDirectory() + "/" + Logs.LOGS_FILE_PATH);
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
                var window = MessageBox.Show("Do you really want to close settings without saving?", "Are you sure?", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation);

                e.Cancel = window == DialogResult.No;
            }
        }
    }
}