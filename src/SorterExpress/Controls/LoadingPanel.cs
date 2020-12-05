using System;
using System.ComponentModel;
using System.Drawing;
using System.Runtime.CompilerServices;
using System.Windows.Forms;

namespace SorterExpress.Controls
{
    public partial class LoadingPanel : UserControl, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public void NotifyPropertyChanged([CallerMemberName] string propertyName = "")
        {
            //Console.WriteLine($"NotifyPropertyChanged! propertyName: {propertyName}");
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            Update();
        }

        private string topText;
        private string bottomText = "";
        private ProgressBarStyle progressBarStyle;
        private int progressValue = 0;

        public string TopText { get { return topText; } set { topText = value; NotifyPropertyChanged(); } }

        public string BottomText { get { return bottomText; } set { bottomText = value; NotifyPropertyChanged(); } }

        public ProgressBarStyle ProgressBarStyle { get { return progressBarStyle; } set { progressBarStyle = value; NotifyPropertyChanged(); } }

        public int ProgressValue { get { return progressValue; } set { progressValue = value; NotifyPropertyChanged(); } }

        [Browsable(true)]
        public bool HideInDesigner { get; set; }

        public LoadingPanel()
        {
            InitializeComponent();
            this.loadingPanelBindingSource.DataSource = this;
            this.Anchor = (((AnchorStyles.Top | AnchorStyles.Bottom) | AnchorStyles.Left) | AnchorStyles.Right);
        }

        private void LoadingPanel_ParentChanged(object sender, EventArgs e)
        {
            ((Form)Parent).Shown += LoadingPanel_Shown;
        }

        private void LoadingPanel_Shown(object sender, EventArgs e)
        {
            Parent.Resize += LoadingPanel_Resize;
        }

        private void LoadingPanel_Resize(object sender, EventArgs e)
        {
            Console.WriteLine($"LoadingPanel_Resize");

            if (DesignMode)
            {
                Visible = !HideInDesigner;
            }
            else
            {
                Location = new Point(
                    (Parent.Width / 2) - (this.Size.Width / 2),
                    (Parent.Height / 2) - (this.Size.Height / 2)
                );
            }
        }
    }
}
