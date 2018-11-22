using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.IO;

namespace MyVideoExplorer
{


    public partial class FormMain : Form
    {
        public SubFormGallery subFormGallery;
        public LoadVideos loadVideos;

        FormWindowState LastWindowState = FormWindowState.Minimized;

        public FormMain()
        {

            InitializeComponent();

            MyLog.Add("========================================== Open application");

            MyFile.SetAppInfo();

            // filter form Filter button
            subFormFilterForm.filterForm_filterVideos += new EventHandler(subFormFilterForm_filterVideos);

            // list item clicked
            subFormListView.listView_selectedIndexChanged += new EventHandler(SubFormListView_selectedIndexChanged);

            // file list double clicked
            subFormFileList.fileList_DoubleClicked += new EventHandler(SubFormFileList_doubleClicked);

            // load videos done
            loadVideos = new LoadVideos();
            loadVideos.loadVideos_Completed += new EventHandler(LoadVideos_Completed);

            // add browse view
            subFormGallery = new SubFormGallery();
            this.Controls.Add(subFormGallery);
            // may not need all controls, but mimicing list view for now
            subFormGallery.AddAccessToSubForms(subFormFilterForm, subFormFileList, subFormVideoForm, subFormVideoImage, subFormProgressMain);
            subFormGallery.Hide();

            // so user controls can talk to other user controls
            subFormListView.AddAccessToSubForms(subFormFilterForm, subFormFileList, subFormVideoForm, subFormVideoImage, subFormProgressMain);
            subFormFilterForm.AddAccessToSubForms(subFormListView, subFormGallery, subFormVideoForm, subFormProgressMain);
            subFormFileList.AddAccessToSubForms(subFormListView, subFormVideoForm, subFormVideoImage, subFormProgressMain);

            // mouse wheelz
            this.MouseWheel += new MouseEventHandler(FormMain_MouseWheel);

        }

        private void FormMain_Load(object sender, EventArgs e)
        {

            // load settings
            if (!Config.Load(this))
            {
                this.CenterToScreen();
            }


            // min size needs to be larger than panel sizes, too account for window, panel borders
            // panel sizes are 1000 x 600
            this.MinimumSize = new Size(1200, 700);


            subFormFileList.AutoSize = false;
            subFormFileList.Dock = DockStyle.Fill;

            subFormFilterForm.AutoSize = false;
            subFormFilterForm.Dock = DockStyle.Fill;

            subFormListView.AutoSize = false;
            subFormListView.Dock = DockStyle.Fill;

            subFormProgressMain.AutoSize = false;
            subFormProgressMain.Dock = DockStyle.Fill;

            subFormVideoForm.AutoSize = false;
            subFormVideoForm.Dock = DockStyle.Fill;

            subFormVideoImage.AutoSize = false;
            subFormVideoImage.Dock = DockStyle.Fill;


            // NOTE: if user controls are not re-sizeing or showing up correctly based on app width/height
            // adjust split containers or user control width/height .. add up the dimensions add pad a tad .. math


            // main contianer; folder left, file right
            splitContainerFolderFile.Orientation = Orientation.Vertical;
            splitContainerFolderFile.Dock = DockStyle.Fill;
            splitContainerFolderFile.SplitterDistance = 415;
            splitContainerFolderFile.BorderStyle = BorderStyle.FixedSingle;
            splitContainerFolderFile.Panel1MinSize = 515;
            splitContainerFolderFile.Panel2MinSize = 615;
            // splitContainerFolderFile.Panel1.BackColor = Color.LightCyan;
            // splitContainerFolderFile.Panel2.BackColor = Color.LightGreen;

            // file panel
            // vertical; file contains file details is fixed
            splitContainerFileImage.Orientation = Orientation.Vertical;
            splitContainerFileImage.Dock = DockStyle.Fill;
            splitContainerFileImage.FixedPanel = FixedPanel.Panel1; // file details
            splitContainerFileImage.IsSplitterFixed = true;
            splitContainerFileImage.SplitterDistance = 350;
            splitContainerFileImage.Panel1MinSize = 350;
            splitContainerFileImage.Panel2MinSize = 240;
            // splitContainerFileImage.Panel1.BackColor = Color.LightCyan;
            // splitContainerFileImage.Panel2.BackColor = Color.LightGreen;


            // filter folder
            // Vertical; filter is fixed, folder is expandable
            splitContainerFilterFolder.Orientation = Orientation.Vertical;
            splitContainerFilterFolder.Dock = DockStyle.Fill;
            splitContainerFilterFolder.FixedPanel = FixedPanel.Panel1; // filter
            splitContainerFilterFolder.SplitterDistance = 250;
            splitContainerFilterFolder.Panel1MinSize = 250;
            splitContainerFilterFolder.Panel2MinSize = 250; 
            // splitContainerFilterFolder.Panel1.BackColor = Color.LightCyan;
            // splitContainerFilterFolder.Panel2.BackColor = Color.LightGreen;

            // folder list
            // Horizontal; folder is expandabe, list is fixed
            splitContainerVideosFiles.Orientation = Orientation.Horizontal;
            splitContainerVideosFiles.Dock = DockStyle.Fill;
            splitContainerVideosFiles.FixedPanel = FixedPanel.Panel2; // files
            splitContainerVideosFiles.IsSplitterFixed = true;
            splitContainerVideosFiles.SplitterDistance = (splitContainerVideosFiles.Height - 200);
            splitContainerVideosFiles.Panel1MinSize = 400;
            splitContainerVideosFiles.Panel2MinSize = 200;
            // splitContainerVideosFiles.Panel1.BackColor = Color.LightCyan;
            // splitContainerVideosFiles.Panel2.BackColor = Color.LightGreen;

            // filter panel
            // horizontal; search is fixed, folder is expandable
            splitContainerFilterProgress.Orientation = Orientation.Horizontal;
            splitContainerFilterProgress.Dock = DockStyle.Fill;
            splitContainerFilterProgress.FixedPanel = FixedPanel.Panel2; // progress
            splitContainerFilterProgress.IsSplitterFixed = true;
            splitContainerFilterProgress.SplitterDistance = (splitContainerFilterProgress.Height - 65);
            splitContainerFilterProgress.Panel1MinSize = 540;
            splitContainerFilterProgress.Panel2MinSize = 65;
            // splitContainerFilterProgress.Panel1.BackColor = Color.BlanchedAlmond;
            // splitContainerFilterProgress.Panel2.BackColor = Color.BurlyWood;

            toolStripMenuItemGallery.Checked = false;
            toolStripMenuItemDetails.Checked = true;

            if (!Config.settings.gallery.enable)
            {
                toolStripMenuItemGallery.Enabled = false;
            }

            subFormListView.ResizeColumns();
            subFormFileList.ResizeColumns();
        }

        // after form loaded
        private void FormMain_Shown(object sender, EventArgs e)
        {
            MyFormField.HighlightFormFieldsOnFocus(this);

            loadVideos.AddAccessToSubForms(subFormListView, subFormGallery, subFormVideoForm, subFormFilterForm, subFormProgressMain);


            Application.DoEvents(); // meh



            // ensure required app dirs exist
            MyFile.EnsureDirectoryExists(@"cache");
            MyFile.EnsureDirectoryExists(@"cache\gallery");
            MyFile.EnsureDirectoryExists(@"config");
            MyFile.EnsureDirectoryExists(@"data");
            MyFile.EnsureDirectoryExists(@"filters");
            MyFile.EnsureDirectoryExists(@"libs");
            MyFile.EnsureDirectoryExists(@"libs\ffmpeg\bin");
            MyFile.EnsureDirectoryExists(@"logs");            
            MyFile.EnsureDirectoryExists(@"stats");
            MyFile.EnsureDirectoryExists(@"sync");



            if (Config.settings.sources.Count == 0)
            {
                MessageBox.Show("No Video Sources found. Add some and Scan..");
                ShowFormSources();
                return;
            }

            if (ListVideoInfo.Load())
            {
                loadVideos.FilterListView();
            }
            else
            { 
                loadVideos.LoadFromDisk();
            }
            
            
        }

        private void FormMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            MyLog.Add("========================================== Closed application");
        }

        private void FormMain_FormClosing(object sender, FormClosingEventArgs e)
        {

            loadVideos.AbortBackgroundWorkers();

            // meh
            Application.DoEvents();

            // save settings
            if (!Config.Save(this))
            {

            }

            // save video sources
            if (!ListVideoInfo.Save())
            {

            }

        }

        private void FormMain_MouseWheel(object sender, MouseEventArgs e)
        {

        }


        protected void SubFormListView_selectedIndexChanged(object sender, EventArgs e)
        {

            ListViewItem selectedItem = (ListViewItem)sender;
            string title = selectedItem.SubItems[0].Text;
            string year = selectedItem.SubItems[1].Text;
            string id = title + " - " + year;

            // called in SubFormListView .. so event not really needed .. but leaving for now
            // LoadVideoForm(selectedItem);
        }

        protected void SubFormFileList_doubleClicked(object sender, EventArgs e)
        {
            // called in SubFormFileList .. so event not really needed .. but leaving for now
        }

        private void subFormFilterForm_filterVideos(object sender, EventArgs e)
        {
            // called in SubFormFilterForm .. so event not really needed .. but leaving for now
        }

        private void subFormFilterForm_rescanVideos(object sender, EventArgs e)
        {
            // called in SubFormFilterForm .. so event not really needed .. but leaving for now
        }

        private void subFormVideoImage_Load(object sender, EventArgs e)
        {

        }

        private void FormMain_Resize(object sender, EventArgs e)
        {
            // called on max/min .. and every mouse movement of resize
            // MyLog.Add("FormMain_Resize");

            // When window state changes
            if (WindowState != LastWindowState)
            {
                LastWindowState = WindowState;

                if (WindowState == FormWindowState.Maximized)
                {
                    // Maximized!
                }
                if (WindowState == FormWindowState.Normal)
                {
                    // Restored!
                }
            }

            subFormListView.ResizeColumns();
            subFormFileList.ResizeColumns();


            LastWindowState = WindowState;
        }

        private void FormMain_ResizeEnd(object sender, EventArgs e)
        {
            // not called on min/max .. but only called once if doing resize
            // MyLog.Add("FormMain_ResizeEnd");

            subFormListView.ResizeColumns();
            subFormFileList.ResizeColumns();
        }





        //
        // start menu events
        //

        private void toolStripMenuItemExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void toolStripMenuItemOptions_Click(object sender, EventArgs e)
        {
            ShowFormOptions();
        }

        private void toolStripMenuItemSync_Click(object sender, EventArgs e)
        {
            ShowFormSync();
        }

        private void toolStripMenuItemSources_Click(object sender, EventArgs e)
        {
            ShowFormSources();
        }

        private void toolStripMenuItemAbout_Click(object sender, EventArgs e)
        {
            // TODO make into a user control about box
            string about = Config.GetAboutInfo();

            MessageBox.Show(about);
        }

        private void toolStripMenuItemDetails_Click(object sender, EventArgs e)
        {
            toolStripMenuItemGallery.Checked = false;
            toolStripMenuItemDetails.Checked = true;

            subFormGallery.Hide();
            // subFormGallery.SendToBack();
        }

        private void toolStripMenuItemGallery_Click(object sender, EventArgs e)
        {
            toolStripMenuItemGallery.Checked = true;
            toolStripMenuItemDetails.Checked = false;

            int left = splitContainerFilterFolder.Panel2.Left;
            int top = menuStripMain.Height;
            int width = splitContainerFolderFile.Width - splitContainerFilterFolder.Panel1.Width;
            int height = splitContainerFilterFolder.Height + 1;
            subFormGallery.Left = left;
            subFormGallery.Top = top;
            subFormGallery.Height = height;
            subFormGallery.Width = width;
            // subFormGallery.BackColor = Color.Black;
            subFormGallery.Anchor = AnchorStyles.Bottom | AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            subFormGallery.Show();
            subFormGallery.BringToFront();

        }

        public void ShowFormOptions()
        {
            using (FormOptions formOptions = new FormOptions())
            {
                formOptions.StartPosition = FormStartPosition.CenterParent;
                formOptions.ShowDialog(this);

                // save settings
                if (!Config.Save(this))
                {

                }

                if (Config.settings.gallery.enable)
                {
                    toolStripMenuItemGallery.Enabled = true;
                }
                else
                {
                    toolStripMenuItemGallery.Enabled = false;
                }
            }
        }

        public void ShowFormSources()
        {
            using (FormSources formSources = new FormSources())
            {
                formSources.StartPosition = FormStartPosition.CenterParent;
                formSources.ShowDialog(this);

                // save settings
                if (!Config.Save(this))
                {

                }
            }
        }

        public void ShowFormSync()
        {
            using (FormSync formSync = new FormSync())
            {
                formSync.StartPosition = FormStartPosition.CenterParent;
                formSync.ShowDialog(this);

                // save settings
                if (!Config.Save(this))
                {

                }
            }
        }

        //
        // end menu events
        //






        public LoadVideos GetLoadVideos()
        {

            return loadVideos;
        }

        protected void LoadVideos_Completed(object sender, EventArgs e)
        {
            // done oading videos from a scan or filter
        }

        public SubFormListView GetSubFormListView()
        {
            return subFormListView;
        }
        public SubFormGallery GetSubFormGallery()
        {
            return subFormGallery;
        }





    }


}
