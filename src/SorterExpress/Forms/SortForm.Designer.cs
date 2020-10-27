using System.Windows;
using Vlc.DotNet.Core;

namespace SorterExpress.Forms
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
            this.sortControllerBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.label1 = new System.Windows.Forms.Label();
            this.addTagButton = new System.Windows.Forms.Button();
            this.openDirectoryButton = new System.Windows.Forms.Button();
            this.openFileButton = new System.Windows.Forms.Button();
            this.openFileInExplorerButton = new System.Windows.Forms.Button();
            this.subfoldersLabel = new System.Windows.Forms.Label();
            this.fileExtensionTextbox = new System.Windows.Forms.TextBox();
            this.tagCreationTextBox = new System.Windows.Forms.TextBox();
            this.saveButton = new System.Windows.Forms.Button();
            this.settingsButton = new System.Windows.Forms.Button();
            this.tooltip = new System.Windows.Forms.ToolTip(this.components);
            this.tagSearchTextBox = new System.Windows.Forms.TextBox();
            this.notesTextBox = new System.Windows.Forms.TextBox();
            this.newFileNameTextBox = new System.Windows.Forms.TextBox();
            this.undoButton = new System.Windows.Forms.Button();
            this.firstFileButton = new System.Windows.Forms.Button();
            this.prevFileButton = new System.Windows.Forms.Button();
            this.fileCountTextbox = new System.Windows.Forms.TextBox();
            this.nextFileButton = new System.Windows.Forms.Button();
            this.lastFileButton = new System.Windows.Forms.Button();
            this.redoButton = new System.Windows.Forms.Button();
            this.subfolderSearchTextBox = new System.Windows.Forms.TextBox();
            this.tagSearchLabel = new System.Windows.Forms.Label();
            this.noteLabel = new System.Windows.Forms.Label();
            this.deleteButton = new System.Windows.Forms.Button();
            this.addDirectoryButton = new System.Windows.Forms.Button();
            this.openFileTableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.fileIndexTableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.fileIndexTextbox = new System.Windows.Forms.TextBox();
            this.indexSlashLabel = new System.Windows.Forms.Label();
            this.seperatorLabel = new System.Windows.Forms.Label();
            this.loadingPanel = new System.Windows.Forms.Panel();
            this.loadingTitleTextBox = new System.Windows.Forms.TextBox();
            this.loadingDescriptionRichTextBox = new System.Windows.Forms.RichTextBox();
            this.loadingProgressBar = new System.Windows.Forms.ProgressBar();
            this.subfolderPanel = new SorterExpress.Controls.SubfolderPanel();
            this.tagPanel = new SorterExpress.Controls.TagPanel();
            this.mediaViewer = new SorterExpress.Controls.MediaViewer();
            ((System.ComponentModel.ISupportInitialize)(this.sortControllerBindingSource)).BeginInit();
            this.openFileTableLayoutPanel.SuspendLayout();
            this.fileIndexTableLayoutPanel.SuspendLayout();
            this.loadingPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // filenameTextbox
            // 
            this.filenameTextbox.BackColor = System.Drawing.SystemColors.Control;
            this.filenameTextbox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.sortControllerBindingSource, "FilenameNoExtension", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.filenameTextbox.Location = new System.Drawing.Point(9, 40);
            this.filenameTextbox.Name = "filenameTextbox";
            this.filenameTextbox.ReadOnly = true;
            this.filenameTextbox.Size = new System.Drawing.Size(202, 20);
            this.filenameTextbox.TabIndex = 5;
            this.filenameTextbox.TabStop = false;
            this.tooltip.SetToolTip(this.filenameTextbox, "The current filename of the loaded file.");
            // 
            // sortControllerBindingSource
            // 
            this.sortControllerBindingSource.AllowNew = true;
            this.sortControllerBindingSource.DataSource = typeof(SorterExpress.Controllers.SortController);
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
            this.openDirectoryButton.Size = new System.Drawing.Size(86, 23);
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
            this.openFileButton.DataBindings.Add(new System.Windows.Forms.Binding("Enabled", this.sortControllerBindingSource, "EnabledFileInteractionButtons", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.openFileButton.Location = new System.Drawing.Point(0, 0);
            this.openFileButton.Margin = new System.Windows.Forms.Padding(0);
            this.openFileButton.Name = "openFileButton";
            this.openFileButton.Size = new System.Drawing.Size(123, 23);
            this.openFileButton.TabIndex = 52;
            this.openFileButton.TabStop = false;
            this.openFileButton.Text = "Open File";
            this.tooltip.SetToolTip(this.openFileButton, "Open current file in default program for this filetype");
            this.openFileButton.UseVisualStyleBackColor = true;
            // 
            // openFileInExplorerButton
            // 
            this.openFileInExplorerButton.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.openFileInExplorerButton.AutoSize = true;
            this.openFileInExplorerButton.DataBindings.Add(new System.Windows.Forms.Binding("Enabled", this.sortControllerBindingSource, "EnabledFileInteractionButtons", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.openFileInExplorerButton.Location = new System.Drawing.Point(123, 0);
            this.openFileInExplorerButton.Margin = new System.Windows.Forms.Padding(0);
            this.openFileInExplorerButton.Name = "openFileInExplorerButton";
            this.openFileInExplorerButton.Size = new System.Drawing.Size(124, 23);
            this.openFileInExplorerButton.TabIndex = 53;
            this.openFileInExplorerButton.TabStop = false;
            this.openFileInExplorerButton.Text = "Open File In Explorer";
            this.tooltip.SetToolTip(this.openFileInExplorerButton, "View current file in file explorer");
            this.openFileInExplorerButton.UseVisualStyleBackColor = true;
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
            this.fileExtensionTextbox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.sortControllerBindingSource, "FileExtension", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.fileExtensionTextbox.Location = new System.Drawing.Point(214, 40);
            this.fileExtensionTextbox.Name = "fileExtensionTextbox";
            this.fileExtensionTextbox.ReadOnly = true;
            this.fileExtensionTextbox.Size = new System.Drawing.Size(48, 20);
            this.fileExtensionTextbox.TabIndex = 6;
            this.fileExtensionTextbox.TabStop = false;
            this.tooltip.SetToolTip(this.fileExtensionTextbox, "File extension of currently loaded file.");
            // 
            // tagCreationTextBox
            // 
            this.tagCreationTextBox.Location = new System.Drawing.Point(60, 111);
            this.tagCreationTextBox.Name = "tagCreationTextBox";
            this.tagCreationTextBox.Size = new System.Drawing.Size(178, 20);
            this.tagCreationTextBox.TabIndex = 10;
            this.tooltip.SetToolTip(this.tagCreationTextBox, "You can add a tag to the tags database here.\r\nThis will *not* automatically enabl" +
        "e the tag.\r\nYou can press ENTER instead of pressing the + button if desired.");
            this.tagCreationTextBox.TextChanged += new System.EventHandler(this.tagCreationTextbox_TextChanged);
            this.tagCreationTextBox.KeyDown += new System.Windows.Forms.KeyEventHandler(this.tagCreationTextbox_KeyDown);
            // 
            // saveButton
            // 
            this.saveButton.DataBindings.Add(new System.Windows.Forms.Binding("Enabled", this.sortControllerBindingSource, "EnabledFileInteractionButtons", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.saveButton.Location = new System.Drawing.Point(333, 7);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(152, 23);
            this.saveButton.TabIndex = 4;
            this.saveButton.TabStop = false;
            this.saveButton.Text = "Save";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // settingsButton
            // 
            this.settingsButton.Location = new System.Drawing.Point(100, 7);
            this.settingsButton.Name = "settingsButton";
            this.settingsButton.Size = new System.Drawing.Size(56, 23);
            this.settingsButton.TabIndex = 1;
            this.settingsButton.Text = "Settings";
            this.settingsButton.UseVisualStyleBackColor = true;
            this.settingsButton.Click += new System.EventHandler(this.settingsButton_Click);
            // 
            // tagSearchTextBox
            // 
            this.tagSearchTextBox.Location = new System.Drawing.Point(60, 135);
            this.tagSearchTextBox.Name = "tagSearchTextBox";
            this.tagSearchTextBox.Size = new System.Drawing.Size(202, 20);
            this.tagSearchTextBox.TabIndex = 11;
            this.tooltip.SetToolTip(this.tagSearchTextBox, resources.GetString("tagSearchTextBox.ToolTip"));
            this.tagSearchTextBox.TextChanged += new System.EventHandler(this.tagSearchTextbox_TextChanged);
            // 
            // notesTextBox
            // 
            this.notesTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.sortControllerBindingSource, "Note", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.notesTextBox.Location = new System.Drawing.Point(60, 87);
            this.notesTextBox.Name = "notesTextBox";
            this.notesTextBox.Size = new System.Drawing.Size(202, 20);
            this.notesTextBox.TabIndex = 9;
            this.tooltip.SetToolTip(this.notesTextBox, "You can add a note to the file\'s new name here.\r\nThe note will be encased in (par" +
        "entheses) at the end of the filename before the file extension.");
            // 
            // newFileNameTextBox
            // 
            this.newFileNameTextBox.BackColor = System.Drawing.SystemColors.Control;
            this.newFileNameTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.sortControllerBindingSource, "NewFilename", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.newFileNameTextBox.Location = new System.Drawing.Point(9, 63);
            this.newFileNameTextBox.Name = "newFileNameTextBox";
            this.newFileNameTextBox.ReadOnly = true;
            this.newFileNameTextBox.Size = new System.Drawing.Size(253, 20);
            this.newFileNameTextBox.TabIndex = 8;
            this.newFileNameTextBox.TabStop = false;
            this.tooltip.SetToolTip(this.newFileNameTextBox, "This field previews what the currently loaded file will be renamed to if saved wi" +
        "th the current selected tags / notes.");
            // 
            // undoButton
            // 
            this.undoButton.DataBindings.Add(new System.Windows.Forms.Binding("Enabled", this.sortControllerBindingSource, "EnableUndo", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.undoButton.Location = new System.Drawing.Point(162, 7);
            this.undoButton.Name = "undoButton";
            this.undoButton.Size = new System.Drawing.Size(49, 23);
            this.undoButton.TabIndex = 2;
            this.undoButton.Text = "Undo";
            this.tooltip.SetToolTip(this.undoButton, "Undo the last file save/move and reload it\'s tags.\r\nCannot yet undo deletes, but " +
        "you can recover them yourself from the recycle bin!\r\n");
            this.undoButton.UseVisualStyleBackColor = true;
            this.undoButton.Click += new System.EventHandler(this.undoButton_Click);
            // 
            // firstFileButton
            // 
            this.firstFileButton.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.firstFileButton.DataBindings.Add(new System.Windows.Forms.Binding("Enabled", this.sortControllerBindingSource, "EnablePreviousButtons", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.firstFileButton.Location = new System.Drawing.Point(0, 0);
            this.firstFileButton.Margin = new System.Windows.Forms.Padding(0, 0, 3, 0);
            this.firstFileButton.Name = "firstFileButton";
            this.firstFileButton.Size = new System.Drawing.Size(31, 22);
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
            this.prevFileButton.DataBindings.Add(new System.Windows.Forms.Binding("Enabled", this.sortControllerBindingSource, "EnablePreviousButtons", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.prevFileButton.Location = new System.Drawing.Point(34, 0);
            this.prevFileButton.Margin = new System.Windows.Forms.Padding(0, 0, 3, 0);
            this.prevFileButton.Name = "prevFileButton";
            this.prevFileButton.Size = new System.Drawing.Size(31, 22);
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
            this.fileCountTextbox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.sortControllerBindingSource, "FileCount", true));
            this.fileCountTextbox.Enabled = false;
            this.fileCountTextbox.Location = new System.Drawing.Point(129, 1);
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
            this.nextFileButton.DataBindings.Add(new System.Windows.Forms.Binding("Enabled", this.sortControllerBindingSource, "EnabledNextButtons", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.nextFileButton.Location = new System.Drawing.Point(178, 0);
            this.nextFileButton.Margin = new System.Windows.Forms.Padding(3, 0, 0, 0);
            this.nextFileButton.Name = "nextFileButton";
            this.nextFileButton.Size = new System.Drawing.Size(31, 22);
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
            this.lastFileButton.DataBindings.Add(new System.Windows.Forms.Binding("Enabled", this.sortControllerBindingSource, "EnabledNextButtons", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.lastFileButton.Location = new System.Drawing.Point(213, 0);
            this.lastFileButton.Margin = new System.Windows.Forms.Padding(4, 0, 0, 0);
            this.lastFileButton.Name = "lastFileButton";
            this.lastFileButton.Size = new System.Drawing.Size(34, 22);
            this.lastFileButton.TabIndex = 59;
            this.lastFileButton.TabStop = false;
            this.lastFileButton.Text = "->>";
            this.tooltip.SetToolTip(this.lastFileButton, "Goto last file");
            this.lastFileButton.UseVisualStyleBackColor = true;
            this.lastFileButton.Click += new System.EventHandler(this.lastFileButton_Click);
            // 
            // redoButton
            // 
            this.redoButton.DataBindings.Add(new System.Windows.Forms.Binding("Enabled", this.sortControllerBindingSource, "EnableRedo", true));
            this.redoButton.Location = new System.Drawing.Point(214, 7);
            this.redoButton.Name = "redoButton";
            this.redoButton.Size = new System.Drawing.Size(49, 23);
            this.redoButton.TabIndex = 53;
            this.redoButton.Text = "Redo";
            this.tooltip.SetToolTip(this.redoButton, "Redo the last undone action.");
            this.redoButton.UseVisualStyleBackColor = true;
            this.redoButton.Click += new System.EventHandler(this.redoButton_Click);
            // 
            // subfolderSearchTextBox
            // 
            this.subfolderSearchTextBox.Location = new System.Drawing.Point(271, 65);
            this.subfolderSearchTextBox.Name = "subfolderSearchTextBox";
            this.subfolderSearchTextBox.Size = new System.Drawing.Size(213, 20);
            this.subfolderSearchTextBox.TabIndex = 58;
            this.tooltip.SetToolTip(this.subfolderSearchTextBox, "Search for a subfolder. Press enter to move the current file to the top result.");
            this.subfolderSearchTextBox.TextChanged += new System.EventHandler(this.subfolderSearchBox_TextChanged);
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
            this.noteLabel.Size = new System.Drawing.Size(30, 13);
            this.noteLabel.TabIndex = 38;
            this.noteLabel.Text = "Note";
            // 
            // deleteButton
            // 
            this.deleteButton.DataBindings.Add(new System.Windows.Forms.Binding("Enabled", this.sortControllerBindingSource, "EnabledFileInteractionButtons", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
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
            this.addDirectoryButton.TabIndex = 13;
            this.addDirectoryButton.Text = "Add Directory";
            this.addDirectoryButton.UseVisualStyleBackColor = true;
            this.addDirectoryButton.Click += new System.EventHandler(this.addDirectoryButton_Click);
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
            this.openFileTableLayoutPanel.Location = new System.Drawing.Point(490, 234);
            this.openFileTableLayoutPanel.Name = "openFileTableLayoutPanel";
            this.openFileTableLayoutPanel.RowCount = 1;
            this.openFileTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.openFileTableLayoutPanel.Size = new System.Drawing.Size(247, 23);
            this.openFileTableLayoutPanel.TabIndex = 42;
            // 
            // fileIndexTableLayoutPanel
            // 
            this.fileIndexTableLayoutPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.fileIndexTableLayoutPanel.ColumnCount = 7;
            this.fileIndexTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.fileIndexTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.fileIndexTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.fileIndexTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 15F));
            this.fileIndexTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            this.fileIndexTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.fileIndexTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15F));
            this.fileIndexTableLayoutPanel.Controls.Add(this.fileIndexTextbox, 2, 0);
            this.fileIndexTableLayoutPanel.Controls.Add(this.indexSlashLabel, 3, 0);
            this.fileIndexTableLayoutPanel.Controls.Add(this.firstFileButton, 0, 0);
            this.fileIndexTableLayoutPanel.Controls.Add(this.prevFileButton, 1, 0);
            this.fileIndexTableLayoutPanel.Controls.Add(this.nextFileButton, 5, 0);
            this.fileIndexTableLayoutPanel.Controls.Add(this.lastFileButton, 6, 0);
            this.fileIndexTableLayoutPanel.Controls.Add(this.fileCountTextbox, 4, 0);
            this.fileIndexTableLayoutPanel.Location = new System.Drawing.Point(490, 260);
            this.fileIndexTableLayoutPanel.Name = "fileIndexTableLayoutPanel";
            this.fileIndexTableLayoutPanel.RowCount = 1;
            this.fileIndexTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.fileIndexTableLayoutPanel.Size = new System.Drawing.Size(247, 22);
            this.fileIndexTableLayoutPanel.TabIndex = 43;
            // 
            // fileIndexTextbox
            // 
            this.fileIndexTextbox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.fileIndexTextbox.DataBindings.Add(new System.Windows.Forms.Binding("Enabled", this.sortControllerBindingSource, "EnabledFileInteractionButtons", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.fileIndexTextbox.Location = new System.Drawing.Point(69, 1);
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
            this.indexSlashLabel.Location = new System.Drawing.Point(117, 4);
            this.indexSlashLabel.Margin = new System.Windows.Forms.Padding(3, 4, 0, 0);
            this.indexSlashLabel.Name = "indexSlashLabel";
            this.indexSlashLabel.Size = new System.Drawing.Size(12, 18);
            this.indexSlashLabel.TabIndex = 3;
            this.indexSlashLabel.Text = "/";
            // 
            // seperatorLabel
            // 
            this.seperatorLabel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.seperatorLabel.Location = new System.Drawing.Point(10, 34);
            this.seperatorLabel.Name = "seperatorLabel";
            this.seperatorLabel.Size = new System.Drawing.Size(473, 1);
            this.seperatorLabel.TabIndex = 44;
            // 
            // loadingPanel
            // 
            this.loadingPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.loadingPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.loadingPanel.Controls.Add(this.loadingTitleTextBox);
            this.loadingPanel.Controls.Add(this.loadingDescriptionRichTextBox);
            this.loadingPanel.Controls.Add(this.loadingProgressBar);
            this.loadingPanel.Location = new System.Drawing.Point(38, 234);
            this.loadingPanel.MaximumSize = new System.Drawing.Size(600, 350);
            this.loadingPanel.MinimumSize = new System.Drawing.Size(360, 170);
            this.loadingPanel.Name = "loadingPanel";
            this.loadingPanel.Size = new System.Drawing.Size(373, 203);
            this.loadingPanel.TabIndex = 57;
            // 
            // loadingTitleTextBox
            // 
            this.loadingTitleTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.loadingTitleTextBox.BackColor = System.Drawing.SystemColors.Control;
            this.loadingTitleTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.loadingTitleTextBox.Enabled = false;
            this.loadingTitleTextBox.Location = new System.Drawing.Point(3, 15);
            this.loadingTitleTextBox.Name = "loadingTitleTextBox";
            this.loadingTitleTextBox.Size = new System.Drawing.Size(365, 13);
            this.loadingTitleTextBox.TabIndex = 1;
            this.loadingTitleTextBox.Text = "Loading...";
            this.loadingTitleTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // loadingDescriptionRichTextBox
            // 
            this.loadingDescriptionRichTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.loadingDescriptionRichTextBox.BackColor = System.Drawing.SystemColors.Control;
            this.loadingDescriptionRichTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.loadingDescriptionRichTextBox.Enabled = false;
            this.loadingDescriptionRichTextBox.Location = new System.Drawing.Point(53, 46);
            this.loadingDescriptionRichTextBox.Name = "loadingDescriptionRichTextBox";
            this.loadingDescriptionRichTextBox.Size = new System.Drawing.Size(265, 105);
            this.loadingDescriptionRichTextBox.TabIndex = 2;
            this.loadingDescriptionRichTextBox.Text = "Please Wait";
            // 
            // loadingProgressBar
            // 
            this.loadingProgressBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.loadingProgressBar.Location = new System.Drawing.Point(15, 162);
            this.loadingProgressBar.Name = "loadingProgressBar";
            this.loadingProgressBar.Size = new System.Drawing.Size(335, 23);
            this.loadingProgressBar.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            this.loadingProgressBar.TabIndex = 0;
            // 
            // subfolderPanel
            // 
            this.subfolderPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.subfolderPanel.DataBindings.Add(new System.Windows.Forms.Binding("Subfolders", this.sortControllerBindingSource, "Subfolders", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.subfolderPanel.DataBindings.Add(new System.Windows.Forms.Binding("Enabled", this.sortControllerBindingSource, "EnabledFileInteractionButtons", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.subfolderPanel.Filter = "";
            this.subfolderPanel.Location = new System.Drawing.Point(271, 91);
            this.subfolderPanel.Name = "subfolderPanel";
            this.subfolderPanel.Size = new System.Drawing.Size(213, 191);
            this.subfolderPanel.Subfolders = null;
            this.subfolderPanel.TabIndex = 14;
            this.subfolderPanel.SubfolderButtonClicked += new System.EventHandler<SorterExpress.Controls.SubfolderButtonClickedEventArgs>(this.subfolderPanel_SubfolderButtonClicked);
            // 
            // tagPanel
            // 
            this.tagPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.tagPanel.DataBindings.Add(new System.Windows.Forms.Binding("EnabledTags", this.sortControllerBindingSource, "EnabledTags", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.tagPanel.DataBindings.Add(new System.Windows.Forms.Binding("Tags", this.sortControllerBindingSource, "Tags", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.tagPanel.EnabledTags = null;
            this.tagPanel.Location = new System.Drawing.Point(9, 161);
            this.tagPanel.Name = "tagPanel";
            this.tagPanel.Size = new System.Drawing.Size(253, 121);
            this.tagPanel.TabIndex = 12;
            this.tagPanel.Tags = null;
            this.tagPanel.TagButtonClicked += new System.EventHandler<SorterExpress.Controls.TagButtonClickedEventArgs>(this.tagPanel_TagButtonClicked);
            // 
            // mediaViewer
            // 
            this.mediaViewer.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.mediaViewer.Location = new System.Drawing.Point(490, 7);
            this.mediaViewer.Name = "mediaViewer";
            this.mediaViewer.Size = new System.Drawing.Size(247, 221);
            this.mediaViewer.TabIndex = 54;
            this.mediaViewer.VideoPosition = -1F;
            // 
            // SortForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(747, 294);
            this.Controls.Add(this.subfolderSearchTextBox);
            this.Controls.Add(this.loadingPanel);
            this.Controls.Add(this.subfolderPanel);
            this.Controls.Add(this.tagPanel);
            this.Controls.Add(this.mediaViewer);
            this.Controls.Add(this.redoButton);
            this.Controls.Add(this.seperatorLabel);
            this.Controls.Add(this.openFileTableLayoutPanel);
            this.Controls.Add(this.undoButton);
            this.Controls.Add(this.addDirectoryButton);
            this.Controls.Add(this.deleteButton);
            this.Controls.Add(this.notesTextBox);
            this.Controls.Add(this.noteLabel);
            this.Controls.Add(this.tagSearchLabel);
            this.Controls.Add(this.tagSearchTextBox);
            this.Controls.Add(this.settingsButton);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.tagCreationTextBox);
            this.Controls.Add(this.fileExtensionTextbox);
            this.Controls.Add(this.subfoldersLabel);
            this.Controls.Add(this.openDirectoryButton);
            this.Controls.Add(this.addTagButton);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.newFileNameTextBox);
            this.Controls.Add(this.filenameTextbox);
            this.Controls.Add(this.fileIndexTableLayoutPanel);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MinimumSize = new System.Drawing.Size(750, 300);
            this.Name = "SortForm";
            this.Text = "Sorter Express - Sort";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.SortForm_FormClosed);
            this.Load += new System.EventHandler(this.SortForm_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.SortForm_KeyDown);
            this.Resize += new System.EventHandler(this.SortForm_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.sortControllerBindingSource)).EndInit();
            this.openFileTableLayoutPanel.ResumeLayout(false);
            this.openFileTableLayoutPanel.PerformLayout();
            this.fileIndexTableLayoutPanel.ResumeLayout(false);
            this.fileIndexTableLayoutPanel.PerformLayout();
            this.loadingPanel.ResumeLayout(false);
            this.loadingPanel.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox filenameTextbox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button openDirectoryButton;
        private System.Windows.Forms.Button openFileButton;
        private System.Windows.Forms.Button openFileInExplorerButton;
        private System.Windows.Forms.Label subfoldersLabel;
        private System.Windows.Forms.TextBox fileExtensionTextbox;
        private System.Windows.Forms.Button settingsButton;
        private System.Windows.Forms.ToolTip tooltip;
        private System.Windows.Forms.Label tagSearchLabel;
        private System.Windows.Forms.Label noteLabel;
        private System.Windows.Forms.Button deleteButton;
        private System.Windows.Forms.Button addDirectoryButton;
        private System.Windows.Forms.TextBox newFileNameTextBox;
        private System.Windows.Forms.TableLayoutPanel openFileTableLayoutPanel;
        private System.Windows.Forms.TableLayoutPanel fileIndexTableLayoutPanel;
        private System.Windows.Forms.Label indexSlashLabel;
        private System.Windows.Forms.Button firstFileButton;
        private System.Windows.Forms.Button prevFileButton;
        private System.Windows.Forms.TextBox fileIndexTextbox;
        private System.Windows.Forms.Button nextFileButton;
        private System.Windows.Forms.Button lastFileButton;
        private System.Windows.Forms.TextBox fileCountTextbox;
        private System.Windows.Forms.Label seperatorLabel;
        public System.Windows.Forms.TextBox notesTextBox;
        public Controls.MediaViewer mediaViewer;
        private System.Windows.Forms.BindingSource sortControllerBindingSource;
        internal System.Windows.Forms.Button undoButton;
        internal System.Windows.Forms.Button redoButton;
        internal System.Windows.Forms.TextBox tagSearchTextBox;
        public Controls.SubfolderPanel subfolderPanel;
        public System.Windows.Forms.Panel loadingPanel;
        public System.Windows.Forms.TextBox loadingTitleTextBox;
        public System.Windows.Forms.RichTextBox loadingDescriptionRichTextBox;
        public System.Windows.Forms.ProgressBar loadingProgressBar;
        internal Controls.TagPanel tagPanel;
        public System.Windows.Forms.TextBox tagCreationTextBox;
        internal System.Windows.Forms.Button addTagButton;
        public System.Windows.Forms.Button saveButton;
        public System.Windows.Forms.TextBox subfolderSearchTextBox;
    }
}

