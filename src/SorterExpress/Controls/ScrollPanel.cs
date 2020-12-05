using System;
using System.Timers;
using System.Windows.Forms;

namespace SorterExpress.Controls
{
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
                    Invoke(new Action(delegate ()
                    {
                        FakeScroll.Visible = !VerticalScroll.Visible;
                    }));
            }
            catch (ObjectDisposedException ode)
            {

            }
        }
    }
}
