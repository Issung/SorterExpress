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
            this.label1 = new System.Windows.Forms.Label();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            this.massTagButton = new System.Windows.Forms.Button();
            this.allInOneButton = new System.Windows.Forms.Button();
            this.duplicatesButton = new System.Windows.Forms.Button();
            this.viewFormButton = new System.Windows.Forms.Button();
            this.exitButton = new System.Windows.Forms.Button();
            this.renameTagButton = new System.Windows.Forms.Button();
            this.settingsButton = new System.Windows.Forms.Button();
            this.sortButton = new System.Windows.Forms.Button();
            this.updatesGroupBox = new System.Windows.Forms.GroupBox();
            this.updateView1 = new SorterExpress.Controls.UpdateView();
            this.optionsGroupBox = new System.Windows.Forms.GroupBox();
            this.updatesGroupBox.SuspendLayout();
            this.optionsGroupBox.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.label1.Location = new System.Drawing.Point(12, 18);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(351, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "Hover over an option to read about it\'s function.";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // massTagButton
            // 
            this.massTagButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.massTagButton.Location = new System.Drawing.Point(6, 49);
            this.massTagButton.Name = "massTagButton";
            this.massTagButton.Size = new System.Drawing.Size(339, 23);
            this.massTagButton.TabIndex = 15;
            this.massTagButton.Text = "Mass Tag Collection";
            this.toolTip.SetToolTip(this.massTagButton, "Modify tags en masse to mutiple files in your collection at once. This option all" +
        "ows you to open a directory and add specific tags to selected files in that dire" +
        "ctory.");
            this.massTagButton.UseVisualStyleBackColor = true;
            this.massTagButton.Click += new System.EventHandler(this.massTagButton_Click);
            // 
            // allInOneButton
            // 
            this.allInOneButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.allInOneButton.Location = new System.Drawing.Point(6, 164);
            this.allInOneButton.Name = "allInOneButton";
            this.allInOneButton.Size = new System.Drawing.Size(339, 23);
            this.allInOneButton.TabIndex = 14;
            this.allInOneButton.Text = "All In One [WIP, Slow]";
            this.toolTip.SetToolTip(this.allInOneButton, "A form that has all features of the application displayed in seperate tabs.");
            this.allInOneButton.UseVisualStyleBackColor = true;
            this.allInOneButton.Click += new System.EventHandler(this.AllInOneButton_Click);
            // 
            // duplicatesButton
            // 
            this.duplicatesButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.duplicatesButton.Location = new System.Drawing.Point(6, 135);
            this.duplicatesButton.Name = "duplicatesButton";
            this.duplicatesButton.Size = new System.Drawing.Size(339, 23);
            this.duplicatesButton.TabIndex = 11;
            this.duplicatesButton.Text = "Find Duplicates in Collection";
            this.toolTip.SetToolTip(this.duplicatesButton, "Search your collection for duplicates. Features recursive directory searching, su" +
        "pport for image & videos, cropping, similarity threshold, multithreading and mor" +
        "e.");
            this.duplicatesButton.UseVisualStyleBackColor = true;
            this.duplicatesButton.Click += new System.EventHandler(this.DuplicatesButton_Click);
            // 
            // viewFormButton
            // 
            this.viewFormButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.viewFormButton.Location = new System.Drawing.Point(6, 77);
            this.viewFormButton.Name = "viewFormButton";
            this.viewFormButton.Size = new System.Drawing.Size(339, 23);
            this.viewFormButton.TabIndex = 9;
            this.viewFormButton.Text = "View Collection";
            this.toolTip.SetToolTip(this.viewFormButton, "View your collection by specifying a search criteria of tags featuring AND, OR & " +
        "NOT filters. You may then scroll through results.");
            this.viewFormButton.UseVisualStyleBackColor = true;
            this.viewFormButton.Click += new System.EventHandler(this.viewFormButton_Click);
            // 
            // exitButton
            // 
            this.exitButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.exitButton.Location = new System.Drawing.Point(5, 239);
            this.exitButton.Name = "exitButton";
            this.exitButton.Size = new System.Drawing.Size(339, 23);
            this.exitButton.TabIndex = 13;
            this.exitButton.Text = "Exit";
            this.toolTip.SetToolTip(this.exitButton, "Exit SorterExpress, bye!");
            this.exitButton.UseVisualStyleBackColor = true;
            this.exitButton.Click += new System.EventHandler(this.exitButton_Click);
            // 
            // renameTagButton
            // 
            this.renameTagButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.renameTagButton.Location = new System.Drawing.Point(6, 107);
            this.renameTagButton.Name = "renameTagButton";
            this.renameTagButton.Size = new System.Drawing.Size(339, 23);
            this.renameTagButton.TabIndex = 10;
            this.renameTagButton.Text = "Rename Tag in Collection";
            this.toolTip.SetToolTip(this.renameTagButton, resources.GetString("renameTagButton.ToolTip"));
            this.renameTagButton.UseVisualStyleBackColor = true;
            this.renameTagButton.Click += new System.EventHandler(this.renameTagButton_Click);
            // 
            // settingsButton
            // 
            this.settingsButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.settingsButton.Location = new System.Drawing.Point(5, 211);
            this.settingsButton.Name = "settingsButton";
            this.settingsButton.Size = new System.Drawing.Size(339, 23);
            this.settingsButton.TabIndex = 12;
            this.settingsButton.Text = "Settings";
            this.toolTip.SetToolTip(this.settingsButton, "Change settings for the application.");
            this.settingsButton.UseVisualStyleBackColor = true;
            this.settingsButton.Click += new System.EventHandler(this.settingsButton_Click);
            // 
            // sortButton
            // 
            this.sortButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.sortButton.Location = new System.Drawing.Point(6, 19);
            this.sortButton.Name = "sortButton";
            this.sortButton.Size = new System.Drawing.Size(339, 23);
            this.sortButton.TabIndex = 8;
            this.sortButton.Text = "Sort Collection";
            this.toolTip.SetToolTip(this.sortButton, "Organise your collection by adding tags and notes to filenames or just moving the" +
        "m to other folders, or both at the same time for more organisation!");
            this.sortButton.UseVisualStyleBackColor = true;
            this.sortButton.Click += new System.EventHandler(this.sortButton_Click);
            // 
            // updatesGroupBox
            // 
            this.updatesGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.updatesGroupBox.Controls.Add(this.updateView1);
            this.updatesGroupBox.Location = new System.Drawing.Point(12, 322);
            this.updatesGroupBox.Name = "updatesGroupBox";
            this.updatesGroupBox.Padding = new System.Windows.Forms.Padding(6);
            this.updatesGroupBox.Size = new System.Drawing.Size(351, 83);
            this.updatesGroupBox.TabIndex = 10;
            this.updatesGroupBox.TabStop = false;
            this.updatesGroupBox.Text = "Updates";
            // 
            // updateView1
            // 
            this.updateView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.updateView1.Location = new System.Drawing.Point(6, 19);
            this.updateView1.Name = "updateView1";
            this.updateView1.Size = new System.Drawing.Size(339, 58);
            this.updateView1.TabIndex = 0;
            this.updateView1.UpdateStarted += new SorterExpress.Controls.UpdateView.UpdateStartedEvent(this.updateView_UpdateStarted);
            // 
            // optionsGroupBox
            // 
            this.optionsGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.optionsGroupBox.Controls.Add(this.massTagButton);
            this.optionsGroupBox.Controls.Add(this.allInOneButton);
            this.optionsGroupBox.Controls.Add(this.duplicatesButton);
            this.optionsGroupBox.Controls.Add(this.viewFormButton);
            this.optionsGroupBox.Controls.Add(this.exitButton);
            this.optionsGroupBox.Controls.Add(this.renameTagButton);
            this.optionsGroupBox.Controls.Add(this.settingsButton);
            this.optionsGroupBox.Controls.Add(this.sortButton);
            this.optionsGroupBox.Location = new System.Drawing.Point(12, 45);
            this.optionsGroupBox.Name = "optionsGroupBox";
            this.optionsGroupBox.Size = new System.Drawing.Size(351, 272);
            this.optionsGroupBox.TabIndex = 11;
            this.optionsGroupBox.TabStop = false;
            this.optionsGroupBox.Text = "Options";
            // 
            // WelcomeForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(375, 415);
            this.Controls.Add(this.optionsGroupBox);
            this.Controls.Add(this.updatesGroupBox);
            this.Controls.Add(this.label1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "WelcomeForm";
            this.Text = "Sorter Express - Welcome";
            this.TransparencyKey = System.Drawing.Color.White;
            this.updatesGroupBox.ResumeLayout(false);
            this.optionsGroupBox.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.GroupBox updatesGroupBox;
        private System.Windows.Forms.GroupBox optionsGroupBox;
        private System.Windows.Forms.Button massTagButton;
        private System.Windows.Forms.Button allInOneButton;
        private System.Windows.Forms.Button duplicatesButton;
        private System.Windows.Forms.Button viewFormButton;
        private System.Windows.Forms.Button exitButton;
        private System.Windows.Forms.Button renameTagButton;
        private System.Windows.Forms.Button settingsButton;
        private System.Windows.Forms.Button sortButton;
        private Controls.UpdateView updateView1;
    }
}