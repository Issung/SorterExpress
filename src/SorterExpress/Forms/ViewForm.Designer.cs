using System;
using System.Windows;
using Vlc.DotNet.Core;

namespace SorterExpress.Forms
{
    partial class ViewForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ViewForm));
            this.openDirectoryButton = new System.Windows.Forms.Button();
            this.openFileButton = new System.Windows.Forms.Button();
            this.openFileInExplorerButton = new System.Windows.Forms.Button();
            this.tooltip = new System.Windows.Forms.ToolTip(this.components);
            this.searchButton = new System.Windows.Forms.Button();
            this.orPage = new System.Windows.Forms.TabPage();
            this.notPage = new System.Windows.Forms.TabPage();
            this.tagSearchTextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.settingsButton = new System.Windows.Forms.Button();
            this.filesPanel = new System.Windows.Forms.Panel();
            this.tabControl = new System.Windows.Forms.TabControl();
            this.andPage = new System.Windows.Forms.TabPage();
            this.resultsCountLabel = new System.Windows.Forms.Label();
            this.openFilesTableLayoutPanel1 = new System.Windows.Forms.TableLayoutPanel();
            this.mediaViewer = new SorterExpress.Controls.MediaViewer();
            this.tabControl.SuspendLayout();
            this.openFilesTableLayoutPanel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // openDirectoryButton
            // 
            this.openDirectoryButton.Location = new System.Drawing.Point(88, 12);
            this.openDirectoryButton.Name = "openDirectoryButton";
            this.openDirectoryButton.Size = new System.Drawing.Size(134, 22);
            this.openDirectoryButton.TabIndex = 6;
            this.openDirectoryButton.Text = "View Directory";
            this.openDirectoryButton.UseVisualStyleBackColor = true;
            this.openDirectoryButton.Click += new System.EventHandler(this.OpenDirectoryButton_Click);
            // 
            // openFileButton
            // 
            this.openFileButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.openFileButton.Location = new System.Drawing.Point(0, 0);
            this.openFileButton.Margin = new System.Windows.Forms.Padding(0, 0, 2, 0);
            this.openFileButton.Name = "openFileButton";
            this.openFileButton.Size = new System.Drawing.Size(125, 23);
            this.openFileButton.TabIndex = 10;
            this.openFileButton.Text = "Open File";
            this.tooltip.SetToolTip(this.openFileButton, "Open current file in default program for this filetype");
            this.openFileButton.UseVisualStyleBackColor = true;
            this.openFileButton.Click += new System.EventHandler(this.openFileButton_Click);
            // 
            // openFileInExplorerButton
            // 
            this.openFileInExplorerButton.AutoSize = true;
            this.openFileInExplorerButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.openFileInExplorerButton.Location = new System.Drawing.Point(129, 0);
            this.openFileInExplorerButton.Margin = new System.Windows.Forms.Padding(2, 0, 0, 0);
            this.openFileInExplorerButton.Name = "openFileInExplorerButton";
            this.openFileInExplorerButton.Size = new System.Drawing.Size(126, 23);
            this.openFileInExplorerButton.TabIndex = 11;
            this.openFileInExplorerButton.Text = "Open File In Explorer";
            this.tooltip.SetToolTip(this.openFileInExplorerButton, "View current file in file explorer");
            this.openFileInExplorerButton.UseVisualStyleBackColor = true;
            this.openFileInExplorerButton.Click += new System.EventHandler(this.openFileInExplorerButton_Click);
            // 
            // searchButton
            // 
            this.searchButton.Location = new System.Drawing.Point(228, 12);
            this.searchButton.Name = "searchButton";
            this.searchButton.Size = new System.Drawing.Size(277, 22);
            this.searchButton.TabIndex = 40;
            this.searchButton.Text = "Search";
            this.tooltip.SetToolTip(this.searchButton, "Search the selected directory with the selected tag parameters.\r\n");
            this.searchButton.UseVisualStyleBackColor = true;
            this.searchButton.Click += new System.EventHandler(this.searchButton_Click);
            // 
            // orPage
            // 
            this.orPage.AutoScroll = true;
            this.orPage.Location = new System.Drawing.Point(4, 22);
            this.orPage.Name = "orPage";
            this.orPage.Padding = new System.Windows.Forms.Padding(3);
            this.orPage.Size = new System.Drawing.Size(203, 237);
            this.orPage.TabIndex = 1;
            this.orPage.Tag = "Or";
            this.orPage.Text = "Or (0)";
            this.orPage.ToolTipText = "Must have one of the tags specified";
            this.orPage.UseVisualStyleBackColor = true;
            // 
            // notPage
            // 
            this.notPage.AutoScroll = true;
            this.notPage.Location = new System.Drawing.Point(4, 22);
            this.notPage.Name = "notPage";
            this.notPage.Size = new System.Drawing.Size(203, 237);
            this.notPage.TabIndex = 2;
            this.notPage.Tag = "Not";
            this.notPage.Text = "Not (0)";
            this.notPage.ToolTipText = "Must not have any of the tags specified.";
            this.notPage.UseVisualStyleBackColor = true;
            // 
            // tagSearchTextBox
            // 
            this.tagSearchTextBox.Location = new System.Drawing.Point(75, 40);
            this.tagSearchTextBox.Name = "tagSearchTextBox";
            this.tagSearchTextBox.Size = new System.Drawing.Size(146, 20);
            this.tagSearchTextBox.TabIndex = 35;
            this.tagSearchTextBox.TextChanged += new System.EventHandler(this.TagSearchTextBox_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(10, 44);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 13);
            this.label1.TabIndex = 36;
            this.label1.Text = "Tag Search";
            // 
            // settingsButton
            // 
            this.settingsButton.Location = new System.Drawing.Point(11, 12);
            this.settingsButton.Name = "settingsButton";
            this.settingsButton.Size = new System.Drawing.Size(71, 23);
            this.settingsButton.TabIndex = 37;
            this.settingsButton.Text = "Settings";
            this.settingsButton.UseVisualStyleBackColor = true;
            this.settingsButton.Click += new System.EventHandler(this.SettingsButton_Click);
            // 
            // filesPanel
            // 
            this.filesPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.filesPanel.AutoScroll = true;
            this.filesPanel.Location = new System.Drawing.Point(229, 68);
            this.filesPanel.Name = "filesPanel";
            this.filesPanel.Size = new System.Drawing.Size(276, 261);
            this.filesPanel.TabIndex = 38;
            // 
            // tabControl
            // 
            this.tabControl.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.tabControl.Controls.Add(this.andPage);
            this.tabControl.Controls.Add(this.orPage);
            this.tabControl.Controls.Add(this.notPage);
            this.tabControl.Location = new System.Drawing.Point(11, 68);
            this.tabControl.Name = "tabControl";
            this.tabControl.SelectedIndex = 0;
            this.tabControl.ShowToolTips = true;
            this.tabControl.Size = new System.Drawing.Size(211, 263);
            this.tabControl.TabIndex = 39;
            // 
            // andPage
            // 
            this.andPage.AutoScroll = true;
            this.andPage.Location = new System.Drawing.Point(4, 22);
            this.andPage.Name = "andPage";
            this.andPage.Size = new System.Drawing.Size(203, 237);
            this.andPage.TabIndex = 3;
            this.andPage.Tag = "And";
            this.andPage.Text = "And (0)";
            this.andPage.UseVisualStyleBackColor = true;
            // 
            // resultsCountLabel
            // 
            this.resultsCountLabel.AutoSize = true;
            this.resultsCountLabel.Location = new System.Drawing.Point(226, 43);
            this.resultsCountLabel.Name = "resultsCountLabel";
            this.resultsCountLabel.Size = new System.Drawing.Size(51, 13);
            this.resultsCountLabel.TabIndex = 41;
            this.resultsCountLabel.Text = "0 Results";
            // 
            // openFilesTableLayoutPanel1
            // 
            this.openFilesTableLayoutPanel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.openFilesTableLayoutPanel1.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.openFilesTableLayoutPanel1.ColumnCount = 2;
            this.openFilesTableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.openFilesTableLayoutPanel1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.openFilesTableLayoutPanel1.Controls.Add(this.openFileInExplorerButton, 1, 0);
            this.openFilesTableLayoutPanel1.Controls.Add(this.openFileButton, 0, 0);
            this.openFilesTableLayoutPanel1.Location = new System.Drawing.Point(511, 306);
            this.openFilesTableLayoutPanel1.Name = "openFilesTableLayoutPanel1";
            this.openFilesTableLayoutPanel1.RowCount = 1;
            this.openFilesTableLayoutPanel1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.openFilesTableLayoutPanel1.Size = new System.Drawing.Size(255, 23);
            this.openFilesTableLayoutPanel1.TabIndex = 47;
            // 
            // mediaViewer
            // 
            this.mediaViewer.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.mediaViewer.Location = new System.Drawing.Point(511, 12);
            this.mediaViewer.Name = "mediaViewer";
            this.mediaViewer.Size = new System.Drawing.Size(255, 288);
            this.mediaViewer.TabIndex = 48;
            this.mediaViewer.VideoPosition = -1F;
            // 
            // ViewForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(771, 336);
            this.Controls.Add(this.mediaViewer);
            this.Controls.Add(this.openFilesTableLayoutPanel1);
            this.Controls.Add(this.resultsCountLabel);
            this.Controls.Add(this.searchButton);
            this.Controls.Add(this.tabControl);
            this.Controls.Add(this.filesPanel);
            this.Controls.Add(this.settingsButton);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.tagSearchTextBox);
            this.Controls.Add(this.openDirectoryButton);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MinimumSize = new System.Drawing.Size(787, 375);
            this.Name = "ViewForm";
            this.Text = "Sorter Express - View";
            this.tabControl.ResumeLayout(false);
            this.openFilesTableLayoutPanel1.ResumeLayout(false);
            this.openFilesTableLayoutPanel1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button openDirectoryButton;
        private System.Windows.Forms.Button openFileButton;
        private System.Windows.Forms.Button openFileInExplorerButton;
        private System.Windows.Forms.ToolTip tooltip;
        private System.Windows.Forms.TextBox tagSearchTextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button settingsButton;
        private System.Windows.Forms.Panel filesPanel;
        private System.Windows.Forms.TabControl tabControl;
        private System.Windows.Forms.TabPage orPage;
        private System.Windows.Forms.TabPage notPage;
        private System.Windows.Forms.Button searchButton;
        private System.Windows.Forms.Label resultsCountLabel;
        private System.Windows.Forms.TabPage andPage;
        private System.Windows.Forms.TableLayoutPanel openFilesTableLayoutPanel1;
        private Controls.MediaViewer mediaViewer;
    }
}

