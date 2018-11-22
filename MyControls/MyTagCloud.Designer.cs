namespace MyVideoExplorer
{
    partial class MyTagCloud
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
            this.flowLayoutPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.buttonToggle = new System.Windows.Forms.Button();
            this.textBoxTags = new System.Windows.Forms.TextBox();
            this.labelTagType = new System.Windows.Forms.Label();
            this.flowLayoutPanel.SuspendLayout();
            this.SuspendLayout();
            // 
            // flowLayoutPanel
            // 
            this.flowLayoutPanel.AutoScroll = true;
            this.flowLayoutPanel.Controls.Add(this.buttonToggle);
            this.flowLayoutPanel.Controls.Add(this.textBoxTags);
            this.flowLayoutPanel.Controls.Add(this.labelTagType);
            this.flowLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.flowLayoutPanel.Location = new System.Drawing.Point(0, 0);
            this.flowLayoutPanel.Name = "flowLayoutPanel";
            this.flowLayoutPanel.Size = new System.Drawing.Size(313, 176);
            this.flowLayoutPanel.TabIndex = 0;
            this.flowLayoutPanel.Paint += new System.Windows.Forms.PaintEventHandler(this.flowLayoutPanel_Paint);
            this.flowLayoutPanel.MouseEnter += new System.EventHandler(this.flowLayoutPanel_MouseEnter);
            this.flowLayoutPanel.MouseLeave += new System.EventHandler(this.flowLayoutPanel_MouseLeave);
            // 
            // buttonToggle
            // 
            this.buttonToggle.Location = new System.Drawing.Point(3, 3);
            this.buttonToggle.Name = "buttonToggle";
            this.buttonToggle.Size = new System.Drawing.Size(25, 25);
            this.buttonToggle.TabIndex = 0;
            this.buttonToggle.Text = "T";
            this.buttonToggle.UseVisualStyleBackColor = true;
            this.buttonToggle.Click += new System.EventHandler(this.buttonToggle_Click);
            // 
            // textBoxTags
            // 
            this.textBoxTags.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.textBoxTags.Location = new System.Drawing.Point(34, 3);
            this.textBoxTags.Multiline = true;
            this.textBoxTags.Name = "textBoxTags";
            this.textBoxTags.Size = new System.Drawing.Size(273, 25);
            this.textBoxTags.TabIndex = 1;
            this.textBoxTags.TextChanged += new System.EventHandler(this.textBoxTags_TextChanged);
            this.textBoxTags.Leave += new System.EventHandler(this.textBoxTags_Leave);
            // 
            // labelTagType
            // 
            this.labelTagType.AutoSize = true;
            this.labelTagType.Location = new System.Drawing.Point(3, 31);
            this.labelTagType.Name = "labelTagType";
            this.labelTagType.Size = new System.Drawing.Size(56, 16);
            this.labelTagType.TabIndex = 2;
            this.labelTagType.Text = "tag type";
            // 
            // MyTagCloud
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.flowLayoutPanel);
            this.Name = "MyTagCloud";
            this.Size = new System.Drawing.Size(313, 176);
            this.Load += new System.EventHandler(this.MyTagCloud_Load);
            this.flowLayoutPanel.ResumeLayout(false);
            this.flowLayoutPanel.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanel;
        private System.Windows.Forms.Button buttonToggle;
        private System.Windows.Forms.TextBox textBoxTags;
        private System.Windows.Forms.Label labelTagType;
    }
}
