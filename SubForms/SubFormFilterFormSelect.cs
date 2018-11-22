using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyVideoExplorer.SubForms
{
    public partial class SubFormFilterFormSelect : UserControl
    {
        public FilterInfo filterInfo;

        // so this user control can update other user controls
        private SubFormFilterForm subFormFilterForm;

        public SubFormFilterFormSelect()
        {
            InitializeComponent();

            InitializeForm();
        }

        private void SubFormFilterFormSelect_Load(object sender, EventArgs e)
        {
            this.MinimumSize = new Size(227, 322);


        }

        public void AddAccessToSubForms(SubFormFilterForm subFormFilterForm)
        {
            this.subFormFilterForm = subFormFilterForm;
        }

        private void InitializeForm()
        {
            // tag clicked
            userControlTagCloud.TagClicked += new MyTagCloud.TagClickedHandler(userControlTagCloud_TagClicked);


            // initialize select form
            comboBoxYearFrom.Items.Clear();
            comboBoxYearTo.Items.Clear();
            int paddingYears = 2;
            int currentYear = System.DateTime.UtcNow.Year + paddingYears;
            int minYear = 1920;
            for (int year = minYear; year < currentYear; year++)
            {
                comboBoxYearFrom.Items.Add(year);
            }
            for (int year = currentYear; year > minYear; year--)
            {
                comboBoxYearTo.Items.Add(year);
            }
            comboBoxYearFrom.SelectedIndex = 0; // minYear
            comboBoxYearTo.SelectedIndex = paddingYears; // now

            comboBoxPlayCountFrom.Items.Clear();
            comboBoxPlayCountTo.Items.Clear();
            comboBoxPlayCountFrom.Items.Add("Any");
            comboBoxPlayCountTo.Items.Add("Any");
            int nbrPlayCounts = 20;
            for (int playCount = 0; playCount <= nbrPlayCounts; playCount++)
            {
                comboBoxPlayCountFrom.Items.Add(playCount);
                comboBoxPlayCountTo.Items.Add(nbrPlayCounts - playCount);
            }
            comboBoxPlayCountFrom.SelectedIndex = 0;
            comboBoxPlayCountTo.SelectedIndex = 0;

            comboBoxIMDBRatingFrom.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxIMDBRatingTo.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxIMDBRatingFrom.Items.Clear();
            comboBoxIMDBRatingTo.Items.Clear();
            comboBoxIMDBRatingFrom.Items.Add("Any");
            comboBoxIMDBRatingTo.Items.Add("Any");
            int nbrIMDBRatings = 10;
            for (int playCount = 0; playCount <= nbrIMDBRatings; playCount++)
            {
                comboBoxIMDBRatingFrom.Items.Add(playCount);
                comboBoxIMDBRatingTo.Items.Add(nbrIMDBRatings - playCount);
            }
            comboBoxIMDBRatingFrom.SelectedIndex = 0;
            comboBoxIMDBRatingTo.SelectedIndex = 0;

            comboBoxRatingFrom.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxRatingTo.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxRatingFrom.Items.Clear();
            comboBoxRatingTo.Items.Clear();
            comboBoxRatingFrom.Items.Add("Any");
            comboBoxRatingTo.Items.Add("Any");
            int nbrRatings = 10;
            for (int playCount = 0; playCount <= nbrRatings; playCount++)
            {
                comboBoxRatingFrom.Items.Add(playCount);
                comboBoxRatingTo.Items.Add(nbrRatings - playCount);
            }
            comboBoxRatingFrom.SelectedIndex = 0;
            comboBoxRatingTo.SelectedIndex = 0;

            comboBoxWatched.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxWatched.Items.Clear();
            comboBoxWatched.DataSource = new BindingSource(VideoFileEnums.watched.ToList(), null);
            comboBoxWatched.DisplayMember = "Value";
            comboBoxWatched.ValueMember = "Key";
            comboBoxWatched.SelectedIndex = 0;

            comboBoxMPAA.DropDownStyle = ComboBoxStyle.DropDown;
            comboBoxMPAA.Items.Clear();
            comboBoxMPAA.Items.Add("Any");
            comboBoxMPAA.Items.Add("G");
            comboBoxMPAA.Items.Add("PG");
            comboBoxMPAA.Items.Add("PG-13");
            comboBoxMPAA.Items.Add("R");
            comboBoxMPAA.Items.Add("NC-17");
            comboBoxMPAA.SelectedIndex = 0;

            comboBoxSource.DropDownStyle = ComboBoxStyle.DropDown;
            comboBoxSource.Items.Clear();
            comboBoxSource.Items.Add("Any");
            comboBoxSource.Items.Add("Bluray");
            comboBoxSource.Items.Add("DVD");
            comboBoxSource.Items.Add("Stream");
            comboBoxSource.SelectedIndex = 0;

            // tag cloud set in calcStats_Completed()
        }


        private void userControlTagCloud_TagClicked(object sender, MyTagCloud.TagClickedEventArgs e)
        {
            MyTagCloud.TagItem tagItem = e.Item;

        }

        public void SetTagCloud()
        {
            VideoInfoStats videoItemStats = CalcVideoInfoStats.GetStats();
            // MessageBox.Show("SetTagCloud");
            if (videoItemStats != null)
            {
                userControlTagCloud.Empty();

                List<MyTagCloud.TagItem> tagItems = new List<MyTagCloud.TagItem> { };
                foreach (VideoInfoStatsQty<string, int> item in videoItemStats.tag)
                {
                    tagItems.Add(new MyTagCloud.TagItem(item.Key.ToString(), item.Value));
                }
                tagItems.Sort((x, y) => x.Name.CompareTo(y.Name) * -1);

                userControlTagCloud.Height = 105;
                userControlTagCloud.AddItems(tagItems);
            }
        }

        private void SetFilterFormComboBoxAny(ComboBox comboBox, int val)
        {
            if (val == -1)
            {
                comboBox.Text = "Any";
            }
            else
            {
                comboBox.Text = val.ToString();
            }
        }

        private void SetFilterFormComboBoxAny(ComboBox comboBox, string val)
        {
            if (val == null)
            {
                comboBox.Text = "Any";
            }
            else
            {
                comboBox.Text = val;
            }
        }


        private int GetFilterFormComboBoxInt(ComboBox comboBox)
        {
            int val = 0;
            if (comboBox.SelectedItem == null)
            {
                val = 0;
            }
            else if (comboBox.SelectedItem.ToString().Length > 0)
            {
                val = Convert.ToInt32(comboBox.Text);
            }
            else
            {
                val = 0;
            }
            return val;
        }

        private int GetFilterFormComboBoxAnyInt(ComboBox comboBox)
        {
            int val = 0;
            if (comboBox.SelectedItem == null)
            {
                val = -1;
            }
            else if (comboBox.SelectedItem.ToString().Length > 0)
            {
                if (comboBox.Text == "Any")
                {
                    val = -1;
                }
                else
                {
                    val = Convert.ToInt32(comboBox.Text);
                }
            }
            else
            {
                val = -1;
            }
            return val;
        }

        private string GetFilterFormComboBoxAnyString(ComboBox comboBox)
        {
            string val = null;
            if (comboBox.SelectedItem == null)
            {
                val = null;
            }
            else if (comboBox.SelectedItem.ToString().Length > 0)
            {
                if (comboBox.Text == "Any")
                {
                    val = null;
                }
                else
                {
                    val = comboBox.Text;
                }
            }
            else
            {
                val = null;
            }
            return val;
        }




        public void RemoveAllCriteria()
        {
            comboBoxYearFrom.Text = "1920";
            comboBoxYearTo.Text = System.DateTime.UtcNow.Year.ToString();
            comboBoxPlayCountFrom.Text = "Any";
            comboBoxPlayCountTo.Text = "Any";
            comboBoxWatched.SelectedIndex = 0;
            comboBoxMPAA.SelectedIndex = 0;
            comboBoxIMDBRatingFrom.SelectedIndex = 0;
            comboBoxIMDBRatingTo.SelectedIndex = 0;
            comboBoxRatingFrom.SelectedIndex = 0;
            comboBoxRatingTo.SelectedIndex = 0;
            comboBoxSource.SelectedIndex = 0;
        }

        public void SetFilterForm(FilterInfo filterInfo)
        {
            try
            {
                if (filterInfo.filterType == 1)
                {
                    comboBoxYearFrom.Text = filterInfo.yearFrom.ToString();
                    comboBoxYearTo.Text = filterInfo.yearTo.ToString();
                    SetFilterFormComboBoxAny(comboBoxPlayCountFrom, filterInfo.playCountFrom);
                    SetFilterFormComboBoxAny(comboBoxPlayCountTo, filterInfo.playCountTo);
                    SetFilterFormComboBoxAny(comboBoxIMDBRatingFrom, filterInfo.imdbRatingFrom);
                    SetFilterFormComboBoxAny(comboBoxIMDBRatingTo, filterInfo.imdbRatingTo);
                    SetFilterFormComboBoxAny(comboBoxRatingFrom, filterInfo.ratingFrom);
                    SetFilterFormComboBoxAny(comboBoxRatingTo, filterInfo.ratingTo);
                    SetFilterFormComboBoxAny(comboBoxSource, filterInfo.source);

                    if (comboBoxWatched.Items.Count > 0 && VideoFileEnums.watched.KeyExists(filterInfo.watched))
                    {
                        comboBoxWatched.SelectedValue = VideoFileEnums.watched.GetValueByKey(filterInfo.watched);
                    }
                }
                else if (filterInfo.filterType == 0)
                {

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
            
            // selectbox filters
            filterInfo.filterType = 1;

            filterInfo.yearFrom = GetFilterFormComboBoxInt(comboBoxYearFrom);
            filterInfo.yearTo = GetFilterFormComboBoxInt(comboBoxYearTo);

            filterInfo.playCountFrom = GetFilterFormComboBoxAnyInt(comboBoxPlayCountFrom);
            filterInfo.playCountTo = GetFilterFormComboBoxAnyInt(comboBoxPlayCountTo);

            filterInfo.imdbRatingFrom = GetFilterFormComboBoxAnyInt(comboBoxIMDBRatingFrom);
            filterInfo.imdbRatingTo = GetFilterFormComboBoxAnyInt(comboBoxIMDBRatingTo);

            filterInfo.ratingFrom = GetFilterFormComboBoxAnyInt(comboBoxRatingFrom);
            filterInfo.ratingTo = GetFilterFormComboBoxAnyInt(comboBoxRatingTo);

            filterInfo.source = GetFilterFormComboBoxAnyString(comboBoxSource);

            if (!String.IsNullOrEmpty(comboBoxWatched.Text))
            {
                filterInfo.watched = VideoFileEnums.watched.GetKeyByValue((int)comboBoxWatched.SelectedValue);
            }
            else
            {
                filterInfo.watched = "ANY";
            }

            // condese tags into comma list 
            // TODO? better to leave in a list? maybe so .. but using simple string conatins for fitlering
            List<MyTagCloud.TagItem> selectedTagItems = userControlTagCloud.GetSelectedTags();
            filterInfo.tag = "";
            foreach (MyTagCloud.TagItem selectedTagItem in selectedTagItems)
            {
                filterInfo.tag += "," + selectedTagItem.Name;
            }
            filterInfo.tag = filterInfo.tag.TrimStart(',');

            return filterInfo;
        }
    }
}
