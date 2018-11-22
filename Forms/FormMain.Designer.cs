namespace MyVideoExplorer
{
    partial class FormMain
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            this.splitContainerFolderFile = new System.Windows.Forms.SplitContainer();
            this.splitContainerFilterFolder = new System.Windows.Forms.SplitContainer();
            this.splitContainerFilterProgress = new System.Windows.Forms.SplitContainer();
            this.subFormFilterForm = new MyVideoExplorer.SubFormFilterForm();
            this.subFormProgressMain = new MyVideoExplorer.SubFormProgress();
            this.splitContainerVideosFiles = new System.Windows.Forms.SplitContainer();
            this.subFormListView = new MyVideoExplorer.SubFormListView();
            this.subFormFileList = new MyVideoExplorer.SubFormFileList();
            this.splitContainerFileImage = new System.Windows.Forms.SplitContainer();
            this.subFormVideoForm = new MyVideoExplorer.SubFormVideoForm();
            this.button1 = new System.Windows.Forms.Button();
            this.subFormVideoImage = new MyVideoExplorer.SubFormVideoImage();
            this.imageListFolderFile = new System.Windows.Forms.ImageList(this.components);
            this.menuStripMain = new System.Windows.Forms.MenuStrip();
            this.toolStripMenuItemFile = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemExit = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemTools = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemSources = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemSync = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemOptions = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemView = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemDetails = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemGallery = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemHelp = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItemAbout = new System.Windows.Forms.ToolStripMenuItem();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerFolderFile)).BeginInit();
            this.splitContainerFolderFile.Panel1.SuspendLayout();
            this.splitContainerFolderFile.Panel2.SuspendLayout();
            this.splitContainerFolderFile.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerFilterFolder)).BeginInit();
            this.splitContainerFilterFolder.Panel1.SuspendLayout();
            this.splitContainerFilterFolder.Panel2.SuspendLayout();
            this.splitContainerFilterFolder.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerFilterProgress)).BeginInit();
            this.splitContainerFilterProgress.Panel1.SuspendLayout();
            this.splitContainerFilterProgress.Panel2.SuspendLayout();
            this.splitContainerFilterProgress.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerVideosFiles)).BeginInit();
            this.splitContainerVideosFiles.Panel1.SuspendLayout();
            this.splitContainerVideosFiles.Panel2.SuspendLayout();
            this.splitContainerVideosFiles.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerFileImage)).BeginInit();
            this.splitContainerFileImage.Panel1.SuspendLayout();
            this.splitContainerFileImage.Panel2.SuspendLayout();
            this.splitContainerFileImage.SuspendLayout();
            this.menuStripMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitContainerFolderFile
            // 
            this.splitContainerFolderFile.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerFolderFile.Location = new System.Drawing.Point(0, 31);
            this.splitContainerFolderFile.Name = "splitContainerFolderFile";
            // 
            // splitContainerFolderFile.Panel1
            // 
            this.splitContainerFolderFile.Panel1.Controls.Add(this.splitContainerFilterFolder);
            // 
            // splitContainerFolderFile.Panel2
            // 
            this.splitContainerFolderFile.Panel2.Controls.Add(this.splitContainerFileImage);
            this.splitContainerFolderFile.Size = new System.Drawing.Size(1226, 566);
            this.splitContainerFolderFile.SplitterDistance = 475;
            this.splitContainerFolderFile.TabIndex = 0;
            // 
            // splitContainerFilterFolder
            // 
            this.splitContainerFilterFolder.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerFilterFolder.FixedPanel = System.Windows.Forms.FixedPanel.Panel1;
            this.splitContainerFilterFolder.IsSplitterFixed = true;
            this.splitContainerFilterFolder.Location = new System.Drawing.Point(0, 0);
            this.splitContainerFilterFolder.Name = "splitContainerFilterFolder";
            // 
            // splitContainerFilterFolder.Panel1
            // 
            this.splitContainerFilterFolder.Panel1.Controls.Add(this.splitContainerFilterProgress);
            this.splitContainerFilterFolder.Panel1MinSize = 160;
            // 
            // splitContainerFilterFolder.Panel2
            // 
            this.splitContainerFilterFolder.Panel2.Controls.Add(this.splitContainerVideosFiles);
            this.splitContainerFilterFolder.Size = new System.Drawing.Size(475, 566);
            this.splitContainerFilterFolder.SplitterDistance = 250;
            this.splitContainerFilterFolder.TabIndex = 0;
            // 
            // splitContainerFilterProgress
            // 
            this.splitContainerFilterProgress.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerFilterProgress.Location = new System.Drawing.Point(0, 0);
            this.splitContainerFilterProgress.Name = "splitContainerFilterProgress";
            this.splitContainerFilterProgress.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainerFilterProgress.Panel1
            // 
            this.splitContainerFilterProgress.Panel1.Controls.Add(this.subFormFilterForm);
            // 
            // splitContainerFilterProgress.Panel2
            // 
            this.splitContainerFilterProgress.Panel2.Controls.Add(this.subFormProgressMain);
            this.splitContainerFilterProgress.Size = new System.Drawing.Size(250, 566);
            this.splitContainerFilterProgress.SplitterDistance = 500;
            this.splitContainerFilterProgress.TabIndex = 1;
            // 
            // subFormFilterForm
            // 
            this.subFormFilterForm.Dock = System.Windows.Forms.DockStyle.Fill;
            this.subFormFilterForm.Location = new System.Drawing.Point(0, 0);
            this.subFormFilterForm.MinimumSize = new System.Drawing.Size(160, 540);
            this.subFormFilterForm.Name = "subFormFilterForm";
            this.subFormFilterForm.Size = new System.Drawing.Size(250, 540);
            this.subFormFilterForm.TabIndex = 0;
            // 
            // subFormProgressMain
            // 
            this.subFormProgressMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.subFormProgressMain.Location = new System.Drawing.Point(0, 0);
            this.subFormProgressMain.Margin = new System.Windows.Forms.Padding(0);
            this.subFormProgressMain.MinimumSize = new System.Drawing.Size(160, 60);
            this.subFormProgressMain.Name = "subFormProgressMain";
            this.subFormProgressMain.Size = new System.Drawing.Size(250, 62);
            this.subFormProgressMain.TabIndex = 1;
            // 
            // splitContainerVideosFiles
            // 
            this.splitContainerVideosFiles.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerVideosFiles.Location = new System.Drawing.Point(0, 0);
            this.splitContainerVideosFiles.Name = "splitContainerVideosFiles";
            this.splitContainerVideosFiles.Orientation = System.Windows.Forms.Orientation.Horizontal;
            // 
            // splitContainerVideosFiles.Panel1
            // 
            this.splitContainerVideosFiles.Panel1.Controls.Add(this.subFormListView);
            // 
            // splitContainerVideosFiles.Panel2
            // 
            this.splitContainerVideosFiles.Panel2.Controls.Add(this.subFormFileList);
            this.splitContainerVideosFiles.Size = new System.Drawing.Size(221, 566);
            this.splitContainerVideosFiles.SplitterDistance = 400;
            this.splitContainerVideosFiles.TabIndex = 0;
            // 
            // subFormListView
            // 
            this.subFormListView.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.subFormListView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.subFormListView.Location = new System.Drawing.Point(0, 0);
            this.subFormListView.MinimumSize = new System.Drawing.Size(240, 400);
            this.subFormListView.Name = "subFormListView";
            this.subFormListView.Size = new System.Drawing.Size(240, 400);
            this.subFormListView.TabIndex = 1;
            // 
            // subFormFileList
            // 
            this.subFormFileList.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.subFormFileList.Dock = System.Windows.Forms.DockStyle.Fill;
            this.subFormFileList.Location = new System.Drawing.Point(0, 0);
            this.subFormFileList.MinimumSize = new System.Drawing.Size(240, 200);
            this.subFormFileList.Name = "subFormFileList";
            this.subFormFileList.Size = new System.Drawing.Size(240, 200);
            this.subFormFileList.TabIndex = 0;
            // 
            // splitContainerFileImage
            // 
            this.splitContainerFileImage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainerFileImage.Location = new System.Drawing.Point(0, 0);
            this.splitContainerFileImage.Name = "splitContainerFileImage";
            // 
            // splitContainerFileImage.Panel1
            // 
            this.splitContainerFileImage.Panel1.Controls.Add(this.subFormVideoForm);
            this.splitContainerFileImage.Panel1.Controls.Add(this.button1);
            // 
            // splitContainerFileImage.Panel2
            // 
            this.splitContainerFileImage.Panel2.Controls.Add(this.subFormVideoImage);
            this.splitContainerFileImage.Size = new System.Drawing.Size(747, 566);
            this.splitContainerFileImage.SplitterDistance = 417;
            this.splitContainerFileImage.TabIndex = 3;
            // 
            // subFormVideoForm
            // 
            this.subFormVideoForm.Dock = System.Windows.Forms.DockStyle.Fill;
            this.subFormVideoForm.Location = new System.Drawing.Point(0, 0);
            this.subFormVideoForm.MinimumSize = new System.Drawing.Size(350, 600);
            this.subFormVideoForm.Name = "subFormVideoForm";
            this.subFormVideoForm.Size = new System.Drawing.Size(417, 600);
            this.subFormVideoForm.TabIndex = 4;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(347, 482);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "button1";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // subFormVideoImage
            // 
            this.subFormVideoImage.Dock = System.Windows.Forms.DockStyle.Fill;
            this.subFormVideoImage.Location = new System.Drawing.Point(0, 0);
            this.subFormVideoImage.MinimumSize = new System.Drawing.Size(240, 600);
            this.subFormVideoImage.Name = "subFormVideoImage";
            this.subFormVideoImage.Size = new System.Drawing.Size(326, 600);
            this.subFormVideoImage.TabIndex = 0;
            this.subFormVideoImage.Load += new System.EventHandler(this.subFormVideoImage_Load);
            // 
            // imageListFolderFile
            // 
            this.imageListFolderFile.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("imageListFolderFile.ImageStream")));
            this.imageListFolderFile.TransparentColor = System.Drawing.Color.Transparent;
            this.imageListFolderFile.Images.SetKeyName(0, "Opened.png");
            this.imageListFolderFile.Images.SetKeyName(1, "Closed.png");
            this.imageListFolderFile.Images.SetKeyName(2, "Video.png");
            this.imageListFolderFile.Images.SetKeyName(3, "Music.png");
            this.imageListFolderFile.Images.SetKeyName(4, "Pictures.png");
            this.imageListFolderFile.Images.SetKeyName(5, "Program_Group.png");
            this.imageListFolderFile.Images.SetKeyName(6, "Scheduled_Tasks.png");
            this.imageListFolderFile.Images.SetKeyName(7, "My_Computer.png");
            this.imageListFolderFile.Images.SetKeyName(8, "Home.png");
            this.imageListFolderFile.Images.SetKeyName(9, "RecycleBin_Empty.png");
            this.imageListFolderFile.Images.SetKeyName(10, "Default.png");
            this.imageListFolderFile.Images.SetKeyName(11, "Default_Document.png");
            this.imageListFolderFile.Images.SetKeyName(12, "TextDocument.png");
            this.imageListFolderFile.Images.SetKeyName(13, "Video.png");
            this.imageListFolderFile.Images.SetKeyName(14, "SystemConfiguration.png");
            this.imageListFolderFile.Images.SetKeyName(15, "Administrative_Tools.png");
            this.imageListFolderFile.Images.SetKeyName(16, "URL_History.png");
            this.imageListFolderFile.Images.SetKeyName(17, "Favorite.png");
            this.imageListFolderFile.Images.SetKeyName(18, "Search.png");
            this.imageListFolderFile.Images.SetKeyName(19, "Help.png");
            // 
            // menuStripMain
            // 
            this.menuStripMain.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItemFile,
            this.toolStripMenuItemTools,
            this.toolStripMenuItemView,
            this.toolStripMenuItemHelp});
            this.menuStripMain.Location = new System.Drawing.Point(0, 0);
            this.menuStripMain.Name = "menuStripMain";
            this.menuStripMain.Size = new System.Drawing.Size(1226, 31);
            this.menuStripMain.TabIndex = 1;
            this.menuStripMain.Text = "menuStripMain";
            // 
            // toolStripMenuItemFile
            // 
            this.toolStripMenuItemFile.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItemExit});
            this.toolStripMenuItemFile.Name = "toolStripMenuItemFile";
            this.toolStripMenuItemFile.Size = new System.Drawing.Size(47, 27);
            this.toolStripMenuItemFile.Text = "&File";
            // 
            // toolStripMenuItemExit
            // 
            this.toolStripMenuItemExit.Name = "toolStripMenuItemExit";
            this.toolStripMenuItemExit.Size = new System.Drawing.Size(107, 28);
            this.toolStripMenuItemExit.Text = "E&xit";
            this.toolStripMenuItemExit.Click += new System.EventHandler(this.toolStripMenuItemExit_Click);
            // 
            // toolStripMenuItemTools
            // 
            this.toolStripMenuItemTools.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItemSources,
            this.toolStripMenuItemSync,
            this.toolStripMenuItemOptions});
            this.toolStripMenuItemTools.Name = "toolStripMenuItemTools";
            this.toolStripMenuItemTools.Size = new System.Drawing.Size(62, 27);
            this.toolStripMenuItemTools.Text = "Tools";
            // 
            // toolStripMenuItemSources
            // 
            this.toolStripMenuItemSources.Name = "toolStripMenuItemSources";
            this.toolStripMenuItemSources.Size = new System.Drawing.Size(188, 28);
            this.toolStripMenuItemSources.Text = "Sources";
            this.toolStripMenuItemSources.Click += new System.EventHandler(this.toolStripMenuItemSources_Click);
            // 
            // toolStripMenuItemSync
            // 
            this.toolStripMenuItemSync.Name = "toolStripMenuItemSync";
            this.toolStripMenuItemSync.Size = new System.Drawing.Size(188, 28);
            this.toolStripMenuItemSync.Text = "Sync";
            this.toolStripMenuItemSync.Click += new System.EventHandler(this.toolStripMenuItemSync_Click);
            // 
            // toolStripMenuItemOptions
            // 
            this.toolStripMenuItemOptions.Name = "toolStripMenuItemOptions";
            this.toolStripMenuItemOptions.Size = new System.Drawing.Size(188, 28);
            this.toolStripMenuItemOptions.Text = "&Options";
            this.toolStripMenuItemOptions.Click += new System.EventHandler(this.toolStripMenuItemOptions_Click);
            // 
            // toolStripMenuItemView
            // 
            this.toolStripMenuItemView.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItemDetails,
            this.toolStripMenuItemGallery});
            this.toolStripMenuItemView.Name = "toolStripMenuItemView";
            this.toolStripMenuItemView.Size = new System.Drawing.Size(58, 27);
            this.toolStripMenuItemView.Text = "View";
            // 
            // toolStripMenuItemDetails
            // 
            this.toolStripMenuItemDetails.Name = "toolStripMenuItemDetails";
            this.toolStripMenuItemDetails.Size = new System.Drawing.Size(132, 28);
            this.toolStripMenuItemDetails.Text = "Details";
            this.toolStripMenuItemDetails.Click += new System.EventHandler(this.toolStripMenuItemDetails_Click);
            // 
            // toolStripMenuItemGallery
            // 
            this.toolStripMenuItemGallery.Name = "toolStripMenuItemGallery";
            this.toolStripMenuItemGallery.Size = new System.Drawing.Size(132, 28);
            this.toolStripMenuItemGallery.Text = "Gallery";
            this.toolStripMenuItemGallery.Click += new System.EventHandler(this.toolStripMenuItemGallery_Click);
            // 
            // toolStripMenuItemHelp
            // 
            this.toolStripMenuItemHelp.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItemAbout});
            this.toolStripMenuItemHelp.Name = "toolStripMenuItemHelp";
            this.toolStripMenuItemHelp.Size = new System.Drawing.Size(57, 27);
            this.toolStripMenuItemHelp.Text = "Help";
            // 
            // toolStripMenuItemAbout
            // 
            this.toolStripMenuItemAbout.Name = "toolStripMenuItemAbout";
            this.toolStripMenuItemAbout.Size = new System.Drawing.Size(139, 28);
            this.toolStripMenuItemAbout.Text = "&About...";
            this.toolStripMenuItemAbout.Click += new System.EventHandler(this.toolStripMenuItemAbout_Click);
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1226, 597);
            this.Controls.Add(this.splitContainerFolderFile);
            this.Controls.Add(this.menuStripMain);
            this.Name = "FormMain";
            this.Text = "MyVideoExplorer";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FormMain_FormClosing);
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FormMain_FormClosed);
            this.Load += new System.EventHandler(this.FormMain_Load);
            this.Shown += new System.EventHandler(this.FormMain_Shown);
            this.ResizeEnd += new System.EventHandler(this.FormMain_ResizeEnd);
            this.Resize += new System.EventHandler(this.FormMain_Resize);
            this.splitContainerFolderFile.Panel1.ResumeLayout(false);
            this.splitContainerFolderFile.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerFolderFile)).EndInit();
            this.splitContainerFolderFile.ResumeLayout(false);
            this.splitContainerFilterFolder.Panel1.ResumeLayout(false);
            this.splitContainerFilterFolder.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerFilterFolder)).EndInit();
            this.splitContainerFilterFolder.ResumeLayout(false);
            this.splitContainerFilterProgress.Panel1.ResumeLayout(false);
            this.splitContainerFilterProgress.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerFilterProgress)).EndInit();
            this.splitContainerFilterProgress.ResumeLayout(false);
            this.splitContainerVideosFiles.Panel1.ResumeLayout(false);
            this.splitContainerVideosFiles.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerVideosFiles)).EndInit();
            this.splitContainerVideosFiles.ResumeLayout(false);
            this.splitContainerFileImage.Panel1.ResumeLayout(false);
            this.splitContainerFileImage.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainerFileImage)).EndInit();
            this.splitContainerFileImage.ResumeLayout(false);
            this.menuStripMain.ResumeLayout(false);
            this.menuStripMain.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainerFolderFile;
        private System.Windows.Forms.ImageList imageListFolderFile;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.SplitContainer splitContainerFileImage;
        private SubFormVideoForm subFormVideoForm;
        private System.Windows.Forms.SplitContainer splitContainerFilterFolder;
        private System.Windows.Forms.SplitContainer splitContainerVideosFiles;
        private SubFormFilterForm subFormFilterForm;
        private SubFormFileList subFormFileList;
        private SubFormVideoImage subFormVideoImage;
        private System.Windows.Forms.MenuStrip menuStripMain;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemFile;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemExit;
        private SubFormProgress subFormProgressMain;
        private System.Windows.Forms.SplitContainer splitContainerFilterProgress;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemHelp;
        private SubFormListView subFormListView;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemTools;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemOptions;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemAbout;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemView;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemDetails;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemGallery;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemSources;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItemSync;
    }
}

