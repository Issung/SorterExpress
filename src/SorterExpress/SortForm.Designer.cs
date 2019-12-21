using System.Windows;
using Vlc.DotNet.Core;

namespace SorterExpress
{
    partial class SortForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SortForm));
            this.filenameTextbox = new System.Windows.Forms.TextBox();
            this.pictureBox = new System.Windows.Forms.PictureBox();
            this.PictureModeContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.stretchImageToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.zoomToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.label1 = new System.Windows.Forms.Label();
            this.addTagButton = new System.Windows.Forms.Button();
            this.openDirectoryButton = new System.Windows.Forms.Button();
            this.openFileButton = new System.Windows.Forms.Button();
            this.openFileInExplorerButton = new System.Windows.Forms.Button();
            this.subfoldersLabel = new System.Windows.Forms.Label();
            this.fileExtensionTextbox = new System.Windows.Forms.TextBox();
            this.tagCreationTextbox = new System.Windows.Forms.TextBox();
            this.saveButton = new System.Windows.Forms.Button();
            this.volumeTrackbar = new EConTech.Windows.MACUI.MACTrackBar();
            this.messageTextBox = new System.Windows.Forms.RichTextBox();
            this.settingsButton = new System.Windows.Forms.Button();
            this.tooltip = new System.Windows.Forms.ToolTip(this.components);
            this.tagSearchTextbox = new System.Windows.Forms.TextBox();
            this.notesTextBox = new System.Windows.Forms.TextBox();
            this.newFileNameTextBox = new System.Windows.Forms.TextBox();
            this.undoButton = new System.Windows.Forms.Button();
            this.firstFileButton = new System.Windows.Forms.Button();
            this.prevFileButton = new System.Windows.Forms.Button();
            this.fileCountTextbox = new System.Windows.Forms.TextBox();
            this.nextFileButton = new System.Windows.Forms.Button();
            this.lastFileButton = new System.Windows.Forms.Button();
            this.videoPauseButton = new System.Windows.Forms.Button();
            this.videoPlayButton = new System.Windows.Forms.Button();
            this.muteButton = new System.Windows.Forms.Button();
            this.tagSearchLabel = new System.Windows.Forms.Label();
            this.noteLabel = new System.Windows.Forms.Label();
            this.deleteButton = new System.Windows.Forms.Button();
            this.addDirectoryButton = new System.Windows.Forms.Button();
            this.openFileTableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.fileIndexTextbox = new System.Windows.Forms.TextBox();
            this.indexSlashLabel = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.videoPanel = new System.Windows.Forms.Panel();
            this.videoControlsTableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.videoPositionTrackBar = new SorterExpress.VideoPositionTrackBar();
            this.subfoldersPanel = new SorterExpress.ScrollPanel();
            this.tagsPanel = new SorterExpress.ScrollPanel();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            this.PictureModeContextMenu.SuspendLayout();
            this.openFileTableLayoutPanel.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.videoPanel.SuspendLayout();
            this.videoControlsTableLayoutPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // filenameTextbox
            // 
            this.filenameTextbox.BackColor = System.Drawing.SystemColors.Control;
            this.filenameTextbox.Location = new System.Drawing.Point(9, 40);
            this.filenameTextbox.Name = "filenameTextbox";
            this.filenameTextbox.ReadOnly = true;
            this.filenameTextbox.Size = new System.Drawing.Size(202, 20);
            this.filenameTextbox.TabIndex = 5;
            this.filenameTextbox.TabStop = false;
            this.tooltip.SetToolTip(this.filenameTextbox, "The current filename of the loaded file.");
            this.filenameTextbox.TextChanged += new System.EventHandler(this.FilenameTextbox_TextChanged);
            // 
            // pictureBox
            // 
            this.pictureBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox.ContextMenuStrip = this.PictureModeContextMenu;
            this.pictureBox.InitialImage = ((System.Drawing.Image)(resources.GetObject("pictureBox.InitialImage")));
            this.pictureBox.Location = new System.Drawing.Point(490, 7);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(240, 251);
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
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 114);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Add Tag";
            // 
            // addTagButton
            // 
            this.addTagButton.Location = new System.Drawing.Point(241, 110);
            this.addTagButton.Name = "addTagButton";
            this.addTagButton.Size = new System.Drawing.Size(22, 22);
            this.addTagButton.TabIndex = 0;
            this.addTagButton.TabStop = false;
            this.addTagButton.Text = "+";
            this.addTagButton.UseVisualStyleBackColor = true;
            this.addTagButton.Click += new System.EventHandler(this.addTagButton_Click);
            // 
            // openDirectoryButton
            // 
            this.openDirectoryButton.Location = new System.Drawing.Point(8, 7);
            this.openDirectoryButton.Name = "openDirectoryButton";
            this.openDirectoryButton.Size = new System.Drawing.Size(99, 22);
            this.openDirectoryButton.TabIndex = 0;
            this.openDirectoryButton.Text = "Open Directory";
            this.openDirectoryButton.UseVisualStyleBackColor = true;
            this.openDirectoryButton.Click += new System.EventHandler(this.openDirectoryButton_Click);
            // 
            // openFileButton
            // 
            this.openFileButton.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.openFileButton.Location = new System.Drawing.Point(0, 0);
            this.openFileButton.Margin = new System.Windows.Forms.Padding(0);
            this.openFileButton.Name = "openFileButton";
            this.openFileButton.Size = new System.Drawing.Size(120, 23);
            this.openFileButton.TabIndex = 52;
            this.openFileButton.TabStop = false;
            this.openFileButton.Text = "Open File";
            this.tooltip.SetToolTip(this.openFileButton, "Open current file in default program for this filetype");
            this.openFileButton.UseVisualStyleBackColor = true;
            this.openFileButton.Click += new System.EventHandler(this.openFileButton_Click);
            // 
            // openFileInExplorerButton
            // 
            this.openFileInExplorerButton.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.openFileInExplorerButton.AutoSize = true;
            this.openFileInExplorerButton.Location = new System.Drawing.Point(120, 0);
            this.openFileInExplorerButton.Margin = new System.Windows.Forms.Padding(0);
            this.openFileInExplorerButton.Name = "openFileInExplorerButton";
            this.openFileInExplorerButton.Size = new System.Drawing.Size(120, 23);
            this.openFileInExplorerButton.TabIndex = 53;
            this.openFileInExplorerButton.TabStop = false;
            this.openFileInExplorerButton.Text = "Open File In Explorer";
            this.tooltip.SetToolTip(this.openFileInExplorerButton, "View current file in file explorer");
            this.openFileInExplorerButton.UseVisualStyleBackColor = true;
            this.openFileInExplorerButton.Click += new System.EventHandler(this.openFileInExplorerButton_Click);
            // 
            // subfoldersLabel
            // 
            this.subfoldersLabel.AutoSize = true;
            this.subfoldersLabel.Location = new System.Drawing.Point(268, 44);
            this.subfoldersLabel.Name = "subfoldersLabel";
            this.subfoldersLabel.Size = new System.Drawing.Size(94, 13);
            this.subfoldersLabel.TabIndex = 12;
            this.subfoldersLabel.Text = "Move to Subfolder";
            // 
            // fileExtensionTextbox
            // 
            this.fileExtensionTextbox.BackColor = System.Drawing.SystemColors.Control;
            this.fileExtensionTextbox.Location = new System.Drawing.Point(214, 40);
            this.fileExtensionTextbox.Name = "fileExtensionTextbox";
            this.fileExtensionTextbox.ReadOnly = true;
            this.fileExtensionTextbox.Size = new System.Drawing.Size(48, 20);
            this.fileExtensionTextbox.TabIndex = 6;
            this.fileExtensionTextbox.TabStop = false;
            this.tooltip.SetToolTip(this.fileExtensionTextbox, "File extension of currently loaded file.");
            // 
            // tagCreationTextbox
            // 
            this.tagCreationTextbox.Location = new System.Drawing.Point(60, 111);
            this.tagCreationTextbox.Name = "tagCreationTextbox";
            this.tagCreationTextbox.Size = new System.Drawing.Size(178, 20);
            this.tagCreationTextbox.TabIndex = 10;
            this.tooltip.SetToolTip(this.tagCreationTextbox, "You can add a tag to the tags database here.\r\nThis will *not* automatically enabl" +
        "e the tag.\r\nYou can press ENTER instead of pressing the + button if desired.");
            this.tagCreationTextbox.TextChanged += new System.EventHandler(this.TagCreationTextbox_TextChanged);
            // 
            // saveButton
            // 
            this.saveButton.Location = new System.Drawing.Point(333, 7);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(152, 23);
            this.saveButton.TabIndex = 4;
            this.saveButton.TabStop = false;
            this.saveButton.Text = "Save";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // volumeTrackbar
            // 
            this.volumeTrackbar.BackColor = System.Drawing.Color.Transparent;
            this.volumeTrackbar.BorderColor = System.Drawing.SystemColors.ActiveBorder;
            this.volumeTrackbar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.volumeTrackbar.Font = new System.Drawing.Font("Verdana", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.volumeTrackbar.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(123)))), ((int)(((byte)(125)))), ((int)(((byte)(123)))));
            this.volumeTrackbar.IndentHeight = 6;
            this.volumeTrackbar.Location = new System.Drawing.Point(158, 26);
            this.volumeTrackbar.Margin = new System.Windows.Forms.Padding(0, 3, 0, 3);
            this.volumeTrackbar.Maximum = 100;
            this.volumeTrackbar.Minimum = 0;
            this.volumeTrackbar.Name = "volumeTrackbar";
            this.volumeTrackbar.Size = new System.Drawing.Size(81, 25);
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
            // messageTextBox
            // 
            this.messageTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.messageTextBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.messageTextBox.Enabled = false;
            this.messageTextBox.Location = new System.Drawing.Point(490, 7);
            this.messageTextBox.Name = "messageTextBox";
            this.messageTextBox.Size = new System.Drawing.Size(240, 251);
            this.messageTextBox.TabIndex = 0;
            this.messageTextBox.TabStop = false;
            this.messageTextBox.Text = "File format not supported.\n\nYou can view the file by clicking \"Open File\" or \"Ope" +
    "n File In Explorer\" buttons below.";
            // 
            // settingsButton
            // 
            this.settingsButton.Location = new System.Drawing.Point(113, 7);
            this.settingsButton.Name = "settingsButton";
            this.settingsButton.Size = new System.Drawing.Size(83, 22);
            this.settingsButton.TabIndex = 1;
            this.settingsButton.Text = "Settings";
            this.settingsButton.UseVisualStyleBackColor = true;
            this.settingsButton.Click += new System.EventHandler(this.settingsButton_Click);
            // 
            // tagSearchTextbox
            // 
            this.tagSearchTextbox.Location = new System.Drawing.Point(60, 135);
            this.tagSearchTextbox.Name = "tagSearchTextbox";
            this.tagSearchTextbox.Size = new System.Drawing.Size(202, 20);
            this.tagSearchTextbox.TabIndex = 11;
            this.tooltip.SetToolTip(this.tagSearchTextbox, resources.GetString("tagSearchTextbox.ToolTip"));
            this.tagSearchTextbox.TextChanged += new System.EventHandler(this.TagSearchTextbox_TextChanged);
            // 
            // notesTextBox
            // 
            this.notesTextBox.Location = new System.Drawing.Point(60, 87);
            this.notesTextBox.Name = "notesTextBox";
            this.notesTextBox.Size = new System.Drawing.Size(202, 20);
            this.notesTextBox.TabIndex = 9;
            this.tooltip.SetToolTip(this.notesTextBox, "You can add a note to the file\'s new name here.\r\nThe note will be encased in (par" +
        "entheses) at the end of the filename before the file extension.");
            this.notesTextBox.TextChanged += new System.EventHandler(this.NotesTextBox_TextChanged);
            // 
            // newFileNameTextBox
            // 
            this.newFileNameTextBox.BackColor = System.Drawing.SystemColors.Control;
            this.newFileNameTextBox.Location = new System.Drawing.Point(9, 63);
            this.newFileNameTextBox.Name = "newFileNameTextBox";
            this.newFileNameTextBox.ReadOnly = true;
            this.newFileNameTextBox.Size = new System.Drawing.Size(253, 20);
            this.newFileNameTextBox.TabIndex = 8;
            this.newFileNameTextBox.TabStop = false;
            this.tooltip.SetToolTip(this.newFileNameTextBox, "This field previews what the currently loaded file will be renamed to if saved wi" +
        "th the current selected tags / notes.");
            this.newFileNameTextBox.TextChanged += new System.EventHandler(this.FilenameTextbox_TextChanged);
            // 
            // undoButton
            // 
            this.undoButton.Location = new System.Drawing.Point(202, 7);
            this.undoButton.Name = "undoButton";
            this.undoButton.Size = new System.Drawing.Size(61, 23);
            this.undoButton.TabIndex = 2;
            this.undoButton.Text = "Undo";
            this.tooltip.SetToolTip(this.undoButton, "Undo the last file save and reload it\'s tags.");
            this.undoButton.UseVisualStyleBackColor = true;
            this.undoButton.Click += new System.EventHandler(this.undoButton_Click);
            // 
            // firstFileButton
            // 
            this.firstFileButton.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.firstFileButton.Location = new System.Drawing.Point(0, 0);
            this.firstFileButton.Margin = new System.Windows.Forms.Padding(0, 0, 3, 0);
            this.firstFileButton.Name = "firstFileButton";
            this.firstFileButton.Size = new System.Drawing.Size(30, 22);
            this.firstFileButton.TabIndex = 54;
            this.firstFileButton.TabStop = false;
            this.firstFileButton.Text = "<<-";
            this.tooltip.SetToolTip(this.firstFileButton, "Goto first file");
            this.firstFileButton.UseVisualStyleBackColor = true;
            this.firstFileButton.Click += new System.EventHandler(this.firstFileButton_Click);
            // 
            // prevFileButton
            // 
            this.prevFileButton.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.prevFileButton.Location = new System.Drawing.Point(33, 0);
            this.prevFileButton.Margin = new System.Windows.Forms.Padding(0, 0, 3, 0);
            this.prevFileButton.Name = "prevFileButton";
            this.prevFileButton.Size = new System.Drawing.Size(30, 22);
            this.prevFileButton.TabIndex = 55;
            this.prevFileButton.TabStop = false;
            this.prevFileButton.Text = "<-";
            this.tooltip.SetToolTip(this.prevFileButton, "Goto previous file");
            this.prevFileButton.UseVisualStyleBackColor = true;
            this.prevFileButton.Click += new System.EventHandler(this.prevFileButton_Click);
            // 
            // fileCountTextbox
            // 
            this.fileCountTextbox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.fileCountTextbox.Enabled = false;
            this.fileCountTextbox.Location = new System.Drawing.Point(126, 1);
            this.fileCountTextbox.Margin = new System.Windows.Forms.Padding(0, 1, 1, 0);
            this.fileCountTextbox.MinimumSize = new System.Drawing.Size(48, 20);
            this.fileCountTextbox.Name = "fileCountTextbox";
            this.fileCountTextbox.Size = new System.Drawing.Size(48, 20);
            this.fileCountTextbox.TabIndex = 57;
            this.fileCountTextbox.TabStop = false;
            this.tooltip.SetToolTip(this.fileCountTextbox, "File count");
            // 
            // nextFileButton
            // 
            this.nextFileButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.nextFileButton.Location = new System.Drawing.Point(174, 0);
            this.nextFileButton.Margin = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.nextFileButton.Name = "nextFileButton";
            this.nextFileButton.Size = new System.Drawing.Size(30, 22);
            this.nextFileButton.TabIndex = 58;
            this.nextFileButton.TabStop = false;
            this.nextFileButton.Text = "->";
            this.tooltip.SetToolTip(this.nextFileButton, "Goto next file");
            this.nextFileButton.UseVisualStyleBackColor = true;
            this.nextFileButton.Click += new System.EventHandler(this.nextFileButton_Click);
            // 
            // lastFileButton
            // 
            this.lastFileButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.lastFileButton.Location = new System.Drawing.Point(208, 0);
            this.lastFileButton.Margin = new System.Windows.Forms.Padding(4, 0, 0, 0);
            this.lastFileButton.Name = "lastFileButton";
            this.lastFileButton.Size = new System.Drawing.Size(32, 22);
            this.lastFileButton.TabIndex = 59;
            this.lastFileButton.TabStop = false;
            this.lastFileButton.Text = "->>";
            this.tooltip.SetToolTip(this.lastFileButton, "Goto last file");
            this.lastFileButton.UseVisualStyleBackColor = true;
            this.lastFileButton.Click += new System.EventHandler(this.lastFileButton_Click);
            // 
            // videoPauseButton
            // 
            this.videoPauseButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.videoPauseButton.Location = new System.Drawing.Point(79, 0);
            this.videoPauseButton.Margin = new System.Windows.Forms.Padding(0);
            this.videoPauseButton.Name = "videoPauseButton";
            this.videoPauseButton.Size = new System.Drawing.Size(79, 23);
            this.videoPauseButton.TabIndex = 23;
            this.videoPauseButton.TabStop = false;
            this.videoPauseButton.Text = "❚❚";
            this.tooltip.SetToolTip(this.videoPauseButton, "Pause video play");
            this.videoPauseButton.UseVisualStyleBackColor = true;
            this.videoPauseButton.Click += new System.EventHandler(this.videoPauseButton_Click);
            // 
            // videoPlayButton
            // 
            this.videoPlayButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.videoPlayButton.Location = new System.Drawing.Point(0, 0);
            this.videoPlayButton.Margin = new System.Windows.Forms.Padding(0);
            this.videoPlayButton.Name = "videoPlayButton";
            this.videoPlayButton.Size = new System.Drawing.Size(79, 23);
            this.videoPlayButton.TabIndex = 0;
            this.videoPlayButton.TabStop = false;
            this.videoPlayButton.Text = "▶";
            this.tooltip.SetToolTip(this.videoPlayButton, "Resume Video Play");
            this.videoPlayButton.UseVisualStyleBackColor = true;
            this.videoPlayButton.Click += new System.EventHandler(this.videoPlayButton_Click);
            // 
            // muteButton
            // 
            this.muteButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.muteButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.muteButton.Location = new System.Drawing.Point(158, 0);
            this.muteButton.Margin = new System.Windows.Forms.Padding(0);
            this.muteButton.Name = "muteButton";
            this.muteButton.Size = new System.Drawing.Size(81, 23);
            this.muteButton.TabIndex = 0;
            this.muteButton.TabStop = false;
            this.muteButton.Text = "🔊";
            this.tooltip.SetToolTip(this.muteButton, "Mute video");
            this.muteButton.UseVisualStyleBackColor = true;
            this.muteButton.Click += new System.EventHandler(this.muteButton_Click);
            // 
            // tagSearchLabel
            // 
            this.tagSearchLabel.AutoSize = true;
            this.tagSearchLabel.Location = new System.Drawing.Point(7, 139);
            this.tagSearchLabel.Name = "tagSearchLabel";
            this.tagSearchLabel.Size = new System.Drawing.Size(41, 13);
            this.tagSearchLabel.TabIndex = 36;
            this.tagSearchLabel.Text = "Search";
            // 
            // noteLabel
            // 
            this.noteLabel.AutoSize = true;
            this.noteLabel.Location = new System.Drawing.Point(7, 90);
            this.noteLabel.Name = "noteLabel";
            this.noteLabel.Size = new System.Drawing.Size(35, 13);
            this.noteLabel.TabIndex = 38;
            this.noteLabel.Text = "Notes";
            // 
            // deleteButton
            // 
            this.deleteButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.deleteButton.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.deleteButton.Location = new System.Drawing.Point(271, 7);
            this.deleteButton.Name = "deleteButton";
            this.deleteButton.Size = new System.Drawing.Size(56, 23);
            this.deleteButton.TabIndex = 3;
            this.deleteButton.TabStop = false;
            this.deleteButton.Text = "Delete";
            this.deleteButton.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.deleteButton.UseMnemonic = false;
            this.deleteButton.UseVisualStyleBackColor = true;
            this.deleteButton.Click += new System.EventHandler(this.deleteButton_Click);
            // 
            // addDirectoryButton
            // 
            this.addDirectoryButton.Location = new System.Drawing.Point(369, 39);
            this.addDirectoryButton.Name = "addDirectoryButton";
            this.addDirectoryButton.Size = new System.Drawing.Size(116, 22);
            this.addDirectoryButton.TabIndex = 51;
            this.addDirectoryButton.Text = "Add Directory";
            this.addDirectoryButton.UseVisualStyleBackColor = true;
            this.addDirectoryButton.Click += new System.EventHandler(this.AddDirectoryButton_Click);
            // 
            // openFileTableLayoutPanel
            // 
            this.openFileTableLayoutPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.openFileTableLayoutPanel.ColumnCount = 2;
            this.openFileTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.openFileTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.openFileTableLayoutPanel.Controls.Add(this.openFileButton, 0, 0);
            this.openFileTableLayoutPanel.Controls.Add(this.openFileInExplorerButton, 1, 0);
            this.openFileTableLayoutPanel.Location = new System.Drawing.Point(490, 261);
            this.openFileTableLayoutPanel.Name = "openFileTableLayoutPanel";
            this.openFileTableLayoutPanel.RowCount = 1;
            this.openFileTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.openFileTableLayoutPanel.Size = new System.Drawing.Size(240, 23);
            this.openFileTableLayoutPanel.TabIndex = 42;
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.ColumnCount = 7;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 15F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.tableLayoutPanel1.Controls.Add(this.fileIndexTextbox, 2, 0);
            this.tableLayoutPanel1.Controls.Add(this.indexSlashLabel, 3, 0);
            this.tableLayoutPanel1.Controls.Add(this.firstFileButton, 0, 0);
            this.tableLayoutPanel1.Controls.Add(this.prevFileButton, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.nextFileButton, 5, 0);
            this.tableLayoutPanel1.Controls.Add(this.lastFileButton, 6, 0);
            this.tableLayoutPanel1.Controls.Add(this.fileCountTextbox, 4, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(490, 287);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(240, 22);
            this.tableLayoutPanel1.TabIndex = 43;
            // 
            // fileIndexTextbox
            // 
            this.fileIndexTextbox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.fileIndexTextbox.Location = new System.Drawing.Point(67, 1);
            this.fileIndexTextbox.Margin = new System.Windows.Forms.Padding(1, 1, 0, 0);
            this.fileIndexTextbox.MinimumSize = new System.Drawing.Size(48, 20);
            this.fileIndexTextbox.Name = "fileIndexTextbox";
            this.fileIndexTextbox.Size = new System.Drawing.Size(48, 20);
            this.fileIndexTextbox.TabIndex = 56;
            this.fileIndexTextbox.TabStop = false;
            this.fileIndexTextbox.TextChanged += new System.EventHandler(this.fileIndexTextbox_TextChanged);
            // 
            // indexSlashLabel
            // 
            this.indexSlashLabel.AutoSize = true;
            this.indexSlashLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.indexSlashLabel.Location = new System.Drawing.Point(114, 4);
            this.indexSlashLabel.Margin = new System.Windows.Forms.Padding(3, 4, 0, 0);
            this.indexSlashLabel.Name = "indexSlashLabel";
            this.indexSlashLabel.Size = new System.Drawing.Size(12, 18);
            this.indexSlashLabel.TabIndex = 3;
            this.indexSlashLabel.Text = "/";
            // 
            // label2
            // 
            this.label2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label2.Location = new System.Drawing.Point(10, 34);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(473, 1);
            this.label2.TabIndex = 44;
            // 
            // videoPanel
            // 
            this.videoPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.videoPanel.Controls.Add(this.videoControlsTableLayoutPanel);
            this.videoPanel.Location = new System.Drawing.Point(490, 7);
            this.videoPanel.Name = "videoPanel";
            this.videoPanel.Padding = new System.Windows.Forms.Padding(1, 1, 1, 0);
            this.videoPanel.Size = new System.Drawing.Size(241, 251);
            this.videoPanel.TabIndex = 45;
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
            this.videoControlsTableLayoutPanel.Location = new System.Drawing.Point(1, 197);
            this.videoControlsTableLayoutPanel.Margin = new System.Windows.Forms.Padding(0);
            this.videoControlsTableLayoutPanel.Name = "videoControlsTableLayoutPanel";
            this.videoControlsTableLayoutPanel.RowCount = 2;
            this.videoControlsTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 23F));
            this.videoControlsTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 20F));
            this.videoControlsTableLayoutPanel.Size = new System.Drawing.Size(239, 54);
            this.videoControlsTableLayoutPanel.TabIndex = 24;
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
            this.videoPositionTrackBar.Size = new System.Drawing.Size(152, 25);
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
            // subfoldersPanel
            // 
            this.subfoldersPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.subfoldersPanel.AutoScroll = true;
            this.subfoldersPanel.Location = new System.Drawing.Point(271, 69);
            this.subfoldersPanel.Name = "subfoldersPanel";
            this.subfoldersPanel.Size = new System.Drawing.Size(213, 240);
            this.subfoldersPanel.TabIndex = 51;
            // 
            // tagsPanel
            // 
            this.tagsPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.tagsPanel.AutoScroll = true;
            this.tagsPanel.Location = new System.Drawing.Point(8, 161);
            this.tagsPanel.Name = "tagsPanel";
            this.tagsPanel.Size = new System.Drawing.Size(255, 148);
            this.tagsPanel.TabIndex = 12;
            // 
            // SortForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(740, 321);
            this.Controls.Add(this.subfoldersPanel);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.openFileTableLayoutPanel);
            this.Controls.Add(this.undoButton);
            this.Controls.Add(this.addDirectoryButton);
            this.Controls.Add(this.deleteButton);
            this.Controls.Add(this.notesTextBox);
            this.Controls.Add(this.noteLabel);
            this.Controls.Add(this.tagSearchLabel);
            this.Controls.Add(this.tagSearchTextbox);
            this.Controls.Add(this.settingsButton);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.tagCreationTextbox);
            this.Controls.Add(this.fileExtensionTextbox);
            this.Controls.Add(this.subfoldersLabel);
            this.Controls.Add(this.openDirectoryButton);
            this.Controls.Add(this.addTagButton);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.newFileNameTextBox);
            this.Controls.Add(this.filenameTextbox);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Controls.Add(this.videoPanel);
            this.Controls.Add(this.messageTextBox);
            this.Controls.Add(this.pictureBox);
            this.Controls.Add(this.tagsPanel);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MinimumSize = new System.Drawing.Size(756, 360);
            this.Name = "SortForm";
            this.Text = "Sorter Express - Sort";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            this.PictureModeContextMenu.ResumeLayout(false);
            this.openFileTableLayoutPanel.ResumeLayout(false);
            this.openFileTableLayoutPanel.PerformLayout();
            this.tableLayoutPanel1.ResumeLayout(false);
            this.tableLayoutPanel1.PerformLayout();
            this.videoPanel.ResumeLayout(false);
            this.videoControlsTableLayoutPanel.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox filenameTextbox;
        private System.Windows.Forms.PictureBox pictureBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button addTagButton;
        private System.Windows.Forms.Button openDirectoryButton;
        private System.Windows.Forms.Button openFileButton;
        private System.Windows.Forms.Button openFileInExplorerButton;
        private System.Windows.Forms.Label subfoldersLabel;
        private System.Windows.Forms.TextBox fileExtensionTextbox;
        private System.Windows.Forms.TextBox tagCreationTextbox;
        private System.Windows.Forms.Button saveButton;
        private EConTech.Windows.MACUI.MACTrackBar volumeTrackbar;
        private System.Windows.Forms.RichTextBox messageTextBox;
        private System.Windows.Forms.Button settingsButton;
        private System.Windows.Forms.ToolTip tooltip;
        private System.Windows.Forms.ContextMenuStrip PictureModeContextMenu;
        private System.Windows.Forms.ToolStripMenuItem stretchImageToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem zoomToolStripMenuItem;
        private System.Windows.Forms.TextBox tagSearchTextbox;
        private System.Windows.Forms.Label tagSearchLabel;
        private System.Windows.Forms.TextBox notesTextBox;
        private System.Windows.Forms.Label noteLabel;
        private System.Windows.Forms.Button deleteButton;
        private System.Windows.Forms.Button undoButton;
        private System.Windows.Forms.Button addDirectoryButton;
        private System.Windows.Forms.TextBox newFileNameTextBox;
        private System.Windows.Forms.TableLayoutPanel openFileTableLayoutPanel;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Label indexSlashLabel;
        private System.Windows.Forms.Button firstFileButton;
        private System.Windows.Forms.Button prevFileButton;
        private System.Windows.Forms.TextBox fileIndexTextbox;
        private System.Windows.Forms.Button nextFileButton;
        private System.Windows.Forms.Button lastFileButton;
        private System.Windows.Forms.TextBox fileCountTextbox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Panel videoPanel;
        private System.Windows.Forms.TableLayoutPanel videoControlsTableLayoutPanel;
        private System.Windows.Forms.Button muteButton;
        private System.Windows.Forms.Button videoPlayButton;
        private System.Windows.Forms.Button videoPauseButton;
        private ScrollPanel subfoldersPanel;
        private VideoPositionTrackBar videoPositionTrackBar;
        public ScrollPanel tagsPanel;
    }
}

