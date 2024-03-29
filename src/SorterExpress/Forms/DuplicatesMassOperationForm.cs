﻿using SorterExpress.Classes.Actions.DuplicateActions;
using SorterExpress.Controllers;
using SorterExpress.Model.Duplicates;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SorterExpress.Forms
{
    public partial class DuplicatesMassOperationForm : Form
    {
        public enum Preference
        {
            [Description("Deepest in Directories")]
            DeepestDirectory,
            [Description("Highest Resolution")]
            HighestResolution,
            [Description("Most Tags")]
            MostTags,
            [Description("Random")]
            Random,
            [Description("Ignore")]
            Ignore,
        }

        public DuplicatesFormController Controller { get; private set; }

        private Random random = new Random();

        public DuplicatesMassOperationForm(DuplicatesFormController controller)
        {
            InitializeComponent();

            row1ComboBox.DisplayMember = "EnumDescription";
            row1ComboBox.ValueMember = "EnumValue";
            row1ComboBox.DataSource = Enum.GetValues(typeof(Preference))
                .Cast<Preference>()
                .Select(value => new ComboBoxItem
                {
                    EnumDescription = EnumHelper.GetEnumDescription(value),
                    EnumValue = value
                })
                .ToList();
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

        private TableLayoutPanel GenerateNewRowControl(int index, Preference[] preferences)
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
            rowLabel.TextAlign = ContentAlignment.MiddleCenter;
            row.Controls.Add(rowLabel, 0, 0);

            // ComboBox 
            ComboBox rowComboBox = new ComboBox();
            rowComboBox.Dock = DockStyle.Fill;
            rowComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            rowComboBox.FormattingEnabled = true;
            rowComboBox.Location = new Point(28, 3);
            rowComboBox.Name = $"row{index}ComboBox";
            rowComboBox.Size = new Size(232, 23);
            //rowComboBox.Margin = new Padding(5, 3, 3, 3);
            rowComboBox.TabIndex = 1;
            rowComboBox.SelectionChangeCommitted += new EventHandler(comboBox_SelectionChangeCommitted);

            rowComboBox.DataSource = preferences.Select(value => new ComboBoxItem
            {
                EnumDescription = EnumHelper.GetEnumDescription(value),
                EnumValue = value
            }).ToList();
            rowComboBox.ValueMember = "EnumValue";
            rowComboBox.DisplayMember = "EnumDescription";

            rowComboBox.Enabled = preferences.Length > 1;   //Enable if there are more options than just 1 (ignore). 

            row.Controls.Add(rowComboBox, 1, 0);

            return row;
        }

        private void comboBox_SelectionChangeCommitted(object sender, EventArgs e)
        {
            ComboBox comboBox = (ComboBox)sender;
            TableLayoutPanel row = (TableLayoutPanel)comboBox.Parent;
            int maxIndex = keepFilePreferenceFlowLayoutPanel.Controls.OfType<TableLayoutPanel>().Max(t => Convert.ToInt32(t.Tag));

            if ((Preference)comboBox.SelectedValue == Preference.Ignore)
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
                List<ComboBoxItem> options = new List<ComboBoxItem>((List<ComboBoxItem>)comboBox.DataSource);
                options.RemoveAll(t => t.EnumValue == (Preference)comboBox.SelectedValue);

                TableLayoutPanel newRow = GenerateNewRowControl(newIndex, options.Select(t => t.EnumValue).ToArray());

                keepFilePreferenceFlowLayoutPanel.Controls.Add(newRow);
            }
        }

        enum Result { KeepLeft1, KeepRight2, Equal };

        Preference[] preferences;

        private void performOperationButton_Click(object sender, EventArgs e)
        {
            if (!backgroundWorker.IsBusy)
            {
                // Disable loading selected duplicates because they load after removing each one and unload media.
                if (Controller.form.matchesDataGridView.Rows.Count > 0)
                {
                    Controller.form.matchesDataGridView.Rows[0].Selected = true;
                }
                Controller.form.EnableSelectionChangedEvents = false;
                Controller.LoadFile(Side.Left, null);
                Controller.LoadFile(Side.Right, null);

                this.ControlBox = false;
                performOperationButton.Enabled = false;

                loadingPanel.ProgressBarStyle = ProgressBarStyle.Continuous;
                loadingPanel.ProgressValue = 0;
                loadingPanel.BottomText = "Loading...";
                loadingPanel.Show();

                preferences = keepFilePreferenceFlowLayoutPanel.Controls
                    .OfType<TableLayoutPanel>()
                    .OrderBy(t => Convert.ToInt32(t.Tag))
                    .Select(t => (Preference)t.Controls.OfType<ComboBox>().First().SelectedValue)
                    .ToArray();

                backgroundWorker.RunWorkerAsync();
            }
        }

        private void backgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            Console.WriteLine("backgroundWorker_DoWork");

            var duplicatesCopy = Controller.model.Duplicates.ToArray();

            // Set to only "Ignore". Alert user and return. 
            if (preferences == null || preferences.Length < 2)
            {
                const string MESSAGE_TEXT = "You must set atleast 1 keep file preference filter.";
                MessageBox.Show(MESSAGE_TEXT, "Invalid Parameters", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Find dimensions for all video files. 
            if (preferences.Contains(Preference.HighestResolution))
            {
                Invoke((MethodInvoker)delegate { loadingPanel.BottomText = "Retrieving video dimensions..."; });
                var prints = Controller.prints.Where(t => duplicatesCopy.Any(d => d.fileprint1 == t || d.fileprint2 == t));

                int printsCount = prints.Count();

                var noSize = new Size(-1, -1);
            }

            Invoke((MethodInvoker)delegate { loadingPanel.BottomText = "Performing filtering and removing files..."; });

            var duplicateToIndexDictionary = duplicatesCopy.Select((d, i) => (d, i)).ToDictionary(t => t.d, t => t.i);

            var i = 0;
            Parallel.ForEach(duplicatesCopy,
                (duplicate) =>
                {
                    var result = GetPreferencesResult(duplicate);

                    if (result != Result.Equal)
                    {
                        // Create appropriate action and add to a list or perform the operation on the spot. 
                        var side = (result == Result.KeepLeft1) ? Side.Left : Side.Right;

                        var action = new KeepSide(Controller, duplicate, duplicateToIndexDictionary[duplicate], side);

                        Invoke((MethodInvoker)delegate
                        {
                            action.Do();

                            Controller.model.UndoneActions.Clear();
                            Controller.model.DoneActions.Push(action);

                            Controller.model.NotifyPropertyChanged(nameof(Controller.model.EnableRedoButton));
                            Controller.model.NotifyPropertyChanged(nameof(Controller.model.EnableUndoButton));
                        });
                    }

                    // TODO: This is not working, progress bar just goes empty.
                    // Too many threads being used by the parallel?
                    // Would be good if we could only refresh the UI for each percentage point, so we don't waste cycles on each duplicate removed.
                    backgroundWorker.ReportProgress((int)(((float)i++ / duplicatesCopy.Length) * 100));
                }
            );
        }

        private Result GetPreferencesResult(Duplicate duplicate)
        {
            for (int i = 0; i < preferences.Length; i++)
            {
                var result = GetPreferenceResult(preferences[i], duplicate);

                // If a file has been decided on break this loop going through preferences.
                if (result != Result.Equal)
                { 
                    return result;
                }
            }

            return Result.Equal;
        }

        private Result GetPreferenceResult(Preference preference, Duplicate duplicate)
        {
            if (preference == Preference.Ignore)
            {
                return Result.Equal;
            }
            else if (preference == Preference.DeepestDirectory)
            {
                var file1depth = GetDirectoryDepth(duplicate.File1Path);
                var file2depth = GetDirectoryDepth(duplicate.File2Path);

                if (file1depth > file2depth)
                {
                    return Result.KeepLeft1;
                }
                else if (file1depth < file2depth)
                { 
                    return Result.KeepRight2;
                }
            }
            else if (preference == Preference.HighestResolution)
            {
                int file1pixels = duplicate.fileprint1.Size.Width * duplicate.fileprint1.Size.Height;
                int file2pixels = duplicate.fileprint2.Size.Width * duplicate.fileprint2.Size.Height;

                if (file1pixels > file2pixels)
                { 
                    return Result.KeepLeft1;
                }
                else if (file1pixels < file2pixels)
                { 
                    return Result.KeepRight2;
                }
            }
            else if (preference == Preference.MostTags)
            {
                FileDetails file1Details = Utilities.GetFileDetails(duplicate.File1Path);
                FileDetails file2Details = Utilities.GetFileDetails(duplicate.File2Path);

                if (file1Details.Tags.Length > file2Details.Tags.Length)
                { 
                    return Result.KeepLeft1;
                }
                else if (file1Details.Tags.Length < file2Details.Tags.Length)
                {
                    return Result.KeepRight2;
                }
            }
            else if (preference == Preference.Random)
            {
                return random.Next(0, 2) == 0 ? Result.KeepLeft1 : Result.KeepRight2;
            }

            return Result.Equal;
        }

        private int GetDirectoryDepth(string path)
        {
            return path.Count(t => t == Path.DirectorySeparatorChar);
        }

        private void backgroundWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            Console.WriteLine($"backgroundWorker_ProgressChanged. progress: {e.ProgressPercentage}");
            loadingPanel.ProgressValue = e.ProgressPercentage;
        }

        private void backgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            Console.WriteLine($"backgroundWorker_RunWorkerCompleted");
            loadingPanel.Hide();
            performOperationButton.Enabled = true;
            this.ControlBox = true;

            // Re-enable loading selected duplicates.
            Controller.form.EnableSelectionChangedEvents = true;
        }

        private void keepFilePreferenceFlowLayoutPanel_Paint(object sender, PaintEventArgs e)
        {

        }
    }

    class ComboBoxItem
    {
        public string EnumDescription { get; set; }
        public DuplicatesMassOperationForm.Preference EnumValue { get; set; }
    }
}