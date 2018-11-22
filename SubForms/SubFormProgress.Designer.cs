namespace MyVideoExplorer
{
    partial class SubFormProgress
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
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.labelProgress = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // progressBar
            // 
            this.progressBar.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.progressBar.Location = new System.Drawing.Point(0, 35);
            this.progressBar.Margin = new System.Windows.Forms.Padding(0);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(160, 30);
            this.progressBar.TabIndex = 0;
            // 
            // labelProgress
            // 
            this.labelProgress.Dock = System.Windows.Forms.DockStyle.Top;
            this.labelProgress.Location = new System.Drawing.Point(0, 0);
            this.labelProgress.Name = "labelProgress";
            this.labelProgress.Size = new System.Drawing.Size(160, 30);
            this.labelProgress.TabIndex = 1;
            this.labelProgress.Text = "labelProgress\r\n1234567890\r\n";
            this.labelProgress.Click += new System.EventHandler(this.labelProgress_Click);
            // 
            // SubFormProgress
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.labelProgress);
            this.Margin = new System.Windows.Forms.Padding(0);
            this.Name = "SubFormProgress";
            this.Size = new System.Drawing.Size(160, 65);
            this.Load += new System.EventHandler(this.SubFormProgress_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.Label labelProgress;

    }
}
