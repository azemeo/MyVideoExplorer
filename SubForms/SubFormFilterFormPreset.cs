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
using System.Text.RegularExpressions;

namespace MyVideoExplorer
{
    public partial class SubFormFilterFormPreset : UserControl
    {
        // meh, but works
        private bool allow_comboBoxPreset_SelectedIndexChanged = true;

        // so this user control can update other user controls
        private SubFormFilterForm subFormFilterForm;

        public SubFormFilterFormPreset()
        {
            InitializeComponent();
        }

        public void AddAccessToSubForms(SubFormFilterForm subFormFilterForm)
        {
            this.subFormFilterForm = subFormFilterForm;

        }

        private void SubFormFilterFormPreset_Load(object sender, EventArgs e)
        {
            this.MinimumSize = new Size(245, 45);

            // lame, but for loading timing issues where config set after sub form load, 
            // TODO btr way of making sure config is set before sub forms load .. or do call backs or something
            // app non configurable, so far, settings
            Config.settings.exportFormat = "json";
            Config.settings.exportExt = "json"; // chicken egg

            comboBoxFilters.Sorted = true;

            // load saved filters
            LoadFilters();


        }





        private void buttonSave_Click(object sender, EventArgs e)
        {
            if (comboBoxFilters.Items.Count == 0)
            {
                return;
            }
            var filterName = comboBoxFilters.Text;
            if (filterName.Length == 0)
            {
                return;
            }
            SaveFilter();

            filterName = comboBoxFilters.Text;
            if (!comboBoxFilters.Items.Contains(filterName))
            {
                comboBoxFilters.Items.Add(filterName);
                
            }

        }

        private void buttonDelete_Click(object sender, EventArgs e)
        {
            if (comboBoxFilters.Items.Count == 0)
            {
                return;
            }
            string filterName = comboBoxFilters.Text;
            if (filterName.Length == 0)
            {
                return;
            }
            DeleteFilter(filterName);
        }

        private void comboBoxFilters_TextChanged(object sender, EventArgs e)
        {
            string filterName = comboBoxFilters.Text;
            if (filterName == "<_reset_>" || filterName == "<filter when closed>" || filterName == "<last saved filter>")
            {
                buttonSave.Enabled = false;
                buttonDelete.Enabled = false;
            }
            else
            {
                buttonSave.Enabled = true;
                buttonDelete.Enabled = true;
            }
        }


        // user or program changed combobox
        private void comboBoxPreset_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (!allow_comboBoxPreset_SelectedIndexChanged)
            {
                return;
            }
            LoadSelectedFilter();
        }

        // user change combobox, but before text changed
        private void comboBoxFilters_SelectionChangeCommitted(object sender, EventArgs e)
        {
            
        }




        public void ResetFilters()
        {
            comboBoxFilters.SelectedIndex = comboBoxFilters.Items.IndexOf("<_reset_>");
        }

        protected bool LoadSelectedFilter()
        {
            if (comboBoxFilters.Items.Count == 0)
            {
                return false;
            }
            if (subFormFilterForm == null)
            {
                return false;
            }

            string filterName = comboBoxFilters.Text;
            if (filterName.Length == 0)
            {
                return false;
            }
            if (filterName == "<_reset_>")
            {
                subFormFilterForm.ResetForm();
                return true;
            }
            if (filterName == "<filter when closed>")
            {
                filterName = "filter when closed";
            }
            else if (filterName == "<last saved filter>")
            {
                filterName = "last saved filter";
            }

            FilterInfo filterInfo = new FilterInfo(); // subFormFilterForm.GetFilterForm();
            string dataFile = MyFile.EnsureDataFile("Filter", Config.settings.exportExt, "filters", filterName);
            // MessageBox.Show(dataFile);
            if (File.Exists(dataFile))
            {
                // load filter preset                
                filterInfo = (FilterInfo)MyDeserialize.FromFile(Config.settings.exportFormat, dataFile, filterInfo);

                if (filterInfo == null)
                {
                    MessageBox.Show("Unable to load Filter [" + filterName + "]");
                    return false;
                }

                subFormFilterForm.ResetForm();

                subFormFilterForm.SetFilterForm(filterInfo);
                MyLog.Add("Loaded Filter Preset " + dataFile.Replace(MyFile.exeDirectory, ""));

                return true;
            }
            return false;
            
        }

        public bool LoadFilters()
        {
            // also ensures directory filter exists
            string dataFile = MyFile.EnsureDataFile("Filter", Config.settings.exportExt, "filters");

            IEnumerable<string> files = MyFile.EnumerateFiles("filters", "Filter_*." + Config.settings.exportExt);

            comboBoxFilters.SuspendLayout();

            comboBoxFilters.Items.Clear();
            comboBoxFilters.Items.Add("<_reset_>");
            comboBoxFilters.Items.Add("<filter when closed>");
            comboBoxFilters.Items.Add("<last saved filter>");
            comboBoxFilters.SelectedIndex = 0;
            if (files.Count() > 0)
            {
                Regex regexIgnoreBackups = new Regex(@"\.[0-9]\." + Config.settings.exportExt);
                foreach (string file in files)
                {
                    if (regexIgnoreBackups.IsMatch(file))
                    {
                        continue;
                    }
                    string filterName = file.Replace(@"filters\", "");
                    filterName = filterName.Replace(@"." + Config.settings.exportExt, "");
                    filterName = filterName.Replace(@"Filter_", "");
                    if (filterName == "_reset_" || filterName == "filter when closed" || filterName == "last saved filter")
                    {
                        continue;
                    }
                    comboBoxFilters.Items.Add(filterName);
                }
            }

            comboBoxFilters.ResumeLayout();
            return true;
        }

        public bool DeleteFilter(string preset)
        {
            bool ret = false;
            if (MessageBox.Show("Delete Filter Preset [" + preset + "]", "Filter Preset", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                string dataFile = MyFile.EnsureDataFile("Filter", Config.settings.exportExt, "filters", preset);
                // MessageBox.Show(dataFile);
                if (MyFile.DeleteFile(dataFile))
                {
                    // MessageBox.Show("Deleted Filter Preset [" + preset + "]");
                    comboBoxFilters.Items.Remove(comboBoxFilters.SelectedItem);
                    LoadFilters();
                    // subFormFilterForm.ResetForm();
                    ret = true;
                }
                else
                {
                    MessageBox.Show("Error deleting Filter Preset [" + preset + "]");
                }
            }
            return ret;
        }

        public bool SaveLastFilter()
        {
            return SaveFilter("<filter when closed>");
        }

        public bool SaveFilter()
        {
            string filterName = comboBoxFilters.Text;
            return SaveFilter(filterName);
        }
        public bool SaveFilter(string filterName)
        {
            
            if (filterName.Length == 0)
            {
                return false;
            }
            string dataFile;
            if (filterName == "<_reset_>")
            {
                MessageBox.Show("Cannot Save filter");
                subFormFilterForm.ResetForm();
                return false;
            }
            else if (filterName == "<filter when closed>")
            {
                dataFile = MyFile.EnsureDataFile("Filter", Config.settings.exportExt, "filters", "filter when closed");
                if (dataFile == null)
                {
                    return false;
                }
            }
            else if (filterName == "<last saved filter>")
            {
                MessageBox.Show("Cannot Save filter.\nThis Filter will be automaticlly be saved when you Save another Filter.");
                return false;
            }
            else
            {
                filterName = MyFile.SafeFileName(filterName);
                dataFile = MyFile.EnsureDataFile("Filter", Config.settings.exportExt, "filters", filterName);
                if (dataFile == null)
                {
                    return false;
                }
                allow_comboBoxPreset_SelectedIndexChanged = false;
                comboBoxFilters.Text = filterName;
                allow_comboBoxPreset_SelectedIndexChanged = true;
            }

            FilterInfo filterInfo = subFormFilterForm.GetFilterForm();

            MyLog.RotateFiles(dataFile);

            filterInfo.about = Config.GetConfigSettingsAbout();
            filterInfo.name = filterName;
            if (filterInfo.description == null)
            {
                filterInfo.description = "";
            }

            MySerialize.ToFile(Config.settings.exportFormat, dataFile, filterInfo);

            MyLog.Add("Saved Filter Preset " + dataFile.Replace(MyFile.exeDirectory, ""));

            // make a copy of last saved filter
            if (filterName != "<last saved filter>" && filterName != "<filter when closed>")
            {
                dataFile = MyFile.EnsureDataFile("Filter", Config.settings.exportExt, "filters", "last saved filter");
                if (dataFile == null)
                {
                    return false;
                }
                MyLog.RotateFiles(dataFile);


                MySerialize.ToFile(Config.settings.exportFormat, dataFile, filterInfo);
                MyLog.Add("Saved Filter Preset " + dataFile.Replace(MyFile.exeDirectory, ""));
            }


            return true;
        }





    }
}
