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
            components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(WelcomeForm));
            label1 = new System.Windows.Forms.Label();
            toolTip = new System.Windows.Forms.ToolTip(components);
            massTagButton = new System.Windows.Forms.Button();
            allInOneButton = new System.Windows.Forms.Button();
            duplicatesButton = new System.Windows.Forms.Button();
            viewFormButton = new System.Windows.Forms.Button();
            exitButton = new System.Windows.Forms.Button();
            renameTagButton = new System.Windows.Forms.Button();
            settingsButton = new System.Windows.Forms.Button();
            sortButton = new System.Windows.Forms.Button();
            nsfwSortButton = new System.Windows.Forms.Button();
            updatesGroupBox = new System.Windows.Forms.GroupBox();
            updateView1 = new Controls.UpdateView();
            operationsGroupBox = new System.Windows.Forms.GroupBox();
            updatesGroupBox.SuspendLayout();
            operationsGroupBox.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            label1.Location = new System.Drawing.Point(14, 21);
            label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new System.Drawing.Size(410, 15);
            label1.TabIndex = 8;
            label1.Text = "Hover over an option to read about it's function.";
            label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // massTagButton
            // 
            massTagButton.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            massTagButton.Location = new System.Drawing.Point(7, 57);
            massTagButton.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            massTagButton.Name = "massTagButton";
            massTagButton.Size = new System.Drawing.Size(396, 27);
            massTagButton.TabIndex = 15;
            massTagButton.Text = "Mass Tag Collection";
            toolTip.SetToolTip(massTagButton, "Modify tags en masse to mutiple files in your collection at once. This option allows you to open a directory and add specific tags to selected files in that directory.");
            massTagButton.UseVisualStyleBackColor = true;
            massTagButton.Click += massTagButton_Click;
            // 
            // allInOneButton
            // 
            allInOneButton.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            allInOneButton.Location = new System.Drawing.Point(7, 222);
            allInOneButton.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            allInOneButton.Name = "allInOneButton";
            allInOneButton.Size = new System.Drawing.Size(396, 27);
            allInOneButton.TabIndex = 14;
            allInOneButton.Text = "All In One [WIP, Slow]";
            toolTip.SetToolTip(allInOneButton, "A form that has all features of the application displayed in seperate tabs.");
            allInOneButton.UseVisualStyleBackColor = true;
            allInOneButton.Click += AllInOneButton_Click;
            // 
            // duplicatesButton
            // 
            duplicatesButton.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            duplicatesButton.Location = new System.Drawing.Point(7, 156);
            duplicatesButton.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            duplicatesButton.Name = "duplicatesButton";
            duplicatesButton.Size = new System.Drawing.Size(396, 27);
            duplicatesButton.TabIndex = 11;
            duplicatesButton.Text = "Find Duplicates in Collection";
            toolTip.SetToolTip(duplicatesButton, "Search your collection for duplicates. Features recursive directory searching, support for image & videos, cropping, similarity threshold, multithreading and more.");
            duplicatesButton.UseVisualStyleBackColor = true;
            duplicatesButton.Click += DuplicatesButton_Click;
            // 
            // viewFormButton
            // 
            viewFormButton.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            viewFormButton.Location = new System.Drawing.Point(7, 89);
            viewFormButton.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            viewFormButton.Name = "viewFormButton";
            viewFormButton.Size = new System.Drawing.Size(396, 27);
            viewFormButton.TabIndex = 9;
            viewFormButton.Text = "View Collection";
            toolTip.SetToolTip(viewFormButton, "View your collection by specifying a search criteria of tags featuring AND, OR & NOT filters. You may then scroll through results.");
            viewFormButton.UseVisualStyleBackColor = true;
            viewFormButton.Click += viewFormButton_Click;
            // 
            // exitButton
            // 
            exitButton.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            exitButton.Location = new System.Drawing.Point(6, 310);
            exitButton.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            exitButton.Name = "exitButton";
            exitButton.Size = new System.Drawing.Size(396, 27);
            exitButton.TabIndex = 13;
            exitButton.Text = "Exit";
            toolTip.SetToolTip(exitButton, "Exit SorterExpress, bye!");
            exitButton.UseVisualStyleBackColor = true;
            exitButton.Click += exitButton_Click;
            // 
            // renameTagButton
            // 
            renameTagButton.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            renameTagButton.Location = new System.Drawing.Point(7, 123);
            renameTagButton.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            renameTagButton.Name = "renameTagButton";
            renameTagButton.Size = new System.Drawing.Size(396, 27);
            renameTagButton.TabIndex = 10;
            renameTagButton.Text = "Rename Tag in Collection";
            toolTip.SetToolTip(renameTagButton, resources.GetString("renameTagButton.ToolTip"));
            renameTagButton.UseVisualStyleBackColor = true;
            renameTagButton.Click += renameTagButton_Click;
            // 
            // settingsButton
            // 
            settingsButton.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            settingsButton.Location = new System.Drawing.Point(6, 277);
            settingsButton.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            settingsButton.Name = "settingsButton";
            settingsButton.Size = new System.Drawing.Size(396, 27);
            settingsButton.TabIndex = 12;
            settingsButton.Text = "Settings";
            toolTip.SetToolTip(settingsButton, "Change settings for the application.");
            settingsButton.UseVisualStyleBackColor = true;
            settingsButton.Click += settingsButton_Click;
            // 
            // sortButton
            // 
            sortButton.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            sortButton.Location = new System.Drawing.Point(7, 22);
            sortButton.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            sortButton.Name = "sortButton";
            sortButton.Size = new System.Drawing.Size(396, 27);
            sortButton.TabIndex = 8;
            sortButton.Text = "Sort Collection";
            toolTip.SetToolTip(sortButton, "Organise your collection by adding tags and notes to filenames or just moving them to other folders, or both at the same time for more organisation!");
            sortButton.UseVisualStyleBackColor = true;
            sortButton.Click += sortButton_Click;
            // 
            // nsfwSortButton
            // 
            nsfwSortButton.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            nsfwSortButton.Location = new System.Drawing.Point(7, 189);
            nsfwSortButton.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            nsfwSortButton.Name = "nsfwSortButton";
            nsfwSortButton.Size = new System.Drawing.Size(396, 27);
            nsfwSortButton.TabIndex = 16;
            nsfwSortButton.Text = "NSFW Sort Collection";
            toolTip.SetToolTip(nsfwSortButton, "Use machine learning to classify images/files into neutral or pornographic categories, then move each classification to separate directories.");
            nsfwSortButton.UseVisualStyleBackColor = true;
            nsfwSortButton.Click += nsfwSortButton_Click;
            // 
            // updatesGroupBox
            // 
            updatesGroupBox.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            updatesGroupBox.Controls.Add(updateView1);
            updatesGroupBox.Location = new System.Drawing.Point(14, 406);
            updatesGroupBox.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            updatesGroupBox.Name = "updatesGroupBox";
            updatesGroupBox.Padding = new System.Windows.Forms.Padding(7);
            updatesGroupBox.Size = new System.Drawing.Size(410, 96);
            updatesGroupBox.TabIndex = 10;
            updatesGroupBox.TabStop = false;
            updatesGroupBox.Text = "Updates";
            // 
            // updateView1
            // 
            updateView1.Dock = System.Windows.Forms.DockStyle.Fill;
            updateView1.Location = new System.Drawing.Point(7, 23);
            updateView1.Margin = new System.Windows.Forms.Padding(5, 3, 5, 3);
            updateView1.Name = "updateView1";
            updateView1.Size = new System.Drawing.Size(396, 66);
            updateView1.TabIndex = 0;
            updateView1.UpdateStarted += updateView_UpdateStarted;
            // 
            // operationsGroupBox
            // 
            operationsGroupBox.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            operationsGroupBox.Controls.Add(nsfwSortButton);
            operationsGroupBox.Controls.Add(massTagButton);
            operationsGroupBox.Controls.Add(allInOneButton);
            operationsGroupBox.Controls.Add(duplicatesButton);
            operationsGroupBox.Controls.Add(viewFormButton);
            operationsGroupBox.Controls.Add(exitButton);
            operationsGroupBox.Controls.Add(renameTagButton);
            operationsGroupBox.Controls.Add(settingsButton);
            operationsGroupBox.Controls.Add(sortButton);
            operationsGroupBox.Location = new System.Drawing.Point(14, 52);
            operationsGroupBox.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            operationsGroupBox.Name = "operationsGroupBox";
            operationsGroupBox.Padding = new System.Windows.Forms.Padding(4, 3, 4, 3);
            operationsGroupBox.Size = new System.Drawing.Size(410, 348);
            operationsGroupBox.TabIndex = 11;
            operationsGroupBox.TabStop = false;
            operationsGroupBox.Text = "Operations";
            // 
            // WelcomeForm
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(438, 513);
            Controls.Add(operationsGroupBox);
            Controls.Add(updatesGroupBox);
            Controls.Add(label1);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            Icon = (System.Drawing.Icon)resources.GetObject("$this.Icon");
            Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            Name = "WelcomeForm";
            Text = "Sorter Express - Welcome";
            TransparencyKey = System.Drawing.Color.White;
            updatesGroupBox.ResumeLayout(false);
            operationsGroupBox.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ToolTip toolTip;
        private System.Windows.Forms.GroupBox updatesGroupBox;
        private System.Windows.Forms.GroupBox operationsGroupBox;
        private System.Windows.Forms.Button massTagButton;
        private System.Windows.Forms.Button allInOneButton;
        private System.Windows.Forms.Button duplicatesButton;
        private System.Windows.Forms.Button viewFormButton;
        private System.Windows.Forms.Button exitButton;
        private System.Windows.Forms.Button renameTagButton;
        private System.Windows.Forms.Button settingsButton;
        private System.Windows.Forms.Button sortButton;
        private Controls.UpdateView updateView1;
        private System.Windows.Forms.Button nsfwSortButton;
    }
}