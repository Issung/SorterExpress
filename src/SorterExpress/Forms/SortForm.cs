using System;
using System.Windows.Forms;
using System.IO;
using System.Drawing;
using System.Text.RegularExpressions;
using SorterExpress.Controls;
using SorterExpress.Controllers;

namespace SorterExpress.Forms
{
    /// <summary>
    /// SortForm controlled in an MVC manner in cooperation with SortController.
    /// </summary>
    public partial class SortForm : Form
    {
        //DirectoryInfo dirInfo;
        SortController controller;

        /// <summary>
        /// Flag used for ignoring programatic changes of the file index textbox text.
        /// </summary>
        bool ignoreFileIndexTextChange = false;

        public SortForm(DirectoryInfo dirInfo)
        {
            InitializeComponent();

            //These are here because the designer likes to delete them from the designer file all the time.
            this.KeyPreview = true;
            this.ActiveControl = tagSearchTextBox;

            //this.dirInfo = dirInfo;

            controller = new SortController(this, dirInfo);
            sortControllerBindingSource.DataSource = controller;

            loadingPanel.Hide();
        }

        private void SortForm_Load(object sender, EventArgs e)
        {
            controller.FormLoaded();
        }

        /// <summary>
        /// Change the text field of fileIndexTextBox without firing the text changed event listener.
        /// </summary>
        public void ChangeFileIndexTextBoxTextSilently(string newText)
        {
            ignoreFileIndexTextChange = true;
            fileIndexTextbox.Text = newText;
            ignoreFileIndexTextChange = false;
        }

        private void fileIndexTextbox_TextChanged(object sender, EventArgs e)
        {
            int goalFileIndex = 0;

            if (!ignoreFileIndexTextChange)
            {
                if (String.IsNullOrWhiteSpace(fileIndexTextbox.Text))
                {
                    // String is null or white space, setting file index to 0.
                    goalFileIndex = 0;
                    ChangeFileIndexTextBoxTextSilently("1");
                }
                else
                {
                    string stringNumbersOnly = Regex.Replace(fileIndexTextbox.Text, "[^0-9]", "");

                    int cursorPositionBeforeChange = fileIndexTextbox.SelectionStart;
                    int changeLengthDifference = fileIndexTextbox.Text.Length - stringNumbersOnly.Length;

                    if (stringNumbersOnly.Length < 1)
                    {
                        // String with numbers only is empty, setting file index to 0.
                        goalFileIndex = 0;
                        ChangeFileIndexTextBoxTextSilently("1");
                    }
                    else
                    {
                        // String is now a number, continuing.
                        int stringAsInt = int.Parse(stringNumbersOnly);

                        stringAsInt = (stringAsInt > controller.FileCount) ? controller.FileCount : stringAsInt;
                        stringAsInt = (stringAsInt < 1) ? 1 : stringAsInt;

                        ChangeFileIndexTextBoxTextSilently(stringAsInt.ToString());
                        goalFileIndex = stringAsInt - 1;
                    }

                    fileIndexTextbox.SelectionStart = cursorPositionBeforeChange - changeLengthDifference;
                }

                controller.UpdateFileIndex(goalFileIndex);
            }
        }

        private void prevFileButton_Click(object sender, EventArgs e)
        {
            controller.DecrementFileIndex();
        }

        private void nextFileButton_Click(object sender, EventArgs e)
        {
            controller.IncrementFileIndex();
        }

        private void firstFileButton_Click(object sender, EventArgs e)
        {
            controller.GotoFirstFileIndex();
        }

        private void lastFileButton_Click(object sender, EventArgs e)
        {
            controller.GotoLastFileIndex();
        }

        private void addTagButton_Click(object sender, EventArgs e)
        {
            controller.AddTag(tagCreationTextBox.Text);
            tagCreationTextBox.Text = String.Empty;
        }

        private void tagCreationTextbox_TextChanged(object sender, EventArgs e)
        {
            tagCreationTextBox.Text = Utilities.Remove(tagCreationTextBox.Text, Utilities.TagForbiddenCharacters);
        }

        private void tagCreationTextbox_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                addTagButton_Click(null, null);
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }

        private void SortForm_FormClosed(object sender, FormClosedEventArgs e)
        {
            controller.SaveSettings();
        }

        private void tagSearchTextbox_TextChanged(object sender, EventArgs e)
        {
            tagPanel.UpdateFilter(tagSearchTextBox.Text);
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            controller.Move(null);
        }

        private void settingsButton_Click(object sender, EventArgs e)
        {
            controller.OpenSettings();
        }

        private void redoButton_Click(object sender, EventArgs e)
        {
            controller.Redo();
        }

        private void undoButton_Click(object sender, EventArgs e)
        {
            controller.Undo();
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            controller.Delete();
        }

        private void SortForm_KeyDown(object sender, System.Windows.Forms.KeyEventArgs e)
        {
            //Console.WriteLine($"SortForm_KeyDown! Key: {e.KeyCode.ToString()}");
            controller.HandleShortcut(e);
        }

        private void subfolderPanel_SubfolderButtonClicked(object sender, SubfolderButtonClickedEventArgs e)
        {
            controller.SubFolderButtonClicked(e);
        }

        private void addDirectoryButton_Click(object sender, EventArgs e)
        {
            controller.AddCustomSubfolder();
        }

        private void openDirectoryButton_Click(object sender, EventArgs e)
        {
            controller.OpenNewDirectory();
        }

        public void SortForm_Resize(object sender, EventArgs e)
        {
            if (loadingPanel.Visible)
            {
                CenterLoadingPanel();
            }
        }

        public void CenterLoadingPanel()
        {
            loadingPanel.Location = new Point(
                (this.Width / 2) - (loadingPanel.Size.Width / 2),
                (this.Height / 2) - (loadingPanel.Size.Height / 2));
        }

        private void tagPanel_TagButtonClicked(object sender, TagButtonClickedEventArgs e)
        {
            controller.TagButtonClicked(e);
        }

        //TODO: Use databinding to do this rather than this method?
        private void subfolderSearchBox_TextChanged(object sender, EventArgs e)
        {
            subfolderPanel.Filter = subfolderSearchTextBox.Text;
        }

        private void subfolderSearchDepthNumeric_ValueChanged(object sender, EventArgs e)
        {
            controller.SubfolderDepthChanged((int)subfolderSearchDepthNumeric.Value);
        }

        private string GetCurrentFilePath()
        {
            return Path.Combine(controller.directory, controller.files[controller.fileIndex]);
        }

        private void openFileInExplorerButton_Click(object sender, EventArgs e)
        {
            Utilities.ViewFileInExplorer(GetCurrentFilePath());
        }

        private void openFileButton_Click(object sender, EventArgs e)
        {
            Utilities.OsOpen(GetCurrentFilePath());
        }
    }
}