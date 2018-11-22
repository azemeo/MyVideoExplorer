namespace MyVideoExplorer
{
    partial class SubFormVideoImage
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
            this.splitContainerImageList = new System.Windows.Forms.SplitContainer();
            this.panelPictureBox = new System.Windows.Forms.Panel();
            this.pictureBoxImage = new System.Windows.Forms.PictureBox();
            this.flowLayoutPanelImages = new System.Windows.Forms.FlowLayoutPanel();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerImageList)).BeginInit();
            this.splitContainerImageList.Panel1.SuspendLayout();
            this.splitContainerImageList.Panel2.SuspendLayout();
            this.splitContainerImageList.SuspendLayout();
            this.panelPictureBox.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxImage)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainerImageList
            // 
            this.splitContainerImageList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerImageList.Location = new System.Drawing.Point(0, 0);
            this.splitContainerImageList.Name = "splitContainerImageList";
            this.splitContainerImageList.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainerImageList.Panel1
            // 
            this.splitContainerImageList.Panel1.Controls.Add(this.panelPictureBox);
            // 
            // splitContainerImageList.Panel2
            // 
            this.splitContainerImageList.Panel2.Controls.Add(this.flowLayoutPanelImages);
            this.splitContainerImageList.Size = new System.Drawing.Size(240, 600);
            this.splitContainerImageList.SplitterDistance = 500;
            this.splitContainerImageList.TabIndex = 2;
            // 
            // panelPictureBox
            // 
            this.panelPictureBox.BackColor = System.Drawing.Color.Black;
            this.panelPictureBox.Controls.Add(this.pictureBoxImage);
            this.panelPictureBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelPictureBox.Location = new System.Drawing.Point(0, 0);
            this.panelPictureBox.Name = "panelPictureBox";
            this.panelPictureBox.Padding = new System.Windows.Forms.Padding(4);
            this.panelPictureBox.Size = new System.Drawing.Size(240, 500);
            this.panelPictureBox.TabIndex = 1;
            // 
            // pictureBoxImage
            // 
            this.pictureBoxImage.BackColor = System.Drawing.Color.Black;
            this.pictureBoxImage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pictureBoxImage.Location = new System.Drawing.Point(4, 4);
            this.pictureBoxImage.Name = "pictureBoxImage";
            this.pictureBoxImage.Size = new System.Drawing.Size(232, 492);
            this.pictureBoxImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxImage.TabIndex = 0;
            this.pictureBoxImage.TabStop = false;
            this.pictureBoxImage.SizeChanged += new System.EventHandler(this.pictureBoxImage_SizeChanged);
            // 
            // flowLayoutPanelImages
            // 
            this.flowLayoutPanelImages.BackColor = System.Drawing.Color.Black;
            this.flowLayoutPanelImages.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanelImages.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanelImages.Name = "flowLayoutPanelImages";
            this.flowLayoutPanelImages.Size = new System.Drawing.Size(240, 96);
            this.flowLayoutPanelImages.TabIndex = 0;
            this.flowLayoutPanelImages.Paint += new System.Windows.Forms.PaintEventHandler(this.flowLayoutPanelImages_Paint);
            // 
            // SubFormVideoImage
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.splitContainerImageList);
            this.Name = "SubFormVideoImage";
            this.Size = new System.Drawing.Size(240, 600);
            this.Load += new System.EventHandler(this.SubFormVideoImage_Load);
            this.splitContainerImageList.Panel1.ResumeLayout(false);
            this.splitContainerImageList.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerImageList)).EndInit();
            this.splitContainerImageList.ResumeLayout(false);
            this.panelPictureBox.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxImage)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainerImageList;
        public System.Windows.Forms.PictureBox pictureBoxImage;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelImages;
        private System.Windows.Forms.Panel panelPictureBox;
    }
}
