using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Diagnostics;
using System.IO;

namespace MyVideoExplorer
{
    public partial class SubFormVideoForm : UserControl
    {
        public VideoInfo selectedVideoInfo;

        

        // so this user control can update other user controls
        private SubFormProgress subFormProgress;
        private SubFormFileList subFormFileList;

        
        public SubFormVideoForm()
        {
            InitializeComponent();
        }

        private void UserControlVideoInfo_Load(object sender, EventArgs e)
        {
            this.MinimumSize = new Size(350, 600);

            comboBoxYear.Items.Clear();
            int paddingYears = 5;
            int currentYear = System.DateTime.UtcNow.Year + paddingYears;
            for (int year = currentYear; year >= 1950; year--)
            {
                comboBoxYear.Items.Add(year);
            }

            comboBoxRating.Items.Clear();
            for (int rating = 10; rating >= 0; rating--)
            {
                comboBoxRating.Items.Add(rating);
            }

            comboBoxIMDBRating.Items.Clear();
            for (int rating = 10; rating >= 0; rating--)
            {
                comboBoxIMDBRating.Items.Add(rating);
            }

            comboBoxPlayCount.Items.Clear();
            for (int playCount = 0; playCount <= 20; playCount++)
            {
                comboBoxPlayCount.Items.Add(playCount);
            }

            comboBoxSource.Items.Clear();
            comboBoxSource.Items.Add("Bluray");
            comboBoxSource.Items.Add("DVD");
            comboBoxSource.Items.Add("Stream");

            comboBoxVersion.Items.Clear();
            comboBoxVersion.Items.Add("Directors");
            comboBoxVersion.Items.Add("Extended");
            comboBoxVersion.Items.Add("Theater");
            comboBoxVersion.Items.Add("Unrated");

            comboBoxCodec.Items.Clear();
            comboBoxCodec.Items.Add("h264");

            comboBoxSource.Items.Clear();
            comboBoxSource.Items.Add("Bluray");
            comboBoxSource.Items.Add("DVD");
            comboBoxSource.Items.Add("Stream");

            comboBoxMPAA.DropDownStyle = ComboBoxStyle.DropDown;
            comboBoxMPAA.Items.Clear();
            comboBoxMPAA.Items.Add("G");
            comboBoxMPAA.Items.Add("PG");
            comboBoxMPAA.Items.Add("PG-13");
            comboBoxMPAA.Items.Add("R");
            comboBoxMPAA.Items.Add("NC-17");
            comboBoxMPAA.SelectedIndex = 0;

            linkLabelBing.LinkBehavior = LinkBehavior.HoverUnderline;
            linkLabelBing.LinkVisited = false;
            linkLabelBing.LinkColor = Color.Gray;
            linkLabelBing.Text = "Bing";

            linkLabelGoogle.LinkBehavior = LinkBehavior.HoverUnderline;
            linkLabelGoogle.LinkVisited = false;
            linkLabelGoogle.LinkColor = Color.Gray;
            linkLabelGoogle.Text = "Google";

            linkLabelRT.LinkBehavior = LinkBehavior.HoverUnderline;
            linkLabelRT.LinkVisited = false;
            linkLabelRT.LinkColor = Color.Gray;
            linkLabelRT.Text = "RT";

            linkLabelIMDB.LinkBehavior = LinkBehavior.HoverUnderline;
            linkLabelIMDB.LinkVisited = false;
            linkLabelIMDB.LinkColor = Color.Gray;
            linkLabelIMDB.Text = "IMDB";

            linkLabelTMDB.LinkBehavior = LinkBehavior.HoverUnderline;
            linkLabelTMDB.LinkVisited = false;
            linkLabelTMDB.LinkColor = Color.Gray;
            linkLabelTMDB.Text = "TMDB";

            checkBoxWatched.Checked = false;

            dataGridViewActors.Columns[1].Width = 100; // role
            dataGridViewActors.Columns[0].Width = dataGridViewActors.Width - dataGridViewActors.Columns[1].Width - MyDPI.ScaleDPIDimension(5); // name

            // match higlights of form fields (textboxes, comboboxes, etc) via MyFormField.HighlightFormFieldsOnFocus()
            dataGridViewActors.RowTemplate.DefaultCellStyle.SelectionBackColor = Color.LightYellow;
            dataGridViewActors.RowTemplate.DefaultCellStyle.SelectionForeColor = Color.Black;

            dataGridViewGenres.RowTemplate.DefaultCellStyle.SelectionBackColor = Color.LightYellow;
            dataGridViewGenres.RowTemplate.DefaultCellStyle.SelectionForeColor = Color.Black;

            dataGridViewTags.RowTemplate.DefaultCellStyle.SelectionBackColor = Color.LightYellow;
            dataGridViewTags.RowTemplate.DefaultCellStyle.SelectionForeColor = Color.Black;

            VideoInfo videoInfo = new VideoInfo();
            videoInfo.videoItem = new VideoItem();
            SetForm(videoInfo);

             DisableFormButtons();


            MyTooltip tooltip = new MyTooltip();
            //tooltip.SetToolTip((LinkLabel)sender, "test test");

        }

        public void AddAccessToSubForms(SubFormFileList subFormFileList, SubFormProgress subFormProgress)
        {
            this.subFormFileList = subFormFileList;
            this.subFormProgress = subFormProgress;
        }

        private void textBoxTMDB_TextChanged(object sender, EventArgs e)
        {

            // set tmdbId link
            MyFormField.SetLinkLabel(linkLabelTMDB, "http://www.themoviedb.org/movie/", textBoxTMDB.Text);
        }

        private void textBoxIMDB_TextChanged(object sender, EventArgs e)
        {
            // set imdbId link
            MyFormField.SetLinkLabel(linkLabelIMDB, "http://www.imdb.com/title/", textBoxIMDB.Text);
        }

        private void linkLabelBing_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            linkLabelOpenLink((LinkLabel)sender, e);
        }

        private void linkLabelGoogle_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            linkLabelOpenLink((LinkLabel)sender, e);
        }

        private void linkLabelRT_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            linkLabelOpenLink((LinkLabel)sender, e);
        }

        private void linkLabelTMDB_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            linkLabelOpenLink((LinkLabel)sender, e);
        }

        private void linkLabelIMDB_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            linkLabelOpenLink((LinkLabel)sender, e);
        }

        private void comboBoxYear_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void checkBoxWatched_CheckedChanged(object sender, EventArgs e)
        {
            
        }

        private void textBoxSearchTitle_TextChanged(object sender, EventArgs e)
        {
            // set bing link
            SetLinkLabelFromTitle(linkLabelBing, "https://www.bing.com/search?q=");

            // set google link
            SetLinkLabelFromTitle(linkLabelGoogle, "https://www.google.com/search?q=");

            // set google link
            SetLinkLabelFromTitle(linkLabelRT, "https://www.rottentomatoes.com/search/?search=");
        }

        private void linkLabelIMDB_MouseHover(object sender, EventArgs e)
        {
            SetToolTipForLink((LinkLabel)sender);
        }

        private void linkLabelTMDB_MouseHover(object sender, EventArgs e)
        {
            SetToolTipForLink((LinkLabel)sender);
        }

        private void linkLabelBing_MouseHover(object sender, EventArgs e)
        {
            SetToolTipForLink((LinkLabel)sender);
        }

        private void linkLabelGoogle_MouseHover(object sender, EventArgs e)
        {
            SetToolTipForLink((LinkLabel)sender);
        }

        private void linkLabelRT_MouseHover(object sender, EventArgs e)
        {
            SetToolTipForLink((LinkLabel)sender);
        }



        private void labelDirectory_MouseHover(object sender, EventArgs e)
        {
            Label label = (Label)sender;
            SetToolTip(label, "Directory", label.Text);
        }

        private void labelUpdated_MouseHover(object sender, EventArgs e)
        {
            SetToolTipForDateTime((Label)sender, "Updated");
        }

        private void labelLastPlayed_MouseHover(object sender, EventArgs e)
        {
            SetToolTipForDateTime((Label)sender, "Last Played");
        }

        private void labelSyncUp_MouseHover(object sender, EventArgs e)
        {
            SetToolTipForDateTime((Label)sender, "Synced Up");
        }

        private void labelSyncDown_MouseHover(object sender, EventArgs e)
        {
            SetToolTipForDateTime((Label)sender, "Synced Down");
        }



        private void buttonSave_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;

            button.Enabled = false;
            button.Text = "Saving..";

            

            SaveForm();

            MyFormField.DelayButtonClick(button, "Save");
        }

        private void buttonPlay_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            if (selectedVideoInfo != null && selectedVideoInfo.files != null && selectedVideoInfo.files.video != null)
            {
                button.Enabled = false;
                button.Text = "Playing..";

                PlayFile playFile = new PlayFile();
                playFile.playFile_Completed += (senderPlay, eventPlay) => PlayFile_Completed(senderPlay, eventPlay, selectedVideoInfo);
                playFile.AddAccessToSubForms(this, subFormProgress);
                string videoFullName = selectedVideoInfo.GetFullName(selectedVideoInfo.files.video);
                FileInfo fileInfo = MyFile.FileInfo(videoFullName);
                if (fileInfo == null)
                {
                    MessageBox.Show("Error trying to play video [" + selectedVideoInfo.files.video.Name + "]");
                    return;
                }
                playFile.Play(selectedVideoInfo, selectedVideoInfo.files.video);

                MyFormField.DelayButtonClick(button, "Play");
            }

        }

        public void PlayFile_Completed(object sender, VideoItemFileInfo resultsVideoItemFileInfo, VideoInfo playedVideoInfo)
        {

        }

        private void buttonScan_Click(object sender, EventArgs e)
        {
            Button button = (Button)sender;
            if (selectedVideoInfo != null && selectedVideoInfo.videoItem != null)
            {
                button.Enabled = false;
                button.Text = "Scanning..";

                string directory = selectedVideoInfo.videoDirectory;
                MyLog.Add("Scanning: " + directory);

                ParseVideo parseVideo = new ParseVideo();
                selectedVideoInfo = parseVideo.ReadDirectory(directory);

                
                subFormFileList.SetList(selectedVideoInfo);
                SetForm(selectedVideoInfo);
                ListVideoInfo.UpdateVideoInfoList(selectedVideoInfo);
                

                MyFormField.DelayButtonClick(button, "Scan");
            }
        }





        public bool SaveForm()
        {
            // MyLog.Add("SaveForm");

            bool ret = true;
            VideoItem videoItem = selectedVideoInfo.videoItem;

            if (comboBoxIMDBRating.Text == "")
            {
                comboBoxIMDBRating.Text = "0";
            }
            videoItem.imdbRating = Convert.ToDecimal(comboBoxIMDBRating.Text);
            videoItem.lastPlayed = (DateTime)labelLastPlayed.Tag;
            videoItem.movieset = textBoxMovieSet.Text;
            videoItem.mpaa = comboBoxMPAA.Text;
            videoItem.notes = richTextBoxNotes.Text;
            if (comboBoxPlayCount.Text == "")
            {
                comboBoxPlayCount.Text = "0";
            }
            videoItem.playCount = Convert.ToInt32(comboBoxPlayCount.Text);
            videoItem.plot = richTextBoxPlot.Text;
            if (comboBoxRating.Text == "")
            {
                comboBoxRating.Text = "0";
            }
            videoItem.rating = Convert.ToInt32(comboBoxRating.Text);
            if (textBoxRunTime.Text == "")
            {
                textBoxRunTime.Text = "0";
            }
            videoItem.runtime = Convert.ToInt32(textBoxRunTime.Text);
            videoItem.title = textBoxTitle.Text;


            videoItem.actors = new List<VideoItemActor<string, string>> { };
            videoItem.directors = new List<VideoItemDirector<string>> { };
            for (int index = dataGridViewActors.Rows.Count - 1; index >= 0; index--)
            {
                if (dataGridViewActors.Rows[index].IsNewRow)
                {
                    continue;
                }               
                string name = dataGridViewActors.Rows[index].Cells[0].Value.ToString();
                string role = dataGridViewActors.Rows[index].Cells[1].Value.ToString();
                if (!String.IsNullOrWhiteSpace(name) && !String.IsNullOrWhiteSpace(role)) 
                {
                    if (role.ToLower() == "director")
                    {
                        videoItem.directors.Add(new VideoItemDirector<string>(name));
                    }
                    else
                    {
                        // VideoItemActor<string, string> actor = new VideoItemActor<string, string>(name, role);
                        videoItem.actors.Add(new VideoItemActor<string, string>(name, role));
                    }
                }
            }

            videoItem.tags = new List<VideoItemTag<string>> { };
            for (int index = dataGridViewTags.Rows.Count - 1; index >= 0; index--)
            {
                if (dataGridViewTags.Rows[index].IsNewRow)
                {
                    continue;
                }
                string tag = dataGridViewTags.Rows[index].Cells[0].Value.ToString();
                if (!String.IsNullOrWhiteSpace(tag))
                {
                    videoItem.tags.Add(new VideoItemTag<string>(tag));
                }
            }

            videoItem.genres = new List<VideoItemGenre<string>> { };
            for (int index = dataGridViewGenres.Rows.Count - 1; index >= 0; index--)
            {
                if (dataGridViewGenres.Rows[index].IsNewRow)
                {
                    continue;
                }
                string genre = dataGridViewGenres.Rows[index].Cells[0].Value.ToString();
                if (!String.IsNullOrWhiteSpace(genre))
                {
                    videoItem.genres.Add(new VideoItemGenre<string>(genre));
                }
            }


            // videoItem.tagline = textBoxTagLine.Text; // not yet

            videoItem.upc = textBoxUPC.Text;
            videoItem.tmdbId = textBoxTMDB.Text;
            videoItem.imdbId = textBoxIMDB.Text;

            videoItem.source = comboBoxSource.Text;
            videoItem.version = comboBoxVersion.Text;
            videoItem.watched = checkBoxWatched.Checked ? "YES" : "NO";

            if (comboBoxYear.Text == "")
            {
                comboBoxYear.Text = "0";
            }
            videoItem.year = Convert.ToInt32(comboBoxYear.Text);

            videoItem.encoding.codec = comboBoxCodec.Text;
            if (textBoxBitrate.Text == "")
            {
                textBoxBitrate.Text = "0";
            }
            videoItem.encoding.bitrate = Convert.ToInt32(textBoxBitrate.Text);
            if (textBoxHeight.Text == "")
            {
                textBoxHeight.Text = "0";
            }
            videoItem.encoding.height = Convert.ToInt32(textBoxHeight.Text);
            if (textBoxWidth.Text == "")
            {
                textBoxWidth.Text = "0";
            }
            videoItem.encoding.width = Convert.ToInt32(textBoxWidth.Text);

            // selectedVideoInfo.source = labelSource.Text; // readonly
            // selectedVideoInfo.directory = labelDirectory.Text; // readonly

            selectedVideoInfo.updated = DateTime.UtcNow;
            selectedVideoInfo.edited = true;

            // reset form in case prior validation changed any fields
            selectedVideoInfo.videoItem = videoItem;
            SetForm(selectedVideoInfo);

            if (!ListVideoInfo.SettingsOkToSaveVideoInfo())
            {
                MessageBox.Show("Nothing to save to.\nNot configured to save Video infomration.\nChange in Tools -> Options.");
                ret = false;
            }
            else
            {
                if (ListVideoInfo.SaveVideoInfo(selectedVideoInfo))
                {
                    buttonSave.Text = "Saved";
                    ret = true;
                }
                else
                {
                    buttonSave.Text = "Error";
                    ret = false;
                }
            }
            return ret;
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
        private void SetToolTipForDateTime(Label label, string tipTitle)
        {
            string tipText = null;
            if (label.Tag == null)
            {
                tipText = "None";
            }
            else
            {
                DateTime dateTime = (DateTime)label.Tag;
                if (dateTime == DateTime.MinValue)
                {
                    tipText = "None";
                }
                else
                {
                    tipText = dateTime.ToLocalTime().ToString();
                }
            }
            SetToolTip(label, tipTitle, tipText);
        }
        private void SetToolTipForLink(LinkLabel linkLabel)
        {
            if (linkLabel.Links.Count > 0 && linkLabel.Links[0].LinkData != null)
            {
                SetToolTip(linkLabel, linkLabel.Text, linkLabel.Links[0].LinkData.ToString());
            }
        }







        private void SetLinkLabelFromTitle(LinkLabel linkLabel, string link)
        {
            string search = "";
            if (textBoxTitle.Text != null && textBoxTitle.Text.Length > 0)
            {
                search = textBoxTitle.Text;
                if (comboBoxYear.Text != null && comboBoxYear.Text.Length == 4)
                {
                    search += " " + comboBoxYear.Text;
                }
                search = Uri.EscapeUriString(search);
                MyFormField.SetLinkLabel(linkLabel, link, search);
            }
            else
            {
                MyFormField.SetLinkLabel(linkLabel, link, null);
            }
        }

        public void DisableFormButtons()
        {
            buttonSave.Enabled = false;
            buttonScan.Enabled = false;
            buttonPlay.Enabled = false;
        }

        public void EnableFormButtons()
        {
            buttonSave.Enabled = true;
            buttonScan.Enabled = true;
            buttonPlay.Enabled = true;
        }

        public void SetForm(VideoInfo videoInfo)
        {
            this.selectedVideoInfo = videoInfo;
            VideoItem videoItem = videoInfo.videoItem;

            try
            {
                // set search title
                MyFormField.SetTextBoxText(textBoxTitle, videoItem.title);

                // set movie set
                MyFormField.SetTextBoxText(textBoxMovieSet, videoItem.movieset);

                // set plot
                MyFormField.SetRichTextBoxText(richTextBoxPlot, videoItem.plot);

                // set runtime
                MyFormField.SetTextBoxText(textBoxRunTime, videoItem.runtime.ToString());

                // set tagline
                // MyFormField.SetTextBoxText(textBoxTagLine, videoItem.tagline); // not yet

                // set notes
                MyFormField.SetRichTextBoxText(richTextBoxNotes, videoItem.notes);

                if (videoItem.encoding != null)
                {
                    // set width
                    if (videoItem.encoding.width > 0)
                    {
                        MyFormField.SetTextBoxText(textBoxWidth, videoItem.encoding.width.ToString());
                    }
                    else
                    {
                        MyFormField.SetTextBoxText(textBoxWidth, "");
                    }

                    // set height
                    if (videoItem.encoding.height > 0)
                    {
                        MyFormField.SetTextBoxText(textBoxHeight, videoItem.encoding.height.ToString());
                    }
                    else
                    {
                        MyFormField.SetTextBoxText(textBoxHeight, "");
                    }

                    // set bitrate
                    if (videoItem.encoding.bitrate > 0)
                    {
                        MyFormField.SetTextBoxText(textBoxBitrate, videoItem.encoding.bitrate.ToString());
                        string bitrateFormatted = MyFile.FormatSize(videoItem.encoding.bitrate, 2);
                        bitrateFormatted = bitrateFormatted.Replace(" ", "\n");
                        MyFormField.SetLabelText(labelForBitrateFormatted, bitrateFormatted);
                    }
                    else
                    {
                        MyFormField.SetTextBoxText(textBoxBitrate, "");
                        MyFormField.SetLabelText(labelForBitrateFormatted, "");
                    }

                    // set codec
                    if (!String.IsNullOrEmpty(videoItem.encoding.codec))
                    {
                        MyFormField.SetComboBoxValue(comboBoxCodec, videoItem.encoding.codec);
                    }
                    else
                    {
                        MyFormField.SetComboBoxValue(comboBoxCodec, "");
                    }
                }
                

                // set tag
                for (int index = dataGridViewTags.Rows.Count - 1; index >= 0; index--)
                {
                    if (dataGridViewTags.Rows[index].IsNewRow)
                    {
                        continue;
                    }
                    dataGridViewTags.Rows.RemoveAt(index);
                }
                if (videoItem.tags != null)
                {
                    IComparer<VideoItemTag<string>> sortVideoItemTag = new SortVideoItemTag();
                    videoItem.tags.Sort(sortVideoItemTag);
                    foreach (VideoItemTag<string> tag in videoItem.tags)
                    {
                        dataGridViewTags.Rows.Add(new object[] { tag.name });
                    }
                    // prevent add row from being auto selected
                    if (dataGridViewTags.CurrentCell != null)
                    {
                        dataGridViewTags.CurrentCell.Selected = false;
                    }
                }

                // set genre
                for (int index = dataGridViewGenres.Rows.Count - 1; index >= 0; index--)
                {
                    if (dataGridViewGenres.Rows[index].IsNewRow)
                    {
                        continue;
                    }
                    dataGridViewGenres.Rows.RemoveAt(index);
                }
                if (videoItem.genres != null)
                {
                    IComparer<VideoItemGenre<string>> sortVideoItemGenre = new SortVideoItemGenre();
                    videoItem.genres.Sort(sortVideoItemGenre);
                    foreach (VideoItemGenre<string> genre in videoItem.genres)
                    {
                        dataGridViewGenres.Rows.Add(new object[] { genre.name });
                    }
                    // prevent add row from being auto selected
                    if (dataGridViewGenres.CurrentCell != null)
                    {
                        dataGridViewGenres.CurrentCell.Selected = false;
                    }
                }

                // set bing link
                SetLinkLabelFromTitle(linkLabelBing, "https://www.bing.com/search?q=");

                // set google link
                SetLinkLabelFromTitle(linkLabelGoogle, "https://www.google.com/search?q=");

                // set google link
                SetLinkLabelFromTitle(linkLabelRT, "https://www.rottentomatoes.com/search/?search=");

                // set upc
                MyFormField.SetTextBoxText(textBoxUPC, videoItem.upc);

                // set tmdbId link
                MyFormField.SetTextBoxText(textBoxTMDB, videoItem.tmdbId);
                MyFormField.SetLinkLabel(linkLabelTMDB, "http://www.themoviedb.org/movie/", videoItem.tmdbId);

                // set imdbId link
                MyFormField.SetTextBoxText(textBoxIMDB, videoItem.imdbId);
                MyFormField.SetLinkLabel(linkLabelIMDB, "http://www.imdb.com/title/", videoItem.imdbId);


                // set year
                MyFormField.SetComboBoxValue(comboBoxYear, videoItem.year);

                // set imdbRating
                MyFormField.SetComboBoxValue(comboBoxIMDBRating, Convert.ToInt32(videoItem.imdbRating));

                // set mpaa
                MyFormField.SetComboBoxValue(comboBoxMPAA, videoItem.mpaa);

                // set playCount
                MyFormField.SetComboBoxValue(comboBoxPlayCount, videoItem.playCount);

                // set rating
                MyFormField.SetComboBoxValue(comboBoxRating, videoItem.rating);

                // set source
                MyFormField.SetComboBoxValue(comboBoxSource, videoItem.source);

                // set version
                MyFormField.SetComboBoxValue(comboBoxVersion, videoItem.version);

                // set lastPlayed
                MyFormField.SetLabelText(labelLastPlayed, videoItem.lastPlayed);

                // set labelUpdated
                MyFormField.SetLabelText(labelUpdated, videoInfo.updated);


                // set watched
                MyFormField.SetCheckBoxChecked(checkBoxWatched, ((videoItem.watched != "NO") ? true : false));

                // set actor/director
                for (int index = dataGridViewActors.Rows.Count - 1; index >= 0; index--)
                {
                    if (dataGridViewActors.Rows[index].IsNewRow)
                    {
                        continue;
                    }
                    dataGridViewActors.Rows.RemoveAt(index);
                }
                if (videoItem.directors != null)
                {
                    IComparer<VideoItemDirector<string>> sortVideoItemDirector = new SortVideoItemDirector();
                    videoItem.directors.Sort(sortVideoItemDirector);
                    foreach (VideoItemDirector<string> director in videoItem.directors)
                    {
                        dataGridViewActors.Rows.Add(new object[] { director.name, "Director" });
                    }
                }
                if (videoItem.actors != null)
                {
                    IComparer<VideoItemActor<string, string>> sortVideoItemActor = new SortVideoItemActor();
                    videoItem.actors.Sort(sortVideoItemActor);
                    foreach (VideoItemActor<string, string> actor in videoItem.actors)
                    {
                        dataGridViewActors.Rows.Add(new object[] { actor.name, actor.role });
                    }
                }
                // prevent add row from being auto selected
                if (dataGridViewActors.CurrentCell != null)
                {
                    dataGridViewActors.CurrentCell.Selected = false;
                }

            }
            catch (Exception e)
            {
                MyLog.Add(e.ToString());
            }

            this.Parent.Focus();
        }

        public void SetWatched()
        {
            // set watched
            try
            {
                selectedVideoInfo.videoItem.watched = "YES";
                MyFormField.SetCheckBoxChecked(checkBoxWatched, true);
            }
            catch (Exception e)
            {
                MyLog.Add(e.ToString());
            }

            // set last played
            try
            {
                selectedVideoInfo.videoItem.lastPlayed = DateTime.UtcNow;
                MyFormField.SetLabelText(labelLastPlayed, selectedVideoInfo.videoItem.lastPlayed);
            }
            catch (Exception e)
            {
                MyLog.Add(e.ToString());
            }

            // increment play count
            try
            {
                if (comboBoxPlayCount.Text == "")
                {
                    comboBoxPlayCount.Text = "0";
                }
                int playCount = Convert.ToInt32(comboBoxPlayCount.Text) + 1;
                selectedVideoInfo.videoItem.playCount = playCount;
                MyFormField.SetComboBoxValue(comboBoxPlayCount, selectedVideoInfo.videoItem.playCount);
            }
            catch (Exception e)
            {
                MyLog.Add(e.ToString());
            }
        }

        private void linkLabelOpenLink(LinkLabel linkLabel, LinkLabelLinkClickedEventArgs e)
        {
            MyLink.OpenLink(linkLabel, e);
        }














            
    }
}
