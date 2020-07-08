namespace SorterExpress.Controls
{
    partial class MediaViewer
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.tooltip = new System.Windows.Forms.ToolTip(this.components);
            this.volumeTrackbar = new EConTech.Windows.MACUI.MACTrackBar();
            this.videoPositionTrackBar = new SorterExpress.Controls.VideoPositionTrackBar();
            this.pictureBox = new System.Windows.Forms.PictureBox();
            this.pictureModeContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.stretchImageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.zoomToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.errorMessageTextBox = new System.Windows.Forms.RichTextBox();
            this.vlcPlayerTableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.muteButton = new System.Windows.Forms.Button();
            this.videoPauseButton = new System.Windows.Forms.Button();
            this.videoPlayButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            this.pictureModeContextMenu.SuspendLayout();
            this.vlcPlayerTableLayoutPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // volumeTrackbar
            // 
            this.volumeTrackbar.BackColor = System.Drawing.Color.Transparent;
            this.volumeTrackbar.BorderColor = System.Drawing.SystemColors.ActiveBorder;
            this.volumeTrackbar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.volumeTrackbar.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.volumeTrackbar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(123)))), ((int)(((byte)(125)))), ((int)(((byte)(123)))));
            this.volumeTrackbar.IndentHeight = 6;
            this.volumeTrackbar.Location = new System.Drawing.Point(266, 375);
            this.volumeTrackbar.Margin = new System.Windows.Forms.Padding(0);
            this.volumeTrackbar.Maximum = 100;
            this.volumeTrackbar.Minimum = 0;
            this.volumeTrackbar.Name = "volumeTrackbar";
            this.volumeTrackbar.Size = new System.Drawing.Size(134, 25);
            this.volumeTrackbar.TabIndex = 27;
            this.volumeTrackbar.TabStop = false;
            this.volumeTrackbar.TextTickStyle = System.Windows.Forms.TickStyle.None;
            this.volumeTrackbar.TickColor = System.Drawing.Color.FromArgb(((int)(((byte)(148)))), ((int)(((byte)(146)))), ((int)(((byte)(148)))));
            this.volumeTrackbar.TickHeight = 1;
            this.volumeTrackbar.TickStyle = System.Windows.Forms.TickStyle.None;
            this.tooltip.SetToolTip(this.volumeTrackbar, "Adjust video volume");
            this.volumeTrackbar.TrackerColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(130)))), ((int)(((byte)(198)))));
            this.volumeTrackbar.TrackerSize = new System.Drawing.Size(16, 16);
            this.volumeTrackbar.TrackLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(93)))), ((int)(((byte)(90)))));
            this.volumeTrackbar.TrackLineHeight = 3;
            this.volumeTrackbar.Value = 0;
            this.volumeTrackbar.ValueChanged += new EConTech.Windows.MACUI.ValueChangedHandler(this.volumeTrackbar_ValueChanged);
            this.volumeTrackbar.MouseDown += new System.Windows.Forms.MouseEventHandler(this.volumeTrackbar_MouseDown);
            // 
            // videoPositionTrackBar
            // 
            this.videoPositionTrackBar.BackColor = System.Drawing.Color.Transparent;
            this.videoPositionTrackBar.BorderColor = System.Drawing.SystemColors.ActiveBorder;
            this.vlcPlayerTableLayoutPanel.SetColumnSpan(this.videoPositionTrackBar, 2);
            this.videoPositionTrackBar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.videoPositionTrackBar.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.videoPositionTrackBar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(123)))), ((int)(((byte)(125)))), ((int)(((byte)(123)))));
            this.videoPositionTrackBar.IndentHeight = 6;
            this.videoPositionTrackBar.Location = new System.Drawing.Point(3, 375);
            this.videoPositionTrackBar.Margin = new System.Windows.Forms.Padding(3, 0, 3, 0);
            this.videoPositionTrackBar.Maximum = 100;
            this.videoPositionTrackBar.Minimum = 0;
            this.videoPositionTrackBar.Name = "videoPositionTrackBar";
            this.videoPositionTrackBar.Size = new System.Drawing.Size(260, 25);
            this.videoPositionTrackBar.TabIndex = 28;
            this.videoPositionTrackBar.TextTickStyle = System.Windows.Forms.TickStyle.None;
            this.videoPositionTrackBar.TickColor = System.Drawing.Color.FromArgb(((int)(((byte)(148)))), ((int)(((byte)(146)))), ((int)(((byte)(148)))));
            this.videoPositionTrackBar.TickHeight = 4;
            this.videoPositionTrackBar.TickStyle = System.Windows.Forms.TickStyle.None;
            this.tooltip.SetToolTip(this.videoPositionTrackBar, "Adjust video time position");
            this.videoPositionTrackBar.TrackerColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(130)))), ((int)(((byte)(198)))));
            this.videoPositionTrackBar.TrackerSize = new System.Drawing.Size(16, 16);
            this.videoPositionTrackBar.TrackLineColor = System.Drawing.Color.FromArgb(((int)(((byte)(90)))), ((int)(((byte)(93)))), ((int)(((byte)(90)))));
            this.videoPositionTrackBar.TrackLineHeight = 3;
            this.videoPositionTrackBar.Value = 0;
            // 
            // pictureBox
            // 
            this.pictureBox.ContextMenuStrip = this.pictureModeContextMenu;
            this.pictureBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBox.Location = new System.Drawing.Point(0, 0);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(400, 400);
            this.pictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox.TabIndex = 29;
            this.pictureBox.TabStop = false;
            // 
            // pictureModeContextMenu
            // 
            this.pictureModeContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.stretchImageToolStripMenuItem,
            this.zoomToolStripMenuItem});
            this.pictureModeContextMenu.Name = "PictureModeContextMenu";
            this.pictureModeContextMenu.Size = new System.Drawing.Size(148, 48);
            // 
            // stretchImageToolStripMenuItem
            // 
            this.stretchImageToolStripMenuItem.Name = "stretchImageToolStripMenuItem";
            this.stretchImageToolStripMenuItem.Size = new System.Drawing.Size(147, 22);
            this.stretchImageToolStripMenuItem.Text = "Stretch Image";
            this.stretchImageToolStripMenuItem.Click += new System.EventHandler(this.stretchImageToolStripMenuItem_Click);
            // 
            // zoomToolStripMenuItem
            // 
            this.zoomToolStripMenuItem.Name = "zoomToolStripMenuItem";
            this.zoomToolStripMenuItem.Size = new System.Drawing.Size(147, 22);
            this.zoomToolStripMenuItem.Text = "Fit Image";
            this.zoomToolStripMenuItem.Click += new System.EventHandler(this.zoomToolStripMenuItem_Click);
            // 
            // errorMessageTextBox
            // 
            this.errorMessageTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.errorMessageTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.errorMessageTextBox.Location = new System.Drawing.Point(0, 0);
            this.errorMessageTextBox.Name = "errorMessageTextBox";
            this.errorMessageTextBox.ReadOnly = true;
            this.errorMessageTextBox.Size = new System.Drawing.Size(400, 400);
            this.errorMessageTextBox.TabIndex = 30;
            this.errorMessageTextBox.TabStop = false;
            this.errorMessageTextBox.Text = "File format not supported.\n\nYou can view the file by clicking \"Open File\" or \"Ope" +
    "n File In Explorer\" buttons below.";
            this.errorMessageTextBox.LinkClicked += new System.Windows.Forms.LinkClickedEventHandler(this.errorMessageTextBox_LinkClicked);
            // 
            // vlcPlayerTableLayoutPanel
            // 
            this.vlcPlayerTableLayoutPanel.ColumnCount = 3;
            this.vlcPlayerTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33332F));
            this.vlcPlayerTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33334F));
            this.vlcPlayerTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33334F));
            this.vlcPlayerTableLayoutPanel.Controls.Add(this.videoPositionTrackBar, 0, 2);
            this.vlcPlayerTableLayoutPanel.Controls.Add(this.volumeTrackbar, 2, 2);
            this.vlcPlayerTableLayoutPanel.Controls.Add(this.muteButton, 2, 1);
            this.vlcPlayerTableLayoutPanel.Controls.Add(this.videoPauseButton, 1, 1);
            this.vlcPlayerTableLayoutPanel.Controls.Add(this.videoPlayButton, 0, 1);
            this.vlcPlayerTableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.vlcPlayerTableLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.vlcPlayerTableLayoutPanel.Margin = new System.Windows.Forms.Padding(0);
            this.vlcPlayerTableLayoutPanel.Name = "vlcPlayerTableLayoutPanel";
            this.vlcPlayerTableLayoutPanel.RowCount = 3;
            this.vlcPlayerTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.vlcPlayerTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 23F));
            this.vlcPlayerTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.vlcPlayerTableLayoutPanel.Size = new System.Drawing.Size(400, 400);
            this.vlcPlayerTableLayoutPanel.TabIndex = 32;
            // 
            // muteButton
            // 
            this.muteButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.muteButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.muteButton.Location = new System.Drawing.Point(268, 352);
            this.muteButton.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.muteButton.Name = "muteButton";
            this.muteButton.Size = new System.Drawing.Size(130, 23);
            this.muteButton.TabIndex = 25;
            this.muteButton.TabStop = false;
            this.muteButton.Text = "🔊";
            this.muteButton.UseVisualStyleBackColor = true;
            this.muteButton.Click += new System.EventHandler(this.muteButton_Click);
            // 
            // videoPauseButton
            // 
            this.videoPauseButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.videoPauseButton.Location = new System.Drawing.Point(135, 352);
            this.videoPauseButton.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.videoPauseButton.Name = "videoPauseButton";
            this.videoPauseButton.Size = new System.Drawing.Size(129, 23);
            this.videoPauseButton.TabIndex = 24;
            this.videoPauseButton.TabStop = false;
            this.videoPauseButton.Text = "❚❚";
            this.videoPauseButton.UseVisualStyleBackColor = true;
            this.videoPauseButton.Click += new System.EventHandler(this.videoPauseButton_Click);
            // 
            // videoPlayButton
            // 
            this.videoPlayButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.videoPlayButton.Location = new System.Drawing.Point(2, 352);
            this.videoPlayButton.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.videoPlayButton.Name = "videoPlayButton";
            this.videoPlayButton.Size = new System.Drawing.Size(129, 23);
            this.videoPlayButton.TabIndex = 1;
            this.videoPlayButton.TabStop = false;
            this.videoPlayButton.Text = "▶";
            this.videoPlayButton.UseVisualStyleBackColor = true;
            this.videoPlayButton.Click += new System.EventHandler(this.videoPlayButton_Click);
            // 
            // MediaViewer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.errorMessageTextBox);
            this.Controls.Add(this.vlcPlayerTableLayoutPanel);
            this.Controls.Add(this.pictureBox);
            this.Name = "MediaViewer";
            this.Size = new System.Drawing.Size(400, 400);
            this.Load += new System.EventHandler(this.MediaViewer_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            this.pictureModeContextMenu.ResumeLayout(false);
            this.vlcPlayerTableLayoutPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.ToolTip tooltip;
        private System.Windows.Forms.PictureBox pictureBox;
        private System.Windows.Forms.RichTextBox errorMessageTextBox;
        private System.Windows.Forms.ContextMenuStrip pictureModeContextMenu;
        private System.Windows.Forms.ToolStripMenuItem stretchImageToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem zoomToolStripMenuItem;
        private System.Windows.Forms.TableLayoutPanel vlcPlayerTableLayoutPanel;
        private VideoPositionTrackBar videoPositionTrackBar;
        private EConTech.Windows.MACUI.MACTrackBar volumeTrackbar;
        private System.Windows.Forms.Button muteButton;
        private System.Windows.Forms.Button videoPauseButton;
        private System.Windows.Forms.Button videoPlayButton;
    }
}
