
namespace SorterExpress.Forms
{
    partial class TagsListForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TagsListForm));
            this.tagsListBox = new System.Windows.Forms.ListBox();
            this.contextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.tagCountLabel = new System.Windows.Forms.Label();
            this.renameButton = new System.Windows.Forms.Button();
            this.deleteButton = new System.Windows.Forms.Button();
            this.addTagLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.addButton = new System.Windows.Forms.Button();
            this.addTagTextBox = new System.Windows.Forms.TextBox();
            this.clearTagsButton = new System.Windows.Forms.Button();
            this.importButton = new System.Windows.Forms.Button();
            this.exportButton = new System.Windows.Forms.Button();
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.saveAndExitButton = new System.Windows.Forms.Button();
            this.saveButton = new System.Windows.Forms.Button();
            this.seperatorLabel = new System.Windows.Forms.Label();
            this.renameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.deleteToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.contextMenuStrip.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.addTagLayoutPanel.SuspendLayout();
            this.flowLayoutPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // tagsListBox
            // 
            this.tagsListBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tagsListBox.ContextMenuStrip = this.contextMenuStrip;
            this.tagsListBox.DataBindings.Add(new System.Windows.Forms.Binding("DataSource", this.bindingSource, "Tags", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.tagsListBox.FormattingEnabled = true;
            this.tagsListBox.IntegralHeight = false;
            this.tagsListBox.Location = new System.Drawing.Point(9, 6);
            this.tagsListBox.Name = "tagsListBox";
            this.tagsListBox.Size = new System.Drawing.Size(211, 342);
            this.tagsListBox.TabIndex = 0;
            this.tagsListBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.tagsListBox_MouseDown);
            // 
            // contextMenuStrip
            // 
            this.contextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.renameToolStripMenuItem,
            this.deleteToolStripMenuItem});
            this.contextMenuStrip.Name = "contextMenuStrip";
            this.contextMenuStrip.Size = new System.Drawing.Size(137, 48);
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.flowLayoutPanel1.Controls.Add(this.tagCountLabel);
            this.flowLayoutPanel1.Controls.Add(this.seperatorLabel);
            this.flowLayoutPanel1.Controls.Add(this.renameButton);
            this.flowLayoutPanel1.Controls.Add(this.deleteButton);
            this.flowLayoutPanel1.Controls.Add(this.addTagLayoutPanel);
            this.flowLayoutPanel1.Controls.Add(this.clearTagsButton);
            this.flowLayoutPanel1.Controls.Add(this.importButton);
            this.flowLayoutPanel1.Controls.Add(this.exportButton);
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(222, 6);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(171, 277);
            this.flowLayoutPanel1.TabIndex = 1;
            // 
            // tagCountLabel
            // 
            this.tagCountLabel.AutoSize = true;
            this.tagCountLabel.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.bindingSource, "TagCount", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.tagCountLabel.Location = new System.Drawing.Point(3, 0);
            this.tagCountLabel.Name = "tagCountLabel";
            this.tagCountLabel.Size = new System.Drawing.Size(40, 13);
            this.tagCountLabel.TabIndex = 7;
            this.tagCountLabel.Text = "0 Tags";
            // 
            // renameButton
            // 
            this.renameButton.Location = new System.Drawing.Point(3, 27);
            this.renameButton.Name = "renameButton";
            this.renameButton.Size = new System.Drawing.Size(166, 23);
            this.renameButton.TabIndex = 0;
            this.renameButton.Text = "Rename";
            this.toolTip.SetToolTip(this.renameButton, "Rename the currently selected tag. Note: this will not rename files that already " +
        "have this tag. For that you should use the \"Rename Tag in Collection\" form from " +
        "the welcome screen.");
            this.renameButton.UseVisualStyleBackColor = true;
            this.renameButton.Click += new System.EventHandler(this.renameButton_Click);
            // 
            // deleteButton
            // 
            this.deleteButton.Location = new System.Drawing.Point(3, 56);
            this.deleteButton.Name = "deleteButton";
            this.deleteButton.Size = new System.Drawing.Size(166, 23);
            this.deleteButton.TabIndex = 1;
            this.deleteButton.Text = "Delete";
            this.toolTip.SetToolTip(this.deleteButton, "Delete the currently selected tag.");
            this.deleteButton.UseVisualStyleBackColor = true;
            this.deleteButton.Click += new System.EventHandler(this.deleteButton_Click);
            // 
            // addTagLayoutPanel
            // 
            this.addTagLayoutPanel.ColumnCount = 2;
            this.addTagLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 26.43052F));
            this.addTagLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 73.56948F));
            this.addTagLayoutPanel.Controls.Add(this.addButton, 0, 0);
            this.addTagLayoutPanel.Controls.Add(this.addTagTextBox, 1, 0);
            this.addTagLayoutPanel.Location = new System.Drawing.Point(3, 85);
            this.addTagLayoutPanel.Name = "addTagLayoutPanel";
            this.addTagLayoutPanel.RowCount = 1;
            this.addTagLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.addTagLayoutPanel.Size = new System.Drawing.Size(166, 23);
            this.addTagLayoutPanel.TabIndex = 3;
            // 
            // addButton
            // 
            this.addButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.addButton.Location = new System.Drawing.Point(0, 0);
            this.addButton.Margin = new System.Windows.Forms.Padding(0);
            this.addButton.Name = "addButton";
            this.addButton.Size = new System.Drawing.Size(43, 23);
            this.addButton.TabIndex = 2;
            this.addButton.Text = "Add";
            this.toolTip.SetToolTip(this.addButton, "Add a new tag from the textbox.");
            this.addButton.UseVisualStyleBackColor = true;
            this.addButton.Click += new System.EventHandler(this.addButton_Click);
            // 
            // addTagTextBox
            // 
            this.addTagTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right)));
            this.addTagTextBox.Location = new System.Drawing.Point(43, 1);
            this.addTagTextBox.Margin = new System.Windows.Forms.Padding(0);
            this.addTagTextBox.Name = "addTagTextBox";
            this.addTagTextBox.Size = new System.Drawing.Size(123, 20);
            this.addTagTextBox.TabIndex = 3;
            this.addTagTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.addTagTextBox_KeyPress);
            // 
            // clearTagsButton
            // 
            this.clearTagsButton.Location = new System.Drawing.Point(3, 114);
            this.clearTagsButton.Name = "clearTagsButton";
            this.clearTagsButton.Size = new System.Drawing.Size(166, 23);
            this.clearTagsButton.TabIndex = 6;
            this.clearTagsButton.Text = "Clear All Tags";
            this.toolTip.SetToolTip(this.clearTagsButton, "Completely clear the current tag library.");
            this.clearTagsButton.UseVisualStyleBackColor = true;
            this.clearTagsButton.Click += new System.EventHandler(this.clearTagsButton_Click);
            // 
            // importButton
            // 
            this.importButton.Location = new System.Drawing.Point(3, 143);
            this.importButton.Name = "importButton";
            this.importButton.Size = new System.Drawing.Size(166, 23);
            this.importButton.TabIndex = 4;
            this.importButton.Text = "Import Tags File";
            this.toolTip.SetToolTip(this.importButton, "Import a tags file into your library alongside your current tags. Duplicate tags " +
        "will not be added.");
            this.importButton.UseVisualStyleBackColor = true;
            this.importButton.Click += new System.EventHandler(this.importButton_Click);
            // 
            // exportButton
            // 
            this.exportButton.Location = new System.Drawing.Point(3, 172);
            this.exportButton.Name = "exportButton";
            this.exportButton.Size = new System.Drawing.Size(166, 23);
            this.exportButton.TabIndex = 5;
            this.exportButton.Text = "Export Tags File";
            this.toolTip.SetToolTip(this.exportButton, "Export all current tags into a tags file, allowing for saving or sharing of your " +
        "library.");
            this.exportButton.UseVisualStyleBackColor = true;
            this.exportButton.Click += new System.EventHandler(this.exportButton_Click);
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.flowLayoutPanel2.Controls.Add(this.saveAndExitButton);
            this.flowLayoutPanel2.Controls.Add(this.saveButton);
            this.flowLayoutPanel2.FlowDirection = System.Windows.Forms.FlowDirection.BottomUp;
            this.flowLayoutPanel2.Location = new System.Drawing.Point(222, 289);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Size = new System.Drawing.Size(171, 60);
            this.flowLayoutPanel2.TabIndex = 3;
            // 
            // saveAndExitButton
            // 
            this.saveAndExitButton.Location = new System.Drawing.Point(3, 34);
            this.saveAndExitButton.Name = "saveAndExitButton";
            this.saveAndExitButton.Size = new System.Drawing.Size(166, 23);
            this.saveAndExitButton.TabIndex = 0;
            this.saveAndExitButton.Text = "Save and Exit";
            this.saveAndExitButton.UseVisualStyleBackColor = true;
            this.saveAndExitButton.Click += new System.EventHandler(this.saveAndExitButton_Click);
            // 
            // saveButton
            // 
            this.saveButton.Location = new System.Drawing.Point(3, 5);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(166, 23);
            this.saveButton.TabIndex = 1;
            this.saveButton.Text = "Save";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.saveButton_Click);
            // 
            // seperatorLabel
            // 
            this.seperatorLabel.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.seperatorLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.seperatorLabel.Location = new System.Drawing.Point(10, 18);
            this.seperatorLabel.Margin = new System.Windows.Forms.Padding(10, 5, 10, 5);
            this.seperatorLabel.Name = "seperatorLabel";
            this.seperatorLabel.Size = new System.Drawing.Size(152, 1);
            this.seperatorLabel.TabIndex = 45;
            // 
            // renameToolStripMenuItem
            // 
            this.renameToolStripMenuItem.Image = global::SorterExpress.Properties.Resources.rename;
            this.renameToolStripMenuItem.Name = "renameToolStripMenuItem";
            this.renameToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.F2;
            this.renameToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.renameToolStripMenuItem.Text = "Rename";
            this.renameToolStripMenuItem.Click += new System.EventHandler(this.renameToolStripMenuItem_Click);
            // 
            // deleteToolStripMenuItem
            // 
            this.deleteToolStripMenuItem.Image = global::SorterExpress.Properties.Resources.close;
            this.deleteToolStripMenuItem.ImageScaling = System.Windows.Forms.ToolStripItemImageScaling.None;
            this.deleteToolStripMenuItem.Name = "deleteToolStripMenuItem";
            this.deleteToolStripMenuItem.ShortcutKeys = System.Windows.Forms.Keys.Delete;
            this.deleteToolStripMenuItem.Size = new System.Drawing.Size(136, 22);
            this.deleteToolStripMenuItem.Text = "Delete";
            this.deleteToolStripMenuItem.Click += new System.EventHandler(this.deleteToolStripMenuItem_Click);
            // 
            // bindingSource
            // 
            this.bindingSource.DataSource = typeof(SorterExpress.Forms.TagsListModel);
            // 
            // TagsListForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(399, 354);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.tagsListBox);
            this.Controls.Add(this.flowLayoutPanel2);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "TagsListForm";
            this.Padding = new System.Windows.Forms.Padding(6);
            this.Text = "Manage Tag Library";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.TagsListForm_FormClosing);
            this.contextMenuStrip.ResumeLayout(false);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.addTagLayoutPanel.ResumeLayout(false);
            this.addTagLayoutPanel.PerformLayout();
            this.flowLayoutPanel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.bindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListBox tagsListBox;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.Button renameButton;
        private System.Windows.Forms.Button deleteButton;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
        private System.Windows.Forms.Button saveAndExitButton;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.TableLayoutPanel addTagLayoutPanel;
        private System.Windows.Forms.Button addButton;
        private System.Windows.Forms.TextBox addTagTextBox;
        private System.Windows.Forms.Button importButton;
        private System.Windows.Forms.Button exportButton;
        private System.Windows.Forms.Button clearTagsButton;
        internal System.Windows.Forms.BindingSource bindingSource;
        private System.Windows.Forms.Label tagCountLabel;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem renameToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem deleteToolStripMenuItem;
        private System.Windows.Forms.Label seperatorLabel;
        private System.Windows.Forms.ToolTip toolTip;
    }
}