namespace MyVideoExplorer
{
    partial class SubFormGallery
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
            this.flowLayoutPanelPosters = new System.Windows.Forms.FlowLayoutPanel();
            this.SuspendLayout();
            // 
            // flowLayoutPanelPosters
            // 
            this.flowLayoutPanelPosters.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanelPosters.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanelPosters.Name = "flowLayoutPanelPosters";
            this.flowLayoutPanelPosters.Size = new System.Drawing.Size(565, 540);
            this.flowLayoutPanelPosters.TabIndex = 0;
            this.flowLayoutPanelPosters.Scroll += new System.Windows.Forms.ScrollEventHandler(this.flowLayoutPanel_Scroll);
            this.flowLayoutPanelPosters.Paint += new System.Windows.Forms.PaintEventHandler(this.flowLayoutPanel_Paint);
            this.flowLayoutPanelPosters.MouseEnter += new System.EventHandler(this.flowLayoutPanel_MouseEnter);
            this.flowLayoutPanelPosters.MouseLeave += new System.EventHandler(this.flowLayoutPanel_MouseLeave);
            this.flowLayoutPanelPosters.Resize += new System.EventHandler(this.flowLayoutPanel_Resize);
            // 
            // SubFormGallery
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.flowLayoutPanelPosters);
            this.Name = "SubFormGallery";
            this.Size = new System.Drawing.Size(565, 540);
            this.Load += new System.EventHandler(this.SubFormGallery_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelPosters;
    }
}
