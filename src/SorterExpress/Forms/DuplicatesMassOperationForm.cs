﻿using GChan.Controls;
using SorterExpress.Classes;
using SorterExpress.Classes.Actions.DuplicateActions;
using SorterExpress.Controllers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.Design;
using System.Windows.Forms.VisualStyles;
using System.Xml.XPath;

namespace SorterExpress.Forms
{
    public partial class DuplicatesMassOperationForm : Form
    {
        const string DEEPEST_DIR = "Deepest in Directories",
            HIGHEST_RES = "Highest Resolution",
            MOST_TAGS = "Most Tags",
            IGNORE = "Ignore";

        public DuplicatesFormController Controller { get; private set; }

        public DuplicatesMassOperationForm(DuplicatesFormController controller)
        {
            InitializeComponent();

            string[] choices = { IGNORE, DEEPEST_DIR, HIGHEST_RES, MOST_TAGS };

            row1ComboBox.DataSource = choices;
            this.Controller = controller;
            this.keepFilePreferenceFlowLayoutPanel.Resize += KeepFilePreferenceFlowLayoutPanel_Resize;

            mergeFileTagsCheckBox.DataBindings.Add("Checked", controller.form.duplicatesFormModelBindingSource, nameof(controller.model.MergeFileTags), true, DataSourceUpdateMode.OnPropertyChanged);
            onlyKeepLibraryTagsCheckBox.DataBindings.Add("Checked", controller.form.duplicatesFormModelBindingSource, nameof(controller.model.OnlyKeepTagsThatAreInLibrary), true, DataSourceUpdateMode.OnPropertyChanged);
            onlyKeepLibraryTagsCheckBox.DataBindings.Add("Enabled", controller.form.duplicatesFormModelBindingSource, nameof(controller.model.EnableOnlyKeepTagsInLibraryButton), true, DataSourceUpdateMode.OnPropertyChanged);
        }

        private void KeepFilePreferenceFlowLayoutPanel_Resize(object sender, EventArgs e)
        {
            const int BIG_WIDTH = 263;
            const int SMALL_WIDTH = BIG_WIDTH - 20;

            if (keepFilePreferenceFlowLayoutPanel.VerticalScroll.Visible)
            {
                foreach (Control row in keepFilePreferenceFlowLayoutPanel.Controls.OfType<TableLayoutPanel>())
                    row.Width = SMALL_WIDTH;
            }
            else
            {
                foreach (Control row in keepFilePreferenceFlowLayoutPanel.Controls.OfType<TableLayoutPanel>())
                    row.Width = BIG_WIDTH;
            }
        }

        private TableLayoutPanel GenerateNewRowControl(int index, string[] options)
        {
            // Row
            TableLayoutPanel row = new TableLayoutPanel();
            row.ColumnCount = 2;
            row.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 25F));
            row.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            row.Location = new Point(3, 3);
            row.Name = $"row{index}";
            row.Tag = index;
            row.RowCount = 1;
            row.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            row.RowStyles.Add(new RowStyle(SizeType.Absolute, 28F));
            row.Size = new Size(263, 28);
            row.TabIndex = 0;

            // Label
            Label rowLabel = new Label();
            rowLabel.AutoSize = true;
            rowLabel.Dock = DockStyle.Fill;
            rowLabel.Location = new Point(3, 0);
            rowLabel.Name = $"row{index}Label";
            rowLabel.Size = new Size(19, 28);
            rowLabel.TabIndex = 0;
            rowLabel.Text = $"{index + 1}.";
            rowLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            row.Controls.Add(rowLabel, 0, 0);

            // ComboBox
            ComboBox rowComboBox = new ComboBox();
            rowComboBox.Dock = DockStyle.Fill;
            rowComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            rowComboBox.FormattingEnabled = true;
            rowComboBox.Location = new Point(28, 3);
            rowComboBox.Name = $"row{index}ComboBox";
            rowComboBox.Size = new Size(232, 21);
            rowComboBox.TabIndex = 1;
            rowComboBox.DataSource = options;
            rowComboBox.SelectionChangeCommitted += new EventHandler(comboBox_SelectedIndexChanged);

            rowComboBox.Enabled = options.Length > 1;   //Enable if there are more options than just 1 (ignore).

            row.Controls.Add(rowComboBox, 1, 0);

            return row;
        }

        private void comboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            ComboBox comboBox = (ComboBox)sender;
            TableLayoutPanel row = (TableLayoutPanel)comboBox.Parent;
            int maxIndex = keepFilePreferenceFlowLayoutPanel.Controls.OfType<TableLayoutPanel>().Max(t => Convert.ToInt32(t.Tag));

            if ((string)comboBox.SelectedItem == IGNORE)
            {
                RemoveLowerRows();
            }
            else if (Convert.ToInt32(row.Tag) < maxIndex)   // If not last combobox and changing to something other than ignore to update comboboxes below.
            {
                RemoveLowerRows();
                AddNewRow();
            }
            else
            {
                AddNewRow();
            }

            //Remove rows below (they have higher indexes).
            void RemoveLowerRows()
            {
                var controls = keepFilePreferenceFlowLayoutPanel.Controls.OfType<TableLayoutPanel>()
                        .Where(t => Convert.ToInt32(t.Tag) > Convert.ToInt32(row.Tag)).ToList();

                for (int i = 0; i < controls.Count; i++)
                    keepFilePreferenceFlowLayoutPanel.Controls.Remove(controls[i]);
            }

            void AddNewRow()
            {
                int newIndex = Convert.ToInt32(row.Tag) + 1;
                List<string> options = ((string[])comboBox.DataSource).ToList();
                options.RemoveAt(comboBox.SelectedIndex);

                TableLayoutPanel newRow = GenerateNewRowControl(newIndex, options.ToArray());

                keepFilePreferenceFlowLayoutPanel.Controls.Add(newRow);
            }
        }

        enum Result { KeepLeft1, KeepRight2, Equal };

        private void performOperationButton_Click(object sender, EventArgs e)
        {
            SortableBindingList<Duplicate> duplicates = Controller.model.Duplicates;

            string[] prefs = keepFilePreferenceFlowLayoutPanel.Controls.OfType<TableLayoutPanel>()
                        .OrderBy(t => Convert.ToInt32(t.Tag))
                        .Select(t => (string)t.Controls.OfType<ComboBox>().First().SelectedItem)
                        .ToArray();

            // Find dimensions for all video files.
            if (prefs.Contains(HIGHEST_RES))
            {
                var prints = Controller.prints.Where(t => duplicates.Any(d => d.fileprint1 == t || d.fileprint2 == t));

                Size noSize = new Size(-1, -1);

                Parallel.ForEach(prints, (print) =>
                {
                    if (print.size == noSize)
                    {
                        print.size = FFWorker.GetSizeWait(print.filepath);
                    }
                });
            }

            // Set to only "Ignore". Alert user and return.
            if (prefs.Length < 2)
            {
                const string MESSAGE_TEXT = "You must set atleast 1 keep file preference filter.";
                MessageBox.Show(MESSAGE_TEXT, "Invalid Parameters", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            for (int i = 0; i < duplicates.Count(); i++)
            {
                Result result = Result.Equal;

                for (int p = 0; p < prefs.Length; p++)
                {
                    if (prefs[p] == IGNORE)
                    {
                        break;
                    }
                    else if (prefs[p] == DEEPEST_DIR)
                    {
                        int comp = GetDirectoryDepth(duplicates[i].File1Path).CompareTo(GetDirectoryDepth(duplicates[i].File2Path));

                        if (comp < 0)
                            result = Result.KeepRight2;
                        else if (comp > 0)
                            result = Result.KeepLeft1;
                    }
                    else if (prefs[p] == HIGHEST_RES)
                    {
                        int file1pixels = duplicates[i].fileprint1.size.Width * duplicates[i].fileprint1.size.Height;
                        int file2pixels = duplicates[i].fileprint2.size.Width * duplicates[i].fileprint2.size.Height;

                        int comp = file1pixels.CompareTo(file2pixels);

                        if (comp < 0)
                            result = Result.KeepRight2;
                        else if (comp > 0)
                            result = Result.KeepLeft1;
                    }
                    else if (prefs[p] == MOST_TAGS)
                    {
                        FileDetails file1Details = Utilities.GetFileDetails(duplicates[i].File1Path);
                        FileDetails file2Details = Utilities.GetFileDetails(duplicates[i].File2Path);

                        int comp = file1Details.Tags.Length.CompareTo(file2Details.Tags.Length);

                        if (comp < 0)
                            result = Result.KeepRight2;
                        else if (comp > 0)
                            result = Result.KeepLeft1;
                    }

                    if (result != Result.Equal)
                        break;
                }

                if (result != Result.Equal)
                {
                    //create appropriate action and add to a list or perform the operation on the spot.
                    DuplicatesFormController.Side side = (result == Result.KeepLeft1) ? DuplicatesFormController.Side.Left : DuplicatesFormController.Side.Right;

                    KeepSide action = new KeepSide(Controller, duplicates[i], i, side);
                    action.Do();
                    Controller.model.UndoneActions.Clear();
                    Controller.model.DoneActions.Push(action);

                    Controller.model.NotifyPropertyChanged(nameof(Controller.model.EnableRedoButton));
                    Controller.model.NotifyPropertyChanged(nameof(Controller.model.EnableUndoButton));

                    //Decrement index because the action just removed the current duplicate from the list.
                    i--;
                }
            }

            int GetDirectoryDepth(string path)
            {
                return path.Count(t => t == Path.DirectorySeparatorChar);
            }
        }
    }
}