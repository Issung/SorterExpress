using System;
using System.Windows.Forms;

namespace SorterExpress.Forms
{
    public partial class WelcomeForm : Form
    {
        public WelcomeForm()
        {
            InitializeComponent();
        }

        private void sortButton_Click(object sender, EventArgs e)
        {
            var di = Utilities.OpenDirectory();

            if (di != null)
            {
                SortForm mainForm = new SortForm(di);
                mainForm.FormClosed += (s, args) => this.Close();
                mainForm.Show();
                this.Hide();
            }
        }

        private void massTagButton_Click(object sender, EventArgs e)
        {
            var di = Utilities.OpenDirectory();

            if (di != null)
            {
                MassTagForm mtf = new MassTagForm(di);
                mtf.FormClosed += (s, args) => this.Close();
                mtf.Show();
                this.Hide();
            }
        }

        private void renameTagButton_Click(object sender, EventArgs e)
        {
            var rtf = new RenameTagForm();
            rtf.Show();
        }

        private void viewFormButton_Click(object sender, EventArgs e)
        {
            var di = Utilities.OpenDirectory();

            if (di != null)
            {
                ViewForm viewForm = new ViewForm(di);
                viewForm.FormClosed += (s, args) => this.Close();
                viewForm.Show();
            }
        }

        private void DuplicatesButton_Click(object sender, EventArgs e)
        {
            DuplicatesForm df = new DuplicatesForm(null);
            df.Show();
        }

        private void AllInOneButton_Click(object sender, EventArgs e)
        {
            var allinone = new AllInOneForm();
            allinone.Show();
        }

        private void settingsButton_Click(object sender, EventArgs e)
        {
            SettingsForm settingsForm = new SettingsForm(null);
            settingsForm.Show();
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
