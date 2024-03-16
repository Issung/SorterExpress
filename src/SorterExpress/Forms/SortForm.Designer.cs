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
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SortForm));
            filenameTextbox = new System.Windows.Forms.TextBox();
            sortControllerBindingSource = new System.Windows.Forms.BindingSource(components);
            label1 = new System.Windows.Forms.Label();
            addTagButton = new System.Windows.Forms.Button();
            openDirectoryButton = new System.Windows.Forms.Button();
            openFileButton = new System.Windows.Forms.Button();
            openFileInExplorerButton = new System.Windows.Forms.Button();
            subfoldersLabel = new System.Windows.Forms.Label();
            fileExtensionTextbox = new System.Windows.Forms.TextBox();
            tagCreationTextBox = new System.Windows.Forms.TextBox();
            saveButton = new System.Windows.Forms.Button();
            settingsButton = new System.Windows.Forms.Button();
            tooltip = new System.Windows.Forms.ToolTip(components);
            tagSearchTextBox = new System.Windows.Forms.TextBox();
            notesTextBox = new System.Windows.Forms.TextBox();
            newFileNameTextBox = new System.Windows.Forms.TextBox();
            undoButton = new System.Windows.Forms.Button();
            firstFileButton = new System.Windows.Forms.Button();
            prevFileButton = new System.Windows.Forms.Button();
            fileCountTextbox = new System.Windows.Forms.TextBox();
            nextFileButton = new System.Windows.Forms.Button();
            lastFileButton = new System.Windows.Forms.Button();
            redoButton = new System.Windows.Forms.Button();
            subfolderSearchTextBox = new System.Windows.Forms.TextBox();
            subfolderSearchDepthNumeric = new System.Windows.Forms.NumericUpDown();
            addDirectoryButton = new System.Windows.Forms.Button();
            tagSearchLabel = new System.Windows.Forms.Label();
            noteLabel = new System.Windows.Forms.Label();
            deleteButton = new System.Windows.Forms.Button();
            openFileTableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            fileIndexTableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            fileIndexTextbox = new System.Windows.Forms.TextBox();
            indexSlashLabel = new System.Windows.Forms.Label();
            seperatorLabel = new System.Windows.Forms.Label();
            loadingPanel = new System.Windows.Forms.Panel();
            loadingTitleTextBox = new System.Windows.Forms.TextBox();
            loadingDescriptionRichTextBox = new System.Windows.Forms.RichTextBox();
            loadingProgressBar = new System.Windows.Forms.ProgressBar();
            subfolderPanel = new Controls.SubfolderPanel();
            tagPanel = new Controls.TagPanel();
            mediaViewer = new Controls.MediaViewer();
            label2 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)sortControllerBindingSource).BeginInit();
            ((System.ComponentModel.ISupportInitialize)subfolderSearchDepthNumeric).BeginInit();
            openFileTableLayoutPanel.SuspendLayout();
            fileIndexTableLayoutPanel.SuspendLayout();
            loadingPanel.SuspendLayout();
            SuspendLayout();
            // 
            // filenameTextbox
            // 
            filenameTextbox.BackColor = System.Drawing.SystemColors.Control;
            filenameTextbox.DataBindings.Add(new System.Windows.Forms.Binding("Text", sortControllerBindingSource, "FilenameNoExtension", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            filenameTextbox.Location = new System.Drawing.Point(10, 46);
            filenameTextbox.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            filenameTextbox.Name = "filenameTextbox";
            filenameTextbox.ReadOnly = true;
            filenameTextbox.Size = new System.Drawing.Size(235, 23);
            filenameTextbox.TabIndex = 5;
            filenameTextbox.TabStop = false;
            tooltip.SetToolTip(filenameTextbox, "The current filename of the loaded file.");
            // 
            // sortControllerBindingSource
            // 
            sortControllerBindingSource.AllowNew = true;
            sortControllerBindingSource.DataSource = typeof(Controllers.SortController);
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new System.Drawing.Point(8, 132);
            label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(50, 15);
            label1.TabIndex = 2;
            label1.Text = "Add Tag";
            // 
            // addTagButton
            // 
            addTagButton.Location = new System.Drawing.Point(281, 127);
            addTagButton.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            addTagButton.Name = "addTagButton";
            addTagButton.Size = new System.Drawing.Size(26, 25);
            addTagButton.TabIndex = 0;
            addTagButton.TabStop = false;
            addTagButton.Text = "+";
            addTagButton.UseVisualStyleBackColor = true;
            addTagButton.Click += addTagButton_Click;
            // 
            // openDirectoryButton
            // 
            openDirectoryButton.Location = new System.Drawing.Point(9, 8);
            openDirectoryButton.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            openDirectoryButton.Name = "openDirectoryButton";
            openDirectoryButton.Size = new System.Drawing.Size(100, 27);
            openDirectoryButton.TabIndex = 0;
            openDirectoryButton.Text = "Open Directory";
            openDirectoryButton.UseVisualStyleBackColor = true;
            openDirectoryButton.Click += openDirectoryButton_Click;
            // 
            // openFileButton
            // 
            openFileButton.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            openFileButton.DataBindings.Add(new System.Windows.Forms.Binding("Enabled", sortControllerBindingSource, "EnabledFileInteractionButtons", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            openFileButton.Location = new System.Drawing.Point(0, 0);
            openFileButton.Margin = new System.Windows.Forms.Padding(0);
            openFileButton.Name = "openFileButton";
            openFileButton.Size = new System.Drawing.Size(144, 27);
            openFileButton.TabIndex = 52;
            openFileButton.TabStop = false;
            openFileButton.Text = "Open File";
            tooltip.SetToolTip(openFileButton, "Open current file in default program for this filetype");
            openFileButton.UseVisualStyleBackColor = true;
            openFileButton.Click += openFileButton_Click;
            // 
            // openFileInExplorerButton
            // 
            openFileInExplorerButton.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            openFileInExplorerButton.AutoSize = true;
            openFileInExplorerButton.DataBindings.Add(new System.Windows.Forms.Binding("Enabled", sortControllerBindingSource, "EnabledFileInteractionButtons", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            openFileInExplorerButton.Location = new System.Drawing.Point(144, 0);
            openFileInExplorerButton.Margin = new System.Windows.Forms.Padding(0);
            openFileInExplorerButton.Name = "openFileInExplorerButton";
            openFileInExplorerButton.Size = new System.Drawing.Size(144, 27);
            openFileInExplorerButton.TabIndex = 53;
            openFileInExplorerButton.TabStop = false;
            openFileInExplorerButton.Text = "Open File In Explorer";
            tooltip.SetToolTip(openFileInExplorerButton, "View current file in file explorer");
            openFileInExplorerButton.UseVisualStyleBackColor = true;
            openFileInExplorerButton.Click += openFileInExplorerButton_Click;
            // 
            // subfoldersLabel
            // 
            subfoldersLabel.AutoSize = true;
            subfoldersLabel.Location = new System.Drawing.Point(313, 51);
            subfoldersLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            subfoldersLabel.Name = "subfoldersLabel";
            subfoldersLabel.Size = new System.Drawing.Size(45, 15);
            subfoldersLabel.TabIndex = 12;
            subfoldersLabel.Text = "Folders";
            tooltip.SetToolTip(subfoldersLabel, resources.GetString("subfoldersLabel.ToolTip"));
            // 
            // fileExtensionTextbox
            // 
            fileExtensionTextbox.BackColor = System.Drawing.SystemColors.Control;
            fileExtensionTextbox.DataBindings.Add(new System.Windows.Forms.Binding("Text", sortControllerBindingSource, "FileExtension", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            fileExtensionTextbox.Location = new System.Drawing.Point(250, 46);
            fileExtensionTextbox.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            fileExtensionTextbox.Name = "fileExtensionTextbox";
            fileExtensionTextbox.ReadOnly = true;
            fileExtensionTextbox.Size = new System.Drawing.Size(55, 23);
            fileExtensionTextbox.TabIndex = 6;
            fileExtensionTextbox.TabStop = false;
            tooltip.SetToolTip(fileExtensionTextbox, "File extension of currently loaded file.");
            // 
            // tagCreationTextBox
            // 
            tagCreationTextBox.Location = new System.Drawing.Point(70, 128);
            tagCreationTextBox.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            tagCreationTextBox.Name = "tagCreationTextBox";
            tagCreationTextBox.Size = new System.Drawing.Size(207, 23);
            tagCreationTextBox.TabIndex = 10;
            tooltip.SetToolTip(tagCreationTextBox, "You can add a tag to the tags database here.\r\nThis will *not* automatically enable the tag.\r\nYou can press ENTER instead of pressing the + button if desired.");
            tagCreationTextBox.TextChanged += tagCreationTextbox_TextChanged;
            tagCreationTextBox.KeyDown += tagCreationTextbox_KeyDown;
            // 
            // saveButton
            // 
            saveButton.DataBindings.Add(new System.Windows.Forms.Binding("Enabled", sortControllerBindingSource, "EnabledFileInteractionButtons", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            saveButton.Location = new System.Drawing.Point(388, 8);
            saveButton.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            saveButton.Name = "saveButton";
            saveButton.Size = new System.Drawing.Size(177, 27);
            saveButton.TabIndex = 4;
            saveButton.TabStop = false;
            saveButton.Text = "Save";
            saveButton.UseVisualStyleBackColor = true;
            saveButton.Click += saveButton_Click;
            // 
            // settingsButton
            // 
            settingsButton.Location = new System.Drawing.Point(117, 8);
            settingsButton.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            settingsButton.Name = "settingsButton";
            settingsButton.Size = new System.Drawing.Size(65, 27);
            settingsButton.TabIndex = 1;
            settingsButton.Text = "Settings";
            settingsButton.UseVisualStyleBackColor = true;
            settingsButton.Click += settingsButton_Click;
            // 
            // tagSearchTextBox
            // 
            tagSearchTextBox.Location = new System.Drawing.Point(70, 156);
            tagSearchTextBox.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            tagSearchTextBox.Name = "tagSearchTextBox";
            tagSearchTextBox.Size = new System.Drawing.Size(235, 23);
            tagSearchTextBox.TabIndex = 11;
            tooltip.SetToolTip(tagSearchTextBox, resources.GetString("tagSearchTextBox.ToolTip"));
            tagSearchTextBox.TextChanged += tagSearchTextbox_TextChanged;
            // 
            // notesTextBox
            // 
            notesTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", sortControllerBindingSource, "Note", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            notesTextBox.Location = new System.Drawing.Point(70, 100);
            notesTextBox.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            notesTextBox.Name = "notesTextBox";
            notesTextBox.Size = new System.Drawing.Size(235, 23);
            notesTextBox.TabIndex = 9;
            tooltip.SetToolTip(notesTextBox, "You can add a note to the file's new name here.\r\nThe note will be encased in (parentheses) at the end of the filename before the file extension.");
            // 
            // newFileNameTextBox
            // 
            newFileNameTextBox.BackColor = System.Drawing.SystemColors.Control;
            newFileNameTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", sortControllerBindingSource, "NewFilename", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            newFileNameTextBox.Location = new System.Drawing.Point(10, 73);
            newFileNameTextBox.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            newFileNameTextBox.Name = "newFileNameTextBox";
            newFileNameTextBox.ReadOnly = true;
            newFileNameTextBox.Size = new System.Drawing.Size(294, 23);
            newFileNameTextBox.TabIndex = 8;
            newFileNameTextBox.TabStop = false;
            tooltip.SetToolTip(newFileNameTextBox, "This field previews what the currently loaded file will be renamed to if saved with the current selected tags / notes.");
            // 
            // undoButton
            // 
            undoButton.DataBindings.Add(new System.Windows.Forms.Binding("Enabled", sortControllerBindingSource, "EnableUndo", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            undoButton.Location = new System.Drawing.Point(189, 8);
            undoButton.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            undoButton.Name = "undoButton";
            undoButton.Size = new System.Drawing.Size(57, 27);
            undoButton.TabIndex = 2;
            undoButton.Text = "Undo";
            tooltip.SetToolTip(undoButton, "Undo the last file save/move and reload it's tags.\r\nCannot yet undo deletes, but you can recover them yourself from the recycle bin!\r\n");
            undoButton.UseVisualStyleBackColor = true;
            undoButton.Click += undoButton_Click;
            // 
            // firstFileButton
            // 
            firstFileButton.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            firstFileButton.DataBindings.Add(new System.Windows.Forms.Binding("Enabled", sortControllerBindingSource, "EnablePreviousButtons", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            firstFileButton.Location = new System.Drawing.Point(0, 0);
            firstFileButton.Margin = new System.Windows.Forms.Padding(0, 0, 4, 0);
            firstFileButton.Name = "firstFileButton";
            firstFileButton.Size = new System.Drawing.Size(36, 25);
            firstFileButton.TabIndex = 54;
            firstFileButton.TabStop = false;
            firstFileButton.Text = "<<-";
            tooltip.SetToolTip(firstFileButton, "Goto first file");
            firstFileButton.UseVisualStyleBackColor = true;
            firstFileButton.Click += firstFileButton_Click;
            // 
            // prevFileButton
            // 
            prevFileButton.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            prevFileButton.DataBindings.Add(new System.Windows.Forms.Binding("Enabled", sortControllerBindingSource, "EnablePreviousButtons", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            prevFileButton.Location = new System.Drawing.Point(40, 0);
            prevFileButton.Margin = new System.Windows.Forms.Padding(0, 0, 4, 0);
            prevFileButton.Name = "prevFileButton";
            prevFileButton.Size = new System.Drawing.Size(36, 25);
            prevFileButton.TabIndex = 55;
            prevFileButton.TabStop = false;
            prevFileButton.Text = "<-";
            tooltip.SetToolTip(prevFileButton, "Goto previous file");
            prevFileButton.UseVisualStyleBackColor = true;
            prevFileButton.Click += prevFileButton_Click;
            // 
            // fileCountTextbox
            // 
            fileCountTextbox.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            fileCountTextbox.DataBindings.Add(new System.Windows.Forms.Binding("Text", sortControllerBindingSource, "FileCount", true));
            fileCountTextbox.Enabled = false;
            fileCountTextbox.Location = new System.Drawing.Point(152, 1);
            fileCountTextbox.Margin = new System.Windows.Forms.Padding(0, 1, 1, 0);
            fileCountTextbox.MinimumSize = new System.Drawing.Size(55, 20);
            fileCountTextbox.Name = "fileCountTextbox";
            fileCountTextbox.Size = new System.Drawing.Size(55, 23);
            fileCountTextbox.TabIndex = 57;
            fileCountTextbox.TabStop = false;
            tooltip.SetToolTip(fileCountTextbox, "File count");
            // 
            // nextFileButton
            // 
            nextFileButton.Anchor = System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            nextFileButton.DataBindings.Add(new System.Windows.Forms.Binding("Enabled", sortControllerBindingSource, "EnabledNextButtons", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            nextFileButton.Location = new System.Drawing.Point(210, 0);
            nextFileButton.Margin = new System.Windows.Forms.Padding(4, 0, 0, 0);
            nextFileButton.Name = "nextFileButton";
            nextFileButton.Size = new System.Drawing.Size(36, 25);
            nextFileButton.TabIndex = 58;
            nextFileButton.TabStop = false;
            nextFileButton.Text = "->";
            tooltip.SetToolTip(nextFileButton, "Goto next file");
            nextFileButton.UseVisualStyleBackColor = true;
            nextFileButton.Click += nextFileButton_Click;
            // 
            // lastFileButton
            // 
            lastFileButton.Anchor = System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            lastFileButton.DataBindings.Add(new System.Windows.Forms.Binding("Enabled", sortControllerBindingSource, "EnabledNextButtons", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            lastFileButton.Location = new System.Drawing.Point(251, 0);
            lastFileButton.Margin = new System.Windows.Forms.Padding(5, 0, 0, 0);
            lastFileButton.Name = "lastFileButton";
            lastFileButton.Size = new System.Drawing.Size(37, 25);
            lastFileButton.TabIndex = 59;
            lastFileButton.TabStop = false;
            lastFileButton.Text = "->>";
            tooltip.SetToolTip(lastFileButton, "Goto last file");
            lastFileButton.UseVisualStyleBackColor = true;
            lastFileButton.Click += lastFileButton_Click;
            // 
            // redoButton
            // 
            redoButton.DataBindings.Add(new System.Windows.Forms.Binding("Enabled", sortControllerBindingSource, "EnableRedo", true));
            redoButton.Location = new System.Drawing.Point(250, 8);
            redoButton.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            redoButton.Name = "redoButton";
            redoButton.Size = new System.Drawing.Size(57, 27);
            redoButton.TabIndex = 53;
            redoButton.Text = "Redo";
            tooltip.SetToolTip(redoButton, "Redo the last undone action.");
            redoButton.UseVisualStyleBackColor = true;
            redoButton.Click += redoButton_Click;
            // 
            // subfolderSearchTextBox
            // 
            subfolderSearchTextBox.Location = new System.Drawing.Point(368, 75);
            subfolderSearchTextBox.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            subfolderSearchTextBox.Name = "subfolderSearchTextBox";
            subfolderSearchTextBox.Size = new System.Drawing.Size(196, 23);
            subfolderSearchTextBox.TabIndex = 58;
            tooltip.SetToolTip(subfolderSearchTextBox, "Search for a subfolder. Press enter to move the current file to the top result.");
            subfolderSearchTextBox.TextChanged += subfolderSearchBox_TextChanged;
            // 
            // subfolderSearchDepthNumeric
            // 
            subfolderSearchDepthNumeric.Location = new System.Drawing.Point(496, 46);
            subfolderSearchDepthNumeric.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            subfolderSearchDepthNumeric.Name = "subfolderSearchDepthNumeric";
            subfolderSearchDepthNumeric.Size = new System.Drawing.Size(68, 23);
            subfolderSearchDepthNumeric.TabIndex = 60;
            tooltip.SetToolTip(subfolderSearchDepthNumeric, "Depth to recursively search for subfolders (0 is immediate subfolders only).");
            subfolderSearchDepthNumeric.ValueChanged += subfolderSearchDepthNumeric_ValueChanged;
            // 
            // addDirectoryButton
            // 
            addDirectoryButton.Location = new System.Drawing.Point(368, 45);
            addDirectoryButton.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            addDirectoryButton.Name = "addDirectoryButton";
            addDirectoryButton.Size = new System.Drawing.Size(121, 25);
            addDirectoryButton.TabIndex = 13;
            addDirectoryButton.Text = "Add Folder";
            tooltip.SetToolTip(addDirectoryButton, "Add a folder anywhere to use for sorting.\r\nAdded folders are saved to settings and seperated from folders in the immediate directory with a divider.\r\n");
            addDirectoryButton.UseVisualStyleBackColor = true;
            addDirectoryButton.Click += addDirectoryButton_Click;
            // 
            // tagSearchLabel
            // 
            tagSearchLabel.AutoSize = true;
            tagSearchLabel.Location = new System.Drawing.Point(8, 160);
            tagSearchLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            tagSearchLabel.Name = "tagSearchLabel";
            tagSearchLabel.Size = new System.Drawing.Size(42, 15);
            tagSearchLabel.TabIndex = 36;
            tagSearchLabel.Text = "Search";
            // 
            // noteLabel
            // 
            noteLabel.AutoSize = true;
            noteLabel.Location = new System.Drawing.Point(8, 104);
            noteLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            noteLabel.Name = "noteLabel";
            noteLabel.Size = new System.Drawing.Size(33, 15);
            noteLabel.TabIndex = 38;
            noteLabel.Text = "Note";
            // 
            // deleteButton
            // 
            deleteButton.DataBindings.Add(new System.Windows.Forms.Binding("Enabled", sortControllerBindingSource, "EnabledFileInteractionButtons", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            deleteButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, 0);
            deleteButton.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            deleteButton.Location = new System.Drawing.Point(316, 8);
            deleteButton.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            deleteButton.Name = "deleteButton";
            deleteButton.Size = new System.Drawing.Size(65, 27);
            deleteButton.TabIndex = 3;
            deleteButton.TabStop = false;
            deleteButton.Text = "Delete";
            deleteButton.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            deleteButton.UseMnemonic = false;
            deleteButton.UseVisualStyleBackColor = true;
            deleteButton.Click += deleteButton_Click;
            // 
            // openFileTableLayoutPanel
            // 
            openFileTableLayoutPanel.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            openFileTableLayoutPanel.ColumnCount = 2;
            openFileTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            openFileTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            openFileTableLayoutPanel.Controls.Add(openFileButton, 0, 0);
            openFileTableLayoutPanel.Controls.Add(openFileInExplorerButton, 1, 0);
            openFileTableLayoutPanel.Location = new System.Drawing.Point(572, 270);
            openFileTableLayoutPanel.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            openFileTableLayoutPanel.Name = "openFileTableLayoutPanel";
            openFileTableLayoutPanel.RowCount = 1;
            openFileTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            openFileTableLayoutPanel.Size = new System.Drawing.Size(288, 27);
            openFileTableLayoutPanel.TabIndex = 42;
            // 
            // fileIndexTableLayoutPanel
            // 
            fileIndexTableLayoutPanel.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            fileIndexTableLayoutPanel.ColumnCount = 7;
            fileIndexTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15F));
            fileIndexTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15F));
            fileIndexTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            fileIndexTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 18F));
            fileIndexTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 20F));
            fileIndexTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15F));
            fileIndexTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 15F));
            fileIndexTableLayoutPanel.Controls.Add(fileIndexTextbox, 2, 0);
            fileIndexTableLayoutPanel.Controls.Add(indexSlashLabel, 3, 0);
            fileIndexTableLayoutPanel.Controls.Add(firstFileButton, 0, 0);
            fileIndexTableLayoutPanel.Controls.Add(prevFileButton, 1, 0);
            fileIndexTableLayoutPanel.Controls.Add(nextFileButton, 5, 0);
            fileIndexTableLayoutPanel.Controls.Add(lastFileButton, 6, 0);
            fileIndexTableLayoutPanel.Controls.Add(fileCountTextbox, 4, 0);
            fileIndexTableLayoutPanel.Location = new System.Drawing.Point(572, 300);
            fileIndexTableLayoutPanel.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            fileIndexTableLayoutPanel.Name = "fileIndexTableLayoutPanel";
            fileIndexTableLayoutPanel.RowCount = 1;
            fileIndexTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            fileIndexTableLayoutPanel.Size = new System.Drawing.Size(288, 25);
            fileIndexTableLayoutPanel.TabIndex = 43;
            // 
            // fileIndexTextbox
            // 
            fileIndexTextbox.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            fileIndexTextbox.DataBindings.Add(new System.Windows.Forms.Binding("Enabled", sortControllerBindingSource, "EnabledFileInteractionButtons", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            fileIndexTextbox.Location = new System.Drawing.Point(81, 1);
            fileIndexTextbox.Margin = new System.Windows.Forms.Padding(1, 1, 0, 0);
            fileIndexTextbox.MinimumSize = new System.Drawing.Size(55, 20);
            fileIndexTextbox.Name = "fileIndexTextbox";
            fileIndexTextbox.Size = new System.Drawing.Size(55, 23);
            fileIndexTextbox.TabIndex = 56;
            fileIndexTextbox.TabStop = false;
            fileIndexTextbox.TextChanged += fileIndexTextbox_TextChanged;
            // 
            // indexSlashLabel
            // 
            indexSlashLabel.AutoSize = true;
            indexSlashLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            indexSlashLabel.Location = new System.Drawing.Point(138, 5);
            indexSlashLabel.Margin = new System.Windows.Forms.Padding(4, 5, 0, 0);
            indexSlashLabel.Name = "indexSlashLabel";
            indexSlashLabel.Size = new System.Drawing.Size(14, 20);
            indexSlashLabel.TabIndex = 3;
            indexSlashLabel.Text = "/";
            // 
            // seperatorLabel
            // 
            seperatorLabel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            seperatorLabel.Location = new System.Drawing.Point(12, 39);
            seperatorLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            seperatorLabel.Name = "seperatorLabel";
            seperatorLabel.Size = new System.Drawing.Size(552, 1);
            seperatorLabel.TabIndex = 44;
            // 
            // loadingPanel
            // 
            loadingPanel.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            loadingPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            loadingPanel.Controls.Add(loadingTitleTextBox);
            loadingPanel.Controls.Add(loadingDescriptionRichTextBox);
            loadingPanel.Controls.Add(loadingProgressBar);
            loadingPanel.Location = new System.Drawing.Point(44, 270);
            loadingPanel.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            loadingPanel.MaximumSize = new System.Drawing.Size(700, 404);
            loadingPanel.MinimumSize = new System.Drawing.Size(420, 196);
            loadingPanel.Name = "loadingPanel";
            loadingPanel.Size = new System.Drawing.Size(435, 234);
            loadingPanel.TabIndex = 57;
            // 
            // loadingTitleTextBox
            // 
            loadingTitleTextBox.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            loadingTitleTextBox.BackColor = System.Drawing.SystemColors.Control;
            loadingTitleTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            loadingTitleTextBox.Enabled = false;
            loadingTitleTextBox.Location = new System.Drawing.Point(4, 17);
            loadingTitleTextBox.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            loadingTitleTextBox.Name = "loadingTitleTextBox";
            loadingTitleTextBox.Size = new System.Drawing.Size(426, 16);
            loadingTitleTextBox.TabIndex = 1;
            loadingTitleTextBox.Text = "Loading...";
            loadingTitleTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // loadingDescriptionRichTextBox
            // 
            loadingDescriptionRichTextBox.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            loadingDescriptionRichTextBox.BackColor = System.Drawing.SystemColors.Control;
            loadingDescriptionRichTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            loadingDescriptionRichTextBox.Enabled = false;
            loadingDescriptionRichTextBox.Location = new System.Drawing.Point(62, 53);
            loadingDescriptionRichTextBox.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            loadingDescriptionRichTextBox.Name = "loadingDescriptionRichTextBox";
            loadingDescriptionRichTextBox.Size = new System.Drawing.Size(309, 121);
            loadingDescriptionRichTextBox.TabIndex = 2;
            loadingDescriptionRichTextBox.Text = "Please Wait";
            // 
            // loadingProgressBar
            // 
            loadingProgressBar.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            loadingProgressBar.Location = new System.Drawing.Point(18, 187);
            loadingProgressBar.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            loadingProgressBar.Name = "loadingProgressBar";
            loadingProgressBar.Size = new System.Drawing.Size(391, 27);
            loadingProgressBar.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            loadingProgressBar.TabIndex = 0;
            // 
            // subfolderPanel
            // 
            subfolderPanel.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
            subfolderPanel.DataBindings.Add(new System.Windows.Forms.Binding("Subfolders", sortControllerBindingSource, "Subfolders", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            subfolderPanel.DataBindings.Add(new System.Windows.Forms.Binding("Enabled", sortControllerBindingSource, "EnabledFileInteractionButtons", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            subfolderPanel.Filter = "";
            subfolderPanel.Location = new System.Drawing.Point(316, 105);
            subfolderPanel.Margin = new System.Windows.Forms.Padding(5, 3, 5, 3);
            subfolderPanel.Name = "subfolderPanel";
            subfolderPanel.Size = new System.Drawing.Size(248, 220);
            subfolderPanel.Subfolders = null;
            subfolderPanel.TabIndex = 14;
            subfolderPanel.SubfolderButtonClicked += subfolderPanel_SubfolderButtonClicked;
            // 
            // tagPanel
            // 
            tagPanel.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left;
            tagPanel.DataBindings.Add(new System.Windows.Forms.Binding("EnabledTags", sortControllerBindingSource, "EnabledTags", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            tagPanel.DataBindings.Add(new System.Windows.Forms.Binding("Tags", sortControllerBindingSource, "Tags", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            tagPanel.EnabledTags = null;
            tagPanel.Location = new System.Drawing.Point(10, 186);
            tagPanel.Margin = new System.Windows.Forms.Padding(5, 3, 5, 3);
            tagPanel.Name = "tagPanel";
            tagPanel.Size = new System.Drawing.Size(295, 140);
            tagPanel.TabIndex = 12;
            tagPanel.Tags = null;
            tagPanel.TagButtonClicked += tagPanel_TagButtonClicked;
            // 
            // mediaViewer
            // 
            mediaViewer.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            mediaViewer.Location = new System.Drawing.Point(572, 8);
            mediaViewer.Margin = new System.Windows.Forms.Padding(5, 3, 5, 3);
            mediaViewer.Name = "mediaViewer";
            mediaViewer.Size = new System.Drawing.Size(288, 255);
            mediaViewer.TabIndex = 54;
            mediaViewer.VideoPosition = -1F;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new System.Drawing.Point(313, 80);
            label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new System.Drawing.Size(42, 15);
            label2.TabIndex = 59;
            label2.Text = "Search";
            // 
            // SortForm
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            ClientSize = new System.Drawing.Size(872, 339);
            Controls.Add(subfolderSearchDepthNumeric);
            Controls.Add(label2);
            Controls.Add(subfolderSearchTextBox);
            Controls.Add(loadingPanel);
            Controls.Add(subfolderPanel);
            Controls.Add(tagPanel);
            Controls.Add(mediaViewer);
            Controls.Add(redoButton);
            Controls.Add(seperatorLabel);
            Controls.Add(openFileTableLayoutPanel);
            Controls.Add(undoButton);
            Controls.Add(addDirectoryButton);
            Controls.Add(deleteButton);
            Controls.Add(notesTextBox);
            Controls.Add(noteLabel);
            Controls.Add(tagSearchLabel);
            Controls.Add(tagSearchTextBox);
            Controls.Add(settingsButton);
            Controls.Add(saveButton);
            Controls.Add(tagCreationTextBox);
            Controls.Add(fileExtensionTextbox);
            Controls.Add(subfoldersLabel);
            Controls.Add(openDirectoryButton);
            Controls.Add(addTagButton);
            Controls.Add(label1);
            Controls.Add(newFileNameTextBox);
            Controls.Add(filenameTextbox);
            Controls.Add(fileIndexTableLayoutPanel);
            Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
            KeyPreview = true;
            Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            MinimumSize = new System.Drawing.Size(872, 340);
            Name = "SortForm";
            Text = "Sorter Express - Sort";
            FormClosed += SortForm_FormClosed;
            Load += SortForm_Load;
            KeyDown += SortForm_KeyDown;
            Resize += SortForm_Resize;
            ((System.ComponentModel.ISupportInitialize)sortControllerBindingSource).EndInit();
            ((System.ComponentModel.ISupportInitialize)subfolderSearchDepthNumeric).EndInit();
            openFileTableLayoutPanel.ResumeLayout(false);
            openFileTableLayoutPanel.PerformLayout();
            fileIndexTableLayoutPanel.ResumeLayout(false);
            fileIndexTableLayoutPanel.PerformLayout();
            loadingPanel.ResumeLayout(false);
            loadingPanel.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
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
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown subfolderSearchDepthNumeric;
    }
}

