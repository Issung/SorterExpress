using System;
using System.Linq;
using System.Diagnostics;
using System.Windows.Forms;
using System.ComponentModel;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using SorterExpress.Properties;
using System.IO;

namespace SorterExpress.Forms
{
    public partial class DuplicateSearchIgnoredForm : Form
    {
        internal DuplicatesIgnoreModel Model { get; set; } = new DuplicatesIgnoreModel();

        private int DirectorySelectedRowIndex { get { return directoryListBox.SelectedIndex; } }

        private string SelectedDirectory { get { return (string)directoryListBox.SelectedItem; } }

        private int FileSelectedRowIndex { get { return filesListBox.SelectedIndex; } }

        private string SelectedFile { get { return (string)filesListBox.SelectedItem; } }

        public DuplicateSearchIgnoredForm()
        {
            InitializeComponent();
            bindingSource.DataSource = Model;

            CleanMissingDirectoriesAndFiles();
        }

        /// <summary>
        /// Remove directories and files from ignore settings that no longer exist.
        /// </summary>
        private void CleanMissingDirectoriesAndFiles()
        {
            foreach (var dir in Model.Directories.ToList())
            {
                if (!Directory.Exists(dir))
                {
                    Model.Directories.Remove(dir);
                }
            }

            foreach (var file in Model.Files.ToList())
            {
                if (!File.Exists(file))
                {
                    Model.Files.Remove(file);
                }
            }

            // Should we save here? Sure..
            SaveSettings();
        }

        private void SaveSettings()
        {
            Settings.Default.DuplicatesIgnoreDirectories = Model.Directories.ToList();
            Settings.Default.DuplicatesIgnoreFiles = Model.Files.ToList();
            Settings.Default.Save();
        }

        private void directoryAddButton_Click(object sender, EventArgs e)
        {
            var dirs = Utilities.OpenDirectories();

            foreach (var dir in dirs ?? Array.Empty<DirectoryInfo>())
            {
                if (!Model.Directories.Contains(dir.FullName))
                { 
                    Utilities.AddItemToListAlphabetically(Model.Directories, dir.FullName);
                }
            }
        }

        private void directoryRemoveButton_Click(object sender, EventArgs e)
        {
            string[] itemsToRemove = directoryListBox.SelectedItems.Cast<string>().ToArray();

            foreach (var dir in itemsToRemove)
            {
                Model.Directories.Remove(dir);
            }
        }

        private void directoryRemoveAllButton_Click(object sender, EventArgs e)
        {
            var answer = MessageBox.Show("Really remove all ignored directories?", "Are you sure?", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);

            if (answer == DialogResult.Yes)
            {
                Model.Directories.Clear();
            }
        }

        private void fileAddButton_Click(object sender, EventArgs e)
        {
            var files = Utilities.OpenFiles();
            
            foreach (var file in files ?? Array.Empty<FileInfo>())
            {
                if (!Model.Files.Contains(file.FullName))
                {
                    Utilities.AddItemToListAlphabetically(Model.Files, file.FullName);
                }
            }
        }

        private void fileRemoveButton_Click(object sender, EventArgs e)
        {
            string[] itemsToRemove = filesListBox.SelectedItems.Cast<string>().ToArray();

            foreach (var file in itemsToRemove)
            {
                Model.Files.Remove(file);
            }
        }

        private void fileRemoveAllButton_Click(object sender, EventArgs e)
        {
            var answer = MessageBox.Show("Really remove all ignored files?", "Are you sure?", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);

            if (answer == DialogResult.Yes)
            {
                Model.Files.Clear();
            }
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            SaveSettings();
        }

        private void saveAndExitButton_Click(object sender, EventArgs e)
        {
            FormClosing -= TagsListForm_FormClosing;
            SaveSettings();
            Close();
        }

        private void TagsListForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            var answer = MessageBox.Show(
                "Close without saving changes?",
                "Are you sure?",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning,
                MessageBoxDefaultButton.Button2
                );

            if (answer == DialogResult.No)
            { 
                e.Cancel = true;
            }
        }

        private void directoryContextMenuOpenInExplorerButton_Click(object sender, EventArgs e)
        {
            Process.Start(SelectedDirectory);
        }

        private void directoryContextMenuRemoveButton_Click(object sender, EventArgs e)
        {
            directoryRemoveButton_Click(null, null);
        }

        private void listBox_MouseDown(object sender, MouseEventArgs e)
        {
            var listBox = (ListBox)sender;

            if (e.Button == MouseButtons.Right)
            {
                listBox.SelectedIndex = listBox.IndexFromPoint(e.Location);
            }
        }

        private void fileContextMenuOpenButton_Click(object sender, EventArgs e)
        {
            Process.Start(SelectedFile);
        }

        private void fileContextMenuOpenInExplorerButton_Click(object sender, EventArgs e)
        {
            Process.Start("explorer.exe", $"/select,\"{SelectedFile}\"");
        }

        private void fileContextMenuRemoveButton_Click(object sender, EventArgs e)
        {
            fileRemoveButton_Click(null, null);
        }
    }

    public class DuplicatesIgnoreModel : INotifyPropertyChanged
    {
        public BindingList<string> Directories { get; set; } = new BindingList<string>(Settings.Default.DuplicatesIgnoreDirectories?.ToList() ?? new List<string>());

        public BindingList<string> Files { get; set; } = new BindingList<string>(Settings.Default.DuplicatesIgnoreFiles?.ToList() ?? new List<string>());

        public string DirectoryCount { get { return $"Ignored Directories ({Directories.Count})"; } }
        public string FileCount { get { return $"Ignored Files ({Files.Count})"; } }

        public event PropertyChangedEventHandler PropertyChanged;

        public void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            Console.WriteLine($"NotifyPropertyChanged! propertyName: {propertyName}");
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public DuplicatesIgnoreModel()
        {
            Directories.ListChanged += (o, ea) => { 
                NotifyPropertyChanged(nameof(Directories));
                NotifyPropertyChanged(nameof(DirectoryCount));
            };

            Files.ListChanged += (o, ea) => {
                NotifyPropertyChanged(nameof(Files));
                NotifyPropertyChanged(nameof(FileCount));
            };
        }
    }
}
