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
using System.IO;

namespace MyVideoExplorer
{

    public partial class SubFormFilterForm : UserControl
    {
        // private bool loadedCurrentFilter = false;

        public FilterInfo filterInfo;

        // so this user control can update other user controls
        private SubFormListView subFormListView;
        private SubFormGallery subFormGallery;
        private SubFormVideoForm subFormVideoForm;
        private SubFormProgress subFormProgress;

        public SubFormFilterForm()
        {
            InitializeComponent();

            InitializeForm();
        }

        public void AddAccessToSubForms(SubFormListView subFormListView, SubFormGallery subFormGallery, SubFormVideoForm subFormVideoForm, SubFormProgress subFormProgress)
        {
            this.subFormListView = subFormListView;
            this.subFormGallery = subFormGallery;
            this.subFormVideoForm = subFormVideoForm;
            this.subFormProgress = subFormProgress;
        }

        private void SubFormFilterForm_Load(object sender, EventArgs e)
        {
            this.MinimumSize = new Size(160, 540);

            this.filterInfo = new FilterInfo();



            subFormFilterFormSelect.AddAccessToSubForms(this);
            subFormFilterFormCriteria.AddAccessToSubForms(this);
            subFormFilterFormPreset.AddAccessToSubForms(this);

            FormMain formMain = (FormMain)this.ParentForm;

            // save <current>
            formMain.FormClosing += new FormClosingEventHandler(ParentForm_FormClosing);

            // meh, but works            
            LoadVideos loadVideos = formMain.GetLoadVideos();
            // when app loaded, filtered/scanned
            loadVideos.loadVideos_Completed += new EventHandler(LoadVideos_Completed);

        }

        protected void LoadVideos_Completed(object sender, EventArgs e)
        {

            SetFilterSelectTagCloud();

        }

        protected void ParentForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            // prevent close
            // e.Cancel = true;

            subFormFilterFormPreset.SaveLastFilter();
        }

        private void subFormFilterFormCriteria_Load(object sender, EventArgs e)
        {

        }

        private void subFormFilterFormSelect_Load(object sender, EventArgs e)
        {

        }

        private void InitializeForm() 
        {
            
            comboBoxSortOrder.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxSortOrder.Items.Clear();
            comboBoxSortOrder.Items.Add("Asc");
            comboBoxSortOrder.Items.Add("Desc");
            comboBoxSortOrder.SelectedIndex = 0;

            comboBoxSortColumn.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBoxSortColumn.Items.Clear();
            comboBoxSortColumn.DataSource = new BindingSource(FilterEnums.sortColumn.ToList().OrderBy(s => s.Value), null);
            comboBoxSortColumn.DisplayMember = "Value";
            comboBoxSortColumn.ValueMember = "Key";
            comboBoxSortColumn.SelectedValue = FilterEnums.sortColumn.GetValueByKey("TITLE");

        }


        private void comboBoxSortColumn_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (subFormListView != null)
            {
                int selectedValue = Convert.ToInt32(comboBoxSortColumn.SelectedValue);

                // if sort by title, show title and year; else show title and sort column
                if (selectedValue == FilterEnums.sortColumn.GetValueByKey("TITLE"))
                {
                    subFormListView.visibleColumnIndex = FilterEnums.sortColumn.GetValueByKey("YEAR");
                }
                else
                {
                    subFormListView.visibleColumnIndex = selectedValue;
                }
            }
        }


        public event EventHandler filterForm_filterVideos;
        private void buttonFilter_Click(object sender, EventArgs e)
        {
            LoadVideos loadVideos = new LoadVideos();
            loadVideos.AddAccessToSubForms(subFormListView, subFormGallery, subFormVideoForm, this, subFormProgress);
            loadVideos.FilterListView();

            // bubble the event up
            if (this.filterForm_filterVideos != null)
            {
                this.filterForm_filterVideos(this, e);
            }
        }

        private void buttonReset_Click(object sender, EventArgs e)
        {
            // clear form
            ResetForm();

            // reset preset drop down
            subFormFilterFormPreset.ResetFilters();

            // meh, let ui refresh before issue filter 
            Thread.Sleep(10);

            // filter
            buttonFilter_Click(sender, e);
        }

        private void textBoxTitle_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBoxTitle_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void textBoxTitle_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                buttonFilter_Click((object)sender, (EventArgs)e);
            }
        }



        public void SetFilterSelectTagCloud()
        {
            subFormFilterFormSelect.SetTagCloud();
        }

        public void SetFilterForm(FilterInfo filterInfo)
        {
            if (filterInfo == null)
            {
                return;
            }
            try 
            {

                tabControlFilter.SuspendLayout();

                if (filterInfo.filterType == 1)
                {
                    tabControlFilter.SelectedIndex = 1;

                    subFormFilterFormSelect.SetFilterForm(filterInfo);
                }
                else if (filterInfo.filterType == 0)
                {
                    tabControlFilter.SelectedIndex = 0;

                    subFormFilterFormCriteria.SetFilterForm(filterInfo);
                }

                tabControlFilter.ResumeLayout();

                textBoxTitle.Text = filterInfo.title;

                SetFilterFormSort(FilterEnums.sortColumn.GetValueByKey(filterInfo.sortColumn), filterInfo.sortOrderIndex);
            }
            catch (Exception e)
            {
                MyLog.Add("SetFilterForm: " + e.ToString());
            }
        }

        public void SetFilterFormSort(int sortColumn, int sortOrder)
        {
            try
            {
                comboBoxSortColumn.SelectedValue = sortColumn;
                comboBoxSortOrder.SelectedIndex = sortOrder;
            }
            catch (Exception e)
            {
                MyLog.Add("SetFilterFormSort: " + e.ToString());
            }
        }

        public void ResetForm()
        {
            // clear form
            textBoxTitle.Text = "";

            tabControlFilter.SuspendLayout();

            subFormFilterFormSelect.RemoveAllCriteria();

            subFormFilterFormCriteria.RemoveAllCriteria();

            tabControlFilter.SelectedIndex = 0;

            tabControlFilter.ResumeLayout();
        }

 
        public FilterInfo GetFilterForm()
        {
            filterInfo = new FilterInfo();

            if (tabControlFilter.SelectedIndex == 1)
            {
                filterInfo.filterType = 1;
                filterInfo = subFormFilterFormSelect.GetFilterForm();
            }
            else if (tabControlFilter.SelectedIndex == 0)
            {
                filterInfo.filterType = 0;
                filterInfo = subFormFilterFormCriteria.GetFilterForm();
            }

            if (textBoxTitle.Text.Length > 0)
            {
                filterInfo.title = textBoxTitle.Text;
            }
            else
            {
                filterInfo.title = "";
            }

            // sort filters
            if (comboBoxSortColumn != null && comboBoxSortColumn.SelectedValue != null)
            {
                int selectedValue = Convert.ToInt32(comboBoxSortColumn.SelectedValue);
                filterInfo.sortColumn = FilterEnums.sortColumn.GetKeyByValue(selectedValue);
            }
            
            filterInfo.sortOrderIndex = comboBoxSortOrder.SelectedIndex;

            return filterInfo;
        }


















 
    }
}
