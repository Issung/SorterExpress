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
            this.settingsPanel = new System.Windows.Forms.Panel();
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
            this.viewLogsButton = new System.Windows.Forms.Button();
            this.tableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.settingsPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tagSearchNumeric)).BeginInit();
            this.tableLayoutPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // settingsPanel
            // 
            this.settingsPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.settingsPanel.AutoScroll = true;
            this.settingsPanel.Controls.Add(this.fastResizingCheckbox);
            this.settingsPanel.Controls.Add(this.tagSearchNumeric);
            this.settingsPanel.Controls.Add(this.tagSearchStartLabel);
            this.settingsPanel.Controls.Add(this.clearTagsButton);
            this.settingsPanel.Controls.Add(this.importTagsButton);
            this.settingsPanel.Controls.Add(this.exportTagsButton);
            this.settingsPanel.Controls.Add(this.displayAllTagsCheckbox);
            this.settingsPanel.Controls.Add(this.autoResetTagSearchCheckBox);
            this.settingsPanel.Controls.Add(this.moveSortedFilesCheckbox);
            this.settingsPanel.Location = new System.Drawing.Point(10, 8);
            this.settingsPanel.Name = "settingsPanel";
            this.settingsPanel.Size = new System.Drawing.Size(415, 323);
            this.settingsPanel.TabIndex = 0;
            // 
            // fastResizingCheckbox
            // 
            this.fastResizingCheckbox.AutoSize = true;
            this.fastResizingCheckbox.Location = new System.Drawing.Point(5, 185);
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
            this.tagSearchNumeric.Location = new System.Drawing.Point(5, 96);
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
            this.tagSearchStartLabel.Location = new System.Drawing.Point(51, 99);
            this.tagSearchStartLabel.Name = "tagSearchStartLabel";
            this.tagSearchStartLabel.Size = new System.Drawing.Size(226, 13);
            this.tagSearchStartLabel.TabIndex = 5;
            this.tagSearchStartLabel.Text = "Begin tag searching at X amount of characters";
            this.toolTip.SetToolTip(this.tagSearchStartLabel, "Searching tags will only begin once X amount of characters have been input. Can b" +
        "e useful to increase program speed.");
            // 
            // clearTagsButton
            // 
            this.clearTagsButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.clearTagsButton.Location = new System.Drawing.Point(4, 5);
            this.clearTagsButton.Name = "clearTagsButton";
            this.clearTagsButton.Size = new System.Drawing.Size(405, 25);
            this.clearTagsButton.TabIndex = 3;
            this.clearTagsButton.Text = "Clear Tags";
            this.clearTagsButton.UseVisualStyleBackColor = true;
            this.clearTagsButton.Click += new System.EventHandler(this.ClearTagsButton_Click);
            // 
            // importTagsButton
            // 
            this.importTagsButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.importTagsButton.Location = new System.Drawing.Point(4, 65);
            this.importTagsButton.Name = "importTagsButton";
            this.importTagsButton.Size = new System.Drawing.Size(405, 25);
            this.importTagsButton.TabIndex = 2;
            this.importTagsButton.Text = "Import Tags";
            this.importTagsButton.UseVisualStyleBackColor = true;
            this.importTagsButton.Click += new System.EventHandler(this.ImportTagsButton_Click);
            // 
            // exportTagsButton
            // 
            this.exportTagsButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.exportTagsButton.Location = new System.Drawing.Point(4, 35);
            this.exportTagsButton.Name = "exportTagsButton";
            this.exportTagsButton.Size = new System.Drawing.Size(405, 25);
            this.exportTagsButton.TabIndex = 1;
            this.exportTagsButton.Text = "Export Tags";
            this.exportTagsButton.UseVisualStyleBackColor = true;
            this.exportTagsButton.Click += new System.EventHandler(this.ExportTagsButton_Click);
            // 
            // displayAllTagsCheckbox
            // 
            this.displayAllTagsCheckbox.AutoSize = true;
            this.displayAllTagsCheckbox.Location = new System.Drawing.Point(5, 142);
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
            this.autoResetTagSearchCheckBox.Location = new System.Drawing.Point(5, 122);
            this.autoResetTagSearchCheckBox.Name = "autoResetTagSearchCheckBox";
            this.autoResetTagSearchCheckBox.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.autoResetTagSearchCheckBox.Size = new System.Drawing.Size(407, 17);
            this.autoResetTagSearchCheckBox.TabIndex = 0;
            this.autoResetTagSearchCheckBox.Text = "Automatically reset the search box to empty when toggling a tag or pressing enter" +
    "";
            this.autoResetTagSearchCheckBox.UseVisualStyleBackColor = true;
            // 
            // moveSortedFilesCheckbox
            // 
            this.moveSortedFilesCheckbox.AutoSize = true;
            this.moveSortedFilesCheckbox.Location = new System.Drawing.Point(5, 162);
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
            this.saveSettingsButton.Location = new System.Drawing.Point(10, 364);
            this.saveSettingsButton.Name = "saveSettingsButton";
            this.saveSettingsButton.Size = new System.Drawing.Size(415, 23);
            this.saveSettingsButton.TabIndex = 1;
            this.saveSettingsButton.Text = "Save Settings";
            this.saveSettingsButton.UseVisualStyleBackColor = true;
            this.saveSettingsButton.Click += new System.EventHandler(this.saveSettingsButton_Click);
            // 
            // websiteButton
            // 
            this.websiteButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.websiteButton.Enabled = false;
            this.websiteButton.Location = new System.Drawing.Point(0, 0);
            this.websiteButton.Margin = new System.Windows.Forms.Padding(0, 0, 2, 0);
            this.websiteButton.Name = "websiteButton";
            this.websiteButton.Size = new System.Drawing.Size(205, 23);
            this.websiteButton.TabIndex = 2;
            this.websiteButton.Text = "Website";
            this.websiteButton.UseVisualStyleBackColor = true;
            this.websiteButton.Click += new System.EventHandler(this.websiteButton_Click);
            // 
            // viewLogsButton
            // 
            this.viewLogsButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.viewLogsButton.Location = new System.Drawing.Point(209, 0);
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
            this.tableLayoutPanel.Location = new System.Drawing.Point(10, 337);
            this.tableLayoutPanel.Margin = new System.Windows.Forms.Padding(0);
            this.tableLayoutPanel.Name = "tableLayoutPanel";
            this.tableLayoutPanel.RowCount = 1;
            this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.tableLayoutPanel.Size = new System.Drawing.Size(415, 23);
            this.tableLayoutPanel.TabIndex = 4;
            // 
            // SettingsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(433, 395);
            this.Controls.Add(this.saveSettingsButton);
            this.Controls.Add(this.settingsPanel);
            this.Controls.Add(this.tableLayoutPanel);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(449, 434);
            this.Name = "SettingsForm";
            this.Text = "Sorter Express - Settings";
            this.settingsPanel.ResumeLayout(false);
            this.settingsPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.tagSearchNumeric)).EndInit();
            this.tableLayoutPanel.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel settingsPanel;
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
    }
}