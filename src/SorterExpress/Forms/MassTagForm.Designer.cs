using System.Windows;
using Vlc.DotNet.Core;

namespace SorterExpress.Forms
{
    partial class MassTagForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MassTagForm));
            this.label1 = new System.Windows.Forms.Label();
            this.addTagButton = new System.Windows.Forms.Button();
            this.openDirectoryButton = new System.Windows.Forms.Button();
            this.tagCreationTextbox = new System.Windows.Forms.TextBox();
            this.tooltip = new System.Windows.Forms.ToolTip(this.components);
            this.tagSearchTextbox = new System.Windows.Forms.TextBox();
            this.applyMassTagButton = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.actionComboBox = new System.Windows.Forms.ComboBox();
            this.tagSearchLabel = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.listBoxesLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.filenamesAfter = new SorterExpress.Controls.ScrollingListBox();
            this.filenamesBefore = new SorterExpress.Controls.ScrollingListBox();
            this.filenamesBeforeLabel = new System.Windows.Forms.Label();
            this.filenamesAfterLabel = new System.Windows.Forms.Label();
            this.labelsTableLayoutPanel2 = new System.Windows.Forms.TableLayoutPanel();
            this.filenamesBeforeContextMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.renameToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.removeDoNotTagThisFileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.tagsPanel = new SorterExpress.Controls.ScrollPanel();
            this.listBoxesLayoutPanel.SuspendLayout();
            this.labelsTableLayoutPanel2.SuspendLayout();
            this.filenamesBeforeContextMenu.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(7, 69);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(48, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Add Tag";
            // 
            // addTagButton
            // 
            this.addTagButton.Location = new System.Drawing.Point(241, 65);
            this.addTagButton.Name = "addTagButton";
            this.addTagButton.Size = new System.Drawing.Size(22, 22);
            this.addTagButton.TabIndex = 0;
            this.addTagButton.TabStop = false;
            this.addTagButton.Text = "+";
            this.addTagButton.UseVisualStyleBackColor = true;
            this.addTagButton.Click += new System.EventHandler(this.addTagButton_Click);
            // 
            // openDirectoryButton
            // 
            this.openDirectoryButton.Location = new System.Drawing.Point(8, 7);
            this.openDirectoryButton.Name = "openDirectoryButton";
            this.openDirectoryButton.Size = new System.Drawing.Size(255, 22);
            this.openDirectoryButton.TabIndex = 0;
            this.openDirectoryButton.Text = "Open Directory";
            this.openDirectoryButton.UseVisualStyleBackColor = true;
            this.openDirectoryButton.Click += new System.EventHandler(this.openDirectoryButton_Click);
            // 
            // tagCreationTextbox
            // 
            this.tagCreationTextbox.Location = new System.Drawing.Point(60, 66);
            this.tagCreationTextbox.Name = "tagCreationTextbox";
            this.tagCreationTextbox.Size = new System.Drawing.Size(178, 20);
            this.tagCreationTextbox.TabIndex = 10;
            this.tooltip.SetToolTip(this.tagCreationTextbox, "You can add a tag to the tags database here.\r\nThis will *not* automatically enabl" +
        "e the tag.\r\nYou can press ENTER instead of pressing the + button if desired.");
            this.tagCreationTextbox.TextChanged += new System.EventHandler(this.TagCreationTextbox_TextChanged);
            // 
            // tagSearchTextbox
            // 
            this.tagSearchTextbox.Location = new System.Drawing.Point(60, 90);
            this.tagSearchTextbox.Name = "tagSearchTextbox";
            this.tagSearchTextbox.Size = new System.Drawing.Size(202, 20);
            this.tagSearchTextbox.TabIndex = 11;
            this.tooltip.SetToolTip(this.tagSearchTextbox, resources.GetString("tagSearchTextbox.ToolTip"));
            this.tagSearchTextbox.TextChanged += new System.EventHandler(this.TagSearchTextbox_TextChanged);
            // 
            // applyMassTagButton
            // 
            this.applyMassTagButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.applyMassTagButton.Enabled = false;
            this.applyMassTagButton.Location = new System.Drawing.Point(272, 290);
            this.applyMassTagButton.Name = "applyMassTagButton";
            this.applyMassTagButton.Size = new System.Drawing.Size(456, 22);
            this.applyMassTagButton.TabIndex = 46;
            this.applyMassTagButton.Text = "Apply Mass Tagging To Files";
            this.tooltip.SetToolTip(this.applyMassTagButton, "Apply the selected tags to all files in the opened directory (rename them). To us" +
        "e this button you must have alteast one tag selected.");
            this.applyMassTagButton.UseVisualStyleBackColor = true;
            this.applyMassTagButton.Click += new System.EventHandler(this.applyMassTagButton_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(8, 45);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(37, 13);
            this.label3.TabIndex = 51;
            this.label3.Text = "Action";
            this.tooltip.SetToolTip(this.label3, resources.GetString("label3.ToolTip"));
            // 
            // actionComboBox
            // 
            this.actionComboBox.FormattingEnabled = true;
            this.actionComboBox.Items.AddRange(new object[] {
            "Set Tags",
            "Add Tags",
            "Remove Tags"});
            this.actionComboBox.Location = new System.Drawing.Point(60, 40);
            this.actionComboBox.Name = "actionComboBox";
            this.actionComboBox.Size = new System.Drawing.Size(202, 21);
            this.actionComboBox.TabIndex = 52;
            this.tooltip.SetToolTip(this.actionComboBox, resources.GetString("actionComboBox.ToolTip"));
            this.actionComboBox.SelectedIndexChanged += new System.EventHandler(this.actionComboBox_SelectedIndexChanged);
            // 
            // tagSearchLabel
            // 
            this.tagSearchLabel.AutoSize = true;
            this.tagSearchLabel.Location = new System.Drawing.Point(7, 94);
            this.tagSearchLabel.Name = "tagSearchLabel";
            this.tagSearchLabel.Size = new System.Drawing.Size(41, 13);
            this.tagSearchLabel.TabIndex = 36;
            this.tagSearchLabel.Text = "Search";
            // 
            // label2
            // 
            this.label2.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.label2.Location = new System.Drawing.Point(10, 34);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(251, 1);
            this.label2.TabIndex = 44;
            // 
            // listBoxesLayoutPanel
            // 
            this.listBoxesLayoutPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.listBoxesLayoutPanel.ColumnCount = 2;
            this.listBoxesLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.listBoxesLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.listBoxesLayoutPanel.Controls.Add(this.filenamesAfter, 1, 0);
            this.listBoxesLayoutPanel.Controls.Add(this.filenamesBefore, 0, 0);
            this.listBoxesLayoutPanel.Location = new System.Drawing.Point(269, 34);
            this.listBoxesLayoutPanel.Name = "listBoxesLayoutPanel";
            this.listBoxesLayoutPanel.RowCount = 1;
            this.listBoxesLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.listBoxesLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 253F));
            this.listBoxesLayoutPanel.Size = new System.Drawing.Size(459, 253);
            this.listBoxesLayoutPanel.TabIndex = 45;
            // 
            // filenamesAfter
            // 
            this.filenamesAfter.Dock = System.Windows.Forms.DockStyle.Fill;
            this.filenamesAfter.FormattingEnabled = true;
            this.filenamesAfter.IntegralHeight = false;
            this.filenamesAfter.Location = new System.Drawing.Point(232, 3);
            this.filenamesAfter.Name = "filenamesAfter";
            this.filenamesAfter.Size = new System.Drawing.Size(224, 247);
            this.filenamesAfter.TabIndex = 1;
            this.filenamesAfter.Scrolled += new System.Windows.Forms.ScrollEventHandler(this.listBox_Scrolled);
            this.filenamesAfter.SelectedIndexChanged += new System.EventHandler(this.listBox_SelectedIndexChanged);
            // 
            // filenamesBefore
            // 
            this.filenamesBefore.Dock = System.Windows.Forms.DockStyle.Fill;
            this.filenamesBefore.FormattingEnabled = true;
            this.filenamesBefore.IntegralHeight = false;
            this.filenamesBefore.Location = new System.Drawing.Point(3, 3);
            this.filenamesBefore.Name = "filenamesBefore";
            this.filenamesBefore.Size = new System.Drawing.Size(223, 247);
            this.filenamesBefore.TabIndex = 0;
            this.filenamesBefore.Scrolled += new System.Windows.Forms.ScrollEventHandler(this.listBox_Scrolled);
            this.filenamesBefore.SelectedIndexChanged += new System.EventHandler(this.listBox_SelectedIndexChanged);
            this.filenamesBefore.KeyUp += new System.Windows.Forms.KeyEventHandler(this.filenamesBefore_KeyUp);
            this.filenamesBefore.MouseDown += new System.Windows.Forms.MouseEventHandler(this.filenamesBefore_MouseDown);
            // 
            // filenamesBeforeLabel
            // 
            this.filenamesBeforeLabel.AutoSize = true;
            this.filenamesBeforeLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.filenamesBeforeLabel.Location = new System.Drawing.Point(3, 3);
            this.filenamesBeforeLabel.Margin = new System.Windows.Forms.Padding(3);
            this.filenamesBeforeLabel.Name = "filenamesBeforeLabel";
            this.filenamesBeforeLabel.Size = new System.Drawing.Size(223, 18);
            this.filenamesBeforeLabel.TabIndex = 47;
            this.filenamesBeforeLabel.Text = "Filenames in directory now";
            // 
            // filenamesAfterLabel
            // 
            this.filenamesAfterLabel.AutoSize = true;
            this.filenamesAfterLabel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.filenamesAfterLabel.Location = new System.Drawing.Point(232, 3);
            this.filenamesAfterLabel.Margin = new System.Windows.Forms.Padding(3);
            this.filenamesAfterLabel.Name = "filenamesAfterLabel";
            this.filenamesAfterLabel.Size = new System.Drawing.Size(224, 18);
            this.filenamesAfterLabel.TabIndex = 48;
            this.filenamesAfterLabel.Text = "Filenames in directory after mass tagging";
            // 
            // labelsTableLayoutPanel2
            // 
            this.labelsTableLayoutPanel2.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.labelsTableLayoutPanel2.ColumnCount = 2;
            this.labelsTableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.labelsTableLayoutPanel2.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.labelsTableLayoutPanel2.Controls.Add(this.filenamesAfterLabel, 1, 0);
            this.labelsTableLayoutPanel2.Controls.Add(this.filenamesBeforeLabel, 0, 0);
            this.labelsTableLayoutPanel2.Location = new System.Drawing.Point(269, 7);
            this.labelsTableLayoutPanel2.Name = "labelsTableLayoutPanel2";
            this.labelsTableLayoutPanel2.RowCount = 1;
            this.labelsTableLayoutPanel2.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.labelsTableLayoutPanel2.Size = new System.Drawing.Size(459, 24);
            this.labelsTableLayoutPanel2.TabIndex = 49;
            // 
            // filenamesBeforeContextMenu
            // 
            this.filenamesBeforeContextMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.renameToolStripMenuItem,
            this.removeDoNotTagThisFileToolStripMenuItem});
            this.filenamesBeforeContextMenu.Name = "filenamesBeforeContextMenu";
            this.filenamesBeforeContextMenu.Size = new System.Drawing.Size(280, 48);
            // 
            // renameToolStripMenuItem
            // 
            this.renameToolStripMenuItem.Name = "renameToolStripMenuItem";
            this.renameToolStripMenuItem.Size = new System.Drawing.Size(279, 22);
            this.renameToolStripMenuItem.Text = "Rename (F2)";
            this.renameToolStripMenuItem.Click += new System.EventHandler(this.renameToolStripMenuItem_Click);
            // 
            // removeDoNotTagThisFileToolStripMenuItem
            // 
            this.removeDoNotTagThisFileToolStripMenuItem.Name = "removeDoNotTagThisFileToolStripMenuItem";
            this.removeDoNotTagThisFileToolStripMenuItem.Size = new System.Drawing.Size(279, 22);
            this.removeDoNotTagThisFileToolStripMenuItem.Text = "Remove (Do not tag this file) (CTRL+D)";
            this.removeDoNotTagThisFileToolStripMenuItem.Click += new System.EventHandler(this.removeDoNotTagThisFileToolStripMenuItem_Click);
            // 
            // tagsPanel
            // 
            this.tagsPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.tagsPanel.AutoScroll = true;
            this.tagsPanel.Location = new System.Drawing.Point(8, 116);
            this.tagsPanel.Name = "tagsPanel";
            this.tagsPanel.Size = new System.Drawing.Size(255, 196);
            this.tagsPanel.TabIndex = 12;
            // 
            // MassTagForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(740, 321);
            this.Controls.Add(this.actionComboBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.labelsTableLayoutPanel2);
            this.Controls.Add(this.applyMassTagButton);
            this.Controls.Add(this.listBoxesLayoutPanel);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.tagSearchLabel);
            this.Controls.Add(this.tagSearchTextbox);
            this.Controls.Add(this.tagCreationTextbox);
            this.Controls.Add(this.openDirectoryButton);
            this.Controls.Add(this.addTagButton);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tagsPanel);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MinimumSize = new System.Drawing.Size(756, 360);
            this.Name = "MassTagForm";
            this.Text = "Sorter Express - Sort";
            this.listBoxesLayoutPanel.ResumeLayout(false);
            this.labelsTableLayoutPanel2.ResumeLayout(false);
            this.labelsTableLayoutPanel2.PerformLayout();
            this.filenamesBeforeContextMenu.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button addTagButton;
        private System.Windows.Forms.Button openDirectoryButton;
        private System.Windows.Forms.TextBox tagCreationTextbox;
        private System.Windows.Forms.ToolTip tooltip;
        private System.Windows.Forms.TextBox tagSearchTextbox;
        private System.Windows.Forms.Label tagSearchLabel;
        private System.Windows.Forms.Label label2;
        public SorterExpress.Controls.ScrollPanel tagsPanel;
        private System.Windows.Forms.TableLayoutPanel listBoxesLayoutPanel;
        private SorterExpress.Controls.ScrollingListBox filenamesAfter;
        private SorterExpress.Controls.ScrollingListBox filenamesBefore;
        private System.Windows.Forms.Button applyMassTagButton;
        private System.Windows.Forms.Label filenamesBeforeLabel;
        private System.Windows.Forms.Label filenamesAfterLabel;
        private System.Windows.Forms.TableLayoutPanel labelsTableLayoutPanel2;
        private System.Windows.Forms.ContextMenuStrip filenamesBeforeContextMenu;
        private System.Windows.Forms.ToolStripMenuItem removeDoNotTagThisFileToolStripMenuItem;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox actionComboBox;
        private System.Windows.Forms.ToolStripMenuItem renameToolStripMenuItem;
    }
}

