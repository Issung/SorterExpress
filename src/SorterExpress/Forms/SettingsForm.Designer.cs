namespace SorterExpress.Forms
{
    partial class SettingsForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SettingsForm));
            this.saveSettingsButton = new System.Windows.Forms.Button();
            this.websiteButton = new System.Windows.Forms.Button();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.miscControlsGroupBox = new System.Windows.Forms.GroupBox();
            this.miscControlsFlowLayoutPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.moveSortedFilesCheckbox = new System.Windows.Forms.CheckBox();
            this.fastResizingCheckbox = new System.Windows.Forms.CheckBox();
            this.vlcControlsGroupBox = new System.Windows.Forms.GroupBox();
            this.flowLayoutPanel3 = new System.Windows.Forms.FlowLayoutPanel();
            this.currentVlcLocationLabel = new System.Windows.Forms.Label();
            this.locateVlcButton = new System.Windows.Forms.Button();
            this.duplicateSearchingAndThumbnailCacheGroupBox = new System.Windows.Forms.GroupBox();
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.thumbsStorageFlowLayoutPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.thumbsStorageSizeLabel = new System.Windows.Forms.Label();
            this.thumbsStorageInfoButton = new System.Windows.Forms.Button();
            this.thumbsStorageEmptyButton = new System.Windows.Forms.Button();
            this.thumbsStorageViewButton = new System.Windows.Forms.Button();
            this.viewLogsButton = new System.Windows.Forms.Button();
            this.tableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.panel1 = new System.Windows.Forms.Panel();
            this.contextMenuGroupBox = new System.Windows.Forms.GroupBox();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.toggleContextMenuOptionsButton = new System.Windows.Forms.Button();
            this.toggleContextMenuOptionsInfoButton = new System.Windows.Forms.Button();
            this.tagControlsGroupBox = new System.Windows.Forms.GroupBox();
            this.tagControlsFlowLayoutPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.manageTagsLibraryButton = new System.Windows.Forms.Button();
            this.tagSearchStartFlowLayoutPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.tagSearchNumeric = new System.Windows.Forms.NumericUpDown();
            this.tagSearchStartLabel = new System.Windows.Forms.Label();
            this.displayAllTagsCheckbox = new System.Windows.Forms.CheckBox();
            this.autoResetTagSearchCheckBox = new System.Windows.Forms.CheckBox();
            this.autoResetSubfolderSearchCheckBox = new System.Windows.Forms.CheckBox();
            this.miscControlsGroupBox.SuspendLayout();
            this.miscControlsFlowLayoutPanel.SuspendLayout();
            this.vlcControlsGroupBox.SuspendLayout();
            this.flowLayoutPanel3.SuspendLayout();
            this.duplicateSearchingAndThumbnailCacheGroupBox.SuspendLayout();
            this.flowLayoutPanel2.SuspendLayout();
            this.thumbsStorageFlowLayoutPanel.SuspendLayout();
            this.tableLayoutPanel.SuspendLayout();
            this.panel1.SuspendLayout();
            this.contextMenuGroupBox.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.tagControlsGroupBox.SuspendLayout();
            this.tagControlsFlowLayoutPanel.SuspendLayout();
            this.tagSearchStartFlowLayoutPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tagSearchNumeric)).BeginInit();
            this.SuspendLayout();
            // 
            // saveSettingsButton
            // 
            this.saveSettingsButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.saveSettingsButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.saveSettingsButton.Location = new System.Drawing.Point(10, 450);
            this.saveSettingsButton.Name = "saveSettingsButton";
            this.saveSettingsButton.Size = new System.Drawing.Size(406, 23);
            this.saveSettingsButton.TabIndex = 1;
            this.saveSettingsButton.Text = "Save Settings";
            this.saveSettingsButton.UseVisualStyleBackColor = true;
            this.saveSettingsButton.Click += new System.EventHandler(this.saveSettingsButton_Click);
            // 
            // websiteButton
            // 
            this.websiteButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.websiteButton.Location = new System.Drawing.Point(0, 0);
            this.websiteButton.Margin = new System.Windows.Forms.Padding(0, 0, 2, 0);
            this.websiteButton.Name = "websiteButton";
            this.websiteButton.Size = new System.Drawing.Size(201, 23);
            this.websiteButton.TabIndex = 2;
            this.websiteButton.Text = "Website (GitHub)";
            this.websiteButton.UseVisualStyleBackColor = true;
            this.websiteButton.Click += new System.EventHandler(this.websiteButton_Click);
            // 
            // miscControlsGroupBox
            // 
            this.miscControlsGroupBox.Controls.Add(this.miscControlsFlowLayoutPanel);
            this.miscControlsGroupBox.Dock = System.Windows.Forms.DockStyle.Top;
            this.miscControlsGroupBox.Location = new System.Drawing.Point(1, 282);
            this.miscControlsGroupBox.Name = "miscControlsGroupBox";
            this.miscControlsGroupBox.Size = new System.Drawing.Size(402, 65);
            this.miscControlsGroupBox.TabIndex = 11;
            this.miscControlsGroupBox.TabStop = false;
            this.miscControlsGroupBox.Text = "Misc";
            this.toolTip.SetToolTip(this.miscControlsGroupBox, "Miscellaneous options.");
            // 
            // miscControlsFlowLayoutPanel
            // 
            this.miscControlsFlowLayoutPanel.Controls.Add(this.moveSortedFilesCheckbox);
            this.miscControlsFlowLayoutPanel.Controls.Add(this.fastResizingCheckbox);
            this.miscControlsFlowLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.miscControlsFlowLayoutPanel.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.miscControlsFlowLayoutPanel.Location = new System.Drawing.Point(3, 16);
            this.miscControlsFlowLayoutPanel.Name = "miscControlsFlowLayoutPanel";
            this.miscControlsFlowLayoutPanel.Size = new System.Drawing.Size(396, 46);
            this.miscControlsFlowLayoutPanel.TabIndex = 8;
            // 
            // moveSortedFilesCheckbox
            // 
            this.moveSortedFilesCheckbox.AutoSize = true;
            this.moveSortedFilesCheckbox.Location = new System.Drawing.Point(3, 3);
            this.moveSortedFilesCheckbox.Name = "moveSortedFilesCheckbox";
            this.moveSortedFilesCheckbox.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.moveSortedFilesCheckbox.Size = new System.Drawing.Size(266, 17);
            this.moveSortedFilesCheckbox.TabIndex = 0;
            this.moveSortedFilesCheckbox.Text = "Move sorted files to \'Sorted\' folder in open directory";
            this.toolTip.SetToolTip(this.moveSortedFilesCheckbox, resources.GetString("moveSortedFilesCheckbox.ToolTip"));
            this.moveSortedFilesCheckbox.UseVisualStyleBackColor = true;
            // 
            // fastResizingCheckbox
            // 
            this.fastResizingCheckbox.AutoSize = true;
            this.fastResizingCheckbox.Location = new System.Drawing.Point(3, 26);
            this.fastResizingCheckbox.Name = "fastResizingCheckbox";
            this.fastResizingCheckbox.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.fastResizingCheckbox.Size = new System.Drawing.Size(84, 17);
            this.fastResizingCheckbox.TabIndex = 7;
            this.fastResizingCheckbox.Text = "Fast resizing";
            this.toolTip.SetToolTip(this.fastResizingCheckbox, "Allows the program to lag less and resize faster by not redrawing all elements un" +
        "til the resizing is finished.");
            this.fastResizingCheckbox.UseVisualStyleBackColor = true;
            // 
            // vlcControlsGroupBox
            // 
            this.vlcControlsGroupBox.Controls.Add(this.flowLayoutPanel3);
            this.vlcControlsGroupBox.Dock = System.Windows.Forms.DockStyle.Top;
            this.vlcControlsGroupBox.Location = new System.Drawing.Point(1, 214);
            this.vlcControlsGroupBox.Name = "vlcControlsGroupBox";
            this.vlcControlsGroupBox.Size = new System.Drawing.Size(402, 68);
            this.vlcControlsGroupBox.TabIndex = 13;
            this.vlcControlsGroupBox.TabStop = false;
            this.vlcControlsGroupBox.Text = "VLC Location ❓";
            this.toolTip.SetToolTip(this.vlcControlsGroupBox, "SorterExpress relies on VLC libraries in order to support video playback. \r\nOptio" +
        "ns in this section allow you to manage this.");
            // 
            // flowLayoutPanel3
            // 
            this.flowLayoutPanel3.Controls.Add(this.currentVlcLocationLabel);
            this.flowLayoutPanel3.Controls.Add(this.locateVlcButton);
            this.flowLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel3.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanel3.Location = new System.Drawing.Point(3, 16);
            this.flowLayoutPanel3.Name = "flowLayoutPanel3";
            this.flowLayoutPanel3.Size = new System.Drawing.Size(396, 49);
            this.flowLayoutPanel3.TabIndex = 0;
            // 
            // currentVlcLocationLabel
            // 
            this.currentVlcLocationLabel.AutoSize = true;
            this.currentVlcLocationLabel.Location = new System.Drawing.Point(3, 3);
            this.currentVlcLocationLabel.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
            this.currentVlcLocationLabel.Name = "currentVlcLocationLabel";
            this.currentVlcLocationLabel.Size = new System.Drawing.Size(111, 13);
            this.currentVlcLocationLabel.TabIndex = 0;
            this.currentVlcLocationLabel.Text = "Current VLC Location:";
            // 
            // locateVlcButton
            // 
            this.locateVlcButton.Location = new System.Drawing.Point(3, 19);
            this.locateVlcButton.Name = "locateVlcButton";
            this.locateVlcButton.Size = new System.Drawing.Size(111, 23);
            this.locateVlcButton.TabIndex = 2;
            this.locateVlcButton.Text = "Locate";
            this.locateVlcButton.UseVisualStyleBackColor = true;
            this.locateVlcButton.Click += new System.EventHandler(this.locateVlcButton_Click);
            // 
            // duplicateSearchingAndThumbnailCacheGroupBox
            // 
            this.duplicateSearchingAndThumbnailCacheGroupBox.Controls.Add(this.flowLayoutPanel2);
            this.duplicateSearchingAndThumbnailCacheGroupBox.Dock = System.Windows.Forms.DockStyle.Top;
            this.duplicateSearchingAndThumbnailCacheGroupBox.Location = new System.Drawing.Point(1, 156);
            this.duplicateSearchingAndThumbnailCacheGroupBox.Name = "duplicateSearchingAndThumbnailCacheGroupBox";
            this.duplicateSearchingAndThumbnailCacheGroupBox.Size = new System.Drawing.Size(402, 58);
            this.duplicateSearchingAndThumbnailCacheGroupBox.TabIndex = 12;
            this.duplicateSearchingAndThumbnailCacheGroupBox.TabStop = false;
            this.duplicateSearchingAndThumbnailCacheGroupBox.Text = "Duplicate Searching / Thumbnail Cache ❓";
            this.toolTip.SetToolTip(this.duplicateSearchingAndThumbnailCacheGroupBox, resources.GetString("duplicateSearchingAndThumbnailCacheGroupBox.ToolTip"));
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.Controls.Add(this.thumbsStorageFlowLayoutPanel);
            this.flowLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel2.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanel2.Location = new System.Drawing.Point(3, 16);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Size = new System.Drawing.Size(396, 39);
            this.flowLayoutPanel2.TabIndex = 3;
            // 
            // thumbsStorageFlowLayoutPanel
            // 
            this.thumbsStorageFlowLayoutPanel.Controls.Add(this.thumbsStorageSizeLabel);
            this.thumbsStorageFlowLayoutPanel.Controls.Add(this.thumbsStorageInfoButton);
            this.thumbsStorageFlowLayoutPanel.Controls.Add(this.thumbsStorageEmptyButton);
            this.thumbsStorageFlowLayoutPanel.Controls.Add(this.thumbsStorageViewButton);
            this.thumbsStorageFlowLayoutPanel.Location = new System.Drawing.Point(3, 3);
            this.thumbsStorageFlowLayoutPanel.Name = "thumbsStorageFlowLayoutPanel";
            this.thumbsStorageFlowLayoutPanel.Padding = new System.Windows.Forms.Padding(3, 2, 3, 3);
            this.thumbsStorageFlowLayoutPanel.Size = new System.Drawing.Size(388, 33);
            this.thumbsStorageFlowLayoutPanel.TabIndex = 0;
            // 
            // thumbsStorageSizeLabel
            // 
            this.thumbsStorageSizeLabel.AutoSize = true;
            this.thumbsStorageSizeLabel.Location = new System.Drawing.Point(6, 10);
            this.thumbsStorageSizeLabel.Margin = new System.Windows.Forms.Padding(3, 8, 3, 0);
            this.thumbsStorageSizeLabel.Name = "thumbsStorageSizeLabel";
            this.thumbsStorageSizeLabel.Size = new System.Drawing.Size(141, 13);
            this.thumbsStorageSizeLabel.TabIndex = 0;
            this.thumbsStorageSizeLabel.Text = "Thumbs Storage Size: 0 Mb ";
            // 
            // thumbsStorageInfoButton
            // 
            this.thumbsStorageInfoButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.thumbsStorageInfoButton.Location = new System.Drawing.Point(153, 5);
            this.thumbsStorageInfoButton.Name = "thumbsStorageInfoButton";
            this.thumbsStorageInfoButton.Size = new System.Drawing.Size(90, 23);
            this.thumbsStorageInfoButton.TabIndex = 1;
            this.thumbsStorageInfoButton.Text = "What\'s This?";
            this.thumbsStorageInfoButton.UseVisualStyleBackColor = true;
            this.thumbsStorageInfoButton.Click += new System.EventHandler(this.thumbsStorageInfoButton_Click);
            // 
            // thumbsStorageEmptyButton
            // 
            this.thumbsStorageEmptyButton.Location = new System.Drawing.Point(249, 5);
            this.thumbsStorageEmptyButton.Name = "thumbsStorageEmptyButton";
            this.thumbsStorageEmptyButton.Size = new System.Drawing.Size(60, 23);
            this.thumbsStorageEmptyButton.TabIndex = 2;
            this.thumbsStorageEmptyButton.Text = "Empty";
            this.thumbsStorageEmptyButton.UseVisualStyleBackColor = true;
            this.thumbsStorageEmptyButton.Click += new System.EventHandler(this.thumbsStorageEmptyButton_Click);
            // 
            // thumbsStorageViewButton
            // 
            this.thumbsStorageViewButton.Location = new System.Drawing.Point(315, 5);
            this.thumbsStorageViewButton.Name = "thumbsStorageViewButton";
            this.thumbsStorageViewButton.Size = new System.Drawing.Size(57, 23);
            this.thumbsStorageViewButton.TabIndex = 3;
            this.thumbsStorageViewButton.Text = "View";
            this.thumbsStorageViewButton.UseVisualStyleBackColor = true;
            this.thumbsStorageViewButton.Click += new System.EventHandler(this.thumbsStorageViewButton_Click);
            // 
            // viewLogsButton
            // 
            this.viewLogsButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.viewLogsButton.Location = new System.Drawing.Point(205, 0);
            this.viewLogsButton.Margin = new System.Windows.Forms.Padding(2, 0, 0, 0);
            this.viewLogsButton.Name = "viewLogsButton";
            this.viewLogsButton.Size = new System.Drawing.Size(201, 23);
            this.viewLogsButton.TabIndex = 3;
            this.viewLogsButton.Text = "View Logs";
            this.viewLogsButton.UseVisualStyleBackColor = true;
            this.viewLogsButton.Click += new System.EventHandler(this.ViewLogsButton_Click);
            // 
            // tableLayoutPanel
            // 
            this.tableLayoutPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel.ColumnCount = 2;
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel.Controls.Add(this.viewLogsButton, 1, 0);
            this.tableLayoutPanel.Controls.Add(this.websiteButton, 0, 0);
            this.tableLayoutPanel.Location = new System.Drawing.Point(10, 424);
            this.tableLayoutPanel.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel.Name = "tableLayoutPanel";
            this.tableLayoutPanel.RowCount = 1;
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel.Size = new System.Drawing.Size(406, 23);
            this.tableLayoutPanel.TabIndex = 4;
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.AutoScroll = true;
            this.panel1.Controls.Add(this.contextMenuGroupBox);
            this.panel1.Controls.Add(this.miscControlsGroupBox);
            this.panel1.Controls.Add(this.vlcControlsGroupBox);
            this.panel1.Controls.Add(this.duplicateSearchingAndThumbnailCacheGroupBox);
            this.panel1.Controls.Add(this.tagControlsGroupBox);
            this.panel1.Location = new System.Drawing.Point(10, 12);
            this.panel1.Name = "panel1";
            this.panel1.Padding = new System.Windows.Forms.Padding(1, 1, 3, 0);
            this.panel1.Size = new System.Drawing.Size(406, 410);
            this.panel1.TabIndex = 7;
            // 
            // contextMenuGroupBox
            // 
            this.contextMenuGroupBox.Controls.Add(this.flowLayoutPanel1);
            this.contextMenuGroupBox.Dock = System.Windows.Forms.DockStyle.Top;
            this.contextMenuGroupBox.Location = new System.Drawing.Point(1, 347);
            this.contextMenuGroupBox.Name = "contextMenuGroupBox";
            this.contextMenuGroupBox.Size = new System.Drawing.Size(402, 50);
            this.contextMenuGroupBox.TabIndex = 14;
            this.contextMenuGroupBox.TabStop = false;
            this.contextMenuGroupBox.Text = "Windows Context Menu Options";
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.toggleContextMenuOptionsButton);
            this.flowLayoutPanel1.Controls.Add(this.toggleContextMenuOptionsInfoButton);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(3, 16);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Padding = new System.Windows.Forms.Padding(1);
            this.flowLayoutPanel1.Size = new System.Drawing.Size(396, 31);
            this.flowLayoutPanel1.TabIndex = 9;
            // 
            // toggleContextMenuOptionsButton
            // 
            this.toggleContextMenuOptionsButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F);
            this.toggleContextMenuOptionsButton.Location = new System.Drawing.Point(4, 4);
            this.toggleContextMenuOptionsButton.Name = "toggleContextMenuOptionsButton";
            this.toggleContextMenuOptionsButton.Size = new System.Drawing.Size(245, 23);
            this.toggleContextMenuOptionsButton.TabIndex = 1;
            this.toggleContextMenuOptionsButton.Text = "Add Context Menu Options To Windows";
            this.toggleContextMenuOptionsButton.UseVisualStyleBackColor = true;
            this.toggleContextMenuOptionsButton.Click += new System.EventHandler(this.toggleContextMenuOptionsButton_Click);
            // 
            // toggleContextMenuOptionsInfoButton
            // 
            this.toggleContextMenuOptionsInfoButton.Location = new System.Drawing.Point(255, 4);
            this.toggleContextMenuOptionsInfoButton.Name = "toggleContextMenuOptionsInfoButton";
            this.toggleContextMenuOptionsInfoButton.Size = new System.Drawing.Size(81, 23);
            this.toggleContextMenuOptionsInfoButton.TabIndex = 2;
            this.toggleContextMenuOptionsInfoButton.Text = "What\'s This?";
            this.toggleContextMenuOptionsInfoButton.UseVisualStyleBackColor = true;
            this.toggleContextMenuOptionsInfoButton.Click += new System.EventHandler(this.toggleContextMenuOptionsInfoButton_Click);
            // 
            // tagControlsGroupBox
            // 
            this.tagControlsGroupBox.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tagControlsGroupBox.Controls.Add(this.tagControlsFlowLayoutPanel);
            this.tagControlsGroupBox.Dock = System.Windows.Forms.DockStyle.Top;
            this.tagControlsGroupBox.Location = new System.Drawing.Point(1, 1);
            this.tagControlsGroupBox.Name = "tagControlsGroupBox";
            this.tagControlsGroupBox.Size = new System.Drawing.Size(402, 155);
            this.tagControlsGroupBox.TabIndex = 15;
            this.tagControlsGroupBox.TabStop = false;
            this.tagControlsGroupBox.Text = "Tags ❓";
            this.toolTip.SetToolTip(this.tagControlsGroupBox, "Options related to the in built tag collection.");
            // 
            // tagControlsFlowLayoutPanel
            // 
            this.tagControlsFlowLayoutPanel.Controls.Add(this.manageTagsLibraryButton);
            this.tagControlsFlowLayoutPanel.Controls.Add(this.tagSearchStartFlowLayoutPanel);
            this.tagControlsFlowLayoutPanel.Controls.Add(this.displayAllTagsCheckbox);
            this.tagControlsFlowLayoutPanel.Controls.Add(this.autoResetTagSearchCheckBox);
            this.tagControlsFlowLayoutPanel.Controls.Add(this.autoResetSubfolderSearchCheckBox);
            this.tagControlsFlowLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tagControlsFlowLayoutPanel.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.tagControlsFlowLayoutPanel.Location = new System.Drawing.Point(3, 16);
            this.tagControlsFlowLayoutPanel.Name = "tagControlsFlowLayoutPanel";
            this.tagControlsFlowLayoutPanel.Padding = new System.Windows.Forms.Padding(3);
            this.tagControlsFlowLayoutPanel.Size = new System.Drawing.Size(396, 136);
            this.tagControlsFlowLayoutPanel.TabIndex = 4;
            // 
            // manageTagsLibraryButton
            // 
            this.manageTagsLibraryButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.manageTagsLibraryButton.Location = new System.Drawing.Point(6, 6);
            this.manageTagsLibraryButton.Name = "manageTagsLibraryButton";
            this.manageTagsLibraryButton.Size = new System.Drawing.Size(365, 25);
            this.manageTagsLibraryButton.TabIndex = 3;
            this.manageTagsLibraryButton.Text = "Manage Tag Library";
            this.manageTagsLibraryButton.UseVisualStyleBackColor = true;
            this.manageTagsLibraryButton.Click += new System.EventHandler(this.manageTagLibraryButton_Click);
            // 
            // tagSearchStartFlowLayoutPanel
            // 
            this.tagSearchStartFlowLayoutPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tagSearchStartFlowLayoutPanel.Controls.Add(this.tagSearchNumeric);
            this.tagSearchStartFlowLayoutPanel.Controls.Add(this.tagSearchStartLabel);
            this.tagSearchStartFlowLayoutPanel.Location = new System.Drawing.Point(3, 34);
            this.tagSearchStartFlowLayoutPanel.Margin = new System.Windows.Forms.Padding(0);
            this.tagSearchStartFlowLayoutPanel.Name = "tagSearchStartFlowLayoutPanel";
            this.tagSearchStartFlowLayoutPanel.Size = new System.Drawing.Size(371, 27);
            this.tagSearchStartFlowLayoutPanel.TabIndex = 8;
            // 
            // tagSearchNumeric
            // 
            this.tagSearchNumeric.Location = new System.Drawing.Point(3, 3);
            this.tagSearchNumeric.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
            this.tagSearchNumeric.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.tagSearchNumeric.Name = "tagSearchNumeric";
            this.tagSearchNumeric.Size = new System.Drawing.Size(46, 20);
            this.tagSearchNumeric.TabIndex = 6;
            this.tagSearchNumeric.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // tagSearchStartLabel
            // 
            this.tagSearchStartLabel.AutoSize = true;
            this.tagSearchStartLabel.Location = new System.Drawing.Point(55, 6);
            this.tagSearchStartLabel.Margin = new System.Windows.Forms.Padding(3, 6, 3, 0);
            this.tagSearchStartLabel.Name = "tagSearchStartLabel";
            this.tagSearchStartLabel.Size = new System.Drawing.Size(226, 13);
            this.tagSearchStartLabel.TabIndex = 5;
            this.tagSearchStartLabel.Text = "Begin tag searching at X amount of characters";
            this.toolTip.SetToolTip(this.tagSearchStartLabel, "Searching tags will only begin once X amount of characters have been input. Can b" +
        "e useful to increase program speed.");
            // 
            // displayAllTagsCheckbox
            // 
            this.displayAllTagsCheckbox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.displayAllTagsCheckbox.AutoSize = true;
            this.displayAllTagsCheckbox.Location = new System.Drawing.Point(6, 64);
            this.displayAllTagsCheckbox.Name = "displayAllTagsCheckbox";
            this.displayAllTagsCheckbox.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.displayAllTagsCheckbox.Size = new System.Drawing.Size(365, 17);
            this.displayAllTagsCheckbox.TabIndex = 0;
            this.displayAllTagsCheckbox.Text = "Display all tags when search box is empty (Can be slow with alot of tags)\r\n";
            this.displayAllTagsCheckbox.UseVisualStyleBackColor = true;
            // 
            // autoResetTagSearchCheckBox
            // 
            this.autoResetTagSearchCheckBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.autoResetTagSearchCheckBox.AutoSize = true;
            this.autoResetTagSearchCheckBox.Location = new System.Drawing.Point(6, 87);
            this.autoResetTagSearchCheckBox.Name = "autoResetTagSearchCheckBox";
            this.autoResetTagSearchCheckBox.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.autoResetTagSearchCheckBox.Size = new System.Drawing.Size(365, 17);
            this.autoResetTagSearchCheckBox.TabIndex = 0;
            this.autoResetTagSearchCheckBox.Text = "Automatically empty tag search box when a tag is toggled on or off";
            this.autoResetTagSearchCheckBox.UseVisualStyleBackColor = true;
            // 
            // autoResetSubfolderSearchCheckBox
            // 
            this.autoResetSubfolderSearchCheckBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.autoResetSubfolderSearchCheckBox.AutoSize = true;
            this.autoResetSubfolderSearchCheckBox.Location = new System.Drawing.Point(6, 110);
            this.autoResetSubfolderSearchCheckBox.Name = "autoResetSubfolderSearchCheckBox";
            this.autoResetSubfolderSearchCheckBox.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.autoResetSubfolderSearchCheckBox.Size = new System.Drawing.Size(365, 17);
            this.autoResetSubfolderSearchCheckBox.TabIndex = 9;
            this.autoResetSubfolderSearchCheckBox.Text = "Automatically empty subfolder search box when a subfolder is selected";
            this.autoResetSubfolderSearchCheckBox.UseVisualStyleBackColor = true;
            // 
            // SettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(424, 482);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.tableLayoutPanel);
            this.Controls.Add(this.saveSettingsButton);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(422, 39);
            this.Name = "SettingsForm";
            this.Text = "Sorter Express - Settings";
            this.Shown += new System.EventHandler(this.SettingsForm_Shown);
            this.miscControlsGroupBox.ResumeLayout(false);
            this.miscControlsFlowLayoutPanel.ResumeLayout(false);
            this.miscControlsFlowLayoutPanel.PerformLayout();
            this.vlcControlsGroupBox.ResumeLayout(false);
            this.flowLayoutPanel3.ResumeLayout(false);
            this.flowLayoutPanel3.PerformLayout();
            this.duplicateSearchingAndThumbnailCacheGroupBox.ResumeLayout(false);
            this.flowLayoutPanel2.ResumeLayout(false);
            this.thumbsStorageFlowLayoutPanel.ResumeLayout(false);
            this.thumbsStorageFlowLayoutPanel.PerformLayout();
            this.tableLayoutPanel.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.contextMenuGroupBox.ResumeLayout(false);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.tagControlsGroupBox.ResumeLayout(false);
            this.tagControlsFlowLayoutPanel.ResumeLayout(false);
            this.tagControlsFlowLayoutPanel.PerformLayout();
            this.tagSearchStartFlowLayoutPanel.ResumeLayout(false);
            this.tagSearchStartFlowLayoutPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tagSearchNumeric)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button saveSettingsButton;
        private System.Windows.Forms.Button websiteButton;
        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.Button viewLogsButton;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.GroupBox miscControlsGroupBox;
        private System.Windows.Forms.FlowLayoutPanel miscControlsFlowLayoutPanel;
        private System.Windows.Forms.CheckBox moveSortedFilesCheckbox;
        private System.Windows.Forms.CheckBox fastResizingCheckbox;
        private System.Windows.Forms.GroupBox vlcControlsGroupBox;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel3;
        private System.Windows.Forms.Label currentVlcLocationLabel;
        private System.Windows.Forms.Button locateVlcButton;
        private System.Windows.Forms.GroupBox duplicateSearchingAndThumbnailCacheGroupBox;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
        private System.Windows.Forms.FlowLayoutPanel thumbsStorageFlowLayoutPanel;
        private System.Windows.Forms.Label thumbsStorageSizeLabel;
        private System.Windows.Forms.Button thumbsStorageInfoButton;
        private System.Windows.Forms.Button thumbsStorageEmptyButton;
        private System.Windows.Forms.GroupBox contextMenuGroupBox;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Button toggleContextMenuOptionsButton;
        private System.Windows.Forms.Button toggleContextMenuOptionsInfoButton;
        private System.Windows.Forms.Button thumbsStorageViewButton;
        private System.Windows.Forms.GroupBox tagControlsGroupBox;
        private System.Windows.Forms.FlowLayoutPanel tagControlsFlowLayoutPanel;
        private System.Windows.Forms.Button manageTagsLibraryButton;
        private System.Windows.Forms.FlowLayoutPanel tagSearchStartFlowLayoutPanel;
        private System.Windows.Forms.NumericUpDown tagSearchNumeric;
        private System.Windows.Forms.Label tagSearchStartLabel;
        private System.Windows.Forms.CheckBox displayAllTagsCheckbox;
        private System.Windows.Forms.CheckBox autoResetTagSearchCheckBox;
        private System.Windows.Forms.CheckBox autoResetSubfolderSearchCheckBox;
    }
}