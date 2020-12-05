
namespace SorterExpress.Controls
{
    partial class LoadingPanel
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

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.loadingTitleTextBox = new System.Windows.Forms.TextBox();
            this.loadingDescriptionRichTextBox = new System.Windows.Forms.RichTextBox();
            this.loadingProgressBar = new System.Windows.Forms.ProgressBar();
            this.loadingPanelBindingSource = new System.Windows.Forms.BindingSource(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.loadingPanelBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // loadingTitleTextBox
            // 
            this.loadingTitleTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.loadingTitleTextBox.BackColor = System.Drawing.SystemColors.Control;
            this.loadingTitleTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.loadingTitleTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.loadingPanelBindingSource, "TopText", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.loadingTitleTextBox.Enabled = false;
            this.loadingTitleTextBox.Location = new System.Drawing.Point(6, 27);
            this.loadingTitleTextBox.Name = "loadingTitleTextBox";
            this.loadingTitleTextBox.Size = new System.Drawing.Size(438, 13);
            this.loadingTitleTextBox.TabIndex = 1;
            this.loadingTitleTextBox.Text = "Loading...";
            this.loadingTitleTextBox.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // loadingDescriptionRichTextBox
            // 
            this.loadingDescriptionRichTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.loadingDescriptionRichTextBox.BackColor = System.Drawing.SystemColors.Control;
            this.loadingDescriptionRichTextBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.loadingDescriptionRichTextBox.DataBindings.Add(new System.Windows.Forms.Binding("Text", this.loadingPanelBindingSource, "BottomText", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.loadingDescriptionRichTextBox.Enabled = false;
            this.loadingDescriptionRichTextBox.Location = new System.Drawing.Point(53, 65);
            this.loadingDescriptionRichTextBox.Name = "loadingDescriptionRichTextBox";
            this.loadingDescriptionRichTextBox.Size = new System.Drawing.Size(338, 100);
            this.loadingDescriptionRichTextBox.TabIndex = 2;
            this.loadingDescriptionRichTextBox.Text = "Please Wait";
            // 
            // loadingProgressBar
            // 
            this.loadingProgressBar.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.loadingProgressBar.DataBindings.Add(new System.Windows.Forms.Binding("Value", this.loadingPanelBindingSource, "ProgressValue", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.loadingProgressBar.DataBindings.Add(new System.Windows.Forms.Binding("Style", this.loadingPanelBindingSource, "ProgressBarStyle", true, System.Windows.Forms.DataSourceUpdateMode.OnPropertyChanged));
            this.loadingProgressBar.Location = new System.Drawing.Point(28, 195);
            this.loadingProgressBar.Name = "loadingProgressBar";
            this.loadingProgressBar.Size = new System.Drawing.Size(395, 23);
            this.loadingProgressBar.TabIndex = 0;
            // 
            // loadingPanelBindingSource
            // 
            this.loadingPanelBindingSource.DataSource = typeof(SorterExpress.Controls.LoadingPanel);
            // 
            // LoadingPanel
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.loadingTitleTextBox);
            this.Controls.Add(this.loadingDescriptionRichTextBox);
            this.Controls.Add(this.loadingProgressBar);
            this.MaximumSize = new System.Drawing.Size(600, 350);
            this.MinimumSize = new System.Drawing.Size(360, 170);
            this.Name = "LoadingPanel";
            this.Size = new System.Drawing.Size(452, 242);
            this.ParentChanged += new System.EventHandler(this.LoadingPanel_ParentChanged);
            ((System.ComponentModel.ISupportInitialize)(this.loadingPanelBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        public System.Windows.Forms.TextBox loadingTitleTextBox;
        public System.Windows.Forms.RichTextBox loadingDescriptionRichTextBox;
        public System.Windows.Forms.ProgressBar loadingProgressBar;
        private System.Windows.Forms.BindingSource loadingPanelBindingSource;
    }
}
