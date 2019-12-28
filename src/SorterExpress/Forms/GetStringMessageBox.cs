using System;
using System.Windows.Forms;

namespace SorterExpress.Forms
{
    public partial class GetStringMessageBox : Form
    {
        /// <summary>
        /// Get the user's entry into the textbox.
        /// </summary>
        public string UserEntry => entryTextBox.Text;

        public GetStringMessageBox(string prepopulatedText = "")
        {
            InitializeComponent();

            entryTextBox.Text = prepopulatedText;
            entryTextBox.SelectedText = "";
        }

        private void okButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
        }

        private void entryTextBox_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                okButton.PerformClick();
            }
            else if (e.KeyChar == (char)Keys.Escape)
            {
                cancelButton.PerformClick();
            }
        }

        private void entryTextBox_TextChanged(object sender, EventArgs e)
        {
            char[] disallowedCharacters = "_/\\!@#$%^&*()[]{};':\"?".ToCharArray();

            entryTextBox.Text = Utilities.RemoveCharactersFromString(entryTextBox.Text, disallowedCharacters);
        }
    }
}
