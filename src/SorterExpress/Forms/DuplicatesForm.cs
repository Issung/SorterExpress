using SorterExpress.Controllers;
using SorterExpress.Model.Duplicates;
using SorterExpress.Models;
using System;
using System.Data;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace SorterExpress.Forms
{
    public partial class DuplicatesForm : Form
    {
        /// <summary>
        /// Disables forwarding of selection events from form to <see cref="DuplicatesFormController.MatchSelectionChanged"/>.
        /// </summary>
        public bool EnableSelectionChangedEvents = true;

        DuplicatesFormController controller;

        public int MatchesGridViewSelectedRow { get { return matchesDataGridView?.CurrentCell?.RowIndex ?? -1; } }

        Side? lastOptionsSideClicked;

        public DuplicatesForm(DirectoryInfo dirInfo)
        {
            InitializeComponent();

            ///Stuff designer can't do

            matchesDataGridView.AutoGenerateColumns = false;
            //matchesDataGridView.DataSource = duplicates; //TODO: Bind in designer.
            //duplicates.ListChanged += Duplicates_ListChanged;

            // Add items to search scope combo box. DisplayMember and ValueMember are used with this anonymous class.
            searchScopeComboBox.DataSource = Enum.GetValues<SearchScope>()
                .Select(value => new
                {
                    EnumDescription = EnumHelper.GetEnumDescription(value),
                    EnumValue = value
                })
                .ToList();

            controller = new DuplicatesFormController(this, dirInfo);
            //matchesDataGridView.DataSource = controller.model.Duplicates;

            ///Stuff designer can't do
        }

        private void DuplicatesForm_Shown(object sender, EventArgs e)
        {
            Console.WriteLine($"DuplicatesForm_Shown");

            duplicatesFormModelBindingSource.DataSource = controller.model;

            mediaViewerLeft.VlcControl.Playing += controller.VlcControl_Playing;
            mediaViewerRight.VlcControl.Playing += controller.VlcControl_Playing;
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

        private void DuplicatesForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            controller.Closing();
        }

        private void matchesDataGridView_SelectionChanged(object sender, EventArgs e)
        {
            if (EnableSelectionChangedEvents)
            {
                controller.MatchSelectionChanged();
            }
        }

        private void undoButton_Click(object sender, EventArgs e)
        {
            controller.Undo();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            controller.Redo();
        }

        private void keepNeitherButton_Click(object sender, EventArgs e)
        {
            controller.KeepNeither();
        }

        private void keepBothButton_Click(object sender, EventArgs e)
        {
            controller.Skip();
        }

        private void keepLeftButton_Click(object sender, EventArgs e)
        {
            controller.KeepSide(Side.Left);
        }

        private void keepRightButton_Click(object sender, EventArgs e)
        {
            controller.KeepSide(Side.Right);
        }

        private void imagesCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            controller.UpdateSearchFilesScope();
        }

        private void videosCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            controller.UpdateSearchFilesScope();
        }

        private void massOperationButton_Click(object sender, EventArgs e)
        {
            controller.OpenMassOperationForm();
        }

        private void settingsButton_Click(object sender, EventArgs e)
        {
            controller.OpenSettings();
        }

        int contextMenuRowIndex = -1;

        private void MatchesDataGridView_CellContextMenuStripNeeded(object sender, DataGridViewCellContextMenuStripNeededEventArgs e)
        {
            contextMenuRowIndex = e.RowIndex;
        }

        private void keepLeftToolStripMenuItem_Click(object sender, EventArgs e)
        {
            controller.KeepSide(Side.Left, contextMenuRowIndex);
        }

        private void removeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            controller.KeepSide(Side.Right, contextMenuRowIndex);
        }

        private void skipToolStripMenuItem_Click(object sender, EventArgs e)
        {
            controller.Skip(contextMenuRowIndex);
        }

        private void deleteBothToolStripMenuItem_Click(object sender, EventArgs e)
        {
            controller.KeepNeither(contextMenuRowIndex);
        }

        private void searchScopeComboBox_SelectedValueChanged(object sender, EventArgs e)
        {
            searchScopeComboBox.DataBindings["SelectedValue"].WriteValue();

            if (controller != null)
                controller.UpdateSearchFilesScope();
        }

        private void DuplicatesForm_KeyDown(object sender, KeyEventArgs e)
        {
            controller.HandleShortcut(e);
        }

        Side? GetSide(object button)
        {
            if (button == optionsLeftButton)
            {
                return Side.Left;
            }
            else if (button == optionsRightButton)
            {
                return Side.Right;
            }
            else
            {
                return null;
            }
        }

        // TODO: Nullable (and all connections).
        string GetSideFilepath(Side? side)
        {
            if (side == Side.Left)
            {
                return controller.inspectingDuplicate.File1Path;
            }
            else if (side == Side.Right)
            {
                return controller.inspectingDuplicate.File2Path;
            }
            else
            {
                return null;
            }
        }

        private void optionsButton_Click(object sender, EventArgs e)
        {
            lastOptionsSideClicked = GetSide(sender);
            var control = (Control)sender;
            optionsContextMenuStrip.Show(control, 0, control.Height);
        }

        private void openFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Utilities.OsOpen(GetSideFilepath(lastOptionsSideClicked));
        }

        private void openFileInExplorerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Utilities.ViewFileInExplorer(GetSideFilepath(lastOptionsSideClicked));
        }

        private void ignoreFileToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (lastOptionsSideClicked != null)
            {
                controller.IgnoreFileOrDirectory(null, IgnoreType.File, lastOptionsSideClicked.Value);
            }
        }

        private void ignoreFilesDirectoryToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (lastOptionsSideClicked != null)
            {
                controller.IgnoreFileOrDirectory(null, IgnoreType.Directory, lastOptionsSideClicked.Value);
            }
        }
    }
}
