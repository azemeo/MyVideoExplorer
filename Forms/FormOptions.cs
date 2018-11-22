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
using System.Threading;

namespace MyVideoExplorer
{
    public partial class FormOptions : Form
    {


        public FormOptions()
        {
            InitializeComponent();
        }

        private void FormOptions_Load(object sender, EventArgs e)
        {

            comboBoxWatchedAfter.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxWatchedAfter.Items.Clear();
            comboBoxWatchedAfter.Items.Add(1);
            comboBoxWatchedAfter.Items.Add(5);
            comboBoxWatchedAfter.Items.Add(10);
            comboBoxWatchedAfter.Items.Add(15);

            int watchedAfter;
            if (Config.settings.watchedAfter == 0)
            {
                watchedAfter = 1;
            }
            else
            {
                watchedAfter = (int)Math.Floor((decimal)Config.settings.watchedAfter / 60);
                switch (watchedAfter)
                {
                    case 1:
                    case 5:
                    case 10:
                    case 15:
                        break;
                    default:
                        watchedAfter = 1;
                        break;
                }
            } 


            try 
            { 
                // update
                MyFormField.SetCheckBoxChecked(checkBoxCreateMB, Config.settings.createMB);
                MyFormField.SetCheckBoxChecked(checkBoxCreateMVE, Config.settings.createMVE);
                MyFormField.SetCheckBoxChecked(checkBoxCreateXBMC, Config.settings.createXBMC);
                MyFormField.SetCheckBoxChecked(checkBoxUpdateMB, Config.settings.updateMB);
                MyFormField.SetCheckBoxChecked(checkBoxUpdateXBMC, Config.settings.updateXBMC);
                MyFormField.SetCheckBoxChecked(checkBoxMarkWatched, Config.settings.markWatched);
                MyFormField.SetComboBoxValue(comboBoxWatchedAfter, watchedAfter);
                ValidateMarkWatched();


                // gallery
                MyFormField.SetCheckBoxChecked(checkBoxEnableGallery, Config.settings.gallery.enable);
                ToggleGalleryEnabled();
                labelGalleryBackColor.Text = "";
                labelGalleryBackColor.BackColor = Config.settings.gallery.backColor;
                MyFormField.SetCheckBoxChecked(checkBoxEnableGalleryCache, Config.settings.gallery.cachePosterThumbnails);

            }
            catch (Exception ex2)
            {
                MyLog.Add(ex2.ToString());
            }

        }

        private void FormOptions_Shown(object sender, EventArgs e)
        {
            MyFormField.HighlightTextBoxesOnFocus(this);

        }

        private void FormOptions_FormClosing(object sender, FormClosingEventArgs e)
        {
            try
            {
                // update
                Config.settings.createMB = checkBoxCreateMB.Checked;
                Config.settings.createMVE = checkBoxCreateMVE.Checked;
                Config.settings.createXBMC = checkBoxCreateXBMC.Checked;
                Config.settings.updateMB = checkBoxUpdateMB.Checked;
                Config.settings.updateXBMC = checkBoxUpdateXBMC.Checked;
                if (checkBoxMarkWatched.Enabled)
                {
                    Config.settings.markWatched = checkBoxMarkWatched.Checked;
                }
                else
                {
                    Config.settings.markWatched = false;
                }
                if (comboBoxWatchedAfter.Enabled)
                {
                    Config.settings.watchedAfter = Convert.ToInt32(comboBoxWatchedAfter.Text) * 60;
                    if (Config.settings.watchedAfter < 60)
                    {
                        Config.settings.watchedAfter = 60;
                    }
                }
                else
                {
                    Config.settings.watchedAfter = 60;
                }

                // gallery
                Config.settings.gallery.backColor = labelGalleryBackColor.BackColor;
                Config.settings.gallery.cachePosterThumbnails = checkBoxEnableGalleryCache.Checked;
            }
            catch (Exception ex)
            {
                MyLog.Add(ex.ToString());
            }
        }

        private void comboBoxWatchedAfter_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxWatchedAfter.Text == "1")
            {
                labelForWatchedAfterMinutes.Text = "Minute";
            }
            else
            {
                labelForWatchedAfterMinutes.Text = "Minutes";
            }
        }

        private void tabControlSettings_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            if (tabControlSettings.SelectedIndex == 1)
            {
                // meta data tab

            }
            else if (tabControlSettings.SelectedIndex == 2)
            {
                // external tab
                string ffprobeExe = MyFile.EnsureDataFile("ffprobe", "exe", @"libs/ffmpeg/bin");
                if (!File.Exists(ffprobeExe))
                {
                    labelFFProbeStatus.Text = "Not Found";
                    labelFFProbeStatus.ForeColor = Color.OrangeRed;
                }
                else
                {
                    labelFFProbeStatus.Text = "Available";
                    labelFFProbeStatus.ForeColor = Color.ForestGreen;
                }
            }
            else if (tabControlSettings.SelectedIndex == 3)
            {
                SetGalleryCacheSize();

            }
        }

        private void labelGalleryBackColor_Click(object sender, EventArgs e)
        {
            buttonBackColor_Click(sender, e);
        }
        private void buttonBackColor_Click(object sender, EventArgs e)
        {
            ColorDialog galleryBackColorDialog = new ColorDialog();
            // Keeps the user from selecting a custom color.
            galleryBackColorDialog.AllowFullOpen = false;

            // Sets the initial color select to the current text color.
            galleryBackColorDialog.Color = labelGalleryBackColor.ForeColor;

            // Update the text box color if the user clicks OK  
            if (galleryBackColorDialog.ShowDialog() == DialogResult.OK)
            {
                labelGalleryBackColor.BackColor = galleryBackColorDialog.Color;
                Config.settings.gallery.backColor = labelGalleryBackColor.BackColor;

                // meh, but works
                FormMain formMain = (FormMain)this.Owner;
                formMain.subFormGallery.Refresh();
            }
        }

        private void buttonEmptyGalleryCache_Click(object sender, EventArgs e)
        {
            EmptyGalleryCache();

            SetGalleryCacheSize();
        }

        private void checkBoxEnableGallery_CheckedChanged(object sender, EventArgs e)
        {
            ToggleGalleryEnabled();
        }


        private void buttonClose_Click(object sender, EventArgs e)
        {

            Close();
        }


        private void checkBoxMarkWatched_CheckedChanged(object sender, EventArgs e)
        {

        }
        private void checkBoxCreateMVE_CheckedChanged(object sender, EventArgs e)
        {
            ValidateMarkWatched();
        }

        private void checkBoxUpdateXBMC_CheckedChanged(object sender, EventArgs e)
        {
            ValidateMarkWatched();
        }
        private void checkBoxCreateXBMC_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void checkBoxUpdateMB_CheckedChanged(object sender, EventArgs e)
        {

        }
        private void checkBoxCreateMB_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void labelVideoFileQty_Click(object sender, EventArgs e)
        {

        }


        private void linkLabelMVE_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            MyLink.OpenLink((LinkLabel)sender, e);
        }

        private void linkLabelXBMC_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            MyLink.OpenLink((LinkLabel)sender, e);
        }

        private void linkLabelMB_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            MyLink.OpenLink((LinkLabel)sender, e);
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            MyLink.OpenLink((LinkLabel)sender, e);
        }




        private void ToggleGalleryEnabled()
        {
            if (checkBoxEnableGallery.Checked)
            {
                buttonBackColor.Enabled = true;
                labelGalleryBackColor.Enabled = true;
                checkBoxEnableGalleryCache.Enabled = true;
                checkBoxEnableGalleryCache.Checked = true;
                buttonEmptyGalleryCache.Enabled = true;

                Config.settings.gallery.enable = true;
            }
            else
            {
                buttonBackColor.Enabled = false;
                labelGalleryBackColor.Enabled = false;
                checkBoxEnableGalleryCache.Enabled = false;
                checkBoxEnableGalleryCache.Checked = true;
                buttonEmptyGalleryCache.Enabled = false;

                Config.settings.gallery.enable = false;
            }
        }

        private void ValidateMarkWatched()
        {
            // make sure have somewhere to mark watched
            if (checkBoxCreateMVE.Checked || checkBoxUpdateXBMC.Checked)
            {
                checkBoxMarkWatched.Enabled = true;
                comboBoxWatchedAfter.Enabled = true;
            }
            else
            {
                checkBoxMarkWatched.Enabled = false;
                checkBoxMarkWatched.Checked = false;
                comboBoxWatchedAfter.Enabled = false;
            }
        }



        private void SetGalleryCacheSize()
        {
            // gallery
            long thumbnailCachesize = MyFile.DirectorySize(@"cache\gallery", "poster*.jpg");
            labelForGalleryCacheSize.Text = MyFile.FormatSize(thumbnailCachesize);
        }
        private bool EmptyGalleryCache() 
        {
            IEnumerable<string> files = MyFile.EnumerateFiles(@"cache\gallery");

            // MyLog.Add("Clean up cache dir: " + files.Count() + " files");
            foreach (string file in files)
            {
                FileInfo fileInfo = MyFile.FileInfo(file);
                // if (fileInfo != null && fileInfo.LastAccessTime < DateTime.Now.AddMinutes(-5))
                if (fileInfo != null)
                {
                    fileInfo.Delete();
                }
            }

            return true;
        }









    }
}
