using Microsoft.WindowsAPICodePack.Dialogs;
using Newtonsoft.Json;
using SorterExpress.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace SorterExpress.Forms
{
    public partial class TagsListForm : Form
    {
        internal TagsListModel Model { get; set; } = new TagsListModel();

        private int SelectedRowIndex { get { return tagsListBox.SelectedIndex; } }

        private string SelectedTag { get { return (string)tagsListBox.SelectedItem; } }

        public delegate void TagsSavedEvent(IEnumerable<string> currentTags);
        public event TagsSavedEvent TagsSaved;

        public TagsListForm()
        {
            InitializeComponent();
            bindingSource.DataSource = Model;
            // Make addTagTextBox equal height with it's neighbour button.
            addTagTextBox.AutoSize = false;
            addTagTextBox.Height = 21;
        }

        private void renameButton_Click(object sender, EventArgs e)
        {
            if (SelectedTag != null)
            { 
                GetStringMessageBox getStringMessageBox = new GetStringMessageBox(SelectedTag);
                getStringMessageBox.Text = "Rename Tag";
                getStringMessageBox.Prompt = $"Enter a new name for the tag {SelectedTag}.";
                getStringMessageBox.IllegalCharacters = Utilities.TagForbiddenCharacters;
                DialogResult result = getStringMessageBox.ShowDialog();

                if (result == DialogResult.OK)
                { 
                    Model.Tags[SelectedRowIndex] = getStringMessageBox.UserEntry;
                }
            }
        }

        private void addButton_Click(object sender, EventArgs e)
        {
            string newTag = addTagTextBox.Text;

            if (Model.Tags.Contains(newTag))
            {
                MessageBox.Show("That tag already exists.", "Add Tag Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                AddTagInAlphabetically(newTag);

                tagsListBox.SelectedItem = newTag;
                tagsListBox.TopIndex = Model.Tags.IndexOf(newTag);

                addTagTextBox.Text = "";
            }
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            if (SelectedTag != null)
            {
                Model.Tags.RemoveAt(SelectedRowIndex);
            }
        }

        private void importButton_Click(object sender, EventArgs e)
        {
            var dialog = new CommonOpenFileDialog();
            dialog.Filters.Add(new CommonFileDialogFilter("Tags file", Utilities.TAGS_FILE_EXTENSION));

            if (dialog.ShowDialog() == CommonFileDialogResult.Ok && !string.IsNullOrWhiteSpace(dialog.FileName))
            {
                // TODO: Ask user if they wish to wipe current tags with import, or import new tags alongside current tags.
                //var wipeCurrentTags = MessageBox.Show("tet", "tet", MessageBoxButtons.);

                var tags = JsonConvert.DeserializeObject<List<string>>(File.ReadAllText(dialog.FileName));

                TagsAddRange(tags);
            }
        }

        /// <summary>
        /// Adds a list of tags to the main tags list that are unique (not already in the tags list) alphabetically.
        /// </summary>
        /// <param name="newItems"></param>
        private void TagsAddRange(IEnumerable<string> newItems)
        {
            newItems = newItems.Where(t => !Model.Tags.Contains(t));

            // If atleast 1 element is going to be added then disable RaiseListChangedEvents so it will be enabled again on the last element.
            // This check stops RaiseListChangedEvents from being disabled when there are 0 elements and never getting enabled again.
            if (newItems.Count() > 0)
                Model.Tags.RaiseListChangedEvents = false;

            int i = 0;
            int max = newItems.Count();
            foreach (string item in newItems)
            {
                // Reenable RaiseListChangedEvents on the last element.
                if (i == max - 1)
                    Model.Tags.RaiseListChangedEvents = true;

                AddTagInAlphabetically(item);

                i++;
            }
        }

        /// <summary>
        /// Adds a tag to the main tag list in alphabetical order.
        /// </summary>
        /// <param name="newTag"></param>
        private void AddTagInAlphabetically(string newTag)
        {
            if (Model.Tags.Count == 0)
                Model.Tags.Add(newTag);
            else
            {
                for (int i = 0; i < Model.Tags.Count; i++)
                {
                    if (String.Compare(newTag, Model.Tags[i]) < 0)
                    {
                        Model.Tags.Insert(i, newTag);
                        break;
                    }
                    else if (i == (Model.Tags.Count - 1))
                    {
                        Model.Tags.Add(newTag);
                        break;
                    }
                }
            }
        }

        private void exportButton_Click(object sender, EventArgs e)
        {
            var dialog = new CommonSaveFileDialog();
            dialog.DefaultFileName = "tags";
            dialog.Filters.Add(new CommonFileDialogFilter("Tags file", Utilities.TAGS_FILE_EXTENSION));

            if (dialog.ShowDialog() == CommonFileDialogResult.Ok && !string.IsNullOrWhiteSpace(dialog.FileName))
            {
                string jsonContents = JsonConvert.SerializeObject(Settings.Default.Tags);

                File.WriteAllText(dialog.FileName, jsonContents);
            }
        }

        private void clearTagsButton_Click(object sender, EventArgs e)
        {
            var answer = MessageBox.Show("Really clear all tags?", "Are you sure?", MessageBoxButtons.YesNo, MessageBoxIcon.Warning, MessageBoxDefaultButton.Button1);

            if (answer == DialogResult.Yes)
            {
                Model.Tags.Clear();
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

        private void SaveSettings()
        {
            Settings.Default.Tags = Model.Tags.ToList();
            TagsSaved?.Invoke(Settings.Default.Tags);
            Settings.Default.Save();
        }

        private void TagsListForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            var answer = MessageBox.Show(
                "Close tag library window without saving changes?",
                "Are you sure?",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning,
                MessageBoxDefaultButton.Button2
                );

            /*if (answer == DialogResult.Yes)
            { 
                Settings.Default.Tags = TagsOnOpen;
                Settings.Default.Save();
            }
            else
                e.Cancel = true;*/

            if (answer == DialogResult.No)
                e.Cancel = true;
        }

        private void addTagTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                addButton.PerformClick();
            }
        }

        private void tagsListBox_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                tagsListBox.SelectedIndex = tagsListBox.IndexFromPoint(e.Location);
            }
        }

        private void renameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            renameButton.PerformClick();
        }

        private void deleteToolStripMenuItem_Click(object sender, EventArgs e)
        {
            deleteButton.PerformClick();
        }
    }

    public class TagsListModel : INotifyPropertyChanged
    {
        public BindingList<string> Tags { get; set; } = new BindingList<string>(Settings.Default.Tags?.ToList() ?? new List<string>());

        public string TagCount { get { return $"{Tags.Count} Tags"; } }

        public event PropertyChangedEventHandler PropertyChanged;

        public void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            Console.WriteLine($"NotifyPropertyChanged! propertyName: {propertyName}");
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public TagsListModel()
        {
            Tags.ListChanged += (o, ea) => { 
                NotifyPropertyChanged(nameof(Tags));
                NotifyPropertyChanged(nameof(TagCount));
            };
        }
    }
}
