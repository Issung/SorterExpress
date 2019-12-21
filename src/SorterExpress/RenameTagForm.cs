﻿using System;
using System.IO;
using System.Data;
using System.Linq;
using System.Drawing;
using System.Windows.Forms;
using System.Collections.Generic;
using Vlc.DotNet.Forms;

namespace SorterExpress
{
    public partial class RenameTagForm : Form
    {
        /// <summary>
        /// The directory opened by the user. eg. "C:\Users\Smith\Images\"
        /// </summary>
        string directory;

        /// <summary>
        /// Files found by searching the opened directory, depending on the search scope option this can range
        /// from files in the immediate directory eg. "12561713.jpg" to directories located 
        /// within the opened directory eg. "\GChan\4chan\hr\621342\12561713.jpg".
        /// </summary>
        List<string> files;
        VlcControl vlcControl;
        Dictionary<string, int> tagCounts;
        AutoCompleteStringCollection autoCompleteTags;

        string[] mediaOptions = new string[] { "input-repeat=4000" };

        //System.Windows.Forms.Timer videoPositionScrubTimer;

        public RenameTagForm()
        {
            InitializeComponent();

            ///Stuff that cant be done in the designer
            vlcControl = new VlcControl();
            vlcControl.BeginInit();
            vlcControl.Location = new Point(2, 2);
            vlcControl.Size = new Size(570, 167);
            vlcControl.Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top | AnchorStyles.Bottom;
            vlcControl.VlcLibDirectoryNeeded += Utilities.VlcLibDirectoryNeeded;
            vlcControl.EndInit();
            videoPanel.Controls.Add(vlcControl);
            vlcControl.Audio.Volume = 0;

            splitContainer.MouseDown += splitCont_MouseDown;
            splitContainer.MouseUp += splitCont_MouseUp;
            splitContainer.MouseMove += splitCont_MouseMove;
            ///Stuff that cant be done in the designer

            videoPositionTrackBar.SetVlcControl(vlcControl);

            scopeComboBox.SelectedIndex = 0;
        }

        private void SelectDirectoryButton_Click(object sender, EventArgs e)
        {
            var dirInfo = Utilities.OpenDirectory();

            if (dirInfo != null)
            {
                LoadDirectory(dirInfo);
            }
        }

        private void LoadDirectory(DirectoryInfo dirInfo)
        {
            directory = dirInfo.FullName;
            UpdateFileAndTagLists();

            tagToRenameTextBox.Enabled = true;
            renameToTextBox.Enabled = true;
            listBox.Enabled = true;
        }

        private void RenameButton_Click(object sender, EventArgs e)
        {
            if (!String.IsNullOrWhiteSpace(tagToRenameTextBox.Text) && !String.IsNullOrWhiteSpace(renameToTextBox.Text))
            {
                foreach (Control control in this.Controls)
                {
                    control.Tag = control.Enabled;
                    control.Enabled = false;
                }

                string renameButtonNormalText = renameButton.Text;
                renameButton.Text = "Renaming Files...";

                string tagToRename = tagToRenameTextBox.Text;
                string renameTo = renameToTextBox.Text;

                var filesToRename = files.Where(t => Utilities.ContainsTag(t, tagToRename)).ToArray();

                for (int i = 0; i < filesToRename.Length; i++)
                {
                    string note = Utilities.GetNote(filesToRename[i]);
                    var fileTags = Utilities.GetTags(filesToRename[i]);

                    for (int j = 0; j < fileTags.Length; j++)
                    {
                        if (fileTags[j] == tagToRename)
                        {
                            fileTags[j] = renameTo;
                        }
                    }

                    var newTags = fileTags.GroupBy(t => t).Select(t => t.Key).OrderBy(t => t).ToArray();

                    string newFilename = "";
                    newFilename += string.Join(" ", newTags);
                    if (!String.IsNullOrWhiteSpace(note))
                        newFilename += $" ({note})";

                    Utilities.MoveFile(
                        directory + "\\" + filesToRename[i], 
                        $"{directory}\\{Path.GetDirectoryName(filesToRename[i])}\\{newFilename}{Path.GetExtension(filesToRename[i])}");
                }

                renameButton.Text = renameButtonNormalText;

                foreach (Control control in this.Controls)
                    control.Enabled = (bool)control.Tag;

                MessageBox.Show("Renaming Complete!", "Renaming Complete!", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void TagToRenameTextBox_TextChanged(object sender, EventArgs e)
        {
            int count = 0;

            listBox.Items.Clear();

            if (tagCounts.ContainsKey(tagToRenameTextBox.Text))
            {
                count = tagCounts[tagToRenameTextBox.Text];

                listBox.Items.AddRange(files.Where(t => Utilities.ContainsTag(t, tagToRenameTextBox.Text, StringComparison.OrdinalIgnoreCase)).ToArray());
            }

            tagToRenameLabel.Text = "Tag To Rename... Count: " + count;

            UpdateRenameButtonEnable();
        }

        private void RenameToTextBox_TextChanged(object sender, EventArgs e)
        {
            int count = 0;
            if (tagCounts.ContainsKey(renameToTextBox.Text))
                count = tagCounts[renameToTextBox.Text];

            renameToLabel.Text = "Rename To... Count: " + count;

            UpdateRenameButtonEnable();
        }

        private bool UpdateRenameButtonEnable()
        {
            bool enable = tagToRenameTextBox.Text.Length > 0 && 
                renameToTextBox.Text.Length > 0 &&
                listBox.Items.Count > 0;

            renameButton.Enabled = enable;
            return enable;
        }

        private void ScopeComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            UpdateFileAndTagLists();
        }

        private void UpdateFileAndTagLists()
        {
            if (!String.IsNullOrWhiteSpace(directory))
            {
                if (scopeComboBox.SelectedIndex == 1)
                {
                    /*files = Directory.GetFiles(directory, "*", SearchOption.AllDirectories)
                        .Select(t => t.Replace(directory, ""))
                        .ToList();*/
                    files = Utilities.RecursivelyGetFileNames(directory).Select(t => t.Replace(directory, "")).ToList();
                }
                else // scopeComboBox.SelectedIndex == 0
                {
                    files = Directory.GetFiles(directory)
                        .Select(t => Path.GetFileName(t))
                        .ToList();
                }

                List<string> tags = new List<string>();
                tagCounts = new Dictionary<string, int>(StringComparer.OrdinalIgnoreCase);

                for (int i = 0; i < files.Count; i++)
                {
                    tags.AddRange(Utilities.GetTags(Path.GetFileNameWithoutExtension(files[i])));
                }

                for (int i = 0; i < tags.Count; i++)
                {
                    if (tagCounts.ContainsKey(tags[i]))
                        tagCounts[tags[i]]++;
                    else
                        tagCounts[tags[i]] = 1;
                }

                tags = tags.GroupBy(t => t).Select(t => t.Key).ToList();

                autoCompleteTags = new AutoCompleteStringCollection();
                autoCompleteTags.AddRange(tags.ToArray());

                tagToRenameTextBox.AutoCompleteCustomSource = autoCompleteTags;
                tagToRenameTextBox.AutoCompleteMode = AutoCompleteMode.Suggest;
                tagToRenameTextBox.AutoCompleteSource = AutoCompleteSource.CustomSource;

                renameToTextBox.AutoCompleteCustomSource = autoCompleteTags;
                renameToTextBox.AutoCompleteMode = AutoCompleteMode.Suggest;
                renameToTextBox.AutoCompleteSource = AutoCompleteSource.CustomSource;

                TagToRenameTextBox_TextChanged(null, null);
            }
        }

        private void ListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadFile(directory + "/" + listBox.SelectedItem as string);
        }

        private void LoadFile(string filepath)
        {
            if (Utilities.imageFileExtensions.Contains(Path.GetExtension(filepath)))
            {
                try
                {
                    string location = (filepath.Contains("/") || filepath.Contains("\\") ? filepath : directory + "/" + filepath);

                    using (var fs = new FileStream(location, FileMode.Open))
                    {
                        Image img;
                        var ms = new MemoryStream();
                        fs.CopyTo(ms);
                        ms.Position = 0;
                        if (pictureBox.Image != null)
                            pictureBox.Image.Dispose();
                        img = Image.FromStream(ms);
                        pictureBox.Image = img;

                        videoPanel.Hide();
                        vlcControl.Stop();
                        pictureBox.Show();
                    }
                }
                catch (Exception e)
                {
                    if (pictureBox.Image != null)
                        pictureBox.Image.Dispose();
                }
            }
            else if (Utilities.videoFileExtensions.Contains(Path.GetExtension(filepath)))
            {
                var fi = new FileInfo(filepath);

                vlcControl.SetMedia(fi, mediaOptions);
                vlcControl.Play();

                pictureBox.Hide();
                videoPanel.Show();
            }
            else
            {
                if (pictureBox.Image != null)
                    pictureBox.Image.Dispose();
            }
        }

        private void splitCont_MouseDown(object sender, MouseEventArgs e)
        {
            // This disables the normal move behavior
            ((SplitContainer)sender).IsSplitterFixed = true;
        }

        private void splitCont_MouseMove(object sender, MouseEventArgs e)
        {
            // Check to make sure the splitter won't be updated by the
            // normal move behavior also
            if (((SplitContainer)sender).IsSplitterFixed)
            {
                // Make sure that the button used to move the splitter
                // is the left mouse button
                if (e.Button.Equals(MouseButtons.Left))
                {
                    // Checks to see if the splitter is aligned Vertically
                    if (((SplitContainer)sender).Orientation.Equals(Orientation.Vertical))
                    {
                        // Only move the splitter if the mouse is within
                        // the appropriate bounds
                        if (e.X > 0 && e.X < ((SplitContainer)sender).Width)
                        {
                            // Move the splitter & force a visual refresh
                            ((SplitContainer)sender).SplitterDistance = e.X;
                            ((SplitContainer)sender).Refresh();
                        }
                    }
                    // If it isn't aligned vertically then it must be
                    // horizontal
                    else
                    {
                        // Only move the splitter if the mouse is within
                        // the appropriate bounds
                        if (e.Y > 0 && e.Y < ((SplitContainer)sender).Height)
                        {
                            // Move the splitter & force a visual refresh
                            ((SplitContainer)sender).SplitterDistance = e.Y;
                            ((SplitContainer)sender).Refresh();
                        }
                    }
                }
                // If a button other than left is pressed or no button
                // at all
                else
                {
                    // This allows the splitter to be moved normally again
                    ((SplitContainer)sender).IsSplitterFixed = false;
                }
            }
        }

        private void splitCont_MouseUp(object sender, MouseEventArgs e)
        {
            // This allows the splitter to be moved normally again
            ((SplitContainer)sender).IsSplitterFixed = false;
        }

        private void VideoPlayButton_Click(object sender, EventArgs e)
        {
            if (!vlcControl.IsPlaying)
            {
                if (vlcControl.Position == 1f)
                    vlcControl.Position = 0f;

                vlcControl.Play();
            }
        }

        private void VideoPauseButton_Click(object sender, EventArgs e)
        {
            vlcControl.Pause();
        }

        private void VolumeTrackbar_ValueChanged(object sender, decimal value)
        {
            Console.WriteLine("volumeTrackbar_ValueChanged: " + value);

            if (vlcControl == null)
                return;

            /*if (value > 0)
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

            unmutedVolume = (int)value;*/
            vlcControl.Audio.Volume = (int)value;
        }
    }
}
