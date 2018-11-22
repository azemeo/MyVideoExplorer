namespace MyVideoExplorer
{
    partial class SubFormFilterForm
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
            this.buttonReset = new System.Windows.Forms.Button();
            this.buttonFilter = new System.Windows.Forms.Button();
            this.textBoxTitle = new System.Windows.Forms.TextBox();
            this.labelTitle = new System.Windows.Forms.Label();
            this.labelForSortOrder = new System.Windows.Forms.Label();
            this.comboBoxSortColumn = new System.Windows.Forms.ComboBox();
            this.labelForSort = new System.Windows.Forms.Label();
            this.comboBoxSortOrder = new System.Windows.Forms.ComboBox();
            this.tabControlFilter = new System.Windows.Forms.TabControl();
            this.tabPageTags = new System.Windows.Forms.TabPage();
            this.subFormFilterFormCriteria = new MyVideoExplorer.SubFormFilterFormTag();
            this.tabPageSelect = new System.Windows.Forms.TabPage();
            this.subFormFilterFormSelect = new MyVideoExplorer.SubForms.SubFormFilterFormSelect();
            this.panel1 = new System.Windows.Forms.Panel();
            this.subFormFilterFormPreset = new MyVideoExplorer.SubFormFilterFormPreset();
            this.tabControlFilter.SuspendLayout();
            this.tabPageTags.SuspendLayout();
            this.tabPageSelect.SuspendLayout();
            this.SuspendLayout();
            // 
            // buttonReset
            // 
            this.buttonReset.Location = new System.Drawing.Point(180, 57);
            this.buttonReset.Name = "buttonReset";
            this.buttonReset.Size = new System.Drawing.Size(52, 23);
            this.buttonReset.TabIndex = 2;
            this.buttonReset.Text = "Reset";
            this.buttonReset.UseVisualStyleBackColor = true;
            this.buttonReset.Click += new System.EventHandler(this.buttonReset_Click);
            // 
            // buttonFilter
            // 
            this.buttonFilter.Location = new System.Drawing.Point(7, 57);
            this.buttonFilter.Name = "buttonFilter";
            this.buttonFilter.Size = new System.Drawing.Size(154, 23);
            this.buttonFilter.TabIndex = 3;
            this.buttonFilter.Text = "Filter";
            this.buttonFilter.UseVisualStyleBackColor = true;
            this.buttonFilter.Click += new System.EventHandler(this.buttonFilter_Click);
            // 
            // textBoxTitle
            // 
            this.textBoxTitle.Location = new System.Drawing.Point(14, 151);
            this.textBoxTitle.Name = "textBoxTitle";
            this.textBoxTitle.Size = new System.Drawing.Size(218, 22);
            this.textBoxTitle.TabIndex = 0;
            this.textBoxTitle.TextChanged += new System.EventHandler(this.textBoxTitle_TextChanged);
            this.textBoxTitle.KeyDown += new System.Windows.Forms.KeyEventHandler(this.textBoxTitle_KeyDown);
            this.textBoxTitle.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBoxTitle_KeyPress);
            // 
            // labelTitle
            // 
            this.labelTitle.Location = new System.Drawing.Point(14, 136);
            this.labelTitle.Name = "labelTitle";
            this.labelTitle.Size = new System.Drawing.Size(69, 13);
            this.labelTitle.TabIndex = 5;
            this.labelTitle.Text = "Title";
            // 
            // labelForSortOrder
            // 
            this.labelForSortOrder.AutoSize = true;
            this.labelForSortOrder.Location = new System.Drawing.Point(156, 92);
            this.labelForSortOrder.Name = "labelForSortOrder";
            this.labelForSortOrder.Size = new System.Drawing.Size(67, 16);
            this.labelForSortOrder.TabIndex = 67;
            this.labelForSortOrder.Text = "Sort order";
            // 
            // comboBoxSortColumn
            // 
            this.comboBoxSortColumn.FormattingEnabled = true;
            this.comboBoxSortColumn.Location = new System.Drawing.Point(14, 108);
            this.comboBoxSortColumn.Name = "comboBoxSortColumn";
            this.comboBoxSortColumn.Size = new System.Drawing.Size(121, 24);
            this.comboBoxSortColumn.TabIndex = 7;
            this.comboBoxSortColumn.SelectedIndexChanged += new System.EventHandler(this.comboBoxSortColumn_SelectedIndexChanged);
            // 
            // labelForSort
            // 
            this.labelForSort.Location = new System.Drawing.Point(14, 92);
            this.labelForSort.Name = "labelForSort";
            this.labelForSort.Size = new System.Drawing.Size(75, 16);
            this.labelForSort.TabIndex = 6;
            this.labelForSort.Text = "Sort by";
            // 
            // comboBoxSortOrder
            // 
            this.comboBoxSortOrder.FormattingEnabled = true;
            this.comboBoxSortOrder.Location = new System.Drawing.Point(153, 108);
            this.comboBoxSortOrder.Name = "comboBoxSortOrder";
            this.comboBoxSortOrder.Size = new System.Drawing.Size(79, 24);
            this.comboBoxSortOrder.TabIndex = 4;
            // 
            // tabControlFilter
            // 
            this.tabControlFilter.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControlFilter.Controls.Add(this.tabPageTags);
            this.tabControlFilter.Controls.Add(this.tabPageSelect);
            this.tabControlFilter.Location = new System.Drawing.Point(7, 183);
            this.tabControlFilter.Name = "tabControlFilter";
            this.tabControlFilter.SelectedIndex = 0;
            this.tabControlFilter.Size = new System.Drawing.Size(235, 354);
            this.tabControlFilter.TabIndex = 78;
            // 
            // tabPageTags
            // 
            this.tabPageTags.BackColor = System.Drawing.SystemColors.Control;
            this.tabPageTags.Controls.Add(this.subFormFilterFormCriteria);
            this.tabPageTags.Location = new System.Drawing.Point(4, 25);
            this.tabPageTags.Name = "tabPageTags";
            this.tabPageTags.Size = new System.Drawing.Size(227, 325);
            this.tabPageTags.TabIndex = 0;
            this.tabPageTags.Text = "by Tag Clouds";
            // 
            // subFormFilterFormCriteria
            // 
            this.subFormFilterFormCriteria.Location = new System.Drawing.Point(-4, 0);
            this.subFormFilterFormCriteria.MinimumSize = new System.Drawing.Size(227, 322);
            this.subFormFilterFormCriteria.Name = "subFormFilterFormCriteria";
            this.subFormFilterFormCriteria.Size = new System.Drawing.Size(232, 322);
            this.subFormFilterFormCriteria.TabIndex = 0;
            this.subFormFilterFormCriteria.Load += new System.EventHandler(this.subFormFilterFormCriteria_Load);
            // 
            // tabPageSelect
            // 
            this.tabPageSelect.BackColor = System.Drawing.SystemColors.Control;
            this.tabPageSelect.Controls.Add(this.subFormFilterFormSelect);
            this.tabPageSelect.Location = new System.Drawing.Point(4, 25);
            this.tabPageSelect.Name = "tabPageSelect";
            this.tabPageSelect.Size = new System.Drawing.Size(227, 325);
            this.tabPageSelect.TabIndex = 1;
            this.tabPageSelect.Text = "by Selects";
            // 
            // subFormFilterFormSelect
            // 
            this.subFormFilterFormSelect.Dock = System.Windows.Forms.DockStyle.Fill;
            this.subFormFilterFormSelect.Location = new System.Drawing.Point(0, 0);
            this.subFormFilterFormSelect.MinimumSize = new System.Drawing.Size(227, 322);
            this.subFormFilterFormSelect.Name = "subFormFilterFormSelect";
            this.subFormFilterFormSelect.Size = new System.Drawing.Size(227, 325);
            this.subFormFilterFormSelect.TabIndex = 0;
            this.subFormFilterFormSelect.Load += new System.EventHandler(this.subFormFilterFormSelect_Load);
            // 
            // panel1
            // 
            this.panel1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.panel1.Location = new System.Drawing.Point(11, 86);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(231, 4);
            this.panel1.TabIndex = 79;
            // 
            // subFormFilterFormPreset
            // 
            this.subFormFilterFormPreset.Location = new System.Drawing.Point(3, 3);
            this.subFormFilterFormPreset.MinimumSize = new System.Drawing.Size(245, 45);
            this.subFormFilterFormPreset.Name = "subFormFilterFormPreset";
            this.subFormFilterFormPreset.Size = new System.Drawing.Size(245, 45);
            this.subFormFilterFormPreset.TabIndex = 80;
            // 
            // SubFormFilterForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.subFormFilterFormPreset);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.labelTitle);
            this.Controls.Add(this.labelForSort);
            this.Controls.Add(this.tabControlFilter);
            this.Controls.Add(this.comboBoxSortOrder);
            this.Controls.Add(this.comboBoxSortColumn);
            this.Controls.Add(this.labelForSortOrder);
            this.Controls.Add(this.textBoxTitle);
            this.Controls.Add(this.buttonFilter);
            this.Controls.Add(this.buttonReset);
            this.Name = "SubFormFilterForm";
            this.Size = new System.Drawing.Size(251, 540);
            this.Load += new System.EventHandler(this.SubFormFilterForm_Load);
            this.tabControlFilter.ResumeLayout(false);
            this.tabPageTags.ResumeLayout(false);
            this.tabPageSelect.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonReset;
        private System.Windows.Forms.Button buttonFilter;
        private System.Windows.Forms.TextBox textBoxTitle;
        private System.Windows.Forms.Label labelTitle;
        private System.Windows.Forms.Label labelForSortOrder;
        private System.Windows.Forms.ComboBox comboBoxSortColumn;
        private System.Windows.Forms.Label labelForSort;
        private System.Windows.Forms.ComboBox comboBoxSortOrder;
        private System.Windows.Forms.TabControl tabControlFilter;
        private System.Windows.Forms.TabPage tabPageTags;
        private System.Windows.Forms.TabPage tabPageSelect;
        private System.Windows.Forms.Panel panel1;
        private SubFormFilterFormPreset subFormFilterFormPreset;
        private SubFormFilterFormTag subFormFilterFormCriteria;
        private SubForms.SubFormFilterFormSelect subFormFilterFormSelect;
    }
}
