namespace MyVideoExplorer
{
    partial class FormSync
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
            this.components = new System.ComponentModel.Container();
            this.subFormProgressSyncUp = new MyVideoExplorer.SubFormProgress();
            this.buttonSyncUp = new System.Windows.Forms.Button();
            this.labelLastSyncUp = new System.Windows.Forms.Label();
            this.labelForLastSyncUp = new System.Windows.Forms.Label();
            this.listViewSyncUp = new System.Windows.Forms.ListView();
            this.columnHeaderIcon = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderQty = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderSize = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.contextMenuStripSyncUp = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItemOpen = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemOpenFolder = new System.Windows.Forms.ToolStripMenuItem();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPageSyncUp = new System.Windows.Forms.TabPage();
            this.tabPageSyncDown = new System.Windows.Forms.TabPage();
            this.contextMenuStripSyncUp.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.tabPageSyncUp.SuspendLayout();
            this.SuspendLayout();
            // 
            // subFormProgressSyncUp
            // 
            this.subFormProgressSyncUp.Location = new System.Drawing.Point(5, 265);
            this.subFormProgressSyncUp.Margin = new System.Windows.Forms.Padding(0);
            this.subFormProgressSyncUp.MinimumSize = new System.Drawing.Size(160, 60);
            this.subFormProgressSyncUp.Name = "subFormProgressSyncUp";
            this.subFormProgressSyncUp.Size = new System.Drawing.Size(238, 65);
            this.subFormProgressSyncUp.TabIndex = 0;
            // 
            // buttonSyncUp
            // 
            this.buttonSyncUp.Location = new System.Drawing.Point(263, 307);
            this.buttonSyncUp.Name = "buttonSyncUp";
            this.buttonSyncUp.Size = new System.Drawing.Size(125, 23);
            this.buttonSyncUp.TabIndex = 1;
            this.buttonSyncUp.Text = "Sync Up";
            this.buttonSyncUp.UseVisualStyleBackColor = true;
            this.buttonSyncUp.Click += new System.EventHandler(this.buttonSyncUp_Click);
            // 
            // labelLastSyncUp
            // 
            this.labelLastSyncUp.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.labelLastSyncUp.Location = new System.Drawing.Point(274, 274);
            this.labelLastSyncUp.Name = "labelLastSyncUp";
            this.labelLastSyncUp.Size = new System.Drawing.Size(101, 22);
            this.labelLastSyncUp.TabIndex = 13;
            this.labelLastSyncUp.Text = "labelLastSyncUp";
            this.labelLastSyncUp.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // labelForLastSyncUp
            // 
            this.labelForLastSyncUp.AutoSize = true;
            this.labelForLastSyncUp.Location = new System.Drawing.Point(281, 254);
            this.labelForLastSyncUp.Name = "labelForLastSyncUp";
            this.labelForLastSyncUp.Size = new System.Drawing.Size(87, 16);
            this.labelForLastSyncUp.TabIndex = 12;
            this.labelForLastSyncUp.Text = "Last Sync Up";
            // 
            // listViewSyncUp
            // 
            this.listViewSyncUp.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeaderIcon,
            this.columnHeaderName,
            this.columnHeaderQty,
            this.columnHeaderSize});
            this.listViewSyncUp.ContextMenuStrip = this.contextMenuStripSyncUp;
            this.listViewSyncUp.Location = new System.Drawing.Point(4, 6);
            this.listViewSyncUp.Name = "listViewSyncUp";
            this.listViewSyncUp.Size = new System.Drawing.Size(403, 245);
            this.listViewSyncUp.TabIndex = 16;
            this.listViewSyncUp.UseCompatibleStateImageBehavior = false;
            this.listViewSyncUp.View = System.Windows.Forms.View.Details;
            // 
            // columnHeaderIcon
            // 
            this.columnHeaderIcon.Text = "   ";
            this.columnHeaderIcon.Width = 30;
            // 
            // columnHeaderName
            // 
            this.columnHeaderName.Text = "Name";
            this.columnHeaderName.Width = 220;
            // 
            // columnHeaderQty
            // 
            this.columnHeaderQty.Text = "Qty";
            this.columnHeaderQty.Width = 76;
            // 
            // columnHeaderSize
            // 
            this.columnHeaderSize.Text = "Size";
            this.columnHeaderSize.Width = 50;
            // 
            // contextMenuStripSyncUp
            // 
            this.contextMenuStripSyncUp.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItemOpen,
            this.toolStripMenuItemOpenFolder});
            this.contextMenuStripSyncUp.Name = "contextMenuStrip";
            this.contextMenuStripSyncUp.Size = new System.Drawing.Size(175, 60);
            // 
            // toolStripMenuItemOpen
            // 
            this.toolStripMenuItemOpen.Name = "toolStripMenuItemOpen";
            this.toolStripMenuItemOpen.Size = new System.Drawing.Size(174, 28);
            this.toolStripMenuItemOpen.Text = "Open";
            this.toolStripMenuItemOpen.Click += new System.EventHandler(this.toolStripMenuItemOpen_Click);
            // 
            // toolStripMenuItemOpenFolder
            // 
            this.toolStripMenuItemOpenFolder.Name = "toolStripMenuItemOpenFolder";
            this.toolStripMenuItemOpenFolder.Size = new System.Drawing.Size(174, 28);
            this.toolStripMenuItemOpenFolder.Text = "Open Folder";
            this.toolStripMenuItemOpenFolder.Click += new System.EventHandler(this.toolStripMenuItemOpenFolder_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPageSyncUp);
            this.tabControl1.Controls.Add(this.tabPageSyncDown);
            this.tabControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabControl1.Location = new System.Drawing.Point(0, 0);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(880, 367);
            this.tabControl1.TabIndex = 17;
            // 
            // tabPageSyncUp
            // 
            this.tabPageSyncUp.Controls.Add(this.listViewSyncUp);
            this.tabPageSyncUp.Controls.Add(this.subFormProgressSyncUp);
            this.tabPageSyncUp.Controls.Add(this.buttonSyncUp);
            this.tabPageSyncUp.Controls.Add(this.labelLastSyncUp);
            this.tabPageSyncUp.Controls.Add(this.labelForLastSyncUp);
            this.tabPageSyncUp.Location = new System.Drawing.Point(4, 25);
            this.tabPageSyncUp.Name = "tabPageSyncUp";
            this.tabPageSyncUp.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageSyncUp.Size = new System.Drawing.Size(872, 338);
            this.tabPageSyncUp.TabIndex = 0;
            this.tabPageSyncUp.Text = "Sync Up";
            this.tabPageSyncUp.UseVisualStyleBackColor = true;
            this.tabPageSyncUp.Click += new System.EventHandler(this.tabPageSyncUp_Click);
            // 
            // tabPageSyncDown
            // 
            this.tabPageSyncDown.Location = new System.Drawing.Point(4, 25);
            this.tabPageSyncDown.Name = "tabPageSyncDown";
            this.tabPageSyncDown.Size = new System.Drawing.Size(872, 338);
            this.tabPageSyncDown.TabIndex = 1;
            this.tabPageSyncDown.Text = "Sync Down";
            this.tabPageSyncDown.UseVisualStyleBackColor = true;
            // 
            // FormSync
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(880, 367);
            this.Controls.Add(this.tabControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "FormSync";
            this.Text = "Sync";
            this.Load += new System.EventHandler(this.FormSync_Load);
            this.contextMenuStripSyncUp.ResumeLayout(false);
            this.tabControl1.ResumeLayout(false);
            this.tabPageSyncUp.ResumeLayout(false);
            this.tabPageSyncUp.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private SubFormProgress subFormProgressSyncUp;
        private System.Windows.Forms.Button buttonSyncUp;
        private System.Windows.Forms.Label labelLastSyncUp;
        private System.Windows.Forms.Label labelForLastSyncUp;
        private System.Windows.Forms.ListView listViewSyncUp;
        private System.Windows.Forms.ColumnHeader columnHeaderIcon;
        private System.Windows.Forms.ColumnHeader columnHeaderName;
        private System.Windows.Forms.ColumnHeader columnHeaderQty;
        private System.Windows.Forms.ColumnHeader columnHeaderSize;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPageSyncUp;
        private System.Windows.Forms.TabPage tabPageSyncDown;
        private System.Windows.Forms.ContextMenuStrip contextMenuStripSyncUp;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemOpen;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemOpenFolder;
    }
}