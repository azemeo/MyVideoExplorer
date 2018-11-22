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

namespace MyVideoExplorer
{
    public partial class SubFormVideoImage : UserControl
    {
        public SubFormVideoImage()
        {
            InitializeComponent();


        }

        private void SubFormVideoImage_Load(object sender, EventArgs e)
        {

            this.MinimumSize = new Size(240, 600);

            // vertical; image is expandable, list is fixed
            splitContainerImageList.Orientation = Orientation.Horizontal;
            splitContainerImageList.Dock = DockStyle.Fill;
            splitContainerImageList.FixedPanel = FixedPanel.Panel2; // list
            splitContainerImageList.IsSplitterFixed = true;
            splitContainerImageList.SplitterDistance = splitContainerImageList.Height - 105;
            splitContainerImageList.Panel1MinSize = 500;
            splitContainerImageList.Panel2MinSize = 105;

            flowLayoutPanelImages.FlowDirection = FlowDirection.TopDown;
            flowLayoutPanelImages.AutoSize = true;
            flowLayoutPanelImages.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            flowLayoutPanelImages.HorizontalScroll.Enabled = true;
            flowLayoutPanelImages.AutoScrollMinSize = new System.Drawing.Size(100, 0);

            // keep aspect ratio
            pictureBoxImage.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBoxImage.BackColor = Color.Black;
        }

        /// <summary>
        /// when clock list of images, populate picture box
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void imageList_Click(object sender, EventArgs e)
        {
            PictureBox image = (PictureBox)sender;

            if (pictureBoxImage.Image != null)
            {
                pictureBoxImage.Image.Dispose();
            }

            pictureBoxImage.Image = image.Image;
        }

        private void pictureBoxImage_SizeChanged(object sender, EventArgs e)
        {

        }

        private void flowLayoutPanelImages_Paint(object sender, PaintEventArgs e)
        {

        }




        public bool SetImages(VideoInfo videoInfo)
        {
            // nothing to see
            if (videoInfo.files == null || videoInfo.files.images == null)
            {
                return false;
            }

            // set big picture box to poster, if avail
            if (videoInfo.files != null && videoInfo.files.poster != null)
            {
                Image posterImage = MyImage.GetImageFromFile(videoInfo.GetFullName(videoInfo.files.poster));
                pictureBoxImage.Image = posterImage;
            }
            else
            {
                if (pictureBoxImage.Image != null)
                {
                    pictureBoxImage.Image.Dispose();
                }
                pictureBoxImage.Image = null;
            }


            flowLayoutPanelImages.SuspendLayout();

            // remove prior images, for memory management funz
            /*
             * http://msdn.microsoft.com/en-us/library/system.windows.forms.control.controlcollection.clear%28v=vs.110%29.aspx
             * Calling the Clear method does not remove control handles from memory. 
             */
            // flowLayoutPanelImages.Controls.Clear();
            foreach (PictureBox priorPictureImage in flowLayoutPanelImages.Controls.OfType<PictureBox>())
            {
                if (priorPictureImage.Image != null)
                {
                    priorPictureImage.Image.Dispose();
                }
                priorPictureImage.Image = null;
            }
            while (flowLayoutPanelImages.Controls.Count > 0)
            {
                flowLayoutPanelImages.Controls.RemoveAt(0);
            }




            PictureBox pictureBox;
            foreach (VideoItemFile videoItemFile in videoInfo.files.images)
            {
                string imageFullName = videoInfo.GetFullName(videoItemFile);
                // skip images smaller than y or larger than x
                if (videoItemFile.Length < 100)
                {
                    MyLog.Add("SetImages: Skipping " + imageFullName + " " + MyFile.FormatSize(videoItemFile.Length));
                    continue;
                }
                if (videoItemFile.Length > 5 * 1048576)
                {
                    MyLog.Add("SetImages: Skipping " + imageFullName + " " + MyFile.FormatSize(videoItemFile.Length));
                    continue;
                }

                Image image = MyImage.GetImageFromFile(imageFullName);

                try 
                {
                    pictureBox = new PictureBox();
                    pictureBox.Size = new Size(75, 75);
                    pictureBox.Image = image;
                    pictureBox.SizeMode = PictureBoxSizeMode.Zoom; // keep aspect ratio
                    pictureBox.Cursor = Cursors.Hand;
                    pictureBox.Click += this.imageList_Click;

                    flowLayoutPanelImages.Controls.Add(pictureBox);


                }
                catch (Exception e)
                {
                    // skip
                    MyLog.Add("SetImages: " + imageFullName + "\n" + e.ToString());
                }
            }

            flowLayoutPanelImages.ResumeLayout();

            return true;
        }






    }
}
