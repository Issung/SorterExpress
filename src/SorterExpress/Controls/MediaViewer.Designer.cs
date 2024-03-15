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
            components = new System.ComponentModel.Container();
            tooltip = new System.Windows.Forms.ToolTip(components);
            volumeTrackbar = new System.Windows.Forms.TrackBar();
            mediaViewerBindingSource = new System.Windows.Forms.BindingSource(components);
            videoPositionTrackBar = new VideoPositionTrackBar();
            pictureBox = new System.Windows.Forms.PictureBox();
            pictureModeContextMenu = new System.Windows.Forms.ContextMenuStrip(components);
            stretchImageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            zoomToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            errorMessageTextBox = new System.Windows.Forms.RichTextBox();
            vlcPlayerTableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            muteButton = new System.Windows.Forms.Button();
            videoPauseButton = new System.Windows.Forms.Button();
            videoPlayButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)volumeTrackbar).BeginInit();
            ((System.ComponentModel.ISupportInitialize)mediaViewerBindingSource).BeginInit();
            ((System.ComponentModel.ISupportInitialize)videoPositionTrackBar).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox).BeginInit();
            pictureModeContextMenu.SuspendLayout();
            vlcPlayerTableLayoutPanel.SuspendLayout();
            SuspendLayout();
            // 
            // volumeTrackbar
            // 
            volumeTrackbar.DataBindings.Add(new System.Windows.Forms.Binding("Enabled", mediaViewerBindingSource, "EnableButtons", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            volumeTrackbar.Dock = System.Windows.Forms.DockStyle.Fill;
            volumeTrackbar.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            volumeTrackbar.Location = new System.Drawing.Point(310, 437);
            volumeTrackbar.Margin = new System.Windows.Forms.Padding(0, 4, 0, 0);
            volumeTrackbar.Maximum = 100;
            volumeTrackbar.Name = "volumeTrackbar";
            volumeTrackbar.Size = new System.Drawing.Size(157, 25);
            volumeTrackbar.TabIndex = 27;
            volumeTrackbar.TabStop = false;
            volumeTrackbar.TickStyle = System.Windows.Forms.TickStyle.None;
            tooltip.SetToolTip(volumeTrackbar, "Adjust video volume");
            volumeTrackbar.ValueChanged += volumeTrackbar_ValueChanged;
            volumeTrackbar.MouseDown += volumeTrackbar_MouseDown;
            // 
            // mediaViewerBindingSource
            // 
            mediaViewerBindingSource.DataSource = typeof(MediaViewer);
            // 
            // videoPositionTrackBar
            // 
            vlcPlayerTableLayoutPanel.SetColumnSpan(videoPositionTrackBar, 2);
            videoPositionTrackBar.DataBindings.Add(new System.Windows.Forms.Binding("Enabled", mediaViewerBindingSource, "EnableButtons", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            videoPositionTrackBar.Dock = System.Windows.Forms.DockStyle.Fill;
            videoPositionTrackBar.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, 0);
            videoPositionTrackBar.Location = new System.Drawing.Point(4, 437);
            videoPositionTrackBar.Margin = new System.Windows.Forms.Padding(4, 4, 4, 0);
            videoPositionTrackBar.Maximum = 100;
            videoPositionTrackBar.Name = "videoPositionTrackBar";
            videoPositionTrackBar.Size = new System.Drawing.Size(302, 25);
            videoPositionTrackBar.TabIndex = 28;
            videoPositionTrackBar.TickStyle = System.Windows.Forms.TickStyle.None;
            tooltip.SetToolTip(videoPositionTrackBar, "Adjust video time position");
            // 
            // pictureBox
            // 
            pictureBox.ContextMenuStrip = pictureModeContextMenu;
            pictureBox.Dock = System.Windows.Forms.DockStyle.Fill;
            pictureBox.Location = new System.Drawing.Point(0, 0);
            pictureBox.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            pictureBox.Name = "pictureBox";
            pictureBox.Size = new System.Drawing.Size(467, 462);
            pictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            pictureBox.TabIndex = 29;
            pictureBox.TabStop = false;
            // 
            // pictureModeContextMenu
            // 
            pictureModeContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] { stretchImageToolStripMenuItem, zoomToolStripMenuItem });
            pictureModeContextMenu.Name = "PictureModeContextMenu";
            pictureModeContextMenu.Size = new System.Drawing.Size(148, 48);
            // 
            // stretchImageToolStripMenuItem
            // 
            stretchImageToolStripMenuItem.Name = "stretchImageToolStripMenuItem";
            stretchImageToolStripMenuItem.Size = new System.Drawing.Size(147, 22);
            stretchImageToolStripMenuItem.Text = "Stretch Image";
            stretchImageToolStripMenuItem.Click += stretchImageToolStripMenuItem_Click;
            // 
            // zoomToolStripMenuItem
            // 
            zoomToolStripMenuItem.Name = "zoomToolStripMenuItem";
            zoomToolStripMenuItem.Size = new System.Drawing.Size(147, 22);
            zoomToolStripMenuItem.Text = "Fit Image";
            zoomToolStripMenuItem.Click += zoomToolStripMenuItem_Click;
            // 
            // errorMessageTextBox
            // 
            errorMessageTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            errorMessageTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            errorMessageTextBox.Location = new System.Drawing.Point(0, 0);
            errorMessageTextBox.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            errorMessageTextBox.Name = "errorMessageTextBox";
            errorMessageTextBox.ReadOnly = true;
            errorMessageTextBox.Size = new System.Drawing.Size(467, 462);
            errorMessageTextBox.TabIndex = 30;
            errorMessageTextBox.TabStop = false;
            errorMessageTextBox.Text = "File format not supported.\n\nYou can view the file by clicking \"Open File\" or \"Open File In Explorer\" buttons below.";
            errorMessageTextBox.LinkClicked += errorMessageTextBox_LinkClicked;
            // 
            // vlcPlayerTableLayoutPanel
            // 
            vlcPlayerTableLayoutPanel.ColumnCount = 3;
            vlcPlayerTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33332F));
            vlcPlayerTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33334F));
            vlcPlayerTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 33.33334F));
            vlcPlayerTableLayoutPanel.Controls.Add(videoPositionTrackBar, 0, 2);
            vlcPlayerTableLayoutPanel.Controls.Add(volumeTrackbar, 2, 2);
            vlcPlayerTableLayoutPanel.Controls.Add(muteButton, 2, 1);
            vlcPlayerTableLayoutPanel.Controls.Add(videoPauseButton, 1, 1);
            vlcPlayerTableLayoutPanel.Controls.Add(videoPlayButton, 0, 1);
            vlcPlayerTableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            vlcPlayerTableLayoutPanel.Location = new System.Drawing.Point(0, 0);
            vlcPlayerTableLayoutPanel.Margin = new System.Windows.Forms.Padding(0);
            vlcPlayerTableLayoutPanel.Name = "vlcPlayerTableLayoutPanel";
            vlcPlayerTableLayoutPanel.RowCount = 3;
            vlcPlayerTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            vlcPlayerTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 27F));
            vlcPlayerTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 29F));
            vlcPlayerTableLayoutPanel.Size = new System.Drawing.Size(467, 462);
            vlcPlayerTableLayoutPanel.TabIndex = 32;
            // 
            // muteButton
            // 
            muteButton.DataBindings.Add(new System.Windows.Forms.Binding("Enabled", mediaViewerBindingSource, "EnableButtons", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            muteButton.Dock = System.Windows.Forms.DockStyle.Fill;
            muteButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            muteButton.Location = new System.Drawing.Point(312, 406);
            muteButton.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            muteButton.Name = "muteButton";
            muteButton.Size = new System.Drawing.Size(153, 27);
            muteButton.TabIndex = 25;
            muteButton.TabStop = false;
            muteButton.Text = "🔊";
            muteButton.UseVisualStyleBackColor = true;
            muteButton.Click += muteButton_Click;
            // 
            // videoPauseButton
            // 
            videoPauseButton.DataBindings.Add(new System.Windows.Forms.Binding("Enabled", mediaViewerBindingSource, "EnableButtons", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            videoPauseButton.Dock = System.Windows.Forms.DockStyle.Fill;
            videoPauseButton.Location = new System.Drawing.Point(157, 406);
            videoPauseButton.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            videoPauseButton.Name = "videoPauseButton";
            videoPauseButton.Size = new System.Drawing.Size(151, 27);
            videoPauseButton.TabIndex = 24;
            videoPauseButton.TabStop = false;
            videoPauseButton.Text = "❚❚";
            videoPauseButton.UseVisualStyleBackColor = true;
            videoPauseButton.Click += videoPauseButton_Click;
            // 
            // videoPlayButton
            // 
            videoPlayButton.DataBindings.Add(new System.Windows.Forms.Binding("Enabled", mediaViewerBindingSource, "EnableButtons", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            videoPlayButton.Dock = System.Windows.Forms.DockStyle.Fill;
            videoPlayButton.Location = new System.Drawing.Point(2, 406);
            videoPlayButton.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            videoPlayButton.Name = "videoPlayButton";
            videoPlayButton.Size = new System.Drawing.Size(151, 27);
            videoPlayButton.TabIndex = 1;
            videoPlayButton.TabStop = false;
            videoPlayButton.Text = "▶";
            videoPlayButton.UseVisualStyleBackColor = true;
            videoPlayButton.Click += videoPlayButton_Click;
            // 
            // MediaViewer
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            Controls.Add(vlcPlayerTableLayoutPanel);
            Controls.Add(pictureBox);
            Controls.Add(errorMessageTextBox);
            Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            Name = "MediaViewer";
            Size = new System.Drawing.Size(467, 462);
            Load += MediaViewer_Load;
            ((System.ComponentModel.ISupportInitialize)volumeTrackbar).EndInit();
            ((System.ComponentModel.ISupportInitialize)mediaViewerBindingSource).EndInit();
            ((System.ComponentModel.ISupportInitialize)videoPositionTrackBar).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox).EndInit();
            pictureModeContextMenu.ResumeLayout(false);
            vlcPlayerTableLayoutPanel.ResumeLayout(false);
            vlcPlayerTableLayoutPanel.PerformLayout();
            ResumeLayout(false);
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
        private System.Windows.Forms.TrackBar volumeTrackbar;
        private System.Windows.Forms.Button muteButton;
        private System.Windows.Forms.Button videoPauseButton;
        private System.Windows.Forms.Button videoPlayButton;
        private System.Windows.Forms.BindingSource mediaViewerBindingSource;
    }
}
