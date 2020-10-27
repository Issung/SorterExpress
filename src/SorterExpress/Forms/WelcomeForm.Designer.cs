namespace SorterExpress.Forms
{
    partial class WelcomeForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WelcomeForm));
            this.sortButton = new System.Windows.Forms.Button();
            this.settingsButton = new System.Windows.Forms.Button();
            this.exitButton = new System.Windows.Forms.Button();
            this.viewFormButton = new System.Windows.Forms.Button();
            this.renameTagButton = new System.Windows.Forms.Button();
            this.duplicatesButton = new System.Windows.Forms.Button();
            this.allInOneButton = new System.Windows.Forms.Button();
            this.massTagButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.sortContextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.startOldSortFormToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.startNewMVCSortFormToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.sortContextMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // sortButton
            // 
            this.sortButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.sortButton.ContextMenuStrip = this.sortContextMenuStrip;
            this.sortButton.Location = new System.Drawing.Point(12, 53);
            this.sortButton.Name = "sortButton";
            this.sortButton.Size = new System.Drawing.Size(301, 23);
            this.sortButton.TabIndex = 0;
            this.sortButton.Text = "Sort Collection";
            this.toolTip.SetToolTip(this.sortButton, "Organise your collection by adding tags and notes to filenames or just moving the" +
        "m to other folders, or both at the same time for more organisation!");
            this.sortButton.UseVisualStyleBackColor = true;
            this.sortButton.Click += new System.EventHandler(this.sortButton_Click);
            // 
            // settingsButton
            // 
            this.settingsButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.settingsButton.Location = new System.Drawing.Point(11, 238);
            this.settingsButton.Name = "settingsButton";
            this.settingsButton.Size = new System.Drawing.Size(301, 23);
            this.settingsButton.TabIndex = 4;
            this.settingsButton.Text = "Settings";
            this.toolTip.SetToolTip(this.settingsButton, "Change settings for the application.");
            this.settingsButton.UseVisualStyleBackColor = true;
            this.settingsButton.Click += new System.EventHandler(this.settingsButton_Click);
            // 
            // exitButton
            // 
            this.exitButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.exitButton.Location = new System.Drawing.Point(11, 267);
            this.exitButton.Name = "exitButton";
            this.exitButton.Size = new System.Drawing.Size(301, 23);
            this.exitButton.TabIndex = 5;
            this.exitButton.Text = "Exit";
            this.toolTip.SetToolTip(this.exitButton, "Exit SorterExpress, bye!");
            this.exitButton.UseVisualStyleBackColor = true;
            this.exitButton.Click += new System.EventHandler(this.exitButton_Click);
            // 
            // viewFormButton
            // 
            this.viewFormButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.viewFormButton.Location = new System.Drawing.Point(12, 111);
            this.viewFormButton.Name = "viewFormButton";
            this.viewFormButton.Size = new System.Drawing.Size(301, 23);
            this.viewFormButton.TabIndex = 1;
            this.viewFormButton.Text = "View Collection";
            this.toolTip.SetToolTip(this.viewFormButton, "View your collection by specifying a search criteria of tags featuring AND, OR & " +
        "NOT filters. You may then scroll through results.");
            this.viewFormButton.UseVisualStyleBackColor = true;
            this.viewFormButton.Click += new System.EventHandler(this.viewFormButton_Click);
            // 
            // renameTagButton
            // 
            this.renameTagButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.renameTagButton.Location = new System.Drawing.Point(12, 140);
            this.renameTagButton.Name = "renameTagButton";
            this.renameTagButton.Size = new System.Drawing.Size(301, 23);
            this.renameTagButton.TabIndex = 2;
            this.renameTagButton.Text = "Rename Tag in Collection";
            this.toolTip.SetToolTip(this.renameTagButton, resources.GetString("renameTagButton.ToolTip"));
            this.renameTagButton.UseVisualStyleBackColor = true;
            this.renameTagButton.Click += new System.EventHandler(this.renameTagButton_Click);
            // 
            // duplicatesButton
            // 
            this.duplicatesButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.duplicatesButton.Location = new System.Drawing.Point(12, 169);
            this.duplicatesButton.Name = "duplicatesButton";
            this.duplicatesButton.Size = new System.Drawing.Size(301, 23);
            this.duplicatesButton.TabIndex = 3;
            this.duplicatesButton.Text = "Find Duplicates in Collection";
            this.toolTip.SetToolTip(this.duplicatesButton, "Search your collection for duplicates. Features recursive directory searching, su" +
        "pport for image & videos, and multithreading.");
            this.duplicatesButton.UseVisualStyleBackColor = true;
            this.duplicatesButton.Click += new System.EventHandler(this.DuplicatesButton_Click);
            // 
            // allInOneButton
            // 
            this.allInOneButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.allInOneButton.Location = new System.Drawing.Point(12, 198);
            this.allInOneButton.Name = "allInOneButton";
            this.allInOneButton.Size = new System.Drawing.Size(301, 23);
            this.allInOneButton.TabIndex = 6;
            this.allInOneButton.Text = "All In One [WIP, Slow]";
            this.toolTip.SetToolTip(this.allInOneButton, "Opens a tabbed form that features all options (sort, mass tag, view, rename tag, " +
        "find duplicates, settings).");
            this.allInOneButton.UseVisualStyleBackColor = true;
            this.allInOneButton.Click += new System.EventHandler(this.AllInOneButton_Click);
            // 
            // massTagButton
            // 
            this.massTagButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.massTagButton.Location = new System.Drawing.Point(12, 82);
            this.massTagButton.Name = "massTagButton";
            this.massTagButton.Size = new System.Drawing.Size(301, 23);
            this.massTagButton.TabIndex = 7;
            this.massTagButton.Text = "Mass Tag Collection";
            this.toolTip.SetToolTip(this.massTagButton, "Add tags en masse to your collection. This option allows you to open a directory " +
        "and add specific tags to selected files in that directory.");
            this.massTagButton.UseVisualStyleBackColor = true;
            this.massTagButton.Click += new System.EventHandler(this.massTagButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(46, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(232, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "Hover over an option to read about it\'s function.";
            // 
            // sortContextMenuStrip
            // 
            this.sortContextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.startOldSortFormToolStripMenuItem,
            this.startNewMVCSortFormToolStripMenuItem});
            this.sortContextMenuStrip.Name = "sortContextMenuStrip";
            this.sortContextMenuStrip.Size = new System.Drawing.Size(205, 70);
            // 
            // startOldSortFormToolStripMenuItem
            // 
            this.startOldSortFormToolStripMenuItem.Name = "startOldSortFormToolStripMenuItem";
            this.startOldSortFormToolStripMenuItem.Size = new System.Drawing.Size(204, 22);
            this.startOldSortFormToolStripMenuItem.Text = "Start old SortForm";
            this.startOldSortFormToolStripMenuItem.Click += new System.EventHandler(this.startOldSortFormToolStripMenuItem_Click);
            // 
            // startNewMVCSortFormToolStripMenuItem
            // 
            this.startNewMVCSortFormToolStripMenuItem.Name = "startNewMVCSortFormToolStripMenuItem";
            this.startNewMVCSortFormToolStripMenuItem.Size = new System.Drawing.Size(204, 22);
            this.startNewMVCSortFormToolStripMenuItem.Text = "Start new MVC SortForm";
            this.startNewMVCSortFormToolStripMenuItem.Click += new System.EventHandler(this.startNewMVCSortFormToolStripMenuItem_Click);
            // 
            // WelcomeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(324, 301);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.massTagButton);
            this.Controls.Add(this.allInOneButton);
            this.Controls.Add(this.duplicatesButton);
            this.Controls.Add(this.viewFormButton);
            this.Controls.Add(this.exitButton);
            this.Controls.Add(this.renameTagButton);
            this.Controls.Add(this.settingsButton);
            this.Controls.Add(this.sortButton);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "WelcomeForm";
            this.Text = "Sorter Express - Welcome";
            this.TransparencyKey = System.Drawing.Color.White;
            this.sortContextMenuStrip.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button sortButton;
        private System.Windows.Forms.Button settingsButton;
        private System.Windows.Forms.Button exitButton;
        private System.Windows.Forms.Button viewFormButton;
        private System.Windows.Forms.Button renameTagButton;
        private System.Windows.Forms.Button duplicatesButton;
        private System.Windows.Forms.Button allInOneButton;
        private System.Windows.Forms.Button massTagButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.ContextMenuStrip sortContextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem startOldSortFormToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem startNewMVCSortFormToolStripMenuItem;
    }
}