using System.Windows.Forms;
using System.IO;
using System.Linq;
using System.Collections.Generic;
using System;
using System.Drawing;
using Vlc.DotNet.Forms;
using SorterExpress.Properties;

namespace SorterExpress
{
    public partial class ViewForm : Form
    {
        public static ViewForm form;
        public string directory;
        public string[] files, folders;
        public const int MAX_FILE_WIDTH = 239;
        public const int MAX_FILE_HEIGHT = 275;
        Image img;
        VlcControl vlcControl;

        public string currentFile;
        public List<string> tags;
        public Dictionary<string, int> tagCounts;
        public List<CheckBox> tagButtons;

        bool mute;
        bool repeat = true;
        int unmutedVolume;
        const string UNMUTED_ICON = "🔊";
        const string SPEAKER_ICON = "🔈";
        const string MUTED_ICON = "🔇";

        // Resizing stuff
        public Size prevSize;
        public int pictureBoxWidthOffset, pictureBoxHeightOffset;
        public int vlcControlWidthOffset, vlcControlHeightOffset;
        public int fileFormatMessageWidthOffset, fileFormatMessageHeightOffset;
        public int panelsHeightOffset;

        FFMPEG ffmpeg;

        List<string> andTags, orTags, notTags;

        public ViewForm(DirectoryInfo dirInfo)
        {
            InitializeComponent();
            form = this;
            tagSearchTextBox.KeyDown += tagSearchTextBox_KeyDown;
            tabControl.Selected += tabControl_Selected;

            vlcControl = new VlcControl();
            vlcControl.BeginInit();
            vlcControl.Location = new Point(0, 0);
            vlcControl.Size = new Size(237, 194);
            vlcControl.Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top | AnchorStyles.Bottom;
            //vlcControl.Audio.Volume = volumeTrackbar.Value;
            vlcControl.VlcLibDirectoryNeeded += Utilities.VlcLibDirectoryNeeded;
            vlcControl.EndInit();
            videoPanel.Controls.Add(vlcControl);

            this.KeyPreview = true;
            ///These are here because the designer likes to delete them from the designer file all the time.
            videoPositionTrackBar.SetVlcControl(vlcControl);
            volumeTrackbar.Value = Settings.Default.VideoVolume;//Prefs.Get<int>(Pref.VideoVolume, 10);
            vlcControl.Audio.Volume = volumeTrackbar.Value;
            mute = Settings.Default.VideoMute;//Prefs.Get<bool>(Pref.VideoMute, false);

            if (mute)
            {
                unmutedVolume = volumeTrackbar.Value;
                vlcControl.Audio.Volume = 0;
                volumeTrackbar.Value = 0;
                muteButton.Text = MUTED_ICON;
            }
            else
                muteButton.Text = UNMUTED_ICON;

            //Events 
            this.Resize += ApplicationResized;

            LoadDirectory(dirInfo);
        }

        public void LoadDirectory(DirectoryInfo dirInfo)
        {
            var watch = System.Diagnostics.Stopwatch.StartNew();

            if (dirInfo == null)
            {
                this.directory = null;
                files = new string[0];
            }
            else
            {
                this.directory = dirInfo.FullName;
                files = dirInfo.GetFileNamesArray();
            }

            tags = new List<string>();
            tagCounts = new Dictionary<string, int>();

            string[] fileTags;

            for (int i = 0; i < files.Length; i++)
            {
                fileTags = Utilities.GetTags(files[i]);

                //Foreach tag in file
                for (int j = 0; j < fileTags.Length; j++)
                {
                    if (!String.IsNullOrWhiteSpace(fileTags[j]))
                        if (!tags.Contains(fileTags[j]))
                            tags.Add(fileTags[j]);

                    if (tagCounts.ContainsKey(fileTags[j]))
                        tagCounts[fileTags[j]]++;
                    else
                        tagCounts[fileTags[j]] = 1;
                }
            }

            tags.Sort();

            tabControl.SuspendLayout();

            tagButtons = new List<CheckBox>();
            int scrollY = andPage.AutoScrollPosition.Y;
            CheckBox cb;

            for (int i = 0; i < tags.Count; i++)
            {
                cb = CreateTagToggleButton(tags[i]);
                cb.Location = new Point(2, 5 + (i * 26) + scrollY);
                andPage.Controls.Add(cb);
                tagButtons.Add(cb);
            }

            andTags = new List<string>();
            orTags = new List<string>();
            notTags = new List<string>();

            tabControl.ResumeLayout();

            watch.Stop();
            Console.WriteLine($"Loaded directory in {watch.ElapsedMilliseconds}ms ({watch.ElapsedMilliseconds / 1000} seconds).");
        }

        private void LoadFile(string filename)
        {
            try
            {
                if (Utilities.imageFileExtensions.Contains(Path.GetExtension(filename)))
                {
                    fileFormatNotSupportedTextbox.Hide();
                    vlcControl.Stop();
                    videoPanel.Hide();

                    pictureBox.Show();
                    pictureBox.Enabled = true;

                    using (var fs = new FileStream(directory + "\\" + filename, FileMode.Open))
                    {
                        var ms = new MemoryStream();
                        fs.CopyTo(ms);
                        ms.Position = 0;

                        if (pictureBox.Image != null)
                            pictureBox.Image.Dispose();

                        img = Image.FromStream(ms);
                        pictureBox.Image = img;
                    }
                }
                else if (Utilities.videoFileExtensions.Contains(Path.GetExtension(filename)))
                {
                    string[] mediaOptions;
                    
                    mediaOptions = new string[] { (repeat) ? "input-repeat=4000" : "input-repeat=0" };

                    var fi = new FileInfo(directory + "/" + filename);
                    vlcControl.SetMedia(fi, mediaOptions);
                    vlcControl.Play();

                    fileFormatNotSupportedTextbox.Hide();
                    videoPanel.Show();
                    pictureBox.Hide();
                }
                else
                {
                    pictureBox.Hide();
                    videoPanel.Hide();
                    fileFormatNotSupportedTextbox.Show();
                    fileFormatNotSupportedTextbox.Text = "File format '" + Path.GetExtension(currentFile) + "' not supported.\n\nYou can view the file by clicking the 'Open File' button below.";
                }
            }
            catch (Exception ex)
            {
                pictureBox.Hide();
                videoPanel.Hide();
                fileFormatNotSupportedTextbox.Show();
                fileFormatNotSupportedTextbox.Text = "An error occured attempting to display an image/video.\n\n";
                fileFormatNotSupportedTextbox.Text = "Exception: " + ex.ToString();
            }
        }

        private CheckBox CreateTagToggleButton(string tag)
        {
            CheckBox cb = new CheckBox();
            cb.Appearance = Appearance.Button;
            cb.Size = new Size(180, 22);
            cb.Text = tag;// $"{tag} ({tagCounts[tag]})";
            cb.Tag = tag;
            cb.Name = tag;
            cb.MouseUp += toggleTagButton_MouseUp;
            tooltip.SetToolTip(cb, $"Toggle tag '{tag}' on or off.\nThis tag occurs in {tagCounts[tag]} files.\nRight click to delete tag from tag list.");

            return cb;
        }

        private Button CreateFileButton(string filename)
        {
            Button button = new Button();
            button.Size = new Size(65, 65);

            if (Utilities.videoFileExtensions.Contains(Path.GetExtension(filename)))
            {
                string thumbnailFilename = Program.VIDEO_THUMBS_PATH + "\\" + Utilities.MD5(filename) + ".jpg";

                if (!File.Exists(thumbnailFilename))
                {
                    if (ffmpeg == null)
                        ffmpeg = new FFMPEG();

                    ffmpeg.GetThumbnail(directory + "\\" + filename, thumbnailFilename, 60, (s) =>
                    {
                        try
                        {
                            button.Image = Image.FromFile(s);
                        }
                        catch
                        {
                            button.Image = null;
                            button.Text = s;
                        }
                    });
                }
                else
                {
                    button.Image = Image.FromFile(thumbnailFilename);
                }
            }
            else
            {
                button.Image = Image.FromFile(directory + "/" + filename).GetThumbnailImage(50, 50, null, IntPtr.Zero);
            }

            button.Name = filename;
            tooltip.SetToolTip(button, filename);

            button.Click += fileButton_Click;

            return button;
        }

        private TabPage GetActivePage()
        {
            Console.WriteLine("Active Tab is " + tabControl.SelectedTab.Name);
            return tabControl.SelectedTab;
        }

        private List<string> GetActivePageTagList()
        {
            if (tabControl.SelectedTab == andPage)
            {
                Console.WriteLine("Active Tags is andTags.");
                return andTags;
            }
            else if (tabControl.SelectedTab == orPage)
            {
                Console.WriteLine("Active Tags is orTags.");
                return orTags;
            }
            else 
            {
                Console.WriteLine("Active Tags is notTags.");
                return notTags;
            }
        }

        private void SearchFiles()
        {
            const int COLUMNS = 4;
            const int BUTTON_WIDTH = 65;
            const int BUTTON_HEIGHT = 65;

            string[] results = files.Where(t => Match(t)).ToArray();

            resultsCountLabel.Text = results.Length + " Results";

            filesPanel.Controls.Clear();
            int scrollY = filesPanel.AutoScrollPosition.Y;

            Button fileButton;

            for (int i = 0; i < results.Length; i++)
            {
                fileButton = CreateFileButton(results[i]);
                fileButton.Location = new Point((i % COLUMNS) * BUTTON_WIDTH, -1 + ((i / COLUMNS) * BUTTON_HEIGHT) + scrollY);
                filesPanel.Controls.Add(fileButton);
            }
        }

        /// <summary>
        /// Returns true if a filename should match the selected search parameters.
        /// </summary>
        private bool Match(string filename)
        {
            if (filename.Contains("("))
                filename = filename.Substring(0, filename.IndexOf('('));
            else
                filename = Path.GetFileNameWithoutExtension(filename);

            string[] fileTags = filename.Trim().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            // Must have all 'and' tags.
            if (andTags.Count > 0)
                if (fileTags.Intersect(andTags).Count() != andTags.Count)
                    return false;

            // Must have atleast one 'or' tag.
            if (orTags.Count > 0)
                if (fileTags.Intersect(orTags).Count() < 1)
                    return false;

            // Must not have any 'not' tags.
            if (notTags.Count > 0)
                if (fileTags.Select(t => t).Intersect(notTags).Any())
                    return false;

            return true;
        }

        /// <summary>
        /// Reorder visible tag buttons.
        /// </summary>
        public void ReorderTagButtons()
        {
            TabPage selectedPage = GetActivePage();
            CheckBox[] checkedButtons, uncheckedButtons;

            tabControl.SuspendLayout();

            foreach (TabPage tabPage in tabControl.TabPages)
            {
                tabPage.SuspendLayout();
            }

            /*if (tagSearchTextBox.Text.Length > 0)
            {*/
                var temp = selectedPage.Controls.OfType<CheckBox>()
                    .Where(t => t.Visible)
                    .OrderByDescending(t => t.Name.ToLower().StartsWith(tagSearchTextBox.Text.ToLower()))
                    .ThenBy(t => t.Name);

                checkedButtons = temp.Where(t => t.Checked).ToArray();
                uncheckedButtons = temp.Where(t => !t.Checked).ToArray();
            /*}
            else
            {
                var temp = selectedPage.Controls.OfType<CheckBox>()
                    .Where(t => t.Visible)
                    .OrderBy(t => t.Name);

                checkedButtons = temp.Where(t => t.Checked).ToArray();
                uncheckedButtons = temp.Where(t => !t.Checked).ToArray();
            }*/

            int scrollY = selectedPage.AutoScrollPosition.Y;
            int y = 5 + (0 * 26) + scrollY;

            for (int i = 0; i < checkedButtons.Length; i++)
            {
                checkedButtons[i].Location = new Point(0, y);
                checkedButtons[i].TabIndex = i + 6; //5 is tag search box tab index.
                y += 26;
            }

            // Add a gap between checked and unchecked buttons.
            if (checkedButtons.Length > 0)
                y += 10;

            for (int i = 0; i < uncheckedButtons.Length; i++)
            {
                uncheckedButtons[i].Location = new Point(0, y);
                uncheckedButtons[i].TabIndex = i + 6 + checkedButtons.Length; //5 is tag search box tab index.
                y += 26;
            }

            foreach (TabPage tabPage in tabControl.TabPages)
            {
                tabPage.ResumeLayout();
            }

            tabControl.ResumeLayout();
        }

        #region Form Events

        private void tabControl_Selected(object sender, TabControlEventArgs e)
        {
            tabControl.SuspendLayout();

            var activePage = GetActivePage();
            var activeTags = GetActivePageTagList();

            foreach (TabPage tabpage in tabControl.TabPages)
            {
                tabpage.SuspendLayout();
            }

            int lastVis = -1;

            if (tagButtons.Where(t => t.Visible).Count() > 0)
                lastVis = tagButtons.FindLastIndex(t => t.Visible);

            for (int i = 0; i < tagButtons.Count; i++)
            {
                activePage.Controls.Add(tagButtons[i]);

                if (activeTags.Contains(tagButtons[i].Name))
                    tagButtons[i].Checked = true;
                else
                    tagButtons[i].Checked = false;

                if (i == lastVis)
                {
                    tagButtons[i].VisibleChanged += (s, ee) => 
                    {
                        if ((s as Control).Visible)
                        {
                            Console.WriteLine("Lastvis!");
                            ReorderTagButtons();
                        }
                    };
                }
            }

            FilterTagButtons();
            ReorderTagButtons();

            foreach (TabPage tabpage in tabControl.TabPages)
            {
                tabpage.ResumeLayout();
            }

            tabControl.ResumeLayout();
        }

        private void toggleTagButton_MouseUp(object sender, MouseEventArgs e)
        {
            CheckBox button = (CheckBox)sender;

            var page = GetActivePage();
            var list = GetActivePageTagList();

            if (button.Checked)
            {
                if (!list.Contains(button.Text))
                    list.Add(button.Text);
            }
            else
            {
                list.Remove(button.Text);
            }

            page.Text = (string)page.Tag + $" ({list.Count})";

            ReorderTagButtons();
        }

        private void fileButton_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            LoadFile(button.Name);
            currentFile = button.Name;
        }

        private void openFileButton_Click(object sender, EventArgs e)
        {
            //https://stackoverflow.com/questions/11365984/c-sharp-open-file-with-default-application-and-parameters
            System.Diagnostics.Process.Start(directory + "/" + currentFile);
        }

        private void openFileInExplorerButton_Click(object sender, EventArgs e)
        {
            //https://stackoverflow.com/questions/13680415/how-to-open-explorer-with-a-specific-file-selected
            System.Diagnostics.Process.Start("explorer.exe", string.Format("/select," + directory + "\\" + currentFile));
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
            if (mute)
            {
                if (unmutedVolume == 0)
                    volumeTrackbar.Value = 10;
                else
                    volumeTrackbar.Value = unmutedVolume;

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
            if (value > 0)
            {
                muteButton.Text = UNMUTED_ICON;
                tooltip.SetToolTip(muteButton, "Mute video");
            }
            else
            {
                muteButton.Text = MUTED_ICON;
                tooltip.SetToolTip(muteButton, "Unmute video");
                mute = true;
            }
             
            vlcControl.Audio.Volume = (int)value;
        }

        private void StretchImageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
        }

        private void FitImageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pictureBox.SizeMode = PictureBoxSizeMode.Zoom;
        }

        private void OpenDirectoryButton_Click(object sender, EventArgs e)
        {
            var dirInfo = Utilities.OpenDirectory();

            LoadDirectory(dirInfo);
        }

        private void TagSearchTextBox_TextChanged(object sender, EventArgs e)
        {
            tabControl.SuspendLayout();

            string search = tagSearchTextBox.Text.ToUpper();

            int searchStartLength = Settings.Default.TagSearchStart;
            TabPage page = GetActivePage();
            var controls = page.Controls.OfType<CheckBox>().ToArray();
            bool displayAllTags = Settings.Default.DisplayAllTags;

            /*if (search.Length == 0)
            {
                if (displayAllTags)
                    for (int i = 0; i < page.Controls.Count; i++)
                        controls[i].Show();
                else
                    for (int i = 0; i < page.Controls.Count; i++)
                        if (!controls[i].Checked)
                            controls[i].Hide();

                ReorderTagButtons();
            }
            else if (search.Length >= searchStartLength)
            {
                for (int i = 0; i < page.Controls.Count; i++)
                {
                    if (page.Controls[i].Name.ToUpper().Contains(search))
                        page.Controls[i].Show();
                    else
                        page.Controls[i].Hide();
                }

                ReorderTagButtons();
            }*/

            FilterTagButtons();
            ReorderTagButtons();

            tabControl.ResumeLayout();
        }

        /// <summary>
        /// Set tag buttons to visible or invisible depending on searchbox.
        /// </summary>
        public bool FilterTagButtons()
        {
            string search = tagSearchTextBox.Text.ToUpper();
            TabPage page = GetActivePage();
            var controls = page.Controls.OfType<CheckBox>().ToArray();

            int searchStartLength = Settings.Default.TagSearchStart;
            bool displayAllTags = Settings.Default.DisplayAllTags;

            bool filtered = false;

            if (search.Length == 0)
            {
                if (displayAllTags)
                    for (int i = 0; i < page.Controls.Count; i++)
                        controls[i].Show();
                else
                    for (int i = 0; i < page.Controls.Count; i++)
                        if (controls[i].Checked)
                            controls[i].Show();
                        else
                            controls[i].Hide();

                filtered = true;
            }
            else if (search.Length >= searchStartLength)
            {
                for (int i = 0; i < page.Controls.Count; i++)
                {
                    if (page.Controls[i].Name.ToUpper().Contains(search))
                        page.Controls[i].Show();
                    else
                        page.Controls[i].Hide();
                }

                filtered = true;
            }

            return filtered;
        }

        private void tagSearchTextBox_KeyDown(object sender, KeyEventArgs e)
        {
            TabPage page = GetActivePage();

            if (e.KeyCode == Keys.Enter)
            {
                CheckBox button = page.Controls.OfType<CheckBox>()
                            .Where(t => t.Visible)
                            .OrderByDescending(t => t.Name.ToLower().StartsWith(form.tagSearchTextBox.Text.ToLower()))
                            .ThenBy(t => t.Name)
                            .FirstOrDefault();

                if (button != null)
                {
                    button.Checked = !button.Checked;
                    form.toggleTagButton_MouseUp(button, new MouseEventArgs(MouseButtons.Left, 0, 0, 0, 0));

                    if (Settings.Default.AutoResetTagSearchBox)//Prefs.Get<bool>(Pref.AutoResetTagSearchBox))
                    {
                        tagSearchTextBox.Text = "";
                        form.ReorderTagButtons();
                    }
                }

                e.SuppressKeyPress = true;
            }

            e.Handled = true;
        }

        private void searchButton_Click(object sender, EventArgs e)
        {
            SearchFiles();
        }

        private void SettingsButton_Click(object sender, EventArgs e)
        {
            SettingsForm sf = new SettingsForm(null);
            sf.Show();
        }

        #endregion

        #region Meta Application Interactions - (ApplicationResized, ApplicationExit, etc..)

        private void ApplicationResized(object source, EventArgs e)
        {
            //half of the width of the form TO THE RIGHT of the button's left subtract constant for the button's proper size.
            openFileButton.Width = ((form.Size.Width - openFileButton.Location.X) / 2) - 11;
            openFileInExplorerButton.Width = ((form.Size.Width - openFileButton.Location.X) / 2) - 11;
        }

        #endregion
    }
}
