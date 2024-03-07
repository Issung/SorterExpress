
namespace SorterExpress.Controls
{
    partial class UpdateView
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
            label = new System.Windows.Forms.Label();
            button = new System.Windows.Forms.Button();
            progressBar = new System.Windows.Forms.ProgressBar();
            SuspendLayout();
            // 
            // label
            // 
            label.Anchor = System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            label.Location = new System.Drawing.Point(0, 0);
            label.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            label.Name = "label";
            label.Size = new System.Drawing.Size(284, 33);
            label.TabIndex = 0;
            label.Text = "No updates available";
            // 
            // button
            // 
            button.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            button.Location = new System.Drawing.Point(0, 37);
            button.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            button.Name = "button";
            button.Size = new System.Drawing.Size(284, 27);
            button.TabIndex = 1;
            button.Text = "Check for Updates";
            button.UseVisualStyleBackColor = true;
            button.Click += button_Click;
            // 
            // progressBar
            // 
            progressBar.Anchor = System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left | System.Windows.Forms.AnchorStyles.Right;
            progressBar.Location = new System.Drawing.Point(0, 37);
            progressBar.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            progressBar.Name = "progressBar";
            progressBar.Size = new System.Drawing.Size(284, 27);
            progressBar.TabIndex = 2;
            // 
            // UpdateView
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            Controls.Add(button);
            Controls.Add(label);
            Controls.Add(progressBar);
            Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            Name = "UpdateView";
            Size = new System.Drawing.Size(284, 63);
            Load += UpdateView_Load;
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Label label;
        private System.Windows.Forms.Button button;
        private System.Windows.Forms.ProgressBar progressBar;
    }
}
