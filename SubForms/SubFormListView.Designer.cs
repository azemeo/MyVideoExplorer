namespace MyVideoExplorer
{
    partial class SubFormListView
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
            this.components = new System.ComponentModel.Container();
            this.listView = new System.Windows.Forms.ListView();
            this.columnHeaderTitle = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeaderYear = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.contextMenuStrip = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItemPlay = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemOpenFolder = new System.Windows.Forms.ToolStripMenuItem();
            this.contextMenuStrip.SuspendLayout();
            this.SuspendLayout();
            // 
            // listView
            // 
            this.listView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeaderTitle,
            this.columnHeaderYear});
            this.listView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.listView.HideSelection = false;
            this.listView.Location = new System.Drawing.Point(0, 0);
            this.listView.Name = "listView";
            this.listView.Size = new System.Drawing.Size(240, 400);
            this.listView.TabIndex = 0;
            this.listView.UseCompatibleStateImageBehavior = false;
            this.listView.View = System.Windows.Forms.View.Details;
            this.listView.ColumnClick += new System.Windows.Forms.ColumnClickEventHandler(this.listView_ColumnClick);
            this.listView.SelectedIndexChanged += new System.EventHandler(this.listView_SelectedIndexChanged);
            this.listView.DoubleClick += new System.EventHandler(this.listView_DoubleClick);
            this.listView.MouseClick += new System.Windows.Forms.MouseEventHandler(this.listView_MouseClick);
            // 
            // columnHeaderTitle
            // 
            this.columnHeaderTitle.Text = "Title";
            this.columnHeaderTitle.Width = 235;
            // 
            // columnHeaderYear
            // 
            this.columnHeaderYear.Text = "Year";
            // 
            // contextMenuStrip
            // 
            this.contextMenuStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItemPlay,
            this.toolStripMenuItemOpenFolder});
            this.contextMenuStrip.Name = "contextMenuStrip";
            this.contextMenuStrip.Size = new System.Drawing.Size(175, 60);
            // 
            // toolStripMenuItemPlay
            // 
            this.toolStripMenuItemPlay.Name = "toolStripMenuItemPlay";
            this.toolStripMenuItemPlay.Size = new System.Drawing.Size(174, 28);
            this.toolStripMenuItemPlay.Text = "Play";
            this.toolStripMenuItemPlay.Click += new System.EventHandler(this.toolStripMenuItemPlay_Click);
            // 
            // toolStripMenuItemOpenFolder
            // 
            this.toolStripMenuItemOpenFolder.Name = "toolStripMenuItemOpenFolder";
            this.toolStripMenuItemOpenFolder.Size = new System.Drawing.Size(174, 28);
            this.toolStripMenuItemOpenFolder.Text = "Open Folder";
            this.toolStripMenuItemOpenFolder.Click += new System.EventHandler(this.toolStripMenuItemOpenFolder_Click);
            // 
            // SubFormListView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.Controls.Add(this.listView);
            this.Name = "SubFormListView";
            this.Size = new System.Drawing.Size(240, 400);
            this.Load += new System.EventHandler(this.SubFormListView_Load);
            this.contextMenuStrip.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ListView listView;
        private System.Windows.Forms.ColumnHeader columnHeaderTitle;
        private System.Windows.Forms.ColumnHeader columnHeaderYear;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemPlay;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemOpenFolder;
    }
}
