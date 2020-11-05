using SorterExpress.Properties;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace SorterExpress.Forms
{
    public partial class AllInOneForm : Form
    {
        public SortFormOld sortForm;
        public MassTagForm massTagForm;
        public ViewForm viewForm;
        public DuplicatesFormOld duplicatesForm;
        public RenameTagForm renameTagForm;
        public SettingsForm settingsForm;

        List<Form> forms;

        public AllInOneForm()
        {
            InitializeComponent();

            sortForm = new SortFormOld(null);
            PrepareForm(sortForm);
            tabControl.TabPages[0].Controls.Add(sortForm);
            sortForm.Show();

            massTagForm = new MassTagForm(null);
            PrepareForm(massTagForm);
            tabControl.TabPages[1].Controls.Add(massTagForm);
            massTagForm.Show();

            viewForm = new ViewForm(null);
            PrepareForm(viewForm);
            tabControl.TabPages[2].Controls.Add(viewForm);
            viewForm.Show();

            duplicatesForm = new DuplicatesFormOld(null);
            PrepareForm(duplicatesForm);
            tabControl.TabPages[3].Controls.Add(duplicatesForm);
            duplicatesForm.Show();

            renameTagForm = new RenameTagForm();
            PrepareForm(renameTagForm);
            tabControl.TabPages[4].Controls.Add(renameTagForm);
            renameTagForm.Show();

            settingsForm = new SettingsForm(seperateWindow: false);
            PrepareForm(settingsForm);
            tabControl.TabPages[5].Controls.Add(settingsForm);
            settingsForm.Show();

            forms = new List<Form>();
            forms.Add(sortForm);
            forms.Add(massTagForm);
            forms.Add(viewForm);
            forms.Add(duplicatesForm);
            forms.Add(renameTagForm);
            forms.Add(settingsForm);

            FormClosing += Application_Exit;

            //tabControl.Selected += TabControl_Selected;
            var newMinSize = (tabControl.SelectedTab.Controls[0] as Form).MinimumSize;
            newMinSize.Width += 25;
            newMinSize.Height += 60;
            MinimumSize = newMinSize;
        }

        private void tabControl_TabIndexChanged(object sender, EventArgs e)
        {
            var newMinSize = (tabControl.TabPages[tabControl.SelectedIndex].Controls[0] as Form).MinimumSize;
            newMinSize.Width += 25;
            newMinSize.Height += 60;
            Console.WriteLine("Current Size: " + Size.ToString());
            Console.WriteLine("New Min Size: " + newMinSize.ToString());
            this.MinimumSize = newMinSize;

            // Doesnt seem to improve anything, neither does Show/Hide. It's probably already done by TabControl itself.
            /*for (int i = 0; i < tabControl.TabPages.Count; i++)
            {
                if (i == tabControl.SelectedIndex)
                    tabControl.TabPages[i].ResumeLayout(true);
                else
                    tabControl.TabPages[i].SuspendLayout();
            }*/
        }

        /*private void TabControl_Selected(object sender, TabControlEventArgs e)
        {
            var newMinSize = (e.TabPage.Controls[0] as Form).MinimumSize;
            newMinSize.Width += 25;
            newMinSize.Height += 60;
            Console.WriteLine("Current Size: " + Size.ToString());
            Console.WriteLine("New Min Size: " + newMinSize.ToString());
            this.MinimumSize = newMinSize;

            // Doesnt seem to improve anything, neither does Show/Hide.
            for (int i = 0; i < tabControl.TabPages.Count; i++)
            {
                if (i == tabControl.SelectedIndex)
                    tabControl.TabPages[i].ResumeLayout(true);
                else
                    tabControl.TabPages[i].SuspendLayout();
            } 
        }*/

        public static void PrepareForm(Form form)
        {
            form.TopLevel = false;
            form.FormBorderStyle = FormBorderStyle.None;
            form.Dock = DockStyle.Fill;
        }

        protected override void OnResizeBegin(EventArgs e)
        {
            if (Settings.Default.FastResizing)
            {
                SuspendLayout();
            }

            base.OnResizeBegin(e);
        }

        protected override void OnResizeEnd(EventArgs e)
        {
            if (Settings.Default.FastResizing)
            {
                ResumeLayout();
            }

            base.OnResizeEnd(e);
        }

        private void Application_Exit(object sender, FormClosingEventArgs e)
        {
            foreach (Form form in forms)
            {
                form.Close();
            }
        }
    }
}
