using EConTech.Windows.MACUI;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Timers;
using System.Windows.Forms;
using Vlc.DotNet.Forms;

namespace SorterExpress
{
    class FFMPEGProcess : Process
    {
        public Action<string> callback;
        public string input;
        public string output;
    }

    class FFProbeProcess : Process
    {
        public Action<Size> callback;
        public string input;
    }

    public class SubfolderInfo
    {
        public string name;
        public string directory;
        public bool custom;

        public SubfolderInfo()
        {
            name = null;
            directory = null;
            custom = false;
        }

        public SubfolderInfo(string name, string directory, bool custom)
        {
            this.name = name;
            this.directory = directory;
            this.custom = custom;
        }
    }

    class SubfolderButton : Button
    {
        public SubfolderInfo subfolderInfo;

        public SubfolderButton() : base()
        {
            subfolderInfo = new SubfolderInfo();
        }

        public SubfolderButton(string name, string directory, bool custom) : base()
        {
            subfolderInfo = new SubfolderInfo(name, directory, custom);
        }
    }

    public class Duplicate
    {
        public string file1;
        public string file2;

        /// <summary>
        /// 0 to 1 likely hood of match.
        /// </summary>
        public float chance;

        public int differenceCount;

        public Duplicate(FilePrint fp1, FilePrint fp2)
        {
            this.file1 = fp1.file;
            this.file2 = fp2.file;

            differenceCount = 0;

            for (int i = 0; i < fp1.print.Length; i++)
            {
                if (fp1.print[i] != fp2.print[i])
                {
                    differenceCount++;
                }
            }

            chance = 1 - ((float)differenceCount / (float)64);
        }

        public override string ToString()
        {
            return $"Chance: {chance * 100}%";
        }
    }

    public class Move
    {
        public string from;
        public string to;
        public List<string> enabledTags;
        public string note;

        public Move(string from, string to, List<string> tags, string note)
        {
            this.from = from;
            this.to = to;
            this.enabledTags = tags;
            this.note = note;
        }
    }

    public class ScrollPanel : Panel
    {
        //https://www.youtube.com/watch?v=L2hdVYtgKO4

        System.Timers.Timer STimer;
        public VScrollBar FakeScroll;

        public ScrollPanel() : base()
        {
            FakeScroll = new VScrollBar();
            this.Controls.Add(FakeScroll);
            FakeScroll.Dock = DockStyle.Right;
            FakeScroll.Enabled = false;
            FakeScroll.BringToFront();

            this.AutoScroll = true;
            FakeScroll.Visible = !VerticalScroll.Visible;

            STimer = new System.Timers.Timer();
            STimer.Interval = 50;
            STimer.Elapsed += Tick;
            STimer.Start();
        }

        private void Tick(object sender, ElapsedEventArgs e)
        {
            try
            {
                if (Created && !IsDisposed && !FakeScroll.IsDisposed)
                    this.Invoke(new Action(delegate ()
                    {
                        FakeScroll.Visible = !VerticalScroll.Visible;
                    }));
            }
            catch (ObjectDisposedException ode)
            {

            }
        }
    }

    public class VideoPositionTrackBar : MACTrackBar
    {
        private VlcControl vlcControl = null;
        System.Windows.Forms.Timer videoPositionUpdateTimer;

        public VideoPositionTrackBar() : base()
        {
            TickStyle = TickStyle.None;
            Maximum = 100;

            MouseDown += TrackBar_MouseDown;
            Scroll += TrackBar_Scroll;
            MouseUp += TrackBar_MouseUp;

            videoPositionUpdateTimer = new System.Windows.Forms.Timer();
            videoPositionUpdateTimer.Interval = 50; // in miliseconds
            videoPositionUpdateTimer.Tick += VideoPositionUpdate;
            videoPositionUpdateTimer.Start();
        }

        public void SetVlcControl(VlcControl vlcControl)
        {
            this.vlcControl = vlcControl;
        }

        private void VideoPositionUpdate(object sender, EventArgs e)
        {
            if (vlcControl != null)
                if (vlcControl.IsPlaying)
                    Value = (int)(vlcControl.Position * 100);
        }

        private void TrackBar_MouseDown(object sender, MouseEventArgs e)
        {
            if (vlcControl != null)
                vlcControl.Pause();
        }

        private void TrackBar_Scroll(object sender, EventArgs e)
        {
            if (vlcControl != null)
                vlcControl.Position = (Value / 100f);
        }

        private void TrackBar_MouseUp(object sender, MouseEventArgs e)
        {
            if (vlcControl != null)
            {
                vlcControl.Position = (Value / 100f);
                vlcControl.Play();
            }
        }
    }
}