namespace SorterExpress.Forms
{
    partial class SettingsForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(SettingsForm));
            this.fastResizingCheckbox = new System.Windows.Forms.CheckBox();
            this.tagSearchNumeric = new System.Windows.Forms.NumericUpDown();
            this.tagSearchStartLabel = new System.Windows.Forms.Label();
            this.clearTagsButton = new System.Windows.Forms.Button();
            this.importTagsButton = new System.Windows.Forms.Button();
            this.exportTagsButton = new System.Windows.Forms.Button();
            this.displayAllTagsCheckbox = new System.Windows.Forms.CheckBox();
            this.autoResetTagSearchCheckBox = new System.Windows.Forms.CheckBox();
            this.moveSortedFilesCheckbox = new System.Windows.Forms.CheckBox();
            this.saveSettingsButton = new System.Windows.Forms.Button();
            this.websiteButton = new System.Windows.Forms.Button();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.tagControlsGroupBox = new System.Windows.Forms.GroupBox();
            this.tagControlsFlowLayoutPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.tagSearchStartFlowLayoutPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.miscControlsGroupBox = new System.Windows.Forms.GroupBox();
            this.miscControlsFlowLayoutPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.viewLogsButton = new System.Windows.Forms.Button();
            this.tableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.flowLayoutPanel2 = new System.Windows.Forms.FlowLayoutPanel();
            this.thumbsStorageSizeLabel = new System.Windows.Forms.Label();
            this.thumbsStorageInfoButton = new System.Windows.Forms.Button();
            this.thumbsStorageEmptyButton = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.tagSearchNumeric)).BeginInit();
            this.tagControlsGroupBox.SuspendLayout();
            this.tagControlsFlowLayoutPanel.SuspendLayout();
            this.tagSearchStartFlowLayoutPanel.SuspendLayout();
            this.miscControlsGroupBox.SuspendLayout();
            this.miscControlsFlowLayoutPanel.SuspendLayout();
            this.tableLayoutPanel.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.flowLayoutPanel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // fastResizingCheckbox
            // 
            this.fastResizingCheckbox.AutoSize = true;
            this.fastResizingCheckbox.Location = new System.Drawing.Point(3, 26);
            this.fastResizingCheckbox.Name = "fastResizingCheckbox";
            this.fastResizingCheckbox.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.fastResizingCheckbox.Size = new System.Drawing.Size(84, 17);
            this.fastResizingCheckbox.TabIndex = 7;
            this.fastResizingCheckbox.Text = "Fast resizing";
            this.toolTip.SetToolTip(this.fastResizingCheckbox, "Make the program resize faster by not redrawing all elements until the resizing i" +
        "s finished.");
            this.fastResizingCheckbox.UseVisualStyleBackColor = true;
            // 
            // tagSearchNumeric
            // 
            this.tagSearchNumeric.Location = new System.Drawing.Point(3, 3);
            this.tagSearchNumeric.Margin = new System.Windows.Forms.Padding(3, 3, 3, 0);
            this.tagSearchNumeric.Minimum = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.tagSearchNumeric.Name = "tagSearchNumeric";
            this.tagSearchNumeric.Size = new System.Drawing.Size(46, 20);
            this.tagSearchNumeric.TabIndex = 6;
            this.tagSearchNumeric.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.tagSearchNumeric.ValueChanged += new System.EventHandler(this.TagSearchNumeric_ValueChanged);
            // 
            // tagSearchStartLabel
            // 
            this.tagSearchStartLabel.AutoSize = true;
            this.tagSearchStartLabel.Location = new System.Drawing.Point(55, 6);
            this.tagSearchStartLabel.Margin = new System.Windows.Forms.Padding(3, 6, 3, 0);
            this.tagSearchStartLabel.Name = "tagSearchStartLabel";
            this.tagSearchStartLabel.Size = new System.Drawing.Size(226, 13);
            this.tagSearchStartLabel.TabIndex = 5;
            this.tagSearchStartLabel.Text = "Begin tag searching at X amount of characters";
            this.toolTip.SetToolTip(this.tagSearchStartLabel, "Searching tags will only begin once X amount of characters have been input. Can b" +
        "e useful to increase program speed.");
            // 
            // clearTagsButton
            // 
            this.clearTagsButton.Location = new System.Drawing.Point(6, 6);
            this.clearTagsButton.Name = "clearTagsButton";
            this.clearTagsButton.Size = new System.Drawing.Size(393, 25);
            this.clearTagsButton.TabIndex = 3;
            this.clearTagsButton.Text = "Clear Tags";
            this.clearTagsButton.UseVisualStyleBackColor = true;
            this.clearTagsButton.Click += new System.EventHandler(this.ClearTagsButton_Click);
            // 
            // importTagsButton
            // 
            this.importTagsButton.Location = new System.Drawing.Point(6, 37);
            this.importTagsButton.Name = "importTagsButton";
            this.importTagsButton.Size = new System.Drawing.Size(393, 25);
            this.importTagsButton.TabIndex = 2;
            this.importTagsButton.Text = "Import Tags";
            this.importTagsButton.UseVisualStyleBackColor = true;
            this.importTagsButton.Click += new System.EventHandler(this.ImportTagsButton_Click);
            // 
            // exportTagsButton
            // 
            this.exportTagsButton.Location = new System.Drawing.Point(6, 68);
            this.exportTagsButton.Name = "exportTagsButton";
            this.exportTagsButton.Size = new System.Drawing.Size(393, 25);
            this.exportTagsButton.TabIndex = 1;
            this.exportTagsButton.Text = "Export Tags";
            this.exportTagsButton.UseVisualStyleBackColor = true;
            this.exportTagsButton.Click += new System.EventHandler(this.ExportTagsButton_Click);
            // 
            // displayAllTagsCheckbox
            // 
            this.displayAllTagsCheckbox.AutoSize = true;
            this.displayAllTagsCheckbox.Location = new System.Drawing.Point(6, 126);
            this.displayAllTagsCheckbox.Name = "displayAllTagsCheckbox";
            this.displayAllTagsCheckbox.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.displayAllTagsCheckbox.Size = new System.Drawing.Size(365, 17);
            this.displayAllTagsCheckbox.TabIndex = 0;
            this.displayAllTagsCheckbox.Text = "Display all tags when search box is empty (Can be slow with alot of tags)\r\n";
            this.displayAllTagsCheckbox.UseVisualStyleBackColor = true;
            this.displayAllTagsCheckbox.CheckedChanged += new System.EventHandler(this.DisplayAllTagsCheckbox_CheckedChanged);
            // 
            // autoResetTagSearchCheckBox
            // 
            this.autoResetTagSearchCheckBox.AutoSize = true;
            this.autoResetTagSearchCheckBox.Location = new System.Drawing.Point(6, 149);
            this.autoResetTagSearchCheckBox.Name = "autoResetTagSearchCheckBox";
            this.autoResetTagSearchCheckBox.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.autoResetTagSearchCheckBox.Size = new System.Drawing.Size(330, 17);
            this.autoResetTagSearchCheckBox.TabIndex = 0;
            this.autoResetTagSearchCheckBox.Text = "Automatically empty tag search box when toggling a tag on or off";
            this.autoResetTagSearchCheckBox.UseVisualStyleBackColor = true;
            // 
            // moveSortedFilesCheckbox
            // 
            this.moveSortedFilesCheckbox.AutoSize = true;
            this.moveSortedFilesCheckbox.Location = new System.Drawing.Point(3, 3);
            this.moveSortedFilesCheckbox.Name = "moveSortedFilesCheckbox";
            this.moveSortedFilesCheckbox.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.moveSortedFilesCheckbox.Size = new System.Drawing.Size(183, 17);
            this.moveSortedFilesCheckbox.TabIndex = 0;
            this.moveSortedFilesCheckbox.Text = "Move sorted files to \'sorted\' folder";
            this.moveSortedFilesCheckbox.UseVisualStyleBackColor = true;
            // 
            // saveSettingsButton
            // 
            this.saveSettingsButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.saveSettingsButton.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.saveSettingsButton.Location = new System.Drawing.Point(10, 373);
            this.saveSettingsButton.Name = "saveSettingsButton";
            this.saveSettingsButton.Size = new System.Drawing.Size(416, 23);
            this.saveSettingsButton.TabIndex = 1;
            this.saveSettingsButton.Text = "Save Settings";
            this.saveSettingsButton.UseVisualStyleBackColor = true;
            this.saveSettingsButton.Click += new System.EventHandler(this.saveSettingsButton_Click);
            // 
            // websiteButton
            // 
            this.websiteButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.websiteButton.Location = new System.Drawing.Point(0, 0);
            this.websiteButton.Margin = new System.Windows.Forms.Padding(0, 0, 2, 0);
            this.websiteButton.Name = "websiteButton";
            this.websiteButton.Size = new System.Drawing.Size(206, 23);
            this.websiteButton.TabIndex = 2;
            this.websiteButton.Text = "Website (GitHub)";
            this.websiteButton.UseVisualStyleBackColor = true;
            this.websiteButton.Click += new System.EventHandler(this.websiteButton_Click);
            // 
            // tagControlsGroupBox
            // 
            this.tagControlsGroupBox.Controls.Add(this.tagControlsFlowLayoutPanel);
            this.tagControlsGroupBox.Location = new System.Drawing.Point(3, 3);
            this.tagControlsGroupBox.Name = "tagControlsGroupBox";
            this.tagControlsGroupBox.Size = new System.Drawing.Size(408, 191);
            this.tagControlsGroupBox.TabIndex = 10;
            this.tagControlsGroupBox.TabStop = false;
            this.tagControlsGroupBox.Text = "Tags";
            this.toolTip.SetToolTip(this.tagControlsGroupBox, "Options related to the in built tag collection.");
            // 
            // tagControlsFlowLayoutPanel
            // 
            this.tagControlsFlowLayoutPanel.Controls.Add(this.clearTagsButton);
            this.tagControlsFlowLayoutPanel.Controls.Add(this.importTagsButton);
            this.tagControlsFlowLayoutPanel.Controls.Add(this.exportTagsButton);
            this.tagControlsFlowLayoutPanel.Controls.Add(this.tagSearchStartFlowLayoutPanel);
            this.tagControlsFlowLayoutPanel.Controls.Add(this.displayAllTagsCheckbox);
            this.tagControlsFlowLayoutPanel.Controls.Add(this.autoResetTagSearchCheckBox);
            this.tagControlsFlowLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tagControlsFlowLayoutPanel.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.tagControlsFlowLayoutPanel.Location = new System.Drawing.Point(3, 16);
            this.tagControlsFlowLayoutPanel.Name = "tagControlsFlowLayoutPanel";
            this.tagControlsFlowLayoutPanel.Padding = new System.Windows.Forms.Padding(3);
            this.tagControlsFlowLayoutPanel.Size = new System.Drawing.Size(402, 172);
            this.tagControlsFlowLayoutPanel.TabIndex = 4;
            // 
            // tagSearchStartFlowLayoutPanel
            // 
            this.tagSearchStartFlowLayoutPanel.Controls.Add(this.tagSearchNumeric);
            this.tagSearchStartFlowLayoutPanel.Controls.Add(this.tagSearchStartLabel);
            this.tagSearchStartFlowLayoutPanel.Location = new System.Drawing.Point(3, 96);
            this.tagSearchStartFlowLayoutPanel.Margin = new System.Windows.Forms.Padding(0);
            this.tagSearchStartFlowLayoutPanel.Name = "tagSearchStartFlowLayoutPanel";
            this.tagSearchStartFlowLayoutPanel.Size = new System.Drawing.Size(396, 27);
            this.tagSearchStartFlowLayoutPanel.TabIndex = 8;
            // 
            // miscControlsGroupBox
            // 
            this.miscControlsGroupBox.Controls.Add(this.miscControlsFlowLayoutPanel);
            this.miscControlsGroupBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.miscControlsGroupBox.Location = new System.Drawing.Point(3, 261);
            this.miscControlsGroupBox.Name = "miscControlsGroupBox";
            this.miscControlsGroupBox.Size = new System.Drawing.Size(408, 66);
            this.miscControlsGroupBox.TabIndex = 11;
            this.miscControlsGroupBox.TabStop = false;
            this.miscControlsGroupBox.Text = "Misc";
            this.toolTip.SetToolTip(this.miscControlsGroupBox, "Miscellaneous options.");
            // 
            // miscControlsFlowLayoutPanel
            // 
            this.miscControlsFlowLayoutPanel.Controls.Add(this.moveSortedFilesCheckbox);
            this.miscControlsFlowLayoutPanel.Controls.Add(this.fastResizingCheckbox);
            this.miscControlsFlowLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.miscControlsFlowLayoutPanel.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.miscControlsFlowLayoutPanel.Location = new System.Drawing.Point(3, 16);
            this.miscControlsFlowLayoutPanel.Name = "miscControlsFlowLayoutPanel";
            this.miscControlsFlowLayoutPanel.Size = new System.Drawing.Size(402, 47);
            this.miscControlsFlowLayoutPanel.TabIndex = 8;
            // 
            // viewLogsButton
            // 
            this.viewLogsButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.viewLogsButton.Location = new System.Drawing.Point(210, 0);
            this.viewLogsButton.Margin = new System.Windows.Forms.Padding(2, 0, 0, 0);
            this.viewLogsButton.Name = "viewLogsButton";
            this.viewLogsButton.Size = new System.Drawing.Size(206, 23);
            this.viewLogsButton.TabIndex = 3;
            this.viewLogsButton.Text = "View Logs";
            this.viewLogsButton.UseVisualStyleBackColor = true;
            this.viewLogsButton.Click += new System.EventHandler(this.ViewLogsButton_Click);
            // 
            // tableLayoutPanel
            // 
            this.tableLayoutPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tableLayoutPanel.ColumnCount = 2;
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel.Controls.Add(this.viewLogsButton, 1, 0);
            this.tableLayoutPanel.Controls.Add(this.websiteButton, 0, 0);
            this.tableLayoutPanel.Location = new System.Drawing.Point(10, 347);
            this.tableLayoutPanel.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel.Name = "tableLayoutPanel";
            this.tableLayoutPanel.RowCount = 1;
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel.Size = new System.Drawing.Size(416, 23);
            this.tableLayoutPanel.TabIndex = 4;
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.flowLayoutPanel1.Controls.Add(this.tagControlsGroupBox);
            this.flowLayoutPanel1.Controls.Add(this.groupBox1);
            this.flowLayoutPanel1.Controls.Add(this.miscControlsGroupBox);
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(10, 11);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(416, 332);
            this.flowLayoutPanel1.TabIndex = 5;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.flowLayoutPanel2);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.groupBox1.Location = new System.Drawing.Point(3, 200);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(408, 55);
            this.groupBox1.TabIndex = 12;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Cache";
            // 
            // flowLayoutPanel2
            // 
            this.flowLayoutPanel2.Controls.Add(this.thumbsStorageSizeLabel);
            this.flowLayoutPanel2.Controls.Add(this.thumbsStorageInfoButton);
            this.flowLayoutPanel2.Controls.Add(this.thumbsStorageEmptyButton);
            this.flowLayoutPanel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel2.Location = new System.Drawing.Point(3, 16);
            this.flowLayoutPanel2.Name = "flowLayoutPanel2";
            this.flowLayoutPanel2.Padding = new System.Windows.Forms.Padding(3);
            this.flowLayoutPanel2.Size = new System.Drawing.Size(402, 36);
            this.flowLayoutPanel2.TabIndex = 0;
            // 
            // thumbsStorageSizeLabel
            // 
            this.thumbsStorageSizeLabel.AutoSize = true;
            this.thumbsStorageSizeLabel.Location = new System.Drawing.Point(6, 11);
            this.thumbsStorageSizeLabel.Margin = new System.Windows.Forms.Padding(3, 8, 3, 0);
            this.thumbsStorageSizeLabel.Name = "thumbsStorageSizeLabel";
            this.thumbsStorageSizeLabel.Size = new System.Drawing.Size(141, 13);
            this.thumbsStorageSizeLabel.TabIndex = 0;
            this.thumbsStorageSizeLabel.Text = "Thumbs Storage Size: 0 Mb ";
            // 
            // thumbsStorageInfoButton
            // 
            this.thumbsStorageInfoButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.thumbsStorageInfoButton.Location = new System.Drawing.Point(153, 6);
            this.thumbsStorageInfoButton.Name = "thumbsStorageInfoButton";
            this.thumbsStorageInfoButton.Size = new System.Drawing.Size(90, 23);
            this.thumbsStorageInfoButton.TabIndex = 1;
            this.thumbsStorageInfoButton.Text = "What\'s This?";
            this.thumbsStorageInfoButton.UseVisualStyleBackColor = true;
            this.thumbsStorageInfoButton.Click += new System.EventHandler(this.thumbsStorageInfoButton_Click);
            // 
            // thumbsStorageEmptyButton
            // 
            this.thumbsStorageEmptyButton.Location = new System.Drawing.Point(249, 6);
            this.thumbsStorageEmptyButton.Name = "thumbsStorageEmptyButton";
            this.thumbsStorageEmptyButton.Size = new System.Drawing.Size(60, 23);
            this.thumbsStorageEmptyButton.TabIndex = 2;
            this.thumbsStorageEmptyButton.Text = "Empty";
            this.thumbsStorageEmptyButton.UseVisualStyleBackColor = true;
            this.thumbsStorageEmptyButton.Click += new System.EventHandler(this.thumbsStorageEmptyButton_Click);
            // 
            // SettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(434, 404);
            this.Controls.Add(this.flowLayoutPanel1);
            this.Controls.Add(this.tableLayoutPanel);
            this.Controls.Add(this.saveSettingsButton);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximumSize = new System.Drawing.Size(450, 1080);
            this.MinimumSize = new System.Drawing.Size(449, 39);
            this.Name = "SettingsForm";
            this.Text = "Sorter Express - Settings";
            this.Shown += new System.EventHandler(this.SettingsForm_Shown);
            ((System.ComponentModel.ISupportInitialize)(this.tagSearchNumeric)).EndInit();
            this.tagControlsGroupBox.ResumeLayout(false);
            this.tagControlsFlowLayoutPanel.ResumeLayout(false);
            this.tagControlsFlowLayoutPanel.PerformLayout();
            this.tagSearchStartFlowLayoutPanel.ResumeLayout(false);
            this.tagSearchStartFlowLayoutPanel.PerformLayout();
            this.miscControlsGroupBox.ResumeLayout(false);
            this.miscControlsFlowLayoutPanel.ResumeLayout(false);
            this.miscControlsFlowLayoutPanel.PerformLayout();
            this.tableLayoutPanel.ResumeLayout(false);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.flowLayoutPanel2.ResumeLayout(false);
            this.flowLayoutPanel2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.CheckBox moveSortedFilesCheckbox;
        private System.Windows.Forms.Button saveSettingsButton;
        private System.Windows.Forms.Button websiteButton;
        private System.Windows.Forms.Button importTagsButton;
        private System.Windows.Forms.Button exportTagsButton;
        private System.Windows.Forms.Button clearTagsButton;
        private System.Windows.Forms.Label tagSearchStartLabel;
        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.NumericUpDown tagSearchNumeric;
        private System.Windows.Forms.Button viewLogsButton;
        private System.Windows.Forms.CheckBox autoResetTagSearchCheckBox;
        private System.Windows.Forms.CheckBox displayAllTagsCheckbox;
        private System.Windows.Forms.CheckBox fastResizingCheckbox;
        private System.Windows.Forms.TableLayoutPanel tableLayoutPanel;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.GroupBox tagControlsGroupBox;
        private System.Windows.Forms.FlowLayoutPanel tagControlsFlowLayoutPanel;
        private System.Windows.Forms.FlowLayoutPanel tagSearchStartFlowLayoutPanel;
        private System.Windows.Forms.GroupBox miscControlsGroupBox;
        private System.Windows.Forms.FlowLayoutPanel miscControlsFlowLayoutPanel;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel2;
        private System.Windows.Forms.Label thumbsStorageSizeLabel;
        private System.Windows.Forms.Button thumbsStorageInfoButton;
        private System.Windows.Forms.Button thumbsStorageEmptyButton;
    }
}