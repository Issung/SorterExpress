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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DuplicatesForm));
            this.keepRightButton = new System.Windows.Forms.Button();
            this.duplicatesFormModelBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.keepLeftButton = new System.Windows.Forms.Button();
            this.keepBothButton = new System.Windows.Forms.Button();
            this.openDirectoryButton = new System.Windows.Forms.Button();
            this.similarityNumeric = new System.Windows.Forms.NumericUpDown();
            this.similarityLabel = new System.Windows.Forms.Label();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.infoRichTextBoxLeft = new System.Windows.Forms.RichTextBox();
            this.infoRichTextBoxRight = new System.Windows.Forms.RichTextBox();
            this.searchButton = new System.Windows.Forms.Button();
            this.imagesCheckBox = new System.Windows.Forms.CheckBox();
            this.videosCheckBox = new System.Windows.Forms.CheckBox();
            this.threadCountNumeric = new System.Windows.Forms.NumericUpDown();
            this.cancelButton = new System.Windows.Forms.Button();
            this.mergeFileTagsCheckBox = new System.Windows.Forms.CheckBox();
            this.onlyKeepLibraryTagsCheckBox = new System.Windows.Forms.CheckBox();
            this.matchFileTypesCheckBox = new System.Windows.Forms.CheckBox();
            this.fileCountLabel = new System.Windows.Forms.Label();
            this.cropLeftRightCheckBox = new System.Windows.Forms.CheckBox();
            this.cropTopBottomCheckBox = new System.Windows.Forms.CheckBox();
            this.searchScopeComboBox = new System.Windows.Forms.ComboBox();
            this.matchesDataGridView = new System.Windows.Forms.DataGridView();
            this.file1ImageColumn = new System.Windows.Forms.DataGridViewImageColumn();
            this.file2ImageColumn = new System.Windows.Forms.DataGridViewImageColumn();
            this.similarityColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.matchesContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.keepLeftToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.removeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.skipToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteBothToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.undoButton = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.loadingLabel = new System.Windows.Forms.Label();
            this.filenameRichTextBoxLeft = new System.Windows.Forms.RichTextBox();
            this.filenameRichTextBoxRight = new System.Windows.Forms.RichTextBox();
            this.sidesLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.leftPanel = new System.Windows.Forms.Panel();
            this.mediaViewerLeft = new SorterExpress.Controls.MediaViewer();
            this.rightPanel = new System.Windows.Forms.Panel();
            this.mediaViewerRight = new SorterExpress.Controls.MediaViewer();
            this.keepButtonsLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.threadsLabel = new System.Windows.Forms.Label();
            this.keepNeitherButton = new System.Windows.Forms.Button();
            this.percentageLabel = new System.Windows.Forms.Label();
            this.settingsButton = new System.Windows.Forms.Button();
            this.massOperationButton = new System.Windows.Forms.Button();
            this.filtersGroupBox = new System.Windows.Forms.GroupBox();
            ((System.ComponentModel.ISupportInitialize)(this.duplicatesFormModelBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.similarityNumeric)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.threadCountNumeric)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.matchesDataGridView)).BeginInit();
            this.matchesContextMenu.SuspendLayout();
            this.sidesLayoutPanel.SuspendLayout();
            this.leftPanel.SuspendLayout();
            this.rightPanel.SuspendLayout();
            this.keepButtonsLayoutPanel.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.filtersGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // keepRightButton
            // 
            this.keepRightButton.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.keepRightButton.DataBindings.Add(new System.Windows.Forms.Binding("Enabled", this.duplicatesFormModelBindingSource, "StateSorting", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.keepRightButton.Location = new System.Drawing.Point(345, 0);
            this.keepRightButton.Margin = new System.Windows.Forms.Padding(2, 0, 0, 0);
            this.keepRightButton.MaximumSize = new System.Drawing.Size(0, 23);
            this.keepRightButton.Name = "keepRightButton";
            this.keepRightButton.Size = new System.Drawing.Size(341, 23);
            this.keepRightButton.TabIndex = 4;
            this.keepRightButton.Text = "Keep &Right (Delete Left)";
            this.keepRightButton.UseVisualStyleBackColor = true;
            this.keepRightButton.Click += new System.EventHandler(this.keepRightButton_Click);
            // 
            // duplicatesFormModelBindingSource
            // 
            this.duplicatesFormModelBindingSource.DataSource = typeof(SorterExpress.Models.DuplicatesFormModel);
            // 
            // keepLeftButton
            // 
            this.keepLeftButton.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.keepLeftButton.DataBindings.Add(new System.Windows.Forms.Binding("Enabled", this.duplicatesFormModelBindingSource, "StateSorting", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.keepLeftButton.Location = new System.Drawing.Point(0, 0);
            this.keepLeftButton.Margin = new System.Windows.Forms.Padding(0, 0, 2, 0);
            this.keepLeftButton.MaximumSize = new System.Drawing.Size(0, 23);
            this.keepLeftButton.Name = "keepLeftButton";
            this.keepLeftButton.Size = new System.Drawing.Size(341, 23);
            this.keepLeftButton.TabIndex = 5;
            this.keepLeftButton.Text = "Keep &Left (Delete Right)";
            this.keepLeftButton.UseVisualStyleBackColor = true;
            this.keepLeftButton.Click += new System.EventHandler(this.keepLeftButton_Click);
            // 
            // keepBothButton
            // 
            this.keepBothButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.keepBothButton.DataBindings.Add(new System.Windows.Forms.Binding("Enabled", this.duplicatesFormModelBindingSource, "StateSorting", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.keepBothButton.Location = new System.Drawing.Point(198, 353);
            this.keepBothButton.Name = "keepBothButton";
            this.keepBothButton.Size = new System.Drawing.Size(686, 23);
            this.keepBothButton.TabIndex = 6;
            this.keepBothButton.Text = "Keep &Both (Remove Match From List)";
            this.keepBothButton.UseVisualStyleBackColor = true;
            this.keepBothButton.Click += new System.EventHandler(this.keepBothButton_Click);
            // 
            // openDirectoryButton
            // 
            this.openDirectoryButton.Location = new System.Drawing.Point(12, 37);
            this.openDirectoryButton.Name = "openDirectoryButton";
            this.openDirectoryButton.Size = new System.Drawing.Size(180, 23);
            this.openDirectoryButton.TabIndex = 0;
            this.openDirectoryButton.Text = "Open Directory";
            this.openDirectoryButton.UseVisualStyleBackColor = true;
            this.openDirectoryButton.Click += new System.EventHandler(this.openDirectoryButton_Click);
            // 
            // similarityNumeric
            // 
            this.similarityNumeric.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.duplicatesFormModelBindingSource, "Similarity", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.similarityNumeric.DataBindings.Add(new System.Windows.Forms.Binding("Enabled", this.duplicatesFormModelBindingSource, "StateDirectoryOpenOrSorting", true));
            this.similarityNumeric.DecimalPlaces = 1;
            this.similarityNumeric.Enabled = false;
            this.similarityNumeric.Location = new System.Drawing.Point(54, 155);
            this.similarityNumeric.Name = "similarityNumeric";
            this.similarityNumeric.Size = new System.Drawing.Size(63, 20);
            this.similarityNumeric.TabIndex = 9;
            this.similarityNumeric.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.toolTip.SetToolTip(this.similarityNumeric, "Images searched must have a similarity chance of this or above to be considered a" +
        " duplicate. \r\n95% or above is reccomended.");
            this.similarityNumeric.Value = new decimal(new int[] {
            95,
            0,
            0,
            0});
            // 
            // similarityLabel
            // 
            this.similarityLabel.AutoSize = true;
            this.similarityLabel.Location = new System.Drawing.Point(2, 158);
            this.similarityLabel.Name = "similarityLabel";
            this.similarityLabel.Size = new System.Drawing.Size(53, 13);
            this.similarityLabel.TabIndex = 10;
            this.similarityLabel.Text = "Similarity: ";
            // 
            // infoRichTextBoxLeft
            // 
            this.infoRichTextBoxLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.infoRichTextBoxLeft.Location = new System.Drawing.Point(0, 0);
            this.infoRichTextBoxLeft.Margin = new System.Windows.Forms.Padding(10, 10, 10, 10);
            this.infoRichTextBoxLeft.Name = "infoRichTextBoxLeft";
            this.infoRichTextBoxLeft.ReadOnly = true;
            this.infoRichTextBoxLeft.Size = new System.Drawing.Size(100, 235);
            this.infoRichTextBoxLeft.TabIndex = 3;
            this.infoRichTextBoxLeft.Text = "";
            this.toolTip.SetToolTip(this.infoRichTextBoxLeft, resources.GetString("infoRichTextBoxLeft.ToolTip"));
            // 
            // infoRichTextBoxRight
            // 
            this.infoRichTextBoxRight.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.infoRichTextBoxRight.Location = new System.Drawing.Point(10, 0);
            this.infoRichTextBoxRight.Margin = new System.Windows.Forms.Padding(10, 0, 10, 0);
            this.infoRichTextBoxRight.Name = "infoRichTextBoxRight";
            this.infoRichTextBoxRight.ReadOnly = true;
            this.infoRichTextBoxRight.Size = new System.Drawing.Size(100, 235);
            this.infoRichTextBoxRight.TabIndex = 3;
            this.infoRichTextBoxRight.Text = "";
            this.toolTip.SetToolTip(this.infoRichTextBoxRight, resources.GetString("infoRichTextBoxRight.ToolTip"));
            // 
            // searchButton
            // 
            this.searchButton.DataBindings.Add(new System.Windows.Forms.Binding("Enabled", this.duplicatesFormModelBindingSource, "StateDirectoryOpenOrSorting", true));
            this.searchButton.Location = new System.Drawing.Point(10, 264);
            this.searchButton.Name = "searchButton";
            this.searchButton.Size = new System.Drawing.Size(117, 23);
            this.searchButton.TabIndex = 18;
            this.searchButton.Text = "Search";
            this.toolTip.SetToolTip(this.searchButton, "If you have changed the similarity threshold and wish to search the same director" +
        "y you have already selected once again you can click this button to do so.");
            this.searchButton.UseVisualStyleBackColor = true;
            this.searchButton.Click += new System.EventHandler(this.searchButton_Click);
            // 
            // imagesCheckBox
            // 
            this.imagesCheckBox.AutoSize = true;
            this.imagesCheckBox.DataBindings.Add(new System.Windows.Forms.Binding("Checked", this.duplicatesFormModelBindingSource, "SearchImages", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.imagesCheckBox.DataBindings.Add(new System.Windows.Forms.Binding("Enabled", this.duplicatesFormModelBindingSource, "StateDirectoryOpenOrSorting", true));
            this.imagesCheckBox.Enabled = false;
            this.imagesCheckBox.Location = new System.Drawing.Point(6, 47);
            this.imagesCheckBox.Name = "imagesCheckBox";
            this.imagesCheckBox.Size = new System.Drawing.Size(60, 17);
            this.imagesCheckBox.TabIndex = 20;
            this.imagesCheckBox.Text = "Images";
            this.toolTip.SetToolTip(this.imagesCheckBox, "Search image files for duplicates.");
            this.imagesCheckBox.UseVisualStyleBackColor = true;
            this.imagesCheckBox.CheckStateChanged += new System.EventHandler(this.imagesCheckBox_CheckedChanged);
            // 
            // videosCheckBox
            // 
            this.videosCheckBox.AutoSize = true;
            this.videosCheckBox.DataBindings.Add(new System.Windows.Forms.Binding("Checked", this.duplicatesFormModelBindingSource, "SearchVideos", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.videosCheckBox.DataBindings.Add(new System.Windows.Forms.Binding("Enabled", this.duplicatesFormModelBindingSource, "StateDirectoryOpenOrSorting", true));
            this.videosCheckBox.Enabled = false;
            this.videosCheckBox.Location = new System.Drawing.Point(70, 47);
            this.videosCheckBox.Name = "videosCheckBox";
            this.videosCheckBox.Size = new System.Drawing.Size(58, 17);
            this.videosCheckBox.TabIndex = 21;
            this.videosCheckBox.Text = "Videos";
            this.toolTip.SetToolTip(this.videosCheckBox, "Search video files for duplicates.\r\n");
            this.videosCheckBox.UseVisualStyleBackColor = true;
            this.videosCheckBox.CheckStateChanged += new System.EventHandler(this.videosCheckBox_CheckedChanged);
            // 
            // threadCountNumeric
            // 
            this.threadCountNumeric.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.duplicatesFormModelBindingSource, "ThreadCount", true));
            this.threadCountNumeric.DataBindings.Add(new System.Windows.Forms.Binding("Enabled", this.duplicatesFormModelBindingSource, "StateDirectoryOpenOrSorting", true));
            this.threadCountNumeric.Enabled = false;
            this.threadCountNumeric.Location = new System.Drawing.Point(54, 132);
            this.threadCountNumeric.Maximum = new decimal(new int[] {
            16,
            0,
            0,
            0});
            this.threadCountNumeric.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.threadCountNumeric.Name = "threadCountNumeric";
            this.threadCountNumeric.Size = new System.Drawing.Size(63, 20);
            this.threadCountNumeric.TabIndex = 22;
            this.threadCountNumeric.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.toolTip.SetToolTip(this.threadCountNumeric, "Thread count for calculating file \'fingerprints\' used for finding similarities, t" +
        "he reccomended amount is your computer\'s CPU core count. \r\nHigher numbers give d" +
        "iminishing returns. Results may vary.");
            this.threadCountNumeric.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // cancelButton
            // 
            this.cancelButton.DataBindings.Add(new System.Windows.Forms.Binding("Enabled", this.duplicatesFormModelBindingSource, "StateSearching", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.cancelButton.Enabled = false;
            this.cancelButton.Location = new System.Drawing.Point(132, 264);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(61, 23);
            this.cancelButton.TabIndex = 24;
            this.cancelButton.Text = "Cancel";
            this.toolTip.SetToolTip(this.cancelButton, "If you have changed the similarity threshold and wish to search the same director" +
        "y you have already selected once again you can click this button to do so.");
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // mergeFileTagsCheckBox
            // 
            this.mergeFileTagsCheckBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.mergeFileTagsCheckBox.AutoSize = true;
            this.mergeFileTagsCheckBox.DataBindings.Add(new System.Windows.Forms.Binding("Checked", this.duplicatesFormModelBindingSource, "MergeFileTags", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.mergeFileTagsCheckBox.DataBindings.Add(new System.Windows.Forms.Binding("Enabled", this.duplicatesFormModelBindingSource, "StateDirectoryOpenOrSorting", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.mergeFileTagsCheckBox.Location = new System.Drawing.Point(197, 306);
            this.mergeFileTagsCheckBox.Name = "mergeFileTagsCheckBox";
            this.mergeFileTagsCheckBox.Size = new System.Drawing.Size(112, 17);
            this.mergeFileTagsCheckBox.TabIndex = 28;
            this.mergeFileTagsCheckBox.Text = "Merge File Tags �";
            this.toolTip.SetToolTip(this.mergeFileTagsCheckBox, "When selecting a file to keep (left or right), if this option is ticked, then Sor" +
        "ter Express will merge\r\nthe tags of both the filenames together and rename the k" +
        "ept file with the new tags combination.");
            this.mergeFileTagsCheckBox.UseVisualStyleBackColor = true;
            // 
            // onlyKeepLibraryTagsCheckBox
            // 
            this.onlyKeepLibraryTagsCheckBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.onlyKeepLibraryTagsCheckBox.AutoSize = true;
            this.onlyKeepLibraryTagsCheckBox.DataBindings.Add(new System.Windows.Forms.Binding("Checked", this.duplicatesFormModelBindingSource, "OnlyKeepTagsThatAreInLibrary", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.onlyKeepLibraryTagsCheckBox.DataBindings.Add(new System.Windows.Forms.Binding("Enabled", this.duplicatesFormModelBindingSource, "EnableOnlyKeepTagsInLibraryButton", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.onlyKeepLibraryTagsCheckBox.Location = new System.Drawing.Point(315, 306);
            this.onlyKeepLibraryTagsCheckBox.Name = "onlyKeepLibraryTagsCheckBox";
            this.onlyKeepLibraryTagsCheckBox.Size = new System.Drawing.Size(205, 17);
            this.onlyKeepLibraryTagsCheckBox.TabIndex = 29;
            this.onlyKeepLibraryTagsCheckBox.Text = "Only keep tags that are in tag library �";
            this.toolTip.SetToolTip(this.onlyKeepLibraryTagsCheckBox, resources.GetString("onlyKeepLibraryTagsCheckBox.ToolTip"));
            this.onlyKeepLibraryTagsCheckBox.UseVisualStyleBackColor = true;
            // 
            // matchFileTypesCheckBox
            // 
            this.matchFileTypesCheckBox.AutoSize = true;
            this.matchFileTypesCheckBox.DataBindings.Add(new System.Windows.Forms.Binding("Checked", this.duplicatesFormModelBindingSource, "OnlyMatchSameFileTypes", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.matchFileTypesCheckBox.DataBindings.Add(new System.Windows.Forms.Binding("Enabled", this.duplicatesFormModelBindingSource, "EnableMatchFileTypesCheckBox", true));
            this.matchFileTypesCheckBox.Location = new System.Drawing.Point(6, 68);
            this.matchFileTypesCheckBox.Name = "matchFileTypesCheckBox";
            this.matchFileTypesCheckBox.Size = new System.Drawing.Size(173, 17);
            this.matchFileTypesCheckBox.TabIndex = 37;
            this.matchFileTypesCheckBox.Text = "Only Match Files of Same Type";
            this.toolTip.SetToolTip(this.matchFileTypesCheckBox, "Only match duplicates if the file types match.\r\nImages will only match images and" +
        " videos will only match videos.");
            this.matchFileTypesCheckBox.UseVisualStyleBackColor = true;
            // 
            // fileCountLabel
            // 
            this.fileCountLabel.AutoSize = true;
            this.fileCountLabel.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.duplicatesFormModelBindingSource, "FileAndMatchesCountText", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.fileCountLabel.Location = new System.Drawing.Point(12, 248);
            this.fileCountLabel.Name = "fileCountLabel";
            this.fileCountLabel.Size = new System.Drawing.Size(40, 13);
            this.fileCountLabel.TabIndex = 25;
            this.fileCountLabel.Text = "Files: 0";
            this.toolTip.SetToolTip(this.fileCountLabel, "The amount of files that will be searched given the given search criteria, and;\r\n" +
        "the number of potential duplicate matches that are currently displayed in the gr" +
        "id view below.");
            // 
            // cropLeftRightCheckBox
            // 
            this.cropLeftRightCheckBox.AutoSize = true;
            this.cropLeftRightCheckBox.DataBindings.Add(new System.Windows.Forms.Binding("Checked", this.duplicatesFormModelBindingSource, "CropLeftAndRight", true));
            this.cropLeftRightCheckBox.DataBindings.Add(new System.Windows.Forms.Binding("Enabled", this.duplicatesFormModelBindingSource, "StateDirectoryOpenOrSorting", true));
            this.cropLeftRightCheckBox.Enabled = false;
            this.cropLeftRightCheckBox.Location = new System.Drawing.Point(6, 90);
            this.cropLeftRightCheckBox.Name = "cropLeftRightCheckBox";
            this.cropLeftRightCheckBox.Size = new System.Drawing.Size(106, 17);
            this.cropLeftRightCheckBox.TabIndex = 31;
            this.cropLeftRightCheckBox.Text = "Crop Left & Right";
            this.toolTip.SetToolTip(this.cropLeftRightCheckBox, "Crop black borders on the left and right of files.");
            this.cropLeftRightCheckBox.UseMnemonic = false;
            this.cropLeftRightCheckBox.UseVisualStyleBackColor = true;
            // 
            // cropTopBottomCheckBox
            // 
            this.cropTopBottomCheckBox.AutoSize = true;
            this.cropTopBottomCheckBox.DataBindings.Add(new System.Windows.Forms.Binding("Checked", this.duplicatesFormModelBindingSource, "CropTopAndBottom", true));
            this.cropTopBottomCheckBox.DataBindings.Add(new System.Windows.Forms.Binding("Enabled", this.duplicatesFormModelBindingSource, "StateDirectoryOpenOrSorting", true));
            this.cropTopBottomCheckBox.Enabled = false;
            this.cropTopBottomCheckBox.Location = new System.Drawing.Point(6, 112);
            this.cropTopBottomCheckBox.Name = "cropTopBottomCheckBox";
            this.cropTopBottomCheckBox.Size = new System.Drawing.Size(115, 17);
            this.cropTopBottomCheckBox.TabIndex = 32;
            this.cropTopBottomCheckBox.Text = "Crop Top & Bottom";
            this.toolTip.SetToolTip(this.cropTopBottomCheckBox, "Crop black borders on the top and bottom of files.");
            this.cropTopBottomCheckBox.UseMnemonic = false;
            this.cropTopBottomCheckBox.UseVisualStyleBackColor = true;
            // 
            // searchScopeComboBox
            // 
            this.searchScopeComboBox.DataBindings.Add(new System.Windows.Forms.Binding("Enabled", this.duplicatesFormModelBindingSource, "StateDirectoryOpenOrSorting", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.searchScopeComboBox.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", this.duplicatesFormModelBindingSource, "SearchScopeSelectedValue", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.searchScopeComboBox.DisplayMember = "EnumDescription";
            this.searchScopeComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.searchScopeComboBox.DropDownWidth = 300;
            this.searchScopeComboBox.Location = new System.Drawing.Point(6, 19);
            this.searchScopeComboBox.Name = "searchScopeComboBox";
            this.searchScopeComboBox.Size = new System.Drawing.Size(168, 21);
            this.searchScopeComboBox.TabIndex = 38;
            this.toolTip.SetToolTip(this.searchScopeComboBox, resources.GetString("searchScopeComboBox.ToolTip"));
            this.searchScopeComboBox.ValueMember = "EnumValue";
            this.searchScopeComboBox.SelectedValueChanged += new System.EventHandler(this.searchScopeComboBox_SelectedValueChanged);
            // 
            // matchesDataGridView
            // 
            this.matchesDataGridView.AllowUserToAddRows = false;
            this.matchesDataGridView.AllowUserToDeleteRows = false;
            this.matchesDataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.matchesDataGridView.BackgroundColor = System.Drawing.SystemColors.ControlLight;
            this.matchesDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.matchesDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.file1ImageColumn,
            this.file2ImageColumn,
            this.similarityColumn});
            this.matchesDataGridView.ContextMenuStrip = this.matchesContextMenu;
            this.matchesDataGridView.DataBindings.Add(new System.Windows.Forms.Binding("DataSource", this.duplicatesFormModelBindingSource, "Duplicates", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.matchesDataGridView.Location = new System.Drawing.Point(11, 290);
            this.matchesDataGridView.MultiSelect = false;
            this.matchesDataGridView.Name = "matchesDataGridView";
            this.matchesDataGridView.ReadOnly = true;
            this.matchesDataGridView.RowHeadersVisible = false;
            this.matchesDataGridView.RowTemplate.Height = 50;
            this.matchesDataGridView.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.matchesDataGridView.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.matchesDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.matchesDataGridView.Size = new System.Drawing.Size(181, 85);
            this.matchesDataGridView.TabIndex = 30;
            this.toolTip.SetToolTip(this.matchesDataGridView, resources.GetString("matchesDataGridView.ToolTip"));
            this.matchesDataGridView.CellContextMenuStripNeeded += new System.Windows.Forms.DataGridViewCellContextMenuStripNeededEventHandler(this.MatchesDataGridView_CellContextMenuStripNeeded);
            this.matchesDataGridView.SelectionChanged += new System.EventHandler(this.matchesDataGridView_SelectionChanged);
            // 
            // file1ImageColumn
            // 
            this.file1ImageColumn.DataPropertyName = "File1Thumb";
            this.file1ImageColumn.HeaderText = "File 1";
            this.file1ImageColumn.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Zoom;
            this.file1ImageColumn.Name = "file1ImageColumn";
            this.file1ImageColumn.ReadOnly = true;
            this.file1ImageColumn.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.file1ImageColumn.Width = 50;
            // 
            // file2ImageColumn
            // 
            this.file2ImageColumn.DataPropertyName = "File2Thumb";
            this.file2ImageColumn.HeaderText = "File 2";
            this.file2ImageColumn.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Zoom;
            this.file2ImageColumn.Name = "file2ImageColumn";
            this.file2ImageColumn.ReadOnly = true;
            this.file2ImageColumn.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            this.file2ImageColumn.Width = 50;
            // 
            // similarityColumn
            // 
            this.similarityColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            this.similarityColumn.DataPropertyName = "ChancePercentageText";
            this.similarityColumn.HeaderText = "Similarity";
            this.similarityColumn.Name = "similarityColumn";
            this.similarityColumn.ReadOnly = true;
            this.similarityColumn.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // matchesContextMenu
            // 
            this.matchesContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.keepLeftToolStripMenuItem,
            this.removeToolStripMenuItem,
            this.skipToolStripMenuItem,
            this.deleteBothToolStripMenuItem});
            this.matchesContextMenu.Name = "matchesContextMenu";
            this.matchesContextMenu.Size = new System.Drawing.Size(272, 92);
            // 
            // keepLeftToolStripMenuItem
            // 
            this.keepLeftToolStripMenuItem.Name = "keepLeftToolStripMenuItem";
            this.keepLeftToolStripMenuItem.Size = new System.Drawing.Size(271, 22);
            this.keepLeftToolStripMenuItem.Text = "Keep &Left (Delete Right)";
            this.keepLeftToolStripMenuItem.Click += new System.EventHandler(this.keepLeftToolStripMenuItem_Click);
            // 
            // removeToolStripMenuItem
            // 
            this.removeToolStripMenuItem.Name = "removeToolStripMenuItem";
            this.removeToolStripMenuItem.Size = new System.Drawing.Size(271, 22);
            this.removeToolStripMenuItem.Text = "Keep &Right (Delete Left)";
            this.removeToolStripMenuItem.Click += new System.EventHandler(this.removeToolStripMenuItem_Click);
            // 
            // skipToolStripMenuItem
            // 
            this.skipToolStripMenuItem.Name = "skipToolStripMenuItem";
            this.skipToolStripMenuItem.Size = new System.Drawing.Size(271, 22);
            this.skipToolStripMenuItem.Text = "Keep &Both (Remove Match From List)";
            this.skipToolStripMenuItem.Click += new System.EventHandler(this.skipToolStripMenuItem_Click);
            // 
            // deleteBothToolStripMenuItem
            // 
            this.deleteBothToolStripMenuItem.Name = "deleteBothToolStripMenuItem";
            this.deleteBothToolStripMenuItem.Size = new System.Drawing.Size(271, 22);
            this.deleteBothToolStripMenuItem.Text = "Keep &Neither (Delete Both)";
            this.deleteBothToolStripMenuItem.Click += new System.EventHandler(this.deleteBothToolStripMenuItem_Click);
            // 
            // undoButton
            // 
            this.undoButton.DataBindings.Add(new System.Windows.Forms.Binding("Enabled", this.duplicatesFormModelBindingSource, "EnableUndoButton", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.undoButton.Location = new System.Drawing.Point(78, 12);
            this.undoButton.Name = "undoButton";
            this.undoButton.Size = new System.Drawing.Size(55, 23);
            this.undoButton.TabIndex = 34;
            this.undoButton.Text = "Undo";
            this.toolTip.SetToolTip(this.undoButton, "Undo last action (CTRL + Z)");
            this.undoButton.UseVisualStyleBackColor = true;
            this.undoButton.Click += new System.EventHandler(this.undoButton_Click);
            // 
            // button1
            // 
            this.button1.DataBindings.Add(new System.Windows.Forms.Binding("Enabled", this.duplicatesFormModelBindingSource, "EnableRedoButton", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.button1.Location = new System.Drawing.Point(137, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(55, 23);
            this.button1.TabIndex = 35;
            this.button1.Text = "Redo";
            this.toolTip.SetToolTip(this.button1, "Redo last undone action (CTRL + Y)");
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // loadingLabel
            // 
            this.loadingLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.loadingLabel.AutoSize = true;
            this.loadingLabel.BackColor = System.Drawing.Color.Transparent;
            this.loadingLabel.DataBindings.Add(new System.Windows.Forms.Binding("Visible", this.duplicatesFormModelBindingSource, "StateSearching", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.loadingLabel.Location = new System.Drawing.Point(10, 376);
            this.loadingLabel.Name = "loadingLabel";
            this.loadingLabel.Size = new System.Drawing.Size(64, 13);
            this.loadingLabel.TabIndex = 12;
            this.loadingLabel.Text = "Searching...";
            // 
            // filenameRichTextBoxLeft
            // 
            this.filenameRichTextBoxLeft.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.filenameRichTextBoxLeft.Location = new System.Drawing.Point(0, 0);
            this.filenameRichTextBoxLeft.Margin = new System.Windows.Forms.Padding(0);
            this.filenameRichTextBoxLeft.Name = "filenameRichTextBoxLeft";
            this.filenameRichTextBoxLeft.ReadOnly = true;
            this.filenameRichTextBoxLeft.Size = new System.Drawing.Size(343, 50);
            this.filenameRichTextBoxLeft.TabIndex = 13;
            this.filenameRichTextBoxLeft.Text = "";
            // 
            // filenameRichTextBoxRight
            // 
            this.filenameRichTextBoxRight.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.filenameRichTextBoxRight.Location = new System.Drawing.Point(353, 0);
            this.filenameRichTextBoxRight.Margin = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.filenameRichTextBoxRight.Name = "filenameRichTextBoxRight";
            this.filenameRichTextBoxRight.ReadOnly = true;
            this.filenameRichTextBoxRight.Size = new System.Drawing.Size(334, 50);
            this.filenameRichTextBoxRight.TabIndex = 14;
            this.filenameRichTextBoxRight.Text = "";
            // 
            // sidesLayoutPanel
            // 
            this.sidesLayoutPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.sidesLayoutPanel.ColumnCount = 2;
            this.sidesLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.sidesLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.sidesLayoutPanel.Controls.Add(this.leftPanel, 0, 0);
            this.sidesLayoutPanel.Controls.Add(this.rightPanel, 1, 0);
            this.sidesLayoutPanel.Location = new System.Drawing.Point(197, 66);
            this.sidesLayoutPanel.Name = "sidesLayoutPanel";
            this.sidesLayoutPanel.RowCount = 1;
            this.sidesLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.sidesLayoutPanel.Size = new System.Drawing.Size(686, 235);
            this.sidesLayoutPanel.TabIndex = 15;
            // 
            // leftPanel
            // 
            this.leftPanel.Controls.Add(this.mediaViewerLeft);
            this.leftPanel.Controls.Add(this.infoRichTextBoxLeft);
            this.leftPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.leftPanel.Location = new System.Drawing.Point(0, 0);
            this.leftPanel.Margin = new System.Windows.Forms.Padding(0);
            this.leftPanel.Name = "leftPanel";
            this.leftPanel.Size = new System.Drawing.Size(343, 235);
            this.leftPanel.TabIndex = 5;
            // 
            // mediaViewerLeft
            // 
            this.mediaViewerLeft.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mediaViewerLeft.Location = new System.Drawing.Point(100, 0);
            this.mediaViewerLeft.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.mediaViewerLeft.Name = "mediaViewerLeft";
            this.mediaViewerLeft.Size = new System.Drawing.Size(243, 235);
            this.mediaViewerLeft.TabIndex = 4;
            this.mediaViewerLeft.VideoPosition = -1F;
            // 
            // rightPanel
            // 
            this.rightPanel.Controls.Add(this.mediaViewerRight);
            this.rightPanel.Controls.Add(this.infoRichTextBoxRight);
            this.rightPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rightPanel.Location = new System.Drawing.Point(343, 0);
            this.rightPanel.Margin = new System.Windows.Forms.Padding(0);
            this.rightPanel.Name = "rightPanel";
            this.rightPanel.Size = new System.Drawing.Size(343, 235);
            this.rightPanel.TabIndex = 4;
            // 
            // mediaViewerRight
            // 
            this.mediaViewerRight.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.mediaViewerRight.Location = new System.Drawing.Point(110, 0);
            this.mediaViewerRight.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.mediaViewerRight.Name = "mediaViewerRight";
            this.mediaViewerRight.Size = new System.Drawing.Size(234, 235);
            this.mediaViewerRight.TabIndex = 4;
            this.mediaViewerRight.VideoPosition = -1F;
            // 
            // keepButtonsLayoutPanel
            // 
            this.keepButtonsLayoutPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.keepButtonsLayoutPanel.ColumnCount = 2;
            this.keepButtonsLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.keepButtonsLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.keepButtonsLayoutPanel.Controls.Add(this.keepRightButton, 1, 0);
            this.keepButtonsLayoutPanel.Controls.Add(this.keepLeftButton, 0, 0);
            this.keepButtonsLayoutPanel.Location = new System.Drawing.Point(198, 329);
            this.keepButtonsLayoutPanel.Margin = new System.Windows.Forms.Padding(0);
            this.keepButtonsLayoutPanel.Name = "keepButtonsLayoutPanel";
            this.keepButtonsLayoutPanel.RowCount = 1;
            this.keepButtonsLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.keepButtonsLayoutPanel.Size = new System.Drawing.Size(686, 23);
            this.keepButtonsLayoutPanel.TabIndex = 16;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel2.ColumnCount = 2;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Controls.Add(this.filenameRichTextBoxLeft, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.filenameRichTextBoxRight, 1, 0);
            this.tableLayoutPanel2.Location = new System.Drawing.Point(197, 12);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(687, 50);
            this.tableLayoutPanel2.TabIndex = 17;
            // 
            // progressBar
            // 
            this.progressBar.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.progressBar.DataBindings.Add(new System.Windows.Forms.Binding("Visible", this.duplicatesFormModelBindingSource, "StateSearching", true));
            this.progressBar.Location = new System.Drawing.Point(73, 378);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(119, 21);
            this.progressBar.TabIndex = 19;
            // 
            // threadsLabel
            // 
            this.threadsLabel.AutoSize = true;
            this.threadsLabel.Location = new System.Drawing.Point(2, 134);
            this.threadsLabel.Name = "threadsLabel";
            this.threadsLabel.Size = new System.Drawing.Size(52, 13);
            this.threadsLabel.TabIndex = 23;
            this.threadsLabel.Text = "Threads: ";
            // 
            // keepNeitherButton
            // 
            this.keepNeitherButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.keepNeitherButton.DataBindings.Add(new System.Windows.Forms.Binding("Enabled", this.duplicatesFormModelBindingSource, "StateSorting", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.keepNeitherButton.Location = new System.Drawing.Point(198, 377);
            this.keepNeitherButton.Name = "keepNeitherButton";
            this.keepNeitherButton.Size = new System.Drawing.Size(686, 23);
            this.keepNeitherButton.TabIndex = 27;
            this.keepNeitherButton.Text = "Keep &Neither (Delete Both)";
            this.keepNeitherButton.UseVisualStyleBackColor = true;
            this.keepNeitherButton.Click += new System.EventHandler(this.keepNeitherButton_Click);
            // 
            // percentageLabel
            // 
            this.percentageLabel.AutoSize = true;
            this.percentageLabel.Location = new System.Drawing.Point(118, 158);
            this.percentageLabel.Name = "percentageLabel";
            this.percentageLabel.Size = new System.Drawing.Size(60, 13);
            this.percentageLabel.TabIndex = 11;
            this.percentageLabel.Text = "% or above";
            // 
            // settingsButton
            // 
            this.settingsButton.Location = new System.Drawing.Point(12, 12);
            this.settingsButton.Name = "settingsButton";
            this.settingsButton.Size = new System.Drawing.Size(62, 23);
            this.settingsButton.TabIndex = 33;
            this.settingsButton.Text = "Settings";
            this.settingsButton.UseVisualStyleBackColor = true;
            this.settingsButton.Click += new System.EventHandler(this.settingsButton_Click);
            // 
            // massOperationButton
            // 
            this.massOperationButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.massOperationButton.DataBindings.Add(new System.Windows.Forms.Binding("Enabled", this.duplicatesFormModelBindingSource, "StateSorting", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.massOperationButton.DataBindings.Add(new System.Windows.Forms.Binding("Visible", this.duplicatesFormModelBindingSource, "StateNotSearching", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.massOperationButton.Location = new System.Drawing.Point(10, 377);
            this.massOperationButton.Name = "massOperationButton";
            this.massOperationButton.Size = new System.Drawing.Size(183, 23);
            this.massOperationButton.TabIndex = 36;
            this.massOperationButton.Text = "Mass Operation";
            this.massOperationButton.UseVisualStyleBackColor = true;
            this.massOperationButton.Click += new System.EventHandler(this.massOperationButton_Click);
            // 
            // filtersGroupBox
            // 
            this.filtersGroupBox.Controls.Add(this.similarityNumeric);
            this.filtersGroupBox.Controls.Add(this.searchScopeComboBox);
            this.filtersGroupBox.Controls.Add(this.similarityLabel);
            this.filtersGroupBox.Controls.Add(this.threadsLabel);
            this.filtersGroupBox.Controls.Add(this.matchFileTypesCheckBox);
            this.filtersGroupBox.Controls.Add(this.percentageLabel);
            this.filtersGroupBox.Controls.Add(this.imagesCheckBox);
            this.filtersGroupBox.Controls.Add(this.videosCheckBox);
            this.filtersGroupBox.Controls.Add(this.threadCountNumeric);
            this.filtersGroupBox.Controls.Add(this.cropLeftRightCheckBox);
            this.filtersGroupBox.Controls.Add(this.cropTopBottomCheckBox);
            this.filtersGroupBox.Location = new System.Drawing.Point(12, 63);
            this.filtersGroupBox.Name = "filtersGroupBox";
            this.filtersGroupBox.Size = new System.Drawing.Size(180, 182);
            this.filtersGroupBox.TabIndex = 39;
            this.filtersGroupBox.TabStop = false;
            this.filtersGroupBox.Text = "Search Filters";
            // 
            // DuplicatesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(893, 411);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.undoButton);
            this.Controls.Add(this.settingsButton);
            this.Controls.Add(this.matchesDataGridView);
            this.Controls.Add(this.onlyKeepLibraryTagsCheckBox);
            this.Controls.Add(this.mergeFileTagsCheckBox);
            this.Controls.Add(this.keepNeitherButton);
            this.Controls.Add(this.fileCountLabel);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.loadingLabel);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.searchButton);
            this.Controls.Add(this.keepButtonsLayoutPanel);
            this.Controls.Add(this.sidesLayoutPanel);
            this.Controls.Add(this.openDirectoryButton);
            this.Controls.Add(this.keepBothButton);
            this.Controls.Add(this.tableLayoutPanel2);
            this.Controls.Add(this.massOperationButton);
            this.Controls.Add(this.filtersGroupBox);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MinimumSize = new System.Drawing.Size(909, 450);
            this.Name = "DuplicatesForm";
            this.Text = "Sorter Express - Duplicate Search";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.DuplicatesForm_FormClosing);
            this.Shown += new System.EventHandler(this.DuplicatesForm_Shown);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.DuplicatesForm_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.duplicatesFormModelBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.similarityNumeric)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.threadCountNumeric)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.matchesDataGridView)).EndInit();
            this.matchesContextMenu.ResumeLayout(false);
            this.sidesLayoutPanel.ResumeLayout(false);
            this.leftPanel.ResumeLayout(false);
            this.rightPanel.ResumeLayout(false);
            this.keepButtonsLayoutPanel.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.filtersGroupBox.ResumeLayout(false);
            this.filtersGroupBox.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

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
    }
}