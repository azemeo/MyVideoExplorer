using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Threading;

namespace MyVideoExplorer
{
    public partial class SubFormFilterFormTag : UserControl
    {
        private Dictionary<string, string> criteriaTypes;
        public FilterInfo filterInfo;

        // so this user control can update other user controls
        private SubFormFilterForm subFormFilterForm;

        public SubFormFilterFormTag()
        {
            InitializeComponent();

            criteriaTypes = new Dictionary<string, string> { };
            criteriaTypes.Add("genre", "Genre");
            criteriaTypes.Add("files", "Files");
            criteriaTypes.Add("height", "Height");
            criteriaTypes.Add("imdbRating", "IMDB Rating");
            criteriaTypes.Add("mpaa", "MPAA");
            criteriaTypes.Add("playCount", "Play Count");
            criteriaTypes.Add("rating", "Rating");
            criteriaTypes.Add("source", "Source");
            criteriaTypes.Add("sourceAlias", "Source Alias");
            criteriaTypes.Add("tag", "Tag");
            criteriaTypes.Add("version", "Version");
            criteriaTypes.Add("watched", "Watched");
            criteriaTypes.Add("width", "Width");
            criteriaTypes.Add("year", "Year");

            comboBoxCriteria.Items.Clear();
            criteriaTypes.OrderBy(s => s.Value);
            comboBoxCriteria.DataSource = new BindingSource(criteriaTypes, null);
            comboBoxCriteria.DisplayMember = "Value";
            comboBoxCriteria.ValueMember = "Key";
            
            comboBoxCriteria.SelectedIndex = comboBoxCriteria.Items.Count - 1; // last item


        }

        public void AddAccessToSubForms(SubFormFilterForm subFormFilterForm)
        {
            this.subFormFilterForm = subFormFilterForm;
        }

        private void SubFormFilterFormCriteria_Load(object sender, EventArgs e)
        {
            this.MinimumSize = new Size(227, 322);
        }

        private void flowLayoutPanelCriteria_Paint(object sender, PaintEventArgs e)
        {

        }

        private void buttonCriteria_Click(object sender, EventArgs e)
        {
            if (buttonCriteria.Text == "Add Criteria")
            {
                AddCriteria();
            }
            else if (buttonCriteria.Text == "Remove Criteria")
            {
                RemoveCriteria();
            }
        }

        private void comboBoxCriteria_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedCriteriaType = comboBoxCriteria.SelectedValue.ToString();
            if (!criteriaTypes.ContainsKey(selectedCriteriaType)) 
            {
                return;
            }

            buttonCriteria.Text = "Add Criteria";
            string name = "userControlTagCloud_" + selectedCriteriaType;
            int index = 0;
            foreach (Control control in flowLayoutPanelCriteria.Controls)
            {
                if (control.Name == name)
                {
                    buttonCriteria.Text = "Remove Criteria";
                    break;
                }
                index++;
            }
        }



        public void RemoveAllCriteria()
        {
            for (int index = flowLayoutPanelCriteria.Controls.Count - 1; index >= 0; --index)
            {
                flowLayoutPanelCriteria.Controls[index].Dispose(); // mark to be freed from memory
                // flowLayoutPanelCriteria.Controls.RemoveAt(index);
            }

            buttonCriteria.Text = "Add Criteria";
        }

        private void RemoveCriteria()
        {
            string selectedCriteriaType = comboBoxCriteria.SelectedValue.ToString();
            if (!criteriaTypes.ContainsKey(selectedCriteriaType))
            {
                return;
            }

            string name = "userControlTagCloud_" + selectedCriteriaType;
            int index = 0;
            foreach (Control control in flowLayoutPanelCriteria.Controls)
            {
                if (control.Name == name)
                {
                    flowLayoutPanelCriteria.Controls[index].Dispose(); // mark to be freed from memory
                    //flowLayoutPanelCriteria.Controls.RemoveAt(index);
                    break;
                }
                index++;
            }


            buttonCriteria.Text = "Add Criteria";

            NormalizeCriteriaWidth();
        }

        /// <summary>
        /// add criteria based on ui combobox
        /// </summary>
        private void AddCriteria()
        {
            string selectedCriteriaType = comboBoxCriteria.SelectedValue.ToString();
            if (!criteriaTypes.ContainsKey(selectedCriteriaType))
            {
                return;
            }
            AddCriteria(selectedCriteriaType, null);
        }

        /// <summary>
        /// add criteria manually
        /// </summary>
        /// <param name="criteriaType"></param>
        /// <param name="selectedTags"></param>
        private void AddCriteria(string criteriaType, string selectedTags)
        {
            // check if valid criteria type
            if (!criteriaTypes.ContainsKey(criteriaType))
            {
                return;
            }

            // check if criteria already exits, exit if so
            string name = "userControlTagCloud_" + criteriaType;
            int index = 0;
            foreach (Control control in flowLayoutPanelCriteria.Controls)
            {
                if (control.Name == name)
                {
                    return;
                }
                index++;
            }

            VideoInfoStats videoItemStats = CalcVideoInfoStats.GetStats();
            if (videoItemStats == null)
            {
                return;
            }

            flowLayoutPanelCriteria.SuspendLayout();

            MyTagCloud userControlTagCloud = new MyTagCloud();
            userControlTagCloud.Height = 100;
            userControlTagCloud.Name = "userControlTagCloud_" + criteriaType;

            userControlTagCloud.SetTagType(criteriaTypes[criteriaType]);

            List<MyTagCloud.TagItem> tagItems = new List<MyTagCloud.TagItem> { };



            switch (criteriaType)
            {
                case "genre":
                    tagItems = GetTagItemsString(videoItemStats.genre);
                    userControlTagCloud.Height = 70;
                    break;
                case "height":
                    tagItems = GetTagItemsNumeric(videoItemStats.height);
                    userControlTagCloud.Height = 60;
                    break;
                case "imdbRating":
                    tagItems = GetTagItemsNumeric(videoItemStats.imdbRating);
                    userControlTagCloud.Height = 60;
                    break;
                case "mpaa":
                    tagItems = GetTagItemsString(videoItemStats.mpaa);
                    userControlTagCloud.Height = 70;
                    break;
                case "playCount":
                    tagItems = GetTagItemsNumeric(videoItemStats.playCount);
                    userControlTagCloud.Height = 60;
                    break;
                case "rating":
                    tagItems = GetTagItemsNumeric(videoItemStats.rating);
                    userControlTagCloud.Height = 60;
                    break;
                case "source":
                    tagItems = GetTagItemsString(videoItemStats.source);
                    userControlTagCloud.Height = 60;
                    break;
                case "sourceAlias":
                    tagItems = GetTagItemsString(videoItemStats.sourceAlias);
                    userControlTagCloud.Height = 60;
                    break;
                case "tag":
                    tagItems = GetTagItemsString(videoItemStats.tag);
                    userControlTagCloud.Height = 105;
                    break;
                case "version":
                    tagItems = GetTagItemsString(videoItemStats.version);
                    userControlTagCloud.Height = 60;
                    break;
                case "watched":
                    foreach (VideoInfoStatsQty<string, int> item in videoItemStats.watched)
                    {
                        string watched = VideoFileEnums.watched.GetTextByKey(item.Key);
                        tagItems.Add(new MyTagCloud.TagItem(watched, item.Value));
                    }
                    tagItems.Sort((x, y) => x.Name.CompareTo(y.Name) * -1);

                    userControlTagCloud.Height = 35;
                    break;
                case "width":
                    tagItems = GetTagItemsNumeric(videoItemStats.width);
                    userControlTagCloud.Height = 60;
                    break;
                case "year":
                    List<int> yearAdded = new List<int> { };
                    foreach (VideoInfoStatsQty<int, int> item in videoItemStats.year)
                    {
                        // MyLog.Add("add year: " + item.Key.ToString() + " " + item.Value.ToString());
                        tagItems.Add(new MyTagCloud.TagItem(item.Key.ToString(), item.Value));
                        yearAdded.Add(item.Key);
                    }

                    int paddingYears = 2;
                    int currentYear = System.DateTime.UtcNow.Year + paddingYears;
                    int minYear = 1920;

                    for (int year = currentYear; year > minYear; year--)
                    {
                        if (yearAdded.Contains(year))
                        {
                            continue;
                        }
                        tagItems.Add(new MyTagCloud.TagItem(year.ToString(), 0));
                    }
                    tagItems.Sort((x, y) => x.Name.CompareTo(y.Name) * -1);

                    userControlTagCloud.Height = 105;
                    break;
                default:
                    return;
            }
            if (tagItems.Count == 0)
            {
                // TODO btr way to handle no results
                tagItems.Add(new MyTagCloud.TagItem("No results", 0));

                // return;
            }
            userControlTagCloud.AddItems(tagItems, selectedTags);

            flowLayoutPanelCriteria.Controls.Add(userControlTagCloud);

            buttonCriteria.Text = "Remove Criteria";

            NormalizeCriteriaWidth();

            flowLayoutPanelCriteria.ResumeLayout();
        }

        private List<MyTagCloud.TagItem> GetTagItemsString(List<VideoInfoStatsQty<string, int>> stats)
        {
            List<MyTagCloud.TagItem> tagItems = new List<MyTagCloud.TagItem> { };

            foreach (VideoInfoStatsQty<string, int> item in stats)
            {
                tagItems.Add(new MyTagCloud.TagItem(item.Key, item.Value));
            }
            tagItems.Sort((x, y) => x.Name.CompareTo(y.Name) * -1);

            return tagItems;
        }

        private List<MyTagCloud.TagItem> GetTagItemsNumeric(List<VideoInfoStatsQty<decimal, int>> stats)
        {
            List<MyTagCloud.TagItem> tagItems = new List<MyTagCloud.TagItem> { };

            foreach (VideoInfoStatsQty<decimal, int> item in stats)
            {
                tagItems.Add(new MyTagCloud.TagItem(item.Key.ToString(), item.Value));
            }
            tagItems.Sort((x, y) => x.Name.CompareTo(y.Name) * -1);

            return tagItems;
        }

        private List<MyTagCloud.TagItem> GetTagItemsNumeric(List<VideoInfoStatsQty<int, int>> stats)
        {
            List<MyTagCloud.TagItem> tagItems = new List<MyTagCloud.TagItem> { };

            foreach (VideoInfoStatsQty<int, int> item in stats)
            {
                tagItems.Add(new MyTagCloud.TagItem(item.Key.ToString(), item.Value));
            }
            tagItems.Sort((x, y) => x.Name.CompareTo(y.Name) * -1);

            return tagItems;
        }

        private void NormalizeCriteriaWidth()
        {
            // check if vertical scroll bar is present, normalize width of controls
            if (flowLayoutPanelCriteria.VerticalScroll.Visible)
            {
                // vertical scroll bar showing, so reduce width of controls
                foreach (Control control in flowLayoutPanelCriteria.Controls)
                {
                    control.Width = flowLayoutPanelCriteria.Width - MyDPI.ScaleDPIDimension(25);
                }
            }
            else
            {
                // no vertical scroll bar
                foreach (Control control in flowLayoutPanelCriteria.Controls)
                {
                    control.Width = flowLayoutPanelCriteria.Width - MyDPI.ScaleDPIDimension(6);
                }
            }
        }

        /// <summary>
        /// Get tags from criteria tag cloud
        /// </summary>
        /// <param name="name">criteria field name</param>
        /// <param name="val">default value if criteria not found</param>
        /// <returns></returns>
        public string GetCriteria(string name, string val)
        {
            string criteria = GetCriteria(name);
            if (criteria != null)
            {
                val = criteria;
            }
            return val;
        }

        public string GetCriteria(string name)
        {
            string criteria = null;
            Control[] tagClouds = flowLayoutPanelCriteria.Controls.Find(name, false);
            foreach (Control tagCloud in tagClouds)
            {
                Control[] textBoxTagss = tagCloud.Controls.Find("textBoxTags", true);
                foreach (TextBox textBoxTags in textBoxTagss)
                {
                    criteria = textBoxTags.Text;
                }
            }
            return criteria;
        }

        public void SetFilterForm(FilterInfo filterInfo)
        {

            try
            {
                if (filterInfo.filterType == 1)
                {
   
                }
                else if (filterInfo.filterType == 0)
                {
                    foreach (KeyValuePair<string, string> type in criteriaTypes)
                    {
                        string selectedTags = null;

                        switch (type.Key)
                        {
                            case "height":
                                if (String.IsNullOrEmpty(filterInfo.height))
                                {
                                    continue;
                                }
                                selectedTags = filterInfo.height;
                                break;
                            case "imdbRating":
                                if (String.IsNullOrEmpty(filterInfo.imdbRating))
                                {
                                    continue;
                                }
                                selectedTags = filterInfo.imdbRating;
                                break;
                            case "mpaa":
                                if (String.IsNullOrEmpty(filterInfo.mpaa))
                                {
                                    continue;
                                }
                                selectedTags = filterInfo.mpaa;
                                break;
                            case "playCount":
                                if (String.IsNullOrEmpty(filterInfo.playCount))
                                {
                                    continue;
                                }
                                selectedTags = filterInfo.playCount;
                                break;
                            case "rating":
                                if (String.IsNullOrEmpty(filterInfo.rating))
                                {
                                    continue;
                                }
                                selectedTags = filterInfo.rating;
                                break;
                            case "source":
                                if (String.IsNullOrEmpty(filterInfo.source))
                                {
                                    continue;
                                }
                                selectedTags = filterInfo.source;
                                break;
                            case "tag":
                                if (String.IsNullOrEmpty(filterInfo.tag))
                                {
                                    continue;
                                }
                                selectedTags = filterInfo.tag;
                                break;
                            case "watched":
                                if (filterInfo.watched == "ANY")
                                {
                                    selectedTags  = VideoFileEnums.watched.GetTextByKey("YES");
                                    selectedTags += ",";
                                    selectedTags += VideoFileEnums.watched.GetTextByKey("NO");
                                }
                                else if (!VideoFileEnums.watched.KeyExists(filterInfo.watched))
                                {
                                    continue;
                                }
                                else
                                {
                                    selectedTags = VideoFileEnums.watched.GetTextByKey(filterInfo.watched);
                                }
                                break;
                            case "width":
                                if (String.IsNullOrEmpty(filterInfo.height))
                                {
                                    continue;
                                }
                                selectedTags = filterInfo.width;
                                break;
                            case "year":
                                if (String.IsNullOrEmpty(filterInfo.year))
                                {
                                    continue;
                                }
                                selectedTags = filterInfo.year;
                                break;
                            default:
                                continue;            
                        }
                        AddCriteria(type.Key, selectedTags);
                    }
                }

            }
            catch (Exception e)
            {
                MyLog.Add("SetFilterForm: " + e.ToString());
            }

        }

        public FilterInfo GetFilterForm()
        {
            filterInfo = new FilterInfo();

            filterInfo.filterType = 0;

            filterInfo.height = GetCriteria("userControlTagCloud_height", "");
            filterInfo.imdbRating = GetCriteria("userControlTagCloud_imdbRating", "");
            filterInfo.mpaa = GetCriteria("userControlTagCloud_mpaa", "");
            filterInfo.playCount = GetCriteria("userControlTagCloud_playCount", "");
            filterInfo.rating = GetCriteria("userControlTagCloud_rating", "");
            filterInfo.source = GetCriteria("userControlTagCloud_source", "");
            filterInfo.tag = GetCriteria("userControlTagCloud_tag", "");
            filterInfo.width = GetCriteria("userControlTagCloud_width", "");
            filterInfo.year = GetCriteria("userControlTagCloud_year", "");

            string watched = GetCriteria("userControlTagCloud_watched", "");
            if (String.IsNullOrEmpty(watched)) 
            {
                filterInfo.watched = "";
            } 
            else if (watched.Contains(VideoFileEnums.watched.GetTextByKey("YES")) && 
                watched.Contains(VideoFileEnums.watched.GetTextByKey("NO")))
            {
                filterInfo.watched = "ANY";
            } 
            else
            {
                filterInfo.watched = VideoFileEnums.watched.GetKeyByText(watched);
            }

            return filterInfo;
        }

    }
}
