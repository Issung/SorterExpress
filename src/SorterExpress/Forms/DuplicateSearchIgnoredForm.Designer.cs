
namespace SorterExpress.Forms
{
    partial class DuplicateSearchIgnoredForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DuplicateSearchIgnoredForm));
            this.directoryContextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.directoryContextMenuOpenInExplorerButton = new System.Windows.Forms.ToolStripMenuItem();
            this.directoryContextMenuRemoveButton = new System.Windows.Forms.ToolStripMenuItem();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.saveButton = new System.Windows.Forms.Button();
            this.saveAndExitButton = new System.Windows.Forms.Button();
            this.tableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.topPanel = new System.Windows.Forms.Panel();
            this.directoryAddButton = new System.Windows.Forms.Button();
            this.directoryRemoveButton = new System.Windows.Forms.Button();
            this.directoryRemoveAllButton = new System.Windows.Forms.Button();
            this.directoryListBox = new System.Windows.Forms.ListBox();
            this.bindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.ignoredDirectoriesLabel = new System.Windows.Forms.Label();
            this.bottomPanel = new System.Windows.Forms.Panel();
            this.filesAddButton = new System.Windows.Forms.Button();
            this.filesRemoveButton = new System.Windows.Forms.Button();
            this.filesRemoveAllButton = new System.Windows.Forms.Button();
            this.filesListBox = new System.Windows.Forms.ListBox();
            this.fileContextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.fileContextMenuOpenButton = new System.Windows.Forms.ToolStripMenuItem();
            this.fileContextMenuOpenInExplorerButton = new System.Windows.Forms.ToolStripMenuItem();
            this.fileContextMenuRemoveButton = new System.Windows.Forms.ToolStripMenuItem();
            this.ignoredFilesLabel = new System.Windows.Forms.Label();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.directoryContextMenuStrip.SuspendLayout();
            this.tableLayoutPanel.SuspendLayout();
            this.topPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).BeginInit();
            this.bottomPanel.SuspendLayout();
            this.fileContextMenuStrip.SuspendLayout();
            this.tableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // directoryContextMenuStrip
            // 
            this.directoryContextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.directoryContextMenuOpenInExplorerButton,
            this.directoryContextMenuRemoveButton});
            this.directoryContextMenuStrip.Name = "contextMenuStrip";
            this.directoryContextMenuStrip.Size = new System.Drawing.Size(163, 48);
            // 
            // directoryContextMenuOpenInExplorerButton
            // 
            this.directoryContextMenuOpenInExplorerButton.Image = global::SorterExpress.Properties.Resources.folder;
            this.directoryContextMenuOpenInExplorerButton.Name = "directoryContextMenuOpenInExplorerButton";
            this.directoryContextMenuOpenInExplorerButton.Size = new System.Drawing.Size(162, 22);
            this.directoryContextMenuOpenInExplorerButton.Text = "Open in &Explorer";
            this.directoryContextMenuOpenInExplorerButton.Click += new System.EventHandler(this.directoryContextMenuOpenInExplorerButton_Click);
            // 
            // directoryContextMenuRemoveButton
            // 
            this.directoryContextMenuRemoveButton.Image = global::SorterExpress.Properties.Resources.close;
            this.directoryContextMenuRemoveButton.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.directoryContextMenuRemoveButton.Name = "directoryContextMenuRemoveButton";
            this.directoryContextMenuRemoveButton.ShortcutKeys = System.Windows.Forms.Keys.Delete;
            this.directoryContextMenuRemoveButton.Size = new System.Drawing.Size(162, 22);
            this.directoryContextMenuRemoveButton.Text = "Remove";
            this.directoryContextMenuRemoveButton.Click += new System.EventHandler(this.directoryContextMenuRemoveButton_Click);
            // 
            // saveButton
            // 
            this.saveButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.saveButton.Location = new System.Drawing.Point(3, 3);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(271, 21);
            this.saveButton.TabIndex = 1;
            this.saveButton.Text = "Save";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // saveAndExitButton
            // 
            this.saveAndExitButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.saveAndExitButton.Location = new System.Drawing.Point(280, 3);
            this.saveAndExitButton.Name = "saveAndExitButton";
            this.saveAndExitButton.Size = new System.Drawing.Size(272, 21);
            this.saveAndExitButton.TabIndex = 0;
            this.saveAndExitButton.Text = "Save and Exit";
            this.saveAndExitButton.UseVisualStyleBackColor = true;
            this.saveAndExitButton.Click += new System.EventHandler(this.saveAndExitButton_Click);
            // 
            // tableLayoutPanel
            // 
            this.tableLayoutPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.tableLayoutPanel.ColumnCount = 1;
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel.Controls.Add(this.topPanel, 0, 0);
            this.tableLayoutPanel.Controls.Add(this.bottomPanel, 0, 1);
            this.tableLayoutPanel.GrowStyle = System.Windows.Forms.TableLayoutPanelGrowStyle.FixedSize;
            this.tableLayoutPanel.Location = new System.Drawing.Point(9, 9);
            this.tableLayoutPanel.Name = "tableLayoutPanel";
            this.tableLayoutPanel.RowCount = 2;
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel.Size = new System.Drawing.Size(554, 428);
            this.tableLayoutPanel.TabIndex = 4;
            // 
            // topPanel
            // 
            this.topPanel.Controls.Add(this.directoryAddButton);
            this.topPanel.Controls.Add(this.directoryRemoveButton);
            this.topPanel.Controls.Add(this.directoryRemoveAllButton);
            this.topPanel.Controls.Add(this.directoryListBox);
            this.topPanel.Controls.Add(this.ignoredDirectoriesLabel);
            this.topPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.topPanel.Location = new System.Drawing.Point(3, 3);
            this.topPanel.Name = "topPanel";
            this.topPanel.Padding = new System.Windows.Forms.Padding(4);
            this.topPanel.Size = new System.Drawing.Size(548, 208);
            this.topPanel.TabIndex = 0;
            // 
            // directoryAddButton
            // 
            this.directoryAddButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.directoryAddButton.Location = new System.Drawing.Point(379, 23);
            this.directoryAddButton.Name = "directoryAddButton";
            this.directoryAddButton.Size = new System.Drawing.Size(162, 23);
            this.directoryAddButton.TabIndex = 2;
            this.directoryAddButton.Text = "Add Directories";
            this.directoryAddButton.UseVisualStyleBackColor = true;
            this.directoryAddButton.Click += new System.EventHandler(this.directoryAddButton_Click);
            // 
            // directoryRemoveButton
            // 
            this.directoryRemoveButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.directoryRemoveButton.Location = new System.Drawing.Point(379, 52);
            this.directoryRemoveButton.Name = "directoryRemoveButton";
            this.directoryRemoveButton.Size = new System.Drawing.Size(162, 23);
            this.directoryRemoveButton.TabIndex = 3;
            this.directoryRemoveButton.Text = "Remove Selected";
            this.directoryRemoveButton.UseVisualStyleBackColor = true;
            this.directoryRemoveButton.Click += new System.EventHandler(this.directoryRemoveButton_Click);
            // 
            // directoryRemoveAllButton
            // 
            this.directoryRemoveAllButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.directoryRemoveAllButton.Location = new System.Drawing.Point(379, 81);
            this.directoryRemoveAllButton.Name = "directoryRemoveAllButton";
            this.directoryRemoveAllButton.Size = new System.Drawing.Size(162, 23);
            this.directoryRemoveAllButton.TabIndex = 4;
            this.directoryRemoveAllButton.Text = "Remove All";
            this.directoryRemoveAllButton.UseVisualStyleBackColor = true;
            this.directoryRemoveAllButton.Click += new System.EventHandler(this.directoryRemoveAllButton_Click);
            // 
            // directoryListBox
            // 
            this.directoryListBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.directoryListBox.ContextMenuStrip = this.directoryContextMenuStrip;
            this.directoryListBox.DataBindings.Add(new System.Windows.Forms.Binding("DataSource", this.bindingSource, "Directories", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.directoryListBox.FormattingEnabled = true;
            this.directoryListBox.IntegralHeight = false;
            this.directoryListBox.Location = new System.Drawing.Point(10, 23);
            this.directoryListBox.Name = "directoryListBox";
            this.directoryListBox.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.directoryListBox.Size = new System.Drawing.Size(363, 186);
            this.directoryListBox.TabIndex = 1;
            this.directoryListBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.listBox_MouseDown);
            // 
            // bindingSource
            // 
            this.bindingSource.DataSource = typeof(SorterExpress.Forms.DuplicatesIgnoreModel);
            // 
            // ignoredDirectoriesLabel
            // 
            this.ignoredDirectoriesLabel.AutoSize = true;
            this.ignoredDirectoriesLabel.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "DirectoryCount", true));
            this.ignoredDirectoriesLabel.Location = new System.Drawing.Point(7, 4);
            this.ignoredDirectoriesLabel.Name = "ignoredDirectoriesLabel";
            this.ignoredDirectoriesLabel.Size = new System.Drawing.Size(96, 13);
            this.ignoredDirectoriesLabel.TabIndex = 0;
            this.ignoredDirectoriesLabel.Text = "Ignored Directories";
            // 
            // bottomPanel
            // 
            this.bottomPanel.Controls.Add(this.filesAddButton);
            this.bottomPanel.Controls.Add(this.filesRemoveButton);
            this.bottomPanel.Controls.Add(this.filesRemoveAllButton);
            this.bottomPanel.Controls.Add(this.filesListBox);
            this.bottomPanel.Controls.Add(this.ignoredFilesLabel);
            this.bottomPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.bottomPanel.Location = new System.Drawing.Point(3, 217);
            this.bottomPanel.Name = "bottomPanel";
            this.bottomPanel.Padding = new System.Windows.Forms.Padding(4);
            this.bottomPanel.Size = new System.Drawing.Size(548, 208);
            this.bottomPanel.TabIndex = 1;
            // 
            // filesAddButton
            // 
            this.filesAddButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.filesAddButton.Location = new System.Drawing.Point(379, 21);
            this.filesAddButton.Name = "filesAddButton";
            this.filesAddButton.Size = new System.Drawing.Size(162, 23);
            this.filesAddButton.TabIndex = 7;
            this.filesAddButton.Text = "Add Files";
            this.filesAddButton.UseVisualStyleBackColor = true;
            this.filesAddButton.Click += new System.EventHandler(this.fileAddButton_Click);
            // 
            // filesRemoveButton
            // 
            this.filesRemoveButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.filesRemoveButton.Location = new System.Drawing.Point(379, 50);
            this.filesRemoveButton.Name = "filesRemoveButton";
            this.filesRemoveButton.Size = new System.Drawing.Size(162, 23);
            this.filesRemoveButton.TabIndex = 8;
            this.filesRemoveButton.Text = "Remove Selected";
            this.filesRemoveButton.UseVisualStyleBackColor = true;
            this.filesRemoveButton.Click += new System.EventHandler(this.fileRemoveButton_Click);
            // 
            // filesRemoveAllButton
            // 
            this.filesRemoveAllButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.filesRemoveAllButton.Location = new System.Drawing.Point(379, 79);
            this.filesRemoveAllButton.Name = "filesRemoveAllButton";
            this.filesRemoveAllButton.Size = new System.Drawing.Size(162, 23);
            this.filesRemoveAllButton.TabIndex = 9;
            this.filesRemoveAllButton.Text = "Remove All";
            this.filesRemoveAllButton.UseVisualStyleBackColor = true;
            this.filesRemoveAllButton.Click += new System.EventHandler(this.fileRemoveAllButton_Click);
            // 
            // filesListBox
            // 
            this.filesListBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.filesListBox.ContextMenuStrip = this.fileContextMenuStrip;
            this.filesListBox.DataBindings.Add(new System.Windows.Forms.Binding("DataSource", this.bindingSource, "Files", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.filesListBox.FormattingEnabled = true;
            this.filesListBox.IntegralHeight = false;
            this.filesListBox.Location = new System.Drawing.Point(10, 21);
            this.filesListBox.Name = "filesListBox";
            this.filesListBox.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.filesListBox.Size = new System.Drawing.Size(363, 186);
            this.filesListBox.TabIndex = 6;
            this.filesListBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.listBox_MouseDown);
            // 
            // fileContextMenuStrip
            // 
            this.fileContextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileContextMenuOpenButton,
            this.fileContextMenuOpenInExplorerButton,
            this.fileContextMenuRemoveButton});
            this.fileContextMenuStrip.Name = "contextMenuStrip";
            this.fileContextMenuStrip.Size = new System.Drawing.Size(163, 70);
            // 
            // fileContextMenuOpenButton
            // 
            this.fileContextMenuOpenButton.Image = global::SorterExpress.Properties.Resources.file;
            this.fileContextMenuOpenButton.Name = "fileContextMenuOpenButton";
            this.fileContextMenuOpenButton.Size = new System.Drawing.Size(162, 22);
            this.fileContextMenuOpenButton.Text = "&Open";
            this.fileContextMenuOpenButton.Click += new System.EventHandler(this.fileContextMenuOpenButton_Click);
            // 
            // fileContextMenuOpenInExplorerButton
            // 
            this.fileContextMenuOpenInExplorerButton.Image = global::SorterExpress.Properties.Resources.folder;
            this.fileContextMenuOpenInExplorerButton.Name = "fileContextMenuOpenInExplorerButton";
            this.fileContextMenuOpenInExplorerButton.Size = new System.Drawing.Size(162, 22);
            this.fileContextMenuOpenInExplorerButton.Text = "Open in &Explorer";
            this.fileContextMenuOpenInExplorerButton.Click += new System.EventHandler(this.fileContextMenuOpenInExplorerButton_Click);
            // 
            // fileContextMenuRemoveButton
            // 
            this.fileContextMenuRemoveButton.Image = global::SorterExpress.Properties.Resources.close;
            this.fileContextMenuRemoveButton.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.fileContextMenuRemoveButton.Name = "fileContextMenuRemoveButton";
            this.fileContextMenuRemoveButton.ShortcutKeys = System.Windows.Forms.Keys.Delete;
            this.fileContextMenuRemoveButton.Size = new System.Drawing.Size(162, 22);
            this.fileContextMenuRemoveButton.Text = "Remove";
            this.fileContextMenuRemoveButton.Click += new System.EventHandler(this.fileContextMenuRemoveButton_Click);
            // 
            // ignoredFilesLabel
            // 
            this.ignoredFilesLabel.AutoSize = true;
            this.ignoredFilesLabel.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "FileCount", true));
            this.ignoredFilesLabel.Location = new System.Drawing.Point(7, 2);
            this.ignoredFilesLabel.Name = "ignoredFilesLabel";
            this.ignoredFilesLabel.Size = new System.Drawing.Size(67, 13);
            this.ignoredFilesLabel.TabIndex = 5;
            this.ignoredFilesLabel.Text = "Ignored Files";
            // 
            // tableLayoutPanel1
            // 
            this.tableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel1.ColumnCount = 2;
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel1.Controls.Add(this.saveAndExitButton, 1, 0);
            this.tableLayoutPanel1.Controls.Add(this.saveButton, 0, 0);
            this.tableLayoutPanel1.Location = new System.Drawing.Point(8, 442);
            this.tableLayoutPanel1.Margin = new System.Windows.Forms.Padding(2);
            this.tableLayoutPanel1.Name = "tableLayoutPanel1";
            this.tableLayoutPanel1.RowCount = 1;
            this.tableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.tableLayoutPanel1.Size = new System.Drawing.Size(555, 27);
            this.tableLayoutPanel1.TabIndex = 5;
            // 
            // DuplicateSearchIgnoredForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(571, 477);
            this.Controls.Add(this.tableLayoutPanel);
            this.Controls.Add(this.tableLayoutPanel1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "DuplicateSearchIgnoredForm";
            this.Padding = new System.Windows.Forms.Padding(6);
            this.Text = "Manage Duplicate Search Ignores";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.TagsListForm_FormClosing);
            this.directoryContextMenuStrip.ResumeLayout(false);
            this.tableLayoutPanel.ResumeLayout(false);
            this.topPanel.ResumeLayout(false);
            this.topPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).EndInit();
            this.bottomPanel.ResumeLayout(false);
            this.bottomPanel.PerformLayout();
            this.fileContextMenuStrip.ResumeLayout(false);
            this.tableLayoutPanel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        internal System.Windows.Forms.BindingSource bindingSource;
        private System.Windows.Forms.ContextMenuStrip directoryContextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem directoryContextMenuRemoveButton;
        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.Button saveAndExitButton;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.Panel topPanel;
        private System.Windows.Forms.ListBox directoryListBox;
        private System.Windows.Forms.Label ignoredDirectoriesLabel;
        private System.Windows.Forms.Panel bottomPanel;
        private System.Windows.Forms.Button directoryRemoveButton;
        private System.Windows.Forms.Button directoryAddButton;
        private System.Windows.Forms.Button directoryRemoveAllButton;
        private System.Windows.Forms.Button filesRemoveAllButton;
        private System.Windows.Forms.Button filesRemoveButton;
        private System.Windows.Forms.Button filesAddButton;
        private System.Windows.Forms.ListBox filesListBox;
        private System.Windows.Forms.Label ignoredFilesLabel;
        private System.Windows.Forms.ToolStripMenuItem directoryContextMenuOpenInExplorerButton;
        private System.Windows.Forms.ContextMenuStrip fileContextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem fileContextMenuOpenButton;
        private System.Windows.Forms.ToolStripMenuItem fileContextMenuOpenInExplorerButton;
        private System.Windows.Forms.ToolStripMenuItem fileContextMenuRemoveButton;
    }
}