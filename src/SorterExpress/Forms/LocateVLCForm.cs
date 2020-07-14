using Microsoft.WindowsAPICodePack.Dialogs;
using System;
using System.IO;
using System.Windows.Forms;

namespace SorterExpress.Forms
{
    public partial class LocateVLCForm : Form
    {
        public string vlcPath = "";

        public LocateVLCForm()
        {
            InitializeComponent();
        }

        private void LocateButton_Click(object sender, EventArgs e)
        {
            using (var dialog = new CommonOpenFileDialog())
            {
                dialog.Multiselect = false;
                dialog.InitialDirectory = @"C:\";
                dialog.Title = "Locate libvlc.dll";
                dialog.DefaultFileName = "libvlc.dll";
                dialog.DefaultExtension = ".dll";

                if (dialog.ShowDialog() == CommonFileDialogResult.Ok)
                {
                    if (Path.GetFileName(dialog.FileName) == "libvlc.dll")
                    {
                        vlcPath = dialog.FileName;
                        pathLabel.Text = dialog.FileName;
                        confirmButton.Enabled = true;
                    }
                    else
                    {
                        confirmButton.Enabled = false;
                        MessageBox.Show("You must select a file named 'libvlc.dll'.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
                }
            }
        }

        private void IgnoreButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Ignore;
        }

        private void ConfirmButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }
    }
}
