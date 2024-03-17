using System;
using Vlc.DotNet.Forms;

namespace SorterExpress.Forms
{
    partial class DuplicatesForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        
        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DuplicatesForm));
            keepRightButton = new System.Windows.Forms.Button();
            duplicatesFormModelBindingSource = new System.Windows.Forms.BindingSource(components);
            keepLeftButton = new System.Windows.Forms.Button();
            keepBothButton = new System.Windows.Forms.Button();
            openDirectoryButton = new System.Windows.Forms.Button();
            similarityNumeric = new System.Windows.Forms.NumericUpDown();
            similarityLabel = new System.Windows.Forms.Label();
            toolTip = new System.Windows.Forms.ToolTip(components);
            infoRichTextBoxLeft = new System.Windows.Forms.RichTextBox();
            infoRichTextBoxRight = new System.Windows.Forms.RichTextBox();
            searchButton = new System.Windows.Forms.Button();
            imagesCheckBox = new System.Windows.Forms.CheckBox();
            videosCheckBox = new System.Windows.Forms.CheckBox();
            threadCountNumeric = new System.Windows.Forms.NumericUpDown();
            cancelButton = new System.Windows.Forms.Button();
            mergeFileTagsCheckBox = new System.Windows.Forms.CheckBox();
            onlyKeepLibraryTagsCheckBox = new System.Windows.Forms.CheckBox();
            matchFileTypesCheckBox = new System.Windows.Forms.CheckBox();
            fileCountLabel = new System.Windows.Forms.Label();
            cropLeftRightCheckBox = new System.Windows.Forms.CheckBox();
            cropTopBottomCheckBox = new System.Windows.Forms.CheckBox();
            searchScopeComboBox = new System.Windows.Forms.ComboBox();
            matchesDataGridView = new System.Windows.Forms.DataGridView();
            file1ImageColumn = new System.Windows.Forms.DataGridViewImageColumn();
            file2ImageColumn = new System.Windows.Forms.DataGridViewImageColumn();
            similarityColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            matchesContextMenu = new System.Windows.Forms.ContextMenuStrip(components);
            keepLeftToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            removeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            skipToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            deleteBothToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            undoButton = new System.Windows.Forms.Button();
            button1 = new System.Windows.Forms.Button();
            optionsLeftButton = new System.Windows.Forms.Button();
            optionsRightButton = new System.Windows.Forms.Button();
            loadingLabel = new System.Windows.Forms.Label();
            filenameRichTextBoxLeft = new System.Windows.Forms.RichTextBox();
            filenameRichTextBoxRight = new System.Windows.Forms.RichTextBox();
            sidesLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            leftPanel = new System.Windows.Forms.Panel();
            mediaViewerLeft = new Controls.MediaViewer();
            rightPanel = new System.Windows.Forms.Panel();
            mediaViewerRight = new Controls.MediaViewer();
            keepButtonsLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            progressBar = new System.Windows.Forms.ProgressBar();
            threadsLabel = new System.Windows.Forms.Label();
            keepNeitherButton = new System.Windows.Forms.Button();
            percentageLabel = new System.Windows.Forms.Label();
            settingsButton = new System.Windows.Forms.Button();
            massOperationButton = new System.Windows.Forms.Button();
            filtersGroupBox = new System.Windows.Forms.GroupBox();
            optionsContextMenuStrip = new System.Windows.Forms.ContextMenuStrip(components);
            openFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            openFileInExplorerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ignoreFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ignoreFilesDirectoryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)duplicatesFormModelBindingSource).BeginInit();
            ((System.ComponentModel.ISupportInitialize)similarityNumeric).BeginInit();
            ((System.ComponentModel.ISupportInitialize)threadCountNumeric).BeginInit();
            ((System.ComponentModel.ISupportInitialize)matchesDataGridView).BeginInit();
            matchesContextMenu.SuspendLayout();
            sidesLayoutPanel.SuspendLayout();
            leftPanel.SuspendLayout();
            rightPanel.SuspendLayout();
            keepButtonsLayoutPanel.SuspendLayout();
            tableLayoutPanel2.SuspendLayout();
            filtersGroupBox.SuspendLayout();
            optionsContextMenuStrip.SuspendLayout();
            SuspendLayout();
            // 
            // keepRightButton
            // 
            keepRightButton.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            keepRightButton.DataBindings.Add(new System.Windows.Forms.Binding("Enabled", duplicatesFormModelBindingSource, "StateViewingDuplicates", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            keepRightButton.Location = new System.Drawing.Point(402, 0);
            keepRightButton.Margin = new System.Windows.Forms.Padding(2, 0, 0, 0);
            keepRightButton.MaximumSize = new System.Drawing.Size(0, 27);
            keepRightButton.Name = "keepRightButton";
            keepRightButton.Size = new System.Drawing.Size(398, 27);
            keepRightButton.TabIndex = 4;
            keepRightButton.Text = "Keep &Right (Delete Left)";
            keepRightButton.UseVisualStyleBackColor = true;
            keepRightButton.Click += keepRightButton_Click;
            // 
            // duplicatesFormModelBindingSource
            // 
            duplicatesFormModelBindingSource.DataSource = typeof(Models.DuplicatesFormModel);
            // 
            // keepLeftButton
            // 
            keepLeftButton.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            keepLeftButton.DataBindings.Add(new System.Windows.Forms.Binding("Enabled", duplicatesFormModelBindingSource, "StateViewingDuplicates", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            keepLeftButton.Location = new System.Drawing.Point(0, 0);
            keepLeftButton.Margin = new System.Windows.Forms.Padding(0, 0, 2, 0);
            keepLeftButton.MaximumSize = new System.Drawing.Size(0, 27);
            keepLeftButton.Name = "keepLeftButton";
            keepLeftButton.Size = new System.Drawing.Size(398, 27);
            keepLeftButton.TabIndex = 5;
            keepLeftButton.Text = "Keep &Left (Delete Right)";
            keepLeftButton.UseVisualStyleBackColor = true;
            keepLeftButton.Click += keepLeftButton_Click;
            // 
            // keepBothButton
            // 
            keepBothButton.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            keepBothButton.DataBindings.Add(new System.Windows.Forms.Binding("Enabled", duplicatesFormModelBindingSource, "StateViewingDuplicates", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            keepBothButton.Location = new System.Drawing.Point(231, 407);
            keepBothButton.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            keepBothButton.Name = "keepBothButton";
            keepBothButton.Size = new System.Drawing.Size(800, 27);
            keepBothButton.TabIndex = 6;
            keepBothButton.Text = "Keep &Both (Remove Match From List)";
            keepBothButton.UseVisualStyleBackColor = true;
            keepBothButton.Click += keepBothButton_Click;
            // 
            // openDirectoryButton
            // 
            openDirectoryButton.Location = new System.Drawing.Point(14, 43);
            openDirectoryButton.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            openDirectoryButton.Name = "openDirectoryButton";
            openDirectoryButton.Size = new System.Drawing.Size(210, 27);
            openDirectoryButton.TabIndex = 0;
            openDirectoryButton.Text = "Open Directory";
            openDirectoryButton.UseVisualStyleBackColor = true;
            openDirectoryButton.Click += openDirectoryButton_Click;
            // 
            // similarityNumeric
            // 
            similarityNumeric.DataBindings.Add(new System.Windows.Forms.Binding("Value", duplicatesFormModelBindingSource, "Similarity", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            similarityNumeric.DataBindings.Add(new System.Windows.Forms.Binding("Enabled", duplicatesFormModelBindingSource, "StateDirectoryOpenOrSorting", true));
            similarityNumeric.DecimalPlaces = 1;
            similarityNumeric.Enabled = false;
            similarityNumeric.Location = new System.Drawing.Point(63, 179);
            similarityNumeric.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            similarityNumeric.Name = "similarityNumeric";
            similarityNumeric.Size = new System.Drawing.Size(74, 23);
            similarityNumeric.TabIndex = 9;
            similarityNumeric.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            toolTip.SetToolTip(similarityNumeric, "Images searched must have a similarity chance of this or above to be considered a duplicate. \r\n95% or above is reccomended.");
            similarityNumeric.Value = new decimal(new int[] { 95, 0, 0, 0 });
            // 
            // similarityLabel
            // 
            similarityLabel.AutoSize = true;
            similarityLabel.Location = new System.Drawing.Point(2, 182);
            similarityLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            similarityLabel.Name = "similarityLabel";
            similarityLabel.Size = new System.Drawing.Size(62, 15);
            similarityLabel.TabIndex = 10;
            similarityLabel.Text = "Similarity: ";
            // 
            // infoRichTextBoxLeft
            // 
            infoRichTextBoxLeft.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
            infoRichTextBoxLeft.Location = new System.Drawing.Point(0, 0);
            infoRichTextBoxLeft.Margin = new System.Windows.Forms.Padding(12, 12, 12, 12);
            infoRichTextBoxLeft.Name = "infoRichTextBoxLeft";
            infoRichTextBoxLeft.ReadOnly = true;
            infoRichTextBoxLeft.Size = new System.Drawing.Size(116, 241);
            infoRichTextBoxLeft.TabIndex = 3;
            infoRichTextBoxLeft.Text = "";
            toolTip.SetToolTip(infoRichTextBoxLeft, resources.GetString("infoRichTextBoxLeft.ToolTip"));
            // 
            // infoRichTextBoxRight
            // 
            infoRichTextBoxRight.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            infoRichTextBoxRight.Location = new System.Drawing.Point(12, 0);
            infoRichTextBoxRight.Margin = new System.Windows.Forms.Padding(12, 0, 12, 0);
            infoRichTextBoxRight.Name = "infoRichTextBoxRight";
            infoRichTextBoxRight.ReadOnly = true;
            infoRichTextBoxRight.Size = new System.Drawing.Size(116, 241);
            infoRichTextBoxRight.TabIndex = 3;
            infoRichTextBoxRight.Text = "";
            toolTip.SetToolTip(infoRichTextBoxRight, resources.GetString("infoRichTextBoxRight.ToolTip"));
            // 
            // searchButton
            // 
            searchButton.DataBindings.Add(new System.Windows.Forms.Binding("Enabled", duplicatesFormModelBindingSource, "StateDirectoryOpenOrSorting", true));
            searchButton.Location = new System.Drawing.Point(12, 305);
            searchButton.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            searchButton.Name = "searchButton";
            searchButton.Size = new System.Drawing.Size(136, 27);
            searchButton.TabIndex = 18;
            searchButton.Text = "Search";
            toolTip.SetToolTip(searchButton, "If you have changed the similarity threshold and wish to search the same directory you have already selected once again you can click this button to do so.");
            searchButton.UseVisualStyleBackColor = true;
            searchButton.Click += searchButton_Click;
            // 
            // imagesCheckBox
            // 
            imagesCheckBox.AutoSize = true;
            imagesCheckBox.DataBindings.Add(new System.Windows.Forms.Binding("Checked", duplicatesFormModelBindingSource, "SearchImages", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            imagesCheckBox.DataBindings.Add(new System.Windows.Forms.Binding("Enabled", duplicatesFormModelBindingSource, "StateDirectoryOpenOrSorting", true));
            imagesCheckBox.Enabled = false;
            imagesCheckBox.Location = new System.Drawing.Point(7, 54);
            imagesCheckBox.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            imagesCheckBox.Name = "imagesCheckBox";
            imagesCheckBox.Size = new System.Drawing.Size(64, 19);
            imagesCheckBox.TabIndex = 20;
            imagesCheckBox.Text = "Images";
            toolTip.SetToolTip(imagesCheckBox, "Search image files for duplicates.");
            imagesCheckBox.UseVisualStyleBackColor = true;
            imagesCheckBox.CheckStateChanged += imagesCheckBox_CheckedChanged;
            // 
            // videosCheckBox
            // 
            videosCheckBox.AutoSize = true;
            videosCheckBox.DataBindings.Add(new System.Windows.Forms.Binding("Checked", duplicatesFormModelBindingSource, "SearchVideos", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            videosCheckBox.DataBindings.Add(new System.Windows.Forms.Binding("Enabled", duplicatesFormModelBindingSource, "StateDirectoryOpenOrSorting", true));
            videosCheckBox.Enabled = false;
            videosCheckBox.Location = new System.Drawing.Point(82, 54);
            videosCheckBox.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            videosCheckBox.Name = "videosCheckBox";
            videosCheckBox.Size = new System.Drawing.Size(61, 19);
            videosCheckBox.TabIndex = 21;
            videosCheckBox.Text = "Videos";
            toolTip.SetToolTip(videosCheckBox, "Search video files for duplicates.\r\n");
            videosCheckBox.UseVisualStyleBackColor = true;
            videosCheckBox.CheckStateChanged += videosCheckBox_CheckedChanged;
            // 
            // threadCountNumeric
            // 
            threadCountNumeric.DataBindings.Add(new System.Windows.Forms.Binding("Value", duplicatesFormModelBindingSource, "ThreadCount", true));
            threadCountNumeric.DataBindings.Add(new System.Windows.Forms.Binding("Enabled", duplicatesFormModelBindingSource, "StateDirectoryOpenOrSorting", true));
            threadCountNumeric.Enabled = false;
            threadCountNumeric.Location = new System.Drawing.Point(63, 152);
            threadCountNumeric.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            threadCountNumeric.Maximum = new decimal(new int[] { 16, 0, 0, 0 });
            threadCountNumeric.Minimum = new decimal(new int[] { 1, 0, 0, 0 });
            threadCountNumeric.Name = "threadCountNumeric";
            threadCountNumeric.Size = new System.Drawing.Size(74, 23);
            threadCountNumeric.TabIndex = 22;
            threadCountNumeric.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            toolTip.SetToolTip(threadCountNumeric, "Thread count for calculating file 'fingerprints' used for finding similarities, the reccomended amount is your computer's CPU core count. \r\nHigher numbers give diminishing returns. Results may vary.");
            threadCountNumeric.Value = new decimal(new int[] { 1, 0, 0, 0 });
            // 
            // cancelButton
            // 
            cancelButton.DataBindings.Add(new System.Windows.Forms.Binding("Enabled", duplicatesFormModelBindingSource, "StateSearching", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            cancelButton.Enabled = false;
            cancelButton.Location = new System.Drawing.Point(154, 305);
            cancelButton.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            cancelButton.Name = "cancelButton";
            cancelButton.Size = new System.Drawing.Size(71, 27);
            cancelButton.TabIndex = 24;
            cancelButton.Text = "Cancel";
            toolTip.SetToolTip(cancelButton, "If you have changed the similarity threshold and wish to search the same directory you have already selected once again you can click this button to do so.");
            cancelButton.UseVisualStyleBackColor = true;
            cancelButton.Click += cancelButton_Click;
            // 
            // mergeFileTagsCheckBox
            // 
            mergeFileTagsCheckBox.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
            mergeFileTagsCheckBox.AutoSize = true;
            mergeFileTagsCheckBox.DataBindings.Add(new System.Windows.Forms.Binding("Checked", duplicatesFormModelBindingSource, "MergeFileTags", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            mergeFileTagsCheckBox.DataBindings.Add(new System.Windows.Forms.Binding("Enabled", duplicatesFormModelBindingSource, "StateDirectoryOpenOrSorting", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            mergeFileTagsCheckBox.Location = new System.Drawing.Point(230, 354);
            mergeFileTagsCheckBox.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            mergeFileTagsCheckBox.Name = "mergeFileTagsCheckBox";
            mergeFileTagsCheckBox.Size = new System.Drawing.Size(121, 19);
            mergeFileTagsCheckBox.TabIndex = 28;
            mergeFileTagsCheckBox.Text = "Merge File Tags �";
            toolTip.SetToolTip(mergeFileTagsCheckBox, "When selecting a file to keep (left or right), if this option is ticked, then Sorter Express will merge\r\nthe tags of both the filenames together and rename the kept file with the new tags combination.");
            mergeFileTagsCheckBox.UseVisualStyleBackColor = true;
            // 
            // onlyKeepLibraryTagsCheckBox
            // 
            onlyKeepLibraryTagsCheckBox.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
            onlyKeepLibraryTagsCheckBox.AutoSize = true;
            onlyKeepLibraryTagsCheckBox.DataBindings.Add(new System.Windows.Forms.Binding("Checked", duplicatesFormModelBindingSource, "OnlyKeepTagsThatAreInLibrary", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            onlyKeepLibraryTagsCheckBox.DataBindings.Add(new System.Windows.Forms.Binding("Enabled", duplicatesFormModelBindingSource, "EnableOnlyKeepTagsInLibraryButton", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            onlyKeepLibraryTagsCheckBox.Location = new System.Drawing.Point(368, 354);
            onlyKeepLibraryTagsCheckBox.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            onlyKeepLibraryTagsCheckBox.Name = "onlyKeepLibraryTagsCheckBox";
            onlyKeepLibraryTagsCheckBox.Size = new System.Drawing.Size(230, 19);
            onlyKeepLibraryTagsCheckBox.TabIndex = 29;
            onlyKeepLibraryTagsCheckBox.Text = "Only keep tags that are in tag library �";
            toolTip.SetToolTip(onlyKeepLibraryTagsCheckBox, resources.GetString("onlyKeepLibraryTagsCheckBox.ToolTip"));
            onlyKeepLibraryTagsCheckBox.UseVisualStyleBackColor = true;
            // 
            // matchFileTypesCheckBox
            // 
            matchFileTypesCheckBox.AutoSize = true;
            matchFileTypesCheckBox.DataBindings.Add(new System.Windows.Forms.Binding("Checked", duplicatesFormModelBindingSource, "OnlyMatchSameFileTypes", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            matchFileTypesCheckBox.DataBindings.Add(new System.Windows.Forms.Binding("Enabled", duplicatesFormModelBindingSource, "EnableMatchFileTypesCheckBox", true));
            matchFileTypesCheckBox.Location = new System.Drawing.Point(7, 78);
            matchFileTypesCheckBox.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            matchFileTypesCheckBox.Name = "matchFileTypesCheckBox";
            matchFileTypesCheckBox.Size = new System.Drawing.Size(187, 19);
            matchFileTypesCheckBox.TabIndex = 37;
            matchFileTypesCheckBox.Text = "Only Match Files of Same Type";
            toolTip.SetToolTip(matchFileTypesCheckBox, "Only match duplicates if the file types match.\r\nImages will only match images and videos will only match videos.");
            matchFileTypesCheckBox.UseVisualStyleBackColor = true;
            // 
            // fileCountLabel
            // 
            fileCountLabel.AutoSize = true;
            fileCountLabel.DataBindings.Add(new System.Windows.Forms.Binding("Text", duplicatesFormModelBindingSource, "FileAndMatchesCountText", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            fileCountLabel.Location = new System.Drawing.Point(14, 286);
            fileCountLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            fileCountLabel.Name = "fileCountLabel";
            fileCountLabel.Size = new System.Drawing.Size(42, 15);
            fileCountLabel.TabIndex = 25;
            fileCountLabel.Text = "Files: 0";
            toolTip.SetToolTip(fileCountLabel, "The amount of files that will be searched given the given search criteria, and;\r\nthe number of potential duplicate matches that are currently displayed in the grid view below.");
            // 
            // cropLeftRightCheckBox
            // 
            cropLeftRightCheckBox.AutoSize = true;
            cropLeftRightCheckBox.DataBindings.Add(new System.Windows.Forms.Binding("Checked", duplicatesFormModelBindingSource, "CropLeftAndRight", true));
            cropLeftRightCheckBox.DataBindings.Add(new System.Windows.Forms.Binding("Enabled", duplicatesFormModelBindingSource, "StateDirectoryOpenOrSorting", true));
            cropLeftRightCheckBox.Enabled = false;
            cropLeftRightCheckBox.Location = new System.Drawing.Point(7, 104);
            cropLeftRightCheckBox.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            cropLeftRightCheckBox.Name = "cropLeftRightCheckBox";
            cropLeftRightCheckBox.Size = new System.Drawing.Size(119, 19);
            cropLeftRightCheckBox.TabIndex = 31;
            cropLeftRightCheckBox.Text = "Crop Left & Right";
            toolTip.SetToolTip(cropLeftRightCheckBox, "Crop black borders on the left and right of files.");
            cropLeftRightCheckBox.UseMnemonic = false;
            cropLeftRightCheckBox.UseVisualStyleBackColor = true;
            // 
            // cropTopBottomCheckBox
            // 
            cropTopBottomCheckBox.AutoSize = true;
            cropTopBottomCheckBox.DataBindings.Add(new System.Windows.Forms.Binding("Checked", duplicatesFormModelBindingSource, "CropTopAndBottom", true));
            cropTopBottomCheckBox.DataBindings.Add(new System.Windows.Forms.Binding("Enabled", duplicatesFormModelBindingSource, "StateDirectoryOpenOrSorting", true));
            cropTopBottomCheckBox.Enabled = false;
            cropTopBottomCheckBox.Location = new System.Drawing.Point(7, 129);
            cropTopBottomCheckBox.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            cropTopBottomCheckBox.Name = "cropTopBottomCheckBox";
            cropTopBottomCheckBox.Size = new System.Drawing.Size(130, 19);
            cropTopBottomCheckBox.TabIndex = 32;
            cropTopBottomCheckBox.Text = "Crop Top & Bottom";
            toolTip.SetToolTip(cropTopBottomCheckBox, "Crop black borders on the top and bottom of files.");
            cropTopBottomCheckBox.UseMnemonic = false;
            cropTopBottomCheckBox.UseVisualStyleBackColor = true;
            // 
            // searchScopeComboBox
            // 
            searchScopeComboBox.DataBindings.Add(new System.Windows.Forms.Binding("Enabled", duplicatesFormModelBindingSource, "StateDirectoryOpenOrSorting", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            searchScopeComboBox.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", duplicatesFormModelBindingSource, "SearchScopeSelectedValue", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            searchScopeComboBox.DisplayMember = "EnumDescription";
            searchScopeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            searchScopeComboBox.DropDownWidth = 300;
            searchScopeComboBox.Location = new System.Drawing.Point(7, 22);
            searchScopeComboBox.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            searchScopeComboBox.Name = "searchScopeComboBox";
            searchScopeComboBox.Size = new System.Drawing.Size(195, 23);
            searchScopeComboBox.TabIndex = 38;
            toolTip.SetToolTip(searchScopeComboBox, resources.GetString("searchScopeComboBox.ToolTip"));
            searchScopeComboBox.ValueMember = "EnumValue";
            searchScopeComboBox.SelectedValueChanged += searchScopeComboBox_SelectedValueChanged;
            // 
            // matchesDataGridView
            // 
            matchesDataGridView.AllowUserToAddRows = false;
            matchesDataGridView.AllowUserToDeleteRows = false;
            matchesDataGridView.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
            matchesDataGridView.BackgroundColor = System.Drawing.SystemColors.ControlLight;
            matchesDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            matchesDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] { file1ImageColumn, file2ImageColumn, similarityColumn });
            matchesDataGridView.ContextMenuStrip = matchesContextMenu;
            matchesDataGridView.DataBindings.Add(new System.Windows.Forms.Binding("DataSource", duplicatesFormModelBindingSource, "Duplicates", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            matchesDataGridView.Location = new System.Drawing.Point(13, 335);
            matchesDataGridView.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            matchesDataGridView.MultiSelect = false;
            matchesDataGridView.Name = "matchesDataGridView";
            matchesDataGridView.ReadOnly = true;
            matchesDataGridView.RowHeadersVisible = false;
            matchesDataGridView.RowTemplate.Height = 50;
            matchesDataGridView.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            matchesDataGridView.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            matchesDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            matchesDataGridView.Size = new System.Drawing.Size(211, 98);
            matchesDataGridView.TabIndex = 30;
            toolTip.SetToolTip(matchesDataGridView, resources.GetString("matchesDataGridView.ToolTip"));
            matchesDataGridView.CellContextMenuStripNeeded += MatchesDataGridView_CellContextMenuStripNeeded;
            matchesDataGridView.SelectionChanged += matchesDataGridView_SelectionChanged;
            // 
            // file1ImageColumn
            // 
            file1ImageColumn.DataPropertyName = "File1Thumb";
            file1ImageColumn.HeaderText = "File 1";
            file1ImageColumn.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Zoom;
            file1ImageColumn.Name = "file1ImageColumn";
            file1ImageColumn.ReadOnly = true;
            file1ImageColumn.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            file1ImageColumn.Width = 50;
            // 
            // file2ImageColumn
            // 
            file2ImageColumn.DataPropertyName = "File2Thumb";
            file2ImageColumn.HeaderText = "File 2";
            file2ImageColumn.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Zoom;
            file2ImageColumn.Name = "file2ImageColumn";
            file2ImageColumn.ReadOnly = true;
            file2ImageColumn.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            file2ImageColumn.Width = 50;
            // 
            // similarityColumn
            // 
            similarityColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            similarityColumn.DataPropertyName = "ChancePercentageText";
            similarityColumn.HeaderText = "Similarity";
            similarityColumn.Name = "similarityColumn";
            similarityColumn.ReadOnly = true;
            similarityColumn.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // matchesContextMenu
            // 
            matchesContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { keepLeftToolStripMenuItem, removeToolStripMenuItem, skipToolStripMenuItem, deleteBothToolStripMenuItem });
            matchesContextMenu.Name = "matchesContextMenu";
            matchesContextMenu.Size = new System.Drawing.Size(272, 92);
            // 
            // keepLeftToolStripMenuItem
            // 
            keepLeftToolStripMenuItem.Name = "keepLeftToolStripMenuItem";
            keepLeftToolStripMenuItem.Size = new System.Drawing.Size(271, 22);
            keepLeftToolStripMenuItem.Text = "Keep &Left (Delete Right)";
            keepLeftToolStripMenuItem.Click += keepLeftToolStripMenuItem_Click;
            // 
            // removeToolStripMenuItem
            // 
            removeToolStripMenuItem.Name = "removeToolStripMenuItem";
            removeToolStripMenuItem.Size = new System.Drawing.Size(271, 22);
            removeToolStripMenuItem.Text = "Keep &Right (Delete Left)";
            removeToolStripMenuItem.Click += removeToolStripMenuItem_Click;
            // 
            // skipToolStripMenuItem
            // 
            skipToolStripMenuItem.Name = "skipToolStripMenuItem";
            skipToolStripMenuItem.Size = new System.Drawing.Size(271, 22);
            skipToolStripMenuItem.Text = "Keep &Both (Remove Match From List)";
            skipToolStripMenuItem.Click += skipToolStripMenuItem_Click;
            // 
            // deleteBothToolStripMenuItem
            // 
            deleteBothToolStripMenuItem.Name = "deleteBothToolStripMenuItem";
            deleteBothToolStripMenuItem.Size = new System.Drawing.Size(271, 22);
            deleteBothToolStripMenuItem.Text = "Keep &Neither (Delete Both)";
            deleteBothToolStripMenuItem.Click += deleteBothToolStripMenuItem_Click;
            // 
            // undoButton
            // 
            undoButton.DataBindings.Add(new System.Windows.Forms.Binding("Enabled", duplicatesFormModelBindingSource, "EnableUndoButton", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            undoButton.Location = new System.Drawing.Point(91, 14);
            undoButton.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            undoButton.Name = "undoButton";
            undoButton.Size = new System.Drawing.Size(64, 27);
            undoButton.TabIndex = 34;
            undoButton.Text = "Undo";
            toolTip.SetToolTip(undoButton, "Undo last action (CTRL + Z)");
            undoButton.UseVisualStyleBackColor = true;
            undoButton.Click += undoButton_Click;
            // 
            // button1
            // 
            button1.DataBindings.Add(new System.Windows.Forms.Binding("Enabled", duplicatesFormModelBindingSource, "EnableRedoButton", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            button1.Location = new System.Drawing.Point(160, 14);
            button1.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            button1.Name = "button1";
            button1.Size = new System.Drawing.Size(64, 27);
            button1.TabIndex = 35;
            button1.Text = "Redo";
            toolTip.SetToolTip(button1, "Redo last undone action (CTRL + Y)");
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // optionsLeftButton
            // 
            optionsLeftButton.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
            optionsLeftButton.DataBindings.Add(new System.Windows.Forms.Binding("Enabled", duplicatesFormModelBindingSource, "StateViewingDuplicates", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            optionsLeftButton.Image = Properties.Resources.down;
            optionsLeftButton.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            optionsLeftButton.Location = new System.Drawing.Point(0, 245);
            optionsLeftButton.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            optionsLeftButton.Name = "optionsLeftButton";
            optionsLeftButton.Size = new System.Drawing.Size(118, 27);
            optionsLeftButton.TabIndex = 6;
            optionsLeftButton.Text = "Options";
            toolTip.SetToolTip(optionsLeftButton, "Options for viewing file or ignoring in searches.\r\nDuplicate Search file/directory ignores can be configured in settings.");
            optionsLeftButton.UseVisualStyleBackColor = true;
            optionsLeftButton.Click += optionsButton_Click;
            // 
            // optionsRightButton
            // 
            optionsRightButton.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
            optionsRightButton.DataBindings.Add(new System.Windows.Forms.Binding("Enabled", duplicatesFormModelBindingSource, "StateViewingDuplicates", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            optionsRightButton.Image = Properties.Resources.down;
            optionsRightButton.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            optionsRightButton.Location = new System.Drawing.Point(10, 245);
            optionsRightButton.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            optionsRightButton.Name = "optionsRightButton";
            optionsRightButton.Size = new System.Drawing.Size(118, 27);
            optionsRightButton.TabIndex = 5;
            optionsRightButton.Text = "Options";
            toolTip.SetToolTip(optionsRightButton, "Options for viewing file or ignoring in searches.\r\nDuplicate Search file/directory ignores can be configured in settings.");
            optionsRightButton.UseVisualStyleBackColor = true;
            optionsRightButton.Click += optionsButton_Click;
            // 
            // loadingLabel
            // 
            loadingLabel.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
            loadingLabel.AutoSize = true;
            loadingLabel.BackColor = System.Drawing.Color.Transparent;
            loadingLabel.DataBindings.Add(new System.Windows.Forms.Binding("Visible", duplicatesFormModelBindingSource, "StateSearching", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            loadingLabel.Location = new System.Drawing.Point(12, 434);
            loadingLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            loadingLabel.Name = "loadingLabel";
            loadingLabel.Size = new System.Drawing.Size(68, 15);
            loadingLabel.TabIndex = 12;
            loadingLabel.Text = "Searching...";
            // 
            // filenameRichTextBoxLeft
            // 
            filenameRichTextBoxLeft.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            filenameRichTextBoxLeft.Location = new System.Drawing.Point(0, 0);
            filenameRichTextBoxLeft.Margin = new System.Windows.Forms.Padding(0);
            filenameRichTextBoxLeft.Name = "filenameRichTextBoxLeft";
            filenameRichTextBoxLeft.ReadOnly = true;
            filenameRichTextBoxLeft.Size = new System.Drawing.Size(401, 58);
            filenameRichTextBoxLeft.TabIndex = 13;
            filenameRichTextBoxLeft.Text = "";
            // 
            // filenameRichTextBoxRight
            // 
            filenameRichTextBoxRight.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            filenameRichTextBoxRight.Location = new System.Drawing.Point(413, 0);
            filenameRichTextBoxRight.Margin = new System.Windows.Forms.Padding(12, 0, 0, 0);
            filenameRichTextBoxRight.Name = "filenameRichTextBoxRight";
            filenameRichTextBoxRight.ReadOnly = true;
            filenameRichTextBoxRight.Size = new System.Drawing.Size(389, 58);
            filenameRichTextBoxRight.TabIndex = 14;
            filenameRichTextBoxRight.Text = "";
            // 
            // sidesLayoutPanel
            // 
            sidesLayoutPanel.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            sidesLayoutPanel.ColumnCount = 2;
            sidesLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            sidesLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            sidesLayoutPanel.Controls.Add(leftPanel, 0, 0);
            sidesLayoutPanel.Controls.Add(rightPanel, 1, 0);
            sidesLayoutPanel.Location = new System.Drawing.Point(230, 76);
            sidesLayoutPanel.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            sidesLayoutPanel.Name = "sidesLayoutPanel";
            sidesLayoutPanel.RowCount = 1;
            sidesLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            sidesLayoutPanel.Size = new System.Drawing.Size(800, 271);
            sidesLayoutPanel.TabIndex = 15;
            // 
            // leftPanel
            // 
            leftPanel.Controls.Add(optionsLeftButton);
            leftPanel.Controls.Add(mediaViewerLeft);
            leftPanel.Controls.Add(infoRichTextBoxLeft);
            leftPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            leftPanel.Location = new System.Drawing.Point(0, 0);
            leftPanel.Margin = new System.Windows.Forms.Padding(0);
            leftPanel.Name = "leftPanel";
            leftPanel.Size = new System.Drawing.Size(400, 271);
            leftPanel.TabIndex = 5;
            // 
            // mediaViewerLeft
            // 
            mediaViewerLeft.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            mediaViewerLeft.Location = new System.Drawing.Point(117, 0);
            mediaViewerLeft.Margin = new System.Windows.Forms.Padding(5, 3, 5, 3);
            mediaViewerLeft.Name = "mediaViewerLeft";
            mediaViewerLeft.Size = new System.Drawing.Size(284, 271);
            mediaViewerLeft.TabIndex = 4;
            mediaViewerLeft.VideoPosition = -1F;
            // 
            // rightPanel
            // 
            rightPanel.Controls.Add(optionsRightButton);
            rightPanel.Controls.Add(mediaViewerRight);
            rightPanel.Controls.Add(infoRichTextBoxRight);
            rightPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            rightPanel.Location = new System.Drawing.Point(400, 0);
            rightPanel.Margin = new System.Windows.Forms.Padding(0);
            rightPanel.Name = "rightPanel";
            rightPanel.Size = new System.Drawing.Size(400, 271);
            rightPanel.TabIndex = 4;
            // 
            // mediaViewerRight
            // 
            mediaViewerRight.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            mediaViewerRight.Location = new System.Drawing.Point(128, 0);
            mediaViewerRight.Margin = new System.Windows.Forms.Padding(5, 3, 5, 3);
            mediaViewerRight.Name = "mediaViewerRight";
            mediaViewerRight.Size = new System.Drawing.Size(273, 271);
            mediaViewerRight.TabIndex = 4;
            mediaViewerRight.VideoPosition = -1F;
            // 
            // keepButtonsLayoutPanel
            // 
            keepButtonsLayoutPanel.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            keepButtonsLayoutPanel.ColumnCount = 2;
            keepButtonsLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            keepButtonsLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            keepButtonsLayoutPanel.Controls.Add(keepRightButton, 1, 0);
            keepButtonsLayoutPanel.Controls.Add(keepLeftButton, 0, 0);
            keepButtonsLayoutPanel.Location = new System.Drawing.Point(231, 380);
            keepButtonsLayoutPanel.Margin = new System.Windows.Forms.Padding(0);
            keepButtonsLayoutPanel.Name = "keepButtonsLayoutPanel";
            keepButtonsLayoutPanel.RowCount = 1;
            keepButtonsLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            keepButtonsLayoutPanel.Size = new System.Drawing.Size(800, 27);
            keepButtonsLayoutPanel.TabIndex = 16;
            // 
            // tableLayoutPanel2
            // 
            tableLayoutPanel2.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            tableLayoutPanel2.ColumnCount = 2;
            tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            tableLayoutPanel2.Controls.Add(filenameRichTextBoxLeft, 0, 0);
            tableLayoutPanel2.Controls.Add(filenameRichTextBoxRight, 1, 0);
            tableLayoutPanel2.Location = new System.Drawing.Point(230, 14);
            tableLayoutPanel2.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            tableLayoutPanel2.Name = "tableLayoutPanel2";
            tableLayoutPanel2.RowCount = 1;
            tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            tableLayoutPanel2.Size = new System.Drawing.Size(802, 58);
            tableLayoutPanel2.TabIndex = 17;
            // 
            // progressBar
            // 
            progressBar.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
            progressBar.DataBindings.Add(new System.Windows.Forms.Binding("Visible", duplicatesFormModelBindingSource, "StateSearching", true));
            progressBar.Location = new System.Drawing.Point(85, 436);
            progressBar.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            progressBar.Name = "progressBar";
            progressBar.Size = new System.Drawing.Size(139, 24);
            progressBar.TabIndex = 19;
            // 
            // threadsLabel
            // 
            threadsLabel.AutoSize = true;
            threadsLabel.Location = new System.Drawing.Point(2, 155);
            threadsLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            threadsLabel.Name = "threadsLabel";
            threadsLabel.Size = new System.Drawing.Size(54, 15);
            threadsLabel.TabIndex = 23;
            threadsLabel.Text = "Threads: ";
            // 
            // keepNeitherButton
            // 
            keepNeitherButton.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            keepNeitherButton.DataBindings.Add(new System.Windows.Forms.Binding("Enabled", duplicatesFormModelBindingSource, "StateViewingDuplicates", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            keepNeitherButton.Location = new System.Drawing.Point(231, 435);
            keepNeitherButton.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            keepNeitherButton.Name = "keepNeitherButton";
            keepNeitherButton.Size = new System.Drawing.Size(800, 27);
            keepNeitherButton.TabIndex = 27;
            keepNeitherButton.Text = "Keep &Neither (Delete Both)";
            keepNeitherButton.UseVisualStyleBackColor = true;
            keepNeitherButton.Click += keepNeitherButton_Click;
            // 
            // percentageLabel
            // 
            percentageLabel.AutoSize = true;
            percentageLabel.Location = new System.Drawing.Point(138, 182);
            percentageLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            percentageLabel.Name = "percentageLabel";
            percentageLabel.Size = new System.Drawing.Size(66, 15);
            percentageLabel.TabIndex = 11;
            percentageLabel.Text = "% or above";
            // 
            // settingsButton
            // 
            settingsButton.Location = new System.Drawing.Point(14, 14);
            settingsButton.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            settingsButton.Name = "settingsButton";
            settingsButton.Size = new System.Drawing.Size(72, 27);
            settingsButton.TabIndex = 33;
            settingsButton.Text = "Settings";
            settingsButton.UseVisualStyleBackColor = true;
            settingsButton.Click += settingsButton_Click;
            // 
            // massOperationButton
            // 
            massOperationButton.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
            massOperationButton.DataBindings.Add(new System.Windows.Forms.Binding("Enabled", duplicatesFormModelBindingSource, "StateSorting", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            massOperationButton.DataBindings.Add(new System.Windows.Forms.Binding("Visible", duplicatesFormModelBindingSource, "StateNotSearching", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            massOperationButton.Location = new System.Drawing.Point(12, 435);
            massOperationButton.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            massOperationButton.Name = "massOperationButton";
            massOperationButton.Size = new System.Drawing.Size(214, 27);
            massOperationButton.TabIndex = 36;
            massOperationButton.Text = "Mass Operation";
            massOperationButton.UseVisualStyleBackColor = true;
            massOperationButton.Click += massOperationButton_Click;
            // 
            // filtersGroupBox
            // 
            filtersGroupBox.Controls.Add(similarityNumeric);
            filtersGroupBox.Controls.Add(searchScopeComboBox);
            filtersGroupBox.Controls.Add(similarityLabel);
            filtersGroupBox.Controls.Add(threadsLabel);
            filtersGroupBox.Controls.Add(matchFileTypesCheckBox);
            filtersGroupBox.Controls.Add(percentageLabel);
            filtersGroupBox.Controls.Add(imagesCheckBox);
            filtersGroupBox.Controls.Add(videosCheckBox);
            filtersGroupBox.Controls.Add(threadCountNumeric);
            filtersGroupBox.Controls.Add(cropLeftRightCheckBox);
            filtersGroupBox.Controls.Add(cropTopBottomCheckBox);
            filtersGroupBox.Location = new System.Drawing.Point(14, 73);
            filtersGroupBox.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            filtersGroupBox.Name = "filtersGroupBox";
            filtersGroupBox.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            filtersGroupBox.Size = new System.Drawing.Size(210, 210);
            filtersGroupBox.TabIndex = 39;
            filtersGroupBox.TabStop = false;
            filtersGroupBox.Text = "Search Filters";
            // 
            // optionsContextMenuStrip
            // 
            optionsContextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { openFileToolStripMenuItem, openFileInExplorerToolStripMenuItem, ignoreFileToolStripMenuItem, ignoreFilesDirectoryToolStripMenuItem });
            optionsContextMenuStrip.Name = "optionsContextMenuStrip";
            optionsContextMenuStrip.Size = new System.Drawing.Size(189, 92);
            // 
            // openFileToolStripMenuItem
            // 
            openFileToolStripMenuItem.Image = Properties.Resources.file;
            openFileToolStripMenuItem.Name = "openFileToolStripMenuItem";
            openFileToolStripMenuItem.Size = new System.Drawing.Size(188, 22);
            openFileToolStripMenuItem.Text = "Open File";
            openFileToolStripMenuItem.Click += openFileToolStripMenuItem_Click;
            // 
            // openFileInExplorerToolStripMenuItem
            // 
            openFileInExplorerToolStripMenuItem.Image = Properties.Resources.folder;
            openFileInExplorerToolStripMenuItem.Name = "openFileInExplorerToolStripMenuItem";
            openFileInExplorerToolStripMenuItem.Size = new System.Drawing.Size(188, 22);
            openFileInExplorerToolStripMenuItem.Text = "Open File in Explorer";
            openFileInExplorerToolStripMenuItem.Click += openFileInExplorerToolStripMenuItem_Click;
            // 
            // ignoreFileToolStripMenuItem
            // 
            ignoreFileToolStripMenuItem.Image = Properties.Resources.file_grey;
            ignoreFileToolStripMenuItem.Name = "ignoreFileToolStripMenuItem";
            ignoreFileToolStripMenuItem.Size = new System.Drawing.Size(188, 22);
            ignoreFileToolStripMenuItem.Text = "Ignore File";
            ignoreFileToolStripMenuItem.Click += ignoreFileToolStripMenuItem_Click;
            // 
            // ignoreFilesDirectoryToolStripMenuItem
            // 
            ignoreFilesDirectoryToolStripMenuItem.Image = Properties.Resources.folder_grey;
            ignoreFilesDirectoryToolStripMenuItem.Name = "ignoreFilesDirectoryToolStripMenuItem";
            ignoreFilesDirectoryToolStripMenuItem.Size = new System.Drawing.Size(188, 22);
            ignoreFilesDirectoryToolStripMenuItem.Text = "Ignore File's Directory";
            ignoreFilesDirectoryToolStripMenuItem.Click += ignoreFilesDirectoryToolStripMenuItem_Click;
            // 
            // DuplicatesForm
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(1042, 474);
            Controls.Add(button1);
            Controls.Add(undoButton);
            Controls.Add(settingsButton);
            Controls.Add(matchesDataGridView);
            Controls.Add(onlyKeepLibraryTagsCheckBox);
            Controls.Add(mergeFileTagsCheckBox);
            Controls.Add(keepNeitherButton);
            Controls.Add(fileCountLabel);
            Controls.Add(progressBar);
            Controls.Add(loadingLabel);
            Controls.Add(cancelButton);
            Controls.Add(searchButton);
            Controls.Add(keepButtonsLayoutPanel);
            Controls.Add(sidesLayoutPanel);
            Controls.Add(openDirectoryButton);
            Controls.Add(keepBothButton);
            Controls.Add(tableLayoutPanel2);
            Controls.Add(massOperationButton);
            Controls.Add(filtersGroupBox);
            Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
            KeyPreview = true;
            Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            MinimumSize = new System.Drawing.Size(1058, 513);
            Name = "DuplicatesForm";
            Text = "Sorter Express - Duplicate Search";
            FormClosing += DuplicatesForm_FormClosing;
            Shown += DuplicatesForm_Shown;
            KeyDown += DuplicatesForm_KeyDown;
            ((System.ComponentModel.ISupportInitialize)duplicatesFormModelBindingSource).EndInit();
            ((System.ComponentModel.ISupportInitialize)similarityNumeric).EndInit();
            ((System.ComponentModel.ISupportInitialize)threadCountNumeric).EndInit();
            ((System.ComponentModel.ISupportInitialize)matchesDataGridView).EndInit();
            matchesContextMenu.ResumeLayout(false);
            sidesLayoutPanel.ResumeLayout(false);
            leftPanel.ResumeLayout(false);
            rightPanel.ResumeLayout(false);
            keepButtonsLayoutPanel.ResumeLayout(false);
            tableLayoutPanel2.ResumeLayout(false);
            filtersGroupBox.ResumeLayout(false);
            filtersGroupBox.PerformLayout();
            optionsContextMenuStrip.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private System.Windows.Forms.Button keepRightButton;
        private System.Windows.Forms.Button keepLeftButton;
        private System.Windows.Forms.Button keepBothButton;
        private System.Windows.Forms.Button openDirectoryButton;
        private System.Windows.Forms.NumericUpDown similarityNumeric;
        private System.Windows.Forms.Label similarityLabel;
        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.TableLayoutPanel sidesLayoutPanel;
        private System.Windows.Forms.TableLayoutPanel keepButtonsLayoutPanel;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Panel rightPanel;
        private System.Windows.Forms.Panel leftPanel;
        private System.Windows.Forms.Button searchButton;
        private System.Windows.Forms.NumericUpDown threadCountNumeric;
        private System.Windows.Forms.Label threadsLabel;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Label fileCountLabel;
        private System.Windows.Forms.Button keepNeitherButton;
        private System.Windows.Forms.CheckBox mergeFileTagsCheckBox;
        private System.Windows.Forms.CheckBox onlyKeepLibraryTagsCheckBox;
        private System.Windows.Forms.CheckBox cropLeftRightCheckBox;
        private System.Windows.Forms.CheckBox cropTopBottomCheckBox;
        private System.Windows.Forms.Label percentageLabel;
        internal System.Windows.Forms.Label loadingLabel;
        internal System.Windows.Forms.ProgressBar progressBar;
        internal System.Windows.Forms.DataGridView matchesDataGridView;
        internal Controls.MediaViewer mediaViewerLeft;
        internal Controls.MediaViewer mediaViewerRight;
        internal System.Windows.Forms.RichTextBox filenameRichTextBoxLeft;
        internal System.Windows.Forms.RichTextBox filenameRichTextBoxRight;
        internal System.Windows.Forms.RichTextBox infoRichTextBoxRight;
        internal System.Windows.Forms.RichTextBox infoRichTextBoxLeft;
        private System.Windows.Forms.Button settingsButton;
        private System.Windows.Forms.Button undoButton;
        private System.Windows.Forms.Button button1;
        internal System.Windows.Forms.CheckBox imagesCheckBox;
        internal System.Windows.Forms.CheckBox videosCheckBox;
        internal System.Windows.Forms.BindingSource duplicatesFormModelBindingSource;
        private System.Windows.Forms.Button massOperationButton;
        private System.Windows.Forms.ContextMenuStrip matchesContextMenu;
        private System.Windows.Forms.ToolStripMenuItem keepLeftToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem removeToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem skipToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteBothToolStripMenuItem;
        private System.Windows.Forms.CheckBox matchFileTypesCheckBox;
        private System.Windows.Forms.DataGridViewImageColumn file1ImageColumn;
        private System.Windows.Forms.DataGridViewImageColumn file2ImageColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn similarityColumn;
        internal System.Windows.Forms.ComboBox searchScopeComboBox;
        private System.Windows.Forms.GroupBox filtersGroupBox;
        private System.Windows.Forms.Button optionsRightButton;
        private System.Windows.Forms.Button optionsLeftButton;
        private System.Windows.Forms.ContextMenuStrip optionsContextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem ignoreFileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem ignoreFilesDirectoryToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openFileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openFileInExplorerToolStripMenuItem;
    }
}