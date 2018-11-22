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
using System.Collections;

namespace MyVideoExplorer
{
    public partial class SubFormListView : UserControl
    {
        public int visibleColumnIndex;
        public int currentListViewIndex = 0;

        public SubFormListViewSort listViewColumnSorter;

        // so this user control can update other user controls
        private SubFormFilterForm subFormFilterForm;
        private SubFormFileList subFormFileList;
        private SubFormVideoForm subFormVideoForm;
        private SubFormVideoImage subFormVideoImage;
        private SubFormProgress subFormProgress;
             
        public SubFormListView()
        {
            InitializeComponent();


            // Create an instance of a ListView column sorter and assign it 
            // to the ListView control.
            listViewColumnSorter = new SubFormListViewSort();
            listView.ListViewItemSorter = listViewColumnSorter;

        }

        public void AddAccessToSubForms(SubFormFilterForm subFormFilterForm, SubFormFileList subFormFileList, SubFormVideoForm subFormVideoForm, SubFormVideoImage subFormVideoImage, SubFormProgress subFormProgress)
        {
            this.subFormFilterForm = subFormFilterForm;
            this.subFormFileList = subFormFileList;
            this.subFormVideoForm = subFormVideoForm;
            this.subFormVideoImage = subFormVideoImage;
            this.subFormProgress = subFormProgress;
        }

        private void SubFormListView_Load(object sender, EventArgs e)
        {
            this.MinimumSize = new Size(240, 400);

            visibleColumnIndex = FilterEnums.sortColumn.GetValueByKey("YEAR");

            listView.View = View.Details;
            listView.ShowItemToolTips = true;
            listView.Sorting = SortOrder.Ascending;
            listView.Dock = DockStyle.Fill;

            listView.HideSelection = false;
            listView.MultiSelect = false;

            // Allow the user to rearrange columns.
            listView.AllowColumnReorder = true;

            // Select the item and subitems when selection is made.
            listView.FullRowSelect = true;

            // Display grid lines.
            listView.GridLines = true;

            listView.Columns.Clear();
            foreach (KeyValuePair<int, string> sortColumn in FilterEnums.sortColumn.ToList().OrderBy(s => s.Key)) 
            {
                string header = FilterEnums.sortColumn.GetAbbrevByValue(sortColumn.Key);
                HorizontalAlignment align = HorizontalAlignment.Center;
                if (sortColumn.Key == FilterEnums.sortColumn.GetValueByKey("TITLE")) 
                {
                    align = HorizontalAlignment.Left;
                } 
                else if (sortColumn.Key == FilterEnums.sortColumn.GetValueByKey("YEAR")) 
                {
                    align = HorizontalAlignment.Center;
                }
                else if (sortColumn.Key == FilterEnums.sortColumn.GetValueByKey("LAST_PLAYED"))
                {
                    align = HorizontalAlignment.Center;
                }
                else if (sortColumn.Key == FilterEnums.sortColumn.GetValueByKey("NUMBER_FILES"))
                {
                    align = HorizontalAlignment.Right;
                }
                else if (sortColumn.Key == FilterEnums.sortColumn.GetValueByKey("PLAY_COUNT"))
                {
                    align = HorizontalAlignment.Right;
                }

                listView.Columns.Add(header, GetColumnWidth(visibleColumnIndex), align);
            }



            ResizeColumns();

            // meh .. seems have to use resizing events
            // listView.AutoResizeColumn(0, ColumnHeaderAutoResizeStyle.ColumnContent);
        }

        private void listView_ColumnClick(object sender, ColumnClickEventArgs e)
        {
            listView.SuspendLayout();

            int sortColumn = e.Column;

            // Determine if clicked column is already the column that is being sorted.
            if (sortColumn == listViewColumnSorter.sortColumnIndex)
            {
                // Reverse the current sort direction for this column.
                if (listViewColumnSorter.sortOrderIndex == SortOrders.ASC)
                {
                    listViewColumnSorter.sortOrderIndex = SortOrders.DESC;
                }
                else
                {
                    listViewColumnSorter.sortOrderIndex = SortOrders.ASC;
                }
            }
            else
            {
                // Set the column number that is to be sorted; default to ascending.
                listViewColumnSorter.sortColumnIndex = sortColumn;
                listViewColumnSorter.sortOrderIndex = SortOrders.ASC;
            }

            // Perform the sort with these new sort options.
            this.listView.Sort();

            subFormFilterForm.SetFilterFormSort(listViewColumnSorter.sortColumnIndex, listViewColumnSorter.sortOrderIndex);

            listView.ResumeLayout();
        }




        public event EventHandler listView_selectedIndexChanged;
        private void listView_SelectedIndexChanged(object sender, EventArgs e)
        {
            // called on select and unselect of item


            // item unselected, so ignore
            if (listView.SelectedItems.Count == 0)
            {
                subFormVideoForm.DisableFormButtons();
                return;
            }

            // grab first one
            ListViewItem selectedItem = listView.SelectedItems[0];
            currentListViewIndex = listView.SelectedIndices[0];


            LoadVideoForm(selectedItem);

            subFormVideoForm.EnableFormButtons();

            // bubble the event up
            if (this.listView_selectedIndexChanged != null)
            {
                this.listView_selectedIndexChanged(selectedItem, e);
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

            // grab first one
            ListViewItem selectedItem = listView.SelectedItems[0];

            VideoInfo videoInfo = (VideoInfo)selectedItem.Tag;

            MyFile.OpenDirectory(videoInfo.videoDirectory);

        }

        private void toolStripMenuItemPlay_Click(object sender, EventArgs e)
        {
            // item unselected, so ignore
            if (listView.SelectedItems.Count == 0)
            {
                return;
            }

            // grab first one
            ListViewItem selectedItem = listView.SelectedItems[0];

            VideoInfo videoInfo = (VideoInfo)selectedItem.Tag;

            PlayVideo(videoInfo);
        }

        private void listView_DoubleClick(object sender, EventArgs e)
        {
            // item unselected, so ignore
            if (listView.SelectedItems.Count == 0)
            {
                return;
            }

            // grab first one
            ListViewItem selectedItem = listView.SelectedItems[0];

            VideoInfo videoInfo = (VideoInfo)selectedItem.Tag;

            PlayVideo(videoInfo);
        }


        private void PlayVideo(VideoInfo videoInfo)
        {
            if (videoInfo != null && videoInfo.files.video != null)
            {
                PlayFile playFile = new PlayFile();
                playFile.AddAccessToSubForms(subFormVideoForm, subFormProgress);

                playFile.Play(videoInfo, videoInfo.files.video);
            }
        }



        /// <summary>
        /// auto adjust title column width
        /// </summary>
        public void ResizeColumns() {

            int titleWidth = listView.Width - MyDPI.ScaleDPIDimension(GetColumnWidth(visibleColumnIndex)) - MyDPI.ScaleDPIDimension(5);

            // count is fall back in case extern call doesnt work
            int nbrItems = listView.Items.Count;
            if (listView.Handle != null && MyUser32_GetWindow.IsVerticalScrollbarVisible(listView.Handle) || nbrItems > 24)
            {
                titleWidth -= MyDPI.ScaleDPIDimension(20);
            }


            /// set all to 0
            foreach (KeyValuePair<int, string> sortColumn in FilterEnums.sortColumn.ToList().OrderBy(s => s.Key))
            {
                listView.Columns[sortColumn.Key].Width = 0;
            }

            // now set visible columns
            listView.Columns[0].Width = titleWidth;
            listView.Columns[visibleColumnIndex].Width = MyDPI.ScaleDPIDimension(GetColumnWidth(visibleColumnIndex));

        }

        private int GetColumnWidth(int column)
        {
            int width = 100;

            if (column == FilterEnums.sortColumn.GetValueByKey("TITLE"))
            {
                width = 100;
            }
            else if (column == FilterEnums.sortColumn.GetValueByKey("YEAR"))
            {
                width = 50;
            }
            else if (column == FilterEnums.sortColumn.GetValueByKey("LAST_PLAYED"))
            {
                width = 70;
            }
            else if (column == FilterEnums.sortColumn.GetValueByKey("NUMBER_FILES"))
            {
                width = 40;
            }
            else if (column == FilterEnums.sortColumn.GetValueByKey("PLAY_COUNT"))
            {
                width = 40;
            }
            return width;
        }

        private string FormatTitleArticles(string title)
        {
            if (String.IsNullOrEmpty(title))
            {
                return title;
            }
            title = title.Trim();

            string[] articles = new string[] { "The", "An", "A" };

            foreach (string article in articles)
            {
                if (title.StartsWith(article + " "))
                {
                    title = title.Substring(article.Length + 1) + ", " + article;
                }
            }
            return title;
        }

        public void SetListViewInfos(List<VideoInfo> videoInfos)
        {

            ResizeColumns();
            listView.SuspendLayout();
            listView.Scrollable = false;

            listView.Items.Clear();

            if (videoInfos == null)
            {
                return;
            }

            int nbrColumns = FilterEnums.sortColumn.ToList().Count();
            string[] listViewItemData = new string[nbrColumns];

            int nbrListItems = 0;
            foreach (VideoInfo videoInfo in videoInfos)
            {
                if (videoInfo.videoItem == null)
                {
                    continue;
                }

                string title = videoInfo.videoItem.title;
                title = FormatTitleArticles(title);

                if (videoInfo.filter)
                {
                    title = "*" + title; // debug, comment out continue
                    continue;
                }

                listViewItemData[FilterEnums.sortColumn.GetValueByKey("TITLE")] = title;
                listViewItemData[FilterEnums.sortColumn.GetValueByKey("YEAR")] = videoInfo.videoItem.year.ToString();
                string lastPlayed;
                if (videoInfo.videoItem.lastPlayed == DateTime.MinValue)
                {
                    lastPlayed = "Not yet";
                }
                else if (videoInfo.videoItem.lastPlayed == DateTime.UtcNow.Date)
                {
                    lastPlayed = videoInfo.videoItem.lastPlayed.ToShortTimeString();
                }
                else
                {
                    lastPlayed = videoInfo.videoItem.lastPlayed.ToShortDateString();
                }   
                listViewItemData[FilterEnums.sortColumn.GetValueByKey("LAST_PLAYED")] = lastPlayed;
                listViewItemData[FilterEnums.sortColumn.GetValueByKey("NUMBER_FILES")] = videoInfo.files.qty.ToString();
                listViewItemData[FilterEnums.sortColumn.GetValueByKey("PLAY_COUNT")] = videoInfo.videoItem.playCount.ToString();


                ListViewItem listViewItem = new ListViewItem(listViewItemData);
                listViewItem.ToolTipText = videoInfo.videoDirectory;

                listViewItem.Tag = videoInfo;
                

                listView.Items.Add(listViewItem);

                nbrListItems++;

                // meh
                if (nbrListItems % 100 == 0)
                {
                    Application.DoEvents();
                }

            }

            listView.Scrollable = true;
            ResizeColumns();
            listView.ResumeLayout();

            if (listView.SelectedItems.Count == 0 && listView.Items.Count != 0)
            {
                listView.Items[currentListViewIndex].Selected = true;
                
            }

            listView.Focus();
        }



        public void LoadVideoForm(ListViewItem selectedItem)
        {

            VideoInfo selectedVideoInfo = (VideoInfo)selectedItem.Tag;

            if (selectedVideoInfo != null)
            {
                subFormVideoForm.AddAccessToSubForms(subFormFileList, subFormProgress);

                subFormVideoForm.SetForm(selectedVideoInfo);

                subFormVideoImage.SetImages(selectedVideoInfo);

                subFormFileList.SetList(selectedVideoInfo);
            }
            else
            {
                subFormProgress.Text("Unable to load info for video");
            }
            
            listView.Focus();
        }











 



    }
}
