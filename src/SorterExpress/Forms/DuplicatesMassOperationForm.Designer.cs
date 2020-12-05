namespace SorterExpress.Forms
{
    partial class DuplicatesMassOperationForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DuplicatesMassOperationForm));
            this.massOperationLabel = new System.Windows.Forms.Label();
            this.groupBox = new System.Windows.Forms.GroupBox();
            this.filenamePreferencesGroupBox = new System.Windows.Forms.GroupBox();
            this.flowLayoutPanel1 = new System.Windows.Forms.FlowLayoutPanel();
            this.mergeFileTagsCheckBox = new System.Windows.Forms.CheckBox();
            this.onlyKeepLibraryTagsCheckBox = new System.Windows.Forms.CheckBox();
            this.keepFilePreferenceGroupBox = new System.Windows.Forms.GroupBox();
            this.keepFilePreferenceFlowLayoutPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.row1 = new System.Windows.Forms.TableLayoutPanel();
            this.row1Label = new System.Windows.Forms.Label();
            this.row1ComboBox = new System.Windows.Forms.ComboBox();
            this.performOperationButton = new System.Windows.Forms.Button();
            this.backgroundWorker = new System.ComponentModel.BackgroundWorker();
            this.loadingPanel = new SorterExpress.Controls.LoadingPanel();
            this.groupBox.SuspendLayout();
            this.filenamePreferencesGroupBox.SuspendLayout();
            this.flowLayoutPanel1.SuspendLayout();
            this.keepFilePreferenceGroupBox.SuspendLayout();
            this.keepFilePreferenceFlowLayoutPanel.SuspendLayout();
            this.row1.SuspendLayout();
            this.SuspendLayout();
            // 
            // massOperationLabel
            // 
            this.massOperationLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.massOperationLabel.Location = new System.Drawing.Point(5, 8);
            this.massOperationLabel.Name = "massOperationLabel";
            this.massOperationLabel.Size = new System.Drawing.Size(524, 124);
            this.massOperationLabel.TabIndex = 1;
            this.massOperationLabel.Text = resources.GetString("massOperationLabel.Text");
            // 
            // groupBox
            // 
            this.groupBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox.Controls.Add(this.filenamePreferencesGroupBox);
            this.groupBox.Controls.Add(this.keepFilePreferenceGroupBox);
            this.groupBox.Location = new System.Drawing.Point(5, 135);
            this.groupBox.Name = "groupBox";
            this.groupBox.Size = new System.Drawing.Size(524, 196);
            this.groupBox.TabIndex = 2;
            this.groupBox.TabStop = false;
            this.groupBox.Text = "Options";
            // 
            // filenamePreferencesGroupBox
            // 
            this.filenamePreferencesGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.filenamePreferencesGroupBox.Controls.Add(this.flowLayoutPanel1);
            this.filenamePreferencesGroupBox.Location = new System.Drawing.Point(284, 20);
            this.filenamePreferencesGroupBox.Name = "filenamePreferencesGroupBox";
            this.filenamePreferencesGroupBox.Size = new System.Drawing.Size(234, 171);
            this.filenamePreferencesGroupBox.TabIndex = 1;
            this.filenamePreferencesGroupBox.TabStop = false;
            this.filenamePreferencesGroupBox.Text = "Filename Preferences";
            // 
            // flowLayoutPanel1
            // 
            this.flowLayoutPanel1.Controls.Add(this.mergeFileTagsCheckBox);
            this.flowLayoutPanel1.Controls.Add(this.onlyKeepLibraryTagsCheckBox);
            this.flowLayoutPanel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel1.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanel1.Location = new System.Drawing.Point(3, 16);
            this.flowLayoutPanel1.Name = "flowLayoutPanel1";
            this.flowLayoutPanel1.Size = new System.Drawing.Size(228, 152);
            this.flowLayoutPanel1.TabIndex = 32;
            // 
            // mergeFileTagsCheckBox
            // 
            this.mergeFileTagsCheckBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.mergeFileTagsCheckBox.AutoSize = true;
            this.mergeFileTagsCheckBox.Location = new System.Drawing.Point(3, 3);
            this.mergeFileTagsCheckBox.Name = "mergeFileTagsCheckBox";
            this.mergeFileTagsCheckBox.Size = new System.Drawing.Size(112, 17);
            this.mergeFileTagsCheckBox.TabIndex = 30;
            this.mergeFileTagsCheckBox.Text = "Merge File Tags �";
            this.mergeFileTagsCheckBox.UseVisualStyleBackColor = true;
            // 
            // onlyKeepLibraryTagsCheckBox
            // 
            this.onlyKeepLibraryTagsCheckBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.onlyKeepLibraryTagsCheckBox.AutoSize = true;
            this.onlyKeepLibraryTagsCheckBox.Location = new System.Drawing.Point(3, 26);
            this.onlyKeepLibraryTagsCheckBox.Name = "onlyKeepLibraryTagsCheckBox";
            this.onlyKeepLibraryTagsCheckBox.Size = new System.Drawing.Size(205, 17);
            this.onlyKeepLibraryTagsCheckBox.TabIndex = 31;
            this.onlyKeepLibraryTagsCheckBox.Text = "Only keep tags that are in tag library �";
            this.onlyKeepLibraryTagsCheckBox.UseVisualStyleBackColor = true;
            // 
            // keepFilePreferenceGroupBox
            // 
            this.keepFilePreferenceGroupBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.keepFilePreferenceGroupBox.Controls.Add(this.keepFilePreferenceFlowLayoutPanel);
            this.keepFilePreferenceGroupBox.Location = new System.Drawing.Point(3, 20);
            this.keepFilePreferenceGroupBox.Name = "keepFilePreferenceGroupBox";
            this.keepFilePreferenceGroupBox.Size = new System.Drawing.Size(275, 171);
            this.keepFilePreferenceGroupBox.TabIndex = 0;
            this.keepFilePreferenceGroupBox.TabStop = false;
            this.keepFilePreferenceGroupBox.Text = "Keep File Preferences";
            // 
            // keepFilePreferenceFlowLayoutPanel
            // 
            this.keepFilePreferenceFlowLayoutPanel.AutoScroll = true;
            this.keepFilePreferenceFlowLayoutPanel.Controls.Add(this.row1);
            this.keepFilePreferenceFlowLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.keepFilePreferenceFlowLayoutPanel.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.keepFilePreferenceFlowLayoutPanel.Location = new System.Drawing.Point(3, 16);
            this.keepFilePreferenceFlowLayoutPanel.Name = "keepFilePreferenceFlowLayoutPanel";
            this.keepFilePreferenceFlowLayoutPanel.Size = new System.Drawing.Size(269, 152);
            this.keepFilePreferenceFlowLayoutPanel.TabIndex = 0;
            this.keepFilePreferenceFlowLayoutPanel.WrapContents = false;
            // 
            // row1
            // 
            this.row1.ColumnCount = 2;
            this.row1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Absolute, 25F));
            this.row1.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.row1.Controls.Add(this.row1Label, 0, 0);
            this.row1.Controls.Add(this.row1ComboBox, 1, 0);
            this.row1.Location = new System.Drawing.Point(3, 3);
            this.row1.Name = "row1";
            this.row1.RowCount = 1;
            this.row1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
            this.row1.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 28F));
            this.row1.Size = new System.Drawing.Size(263, 28);
            this.row1.TabIndex = 0;
            this.row1.Tag = 0;
            // 
            // row1Label
            // 
            this.row1Label.AutoSize = true;
            this.row1Label.Dock = System.Windows.Forms.DockStyle.Fill;
            this.row1Label.Location = new System.Drawing.Point(3, 0);
            this.row1Label.Name = "row1Label";
            this.row1Label.Size = new System.Drawing.Size(19, 28);
            this.row1Label.TabIndex = 0;
            this.row1Label.Text = "1.";
            this.row1Label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // row1ComboBox
            // 
            this.row1ComboBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.row1ComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.row1ComboBox.FormattingEnabled = true;
            this.row1ComboBox.Location = new System.Drawing.Point(28, 3);
            this.row1ComboBox.Name = "row1ComboBox";
            this.row1ComboBox.Size = new System.Drawing.Size(232, 21);
            this.row1ComboBox.TabIndex = 1;
            this.row1ComboBox.Tag = "0";
            this.row1ComboBox.SelectionChangeCommitted += new System.EventHandler(this.comboBox_SelectedIndexChanged);
            // 
            // performOperationButton
            // 
            this.performOperationButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.performOperationButton.Location = new System.Drawing.Point(4, 334);
            this.performOperationButton.Name = "performOperationButton";
            this.performOperationButton.Size = new System.Drawing.Size(526, 23);
            this.performOperationButton.TabIndex = 3;
            this.performOperationButton.Text = "Perform Operation";
            this.performOperationButton.UseVisualStyleBackColor = true;
            this.performOperationButton.Click += new System.EventHandler(this.performOperationButton_Click);
            // 
            // backgroundWorker
            // 
            this.backgroundWorker.WorkerReportsProgress = true;
            this.backgroundWorker.WorkerSupportsCancellation = true;
            this.backgroundWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.backgroundWorker_DoWork);
            this.backgroundWorker.ProgressChanged += new System.ComponentModel.ProgressChangedEventHandler(this.backgroundWorker_ProgressChanged);
            this.backgroundWorker.RunWorkerCompleted += new System.ComponentModel.RunWorkerCompletedEventHandler(this.backgroundWorker_RunWorkerCompleted);
            // 
            // loadingPanel
            // 
            this.loadingPanel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.loadingPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.loadingPanel.BottomText = "";
            this.loadingPanel.HideInDesigner = false;
            this.loadingPanel.Location = new System.Drawing.Point(42, 70);
            this.loadingPanel.MaximumSize = new System.Drawing.Size(600, 350);
            this.loadingPanel.MinimumSize = new System.Drawing.Size(360, 170);
            this.loadingPanel.Name = "loadingPanel";
            this.loadingPanel.ProgressBarStyle = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.loadingPanel.ProgressValue = 0;
            this.loadingPanel.Size = new System.Drawing.Size(446, 192);
            this.loadingPanel.TabIndex = 4;
            this.loadingPanel.TopText = "Loading...";
            this.loadingPanel.Visible = false;
            // 
            // DuplicatesMassOperationForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(534, 361);
            this.Controls.Add(this.loadingPanel);
            this.Controls.Add(this.performOperationButton);
            this.Controls.Add(this.groupBox);
            this.Controls.Add(this.massOperationLabel);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(550, 400);
            this.Name = "DuplicatesMassOperationForm";
            this.Text = "Duplicates Search - Mass Operation";
            this.groupBox.ResumeLayout(false);
            this.filenamePreferencesGroupBox.ResumeLayout(false);
            this.flowLayoutPanel1.ResumeLayout(false);
            this.flowLayoutPanel1.PerformLayout();
            this.keepFilePreferenceGroupBox.ResumeLayout(false);
            this.keepFilePreferenceFlowLayoutPanel.ResumeLayout(false);
            this.row1.ResumeLayout(false);
            this.row1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label massOperationLabel;
        private System.Windows.Forms.GroupBox groupBox;
        private System.Windows.Forms.GroupBox filenamePreferencesGroupBox;
        private System.Windows.Forms.GroupBox keepFilePreferenceGroupBox;
        private System.Windows.Forms.FlowLayoutPanel keepFilePreferenceFlowLayoutPanel;
        private System.Windows.Forms.TableLayoutPanel row1;
        private System.Windows.Forms.Label row1Label;
        private System.Windows.Forms.ComboBox row1ComboBox;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel1;
        private System.Windows.Forms.CheckBox mergeFileTagsCheckBox;
        private System.Windows.Forms.CheckBox onlyKeepLibraryTagsCheckBox;
        private System.Windows.Forms.Button performOperationButton;
        private Controls.LoadingPanel loadingPanel;
        private System.ComponentModel.BackgroundWorker backgroundWorker;
    }
}