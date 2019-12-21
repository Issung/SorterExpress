using Microsoft.WindowsAPICodePack.Dialogs;
using System;
using System.Windows.Forms;

namespace SorterExpress
{
    public partial class AddDirectoryForm : Form
    {
        Action<string, string> callback;
        string directory = null;

        /// <summary>
        /// Will invoke callback with name, directory
        /// </summary>
        public AddDirectoryForm(Action<string, string> callback)
        {
            InitializeComponent();

            nameTextBox.KeyDown += nameTextBox_KeyDown;

            this.callback = callback;
        }

        private void nameTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                AddButton_Click(null, null);
                e.Handled = true;
                e.SuppressKeyPress = true;
            }
        }

        private void SelectDirectoryButton_Click(object sender, EventArgs e)
        {
            CommonOpenFileDialog dialog = new CommonOpenFileDialog();
            dialog.IsFolderPicker = true;

            if (dialog.ShowDialog() == CommonFileDialogResult.Ok && !string.IsNullOrWhiteSpace(dialog.FileName))
            {
                this.directory = dialog.FileName;
                selectDirectoryButton.Text = dialog.FileName;
            }
        }

        private void CancelButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrWhiteSpace(directory))
            {
                MessageBox.Show("You must select a directory.",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning,
                    MessageBoxDefaultButton.Button1
                );
            }
            else if (String.IsNullOrWhiteSpace(nameTextBox.Text))
            {
                MessageBox.Show("You must enter a name.",
                    "Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning,
                    MessageBoxDefaultButton.Button1
                );
            }
            else
            {
                callback.Invoke(nameTextBox.Text, directory);
                Close();
            }
        }
    }
}
