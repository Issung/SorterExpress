using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace SorterExpress.Forms
{
    public partial class WelcomeForm : Form
    {
        public WelcomeForm()
        {
            InitializeComponent();

            Logs.Log(true, $"{Program.NAME} opened. Is64BitProcess: {Environment.Is64BitProcess}. Is64BitOperatingSystem: {Environment.Is64BitOperatingSystem}.");
        }

        private void sortButton_Click(object sender, EventArgs e)
        {
            StartSortForm();
        }

        private void StartSortForm()
        {
            var di = Utilities.OpenDirectory();

            if (di != null)
            {
                SortForm mainForm = new SortForm(di);
                mainForm.FormClosed += (s, args) => this.Show();
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
                mtf.FormClosed += (s, args) => this.Show();
                mtf.Show();
                this.Hide();
            }
        }

        private void renameTagButton_Click(object sender, EventArgs e)
        {
            var rtf = new RenameTagForm();
            rtf.FormClosed += (s, args) => this.Show();
            rtf.Show();
            this.Hide();
        }

        private void viewFormButton_Click(object sender, EventArgs e)
        {
            var di = Utilities.OpenDirectory();

            if (di != null)
            {
                ViewForm viewForm = new ViewForm(di);
                viewForm.FormClosed += (s, args) => this.Show();
                viewForm.Show();
                this.Hide();
            }
        }

        private void DuplicatesButton_Click(object sender, EventArgs e)
        {
            DuplicatesForm df = new DuplicatesForm(null);
            df.FormClosed += (s, args) => this.Show();
            df.Show();
            this.Hide();
        }

        private void AllInOneButton_Click(object sender, EventArgs e)
        {
            var allinone = new AllInOneForm();
            allinone.FormClosed += (s, args) => this.Show();
            allinone.Show();
            this.Hide();
        }

        private void settingsButton_Click(object sender, EventArgs e)
        {
            SettingsForm settingsForm = new SettingsForm(null);
            settingsForm.ShowDialog();
        }

        private void exitButton_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void updateView_UpdateStarted(object sender, EventArgs e)
        {
            var controls = new Control[] { 
                sortButton, 
                massTagButton, 
                viewFormButton, 
                renameTagButton, 
                duplicatesButton, 
                allInOneButton, 
                settingsButton, 
                exitButton 
            };

            foreach (Control control in controls)
            {
                control.Enabled = false;
            }
        }
    }
}
