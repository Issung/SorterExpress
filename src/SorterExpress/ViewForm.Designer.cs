using System.Windows;
using Vlc.DotNet.Core;

namespace SorterExpress
{
    partial class ViewForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ViewForm));
            this.pictureBox = new System.Windows.Forms.PictureBox();
            this.PictureModeContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.stretchImageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.zoomToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.openDirectoryButton = new System.Windows.Forms.Button();
            this.openFileButton = new System.Windows.Forms.Button();
            this.openFileInExplorerButton = new System.Windows.Forms.Button();
            this.fileFormatNotSupportedTextbox = new System.Windows.Forms.RichTextBox();
            this.tooltip = new System.Windows.Forms.ToolTip(this.components);
            this.searchButton = new System.Windows.Forms.Button();
            this.muteButton = new System.Windows.Forms.Button();
            this.videoPlayButton = new System.Windows.Forms.Button();
            this.videoPauseButton = new System.Windows.Forms.Button();
            this.orPage = new System.Windows.Forms.TabPage();
            this.notPage = new System.Windows.Forms.TabPage();
            this.tagSearchTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.settingsButton = new System.Windows.Forms.Button();
            this.filesPanel = new System.Windows.Forms.Panel();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.andPage = new System.Windows.Forms.TabPage();
            this.resultsCountLabel = new System.Windows.Forms.Label();
            this.videoPanel = new System.Windows.Forms.Panel();
            this.videoControlsTableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.volumeTrackbar = new EConTech.Windows.MACUI.MACTrackBar();
            this.videoPositionTrackBar = new SorterExpress.VideoPositionTrackBar();
            this.openFilesTableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            this.PictureModeContextMenu.SuspendLayout();
            this.tabControl.SuspendLayout();
            this.videoPanel.SuspendLayout();
            this.videoControlsTableLayoutPanel.SuspendLayout();
            this.openFilesTableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBox
            // 
            this.pictureBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox.ContextMenuStrip = this.PictureModeContextMenu;
            this.pictureBox.InitialImage = ((System.Drawing.Image)(resources.GetObject("pictureBox.InitialImage")));
            this.pictureBox.Location = new System.Drawing.Point(511, 12);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(254, 290);
            this.pictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox.TabIndex = 1;
            this.pictureBox.TabStop = false;
            // 
            // PictureModeContextMenu
            // 
            this.PictureModeContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.stretchImageToolStripMenuItem,
            this.zoomToolStripMenuItem});
            this.PictureModeContextMenu.Name = "PictureModeContextMenu";
            this.PictureModeContextMenu.Size = new System.Drawing.Size(148, 48);
            // 
            // stretchImageToolStripMenuItem
            // 
            this.stretchImageToolStripMenuItem.Name = "stretchImageToolStripMenuItem";
            this.stretchImageToolStripMenuItem.Size = new System.Drawing.Size(147, 22);
            this.stretchImageToolStripMenuItem.Text = "Stretch Image";
            this.stretchImageToolStripMenuItem.Click += new System.EventHandler(this.StretchImageToolStripMenuItem_Click);
            // 
            // zoomToolStripMenuItem
            // 
            this.zoomToolStripMenuItem.Name = "zoomToolStripMenuItem";
            this.zoomToolStripMenuItem.Size = new System.Drawing.Size(147, 22);
            this.zoomToolStripMenuItem.Text = "Fit Image";
            this.zoomToolStripMenuItem.Click += new System.EventHandler(this.FitImageToolStripMenuItem_Click);
            // 
            // openDirectoryButton
            // 
            this.openDirectoryButton.Location = new System.Drawing.Point(88, 12);
            this.openDirectoryButton.Name = "openDirectoryButton";
            this.openDirectoryButton.Size = new System.Drawing.Size(134, 22);
            this.openDirectoryButton.TabIndex = 6;
            this.openDirectoryButton.Text = "View Directory";
            this.openDirectoryButton.UseVisualStyleBackColor = true;
            this.openDirectoryButton.Click += new System.EventHandler(this.OpenDirectoryButton_Click);
            // 
            // openFileButton
            // 
            this.openFileButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.openFileButton.Location = new System.Drawing.Point(0, 0);
            this.openFileButton.Margin = new System.Windows.Forms.Padding(0, 0, 2, 0);
            this.openFileButton.Name = "openFileButton";
            this.openFileButton.Size = new System.Drawing.Size(125, 23);
            this.openFileButton.TabIndex = 10;
            this.openFileButton.Text = "Open File";
            this.tooltip.SetToolTip(this.openFileButton, "Open current file in default program for this filetype");
            this.openFileButton.UseVisualStyleBackColor = true;
            this.openFileButton.Click += new System.EventHandler(this.openFileButton_Click);
            // 
            // openFileInExplorerButton
            // 
            this.openFileInExplorerButton.AutoSize = true;
            this.openFileInExplorerButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.openFileInExplorerButton.Location = new System.Drawing.Point(129, 0);
            this.openFileInExplorerButton.Margin = new System.Windows.Forms.Padding(2, 0, 0, 0);
            this.openFileInExplorerButton.Name = "openFileInExplorerButton";
            this.openFileInExplorerButton.Size = new System.Drawing.Size(126, 23);
            this.openFileInExplorerButton.TabIndex = 11;
            this.openFileInExplorerButton.Text = "Open File In Explorer";
            this.tooltip.SetToolTip(this.openFileInExplorerButton, "View current file in file explorer");
            this.openFileInExplorerButton.UseVisualStyleBackColor = true;
            this.openFileInExplorerButton.Click += new System.EventHandler(this.openFileInExplorerButton_Click);
            // 
            // fileFormatNotSupportedTextbox
            // 
            this.fileFormatNotSupportedTextbox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.fileFormatNotSupportedTextbox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.fileFormatNotSupportedTextbox.Enabled = false;
            this.fileFormatNotSupportedTextbox.Location = new System.Drawing.Point(513, 13);
            this.fileFormatNotSupportedTextbox.Name = "fileFormatNotSupportedTextbox";
            this.fileFormatNotSupportedTextbox.Size = new System.Drawing.Size(252, 289);
            this.fileFormatNotSupportedTextbox.TabIndex = 31;
            this.fileFormatNotSupportedTextbox.Text = "";
            // 
            // searchButton
            // 
            this.searchButton.Location = new System.Drawing.Point(228, 12);
            this.searchButton.Name = "searchButton";
            this.searchButton.Size = new System.Drawing.Size(277, 22);
            this.searchButton.TabIndex = 40;
            this.searchButton.Text = "Search";
            this.tooltip.SetToolTip(this.searchButton, "Search the selected directory with the selected tag parameters.\r\n");
            this.searchButton.UseVisualStyleBackColor = true;
            this.searchButton.Click += new System.EventHandler(this.searchButton_Click);
            // 
            // muteButton
            // 
            this.muteButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.muteButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.muteButton.Location = new System.Drawing.Point(168, 0);
            this.muteButton.Margin = new System.Windows.Forms.Padding(0);
            this.muteButton.Name = "muteButton";
            this.muteButton.Size = new System.Drawing.Size(85, 23);
            this.muteButton.TabIndex = 0;
            this.muteButton.TabStop = false;
            this.muteButton.Text = "🔊";
            this.tooltip.SetToolTip(this.muteButton, "Mute video");
            this.muteButton.UseVisualStyleBackColor = true;
            this.muteButton.Click += new System.EventHandler(this.muteButton_Click);
            // 
            // videoPlayButton
            // 
            this.videoPlayButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.videoPlayButton.Location = new System.Drawing.Point(0, 0);
            this.videoPlayButton.Margin = new System.Windows.Forms.Padding(0);
            this.videoPlayButton.Name = "videoPlayButton";
            this.videoPlayButton.Size = new System.Drawing.Size(84, 23);
            this.videoPlayButton.TabIndex = 0;
            this.videoPlayButton.TabStop = false;
            this.videoPlayButton.Text = "▶";
            this.tooltip.SetToolTip(this.videoPlayButton, "Resume Video Play");
            this.videoPlayButton.UseVisualStyleBackColor = true;
            this.videoPlayButton.Click += new System.EventHandler(this.videoPlayButton_Click);
            // 
            // videoPauseButton
            // 
            this.videoPauseButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.videoPauseButton.Location = new System.Drawing.Point(84, 0);
            this.videoPauseButton.Margin = new System.Windows.Forms.Padding(0);
            this.videoPauseButton.Name = "videoPauseButton";
            this.videoPauseButton.Size = new System.Drawing.Size(84, 23);
            this.videoPauseButton.TabIndex = 23;
            this.videoPauseButton.TabStop = false;
            this.videoPauseButton.Text = "❚❚";
            this.tooltip.SetToolTip(this.videoPauseButton, "Pause video play");
            this.videoPauseButton.UseVisualStyleBackColor = true;
            this.videoPauseButton.Click += new System.EventHandler(this.videoPauseButton_Click);
            // 
            // orPage
            // 
            this.orPage.AutoScroll = true;
            this.orPage.Location = new System.Drawing.Point(4, 22);
            this.orPage.Name = "orPage";
            this.orPage.Padding = new System.Windows.Forms.Padding(3);
            this.orPage.Size = new System.Drawing.Size(203, 222);
            this.orPage.TabIndex = 1;
            this.orPage.Tag = "Or";
            this.orPage.Text = "Or (0)";
            this.orPage.ToolTipText = "Must have one of the tags specified";
            this.orPage.UseVisualStyleBackColor = true;
            // 
            // notPage
            // 
            this.notPage.AutoScroll = true;
            this.notPage.Location = new System.Drawing.Point(4, 22);
            this.notPage.Name = "notPage";
            this.notPage.Size = new System.Drawing.Size(203, 222);
            this.notPage.TabIndex = 2;
            this.notPage.Tag = "Not";
            this.notPage.Text = "Not (0)";
            this.notPage.ToolTipText = "Must not have any of the tags specified.";
            this.notPage.UseVisualStyleBackColor = true;
            // 
            // tagSearchTextBox
            // 
            this.tagSearchTextBox.Location = new System.Drawing.Point(75, 40);
            this.tagSearchTextBox.Name = "tagSearchTextBox";
            this.tagSearchTextBox.Size = new System.Drawing.Size(146, 20);
            this.tagSearchTextBox.TabIndex = 35;
            this.tagSearchTextBox.TextChanged += new System.EventHandler(this.TagSearchTextBox_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 44);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 13);
            this.label1.TabIndex = 36;
            this.label1.Text = "Tag Search";
            // 
            // settingsButton
            // 
            this.settingsButton.Location = new System.Drawing.Point(11, 12);
            this.settingsButton.Name = "settingsButton";
            this.settingsButton.Size = new System.Drawing.Size(71, 23);
            this.settingsButton.TabIndex = 37;
            this.settingsButton.Text = "Settings";
            this.settingsButton.UseVisualStyleBackColor = true;
            this.settingsButton.Click += new System.EventHandler(this.SettingsButton_Click);
            // 
            // filesPanel
            // 
            this.filesPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.filesPanel.AutoScroll = true;
            this.filesPanel.Location = new System.Drawing.Point(229, 68);
            this.filesPanel.Name = "filesPanel";
            this.filesPanel.Size = new System.Drawing.Size(276, 261);
            this.filesPanel.TabIndex = 38;
            // 
            // tabControl
            // 
            this.tabControl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.tabControl.Controls.Add(this.andPage);
            this.tabControl.Controls.Add(this.orPage);
            this.tabControl.Controls.Add(this.notPage);
            this.tabControl.Location = new System.Drawing.Point(11, 68);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.ShowToolTips = true;
            this.tabControl.Size = new System.Drawing.Size(211, 263);
            this.tabControl.TabIndex = 39;
            // 
            // andPage
            // 
            this.andPage.AutoScroll = true;
            this.andPage.Location = new System.Drawing.Point(4, 22);
            this.andPage.Name = "andPage";
            this.andPage.Size = new System.Drawing.Size(203, 237);
            this.andPage.TabIndex = 3;
            this.andPage.Tag = "And";
            this.andPage.Text = "And (0)";
            this.andPage.UseVisualStyleBackColor = true;
            // 
            // resultsCountLabel
            // 
            this.resultsCountLabel.AutoSize = true;
            this.resultsCountLabel.Location = new System.Drawing.Point(226, 43);
            this.resultsCountLabel.Name = "resultsCountLabel";
            this.resultsCountLabel.Size = new System.Drawing.Size(51, 13);
            this.resultsCountLabel.TabIndex = 41;
            this.resultsCountLabel.Text = "0 Results";
            // 
            // videoPanel
            // 
            this.videoPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.videoPanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.videoPanel.Controls.Add(this.videoControlsTableLayoutPanel);
            this.videoPanel.Location = new System.Drawing.Point(511, 12);
            this.videoPanel.Name = "videoPanel";
            this.videoPanel.Padding = new System.Windows.Forms.Padding(1, 1, 1, 0);
            this.videoPanel.Size = new System.Drawing.Size(255, 290);
            this.videoPanel.TabIndex = 46;
            // 
            // videoControlsTableLayoutPanel
            // 
            this.videoControlsTableLayoutPanel.ColumnCount = 3;
            this.videoControlsTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.videoControlsTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.videoControlsTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33333F));
            this.videoControlsTableLayoutPanel.Controls.Add(this.volumeTrackbar, 2, 1);
            this.videoControlsTableLayoutPanel.Controls.Add(this.muteButton, 2, 0);
            this.videoControlsTableLayoutPanel.Controls.Add(this.videoPlayButton, 0, 0);
            this.videoControlsTableLayoutPanel.Controls.Add(this.videoPauseButton, 1, 0);
            this.videoControlsTableLayoutPanel.Controls.Add(this.videoPositionTrackBar, 0, 1);
            this.videoControlsTableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.videoControlsTableLayoutPanel.Location = new System.Drawing.Point(1, 236);
            this.videoControlsTableLayoutPanel.Margin = new System.Windows.Forms.Padding(0);
            this.videoControlsTableLayoutPanel.Name = "videoControlsTableLayoutPanel";
            this.videoControlsTableLayoutPanel.RowCount = 2;
            this.videoControlsTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 23F));
            this.videoControlsTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.videoControlsTableLayoutPanel.Size = new System.Drawing.Size(253, 54);
            this.videoControlsTableLayoutPanel.TabIndex = 24;
            // 
            // volumeTrackbar
            // 
            this.volumeTrackbar.BackColor = System.Drawing.Color.Transparent;
            this.volumeTrackbar.BorderColor = System.Drawing.SystemColors.ActiveBorder;
            this.volumeTrackbar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.volumeTrackbar.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.volumeTrackbar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(123)))), ((int)(((byte)(125)))), ((int)(((byte)(123)))));
            this.volumeTrackbar.IndentHeight = 6;
            this.volumeTrackbar.Location = new System.Drawing.Point(168, 26);
            this.volumeTrackbar.Margin = new System.Windows.Forms.Padding(0, 3, 0, 3);
            this.volumeTrackbar.Maximum = 100;
            this.volumeTrackbar.Minimum = 0;
            this.volumeTrackbar.Name = "volumeTrackbar";
            this.volumeTrackbar.Size = new System.Drawing.Size(85, 25);
            this.volumeTrackbar.TabIndex = 0;
            this.volumeTrackbar.TabStop = false;
            this.volumeTrackbar.TextTickStyle = System.Windows.Forms.TickStyle.None;
            this.volumeTrackbar.TickColor = System.Drawing.Color.FromArgb(((int)(((byte)(148)))), ((int)(((byte)(146)))), ((int)(((byte)(148)))));
            this.volumeTrackbar.TickHeight = 1;
            this.volumeTrackbar.TickStyle = System.Windows.Forms.TickStyle.None;
            this.volumeTrackbar.TrackerColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(130)))), ((int)(((byte)(198)))));
            this.volumeTrackbar.TrackerSize = new System.Drawing.Size(16, 16);
            this.volumeTrackbar.TrackLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(93)))), ((int)(((byte)(90)))));
            this.volumeTrackbar.TrackLineHeight = 3;
            this.volumeTrackbar.Value = 1;
            this.volumeTrackbar.ValueChanged += new EConTech.Windows.MACUI.ValueChangedHandler(this.volumeTrackbar_ValueChanged);
            // 
            // videoPositionTrackBar
            // 
            this.videoPositionTrackBar.BackColor = System.Drawing.Color.Transparent;
            this.videoPositionTrackBar.BorderColor = System.Drawing.SystemColors.ActiveBorder;
            this.videoControlsTableLayoutPanel.SetColumnSpan(this.videoPositionTrackBar, 2);
            this.videoPositionTrackBar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.videoPositionTrackBar.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.videoPositionTrackBar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(123)))), ((int)(((byte)(125)))), ((int)(((byte)(123)))));
            this.videoPositionTrackBar.IndentHeight = 6;
            this.videoPositionTrackBar.Location = new System.Drawing.Point(3, 26);
            this.videoPositionTrackBar.Maximum = 100;
            this.videoPositionTrackBar.Minimum = 0;
            this.videoPositionTrackBar.Name = "videoPositionTrackBar";
            this.videoPositionTrackBar.Size = new System.Drawing.Size(162, 25);
            this.videoPositionTrackBar.TabIndex = 24;
            this.videoPositionTrackBar.TickColor = System.Drawing.Color.FromArgb(((int)(((byte)(148)))), ((int)(((byte)(146)))), ((int)(((byte)(148)))));
            this.videoPositionTrackBar.TickHeight = 4;
            this.videoPositionTrackBar.TickStyle = System.Windows.Forms.TickStyle.None;
            this.videoPositionTrackBar.TrackerColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(130)))), ((int)(((byte)(198)))));
            this.videoPositionTrackBar.TrackerSize = new System.Drawing.Size(16, 16);
            this.videoPositionTrackBar.TrackLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(93)))), ((int)(((byte)(90)))));
            this.videoPositionTrackBar.TrackLineHeight = 3;
            this.videoPositionTrackBar.Value = 0;
            // 
            // openFilesTableLayoutPanel1
            // 
            this.openFilesTableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.openFilesTableLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.openFilesTableLayoutPanel1.ColumnCount = 2;
            this.openFilesTableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.openFilesTableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.openFilesTableLayoutPanel1.Controls.Add(this.openFileInExplorerButton, 1, 0);
            this.openFilesTableLayoutPanel1.Controls.Add(this.openFileButton, 0, 0);
            this.openFilesTableLayoutPanel1.Location = new System.Drawing.Point(511, 306);
            this.openFilesTableLayoutPanel1.Name = "openFilesTableLayoutPanel1";
            this.openFilesTableLayoutPanel1.RowCount = 1;
            this.openFilesTableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.openFilesTableLayoutPanel1.Size = new System.Drawing.Size(255, 23);
            this.openFilesTableLayoutPanel1.TabIndex = 47;
            // 
            // ViewForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(771, 336);
            this.Controls.Add(this.openFilesTableLayoutPanel1);
            this.Controls.Add(this.resultsCountLabel);
            this.Controls.Add(this.searchButton);
            this.Controls.Add(this.tabControl);
            this.Controls.Add(this.filesPanel);
            this.Controls.Add(this.settingsButton);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tagSearchTextBox);
            this.Controls.Add(this.openDirectoryButton);
            this.Controls.Add(this.videoPanel);
            this.Controls.Add(this.pictureBox);
            this.Controls.Add(this.fileFormatNotSupportedTextbox);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MinimumSize = new System.Drawing.Size(787, 375);
            this.Name = "ViewForm";
            this.Text = "Sorter Express - View";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            this.PictureModeContextMenu.ResumeLayout(false);
            this.tabControl.ResumeLayout(false);
            this.videoPanel.ResumeLayout(false);
            this.videoControlsTableLayoutPanel.ResumeLayout(false);
            this.openFilesTableLayoutPanel1.ResumeLayout(false);
            this.openFilesTableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.PictureBox pictureBox;
        private System.Windows.Forms.Button openDirectoryButton;
        private System.Windows.Forms.Button openFileButton;
        private System.Windows.Forms.Button openFileInExplorerButton;
        private System.Windows.Forms.RichTextBox fileFormatNotSupportedTextbox;
        private System.Windows.Forms.ToolTip tooltip;
        private System.Windows.Forms.ContextMenuStrip PictureModeContextMenu;
        private System.Windows.Forms.ToolStripMenuItem stretchImageToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem zoomToolStripMenuItem;
        private System.Windows.Forms.TextBox tagSearchTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button settingsButton;
        private System.Windows.Forms.Panel filesPanel;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage orPage;
        private System.Windows.Forms.TabPage notPage;
        private System.Windows.Forms.Button searchButton;
        private System.Windows.Forms.Label resultsCountLabel;
        private System.Windows.Forms.TabPage andPage;
        private System.Windows.Forms.Panel videoPanel;
        private System.Windows.Forms.TableLayoutPanel videoControlsTableLayoutPanel;
        private EConTech.Windows.MACUI.MACTrackBar volumeTrackbar;
        private System.Windows.Forms.Button muteButton;
        private System.Windows.Forms.Button videoPlayButton;
        private System.Windows.Forms.Button videoPauseButton;
        private System.Windows.Forms.TableLayoutPanel openFilesTableLayoutPanel1;
        private VideoPositionTrackBar videoPositionTrackBar;
    }
}

