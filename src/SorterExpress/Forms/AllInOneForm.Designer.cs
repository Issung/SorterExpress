namespace SorterExpress.Forms
{
    partial class AllInOneForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AllInOneForm));
            this.tabControl = new System.Windows.Forms.TabControl();
            this.sort = new System.Windows.Forms.TabPage();
            this.view = new System.Windows.Forms.TabPage();
            this.duplicates = new System.Windows.Forms.TabPage();
            this.renameTag = new System.Windows.Forms.TabPage();
            this.settings = new System.Windows.Forms.TabPage();
            this.massTag = new System.Windows.Forms.TabPage();
            this.tabControl.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl
            // 
            this.tabControl.Controls.Add(this.sort);
            this.tabControl.Controls.Add(this.massTag);
            this.tabControl.Controls.Add(this.view);
            this.tabControl.Controls.Add(this.duplicates);
            this.tabControl.Controls.Add(this.renameTag);
            this.tabControl.Controls.Add(this.settings);
            this.tabControl.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl.Location = new System.Drawing.Point(0, 0);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.Size = new System.Drawing.Size(800, 450);
            this.tabControl.TabIndex = 0;
            // 
            // sort
            // 
            this.sort.Location = new System.Drawing.Point(4, 22);
            this.sort.Name = "sort";
            this.sort.Padding = new System.Windows.Forms.Padding(3);
            this.sort.Size = new System.Drawing.Size(792, 424);
            this.sort.TabIndex = 0;
            this.sort.Text = "Sort";
            this.sort.UseVisualStyleBackColor = true;
            // 
            // view
            // 
            this.view.Location = new System.Drawing.Point(4, 22);
            this.view.Name = "view";
            this.view.Padding = new System.Windows.Forms.Padding(3);
            this.view.Size = new System.Drawing.Size(792, 424);
            this.view.TabIndex = 1;
            this.view.Text = "View";
            this.view.UseVisualStyleBackColor = true;
            // 
            // duplicates
            // 
            this.duplicates.Location = new System.Drawing.Point(4, 22);
            this.duplicates.Name = "duplicates";
            this.duplicates.Size = new System.Drawing.Size(792, 424);
            this.duplicates.TabIndex = 2;
            this.duplicates.Text = "Find Duplicates";
            this.duplicates.UseVisualStyleBackColor = true;
            // 
            // renameTag
            // 
            this.renameTag.Location = new System.Drawing.Point(4, 22);
            this.renameTag.Name = "renameTag";
            this.renameTag.Size = new System.Drawing.Size(792, 424);
            this.renameTag.TabIndex = 3;
            this.renameTag.Text = "Rename Tag";
            this.renameTag.UseVisualStyleBackColor = true;
            // 
            // settings
            // 
            this.settings.Location = new System.Drawing.Point(4, 22);
            this.settings.Name = "settings";
            this.settings.Size = new System.Drawing.Size(792, 424);
            this.settings.TabIndex = 4;
            this.settings.Text = "Settings";
            this.settings.UseVisualStyleBackColor = true;
            // 
            // massTag
            // 
            this.massTag.Location = new System.Drawing.Point(4, 22);
            this.massTag.Name = "massTag";
            this.massTag.Padding = new System.Windows.Forms.Padding(3);
            this.massTag.Size = new System.Drawing.Size(792, 424);
            this.massTag.TabIndex = 5;
            this.massTag.Text = "Mass Tag";
            this.massTag.UseVisualStyleBackColor = true;
            // 
            // AllInOneForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.tabControl);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "AllInOneForm";
            this.Text = "Sorter Express - All In One";
            this.tabControl.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage sort;
        private System.Windows.Forms.TabPage view;
        private System.Windows.Forms.TabPage duplicates;
        private System.Windows.Forms.TabPage renameTag;
        private System.Windows.Forms.TabPage settings;
        private System.Windows.Forms.TabPage massTag;
    }
}