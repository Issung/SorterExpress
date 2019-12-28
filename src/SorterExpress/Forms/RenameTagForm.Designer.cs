namespace SorterExpress.Forms
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
            this.splitContainer = new System.Windows.Forms.SplitContainer();
            this.mediaViewer = new SorterExpress.Controls.MediaViewer();
            this.tableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.tableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
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
            this.splitContainer.Panel2.Controls.Add(this.mediaViewer);
            this.splitContainer.Size = new System.Drawing.Size(690, 227);
            this.splitContainer.SplitterDistance = 108;
            this.splitContainer.TabIndex = 47;
            this.splitContainer.MouseDown += new System.Windows.Forms.MouseEventHandler(this.splitCont_MouseDown);
            this.splitContainer.MouseMove += new System.Windows.Forms.MouseEventHandler(this.splitCont_MouseMove);
            this.splitContainer.MouseUp += new System.Windows.Forms.MouseEventHandler(this.splitCont_MouseUp);
            // 
            // mediaViewer
            // 
            this.mediaViewer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mediaViewer.Location = new System.Drawing.Point(0, 0);
            this.mediaViewer.Name = "mediaViewer";
            this.mediaViewer.Size = new System.Drawing.Size(574, 223);
            this.mediaViewer.TabIndex = 0;
            this.mediaViewer.VideoPosition = -1F;
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
        private System.Windows.Forms.SplitContainer splitContainer;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel1;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel2;
        private Controls.MediaViewer mediaViewer;
    }
}