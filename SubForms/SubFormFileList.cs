using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.IO;
using System.Diagnostics;

namespace MyVideoExplorer
{

    public partial class SubFormFileList : UserControl
    {
        private int nameWidth = 70;
        private int typeWidth = 45;
        private int sizeWidth = 50;
        private ImageList smallImageList = new ImageList();

        public SubFormFileListSort listViewColumnSorter;
        

        // so this user control can update other user controls
        private SubFormListView subFormListView;
        private SubFormVideoForm subFormVideoForm;
        private SubFormVideoImage subFormVideoImage;
        private SubFormProgress subFormProgress;

        public SubFormFileList()
        {
            InitializeComponent();

            // Create an instance of a ListView column sorter and assign it 
            // to the ListView control.
            listViewColumnSorter = new SubFormFileListSort();
            listView.ListViewItemSorter = listViewColumnSorter;
            listView.HideSelection = false;
            listView.MultiSelect = false;
        }

        public void AddAccessToSubForms(SubFormListView subFormListView, SubFormVideoForm subFormVideoForm, SubFormVideoImage subFormVideoImage, SubFormProgress subFormProgress)
        {
            this.subFormListView = subFormListView;
            this.subFormVideoForm = subFormVideoForm;
            this.subFormVideoImage = subFormVideoImage;
            this.subFormProgress = subFormProgress;
        }

        private void SubFormFileList_Load(object sender, EventArgs e)
        {
            this.MinimumSize = new Size(240, 200);

            listView.View = View.Details;
            listView.FullRowSelect = true;
            listView.Sorting = SortOrder.Ascending;
            listView.HideSelection = true; // keep selection highlighted (grey) on blur

            listView.Columns.Clear();
            listView.Columns.Add("Name", nameWidth, HorizontalAlignment.Left);
            listView.Columns.Add("Type", typeWidth, HorizontalAlignment.Center);
            listView.Columns.Add("Size", sizeWidth, HorizontalAlignment.Right);

            listView.SmallImageList = smallImageList;

            // meh .. seems have to use resizing events
            // listView.AutoResizeColumn(0, ColumnHeaderAutoResizeStyle.ColumnContent);

            ResizeColumns();
        }


        private void listView_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            listView.SuspendLayout();

            // Determine if clicked column is already the column that is being sorted.
            if (e.Column == listViewColumnSorter.SortColumnIndex)
            {
                // Reverse the current sort direction for this column.
                if (listViewColumnSorter.SortOrderIndex == SortOrders.ASC)
                {
                    listViewColumnSorter.SortOrderIndex = SortOrders.DESC;
                }
                else
                {
                    listViewColumnSorter.SortOrderIndex = SortOrders.ASC;
                }
            }
            else
            {
                // Set the column number that is to be sorted; default to ascending.
                listViewColumnSorter.SortColumnIndex = e.Column;
                listViewColumnSorter.SortOrderIndex = SortOrders.ASC;
            }

            // Perform the sort with these new sort options.
            listView.Sort();

            ResizeColumns();

            listView.ResumeLayout();
        }


        private void listView_SelectedIndexChanged(object sender, EventArgs e)
        {
            // called on select and unselect

            // ignore unselected
            if (this.listView.SelectedItems.Count == 0)
            {
                return;
            }

            string file = this.listView.SelectedItems[0].Text;
        }

        public event EventHandler fileList_DoubleClicked;
        /// <summary>
        /// launch selected file
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void listView_DoubleClick(object sender, EventArgs e)
        {
            VideoItemFileInfo videoItemFileInfo = (VideoItemFileInfo)listView.SelectedItems[0].Tag;
            if (videoItemFileInfo == null)
            {
                return;
            }

            PlayFile playFile = new PlayFile();
            playFile.AddAccessToSubForms(subFormVideoForm, subFormProgress);

            playFile.Play(videoItemFileInfo.videoInfo, videoItemFileInfo.videoItemFile);

            //bubble the event up
            if (this.fileList_DoubleClicked != null)
            {
                this.fileList_DoubleClicked(sender, e);
            }


        }


        private void listView_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                if (listView.FocusedItem.Bounds.Contains(e.Location) == true)
                {
                    contextMenuStrip.Show(Cursor.Position);
                }
            }
        }

        private void toolStripMenuItemOpenFolder_Click(object sender, EventArgs e)
        {
            // item unselected, so ignore
            if (listView.SelectedItems.Count == 0)
            {
                return;
            }

            VideoItemFileInfo videoItemFileInfo = (VideoItemFileInfo)listView.SelectedItems[0].Tag;
            string directory = videoItemFileInfo.videoInfo.videoDirectory;

            MyFile.OpenDirectory(directory);
        }

        private void toolStripMenuItemOpen_Click(object sender, EventArgs e)
        {
            // item unselected, so ignore
            if (listView.SelectedItems.Count == 0)
            {
                return;
            }

            VideoItemFileInfo videoItemFileInfo = (VideoItemFileInfo)listView.SelectedItems[0].Tag;
            if (videoItemFileInfo == null)
            {
                return;
            }

            FileInfo fileInfo = videoItemFileInfo.GetFileInfo();
            if (fileInfo == null)
            {
                return;
            }

            MyFile.RunFile(fileInfo);
        }






        public bool SetList(VideoInfo videoInfo)
        {

            listView.SuspendLayout();

            listView.Items.Clear();
            if (videoInfo.files.video != null) 
            {
                SetListItem(videoInfo, videoInfo.files.video, "Video");
            }

            if (videoInfo.files.mve != null)
            {
                SetListItem(videoInfo, videoInfo.files.mve, "MVE");
            }

            if (videoInfo.files.xbmc != null)
            {
                SetListItem(videoInfo, videoInfo.files.xbmc, "XBMC");
            }

            if (videoInfo.files.mb != null)
            {
                SetListItem(videoInfo, videoInfo.files.mb, "MB");
            }

            foreach (VideoItemFile videoItemFile in videoInfo.files.images)
            {
                SetListItem(videoInfo, videoItemFile, "Image");
            }

            foreach (VideoItemFile videoItemFile in videoInfo.files.others)
            {
                SetListItem(videoInfo, videoItemFile, videoItemFile.Extension.TrimStart('.'));
            }

            ResizeColumns();

            // Set the column number that is to be sorted
            listViewColumnSorter.SortColumnIndex = 2;
            listViewColumnSorter.SortOrderIndex = SortOrders.DESC;

            // Perform the sort with these new sort options.
            listView.Sort();

            listView.ResumeLayout();            

            return true;
        }

        private void SetListItem(VideoInfo videoInfo, VideoItemFile videoItemFile, string fileType)
        {


            VideoItemFileInfo videoItemFileInfo = new VideoItemFileInfo();
            videoItemFileInfo.videoInfo = videoInfo;
            videoItemFileInfo.videoItemFile = videoItemFile;

            // if not already in image list, add to it
            if (!smallImageList.Images.ContainsKey(videoItemFile.Extension)) 
            {
                Icon icon = MyFileTypeIcon.Get(videoItemFileInfo.GetFullName());
                if (icon != null)
                {
                    smallImageList.Images.Add(videoItemFile.Extension, icon);
                }
            }

            ListViewItem listViewItem = new ListViewItem(videoItemFile.Name);
            listViewItem.ImageKey = videoItemFile.Extension;
            listViewItem.SubItems.Add(fileType);
            string fileSize = Convert.ToString(MyFile.FormatSize(videoItemFile.Length));
            listViewItem.SubItems.Add(fileSize);


            listViewItem.Tag = videoItemFileInfo;

            listView.Items.Add(listViewItem);
        }

        public void ResizeColumns()
        {
            nameWidth = listView.Width - MyDPI.ScaleDPIDimension(typeWidth) - MyDPI.ScaleDPIDimension(sizeWidth) - MyDPI.ScaleDPIDimension(5);

            // count is fall back in case extern call doesnt work
            int nbrItems = listView.Items.Count;
            if (MyUser32_GetWindow.IsVerticalScrollbarVisible(listView.Handle) || nbrItems > 8)
            { 
                    nameWidth -= MyDPI.ScaleDPIDimension(20);
            }

            listView.Columns[0].Width = nameWidth;
            listView.Columns[1].Width = MyDPI.ScaleDPIDimension(typeWidth);
            listView.Columns[2].Width = MyDPI.ScaleDPIDimension(sizeWidth);
        }

     





    }
}
