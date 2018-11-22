namespace MyVideoExplorer
{
    partial class SubFormFilterFormTag
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
            this.buttonCriteria = new System.Windows.Forms.Button();
            this.comboBoxCriteria = new System.Windows.Forms.ComboBox();
            this.flowLayoutPanelCriteria = new System.Windows.Forms.FlowLayoutPanel();
            this.SuspendLayout();
            // 
            // buttonCriteria
            // 
            this.buttonCriteria.Location = new System.Drawing.Point(132, 2);
            this.buttonCriteria.Name = "buttonCriteria";
            this.buttonCriteria.Size = new System.Drawing.Size(92, 23);
            this.buttonCriteria.TabIndex = 78;
            this.buttonCriteria.Text = "Add Criteria";
            this.buttonCriteria.UseVisualStyleBackColor = true;
            this.buttonCriteria.Click += new System.EventHandler(this.buttonCriteria_Click);
            // 
            // comboBoxCriteria
            // 
            this.comboBoxCriteria.FormattingEnabled = true;
            this.comboBoxCriteria.Location = new System.Drawing.Point(9, 2);
            this.comboBoxCriteria.Name = "comboBoxCriteria";
            this.comboBoxCriteria.Size = new System.Drawing.Size(117, 24);
            this.comboBoxCriteria.TabIndex = 80;
            this.comboBoxCriteria.SelectedIndexChanged += new System.EventHandler(this.comboBoxCriteria_SelectedIndexChanged);
            // 
            // flowLayoutPanelCriteria
            // 
            this.flowLayoutPanelCriteria.AutoScroll = true;
            this.flowLayoutPanelCriteria.FlowDirection = System.Windows.Forms.FlowDirection.TopDown;
            this.flowLayoutPanelCriteria.Location = new System.Drawing.Point(3, 31);
            this.flowLayoutPanelCriteria.Name = "flowLayoutPanelCriteria";
            this.flowLayoutPanelCriteria.Size = new System.Drawing.Size(227, 287);
            this.flowLayoutPanelCriteria.TabIndex = 79;
            this.flowLayoutPanelCriteria.WrapContents = false;
            this.flowLayoutPanelCriteria.Paint += new System.Windows.Forms.PaintEventHandler(this.flowLayoutPanelCriteria_Paint);
            // 
            // SubFormFilterFormCriteria
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.buttonCriteria);
            this.Controls.Add(this.comboBoxCriteria);
            this.Controls.Add(this.flowLayoutPanelCriteria);
            this.Name = "SubFormFilterFormCriteria";
            this.Size = new System.Drawing.Size(232, 320);
            this.Load += new System.EventHandler(this.SubFormFilterFormCriteria_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonCriteria;
        private System.Windows.Forms.ComboBox comboBoxCriteria;
        private System.Windows.Forms.FlowLayoutPanel flowLayoutPanelCriteria;
    }
}
