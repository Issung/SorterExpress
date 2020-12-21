namespace SorterExpress.Forms
{
    partial class GetStringMessageBox
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(GetStringMessageBox));
            this.promptLabel = new System.Windows.Forms.Label();
            this.entryTextBox = new System.Windows.Forms.TextBox();
            this.okButton = new System.Windows.Forms.Button();
            this.cancelButton = new System.Windows.Forms.Button();
            this.buttonTableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
            this.buttonTableLayoutPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // promptLabel
            // 
            this.promptLabel.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.promptLabel.Location = new System.Drawing.Point(19, 13);
            this.promptLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.promptLabel.Name = "promptLabel";
            this.promptLabel.Size = new System.Drawing.Size(455, 15);
            this.promptLabel.TabIndex = 0;
            this.promptLabel.Text = "Please enter a string. Some characters are disallowed.";
            this.promptLabel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // entryTextBox
            // 
            this.entryTextBox.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.entryTextBox.Location = new System.Drawing.Point(19, 46);
            this.entryTextBox.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.entryTextBox.Name = "entryTextBox";
            this.entryTextBox.Size = new System.Drawing.Size(455, 23);
            this.entryTextBox.TabIndex = 1;
            this.entryTextBox.TextChanged += new System.EventHandler(this.entryTextBox_TextChanged);
            this.entryTextBox.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.entryTextBox_KeyPress);
            // 
            // okButton
            // 
            this.okButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.okButton.Location = new System.Drawing.Point(0, 0);
            this.okButton.Margin = new System.Windows.Forms.Padding(0, 0, 2, 0);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(226, 27);
            this.okButton.TabIndex = 2;
            this.okButton.Text = "OK";
            this.okButton.UseVisualStyleBackColor = true;
            this.okButton.Click += new System.EventHandler(this.okButton_Click);
            // 
            // cancelButton
            // 
            this.cancelButton.Dock = System.Windows.Forms.DockStyle.Fill;
            this.cancelButton.Location = new System.Drawing.Point(230, 0);
            this.cancelButton.Margin = new System.Windows.Forms.Padding(2, 0, 0, 0);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(226, 27);
            this.cancelButton.TabIndex = 3;
            this.cancelButton.Text = "Cancel";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
            // 
            // buttonTableLayoutPanel
            // 
            this.buttonTableLayoutPanel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonTableLayoutPanel.ColumnCount = 2;
            this.buttonTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.buttonTableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.buttonTableLayoutPanel.Controls.Add(this.cancelButton, 1, 0);
            this.buttonTableLayoutPanel.Controls.Add(this.okButton, 0, 0);
            this.buttonTableLayoutPanel.Location = new System.Drawing.Point(19, 76);
            this.buttonTableLayoutPanel.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.buttonTableLayoutPanel.Name = "buttonTableLayoutPanel";
            this.buttonTableLayoutPanel.RowCount = 1;
            this.buttonTableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 50F));
            this.buttonTableLayoutPanel.Size = new System.Drawing.Size(456, 27);
            this.buttonTableLayoutPanel.TabIndex = 4;
            // 
            // GetStringMessageBox
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(489, 117);
            this.Controls.Add(this.buttonTableLayoutPanel);
            this.Controls.Add(this.entryTextBox);
            this.Controls.Add(this.promptLabel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(505, 156);
            this.MinimumSize = new System.Drawing.Size(505, 156);
            this.Name = "GetStringMessageBox";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "String Input";
            this.buttonTableLayoutPanel.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label promptLabel;
        private System.Windows.Forms.TextBox entryTextBox;
        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.TableLayoutPanel buttonTableLayoutPanel;
    }
}