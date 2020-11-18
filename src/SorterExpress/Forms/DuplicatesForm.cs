using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using GChan.Controls;
using Microsoft.VisualBasic.FileIO;
using SorterExpress.Controllers;
using SorterExpress.Controls;
using SorterExpress.Properties;

namespace SorterExpress.Forms
{
    public partial class DuplicatesForm : Form
    {
        DuplicatesFormController controller;

        //public bool MergeFileTags { get { return mergeFileTagsCheckBox.Checked; } }
        //public bool OnlyKeepLibraryTags { get { return onlyKeepLibraryTagsCheckBox.Checked; } }

        public int MatchesGridViewSelectedRow { get { return matchesDataGridView?.CurrentCell?.RowIndex ?? -1; } }

        public DuplicatesForm(DirectoryInfo dirInfo)
        {
            InitializeComponent();

            ///Stuff designer can't do
            
            matchesDataGridView.AutoGenerateColumns = false;
            //matchesDataGridView.DataSource = duplicates; //TODO: Bind in designer.
            //duplicates.ListChanged += Duplicates_ListChanged;

            // Add items to search scope combo box. DisplayMember and ValueMember are used with this anonymous class.
            searchScopeComboBox.DataSource = Enum.GetValues(typeof(DuplicatesFormModel.SearchScope))
                .Cast<DuplicatesFormModel.SearchScope>()
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
            controller.MatchSelectionChanged();
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
            controller.KeepSide(DuplicatesFormController.Side.Left);
        }

        private void keepRightButton_Click(object sender, EventArgs e)
        {
            controller.KeepSide(DuplicatesFormController.Side.Right);
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
            controller.KeepSide(DuplicatesFormController.Side.Left, contextMenuRowIndex);
        }

        private void removeToolStripMenuItem_Click(object sender, EventArgs e)
        {
            controller.KeepSide(DuplicatesFormController.Side.Right, contextMenuRowIndex);
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
    }
}
