namespace SorterExpress
{
    partial class RenameTagForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RenameTagForm));
            this.selectDirectoryButton = new System.Windows.Forms.Button();
            this.tagToRenameTextBox = new System.Windows.Forms.TextBox();
            this.renameToTextBox = new System.Windows.Forms.TextBox();
            this.arrowLabel = new System.Windows.Forms.Label();
            this.tagToRenameLabel = new System.Windows.Forms.Label();
            this.renameToLabel = new System.Windows.Forms.Label();
            this.scopeComboBox = new System.Windows.Forms.ComboBox();
            this.renameButton = new System.Windows.Forms.Button();
            this.listBox = new System.Windows.Forms.ListBox();
            this.pictureBox = new System.Windows.Forms.PictureBox();
            this.videoPanel = new System.Windows.Forms.Panel();
            this.videoControlsTableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.volumeTrackbar = new EConTech.Windows.MACUI.MACTrackBar();
            this.muteButton = new System.Windows.Forms.Button();
            this.videoPlayButton = new System.Windows.Forms.Button();
            this.videoPauseButton = new System.Windows.Forms.Button();
            this.videoPositionTrackBar = new SorterExpress.VideoPositionTrackBar();
            this.splitContainer = new System.Windows.Forms.SplitContainer();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            this.videoPanel.SuspendLayout();
            this.videoControlsTableLayoutPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).BeginInit();
            this.splitContainer.Panel1.SuspendLayout();
            this.splitContainer.Panel2.SuspendLayout();
            this.splitContainer.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.tableLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // selectDirectoryButton
            // 
            this.selectDirectoryButton.Location = new System.Drawing.Point(9, 10);
            this.selectDirectoryButton.Name = "selectDirectoryButton";
            this.selectDirectoryButton.Size = new System.Drawing.Size(188, 23);
            this.selectDirectoryButton.TabIndex = 0;
            this.selectDirectoryButton.Text = "Select Directory";
            this.selectDirectoryButton.UseVisualStyleBackColor = true;
            this.selectDirectoryButton.Click += new System.EventHandler(this.SelectDirectoryButton_Click);
            // 
            // tagToRenameTextBox
            // 
            this.tagToRenameTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.tagToRenameTextBox.Enabled = false;
            this.tagToRenameTextBox.Location = new System.Drawing.Point(3, 3);
            this.tagToRenameTextBox.Name = "tagToRenameTextBox";
            this.tagToRenameTextBox.Size = new System.Drawing.Size(325, 20);
            this.tagToRenameTextBox.TabIndex = 1;
            this.tagToRenameTextBox.TextChanged += new System.EventHandler(this.TagToRenameTextBox_TextChanged);
            // 
            // renameToTextBox
            // 
            this.renameToTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.renameToTextBox.Enabled = false;
            this.renameToTextBox.Location = new System.Drawing.Point(364, 3);
            this.renameToTextBox.Name = "renameToTextBox";
            this.renameToTextBox.Size = new System.Drawing.Size(326, 20);
            this.renameToTextBox.TabIndex = 1;
            this.renameToTextBox.TextChanged += new System.EventHandler(this.RenameToTextBox_TextChanged);
            // 
            // arrowLabel
            // 
            this.arrowLabel.AutoSize = true;
            this.arrowLabel.Location = new System.Drawing.Point(336, 7);
            this.arrowLabel.Margin = new System.Windows.Forms.Padding(5, 0, 0, 0);
            this.arrowLabel.Name = "arrowLabel";
            this.arrowLabel.Size = new System.Drawing.Size(18, 13);
            this.arrowLabel.TabIndex = 2;
            this.arrowLabel.Text = "→";
            // 
            // tagToRenameLabel
            // 
            this.tagToRenameLabel.AutoSize = true;
            this.tagToRenameLabel.Location = new System.Drawing.Point(3, 0);
            this.tagToRenameLabel.Name = "tagToRenameLabel";
            this.tagToRenameLabel.Size = new System.Drawing.Size(85, 13);
            this.tagToRenameLabel.TabIndex = 3;
            this.tagToRenameLabel.Text = "Tag To Rename";
            // 
            // renameToLabel
            // 
            this.renameToLabel.AutoSize = true;
            this.renameToLabel.Location = new System.Drawing.Point(364, 0);
            this.renameToLabel.Name = "renameToLabel";
            this.renameToLabel.Size = new System.Drawing.Size(66, 13);
            this.renameToLabel.TabIndex = 3;
            this.renameToLabel.Text = "Rename To ";
            // 
            // scopeComboBox
            // 
            this.scopeComboBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.scopeComboBox.FormattingEnabled = true;
            this.scopeComboBox.Items.AddRange(new object[] {
            "Only files in immediate directory",
            "All files under directory recursively"});
            this.scopeComboBox.Location = new System.Drawing.Point(205, 11);
            this.scopeComboBox.Name = "scopeComboBox";
            this.scopeComboBox.Size = new System.Drawing.Size(495, 21);
            this.scopeComboBox.TabIndex = 4;
            this.scopeComboBox.SelectedIndexChanged += new System.EventHandler(this.ScopeComboBox_SelectedIndexChanged);
            // 
            // renameButton
            // 
            this.renameButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.renameButton.Enabled = false;
            this.renameButton.Location = new System.Drawing.Point(9, 314);
            this.renameButton.Name = "renameButton";
            this.renameButton.Size = new System.Drawing.Size(690, 23);
            this.renameButton.TabIndex = 6;
            this.renameButton.Text = "Rename All";
            this.renameButton.UseVisualStyleBackColor = true;
            this.renameButton.Click += new System.EventHandler(this.RenameButton_Click);
            // 
            // listBox
            // 
            this.listBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listBox.Enabled = false;
            this.listBox.FormattingEnabled = true;
            this.listBox.IntegralHeight = false;
            this.listBox.Location = new System.Drawing.Point(0, 0);
            this.listBox.Name = "listBox";
            this.listBox.Size = new System.Drawing.Size(104, 223);
            this.listBox.TabIndex = 7;
            this.listBox.SelectedIndexChanged += new System.EventHandler(this.ListBox_SelectedIndexChanged);
            // 
            // pictureBox
            // 
            this.pictureBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox.Location = new System.Drawing.Point(0, 0);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(574, 223);
            this.pictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox.TabIndex = 8;
            this.pictureBox.TabStop = false;
            // 
            // videoPanel
            // 
            this.videoPanel.Controls.Add(this.videoControlsTableLayoutPanel);
            this.videoPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.videoPanel.Location = new System.Drawing.Point(0, 0);
            this.videoPanel.Name = "videoPanel";
            this.videoPanel.Padding = new System.Windows.Forms.Padding(1, 1, 1, 0);
            this.videoPanel.Size = new System.Drawing.Size(574, 223);
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
            this.videoControlsTableLayoutPanel.Location = new System.Drawing.Point(1, 169);
            this.videoControlsTableLayoutPanel.Margin = new System.Windows.Forms.Padding(0);
            this.videoControlsTableLayoutPanel.Name = "videoControlsTableLayoutPanel";
            this.videoControlsTableLayoutPanel.RowCount = 2;
            this.videoControlsTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 23F));
            this.videoControlsTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.videoControlsTableLayoutPanel.Size = new System.Drawing.Size(572, 54);
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
            this.volumeTrackbar.Location = new System.Drawing.Point(380, 26);
            this.volumeTrackbar.Margin = new System.Windows.Forms.Padding(0, 3, 0, 3);
            this.volumeTrackbar.Maximum = 100;
            this.volumeTrackbar.Minimum = 0;
            this.volumeTrackbar.Name = "volumeTrackbar";
            this.volumeTrackbar.Size = new System.Drawing.Size(192, 25);
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
            this.volumeTrackbar.ValueChanged += new EConTech.Windows.MACUI.ValueChangedHandler(this.VolumeTrackbar_ValueChanged);
            // 
            // muteButton
            // 
            this.muteButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.muteButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.muteButton.Location = new System.Drawing.Point(380, 0);
            this.muteButton.Margin = new System.Windows.Forms.Padding(0);
            this.muteButton.Name = "muteButton";
            this.muteButton.Size = new System.Drawing.Size(192, 23);
            this.muteButton.TabIndex = 0;
            this.muteButton.TabStop = false;
            this.muteButton.Text = "🔊";
            this.muteButton.UseVisualStyleBackColor = true;
            // 
            // videoPlayButton
            // 
            this.videoPlayButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.videoPlayButton.Location = new System.Drawing.Point(0, 0);
            this.videoPlayButton.Margin = new System.Windows.Forms.Padding(0);
            this.videoPlayButton.Name = "videoPlayButton";
            this.videoPlayButton.Size = new System.Drawing.Size(190, 23);
            this.videoPlayButton.TabIndex = 0;
            this.videoPlayButton.TabStop = false;
            this.videoPlayButton.Text = "▶";
            this.videoPlayButton.UseVisualStyleBackColor = true;
            this.videoPlayButton.Click += new System.EventHandler(this.VideoPlayButton_Click);
            // 
            // videoPauseButton
            // 
            this.videoPauseButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.videoPauseButton.Location = new System.Drawing.Point(190, 0);
            this.videoPauseButton.Margin = new System.Windows.Forms.Padding(0);
            this.videoPauseButton.Name = "videoPauseButton";
            this.videoPauseButton.Size = new System.Drawing.Size(190, 23);
            this.videoPauseButton.TabIndex = 23;
            this.videoPauseButton.TabStop = false;
            this.videoPauseButton.Text = "❚❚";
            this.videoPauseButton.UseVisualStyleBackColor = true;
            this.videoPauseButton.Click += new System.EventHandler(this.VideoPauseButton_Click);
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
            this.videoPositionTrackBar.Size = new System.Drawing.Size(374, 25);
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
            // splitContainer
            // 
            this.splitContainer.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.splitContainer.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.splitContainer.Location = new System.Drawing.Point(10, 81);
            this.splitContainer.Name = "splitContainer";
            // 
            // splitContainer.Panel1
            // 
            this.splitContainer.Panel1.Controls.Add(this.listBox);
            // 
            // splitContainer.Panel2
            // 
            this.splitContainer.Panel2.Controls.Add(this.videoPanel);
            this.splitContainer.Panel2.Controls.Add(this.pictureBox);
            this.splitContainer.Size = new System.Drawing.Size(690, 227);
            this.splitContainer.SplitterDistance = 108;
            this.splitContainer.TabIndex = 47;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.ColumnCount = 3;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.renameToTextBox, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.tagToRenameTextBox, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.arrowLabel, 1, 1);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(7, 54);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 2;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(693, 27);
            this.tableLayoutPanel1.TabIndex = 48;
            // 
            // tableLayoutPanel2
            // 
            this.tableLayoutPanel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel2.ColumnCount = 3;
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.tableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel2.Controls.Add(this.tagToRenameLabel, 0, 0);
            this.tableLayoutPanel2.Controls.Add(this.renameToLabel, 2, 0);
            this.tableLayoutPanel2.Location = new System.Drawing.Point(7, 38);
            this.tableLayoutPanel2.Name = "tableLayoutPanel2";
            this.tableLayoutPanel2.RowCount = 1;
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 13F));
            this.tableLayoutPanel2.Size = new System.Drawing.Size(693, 13);
            this.tableLayoutPanel2.TabIndex = 49;
            // 
            // RenameTagForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(709, 345);
            this.Controls.Add(this.tableLayoutPanel2);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.splitContainer);
            this.Controls.Add(this.renameButton);
            this.Controls.Add(this.scopeComboBox);
            this.Controls.Add(this.selectDirectoryButton);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(605, 357);
            this.Name = "RenameTagForm";
            this.Text = "Sorter Express - Rename Tag";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            this.videoPanel.ResumeLayout(false);
            this.videoControlsTableLayoutPanel.ResumeLayout(false);
            this.splitContainer.Panel1.ResumeLayout(false);
            this.splitContainer.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer)).EndInit();
            this.splitContainer.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.tableLayoutPanel2.ResumeLayout(false);
            this.tableLayoutPanel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button selectDirectoryButton;
        private System.Windows.Forms.TextBox tagToRenameTextBox;
        private System.Windows.Forms.TextBox renameToTextBox;
        private System.Windows.Forms.Label arrowLabel;
        private System.Windows.Forms.Label tagToRenameLabel;
        private System.Windows.Forms.Label renameToLabel;
        private System.Windows.Forms.ComboBox scopeComboBox;
        private System.Windows.Forms.Button renameButton;
        private System.Windows.Forms.ListBox listBox;
        private System.Windows.Forms.PictureBox pictureBox;
        private System.Windows.Forms.Panel videoPanel;
        private System.Windows.Forms.TableLayoutPanel videoControlsTableLayoutPanel;
        private EConTech.Windows.MACUI.MACTrackBar volumeTrackbar;
        private System.Windows.Forms.Button muteButton;
        private System.Windows.Forms.Button videoPlayButton;
        private System.Windows.Forms.Button videoPauseButton;
        private System.Windows.Forms.SplitContainer splitContainer;
        private VideoPositionTrackBar videoPositionTrackBar;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
    }
}