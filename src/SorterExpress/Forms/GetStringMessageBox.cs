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

        public string Prompt { get { return promptLabel.Text; } set { promptLabel.Text = value; } }

        public char[] IllegalCharacters { get; set; } = Utilities.TagForbiddenCharacters;

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

        int ignoreTextChanged = 0;
        private void entryTextBox_TextChanged(object sender, EventArgs e)
        {
            if (ignoreTextChanged > 0)
            {
                ignoreTextChanged--;
                return;
            }

            if (IllegalCharacters != null)
            {
                int oldLength = entryTextBox.Text.Length;
                int oldCursorPosition = entryTextBox.SelectionStart;
                int oldCursorLength = entryTextBox.SelectionLength;
                ignoreTextChanged = 1;
                entryTextBox.Text = Utilities.RemoveCharactersFromString(entryTextBox.Text, IllegalCharacters);
                int newLength = entryTextBox.Text.Length;

                if (newLength < oldLength)
                {
                    entryTextBox.SelectionStart = oldCursorPosition - 1;
                    entryTextBox.SelectionLength = oldCursorLength;
                }
            }
        }
    }
}
