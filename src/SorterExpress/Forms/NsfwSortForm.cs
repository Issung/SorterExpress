using Google.Protobuf.Reflection;
using SorterExpress.Controllers;
using SorterExpress.Models;
using System;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Windows.Forms;

#nullable enable

namespace SorterExpress.Forms
{
    public partial class NsfwSortForm : Form
    {
        /// <summary>
        /// Disables forwarding of selection events from form to <see cref="DuplicatesFormController.MatchSelectionChanged"/>.
        /// </summary>
        public bool EnableSelectionChangedEvents = true;

        public int? SelectedRowIndex => resultsDataGridView?.CurrentCell?.RowIndex;

        private readonly NsfwSortController controller;

        public NsfwSortForm(DirectoryInfo dirInfo)
        {
            InitializeComponent();
            DesignerSetup();

            controller = new NsfwSortController(this, dirInfo);
        }

        private void DesignerSetup()
        {
            resultsDataGridView.AutoGenerateColumns = false;

            // Add items to search scope combo box. DisplayMember and ValueMember are used with this anonymous class.
            searchScopeComboBox.DataSource = Enum.GetValues<SearchScope>()
                .Select(value => new
                {
                    EnumDescription = EnumHelper.GetEnumDescription(value),
                    EnumValue = value
                })
                .ToList();

            resultsFilterComboBox.DataSource = Enum
                .GetValues<Classification>()
                .Select(v => new
                {
                    EnumDescription = v.ToString(),
                    EnumValue = v,
                })
                .ToList();
        }

        private void NsfwSortForm_Load(object sender, EventArgs e)
        {
            Debug.WriteLine($"NsfwSortForm_Load");
            bindingSource.DataSource = controller.model;
        }

        private void openDirectoryButton_Click(object sender, EventArgs e)
        {
            controller.OpenDirectoryDialog();
        }

        private void searchButton_Click(object sender, EventArgs e)
        {
            controller.BeginSearch();
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            controller.CancelSearch();
        }

        private void Form_FormClosing(object sender, FormClosingEventArgs e)
        {
            controller.Closing();
        }

        private void matchesDataGridView_SelectionChanged(object sender, EventArgs e)
        {
            if (EnableSelectionChangedEvents)
            {
                controller.SelectionChanged();
            }
        }

        private void imagesCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            controller.UpdateSearchFilesScope();
        }

        private void videosCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            controller.UpdateSearchFilesScope();
        }

        private void settingsButton_Click(object sender, EventArgs e)
        {
            controller.OpenSettings();
        }

        private void searchScopeComboBox_SelectedValueChanged(object sender, EventArgs e)
        {
            searchScopeComboBox.DataBindings["SelectedValue"].WriteValue();
            controller?.UpdateSearchFilesScope();
        }

        private void Form_KeyDown(object sender, KeyEventArgs e)
        {
            controller.HandleShortcut(e);
        }

        private void optionsButton_Click(object sender, EventArgs e)
        {
            var control = (Control)sender;
            optionsContextMenuStrip.Show(control, 0, control.Height);
        }

        private void openFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Utilities.OsOpen(controller.InspectingResult.Path);
        }

        private void openFileInExplorerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Utilities.ViewFileInExplorer(controller.InspectingResult.Path);
        }

        private void overrideButton_CheckedChanged(object? sender, EventArgs e)
        {
            if (sender == null)
            {
                return;
            }

            var button = (RadioButton)sender;

            if (button.Checked)
            {
                controller.OverrideChecked(Enum.Parse<Classification>(button.Text.Replace("&", string.Empty)));
            }
        }

        private void moveButton_Click(object sender, EventArgs e)
        {
            var button = (Button)sender;

            var classificiationStr = Regex.Match(button.Text, "(?<=').*(?=')").Groups[0].Value;
            var classification = Enum.Parse<Classification>(classificiationStr);

            controller.MoveAll(classification);
        }

        private void resultsFilterComboBox_SelectedValueChanged(object sender, EventArgs e)
        {
            resultsFilterComboBox.DataBindings["SelectedValue"].WriteValue();
            controller?.UpdateResultsFilter();
        }
    }
}
