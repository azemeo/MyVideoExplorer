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
using System.Drawing.Drawing2D;

namespace MyVideoExplorer
{
    public partial class SubFormGallery : UserControl
    {
        // so this user control can update other user controls
        private SubFormFilterForm subFormFilterForm;
        private SubFormFileList subFormFileList;
        private SubFormVideoForm subFormVideoForm;
        private SubFormVideoImage subFormVideoImage;
        private SubFormProgress subFormProgress;

        private List<PictureBox> activePosters;
        private Timer posterTimer;
        private List<PictureBox> posterPictureBoxes;

        private int posterWidth = 165;
        private int posterHeight = 250;
        private int posterPadding = 10;

        private int currentPosterPage = 0;

        public SubFormGallery()
        {
            InitializeComponent();

            flowLayoutPanelPosters.FlowDirection = FlowDirection.LeftToRight;
            flowLayoutPanelPosters.Dock = DockStyle.Fill;

            // flowLayoutPanelPosters.AutoSize = true;
            // flowLayoutPanelPosters.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            // flowLayoutPanelPosters.VerticalScroll.Enabled = false;
            // flowLayoutPanel.HorizontalScroll.Enabled = true;
            // flowLayoutPanel.AutoScrollMinSize = new System.Drawing.Size(400, 400);



            // should only be one, but mouse leave doesnt always fire, so mega meh
            activePosters = new List<PictureBox> { };
            posterPictureBoxes = new List<PictureBox> { };

            posterTimer = new Timer();
            posterTimer.Interval = 500;
            posterTimer.Enabled = false;
            posterTimer.Tick += posterTimer_Tick;

            // mouse wheelz
            flowLayoutPanelPosters.MouseWheel += new MouseEventHandler(flowLayoutPanel_MouseWheel);
        }

        public void AddAccessToSubForms(SubFormFilterForm subFormFilterForm, SubFormFileList subFormFileList, SubFormVideoForm subFormVideoForm, SubFormVideoImage subFormVideoImage, SubFormProgress subFormProgress)
        {
            this.subFormFilterForm = subFormFilterForm;
            this.subFormFileList = subFormFileList;
            this.subFormVideoForm = subFormVideoForm;
            this.subFormVideoImage = subFormVideoImage;
            this.subFormProgress = subFormProgress;
        }

        private void SubFormGallery_Load(object sender, EventArgs e)
        {
            // gallery shown

            SetVisiblePosterImages();
        }

        private void posterTimer_Tick(object sender, EventArgs e)
        {
            // not used nor needed, but leaving as, meh, typed it 
        }



        /// <summary>
        /// prevent flicker on scroll
        /// http://stackoverflow.com/questions/76993/how-to-double-buffer-net-controls-on-a-form/89125#89125
        /// </summary>
        protected override CreateParams CreateParams
        {
            get
            {
                var cp = base.CreateParams;
                cp.ExStyle |= 0x02000000;    // Turn on WS_EX_COMPOSITED
                return cp;
            }
        }



        private void flowLayoutPanel_MouseWheel(object sender, MouseEventArgs e)
        {

            if (e.Delta > 0) 
            {
                // scroll up
                currentPosterPage--;
            }
            else
            {
                // scroll down
                currentPosterPage++;
            }

             
             SetVisiblePosterImages();
        }

        private void flowLayoutPanel_MouseLeave(object sender, EventArgs e)
        {
            // so mouse wheel will not scroll panel
            this.Focus();

            // clear any mouse leave missed
            ClearSelectedPosters();
        }

        private void flowLayoutPanel_MouseEnter(object sender, EventArgs e)
        {
            // mouse wheel doesnt trigger scroll event, so mimic uhm scroll event

            // when panel scrolled, redraw
            this.Invalidate();

            // so mouse wheel will scroll panel
            flowLayoutPanelPosters.Focus();
        }

        private void flowLayoutPanel_Paint(object sender, PaintEventArgs e)
        {
            if (this.ClientRectangle.Width == 0 || this.ClientRectangle.Height == 0)
            {
                return;
            }
            Color backColor = System.Drawing.Color.DarkSlateBlue;
            if (Config.settings.gallery != null && Config.settings.gallery.backColor != null)
            {
                backColor = Config.settings.gallery.backColor;
            }

            // draw gradient on gallery panel
            int x = 0;
            int y = 0;
            int width = this.ClientRectangle.Width;
            int height = (int)Math.Floor((decimal)this.ClientRectangle.Height / 2);
            using (LinearGradientBrush brush = new LinearGradientBrush(this.ClientRectangle,
                backColor, System.Drawing.Color.Black, 90F))
            {
                // e.Graphics.FillRectangle(brush, this.ClientRectangle);
                e.Graphics.FillRectangle(brush, x, y, width, height);
            }
            y = height;
            using (LinearGradientBrush brush = new LinearGradientBrush(this.ClientRectangle,
                System.Drawing.Color.Black, backColor, 90F))
            {
                e.Graphics.FillRectangle(brush, x, y, width, height);
            }
        }

        private void flowLayoutPanel_Scroll(object sender, ScrollEventArgs e)
        {
            // when panel scrolled, redraw
            this.Invalidate();

            SetVisiblePosterImages();
        }

        private void flowLayoutPanel_Resize(object sender, EventArgs e)
        {
            if (flowLayoutPanelPosters == null || flowLayoutPanelPosters.Visible == false)
            {
                return;
            }
            // when panel resized, redraw
            this.Invalidate();

            // currentPosterPage = 0;
            SetVisiblePosterImages();
        }


        protected override void OnPaintBackground(PaintEventArgs e)
        {

        }


        public event EventHandler browsePoster_Click;
        private void poster_Click(object sender, EventArgs e)
        {
            PictureBox poster = (PictureBox)sender;
            VideoInfo videoInfo = (VideoInfo)poster.Tag;

            // so far do nothing

            // bubble the event up
            var handler = browsePoster_Click;
            if (handler != null)
            {
                handler(sender, e);
            }
        }

        public event EventHandler browsePoster_DoubleClick;
        private void poster_DoubleClick(object sender, EventArgs e)
        {
            PictureBox poster = (PictureBox)sender;
            VideoInfo videoInfo = (VideoInfo)poster.Tag;

            // play it sam
            PlayVideo(videoInfo);

            // bubble the event up
            var handler = browsePoster_DoubleClick;
            if (handler != null)
            {
                handler(sender, e);
            }
        }

        public event EventHandler browsePoster_MouseEnter;
        private void poster_MouseEnter(object sender, EventArgs e)
        {
            PictureBox poster = (PictureBox)sender;
            VideoInfo videoInfo = (VideoInfo)poster.Tag;

            // clear any other poster which may be marked due to being missed by mouse leave
            ClearSelectedPosters();

            // add to active posters .. should reallybe only one, but meh
            activePosters.Add(poster);
            // posterTimer.Start();

            // indicate poster selected
            poster.BackColor = Color.LightGoldenrodYellow;
            poster.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;

            // bubble the event up
            var handler = browsePoster_MouseEnter;
            if (handler != null)
            {
                handler(sender, e);
            }
        }

        public event EventHandler browsePoster_MouseLeave;
        private void poster_MouseLeave(object sender, EventArgs e)
        {
            PictureBox poster = (PictureBox)sender;
            VideoInfo videoInfo = (VideoInfo)poster.Tag;

            // clear all posters, should only be one, but meh, mouse leave doesnt always fire
            ClearSelectedPosters();
            // posterTimer.Stop();

            // bubble the event up
            var handler = browsePoster_MouseLeave;
            if (handler != null)
            {
                handler(sender, e);
            }
        }

        public bool SetPosters(List<VideoInfo> videoInfos)
        {

            // sort
            FilterInfo filterInfo = subFormFilterForm.GetFilterForm();
            videoInfos.Sort(new SortVideoInfo(filterInfo.sortColumn, filterInfo.sortOrderIndex));

            posterPictureBoxes = new List<PictureBox> { };
            PictureBox pictureBox;
            // posterPictureBoxes = new List<PictureBox>(videoInfos.Count + 1);
            int nbrPosters = 0;

            // for dev .. to test a larger limit of videos
            for (int dev = 0; dev < 3; dev++)
            {
                // build array er list of posters
                foreach (VideoInfo videoInfo in videoInfos)
                {

                    if (videoInfo.filter)
                    {
                        continue;
                    }

                    // no files or no video, so skip
                    if (videoInfo.files == null || videoInfo.files.video == null)
                    {
                        continue;
                    }

                    // Image thumbnail = GetCachedThumbnail(videoInfo);
                    Image thumbnail = videoInfo.files.posterThumbnail;

                    try
                    {

                        pictureBox = new PictureBox();
                        pictureBox.Name = videoInfo.videoItem.title;
                        pictureBox.Size = new Size(this.posterWidth, this.posterHeight);
                        if (thumbnail == null)
                        {
                            // no poster
                            pictureBox.BackColor = Color.Black;
                        }
                        else
                        {
                            pictureBox.BackColor = Color.Transparent;
                        }
                        pictureBox.Margin = new Padding(this.posterPadding);  // yes padding, no margin obj, margin = thickness = property, meh
                        pictureBox.BorderStyle = System.Windows.Forms.BorderStyle.None;
                        // pictureBox.Image = thumbnail;
                        pictureBox.Image = null;
                        pictureBox.SizeMode = PictureBoxSizeMode.Zoom; // keep aspect ratio
                        pictureBox.Cursor = Cursors.Hand;
                        pictureBox.Tag = videoInfo;
                        pictureBox.Click += this.poster_Click;
                        pictureBox.DoubleClick += this.poster_DoubleClick;
                        pictureBox.MouseEnter += this.poster_MouseEnter;
                        pictureBox.MouseLeave += this.poster_MouseLeave;

                        SetToolTipForPoster(pictureBox, videoInfo);

                        // needed for SetVisiblePosterImages()
                        posterPictureBoxes.Add(pictureBox);
                        nbrPosters++;

                        // meh
                        if (nbrPosters % 100 == 0)
                        {
                            Application.DoEvents();
                        }


                    }
                    catch (Exception e)
                    {
                        // skip
                        MyLog.Add("SetImages: " + videoInfo.videoItem.title + "\n" + e.ToString());
                    }

                }
            }

            // actually show visible posters
            SetVisiblePosterImages();

            return true;
        }

        /// <summary>
        /// actually show visible posters
        /// </summary>
        private  void SetVisiblePosterImages() 
        {

            int width = flowLayoutPanelPosters.ClientRectangle.Width;
            int nbrXPosters = (int)Math.Floor((double)width / (this.posterWidth + this.posterPadding));
            int height = flowLayoutPanelPosters.ClientRectangle.Height;
            int nbrYPosters = (int)Math.Floor((double)height / (this.posterHeight + this.posterPadding));
            int maxPosters = nbrXPosters * nbrYPosters;

            if (currentPosterPage < 0)
            {
                currentPosterPage = 0;
            }
            int offset = currentPosterPage * maxPosters;
            if (offset > posterPictureBoxes.Count() - 1)
            {
                currentPosterPage--;
                offset -= maxPosters;

            }
            int limit = offset + maxPosters;
            if (limit > posterPictureBoxes.Count() - 1)
            {
                limit = posterPictureBoxes.Count() - 1;
            }




            flowLayoutPanelPosters.SuspendLayout();

            // remove any prior posters
            //for (int index = posterPictureBoxes.Count - 1; index >= 0; --index)
            //{
            // posterPictureBoxes[index].Dispose();
            //}

            // remove prior images, for memory management
            /*
             * http://msdn.microsoft.com/en-us/library/system.windows.forms.control.controlcollection.clear%28v=vs.110%29.aspx
             * Calling the Clear method does not remove control handles from memory. 
             */
            // flowLayoutPanelImages.Controls.Clear();
            while (flowLayoutPanelPosters.Controls.Count > 0)
            {
                flowLayoutPanelPosters.Controls.RemoveAt(0);
            }



            for (int index = offset; index < limit; index++)
            {
                PictureBox pictureBox = posterPictureBoxes.ElementAt(index);
                VideoInfo videoInfo = (VideoInfo)pictureBox.Tag;
                pictureBox.Image = videoInfo.files.posterThumbnail;
                flowLayoutPanelPosters.Controls.Add(pictureBox);
            }

            flowLayoutPanelPosters.ResumeLayout();
        }




        private bool IsMouseOverPoster()
        {
            Point cursorPoint = this.PointToClient(Cursor.Position);
            Control childControl = this.GetChildAtPoint(cursorPoint);

            if (activePosters.Count > 0)
            {
                while (childControl != null)
                {
                    if (childControl.GetType() == typeof(PictureBox))
                    {
                        return true;
                    }
                    childControl = childControl.GetChildAtPoint(cursorPoint);

                    // MessageBox.Show(activePosters.Count.ToString() + " " + childControl.GetType().ToString());
                }
            }
            return false;
        }

        private void ClearSelectedPosters()
        {
            List<PictureBox> copyActivePosters = activePosters.ToList();
            foreach (PictureBox poster in copyActivePosters)
            {
                poster.BackColor = Color.Black;
                poster.BorderStyle = System.Windows.Forms.BorderStyle.None;
                activePosters.Remove(poster);
            }
        }

        private void SetToolTipForPoster(PictureBox pictureBox, VideoInfo videoInfo)
        {
            string tipTitle = videoInfo.videoItem.title + " (" + videoInfo.videoItem.year.ToString() + ")";
            string tipText = "";
            if (videoInfo.videoItem.lastPlayed != DateTime.MinValue)
            {
                tipText += "Last Played:\t" + videoInfo.videoItem.lastPlayed.ToLocalTime().ToString();
            }
            else
            {
                tipText += "Last Played:\tNot yet";
            }
            tipText += "\n";
            if (videoInfo.videoItem.runtime > 0)
            {
                tipText += "Runtime:\t\t" + videoInfo.videoItem.runtime.ToString();
            }
            else
            {
                tipText += "Runtime:\t\t-";
            }
            tipText += "\n";
            if (videoInfo.videoItem.plot != null)
            {
                List<string> plot = MyString.WordWrap(videoInfo.videoItem.plot, 60);
                tipText += "Plot:\n" + String.Join("\n", plot);
            }
            else
            {
                tipText += "Plot:\t\t-";
            }
            SetToolTip(pictureBox, tipTitle, tipText);
        }

        private void SetToolTip(Control control, string tipTitle, string tipText)
        {
            tipText = "\n" + tipText + "\n";

            ToolTip toolTip = new ToolTip();
            toolTip.ToolTipIcon = ToolTipIcon.Info;
            toolTip.UseAnimation = false;
            toolTip.UseFading = false;
            toolTip.IsBalloon = false;
            toolTip.AutoPopDelay = 20000;
            toolTip.InitialDelay = 1000;
            toolTip.ReshowDelay = 500;
            toolTip.ShowAlways = true;
            toolTip.ToolTipTitle = tipTitle;
            toolTip.SetToolTip(control, tipText);
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

        public void SetPanelFocus()
        {
            flowLayoutPanelPosters.Focus();
        }








    }
}
