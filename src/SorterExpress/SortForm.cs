using System;
using System.Windows.Forms;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using System.Drawing;
using Vlc.DotNet.Forms;
using System.Text.RegularExpressions;
using SorterExpress.Properties;
using Microsoft.VisualBasic.FileIO;

//This interesting line enables us to use enums without the prefix :o
//using static SorterExpress.PrefName;

namespace SorterExpress
{
    public partial class SortForm : Form
    {
        public static SortForm form;
        public string directory;
        public string[] folders;
        public List<string> files;
        public int fileIndex = 0;
        public const int MAX_FILE_WIDTH = 239;
        public const int MAX_FILE_HEIGHT = 275;

        Image img;
        VlcControl vlcControl = null;

        List<SubfolderInfo> customSubfolders; 

        List<Button> subfolderButtons;

        public List<string> previousTags;
        public List<string> tags;
        List<string> enabledTags;

        bool mute;
        bool repeat = true;
        int unmutedVolume;
        const string UNMUTED_ICON = "🔊";
        const string SPEAKER_ICON = "🔈";
        const string MUTED_ICON = "🔇";

        Move lastMove;

        // The same but without the space
        public readonly char[] noteForbiddenCharacters = { '/', '\\', '?', '%', '*', ':', '|', '"', '<', '>', '.' };
        public readonly char[] tagForbiddenCharacters = { '/', '\\', '?', '%', '*', ':', '|', '"', '<', '>', '.', ' ' };

        public SortForm(DirectoryInfo dirInfo)
        {
            InitializeComponent();
            SuspendLayout();

            ///Stuff that cant be done in the designer
            vlcControl = new VlcControl();
            vlcControl.BeginInit();
            vlcControl.Location = new Point(0, 0);
            vlcControl.Size = new Size(241, 197);
            //vlcControl.Dock = DockStyle.Top;
            vlcControl.Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top | AnchorStyles.Bottom;
            //vlcControl.Audio.Volume = volumeTrackbar.Value;
            vlcControl.VlcLibDirectoryNeeded += Utilities.VlcLibDirectoryNeeded;
            vlcControl.EndInit();
            videoPanel.Controls.Add(vlcControl);
            ///Stuff that cant be done in the designer

            form = this;

            volumeTrackbar.Value = Settings.Default.VideoVolume;
            mute = Settings.Default.VideoMute;

            subfolderButtons = new List<Button>();
            enabledTags = new List<string>();

            tags = Settings.Default.Tags ?? new List<string>();

            customSubfolders = new List<SubfolderInfo>();

            var sfnames = Settings.Default.SubfolderNames ?? new List<string>();
            var sfdirectories = Settings.Default.SubfolderDirectories ?? new List<string>();

            for (int i = 0; i < Math.Min(sfnames.Count, sfdirectories.Count); i++)
            {
                customSubfolders.Add(new SubfolderInfo(sfnames[i], sfdirectories[i], true));
            }

            if (Settings.Default.DisplayAllTags)
                Show();

            foreach (string tag in tags)
                tagsPanel.Controls.Add(CreateTagToggleButton(tag));

            previousTags = new List<string>();

            ReorderTagButtons();

            //Events 
            //this.Resize += ApplicationResized;
            this.FormClosed += ApplicationExit;
            notesTextBox.KeyDown += textBox_KeyDown;
            tagCreationTextbox.KeyDown += textBox_KeyDown;
            tagSearchTextbox.KeyDown += textBox_KeyDown;

            // Open directory

            if (dirInfo == null)
            {
                Logs.Log(true, "Directory open cancelled.");
                this.files = new List<string>();
                this.folders = new string[0];
            }
            else
            {
                this.directory = dirInfo.FullName;
                this.files = dirInfo.GetFileNamesList();
                this.folders = dirInfo.GetFolderNames();

                fileIndex = 0;

                Logs.Log(true, "Opened '" + directory + "' and found " + files.Count + " files and " + folders.Length + " subdirectories.");
                DrawSubfolderButtons();

                UpdateIndexLabels();
            }

            //These are here because the designer likes to delete them from the designer file all the time.
            videoPositionTrackBar.SetVlcControl(vlcControl);
            subfoldersPanel.VerticalScroll.Visible = true;
            this.KeyPreview = true;
            this.KeyDown += Form_KeyDown;
            this.ActiveControl = tagSearchTextbox;

            if (mute)
            {
                unmutedVolume = volumeTrackbar.Value;
                vlcControl.Audio.Volume = 0;
                volumeTrackbar.Value = 0;
                muteButton.Text = MUTED_ICON;
            }
            else
            {
                muteButton.Text = UNMUTED_ICON;
                vlcControl.Audio.Volume = (int)volumeTrackbar.Value;
            }

            LoadFile();

            ResumeLayout();
        }

        private void DrawSubfolderButtons()
        {
            //Do this so that we dont remove the VScrollBar
            var scrollbar = subfoldersPanel.FakeScroll;
            subfoldersPanel.Controls.Clear();
            subfoldersPanel.Controls.Add(scrollbar);

            int position = -1 + subfoldersPanel.AutoScrollPosition.Y;
            const int positionAdd = 26;

            int tabIndex = 50;

            for (int i = 0; i < customSubfolders.Count; i++)
            {
                if (Directory.Exists(customSubfolders[i].directory))
                {
                    SubfolderButton sfb = CreateSubfolderButton(customSubfolders[i]);
                    sfb.Location = new Point(0, position);
                    position += positionAdd;
                    subfoldersPanel.Controls.Add(sfb);
                    sfb.TabIndex = tabIndex;
                    tabIndex++;
                }
                else
                {
                    customSubfolders.RemoveAt(i);
                    i--;
                }
            }

            if (customSubfolders.Count > 0 && folders.Length > 0)
            {
                Label div = new Label();
                div.Text = "";
                div.BorderStyle = BorderStyle.Fixed3D;
                div.AutoSize = false;
                div.Height = 2;
                div.Width = 189 - 2 - 20;
                div.Location = new Point(0 + 10, position);
                subfoldersPanel.Controls.Add(div);
                div.BringToFront();
                position += 5;
            }

            for (int i = 0; i < folders.Length; i++)
            {
                SubfolderButton sfb = CreateSubfolderButton(Path.GetFileName(folders[i]), directory + "/" + folders[i], false);
                sfb.Location = new Point(0, position);
                position += positionAdd;
                subfoldersPanel.Controls.Add(sfb);
                sfb.TabIndex = tabIndex;
                tabIndex++;
            }
        }

        private SubfolderButton CreateSubfolderButton(SubfolderInfo info)
        {
            return CreateSubfolderButton(info.name, info.directory, info.custom);
        }

        private SubfolderButton CreateSubfolderButton(string name, string directory, bool custom)
        {
            SubfolderButton button = new SubfolderButton();
            button.Size = new Size(189, 22);
            button.UseMnemonic = false;

            button.Text = name;

            button.subfolderInfo.name = name;
            button.subfolderInfo.directory = directory;
            button.subfolderInfo.custom = custom;

            tooltip.SetToolTip(button, directory + (custom ? "\nThis is a custom, user-added directory, right click to remove." : ""));

            button.TextAlign = ContentAlignment.BottomLeft;
            button.MouseUp += subfolderButton_MouseUp;

            return button;
        }

        internal void LoadNewTags(List<string> newTags)
        {
            tags = newTags;
            tagsPanel.Controls.Clear();

            foreach (string tag in tags)
                tagsPanel.Controls.Add(CreateTagToggleButton(tag));

            ReorderTagButtons();
        }

        private void Form_KeyDown(object sender, KeyEventArgs e)
        {
            
        }

        private void LoadFile()
        {
            //https://support.microsoft.com/en-au/help/309482/image-file-is-locked-when-you-set-the-picturebox-image-property-to-a-f

            if (files.Count > 0)
            {
                ClampFileIndex();
                string filename = files[fileIndex];

                UncheckAllTags();
                enabledTags.Clear();

                filenameTextbox.Text = Path.GetFileNameWithoutExtension(files[fileIndex]);
                fileExtensionTextbox.Text = Path.GetExtension(files[fileIndex]);

                string[] possibleTags = Path.GetFileNameWithoutExtension(filename).Split(' ');

                for (int i = 0; i < possibleTags.Length; i++)
                {
                    if (tags.Contains(possibleTags[i], StringComparer.OrdinalIgnoreCase))
                    {
                        CheckBox[] cbs = tagsPanel.Controls.OfType<CheckBox>()
                            .Where(t => t.Name.Equals(possibleTags[i], StringComparison.OrdinalIgnoreCase))
                            .ToArray();

                        for (int j = 0; j < cbs.Length; j++)
                        {
                            cbs[j].Checked = true;
                            enabledTags.Add(cbs[j].Name);   //Gotta make sure to add the tag's correct capitalisation.
                        }

                        Console.WriteLine($"Found tag {possibleTags[i]} in filename.");
                    }
                }

                if (!Settings.Default.DisplayAllTags)
                {
                    var cbs = tagsPanel.Controls.OfType<CheckBox>().ToArray();
                    for (int i = 0; i < cbs.Length; i++)
                        if (cbs[i].Checked)
                            cbs[i].Visible = true;
                        else
                            cbs[i].Visible = false;

                    ReorderTagButtons();
                }


                if (Utilities.imageFileExtensions.Contains(GetFileExtension(filename)))
                {
                    messageTextBox.Hide();
                    vlcControl.Stop();
                    videoPanel.Hide();
                    pictureBox.Show();
                    pictureBox.Enabled = true;

                    try
                    {
                        using (var fs = new FileStream(directory + "\\" + filename, FileMode.Open))
                        {
                            var ms = new MemoryStream();
                            fs.CopyTo(ms);
                            ms.Position = 0;                               // <=== here
                            if (pictureBox.Image != null)
                                pictureBox.Image.Dispose();
                            img = Image.FromStream(ms);
                            pictureBox.Image = img;
                        }
                    }
                    catch (Exception e)
                    {
                        pictureBox.Hide();
                        videoPanel.Hide();

                        messageTextBox.Text = "An error occured attempting to load this file. Error message: \n\n" + e.Message;
                        messageTextBox.Show();
                    }
                }
                else if (Utilities.videoFileExtensions.Contains(GetFileExtension(filename)))
                {
                    string[] mediaOptions;

                    mediaOptions = new string[] { (repeat) ? "input-repeat=4000" : "input-repeat=0" };

                    var fi = new FileInfo(directory + "/" + filename);
                    vlcControl.SetMedia(fi, mediaOptions);
                    vlcControl.Play();
                    vlcControl.Audio.Volume = (int)volumeTrackbar.Value;

                    messageTextBox.Hide();
                    pictureBox.Hide();
                    videoPanel.Show();
                }
                else
                {
                    pictureBox.Hide();
                    videoPanel.Hide();
                    messageTextBox.Show();
                    messageTextBox.Text = "File format '" + GetFileExtension(files[fileIndex]) + "' not supported.\n\nYou can view the file by clicking the 'Open File' button below.";
                }

                filenameTextbox.Text = Path.GetFileNameWithoutExtension(filename);
                fileExtensionTextbox.Text = Path.GetExtension(filename);
                GenerateFileName();
            }
            else
            {
                videoPanel.Hide();
                pictureBox.Hide();

                messageTextBox.Text = "No files left in directory, well done on sorting them all!\n\nUse the 'Open Directory' button to sort another directory.";
                messageTextBox.Show();
            }

            UpdateIndexLabels();
        }

        private bool MoveFile(string fromDir, string toDir)
        {
            if (fromDir == toDir)
            {
                if (Settings.Default.MoveSortedFiles)
                {
                    if (!Directory.Exists(directory + "/Sorted"))
                    {
                        Directory.CreateDirectory(directory + "/Sorted");
                    }

                    toDir += "/" + "Sorted";
                }
            }

            string extension = GetFileExtension(files[fileIndex]);

            if (Utilities.FileIsVideo(files[fileIndex]))
            {
                vlcControl.Stop();
            }

            try
            {
                string filename = GenerateFileName() + extension;

                string newPath = Utilities.MoveFile(fromDir + "\\" + files[fileIndex], toDir + "\\" + filename);

                lastMove = new Move(fromDir + "\\" + files[fileIndex], newPath, enabledTags.Clone(), notesTextBox.Text);

                files.RemoveAt(fileIndex);
                ClampFileIndex();

                // Reset fields for next image.
                notesTextBox.Text = "";

                LoadFile();
                tooltip.SetToolTip(filenameTextbox, $"Original filename: {files[fileIndex]}");
                UpdateIndexLabels();

                if (fromDir == toDir)
                    Logs.Log(true, $"Renamed '{filenameTextbox.Text.Trim() + fileExtensionTextbox.Text}' to '{filename}'.");
                else
                    Logs.Log(true, $"Moved '{filenameTextbox.Text.Trim() + fileExtensionTextbox.Text}' to folder '{toDir.Split('/').Last()}' with new name '{filename}'.");
            }
            catch (Exception ex)
            {
                Logs.Log(true, $"Encountered an exception trying to move or rename file '{GenerateFileName()}': {ex.ToString()}");
                return false;
            }

            return true;
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
        /// Generates filename and displays it in text box, returns filename with no dot or extension
        /// </summary>
        public string GenerateFileName()
        {
            if (enabledTags.Count == 0 && String.IsNullOrWhiteSpace(notesTextBox.Text))
            {
                newFileNameTextBox.Text = files[fileIndex];
                return Path.GetFileNameWithoutExtension(files[fileIndex]);
            }
            else
            {
                string name = "";

                if (enabledTags.Count > 0)
                {
                    enabledTags.Sort();
                    name += String.Join(" ", enabledTags);
                }

                if (notesTextBox.Text.Length > 0)
                    if (enabledTags.Count == 0)
                        name += notesTextBox.Text;
                    else
                        name += " (" + notesTextBox.Text + ")";

                newFileNameTextBox.Text = name;

                if (String.IsNullOrWhiteSpace(name))
                    return files[fileIndex];

                return name;
            }
        }

        public void UpdateIndexLabels()
        {
            //Will add 1 if files.Count is > 0. If not will result to 0.
            ChangeFileIndexTextBoxTextSilently((fileIndex + (files.Count > 0 ? 1 : 0)).ToString());

            fileCountTextbox.Text = files.Count.ToString();
        }

        /// <summary>
        /// Change the text field of fileIndexTextBox without firing the text changed event listener.
        /// </summary>
        private void ChangeFileIndexTextBoxTextSilently(string newText)
        {
            fileIndexTextbox.TextChanged -= fileIndexTextbox_TextChanged;
            fileIndexTextbox.Text = newText;
            fileIndexTextbox.TextChanged += fileIndexTextbox_TextChanged;
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

            if (e.KeyChar == '\r')  // /r (13) = enter key
            {
                cb.Checked = !cb.Checked;
                toggleTagButton_MouseUp(sender, new MouseEventArgs(MouseButtons.Left, 1, 0, 0, 0));
                e.Handled = true;
            }
            else if (e.KeyChar == '\u001b') // \u001b = escape key
            {
                toggleTagButton_MouseUp(sender, new MouseEventArgs(MouseButtons.Right, 1, 0, 0, 0));
                e.Handled = true;
            }
        }

        /// <summary>
        /// Clamp fileIndex variable to 0 and files.Count - 1.
        /// </summary>
        public void ClampFileIndex()
        {
            if (files.Count == 0)
                fileIndex = 0;
            else
            {
                fileIndex = fileIndex < 0 ? 0 : fileIndex;
                fileIndex = fileIndex >= files.Count ? files.Count - 1 : fileIndex;
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

        private void openDirectoryButton_Click(object sender, System.EventArgs e)
        {
            var dirInfo = Utilities.OpenDirectory();

            if (dirInfo != null)
            {
                this.directory = dirInfo.FullName;
                this.files = dirInfo.GetFileNamesList();
                this.folders = dirInfo.GetFolderNames();

                fileIndex = 0;
                LoadFile();

                Logs.Log(true, "Opened '" + directory + "' and found " + files.Count + " files and " + folders.Length + " subdirectories.");

                DrawSubfolderButtons();

                UpdateIndexLabels();
            }
        }

        private void prevFileButton_Click(object sender, EventArgs e)
        {
            if (fileIndex > 0)
            {
                fileIndex--;
                LoadFile();
                UpdateIndexLabels();
            }
        }

        private void nextFileButton_Click(object sender, EventArgs e)
        {
            if (fileIndex < files.Count - 1)
            {
                fileIndex++;
                UpdateIndexLabels();
                LoadFile();
            }
        }

        private void openFileButton_Click(object sender, EventArgs e)
        {
            //https://stackoverflow.com/questions/11365984/c-sharp-open-file-with-default-application-and-parameters
            System.Diagnostics.Process.Start(directory + "/" + files[fileIndex]);
        }

        private void openFileInExplorerButton_Click(object sender, EventArgs e)
        {
            //https://stackoverflow.com/questions/13680415/how-to-open-explorer-with-a-specific-file-selected
            System.Diagnostics.Process.Start("explorer.exe", string.Format("/select," + directory + "\\" + files[fileIndex]));
        }

        private void subfolderButton_MouseUp(object sender, MouseEventArgs e)
        {
            SubfolderButton button = (SubfolderButton)sender;

            if (e.Button == MouseButtons.Left)
            {
                MoveFile(directory, button.subfolderInfo.directory);
                tagSearchTextbox.Focus();
            }
            else if (e.Button == MouseButtons.Right)
            {
                if (button.subfolderInfo.custom)
                {
                    customSubfolders.RemoveAll(t => t.name == button.subfolderInfo.name && t.directory == button.subfolderInfo.directory);
                    DrawSubfolderButtons();
                }
            }
        }

        private void addTagButton_Click(object sender, EventArgs e)
        {
            if (tags.Where(t => t == tagCreationTextbox.Text).Count() > 0)
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

                GenerateFileName();
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
                form.GenerateFileName();
            }
        }

        private void firstFileButton_Click(object sender, EventArgs e)
        {
            fileIndex = 0;
            LoadFile();
            UpdateIndexLabels();
        }

        private void lastFileButton_Click(object sender, EventArgs e)
        {
            fileIndex = files.Count - 1;
            LoadFile();
            UpdateIndexLabels();
        }

        static void textBox_KeyDown(object sender, KeyEventArgs e)
        {
            TextBox tb = (TextBox)sender;

            if (e.Control)
            {
                if (e.KeyCode == Keys.D)
                {
                    form.deleteButton_Click(null, null);
                }
                else if (e.KeyCode == Keys.Z)
                {
                    form.undoButton_Click(null, null);
                    e.Handled = true;
                    e.SuppressKeyPress = true;
                }
                else if (e.KeyCode == Keys.P) //Load previously saved tags
                {
                    foreach (string prevTag in form.previousTags)
                    {
                        if (!form.enabledTags.Contains(prevTag))
                        {
                            form.enabledTags.Add(prevTag);
                        }
                    }

                    /*foreach (CheckBox cb in form.tagsPanel.Controls.OfType<CheckBox>().Where(t => form.enabledTags.Contains(t.Name)))
                    {
                        cb.Checked = true;
                    }*/

                    foreach(CheckBox cb in form.tagsPanel.Controls.OfType<CheckBox>())
                    {
                        if (form.enabledTags.Contains(cb.Name))
                        {
                            cb.Checked = true;
                            cb.Show();
                        }
                        else if (!cb.Checked)
                        {
                            cb.Hide();
                        }
                    }

                    form.ReorderTagButtons();
                    form.GenerateFileName();

                    e.Handled = true;
                    e.SuppressKeyPress = true;
                }
            }

            if (e.KeyCode == Keys.Left)
            {
                if (e.Alt)
                    form.vlcControl.Position -= 0.1f;
                else if (tb.Text.Length == 0)
                    form.prevFileButton_Click(null, null);
            }
            else if (e.KeyCode == Keys.Right)
            {
                if (e.Alt)
                    form.vlcControl.Position += 0.1f;
                else if (tb.Text.Length == 0)
                    form.nextFileButton_Click(null, null);
            }

            if (e.KeyCode == Keys.Enter)
            {
                if (tb == form.tagCreationTextbox)
                {
                    form.addTagButton_Click(null, null);
                    e.Handled = true;
                    e.SuppressKeyPress = true;
                }
                if (tb == form.notesTextBox || (tb == form.tagSearchTextbox && form.tagSearchTextbox.Text.Length == 0))
                {
                    form.saveButton_Click(null, null);
                    e.Handled = true;
                    e.SuppressKeyPress = true;
                }
                else if (tb == form.tagSearchTextbox && form.tagSearchTextbox.Text.Length > 0)
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

        private void videoPauseButton_Click(object sender, EventArgs e)
        {
            if (vlcControl.IsPlaying)
                vlcControl.Pause();
        }

        private void videoPlayButton_Click(object sender, EventArgs e)
        {
            if (!vlcControl.IsPlaying)
            {
                if (vlcControl.Position == 1f)
                    vlcControl.Position = 0f;

                vlcControl.Play();
            }
        }

        private void muteButton_Click(object sender, EventArgs e)
        {
            Console.WriteLine("muteButton_Click, unmutedVolume: " + unmutedVolume);
            if (mute)
            {
                volumeTrackbar.Value = (unmutedVolume < 2) ? 100 : unmutedVolume;
                muteButton.Text = UNMUTED_ICON;
                tooltip.SetToolTip(muteButton, "Mute video");
                mute = false;
            }
            else
            {
                unmutedVolume = volumeTrackbar.Value;
                volumeTrackbar.Value = 0;
                muteButton.Text = MUTED_ICON;
                tooltip.SetToolTip(muteButton, "Unmute video");
                mute = true;
            }
        }

        private void volumeTrackbar_ValueChanged(object sender, decimal value)
        {
            Console.WriteLine("volumeTrackbar_ValueChanged: " + value);

            if (vlcControl == null)
                return;

            if (value > 0)
            {
                muteButton.Text = UNMUTED_ICON;
                tooltip.SetToolTip(muteButton, "Mute video");
                mute = false;
            }
            else
            {
                muteButton.Text = MUTED_ICON;
                tooltip.SetToolTip(muteButton, "Unmute video");
                mute = true;
            }

            unmutedVolume = (int)value;
            vlcControl.Audio.Volume = (int)value;
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            previousTags.Clear();

            for (int i = 0; i < enabledTags.Count; i++)
                previousTags.Add(enabledTags[i]);

            MoveFile(directory, directory);
        }

        private void settingsButton_Click(object sender, EventArgs e)
        {
            SettingsForm settingsForm = new SettingsForm();
            settingsForm.Show();
        }

        private void fileIndexTextbox_TextChanged(object sender, EventArgs e)
        {
            if (String.IsNullOrWhiteSpace(fileIndexTextbox.Text))
            {
                Console.WriteLine("string is null or white space, setting file index to 0.");
                fileIndex = 0;
                ChangeFileIndexTextBoxTextSilently("1");
                LoadFile();
            }
            else
            {
                string stringNumbersOnly = Regex.Replace(fileIndexTextbox.Text, "[^0-9]", "");

                if (stringNumbersOnly.Length < 1)
                {
                    Console.WriteLine("string with numbers only is empty, setting file index to 0.");
                    fileIndex = 0;
                    ChangeFileIndexTextBoxTextSilently("1");
                    LoadFile();
                }
                else
                {
                    int stringAsInt = int.Parse(stringNumbersOnly);

                    stringAsInt = (stringAsInt > files.Count) ? files.Count : stringAsInt;
                    stringAsInt = (stringAsInt < 1) ? 1 : stringAsInt;

                    ChangeFileIndexTextBoxTextSilently(stringAsInt.ToString());
                    fileIndex = stringAsInt - 1;
                    LoadFile();
                }
            }
        }

        private void StretchImageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
        }

        private void FitImageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pictureBox.SizeMode = PictureBoxSizeMode.Zoom;
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

        private void FilenameTextbox_TextChanged(object sender, EventArgs e)
        {

        }

        private void TagCreationTextbox_TextChanged(object sender, EventArgs e)
        {
            tagCreationTextbox.Text = Utilities.Remove(tagCreationTextbox.Text, tagForbiddenCharacters);
        }

        private void deleteButton_Click(object sender, EventArgs e)
        {
            /*string title = $"Really delete {files[fileIndex]}?";
            DialogResult answer = MessageBox.Show(title,
                title,
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning,
                MessageBoxDefaultButton.Button1);*/

            DialogResult result = MessageBox.Show(
                    "This action will delete the currently viewed image, is that okay?\n"
                  + "The deleted file will be moved to the Recycle Bin, where it can be manually recovered if desired.",
                    "Deletion Warning",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning
                );

            if (result == DialogResult.Yes)
            {
                if (Utilities.videoFileExtensions.Contains(GetFileExtension(files[fileIndex])))
                    vlcControl.Stop();

                FileSystem.DeleteFile(directory + "/" + files[fileIndex], UIOption.OnlyErrorDialogs, RecycleOption.SendToRecycleBin, UICancelOption.ThrowException);

                Logs.Log(true, $"Deleted file '{directory + "/" + files[fileIndex]}'.");

                files.RemoveAt(fileIndex);
                ClampFileIndex();

                // Reset fields for next image.
                enabledTags.Clear();
                UncheckAllTags();
                tagSearchTextbox.Focus();
                notesTextBox.Text = "";

                LoadFile();
                tooltip.SetToolTip(filenameTextbox, $"Original filename: {files[fileIndex]}");
                UpdateIndexLabels();
            }
        }

        private void undoButton_Click(object sender, EventArgs e)
        {
            if (lastMove != null)
            {
                File.Move(lastMove.to, lastMove.from);
                string filename = Path.GetFileName(lastMove.from);
                files.Insert(Math.Max(0, fileIndex - 1), filename);
                fileIndex = Math.Max(0, fileIndex - 1);
                LoadFile();
                enabledTags = lastMove.enabledTags;

                foreach (CheckBox cb in tagsPanel.Controls.OfType<CheckBox>().Where(t => enabledTags.Contains(t.Name)))
                {
                    cb.Show();
                    cb.Checked = true;
                }

                ReorderTagButtons();
                GenerateFileName();
            }
        }

        private void NotesTextBox_TextChanged(object sender, EventArgs e)
        {
            notesTextBox.Text = Utilities.Remove(notesTextBox.Text, noteForbiddenCharacters);
            GenerateFileName();
        }

        private void TableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void AddDirectoryButton_Click(object sender, EventArgs e)
        {
            AddDirectoryForm adf = new AddDirectoryForm((name, directory) =>
            {
                customSubfolders.Add(new SubfolderInfo(name, directory, true));
                DrawSubfolderButtons();
            });

            adf.Show();
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            //capture up arrow key
            if (keyData == Keys.Up)
            {
                form.SelectNextControl(ActiveControl, false, true, true, true);
                return true;
            }
            //capture down arrow key
            if (keyData == Keys.Down)
            {
                form.SelectNextControl(ActiveControl, true, true, true, true);
                return true;
            }

            return base.ProcessCmdKey(ref msg, keyData);
        }

        #endregion

        #region Meta Application Interactions - (ApplicationResized, ApplicationExit, etc..)

        public void ResizeBegin(EventArgs e)
        {
            OnResizeBegin(e);
        }

        protected override void OnResizeBegin(EventArgs e)
        {
            Console.WriteLine("SortForm OnResizeBegin.");
            tagsPanel.SuspendLayout();
            base.OnResizeBegin(e);
        }

        public void ResizeEnd(EventArgs e)
        {
            OnResizeEnd(e);
        }

        protected override void OnResizeEnd(EventArgs e)
        {
            Console.WriteLine("SortForm OnResizeEnd.");
            tagsPanel.ResumeLayout();
            base.OnResizeEnd(e);
        }

        void ApplicationExit(Object source, EventArgs e)
        {
            // On exit, set all these prefs but dont save after each one, save after setting them all.
            Settings.Default.Tags = tags;

            Settings.Default.SubfolderNames = customSubfolders.Select(t => t.name).ToList();
            Settings.Default.SubfolderDirectories = customSubfolders.Select(t => t.directory).ToList();

            Settings.Default.VideoMute = mute;
            Settings.Default.VideoVolume = volumeTrackbar.Value;

            Settings.Default.Save();
        }

        #endregion
    }
}
