using SorterExpress.Classes.SettingsData;
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Runtime.CompilerServices;
using System.Threading;
using System.Windows.Forms;
using Vlc.DotNet.Forms;

namespace SorterExpress.Controls
{
    public partial class MediaViewer : UserControl, INotifyPropertyChanged
    {
        VlcControl vlcControl;

        public string CurrentMedia { get; private set; }

        /// <summary>
        /// Specifies whether buttons such as the media controls (Play, Pause, Trackbars, Etc) should be enabled.
        /// </summary>
        public bool EnableButtons => CurrentMedia != null;

        bool repeat = true;
        private bool mute;
        private int lastVolume;

        const string UNMUTED_ICON = "🔊";
        const string SPEAKER_ICON = "🔈";
        const string MUTED_ICON = "🔇";

        public VlcControl VlcControl { get { return vlcControl; } }
        public PictureBox PictureBox { get { return  pictureBox; } }

        public bool Mute { get { return mute; } }

        /// <summary>
        /// Get the volume level of the vlc player. If mute is true then returns 0.
        /// </summary>
        public int VolumeLevel { 
            get 
            {
                if (Mute)
                    return 0;
                else
                    return 0;// volumeTrackbar.Value; 
            } 
        }

        public float VideoPosition { 
            get 
            {
                if (vlcControl != null)
                    return vlcControl.Position;
                else
                    return -1;
            } 
            set 
            {
                if (vlcControl != null)
                    vlcControl.Position = value;
            } 
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }

        public MediaViewer()
        {
            InitializeComponent();

            if (!DesignMode)
            {
                mediaViewerBindingSource.DataSource = this;
            }
        }

        private void MediaViewer_Load(object sender, EventArgs e)
        {
            if (!DesignMode && Enabled)
            {
                FindVlcLocation();

                videoPositionTrackBar.SetVlcControl(vlcControl);

                mute = Settings.Default.Video.Mute;

                if (mute)
                {
                    lastVolume = volumeTrackbar.Value;
                    volumeTrackbar.Value = 0;
                    muteButton.Text = MUTED_ICON;

                    if (vlcControl != null)
                        vlcControl.Audio.Volume = 0;
                }
                else
                {
                    muteButton.Text = UNMUTED_ICON;
                    if (vlcControl != null)
                    { 
                        vlcControl.Audio.Volume = (int)volumeTrackbar.Value;
                        if (vlcControl.Audio.Volume == 0)
                            muteButton.Text = MUTED_ICON;
                    }
                }
            }
        }

        private void FindVlcLocation()
        {
            DirectoryInfo dirInfo = Utilities.FindVlcLibDirectory();

            if (dirInfo != null)
            {
                vlcControl = new VlcControl();
                vlcControl.BeginInit();
                vlcControl.Margin = new Padding(0, 0, 0, 3);
                vlcControl.Dock = DockStyle.Fill;
                vlcControl.VlcLibDirectory = dirInfo;
                vlcControl.EndInit();
                vlcPlayerTableLayoutPanel.Controls.Add(vlcControl, 0, 0);
                vlcPlayerTableLayoutPanel.SetColumnSpan(vlcControl, 3);
                vlcPlayerTableLayoutPanel.Controls.Add(vlcControl);
            }
        }

        public void LoadMedia(string path)
        {
            Console.WriteLine($"{Name} Loading media {path}!");

            // Don't attempt to load the same media that is already loaded, but put the media back to the start.
            if (path == CurrentMedia)
            {
                if (vlcControl != null)
                    vlcControl.Position = 0f;
                return;
            }

            FileType fileType = Utilities.GetFileType(path);

            if (fileType == FileType.Image)
            {
                errorMessageTextBox.Hide();
                vlcPlayerTableLayoutPanel.Hide();

                try
                {
                    Image img;

                    using (var fs = new FileStream(path, FileMode.Open))
                    {
                        var ms = new MemoryStream();
                        fs.CopyTo(ms);
                        ms.Position = 0;                               // <=== here
                        if (pictureBox.Image != null)
                            pictureBox.Image.Dispose();
                        img = Image.FromStream(ms);
                        pictureBox.Image = img;

                        pictureBox.Show();
                        pictureBox.Enabled = true; 
                    }
                }
                catch (Exception e)
                {
                    ShowErrorMessageBox(e);
                    if (pictureBox.Image != null)
                        pictureBox.Image.Dispose();
                }
            }
            else if (fileType == FileType.Video)
            {
                pictureBox.Hide();
                errorMessageTextBox.Hide();

                try
                {
                    if (vlcControl != null)
                    {
                        FileInfo fi = new FileInfo(path);

                        Invoke(() =>
                        {
                            vlcControl.SetMedia(fi, (repeat) ? "input-repeat=4000" : "input-repeat=0");
                            vlcControl.Play();
                            vlcControl.Audio.Volume = (int)volumeTrackbar.Value;
                        });
                        /*ThreadPool.QueueUserWorkItem(_ => 
                        {
                            vlcControl.SetMedia(fi, (repeat) ? "input-repeat=4000" : "input-repeat=0");
                            vlcControl.Play();
                            vlcControl.Audio.Volume = (int)volumeTrackbar.Value;
                        });*/

                        vlcPlayerTableLayoutPanel.Show();
                    }
                    else
                    {
                        ShowErrorMessageBox("VLC must be located by this program in order to support video playback. This can be configured in the settings.");
                    }
                }
                catch (Exception e)
                {
                    ShowErrorMessageBox(e);
                }
            }
            else
            {
                ShowErrorMessageBox($"File format '{Path.GetExtension(path).ToLower()}' not supported.");
            }

            CurrentMedia = path;
            //Invoke((MethodInvoker)delegate { NotifyPropertyChanged(nameof(EnableButtons)); });
            NotifyPropertyChanged(nameof(EnableButtons));
        }

        public void UnloadMedia(bool forceVideoWait = false)
        {
            if (Enabled)
            {
                Console.WriteLine($"{Name} Unloading Media!");

                if (pictureBox.Image != null)
                    pictureBox.Image.Dispose();

                pictureBox.Image = null;

                CurrentMedia = null;

                if (vlcControl != null)
                {
                    if (forceVideoWait)
                    {
                        vlcControl.Stop();
                        vlcControl.ResetMedia();

                        while (vlcControl.GetCurrentMedia() != null)
                        {
                            //Block while waiting for media to unload.
                        }
                    }
                    else
                    {
                        Invoke(() =>
                        {
                            vlcControl.Stop();
                            vlcControl.ResetMedia();
                        });
                    }
                }

                //Invoke((MethodInvoker)delegate { NotifyPropertyChanged(nameof(EnableButtons)); });
                NotifyPropertyChanged(nameof(EnableButtons));
            }
        }

        private void ShowErrorMessageBox(Exception e)
        {
            pictureBox.Hide();
            vlcPlayerTableLayoutPanel.Hide();

            errorMessageTextBox.Text = $"An error occured attempting to load this file.\n\n";
            errorMessageTextBox.Text += $"Error Type: \n{e.GetType().Name}\n";
            errorMessageTextBox.Text += $"Error Message: \n{e.Message}\n";
            errorMessageTextBox.Text += $"Stack Trace: \n{e.StackTrace}\n\n";
            errorMessageTextBox.Text += $"If you believe the program is at fault please log an issue at " +
                                        $"https://github.com/Issung/SorterExpress with the above information";

            errorMessageTextBox.Show();
        }

        private void ShowErrorMessageBox(params string[] lines)
        {
            pictureBox.Hide();
            vlcPlayerTableLayoutPanel.Hide();

            errorMessageTextBox.Text = "";
            foreach (string line in lines)
                errorMessageTextBox.Text = line + "\n";

            errorMessageTextBox.Show();
        }

        public void Hide(bool unloadMedia)
        {
            if (unloadMedia)
                UnloadMedia();

            Hide();
        }

        #region Events

        private void videoPlayButton_Click(object sender, EventArgs e)
        {
            if (vlcControl != null)
            { 
                if (!vlcControl.IsPlaying)
                {
                    if (vlcControl.Position == 1f)
                        vlcControl.Position = 0f;

                    vlcControl.Play();
                }
            }
        }

        private void videoPauseButton_Click(object sender, EventArgs e)
        {
            if (vlcControl != null)
                if (vlcControl.IsPlaying)
                    vlcControl.Pause();
        }

        private void muteButton_Click(object sender, EventArgs e)
        {
            if (mute) //then unmute
            {
                volumeTrackbar.Value = (lastVolume <= 2) ? 100 : lastVolume;
                muteButton.Text = UNMUTED_ICON;
                tooltip.SetToolTip(muteButton, "Mute video");
                mute = false;
            }
            else //then mute
            {
                lastVolume = volumeTrackbar.Value;
                volumeTrackbar.Value = 0;
                muteButton.Text = MUTED_ICON;
                tooltip.SetToolTip(muteButton, "Unmute video");
                mute = true;
            }
        }

        private void volumeTrackbar_ValueChanged(object sender, EventArgs e)
        {
            if (vlcControl == null)
                return;

            if (volumeTrackbar.Value > 0)
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

            vlcControl.Audio.Volume = volumeTrackbar.Value;
        }

        private void volumeTrackbar_MouseDown(object sender, MouseEventArgs e)
        {
            Console.WriteLine($"volumeTrackbar_MouseDown, lastVolume set to {volumeTrackbar.Value}");
            lastVolume = volumeTrackbar.Value;
        }

        private void stretchImageToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pictureBox.SizeMode = PictureBoxSizeMode.StretchImage;
        }

        private void zoomToolStripMenuItem_Click(object sender, EventArgs e)
        {
            pictureBox.SizeMode = PictureBoxSizeMode.Zoom;
        }

        #endregion

        private void errorMessageTextBox_LinkClicked(object sender, LinkClickedEventArgs e)
        {
            Process.Start(e.LinkText);
        }
    }
}
