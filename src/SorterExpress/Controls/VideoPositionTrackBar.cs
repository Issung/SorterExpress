using System;
using System.Windows.Forms;
using Vlc.DotNet.Forms;
using EConTech.Windows.MACUI;
using System.Threading;

namespace SorterExpress.Controls
{
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
                {
                    //Value = (int)(vlcControl.Position * 100);
                    ThreadPool.QueueUserWorkItem(_ => { Value = (int)(vlcControl.Position * 100); });
                }
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
