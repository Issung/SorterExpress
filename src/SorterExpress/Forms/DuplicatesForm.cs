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

            controller = new DuplicatesFormController(this, dirInfo);
            duplicatesFormModelBindingSource.DataSource = controller.model;
            //matchesDataGridView.DataSource = controller.model.Duplicates;

            ///Stuff designer can't do
        }

        private void DuplicatesForm_Shown(object sender, EventArgs e)
        {
            mediaViewerLeft.VlcControl.Playing += controller.VlcControl_Playing;
            mediaViewerRight.VlcControl.Playing += controller.VlcControl_Playing;
        }

        /*public List<string> GetSearchScope(List<string> files)
        {
            return files.Where(
                t => (imagesCheckBox.Checked && Utilities.FileIsImage(t)) ||
                (videosCheckBox.Checked && Utilities.FileIsVideo(t)))
                .ToList();
        }*/

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

        private void searchCriteriaCheckBoxCheckChanged(object sender, EventArgs e)
        {
            controller.UpdateSearchFilesScope();
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

        /*private bool CheckDeletingFilesOkay()
        {
            if (deletingOK)
            {
                return true;
            }
            else
            {
                DialogResult result = MessageBox.Show(
                    "This action will delete the other image that you do not want, is that okay?\n"
                  + "The deleted files will be moved to the Recycle Bin, where they can be manually recovered if desired.",
                    "Deletion Warning", 
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Warning
                );

                if (result == DialogResult.Yes)
                {
                    deletingOK = true;
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }*/

    }
}
