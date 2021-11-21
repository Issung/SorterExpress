using System;
using System.Windows.Forms;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using System.Drawing;
using SorterExpress.Properties;
using SorterExpress.Controls;
using SorterExpress.Classes.SettingsData;

namespace SorterExpress.Forms
{
    public partial class MassTagForm : Form
    {
        public enum Action { SetTags, AddTags, RemoveTags };
        public static MassTagForm form;
        public string directory;
        public List<string> files;
        public BindingSource filesBindingSource;

        public List<string> tags;
        List<string> enabledTags;

        // The same but without the space
        public readonly char[] tagForbiddenCharacters = { '/', '\\', '?', '%', '*', ':', '|', '"', '<', '>', '.', ' ' };

        public MassTagForm(DirectoryInfo dirInfo)
        {
            InitializeComponent();
            SuspendLayout();

            form = this;

            enabledTags = new List<string>();

            tags = Settings.Default.Tags.ToList() ?? new List<string>();

            if (Settings.Default.DisplayAllTags)
            { 
                Show();
            }

            foreach (string tag in tags)
                tagsPanel.Controls.Add(CreateTagToggleButton(tag));

            ReorderTagButtons();

            //Events 
            tagCreationTextbox.KeyDown += textBox_KeyDown;
            tagSearchTextbox.KeyDown += textBox_KeyDown;

            //Bindings Setup
            filesBindingSource = new BindingSource();
            filesBindingSource.DataSource = files;
            filenamesBefore.DataSource = filesBindingSource;

            // Open directory
            LoadDirectory(dirInfo);

            //These are here because the designer likes to delete them from the designer file all the time.
            this.KeyPreview = true;
            this.ActiveControl = tagSearchTextbox;
            actionComboBox.SelectedIndex = 0;
            
            ResumeLayout();
        }

        private string[] GenerateFileNamesAfter()
        {
            if (files == null)
                return null;

            const bool REMOVE_CERTAIN_TAGS = true;
            Action action = (Action)actionComboBox.SelectedIndex;

            string[] namesAfter = new string[files.Count];

            if (enabledTags.Count > 0)
            {
                for (int i = 0; i < files.Count; i++)
                {
                    List<string> finalTags = new List<string>();

                    if (action == Action.SetTags)
                    {
                        enabledTags.Sort();
                        finalTags = enabledTags;
                        //namesAfter[i] = String.Join(" ", enabledTags);

                        //namesAfter[i] += GetFileExtension(files[i]);
                    }
                    else if (action == Action.AddTags)
                    {
                        string[] filesCurrentTags = Utilities.GetTags(files[i]);
                        List<string> combinedTags = new List<string>();
                        combinedTags.AddRange(filesCurrentTags);
                        foreach (string enabledTag in enabledTags)
                            if (!combinedTags.Contains(enabledTag))
                                combinedTags.Add(enabledTag);

                        combinedTags.Sort();
                        finalTags = combinedTags;
                        //namesAfter[i] = String.Join(" ", combinedTags) + GetFileExtension(files[i]);
                    }
                    else // Action.RemoveTags
                    {
                        string[] filesCurrentTags = Utilities.GetTags(files[i]);
                        //List<string> finalTags = new List<string>();
                        finalTags.AddRange(filesCurrentTags);
                        foreach (string enabledTag in enabledTags)
                            finalTags.Remove(enabledTag);

                        finalTags.Sort();
                        //namesAfter[i] = String.Join(" ", finalTags) + GetFileExtension(files[i]);
                    }

                    if (REMOVE_CERTAIN_TAGS)
                    {
                        // Remove all tags that are just numbers or a dash -.
                        finalTags.RemoveAll(t => long.TryParse(t, out long irrelevant) || t == "-");
                    }

                    finalTags.GroupBy(t => t).Select(t => t.Key);
                    finalTags.Sort();

                    if (finalTags.Count == 0)
                        namesAfter[i] = "NoTags" + GetFileExtension(files[i]);
                    else
                        namesAfter[i] = String.Join(" ", finalTags) + GetFileExtension(files[i]);
                }
            }
            else
            {
                namesAfter = files.ToArray();
            }

            return namesAfter;
        }

        private void DisplayFilenamesAfter(string[] names)
        {
            filenamesAfter.DataSource = names;
        }

        /// <summary>
        /// Reorders all visible tag toggle buttons in alphabetical order.
        /// </summary>
        public void ReorderTagButtons()
        {
            int scrollY = tagsPanel.AutoScrollPosition.Y;

            CheckBox[] scope;

            if (tagSearchTextbox.Text.Length > 0)
            {
                scope = tagsPanel.Controls.OfType<CheckBox>()
                    .Where(t => t.Visible)
                    .OrderByDescending(t => t.Name.ToLower().StartsWith(tagSearchTextbox.Text.ToLower()))
                    .ThenBy(t => t.Name).ToArray();
            }
            else
            {
                scope = tagsPanel.Controls.OfType<CheckBox>()
                    .Where(t => t.Visible)
                    .OrderBy(t => t.Name).ToArray();
            }

            var location = new Point(0, -1 + (0 * 26) + scrollY);

            for (int i = 0; i < scope.Length; i++)
            {
                scope[i].Location = location;
                scope[i].TabIndex = i;// + 12; //11 is tag search box tab index.
                location.Y += 26;
            }

            tagsPanel.VerticalScroll.Visible = true;
        }

        /// <summary>
        /// Returns the dot (.) too.  Pass in "meme.jpg" get back ".jpg"
        /// Will also always return in all lower case (string.ToLower()).
        /// </summary>
        public string GetFileExtension(string str)
        {
            return Path.GetExtension(str).ToLower();
        }

        private CheckBox CreateTagToggleButton(string tag)
        {
            CheckBox cb = new CheckBox();
            cb.Appearance = Appearance.Button;
            cb.Size = new Size(230, 22);
            cb.Text = tag;
            cb.Tag = tag;
            cb.Name = tag;
            cb.KeyPress += toggleTagButton_KeyPress;
            cb.MouseUp += toggleTagButton_MouseUp;
            //cb.BackColor = buttonBackColor;
            tooltip.SetToolTip(cb, $"Toggle tag '{tag}' on or off. Right click to delete tag from tag list.");

            return cb;
        }

        private void toggleTagButton_KeyPress(object sender, KeyPressEventArgs e)
        {
            CheckBox cb = (CheckBox)sender;

            if (e.KeyChar == '\r')  // /r (13) = ENTER key
            {
                cb.Checked = !cb.Checked;
                toggleTagButton_MouseUp(sender, new MouseEventArgs(MouseButtons.Left, 1, 0, 0, 0));
                e.Handled = true;
            }
            else if (e.KeyChar == '\u001b') // \u001b = ESCAPE key
            {
                toggleTagButton_MouseUp(sender, new MouseEventArgs(MouseButtons.Right, 1, 0, 0, 0));
                e.Handled = true;
            }
        }

        public void DisplayAllTags()
        {
            tagsPanel.SuspendLayout();

            for (int i = 0; i < tagsPanel.Controls.Count; i++)
            {
                tagsPanel.Controls[i].Show();
            }

            ReorderTagButtons();

            tagsPanel.ResumeLayout();
        }

        private void UncheckAllTags()
        {
            foreach (CheckBox cb in tagsPanel.Controls.OfType<CheckBox>())
            {
                cb.Checked = false;
            }
        }

        #region Form Events

        private void openDirectoryButton_Click(object sender, EventArgs e)
        {
            var dirInfo = Utilities.OpenDirectory();

            if (dirInfo != null)
                LoadDirectory(dirInfo);
        }

        private void LoadDirectory(DirectoryInfo dirInfo)
        {
            if (dirInfo != null)
            { 
                this.directory = dirInfo.FullName;
                this.files = dirInfo.GetFileNamesList();
                filesBindingSource.DataSource = this.files;

                //DisplayFilenamesBefore();

                Logs.Log("Opened '" + directory + "' and found " + files.Count + " files.");
            }
        }

        private void addTagButton_Click(object sender, EventArgs e)
        {
            if (tags.Exists(t => t == tagCreationTextbox.Text))
            {
                MessageBox.Show("That tag already exists.", "Add Tag Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                tags.Add(tagCreationTextbox.Text);  //try and insert in correct place later on for optimisation
                tags.Sort();

                tagsPanel.Controls.Add(CreateTagToggleButton(tagCreationTextbox.Text));

                ReorderTagButtons();
                tagCreationTextbox.Text = "";
                ActiveControl = tagCreationTextbox;
            }
        }

        private void toggleTagButton_MouseUp(object sender, MouseEventArgs e)
        {
            CheckBox button = (CheckBox)sender;

            if (e.Button == MouseButtons.Left)
            {
                if (button == null)
                    return;

                if (button.Checked)
                {
                    if (!enabledTags.Contains(button.Text))
                        enabledTags.Add(button.Text);
                }
                else
                {
                    enabledTags.Remove(button.Text);
                }

                if (Settings.Default.AutoResetTagSearchBox)
                {
                    tagSearchTextbox.Text = "";
                    tagSearchTextbox.Focus();
                }
            }
            else //Right Click
            {
                string tag = (string)button.Tag;

                form.tags.Remove(tag);
                form.enabledTags.Remove(tag);

                List<CheckBox> tagButtons = form.tagsPanel.Controls.OfType<CheckBox>().Where(t => t.Name == tag).ToList();

                foreach (Control c in tagButtons)
                    form.tagsPanel.Controls.Remove(c);

                form.ReorderTagButtons();
            }

            DisplayFilenamesAfter(GenerateFileNamesAfter());

            applyMassTagButton.Enabled = enabledTags.Count > 0;
        }

        static void textBox_KeyDown(object sender, KeyEventArgs e)
        {
            TextBox tb = (TextBox)sender;

            if (tb == form.tagCreationTextbox)
            {
                if (e.KeyCode == Keys.Enter)
                {
                    form.addTagButton.PerformClick();
                    e.Handled = true;
                    e.SuppressKeyPress = true;
                }
            }
            else if (tb == form.tagSearchTextbox)
            {
                if (e.KeyCode == Keys.Enter && form.tagSearchTextbox.Text.Length > 0)
                {
                    CheckBox cb = form.tagsPanel.Controls.OfType<CheckBox>()
                            .Where(t => t.Visible)
                            .OrderByDescending(t => t.Name.ToLower().StartsWith(form.tagSearchTextbox.Text.ToLower()))
                            .ThenBy(t => t.Name)
                            .FirstOrDefault();

                    if (cb != null)
                    {
                        cb.Checked = !cb.Checked;
                        form.toggleTagButton_MouseUp(cb, new MouseEventArgs(MouseButtons.Left, 0, 0, 0, 0));

                        if (Settings.Default.AutoResetTagSearchBox)
                        {
                            tb.Text = "";
                            form.ReorderTagButtons();
                        }
                        e.Handled = true;
                        e.SuppressKeyPress = true;
                    }
                }
            }
        }

        private void TagSearchTextbox_TextChanged(object sender, EventArgs e)
        {
            tagsPanel.SuspendLayout();

            string search = tagSearchTextbox.Text.ToLower();

            int searchStartLength = Settings.Default.TagSearchStart;
            bool displayAllTags = Settings.Default.DisplayAllTags;

            if (search.Length == 0)
            {
                if (displayAllTags)
                    for (int i = 0; i < tagsPanel.Controls.Count; i++)
                        tagsPanel.Controls[i].Show();
                else
                {
                    for (int i = 0; i < tagsPanel.Controls.Count; i++)
                    {
                        if (enabledTags.Contains(tagsPanel.Controls[i].Name))
                            tagsPanel.Controls[i].Show();
                        else
                            tagsPanel.Controls[i].Hide();
                    }
                }

                ReorderTagButtons();
            }
            else if (search.Length >= searchStartLength)
            {
                for (int i = 0; i < tagsPanel.Controls.Count; i++)
                {
                    if (tagsPanel.Controls[i].Name.ToLower().Contains(search))
                        tagsPanel.Controls[i].Show();
                    else
                        tagsPanel.Controls[i].Hide();
                }

                ReorderTagButtons();
            }

            tagsPanel.ResumeLayout();
        }

        private void TagCreationTextbox_TextChanged(object sender, EventArgs e)
        {
            tagCreationTextbox.Text = Utilities.Remove(tagCreationTextbox.Text, tagForbiddenCharacters);
        }

        #endregion

        #region Meta Application Interactions - (ApplicationResized, ApplicationExit, etc..)

        protected override void OnResizeBegin(EventArgs e)
        {
            Console.WriteLine("SortForm OnResizeBegin.");
            tagsPanel.SuspendLayout();
            base.OnResizeBegin(e);
        }

        protected override void OnResizeEnd(EventArgs e)
        {
            Console.WriteLine("SortForm OnResizeEnd.");
            tagsPanel.ResumeLayout();
            base.OnResizeEnd(e);
        }

        void ApplicationExit(Object source, EventArgs e)
        {
            Settings.Default.Tags = tags.ToArray();

            Settings.Save();
        }

        #endregion

        private void filenamesBefore_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            { 
                filenamesBefore.SelectedIndex = filenamesBefore.IndexFromPoint(e.X, e.Y);
                filenamesBeforeContextMenu.Show(filenamesBefore, new Point(e.X, e.Y));
            }
        }

        private void removeDoNotTagThisFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            filesBindingSource.RemoveAt(filenamesBefore.SelectedIndex);
            DisplayFilenamesAfter(GenerateFileNamesAfter());
        }

        private void applyMassTagButton_Click(object sender, EventArgs e)
        {
            string[] newNames = GenerateFileNamesAfter();

            if (enabledTags.Count > 0)
            {
                for (int i = 0; i < files.Count; i++)
                {
                    Utilities.MoveFile($"{directory}\\{files[i]}", $"{directory}\\{newNames[i]}");
                    filesBindingSource[i] = newNames[i];
                }
            }
        }

        private void actionComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            DisplayFilenamesAfter(GenerateFileNamesAfter());
        }

        private void renameToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UserRenameFile(filenamesBefore.SelectedIndex);
        }

        private void filenamesBefore_KeyUp(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.F2)
            {
                UserRenameFile(filenamesBefore.SelectedIndex);
            }
            else if (e.Control && (e.KeyCode == Keys.D))
            {
                filesBindingSource.RemoveAt(filenamesBefore.SelectedIndex);
            }
        }

        private void UserRenameFile(int index)
        {
            string entry = Utilities.MessageBoxGetString(Path.GetFileNameWithoutExtension(files[index]));
            if (entry != null && entry != Path.GetFileNameWithoutExtension(files[index]))
            {
                string newName = Utilities.MoveFile(
                    directory + "\\" + files[index],
                    directory + "\\" + Path.GetFileNameWithoutExtension(entry) + Path.GetExtension(files[index]).ToLower()
                );

                filesBindingSource[index] = Path.GetFileName(newName);

                DisplayFilenamesAfter(GenerateFileNamesAfter());
                filenamesAfter.TopIndex = filenamesBefore.TopIndex;
                filenamesAfter.SelectedIndex = filenamesBefore.SelectedIndex;
            }
        }

        private void listBox_Scrolled(object sender, ScrollEventArgs e)
        {
            ScrollingListBox listbox = sender as ScrollingListBox;

            if (listbox == filenamesBefore)
                filenamesAfter.TopIndex = filenamesBefore.TopIndex;
            else //filenamesAfter
                filenamesBefore.TopIndex = filenamesAfter.TopIndex;
        }

        private void listBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            ScrollingListBox listbox = sender as ScrollingListBox;
            if (listbox.SelectedIndex >= 1)
            { 
                if (listbox == filenamesBefore)
                    filenamesAfter.SelectedIndex = filenamesBefore.SelectedIndex;
                else //filenamesAfter
                    filenamesBefore.SelectedIndex = filenamesAfter.SelectedIndex;
            }
        }
    }
}
