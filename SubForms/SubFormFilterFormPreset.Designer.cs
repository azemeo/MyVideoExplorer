namespace MyVideoExplorer
{
    partial class SubFormFilterFormPreset
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
            this.labelForFilters = new System.Windows.Forms.Label();
            this.buttonDelete = new System.Windows.Forms.Button();
            this.buttonSave = new System.Windows.Forms.Button();
            this.comboBoxFilters = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // labelForFilters
            // 
            this.labelForFilters.AutoSize = true;
            this.labelForFilters.Location = new System.Drawing.Point(3, 0);
            this.labelForFilters.Name = "labelForFilters";
            this.labelForFilters.Size = new System.Drawing.Size(44, 16);
            this.labelForFilters.TabIndex = 77;
            this.labelForFilters.Text = "Filters";
            // 
            // buttonDelete
            // 
            this.buttonDelete.Location = new System.Drawing.Point(224, 19);
            this.buttonDelete.Name = "buttonDelete";
            this.buttonDelete.Size = new System.Drawing.Size(16, 23);
            this.buttonDelete.TabIndex = 76;
            this.buttonDelete.Text = "X";
            this.buttonDelete.UseVisualStyleBackColor = true;
            this.buttonDelete.Click += new System.EventHandler(this.buttonDelete_Click);
            // 
            // buttonSave
            // 
            this.buttonSave.Location = new System.Drawing.Point(168, 18);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(50, 23);
            this.buttonSave.TabIndex = 75;
            this.buttonSave.Text = "Save";
            this.buttonSave.UseVisualStyleBackColor = true;
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // comboBoxFilters
            // 
            this.comboBoxFilters.FormattingEnabled = true;
            this.comboBoxFilters.Location = new System.Drawing.Point(6, 17);
            this.comboBoxFilters.Name = "comboBoxFilters";
            this.comboBoxFilters.Size = new System.Drawing.Size(154, 24);
            this.comboBoxFilters.TabIndex = 74;
            this.comboBoxFilters.SelectedIndexChanged += new System.EventHandler(this.comboBoxPreset_SelectedIndexChanged);
            this.comboBoxFilters.SelectionChangeCommitted += new System.EventHandler(this.comboBoxFilters_SelectionChangeCommitted);
            this.comboBoxFilters.TextChanged += new System.EventHandler(this.comboBoxFilters_TextChanged);
            // 
            // SubFormFilterFormPreset
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.labelForFilters);
            this.Controls.Add(this.buttonDelete);
            this.Controls.Add(this.buttonSave);
            this.Controls.Add(this.comboBoxFilters);
            this.Name = "SubFormFilterFormPreset";
            this.Size = new System.Drawing.Size(245, 45);
            this.Load += new System.EventHandler(this.SubFormFilterFormPreset_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label labelForFilters;
        private System.Windows.Forms.Button buttonDelete;
        private System.Windows.Forms.Button buttonSave;
        private System.Windows.Forms.ComboBox comboBoxFilters;
    }
}
