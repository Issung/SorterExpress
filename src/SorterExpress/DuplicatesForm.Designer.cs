using System;
using Vlc.DotNet.Forms;

namespace SorterExpress
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
            this.pictureBoxRight = new System.Windows.Forms.PictureBox();
            this.keepRightButton = new System.Windows.Forms.Button();
            this.keepLeftButton = new System.Windows.Forms.Button();
            this.keepBothButton = new System.Windows.Forms.Button();
            this.openDirectoryButton = new System.Windows.Forms.Button();
            this.matchesListBox = new System.Windows.Forms.ListBox();
            this.similarityNumeric = new System.Windows.Forms.NumericUpDown();
            this.similarityLabel = new System.Windows.Forms.Label();
            this.percentageLabel = new System.Windows.Forms.Label();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.infoRichTextBoxLeft = new System.Windows.Forms.RichTextBox();
            this.infoRichTextBoxRight = new System.Windows.Forms.RichTextBox();
            this.muteButtonLeft = new System.Windows.Forms.Button();
            this.videoPlayButtonLeft = new System.Windows.Forms.Button();
            this.videoPauseButtonLeft = new System.Windows.Forms.Button();
            this.muteButtonRight = new System.Windows.Forms.Button();
            this.videoPlayButtonRight = new System.Windows.Forms.Button();
            this.videoPauseButtonRight = new System.Windows.Forms.Button();
            this.searchButton = new System.Windows.Forms.Button();
            this.imagesCheckBox = new System.Windows.Forms.CheckBox();
            this.videosCheckBox = new System.Windows.Forms.CheckBox();
            this.threadCountNumeric = new System.Windows.Forms.NumericUpDown();
            this.cancelButton = new System.Windows.Forms.Button();
            this.searchSubfoldersCheckBox = new System.Windows.Forms.CheckBox();
            this.loadingLabel = new System.Windows.Forms.Label();
            this.filenameRichTextBoxLeft = new System.Windows.Forms.RichTextBox();
            this.filenameRichTextBoxRight = new System.Windows.Forms.RichTextBox();
            this.sidesLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.leftPanel = new System.Windows.Forms.Panel();
            this.videoPanelLeft = new System.Windows.Forms.Panel();
            this.videoControlsTableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.volumeTrackBarLeft = new EConTech.Windows.MACUI.MACTrackBar();
            this.videoPositionTrackBarLeft = new SorterExpress.VideoPositionTrackBar();
            this.pictureBoxLeft = new System.Windows.Forms.PictureBox();
            this.rightPanel = new System.Windows.Forms.Panel();
            this.videoPanelRight = new System.Windows.Forms.Panel();
            this.tableLayoutPanel3 = new System.Windows.Forms.TableLayoutPanel();
            this.volumeTrackBarRight = new EConTech.Windows.MACUI.MACTrackBar();
            this.videoPositionTrackBarRight = new SorterExpress.VideoPositionTrackBar();
            this.keepButtonsLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.label1 = new System.Windows.Forms.Label();
            this.fileCountLabel = new System.Windows.Forms.Label();
            this.keepNeitherButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxRight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.similarityNumeric)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.threadCountNumeric)).BeginInit();
            this.sidesLayoutPanel.SuspendLayout();
            this.leftPanel.SuspendLayout();
            this.videoPanelLeft.SuspendLayout();
            this.videoControlsTableLayoutPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxLeft)).BeginInit();
            this.rightPanel.SuspendLayout();
            this.videoPanelRight.SuspendLayout();
            this.tableLayoutPanel3.SuspendLayout();
            this.keepButtonsLayoutPanel.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBoxRight
            // 
            this.pictureBoxRight.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBoxRight.InitialImage = ((System.Drawing.Image)(resources.GetObject("pictureBoxRight.InitialImage")));
            this.pictureBoxRight.Location = new System.Drawing.Point(116, 0);
            this.pictureBoxRight.Margin = new System.Windows.Forms.Padding(10);
            this.pictureBoxRight.Name = "pictureBoxRight";
            this.pictureBoxRight.Size = new System.Drawing.Size(226, 257);
            this.pictureBoxRight.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxRight.TabIndex = 2;
            this.pictureBoxRight.TabStop = false;
            // 
            // keepRightButton
            // 
            this.keepRightButton.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.keepRightButton.Location = new System.Drawing.Point(345, 0);
            this.keepRightButton.Margin = new System.Windows.Forms.Padding(2, 0, 0, 0);
            this.keepRightButton.MaximumSize = new System.Drawing.Size(0, 23);
            this.keepRightButton.Name = "keepRightButton";
            this.keepRightButton.Size = new System.Drawing.Size(341, 23);
            this.keepRightButton.TabIndex = 4;
            this.keepRightButton.Text = "Keep This (Delete Left)";
            this.keepRightButton.UseVisualStyleBackColor = true;
            this.keepRightButton.Click += new System.EventHandler(this.KeepRightButton_Click);
            // 
            // keepLeftButton
            // 
            this.keepLeftButton.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.keepLeftButton.Location = new System.Drawing.Point(0, 0);
            this.keepLeftButton.Margin = new System.Windows.Forms.Padding(0, 0, 2, 0);
            this.keepLeftButton.MaximumSize = new System.Drawing.Size(0, 23);
            this.keepLeftButton.Name = "keepLeftButton";
            this.keepLeftButton.Size = new System.Drawing.Size(341, 23);
            this.keepLeftButton.TabIndex = 5;
            this.keepLeftButton.Text = "Keep This (Delete Right)";
            this.keepLeftButton.UseVisualStyleBackColor = true;
            this.keepLeftButton.Click += new System.EventHandler(this.KeepLeftButton_Click);
            // 
            // keepBothButton
            // 
            this.keepBothButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.keepBothButton.Location = new System.Drawing.Point(198, 353);
            this.keepBothButton.Name = "keepBothButton";
            this.keepBothButton.Size = new System.Drawing.Size(686, 23);
            this.keepBothButton.TabIndex = 6;
            this.keepBothButton.Text = "Keep Both (Skip)";
            this.keepBothButton.UseVisualStyleBackColor = true;
            this.keepBothButton.Click += new System.EventHandler(this.KeepBothButton_Click);
            // 
            // openDirectoryButton
            // 
            this.openDirectoryButton.Location = new System.Drawing.Point(12, 12);
            this.openDirectoryButton.Name = "openDirectoryButton";
            this.openDirectoryButton.Size = new System.Drawing.Size(180, 23);
            this.openDirectoryButton.TabIndex = 0;
            this.openDirectoryButton.Text = "Open Directory";
            this.openDirectoryButton.UseVisualStyleBackColor = true;
            this.openDirectoryButton.Click += new System.EventHandler(this.OpenDirectoryButton_Click);
            // 
            // matchesListBox
            // 
            this.matchesListBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.matchesListBox.FormattingEnabled = true;
            this.matchesListBox.IntegralHeight = false;
            this.matchesListBox.Location = new System.Drawing.Point(11, 182);
            this.matchesListBox.Name = "matchesListBox";
            this.matchesListBox.Size = new System.Drawing.Size(181, 217);
            this.matchesListBox.TabIndex = 8;
            this.matchesListBox.SelectedIndexChanged += new System.EventHandler(this.matchesListBox_SelectedIndexChanged);
            // 
            // similarityNumeric
            // 
            this.similarityNumeric.DecimalPlaces = 1;
            this.similarityNumeric.Enabled = false;
            this.similarityNumeric.Location = new System.Drawing.Point(64, 107);
            this.similarityNumeric.Name = "similarityNumeric";
            this.similarityNumeric.Size = new System.Drawing.Size(63, 20);
            this.similarityNumeric.TabIndex = 9;
            this.similarityNumeric.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.toolTip.SetToolTip(this.similarityNumeric, "Images searched must have a similarity chance of this or above to be considered a" +
        " duplicate. \r\n85% or above is reccomended.");
            this.similarityNumeric.Value = new decimal(new int[] {
            90,
            0,
            0,
            0});
            // 
            // similarityLabel
            // 
            this.similarityLabel.AutoSize = true;
            this.similarityLabel.Location = new System.Drawing.Point(12, 110);
            this.similarityLabel.Name = "similarityLabel";
            this.similarityLabel.Size = new System.Drawing.Size(53, 13);
            this.similarityLabel.TabIndex = 10;
            this.similarityLabel.Text = "Similarity: ";
            // 
            // percentageLabel
            // 
            this.percentageLabel.AutoSize = true;
            this.percentageLabel.Location = new System.Drawing.Point(129, 110);
            this.percentageLabel.Name = "percentageLabel";
            this.percentageLabel.Size = new System.Drawing.Size(60, 13);
            this.percentageLabel.TabIndex = 11;
            this.percentageLabel.Text = "% or above";
            // 
            // infoRichTextBoxLeft
            // 
            this.infoRichTextBoxLeft.Dock = System.Windows.Forms.DockStyle.Left;
            this.infoRichTextBoxLeft.Enabled = false;
            this.infoRichTextBoxLeft.Location = new System.Drawing.Point(0, 0);
            this.infoRichTextBoxLeft.Margin = new System.Windows.Forms.Padding(10);
            this.infoRichTextBoxLeft.Name = "infoRichTextBoxLeft";
            this.infoRichTextBoxLeft.Size = new System.Drawing.Size(100, 256);
            this.infoRichTextBoxLeft.TabIndex = 3;
            this.infoRichTextBoxLeft.Text = "";
            this.toolTip.SetToolTip(this.infoRichTextBoxLeft, "A tag in bold indicates it is not on the other file.\r\nTags may not be actual tags" +
        ".");
            // 
            // infoRichTextBoxRight
            // 
            this.infoRichTextBoxRight.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.infoRichTextBoxRight.Enabled = false;
            this.infoRichTextBoxRight.Location = new System.Drawing.Point(10, 0);
            this.infoRichTextBoxRight.Margin = new System.Windows.Forms.Padding(10, 0, 10, 0);
            this.infoRichTextBoxRight.Name = "infoRichTextBoxRight";
            this.infoRichTextBoxRight.Size = new System.Drawing.Size(100, 256);
            this.infoRichTextBoxRight.TabIndex = 3;
            this.infoRichTextBoxRight.Text = "";
            this.toolTip.SetToolTip(this.infoRichTextBoxRight, "A tag in bold indicates it is not on the other file.\r\nTags may not be actual tags" +
        ".");
            // 
            // muteButtonLeft
            // 
            this.muteButtonLeft.Dock = System.Windows.Forms.DockStyle.Fill;
            this.muteButtonLeft.Enabled = false;
            this.muteButtonLeft.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.muteButtonLeft.Location = new System.Drawing.Point(150, 0);
            this.muteButtonLeft.Margin = new System.Windows.Forms.Padding(0);
            this.muteButtonLeft.Name = "muteButtonLeft";
            this.muteButtonLeft.Size = new System.Drawing.Size(76, 23);
            this.muteButtonLeft.TabIndex = 0;
            this.muteButtonLeft.TabStop = false;
            this.muteButtonLeft.Text = "🔊";
            this.toolTip.SetToolTip(this.muteButtonLeft, "Mute video");
            this.muteButtonLeft.UseVisualStyleBackColor = true;
            // 
            // videoPlayButtonLeft
            // 
            this.videoPlayButtonLeft.Dock = System.Windows.Forms.DockStyle.Fill;
            this.videoPlayButtonLeft.Location = new System.Drawing.Point(0, 0);
            this.videoPlayButtonLeft.Margin = new System.Windows.Forms.Padding(0);
            this.videoPlayButtonLeft.Name = "videoPlayButtonLeft";
            this.videoPlayButtonLeft.Size = new System.Drawing.Size(75, 23);
            this.videoPlayButtonLeft.TabIndex = 0;
            this.videoPlayButtonLeft.TabStop = false;
            this.videoPlayButtonLeft.Text = "▶";
            this.toolTip.SetToolTip(this.videoPlayButtonLeft, "Resume Video Play");
            this.videoPlayButtonLeft.UseVisualStyleBackColor = true;
            // 
            // videoPauseButtonLeft
            // 
            this.videoPauseButtonLeft.Dock = System.Windows.Forms.DockStyle.Fill;
            this.videoPauseButtonLeft.Location = new System.Drawing.Point(75, 0);
            this.videoPauseButtonLeft.Margin = new System.Windows.Forms.Padding(0);
            this.videoPauseButtonLeft.Name = "videoPauseButtonLeft";
            this.videoPauseButtonLeft.Size = new System.Drawing.Size(75, 23);
            this.videoPauseButtonLeft.TabIndex = 23;
            this.videoPauseButtonLeft.TabStop = false;
            this.videoPauseButtonLeft.Text = "❚❚";
            this.toolTip.SetToolTip(this.videoPauseButtonLeft, "Pause video play");
            this.videoPauseButtonLeft.UseVisualStyleBackColor = true;
            // 
            // muteButtonRight
            // 
            this.muteButtonRight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.muteButtonRight.Enabled = false;
            this.muteButtonRight.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.muteButtonRight.Location = new System.Drawing.Point(146, 0);
            this.muteButtonRight.Margin = new System.Windows.Forms.Padding(0);
            this.muteButtonRight.Name = "muteButtonRight";
            this.muteButtonRight.Size = new System.Drawing.Size(74, 23);
            this.muteButtonRight.TabIndex = 0;
            this.muteButtonRight.TabStop = false;
            this.muteButtonRight.Text = "🔊";
            this.toolTip.SetToolTip(this.muteButtonRight, "Mute video");
            this.muteButtonRight.UseVisualStyleBackColor = true;
            // 
            // videoPlayButtonRight
            // 
            this.videoPlayButtonRight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.videoPlayButtonRight.Location = new System.Drawing.Point(0, 0);
            this.videoPlayButtonRight.Margin = new System.Windows.Forms.Padding(0);
            this.videoPlayButtonRight.Name = "videoPlayButtonRight";
            this.videoPlayButtonRight.Size = new System.Drawing.Size(73, 23);
            this.videoPlayButtonRight.TabIndex = 0;
            this.videoPlayButtonRight.TabStop = false;
            this.videoPlayButtonRight.Text = "▶";
            this.toolTip.SetToolTip(this.videoPlayButtonRight, "Resume Video Play");
            this.videoPlayButtonRight.UseVisualStyleBackColor = true;
            // 
            // videoPauseButtonRight
            // 
            this.videoPauseButtonRight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.videoPauseButtonRight.Location = new System.Drawing.Point(73, 0);
            this.videoPauseButtonRight.Margin = new System.Windows.Forms.Padding(0);
            this.videoPauseButtonRight.Name = "videoPauseButtonRight";
            this.videoPauseButtonRight.Size = new System.Drawing.Size(73, 23);
            this.videoPauseButtonRight.TabIndex = 23;
            this.videoPauseButtonRight.TabStop = false;
            this.videoPauseButtonRight.Text = "❚❚";
            this.toolTip.SetToolTip(this.videoPauseButtonRight, "Pause video play");
            this.videoPauseButtonRight.UseVisualStyleBackColor = true;
            // 
            // searchButton
            // 
            this.searchButton.Enabled = false;
            this.searchButton.Location = new System.Drawing.Point(10, 153);
            this.searchButton.Name = "searchButton";
            this.searchButton.Size = new System.Drawing.Size(117, 23);
            this.searchButton.TabIndex = 18;
            this.searchButton.Text = "Search";
            this.toolTip.SetToolTip(this.searchButton, "If you have changed the similarity threshold and wish to search the same director" +
        "y you have already selected once again you can click this button to do so.");
            this.searchButton.UseVisualStyleBackColor = true;
            this.searchButton.Click += new System.EventHandler(this.SearchButton_Click);
            // 
            // imagesCheckBox
            // 
            this.imagesCheckBox.AutoSize = true;
            this.imagesCheckBox.Checked = true;
            this.imagesCheckBox.CheckState = System.Windows.Forms.CheckState.Checked;
            this.imagesCheckBox.Enabled = false;
            this.imagesCheckBox.Location = new System.Drawing.Point(15, 61);
            this.imagesCheckBox.Name = "imagesCheckBox";
            this.imagesCheckBox.Size = new System.Drawing.Size(60, 17);
            this.imagesCheckBox.TabIndex = 20;
            this.imagesCheckBox.Text = "Images";
            this.toolTip.SetToolTip(this.imagesCheckBox, "Search image files for duplicates.");
            this.imagesCheckBox.UseVisualStyleBackColor = true;
            this.imagesCheckBox.CheckedChanged += new System.EventHandler(this.ImagesCheckBox_CheckedChanged);
            // 
            // videosCheckBox
            // 
            this.videosCheckBox.AutoSize = true;
            this.videosCheckBox.Enabled = false;
            this.videosCheckBox.Location = new System.Drawing.Point(79, 61);
            this.videosCheckBox.Name = "videosCheckBox";
            this.videosCheckBox.Size = new System.Drawing.Size(58, 17);
            this.videosCheckBox.TabIndex = 21;
            this.videosCheckBox.Text = "Videos";
            this.toolTip.SetToolTip(this.videosCheckBox, "Search video files for duplicates.\r\n");
            this.videosCheckBox.UseVisualStyleBackColor = true;
            this.videosCheckBox.CheckedChanged += new System.EventHandler(this.VideosCheckBox_CheckedChanged);
            // 
            // threadCountNumeric
            // 
            this.threadCountNumeric.Enabled = false;
            this.threadCountNumeric.Location = new System.Drawing.Point(64, 83);
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
        "he reccomended amount is your computer\'s CPU core count. There are diminishing r" +
        "eturns, results may vary.");
            this.threadCountNumeric.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            // 
            // cancelButton
            // 
            this.cancelButton.Enabled = false;
            this.cancelButton.Location = new System.Drawing.Point(132, 153);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(61, 23);
            this.cancelButton.TabIndex = 24;
            this.cancelButton.Text = "Cancel";
            this.toolTip.SetToolTip(this.cancelButton, "If you have changed the similarity threshold and wish to search the same director" +
        "y you have already selected once again you can click this button to do so.");
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.CancelButton_Click);
            // 
            // searchSubfoldersCheckBox
            // 
            this.searchSubfoldersCheckBox.AutoSize = true;
            this.searchSubfoldersCheckBox.Enabled = false;
            this.searchSubfoldersCheckBox.Location = new System.Drawing.Point(15, 40);
            this.searchSubfoldersCheckBox.Name = "searchSubfoldersCheckBox";
            this.searchSubfoldersCheckBox.Size = new System.Drawing.Size(111, 17);
            this.searchSubfoldersCheckBox.TabIndex = 26;
            this.searchSubfoldersCheckBox.Text = "Search subfolders";
            this.toolTip.SetToolTip(this.searchSubfoldersCheckBox, "Search recursively through subfolders for duplicates");
            this.searchSubfoldersCheckBox.UseVisualStyleBackColor = true;
            this.searchSubfoldersCheckBox.CheckedChanged += new System.EventHandler(this.SearchSubfoldersCheckBox_CheckedChanged);
            // 
            // loadingLabel
            // 
            this.loadingLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.loadingLabel.AutoSize = true;
            this.loadingLabel.BackColor = System.Drawing.Color.Transparent;
            this.loadingLabel.Location = new System.Drawing.Point(10, 375);
            this.loadingLabel.Name = "loadingLabel";
            this.loadingLabel.Size = new System.Drawing.Size(64, 13);
            this.loadingLabel.TabIndex = 12;
            this.loadingLabel.Text = "Searching...";
            this.loadingLabel.Visible = false;
            // 
            // filenameRichTextBoxLeft
            // 
            this.filenameRichTextBoxLeft.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.filenameRichTextBoxLeft.Enabled = false;
            this.filenameRichTextBoxLeft.Location = new System.Drawing.Point(0, 0);
            this.filenameRichTextBoxLeft.Margin = new System.Windows.Forms.Padding(0);
            this.filenameRichTextBoxLeft.Name = "filenameRichTextBoxLeft";
            this.filenameRichTextBoxLeft.Size = new System.Drawing.Size(343, 50);
            this.filenameRichTextBoxLeft.TabIndex = 13;
            this.filenameRichTextBoxLeft.Text = "";
            // 
            // filenameRichTextBoxRight
            // 
            this.filenameRichTextBoxRight.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.filenameRichTextBoxRight.Enabled = false;
            this.filenameRichTextBoxRight.Location = new System.Drawing.Point(353, 0);
            this.filenameRichTextBoxRight.Margin = new System.Windows.Forms.Padding(10, 0, 0, 0);
            this.filenameRichTextBoxRight.Name = "filenameRichTextBoxRight";
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
            this.sidesLayoutPanel.Size = new System.Drawing.Size(686, 256);
            this.sidesLayoutPanel.TabIndex = 15;
            // 
            // leftPanel
            // 
            this.leftPanel.Controls.Add(this.infoRichTextBoxLeft);
            this.leftPanel.Controls.Add(this.videoPanelLeft);
            this.leftPanel.Controls.Add(this.pictureBoxLeft);
            this.leftPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.leftPanel.Location = new System.Drawing.Point(0, 0);
            this.leftPanel.Margin = new System.Windows.Forms.Padding(0);
            this.leftPanel.Name = "leftPanel";
            this.leftPanel.Size = new System.Drawing.Size(343, 256);
            this.leftPanel.TabIndex = 5;
            // 
            // videoPanelLeft
            // 
            this.videoPanelLeft.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.videoPanelLeft.Controls.Add(this.videoControlsTableLayoutPanel);
            this.videoPanelLeft.Location = new System.Drawing.Point(115, 0);
            this.videoPanelLeft.Name = "videoPanelLeft";
            this.videoPanelLeft.Padding = new System.Windows.Forms.Padding(1, 1, 1, 0);
            this.videoPanelLeft.Size = new System.Drawing.Size(228, 256);
            this.videoPanelLeft.TabIndex = 47;
            // 
            // videoControlsTableLayoutPanel
            // 
            this.videoControlsTableLayoutPanel.ColumnCount = 3;
            this.videoControlsTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.videoControlsTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.videoControlsTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.videoControlsTableLayoutPanel.Controls.Add(this.volumeTrackBarLeft, 2, 1);
            this.videoControlsTableLayoutPanel.Controls.Add(this.muteButtonLeft, 2, 0);
            this.videoControlsTableLayoutPanel.Controls.Add(this.videoPlayButtonLeft, 0, 0);
            this.videoControlsTableLayoutPanel.Controls.Add(this.videoPauseButtonLeft, 1, 0);
            this.videoControlsTableLayoutPanel.Controls.Add(this.videoPositionTrackBarLeft, 0, 1);
            this.videoControlsTableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.videoControlsTableLayoutPanel.Location = new System.Drawing.Point(1, 202);
            this.videoControlsTableLayoutPanel.Margin = new System.Windows.Forms.Padding(0);
            this.videoControlsTableLayoutPanel.Name = "videoControlsTableLayoutPanel";
            this.videoControlsTableLayoutPanel.RowCount = 2;
            this.videoControlsTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 23F));
            this.videoControlsTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.videoControlsTableLayoutPanel.Size = new System.Drawing.Size(226, 54);
            this.videoControlsTableLayoutPanel.TabIndex = 24;
            // 
            // volumeTrackBarLeft
            // 
            this.volumeTrackBarLeft.BackColor = System.Drawing.Color.Transparent;
            this.volumeTrackBarLeft.BorderColor = System.Drawing.SystemColors.ActiveBorder;
            this.volumeTrackBarLeft.Dock = System.Windows.Forms.DockStyle.Fill;
            this.volumeTrackBarLeft.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.volumeTrackBarLeft.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(123)))), ((int)(((byte)(125)))), ((int)(((byte)(123)))));
            this.volumeTrackBarLeft.IndentHeight = 6;
            this.volumeTrackBarLeft.Location = new System.Drawing.Point(150, 26);
            this.volumeTrackBarLeft.Margin = new System.Windows.Forms.Padding(0, 3, 0, 3);
            this.volumeTrackBarLeft.Maximum = 100;
            this.volumeTrackBarLeft.Minimum = 0;
            this.volumeTrackBarLeft.Name = "volumeTrackBarLeft";
            this.volumeTrackBarLeft.Size = new System.Drawing.Size(76, 25);
            this.volumeTrackBarLeft.TabIndex = 0;
            this.volumeTrackBarLeft.TabStop = false;
            this.volumeTrackBarLeft.TextTickStyle = System.Windows.Forms.TickStyle.None;
            this.volumeTrackBarLeft.TickColor = System.Drawing.Color.FromArgb(((int)(((byte)(148)))), ((int)(((byte)(146)))), ((int)(((byte)(148)))));
            this.volumeTrackBarLeft.TickHeight = 1;
            this.volumeTrackBarLeft.TickStyle = System.Windows.Forms.TickStyle.None;
            this.volumeTrackBarLeft.TrackerColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(130)))), ((int)(((byte)(198)))));
            this.volumeTrackBarLeft.TrackerSize = new System.Drawing.Size(16, 16);
            this.volumeTrackBarLeft.TrackLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(93)))), ((int)(((byte)(90)))));
            this.volumeTrackBarLeft.TrackLineHeight = 3;
            this.volumeTrackBarLeft.Value = 1;
            // 
            // videoPositionTrackBarLeft
            // 
            this.videoPositionTrackBarLeft.BackColor = System.Drawing.Color.Transparent;
            this.videoPositionTrackBarLeft.BorderColor = System.Drawing.SystemColors.ActiveBorder;
            this.videoControlsTableLayoutPanel.SetColumnSpan(this.videoPositionTrackBarLeft, 2);
            this.videoPositionTrackBarLeft.Dock = System.Windows.Forms.DockStyle.Fill;
            this.videoPositionTrackBarLeft.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.videoPositionTrackBarLeft.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(123)))), ((int)(((byte)(125)))), ((int)(((byte)(123)))));
            this.videoPositionTrackBarLeft.IndentHeight = 6;
            this.videoPositionTrackBarLeft.Location = new System.Drawing.Point(3, 26);
            this.videoPositionTrackBarLeft.Maximum = 100;
            this.videoPositionTrackBarLeft.Minimum = 0;
            this.videoPositionTrackBarLeft.Name = "videoPositionTrackBarLeft";
            this.videoPositionTrackBarLeft.Size = new System.Drawing.Size(144, 25);
            this.videoPositionTrackBarLeft.TabIndex = 24;
            this.videoPositionTrackBarLeft.TickColor = System.Drawing.Color.FromArgb(((int)(((byte)(148)))), ((int)(((byte)(146)))), ((int)(((byte)(148)))));
            this.videoPositionTrackBarLeft.TickHeight = 4;
            this.videoPositionTrackBarLeft.TickStyle = System.Windows.Forms.TickStyle.None;
            this.videoPositionTrackBarLeft.TrackerColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(130)))), ((int)(((byte)(198)))));
            this.videoPositionTrackBarLeft.TrackerSize = new System.Drawing.Size(16, 16);
            this.videoPositionTrackBarLeft.TrackLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(93)))), ((int)(((byte)(90)))));
            this.videoPositionTrackBarLeft.TrackLineHeight = 3;
            this.videoPositionTrackBarLeft.Value = 0;
            // 
            // pictureBoxLeft
            // 
            this.pictureBoxLeft.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBoxLeft.InitialImage = ((System.Drawing.Image)(resources.GetObject("pictureBoxLeft.InitialImage")));
            this.pictureBoxLeft.Location = new System.Drawing.Point(110, 0);
            this.pictureBoxLeft.Margin = new System.Windows.Forms.Padding(0);
            this.pictureBoxLeft.Name = "pictureBoxLeft";
            this.pictureBoxLeft.Size = new System.Drawing.Size(233, 256);
            this.pictureBoxLeft.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxLeft.TabIndex = 2;
            this.pictureBoxLeft.TabStop = false;
            // 
            // rightPanel
            // 
            this.rightPanel.Controls.Add(this.infoRichTextBoxRight);
            this.rightPanel.Controls.Add(this.videoPanelRight);
            this.rightPanel.Controls.Add(this.pictureBoxRight);
            this.rightPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.rightPanel.Location = new System.Drawing.Point(343, 0);
            this.rightPanel.Margin = new System.Windows.Forms.Padding(0);
            this.rightPanel.Name = "rightPanel";
            this.rightPanel.Size = new System.Drawing.Size(343, 256);
            this.rightPanel.TabIndex = 4;
            // 
            // videoPanelRight
            // 
            this.videoPanelRight.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.videoPanelRight.Controls.Add(this.tableLayoutPanel3);
            this.videoPanelRight.Location = new System.Drawing.Point(116, 0);
            this.videoPanelRight.Name = "videoPanelRight";
            this.videoPanelRight.Padding = new System.Windows.Forms.Padding(1, 1, 1, 0);
            this.videoPanelRight.Size = new System.Drawing.Size(222, 256);
            this.videoPanelRight.TabIndex = 48;
            // 
            // tableLayoutPanel3
            // 
            this.tableLayoutPanel3.ColumnCount = 3;
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel3.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.tableLayoutPanel3.Controls.Add(this.volumeTrackBarRight, 2, 1);
            this.tableLayoutPanel3.Controls.Add(this.muteButtonRight, 2, 0);
            this.tableLayoutPanel3.Controls.Add(this.videoPlayButtonRight, 0, 0);
            this.tableLayoutPanel3.Controls.Add(this.videoPauseButtonRight, 1, 0);
            this.tableLayoutPanel3.Controls.Add(this.videoPositionTrackBarRight, 0, 1);
            this.tableLayoutPanel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.tableLayoutPanel3.Location = new System.Drawing.Point(1, 202);
            this.tableLayoutPanel3.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel3.Name = "tableLayoutPanel3";
            this.tableLayoutPanel3.RowCount = 2;
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 23F));
            this.tableLayoutPanel3.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel3.Size = new System.Drawing.Size(220, 54);
            this.tableLayoutPanel3.TabIndex = 24;
            // 
            // volumeTrackBarRight
            // 
            this.volumeTrackBarRight.BackColor = System.Drawing.Color.Transparent;
            this.volumeTrackBarRight.BorderColor = System.Drawing.SystemColors.ActiveBorder;
            this.volumeTrackBarRight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.volumeTrackBarRight.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.volumeTrackBarRight.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(123)))), ((int)(((byte)(125)))), ((int)(((byte)(123)))));
            this.volumeTrackBarRight.IndentHeight = 6;
            this.volumeTrackBarRight.Location = new System.Drawing.Point(146, 26);
            this.volumeTrackBarRight.Margin = new System.Windows.Forms.Padding(0, 3, 0, 3);
            this.volumeTrackBarRight.Maximum = 100;
            this.volumeTrackBarRight.Minimum = 0;
            this.volumeTrackBarRight.Name = "volumeTrackBarRight";
            this.volumeTrackBarRight.Size = new System.Drawing.Size(74, 25);
            this.volumeTrackBarRight.TabIndex = 0;
            this.volumeTrackBarRight.TabStop = false;
            this.volumeTrackBarRight.TextTickStyle = System.Windows.Forms.TickStyle.None;
            this.volumeTrackBarRight.TickColor = System.Drawing.Color.FromArgb(((int)(((byte)(148)))), ((int)(((byte)(146)))), ((int)(((byte)(148)))));
            this.volumeTrackBarRight.TickHeight = 1;
            this.volumeTrackBarRight.TickStyle = System.Windows.Forms.TickStyle.None;
            this.volumeTrackBarRight.TrackerColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(130)))), ((int)(((byte)(198)))));
            this.volumeTrackBarRight.TrackerSize = new System.Drawing.Size(16, 16);
            this.volumeTrackBarRight.TrackLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(93)))), ((int)(((byte)(90)))));
            this.volumeTrackBarRight.TrackLineHeight = 3;
            this.volumeTrackBarRight.Value = 1;
            // 
            // videoPositionTrackBarRight
            // 
            this.videoPositionTrackBarRight.BackColor = System.Drawing.Color.Transparent;
            this.videoPositionTrackBarRight.BorderColor = System.Drawing.SystemColors.ActiveBorder;
            this.tableLayoutPanel3.SetColumnSpan(this.videoPositionTrackBarRight, 2);
            this.videoPositionTrackBarRight.Dock = System.Windows.Forms.DockStyle.Fill;
            this.videoPositionTrackBarRight.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.videoPositionTrackBarRight.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(123)))), ((int)(((byte)(125)))), ((int)(((byte)(123)))));
            this.videoPositionTrackBarRight.IndentHeight = 6;
            this.videoPositionTrackBarRight.Location = new System.Drawing.Point(3, 26);
            this.videoPositionTrackBarRight.Maximum = 100;
            this.videoPositionTrackBarRight.Minimum = 0;
            this.videoPositionTrackBarRight.Name = "videoPositionTrackBarRight";
            this.videoPositionTrackBarRight.Size = new System.Drawing.Size(140, 25);
            this.videoPositionTrackBarRight.TabIndex = 24;
            this.videoPositionTrackBarRight.TickColor = System.Drawing.Color.FromArgb(((int)(((byte)(148)))), ((int)(((byte)(146)))), ((int)(((byte)(148)))));
            this.videoPositionTrackBarRight.TickHeight = 4;
            this.videoPositionTrackBarRight.TickStyle = System.Windows.Forms.TickStyle.None;
            this.videoPositionTrackBarRight.TrackerColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(130)))), ((int)(((byte)(198)))));
            this.videoPositionTrackBarRight.TrackerSize = new System.Drawing.Size(16, 16);
            this.videoPositionTrackBarRight.TrackLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(93)))), ((int)(((byte)(90)))));
            this.videoPositionTrackBarRight.TrackLineHeight = 3;
            this.videoPositionTrackBarRight.Value = 0;
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
            this.progressBar.Location = new System.Drawing.Point(73, 377);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(119, 21);
            this.progressBar.TabIndex = 19;
            this.progressBar.Visible = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 86);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 13);
            this.label1.TabIndex = 23;
            this.label1.Text = "Threads: ";
            // 
            // fileCountLabel
            // 
            this.fileCountLabel.AutoSize = true;
            this.fileCountLabel.Location = new System.Drawing.Point(13, 134);
            this.fileCountLabel.Name = "fileCountLabel";
            this.fileCountLabel.Size = new System.Drawing.Size(40, 13);
            this.fileCountLabel.TabIndex = 25;
            this.fileCountLabel.Text = "Files: 0";
            // 
            // keepNeitherButton
            // 
            this.keepNeitherButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.keepNeitherButton.Location = new System.Drawing.Point(198, 377);
            this.keepNeitherButton.Name = "keepNeitherButton";
            this.keepNeitherButton.Size = new System.Drawing.Size(686, 23);
            this.keepNeitherButton.TabIndex = 27;
            this.keepNeitherButton.Text = "Keep Neither (Delete Both)";
            this.keepNeitherButton.UseVisualStyleBackColor = true;
            this.keepNeitherButton.Click += new System.EventHandler(this.keepNeitherButton_Click);
            // 
            // DuplicatesForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(893, 411);
            this.Controls.Add(this.keepNeitherButton);
            this.Controls.Add(this.searchSubfoldersCheckBox);
            this.Controls.Add(this.fileCountLabel);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.loadingLabel);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.threadCountNumeric);
            this.Controls.Add(this.similarityNumeric);
            this.Controls.Add(this.videosCheckBox);
            this.Controls.Add(this.imagesCheckBox);
            this.Controls.Add(this.searchButton);
            this.Controls.Add(this.keepButtonsLayoutPanel);
            this.Controls.Add(this.sidesLayoutPanel);
            this.Controls.Add(this.percentageLabel);
            this.Controls.Add(this.similarityLabel);
            this.Controls.Add(this.openDirectoryButton);
            this.Controls.Add(this.keepBothButton);
            this.Controls.Add(this.tableLayoutPanel2);
            this.Controls.Add(this.matchesListBox);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(909, 450);
            this.Name = "DuplicatesForm";
            this.Text = "Sorter Express - Duplicate Search";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxRight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.similarityNumeric)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.threadCountNumeric)).EndInit();
            this.sidesLayoutPanel.ResumeLayout(false);
            this.leftPanel.ResumeLayout(false);
            this.videoPanelLeft.ResumeLayout(false);
            this.videoControlsTableLayoutPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxLeft)).EndInit();
            this.rightPanel.ResumeLayout(false);
            this.videoPanelRight.ResumeLayout(false);
            this.tableLayoutPanel3.ResumeLayout(false);
            this.keepButtonsLayoutPanel.ResumeLayout(false);
            this.tableLayoutPanel2.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBoxRight;
        private System.Windows.Forms.Button keepRightButton;
        private System.Windows.Forms.Button keepLeftButton;
        private System.Windows.Forms.Button keepBothButton;
        private System.Windows.Forms.Button openDirectoryButton;
        private System.Windows.Forms.ListBox matchesListBox;
        private System.Windows.Forms.NumericUpDown similarityNumeric;
        private System.Windows.Forms.Label similarityLabel;
        private System.Windows.Forms.Label percentageLabel;
        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.Label loadingLabel;
        private System.Windows.Forms.RichTextBox filenameRichTextBoxLeft;
        private System.Windows.Forms.RichTextBox filenameRichTextBoxRight;
        private System.Windows.Forms.TableLayoutPanel sidesLayoutPanel;
        private System.Windows.Forms.TableLayoutPanel keepButtonsLayoutPanel;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private System.Windows.Forms.Panel rightPanel;
        private System.Windows.Forms.RichTextBox infoRichTextBoxRight;
        private System.Windows.Forms.Panel leftPanel;
        private System.Windows.Forms.RichTextBox infoRichTextBoxLeft;
        private System.Windows.Forms.PictureBox pictureBoxLeft;
        private System.Windows.Forms.Panel videoPanelLeft;
        private System.Windows.Forms.TableLayoutPanel videoControlsTableLayoutPanel;
        private EConTech.Windows.MACUI.MACTrackBar volumeTrackBarLeft;
        private System.Windows.Forms.Button muteButtonLeft;
        private System.Windows.Forms.Button videoPlayButtonLeft;
        private System.Windows.Forms.Button videoPauseButtonLeft;
        private System.Windows.Forms.Panel videoPanelRight;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel3;
        private EConTech.Windows.MACUI.MACTrackBar volumeTrackBarRight;
        private System.Windows.Forms.Button muteButtonRight;
        private System.Windows.Forms.Button videoPlayButtonRight;
        private System.Windows.Forms.Button videoPauseButtonRight;
        private System.Windows.Forms.Button searchButton;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.CheckBox imagesCheckBox;
        private System.Windows.Forms.CheckBox videosCheckBox;
        private System.Windows.Forms.NumericUpDown threadCountNumeric;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button cancelButton;
        private VideoPositionTrackBar videoPositionTrackBarLeft;
        private VideoPositionTrackBar videoPositionTrackBarRight;
        private System.Windows.Forms.Label fileCountLabel;
        private System.Windows.Forms.CheckBox searchSubfoldersCheckBox;
        private System.Windows.Forms.Button keepNeitherButton;
    }
}