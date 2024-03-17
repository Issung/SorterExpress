namespace SorterExpress.Forms
{
    partial class NsfwSortForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(NsfwSortForm));
            bindingSource = new System.Windows.Forms.BindingSource(components);
            openDirectoryButton = new System.Windows.Forms.Button();
            toolTip = new System.Windows.Forms.ToolTip(components);
            searchButton = new System.Windows.Forms.Button();
            imagesCheckBox = new System.Windows.Forms.CheckBox();
            videosCheckBox = new System.Windows.Forms.CheckBox();
            threadCountNumeric = new System.Windows.Forms.NumericUpDown();
            cancelButton = new System.Windows.Forms.Button();
            fileCountLabel = new System.Windows.Forms.Label();
            searchScopeComboBox = new System.Windows.Forms.ComboBox();
            resultsDataGridView = new System.Windows.Forms.DataGridView();
            fileImageColumn = new System.Windows.Forms.DataGridViewImageColumn();
            classificationColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            undoButton = new System.Windows.Forms.Button();
            redoButton = new System.Windows.Forms.Button();
            optionsRightButton = new System.Windows.Forms.Button();
            chartImg = new System.Windows.Forms.PictureBox();
            overrideLabel = new System.Windows.Forms.Label();
            resultsFilterComboBox = new System.Windows.Forms.ComboBox();
            loadingLabel = new System.Windows.Forms.Label();
            filenameRichTextBox = new System.Windows.Forms.RichTextBox();
            mediaViewer = new Controls.MediaViewer();
            progressBar = new System.Windows.Forms.ProgressBar();
            threadsLabel = new System.Windows.Forms.Label();
            settingsButton = new System.Windows.Forms.Button();
            filtersGroupBox = new System.Windows.Forms.GroupBox();
            optionsContextMenuStrip = new System.Windows.Forms.ContextMenuStrip(components);
            openFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            openFileInExplorerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            weightsLabel = new System.Windows.Forms.Label();
            overallGroupBox = new System.Windows.Forms.GroupBox();
            button4 = new System.Windows.Forms.Button();
            button3 = new System.Windows.Forms.Button();
            button2 = new System.Windows.Forms.Button();
            button1 = new System.Windows.Forms.Button();
            overrideNeutralButton = new System.Windows.Forms.RadioButton();
            thisFileGroupBox = new System.Windows.Forms.GroupBox();
            overrideTableLayout = new System.Windows.Forms.TableLayoutPanel();
            overridePornographyButton = new System.Windows.Forms.RadioButton();
            overrideHentaiButton = new System.Windows.Forms.RadioButton();
            overrideSexyButton = new System.Windows.Forms.RadioButton();
            chartLabelsTableLayout = new System.Windows.Forms.TableLayoutPanel();
            label4 = new System.Windows.Forms.Label();
            label3 = new System.Windows.Forms.Label();
            label2 = new System.Windows.Forms.Label();
            label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)bindingSource).BeginInit();
            ((System.ComponentModel.ISupportInitialize)threadCountNumeric).BeginInit();
            ((System.ComponentModel.ISupportInitialize)resultsDataGridView).BeginInit();
            ((System.ComponentModel.ISupportInitialize)chartImg).BeginInit();
            filtersGroupBox.SuspendLayout();
            optionsContextMenuStrip.SuspendLayout();
            overallGroupBox.SuspendLayout();
            thisFileGroupBox.SuspendLayout();
            overrideTableLayout.SuspendLayout();
            chartLabelsTableLayout.SuspendLayout();
            SuspendLayout();
            // 
            // bindingSource
            // 
            bindingSource.DataSource = typeof(Models.NsfwSortModel);
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
            // searchButton
            // 
            searchButton.DataBindings.Add(new System.Windows.Forms.Binding("Enabled", bindingSource, "StateDirectoryOpenOrSorting", true));
            searchButton.Location = new System.Drawing.Point(12, 181);
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
            imagesCheckBox.DataBindings.Add(new System.Windows.Forms.Binding("Checked", bindingSource, "SearchImages", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            imagesCheckBox.DataBindings.Add(new System.Windows.Forms.Binding("Enabled", bindingSource, "StateDirectoryOpenOrSorting", true));
            imagesCheckBox.Enabled = false;
            imagesCheckBox.Location = new System.Drawing.Point(7, 51);
            imagesCheckBox.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            imagesCheckBox.Name = "imagesCheckBox";
            imagesCheckBox.Size = new System.Drawing.Size(64, 19);
            imagesCheckBox.TabIndex = 20;
            imagesCheckBox.Text = "Images";
            toolTip.SetToolTip(imagesCheckBox, "Classify image files for NSFW content.");
            imagesCheckBox.UseVisualStyleBackColor = true;
            imagesCheckBox.CheckStateChanged += imagesCheckBox_CheckedChanged;
            // 
            // videosCheckBox
            // 
            videosCheckBox.AutoSize = true;
            videosCheckBox.DataBindings.Add(new System.Windows.Forms.Binding("Checked", bindingSource, "SearchVideos", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            videosCheckBox.DataBindings.Add(new System.Windows.Forms.Binding("Enabled", bindingSource, "StateDirectoryOpenOrSorting", true));
            videosCheckBox.Enabled = false;
            videosCheckBox.Location = new System.Drawing.Point(82, 51);
            videosCheckBox.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            videosCheckBox.Name = "videosCheckBox";
            videosCheckBox.Size = new System.Drawing.Size(61, 19);
            videosCheckBox.TabIndex = 21;
            videosCheckBox.Text = "Videos";
            toolTip.SetToolTip(videosCheckBox, "Clasiffy video files for NSFW content.");
            videosCheckBox.UseVisualStyleBackColor = true;
            videosCheckBox.CheckStateChanged += videosCheckBox_CheckedChanged;
            // 
            // threadCountNumeric
            // 
            threadCountNumeric.DataBindings.Add(new System.Windows.Forms.Binding("Value", bindingSource, "ThreadCount", true));
            threadCountNumeric.DataBindings.Add(new System.Windows.Forms.Binding("Enabled", bindingSource, "StateDirectoryOpenOrSorting", true));
            threadCountNumeric.Enabled = false;
            threadCountNumeric.Location = new System.Drawing.Point(63, 74);
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
            cancelButton.DataBindings.Add(new System.Windows.Forms.Binding("Enabled", bindingSource, "StateSearching", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            cancelButton.Enabled = false;
            cancelButton.Location = new System.Drawing.Point(154, 181);
            cancelButton.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            cancelButton.Name = "cancelButton";
            cancelButton.Size = new System.Drawing.Size(71, 27);
            cancelButton.TabIndex = 24;
            cancelButton.Text = "Cancel";
            toolTip.SetToolTip(cancelButton, "If you have changed the similarity threshold and wish to search the same directory you have already selected once again you can click this button to do so.");
            cancelButton.UseVisualStyleBackColor = true;
            cancelButton.Click += cancelButton_Click;
            // 
            // fileCountLabel
            // 
            fileCountLabel.AutoSize = true;
            fileCountLabel.DataBindings.Add(new System.Windows.Forms.Binding("Text", bindingSource, "FileAndMatchesCountText", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            fileCountLabel.Location = new System.Drawing.Point(14, 214);
            fileCountLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            fileCountLabel.Name = "fileCountLabel";
            fileCountLabel.Size = new System.Drawing.Size(42, 15);
            fileCountLabel.TabIndex = 25;
            fileCountLabel.Text = "Files: 0";
            toolTip.SetToolTip(fileCountLabel, "The amount of files that will be searched given the given search criteria, and;\r\nthe number of potential duplicate matches that are currently displayed in the grid view below.");
            // 
            // searchScopeComboBox
            // 
            searchScopeComboBox.DataBindings.Add(new System.Windows.Forms.Binding("Enabled", bindingSource, "StateDirectoryOpenOrSorting", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            searchScopeComboBox.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", bindingSource, "SearchScope", true));
            searchScopeComboBox.DataSource = bindingSource;
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
            // resultsDataGridView
            // 
            resultsDataGridView.AllowUserToAddRows = false;
            resultsDataGridView.AllowUserToDeleteRows = false;
            resultsDataGridView.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
            resultsDataGridView.BackgroundColor = System.Drawing.SystemColors.ControlLight;
            resultsDataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            resultsDataGridView.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] { fileImageColumn, classificationColumn });
            resultsDataGridView.DataBindings.Add(new System.Windows.Forms.Binding("DataSource", bindingSource, "FilteredResults", true));
            resultsDataGridView.Location = new System.Drawing.Point(13, 235);
            resultsDataGridView.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            resultsDataGridView.MultiSelect = false;
            resultsDataGridView.Name = "resultsDataGridView";
            resultsDataGridView.ReadOnly = true;
            resultsDataGridView.RowHeadersVisible = false;
            resultsDataGridView.RowTemplate.Height = 50;
            resultsDataGridView.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            resultsDataGridView.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            resultsDataGridView.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            resultsDataGridView.Size = new System.Drawing.Size(211, 198);
            resultsDataGridView.TabIndex = 30;
            toolTip.SetToolTip(resultsDataGridView, resources.GetString("resultsDataGridView.ToolTip"));
            resultsDataGridView.SelectionChanged += matchesDataGridView_SelectionChanged;
            // 
            // fileImageColumn
            // 
            fileImageColumn.DataPropertyName = "Thumb";
            fileImageColumn.HeaderText = "File";
            fileImageColumn.ImageLayout = System.Windows.Forms.DataGridViewImageCellLayout.Zoom;
            fileImageColumn.Name = "fileImageColumn";
            fileImageColumn.ReadOnly = true;
            fileImageColumn.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            fileImageColumn.Width = 50;
            // 
            // classificationColumn
            // 
            classificationColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.Fill;
            classificationColumn.DataPropertyName = "ClassificationViewString";
            classificationColumn.HeaderText = "Classification";
            classificationColumn.Name = "classificationColumn";
            classificationColumn.ReadOnly = true;
            classificationColumn.Resizable = System.Windows.Forms.DataGridViewTriState.False;
            // 
            // undoButton
            // 
            undoButton.Location = new System.Drawing.Point(91, 14);
            undoButton.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            undoButton.Name = "undoButton";
            undoButton.Size = new System.Drawing.Size(64, 27);
            undoButton.TabIndex = 34;
            undoButton.Text = "Undo";
            toolTip.SetToolTip(undoButton, "Undo last action (CTRL + Z)");
            undoButton.UseVisualStyleBackColor = true;
            // 
            // redoButton
            // 
            redoButton.Location = new System.Drawing.Point(160, 14);
            redoButton.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            redoButton.Name = "redoButton";
            redoButton.Size = new System.Drawing.Size(64, 27);
            redoButton.TabIndex = 35;
            redoButton.Text = "Redo";
            toolTip.SetToolTip(redoButton, "Redo last undone action (CTRL + Y)");
            redoButton.UseVisualStyleBackColor = true;
            // 
            // optionsRightButton
            // 
            optionsRightButton.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right;
            optionsRightButton.DataBindings.Add(new System.Windows.Forms.Binding("Enabled", bindingSource, "StateViewing", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            optionsRightButton.Image = Properties.Resources.down;
            optionsRightButton.ImageAlign = System.Drawing.ContentAlignment.MiddleRight;
            optionsRightButton.Location = new System.Drawing.Point(331, 18);
            optionsRightButton.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            optionsRightButton.Name = "optionsRightButton";
            optionsRightButton.Size = new System.Drawing.Size(66, 27);
            optionsRightButton.TabIndex = 5;
            optionsRightButton.Text = "Open";
            optionsRightButton.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            toolTip.SetToolTip(optionsRightButton, "Options for viewing file or ignoring in searches.\r\nDuplicate Search file/directory ignores can be configured in settings.");
            optionsRightButton.UseVisualStyleBackColor = true;
            optionsRightButton.Click += optionsButton_Click;
            // 
            // chartImg
            // 
            chartImg.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            chartImg.Location = new System.Drawing.Point(6, 106);
            chartImg.Name = "chartImg";
            chartImg.Size = new System.Drawing.Size(391, 175);
            chartImg.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            chartImg.TabIndex = 40;
            chartImg.TabStop = false;
            toolTip.SetToolTip(chartImg, "Weights found for image classification via machine learning.");
            // 
            // overrideLabel
            // 
            overrideLabel.AutoSize = true;
            overrideLabel.Location = new System.Drawing.Point(4, 24);
            overrideLabel.Name = "overrideLabel";
            overrideLabel.Size = new System.Drawing.Size(125, 15);
            overrideLabel.TabIndex = 42;
            overrideLabel.Text = "Override Classification";
            toolTip.SetToolTip(overrideLabel, "Select one of the classification categories below to override the auto-classification found via machine learning.");
            // 
            // resultsFilterComboBox
            // 
            resultsFilterComboBox.DataBindings.Add(new System.Windows.Forms.Binding("Enabled", bindingSource, "StateSorting", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            resultsFilterComboBox.DataBindings.Add(new System.Windows.Forms.Binding("SelectedValue", bindingSource, "ResultsFilter", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            resultsFilterComboBox.DataSource = bindingSource;
            resultsFilterComboBox.DisplayMember = "EnumDescription";
            resultsFilterComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            resultsFilterComboBox.DropDownWidth = 300;
            resultsFilterComboBox.Location = new System.Drawing.Point(112, 209);
            resultsFilterComboBox.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            resultsFilterComboBox.Name = "resultsFilterComboBox";
            resultsFilterComboBox.Size = new System.Drawing.Size(112, 23);
            resultsFilterComboBox.TabIndex = 39;
            toolTip.SetToolTip(resultsFilterComboBox, "Filter results by classification.");
            resultsFilterComboBox.ValueMember = "EnumValue";
            resultsFilterComboBox.SelectedValueChanged += resultsFilterComboBox_SelectedValueChanged;
            // 
            // loadingLabel
            // 
            loadingLabel.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
            loadingLabel.AutoSize = true;
            loadingLabel.BackColor = System.Drawing.Color.Transparent;
            loadingLabel.DataBindings.Add(new System.Windows.Forms.Binding("Visible", bindingSource, "StateSearching", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            loadingLabel.Location = new System.Drawing.Point(12, 434);
            loadingLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            loadingLabel.Name = "loadingLabel";
            loadingLabel.Size = new System.Drawing.Size(68, 15);
            loadingLabel.TabIndex = 12;
            loadingLabel.Text = "Searching...";
            // 
            // filenameRichTextBox
            // 
            filenameRichTextBox.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            filenameRichTextBox.Location = new System.Drawing.Point(643, 14);
            filenameRichTextBox.Margin = new System.Windows.Forms.Padding(12, 0, 0, 0);
            filenameRichTextBox.Name = "filenameRichTextBox";
            filenameRichTextBox.ReadOnly = true;
            filenameRichTextBox.Size = new System.Drawing.Size(389, 58);
            filenameRichTextBox.TabIndex = 14;
            filenameRichTextBox.Text = "";
            // 
            // mediaViewer
            // 
            mediaViewer.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            mediaViewer.Location = new System.Drawing.Point(643, 78);
            mediaViewer.Margin = new System.Windows.Forms.Padding(5, 3, 5, 3);
            mediaViewer.Name = "mediaViewer";
            mediaViewer.Size = new System.Drawing.Size(389, 382);
            mediaViewer.TabIndex = 4;
            mediaViewer.VideoPosition = -1F;
            // 
            // progressBar
            // 
            progressBar.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
            progressBar.DataBindings.Add(new System.Windows.Forms.Binding("Visible", bindingSource, "StateSearching", true));
            progressBar.Location = new System.Drawing.Point(85, 436);
            progressBar.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            progressBar.Name = "progressBar";
            progressBar.Size = new System.Drawing.Size(139, 24);
            progressBar.TabIndex = 19;
            // 
            // threadsLabel
            // 
            threadsLabel.AutoSize = true;
            threadsLabel.Location = new System.Drawing.Point(2, 77);
            threadsLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            threadsLabel.Name = "threadsLabel";
            threadsLabel.Size = new System.Drawing.Size(54, 15);
            threadsLabel.TabIndex = 23;
            threadsLabel.Text = "Threads: ";
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
            // filtersGroupBox
            // 
            filtersGroupBox.Controls.Add(searchScopeComboBox);
            filtersGroupBox.Controls.Add(threadsLabel);
            filtersGroupBox.Controls.Add(imagesCheckBox);
            filtersGroupBox.Controls.Add(videosCheckBox);
            filtersGroupBox.Controls.Add(threadCountNumeric);
            filtersGroupBox.Location = new System.Drawing.Point(14, 73);
            filtersGroupBox.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            filtersGroupBox.Name = "filtersGroupBox";
            filtersGroupBox.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            filtersGroupBox.Size = new System.Drawing.Size(210, 107);
            filtersGroupBox.TabIndex = 39;
            filtersGroupBox.TabStop = false;
            filtersGroupBox.Text = "Search Filters";
            // 
            // optionsContextMenuStrip
            // 
            optionsContextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { openFileToolStripMenuItem, openFileInExplorerToolStripMenuItem });
            optionsContextMenuStrip.Name = "optionsContextMenuStrip";
            optionsContextMenuStrip.Size = new System.Drawing.Size(184, 48);
            // 
            // openFileToolStripMenuItem
            // 
            openFileToolStripMenuItem.Image = Properties.Resources.file;
            openFileToolStripMenuItem.Name = "openFileToolStripMenuItem";
            openFileToolStripMenuItem.Size = new System.Drawing.Size(183, 22);
            openFileToolStripMenuItem.Text = "Open File";
            openFileToolStripMenuItem.Click += openFileToolStripMenuItem_Click;
            // 
            // openFileInExplorerToolStripMenuItem
            // 
            openFileInExplorerToolStripMenuItem.Image = Properties.Resources.folder;
            openFileInExplorerToolStripMenuItem.Name = "openFileInExplorerToolStripMenuItem";
            openFileInExplorerToolStripMenuItem.Size = new System.Drawing.Size(183, 22);
            openFileInExplorerToolStripMenuItem.Text = "Open File in Explorer";
            openFileInExplorerToolStripMenuItem.Click += openFileInExplorerToolStripMenuItem_Click;
            // 
            // weightsLabel
            // 
            weightsLabel.AutoSize = true;
            weightsLabel.Location = new System.Drawing.Point(3, 88);
            weightsLabel.Name = "weightsLabel";
            weightsLabel.Size = new System.Drawing.Size(154, 15);
            weightsLabel.TabIndex = 41;
            weightsLabel.Text = "Auto-Classification Weights";
            // 
            // overallGroupBox
            // 
            overallGroupBox.Controls.Add(button4);
            overallGroupBox.Controls.Add(button3);
            overallGroupBox.Controls.Add(button2);
            overallGroupBox.Controls.Add(button1);
            overallGroupBox.Location = new System.Drawing.Point(231, 14);
            overallGroupBox.Name = "overallGroupBox";
            overallGroupBox.Size = new System.Drawing.Size(404, 151);
            overallGroupBox.TabIndex = 42;
            overallGroupBox.TabStop = false;
            overallGroupBox.Text = "Mass Operation";
            // 
            // button4
            // 
            button4.Location = new System.Drawing.Point(11, 112);
            button4.Name = "button4";
            button4.Size = new System.Drawing.Size(180, 23);
            button4.TabIndex = 3;
            button4.Text = "Move All 'Pornography' To...";
            button4.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            button4.UseVisualStyleBackColor = true;
            button4.Click += moveButton_Click;
            // 
            // button3
            // 
            button3.Location = new System.Drawing.Point(11, 82);
            button3.Name = "button3";
            button3.Size = new System.Drawing.Size(180, 23);
            button3.TabIndex = 2;
            button3.Text = "Move All 'Hentai' To...";
            button3.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            button3.UseVisualStyleBackColor = true;
            button3.Click += moveButton_Click;
            // 
            // button2
            // 
            button2.Location = new System.Drawing.Point(11, 53);
            button2.Name = "button2";
            button2.Size = new System.Drawing.Size(180, 23);
            button2.TabIndex = 1;
            button2.Text = "Move All 'Sexy' To...";
            button2.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            button2.UseVisualStyleBackColor = true;
            button2.Click += moveButton_Click;
            // 
            // button1
            // 
            button1.Location = new System.Drawing.Point(11, 24);
            button1.Name = "button1";
            button1.Size = new System.Drawing.Size(180, 23);
            button1.TabIndex = 0;
            button1.Text = "Move All 'Neutral' To...";
            button1.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            button1.UseVisualStyleBackColor = true;
            button1.Click += moveButton_Click;
            // 
            // overrideNeutralButton
            // 
            overrideNeutralButton.Appearance = System.Windows.Forms.Appearance.Button;
            overrideNeutralButton.AutoSize = true;
            overrideNeutralButton.DataBindings.Add(new System.Windows.Forms.Binding("Enabled", bindingSource, "StateViewing", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            overrideNeutralButton.Dock = System.Windows.Forms.DockStyle.Fill;
            overrideNeutralButton.Location = new System.Drawing.Point(3, 3);
            overrideNeutralButton.Name = "overrideNeutralButton";
            overrideNeutralButton.Size = new System.Drawing.Size(92, 28);
            overrideNeutralButton.TabIndex = 0;
            overrideNeutralButton.TabStop = true;
            overrideNeutralButton.Text = "&Neutral";
            overrideNeutralButton.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            overrideNeutralButton.UseVisualStyleBackColor = true;
            overrideNeutralButton.CheckedChanged += overrideButton_CheckedChanged;
            // 
            // thisFileGroupBox
            // 
            thisFileGroupBox.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
            thisFileGroupBox.Controls.Add(overrideLabel);
            thisFileGroupBox.Controls.Add(overrideTableLayout);
            thisFileGroupBox.Controls.Add(weightsLabel);
            thisFileGroupBox.Controls.Add(optionsRightButton);
            thisFileGroupBox.Controls.Add(chartLabelsTableLayout);
            thisFileGroupBox.Controls.Add(chartImg);
            thisFileGroupBox.Location = new System.Drawing.Point(231, 171);
            thisFileGroupBox.Name = "thisFileGroupBox";
            thisFileGroupBox.Size = new System.Drawing.Size(404, 289);
            thisFileGroupBox.TabIndex = 43;
            thisFileGroupBox.TabStop = false;
            thisFileGroupBox.Text = "This File";
            // 
            // overrideTableLayout
            // 
            overrideTableLayout.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            overrideTableLayout.ColumnCount = 4;
            overrideTableLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            overrideTableLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            overrideTableLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            overrideTableLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            overrideTableLayout.Controls.Add(overridePornographyButton, 3, 0);
            overrideTableLayout.Controls.Add(overrideHentaiButton, 2, 0);
            overrideTableLayout.Controls.Add(overrideSexyButton, 1, 0);
            overrideTableLayout.Controls.Add(overrideNeutralButton, 0, 0);
            overrideTableLayout.Location = new System.Drawing.Point(4, 44);
            overrideTableLayout.Name = "overrideTableLayout";
            overrideTableLayout.RowCount = 1;
            overrideTableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            overrideTableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            overrideTableLayout.Size = new System.Drawing.Size(393, 34);
            overrideTableLayout.TabIndex = 43;
            // 
            // overridePornographyButton
            // 
            overridePornographyButton.Appearance = System.Windows.Forms.Appearance.Button;
            overridePornographyButton.AutoSize = true;
            overridePornographyButton.DataBindings.Add(new System.Windows.Forms.Binding("Enabled", bindingSource, "StateViewing", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            overridePornographyButton.Dock = System.Windows.Forms.DockStyle.Fill;
            overridePornographyButton.Location = new System.Drawing.Point(297, 3);
            overridePornographyButton.Name = "overridePornographyButton";
            overridePornographyButton.Size = new System.Drawing.Size(93, 28);
            overridePornographyButton.TabIndex = 3;
            overridePornographyButton.TabStop = true;
            overridePornographyButton.Text = "&Pornography";
            overridePornographyButton.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            overridePornographyButton.UseVisualStyleBackColor = true;
            overridePornographyButton.CheckedChanged += overrideButton_CheckedChanged;
            // 
            // overrideHentaiButton
            // 
            overrideHentaiButton.Appearance = System.Windows.Forms.Appearance.Button;
            overrideHentaiButton.AutoSize = true;
            overrideHentaiButton.DataBindings.Add(new System.Windows.Forms.Binding("Enabled", bindingSource, "StateViewing", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            overrideHentaiButton.Dock = System.Windows.Forms.DockStyle.Fill;
            overrideHentaiButton.Location = new System.Drawing.Point(199, 3);
            overrideHentaiButton.Name = "overrideHentaiButton";
            overrideHentaiButton.Size = new System.Drawing.Size(92, 28);
            overrideHentaiButton.TabIndex = 2;
            overrideHentaiButton.TabStop = true;
            overrideHentaiButton.Text = "&Hentai";
            overrideHentaiButton.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            overrideHentaiButton.UseVisualStyleBackColor = true;
            overrideHentaiButton.CheckedChanged += overrideButton_CheckedChanged;
            // 
            // overrideSexyButton
            // 
            overrideSexyButton.Appearance = System.Windows.Forms.Appearance.Button;
            overrideSexyButton.AutoSize = true;
            overrideSexyButton.DataBindings.Add(new System.Windows.Forms.Binding("Enabled", bindingSource, "StateViewing", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            overrideSexyButton.Dock = System.Windows.Forms.DockStyle.Fill;
            overrideSexyButton.Location = new System.Drawing.Point(101, 3);
            overrideSexyButton.Name = "overrideSexyButton";
            overrideSexyButton.Size = new System.Drawing.Size(92, 28);
            overrideSexyButton.TabIndex = 1;
            overrideSexyButton.TabStop = true;
            overrideSexyButton.Text = "&Sexy";
            overrideSexyButton.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            overrideSexyButton.UseVisualStyleBackColor = true;
            overrideSexyButton.CheckedChanged += overrideButton_CheckedChanged;
            // 
            // chartLabelsTableLayout
            // 
            chartLabelsTableLayout.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            chartLabelsTableLayout.BackColor = System.Drawing.Color.Transparent;
            chartLabelsTableLayout.ColumnCount = 4;
            chartLabelsTableLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            chartLabelsTableLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            chartLabelsTableLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            chartLabelsTableLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 25F));
            chartLabelsTableLayout.Controls.Add(label4, 3, 0);
            chartLabelsTableLayout.Controls.Add(label3, 2, 0);
            chartLabelsTableLayout.Controls.Add(label2, 1, 0);
            chartLabelsTableLayout.Controls.Add(label1, 0, 0);
            chartLabelsTableLayout.Location = new System.Drawing.Point(11, 106);
            chartLabelsTableLayout.Name = "chartLabelsTableLayout";
            chartLabelsTableLayout.RowCount = 1;
            chartLabelsTableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            chartLabelsTableLayout.Size = new System.Drawing.Size(383, 27);
            chartLabelsTableLayout.TabIndex = 44;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.BackColor = System.Drawing.Color.Transparent;
            label4.Dock = System.Windows.Forms.DockStyle.Fill;
            label4.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            label4.Location = new System.Drawing.Point(288, 0);
            label4.Name = "label4";
            label4.Size = new System.Drawing.Size(92, 27);
            label4.TabIndex = 3;
            label4.Text = "Pornography";
            label4.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = System.Drawing.Color.Transparent;
            label3.Dock = System.Windows.Forms.DockStyle.Fill;
            label3.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            label3.Location = new System.Drawing.Point(193, 0);
            label3.Name = "label3";
            label3.Size = new System.Drawing.Size(89, 27);
            label3.TabIndex = 2;
            label3.Text = "Hentai";
            label3.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = System.Drawing.Color.Transparent;
            label2.Dock = System.Windows.Forms.DockStyle.Fill;
            label2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            label2.Location = new System.Drawing.Point(98, 0);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(89, 27);
            label2.TabIndex = 1;
            label2.Text = "Sexy";
            label2.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = System.Drawing.Color.Transparent;
            label1.Dock = System.Windows.Forms.DockStyle.Fill;
            label1.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
            label1.Location = new System.Drawing.Point(3, 0);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(89, 27);
            label1.TabIndex = 0;
            label1.Text = "Neutral";
            label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // NsfwSortForm
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(1042, 474);
            Controls.Add(resultsFilterComboBox);
            Controls.Add(thisFileGroupBox);
            Controls.Add(overallGroupBox);
            Controls.Add(settingsButton);
            Controls.Add(undoButton);
            Controls.Add(redoButton);
            Controls.Add(fileCountLabel);
            Controls.Add(cancelButton);
            Controls.Add(searchButton);
            Controls.Add(resultsDataGridView);
            Controls.Add(loadingLabel);
            Controls.Add(progressBar);
            Controls.Add(mediaViewer);
            Controls.Add(openDirectoryButton);
            Controls.Add(filenameRichTextBox);
            Controls.Add(filtersGroupBox);
            Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
            KeyPreview = true;
            Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            MinimumSize = new System.Drawing.Size(1058, 513);
            Name = "NsfwSortForm";
            Text = "Sorter Express - NSFW Search";
            FormClosing += Form_FormClosing;
            Load += NsfwSortForm_Load;
            KeyDown += Form_KeyDown;
            ((System.ComponentModel.ISupportInitialize)bindingSource).EndInit();
            ((System.ComponentModel.ISupportInitialize)threadCountNumeric).EndInit();
            ((System.ComponentModel.ISupportInitialize)resultsDataGridView).EndInit();
            ((System.ComponentModel.ISupportInitialize)chartImg).EndInit();
            filtersGroupBox.ResumeLayout(false);
            filtersGroupBox.PerformLayout();
            optionsContextMenuStrip.ResumeLayout(false);
            overallGroupBox.ResumeLayout(false);
            thisFileGroupBox.ResumeLayout(false);
            thisFileGroupBox.PerformLayout();
            overrideTableLayout.ResumeLayout(false);
            overrideTableLayout.PerformLayout();
            chartLabelsTableLayout.ResumeLayout(false);
            chartLabelsTableLayout.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private System.Windows.Forms.Button openDirectoryButton;
        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.Button searchButton;
        private System.Windows.Forms.NumericUpDown threadCountNumeric;
        private System.Windows.Forms.Label threadsLabel;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Label fileCountLabel;
        internal System.Windows.Forms.Label loadingLabel;
        internal System.Windows.Forms.ProgressBar progressBar;
        internal System.Windows.Forms.DataGridView resultsDataGridView;
        internal Controls.MediaViewer mediaViewer;
        internal System.Windows.Forms.RichTextBox filenameRichTextBox;
        private System.Windows.Forms.Button settingsButton;
        private System.Windows.Forms.Button undoButton;
        private System.Windows.Forms.Button redoButton;
        internal System.Windows.Forms.CheckBox imagesCheckBox;
        internal System.Windows.Forms.CheckBox videosCheckBox;
        internal System.Windows.Forms.BindingSource bindingSource;
        internal System.Windows.Forms.ComboBox searchScopeComboBox;
        private System.Windows.Forms.GroupBox filtersGroupBox;
        private System.Windows.Forms.ContextMenuStrip optionsContextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem openFileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem openFileInExplorerToolStripMenuItem;
        private System.Windows.Forms.Button optionsRightButton;
        private System.Windows.Forms.DataGridViewImageColumn fileImageColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn classificationColumn;
        internal System.Windows.Forms.PictureBox chartImg;
        private System.Windows.Forms.Label weightsLabel;
        private System.Windows.Forms.GroupBox overallGroupBox;
        private System.Windows.Forms.GroupBox thisFileGroupBox;
        private System.Windows.Forms.Label overrideLabel;
        private System.Windows.Forms.TableLayoutPanel overrideTableLayout;
        private System.Windows.Forms.TableLayoutPanel chartLabelsTableLayout;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        internal System.Windows.Forms.RadioButton overrideNeutralButton;
        internal System.Windows.Forms.RadioButton overridePornographyButton;
        internal System.Windows.Forms.RadioButton overrideHentaiButton;
        internal System.Windows.Forms.RadioButton overrideSexyButton;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        internal System.Windows.Forms.ComboBox resultsFilterComboBox;
    }
}