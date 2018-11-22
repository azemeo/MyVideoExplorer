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
    public partial class FormSources : Form
    {
        private int aliasWidth = 200;
        private int typeWidth = 50;
        private int scannedWidth = 150;

        private bool scanning;
        private ConfigSettings.Source currentSource;

        public FormSources()
        {
            InitializeComponent();

            listViewSource.HideSelection = false;
            listViewSource.MultiSelect = false;
        }

        private void FormSources_Load(object sender, EventArgs e)
        {
            listViewSource.Items.Clear();
            try
            {
                foreach (ConfigSettings.Source source in Config.settings.sources)
                {
                    string lastScanned = "Not yet";
                    if (source.lastScanned != DateTime.MinValue)
                    {
                        lastScanned = source.lastScanned.ToLocalTime().ToString();
                    }
                    ListViewItem lvi = new ListViewItem(source.alias);
                    lvi.SubItems.Add(source.type);
                    lvi.SubItems.Add(lastScanned);
                    listViewSource.Items.Add(lvi);
                }


                comboBoxType.DropDownStyle = ComboBoxStyle.DropDownList;
                comboBoxType.Items.Clear();
                comboBoxType.DataSource = new BindingSource(VideoFileEnums.sourceType.ToList(), null);
                comboBoxType.DisplayMember = "Value";
                comboBoxType.ValueMember = "Key";
                comboBoxType.SelectedIndex = 0;
                comboBoxType.Enabled = false; // only movies so fr
            }
            catch (Exception ex1)
            {
                MyLog.Add(ex1.ToString());
            }

            subFormProgressOptions.SetTextAlignment(ContentAlignment.MiddleCenter);


            scanning = false;
        }

        private void FormSources_Shown(object sender, EventArgs e)
        {
            MyFormField.HighlightTextBoxesOnFocus(this);

            ClearSourceForm();

            ResizeColumns();

            if (Config.settings.sources.Count == 0)
            {
                buttonAddSource_Click(sender, e);
                return;
            }
        }

        private void FormSources_FormClosing(object sender, FormClosingEventArgs e)
        {

        }

        private void tabPageSource_Click(object sender, EventArgs e)
        {

        }

        private void buttonSaveSource_Click(object sender, EventArgs e)
        {
            string alias = textBoxAlias.Text.Trim();
            string type = VideoFileEnums.sourceType.GetTextByValue(comboBoxType.SelectedValue);
            string directory = textBoxDirectory.Text.Trim();

            string message = "";
            if (alias == "")
            {
                message += "Enter an Alias for this Video Source." + Environment.NewLine;
            }
            if (directory.Length < 3)
            {
                message += "Select a Directory for this Video Source" + Environment.NewLine;
            }
            foreach (ListViewItem listViewItemCheck in listViewSource.Items)
            {
                string aliasCheck = listViewItemCheck.SubItems[0].Text;
                string directoryCheck = listViewItemCheck.SubItems[1].Text;

                if (alias == aliasCheck)
                {
                    message += "Alias [" + alias + "] already exists." + Environment.NewLine;
                    message += "Enter an unique Alias for this Video Source." + Environment.NewLine;
                }
                if (directory == directoryCheck)
                {
                    message += "Directory [" + directory + "] already exists." + Environment.NewLine;
                    message += "Select an unique Directory for this Video Source." + Environment.NewLine;
                }

            }
            if (message != "")
            {
                MessageBox.Show(message);
                return;
            }

            // add to source list
            alias = MyFile.SafeFileName(alias);
            directory = MyFile.SafeDirectory(directory);
            ListViewItem listViewItem = new ListViewItem(alias);
            listViewItem.SubItems.Add(type);
            listViewItem.SubItems.Add("");
            listViewSource.Items.Add(listViewItem);

            // add to settings
            ConfigSettings.Source source = new ConfigSettings.Source();
            source.alias = alias;
            source.directory = directory;
            source.type = type;
            Config.settings.sources.Add(source);

            // clear form
            ClearSourceForm();

            buttonSaveSource.Enabled = false; // no edits

            // select added item and infer scan
            listViewItem = listViewSource.FindItemWithText(source.alias);
            if (listViewItem != null)
            {
                listViewItem.Selected = true;
            }
            buttonScanSource.Focus();

            // video list ui will be update when user rescans
            // video list xml will be updated on main form close
            // settings xml will be updated on main form close, and options form closes
        }

        private void buttonAddSource_Click(object sender, EventArgs e)
        {
            ClearSourceForm();

            textBoxAlias.Enabled = true;
            textBoxDirectory.Enabled = true;
            comboBoxType.Enabled = false; // only movies so far
            comboBoxType.SelectedIndex = 0;

            buttonAddSource.Enabled = false;
            buttonSourceDirectory.Enabled = true;
            buttonSaveSource.Enabled = true;
            buttonScanSource.Enabled = false;
            buttonRemoveSource.Enabled = false;

            subFormProgressOptions.Text("Pending Save");

            textBoxAlias.Focus();
        }


        private void buttonRemoveSource_Click(object sender, EventArgs e)
        {
            MyFormField.DelayButtonClick(buttonRemoveSource);

            if (currentSource == null)
            {
                return;
            }
            
            string message = "Are you sure you want to remove this Video Source?"+Environment.NewLine;
            message += "Alias: " + currentSource.alias + Environment.NewLine;
            message += "Type: " + currentSource.type + Environment.NewLine;
            message += "Directory: " + currentSource.directory + Environment.NewLine;
            string lastScanned = currentSource.lastScanned.ToLocalTime().ToString();
            if (currentSource.lastScanned == DateTime.MinValue)
            {
                lastScanned = "Not yet";
            }
            message += "Last Scanned: " + lastScanned + Environment.NewLine;

            if (MessageBox.Show(message, "Confirm Removal",
                MessageBoxButtons.YesNo, MessageBoxIcon.Question,
                MessageBoxDefaultButton.Button2) == System.Windows.Forms.DialogResult.Yes)
            {
                listViewSource.SelectedItems[0].Remove();
       

                // remove entry from settings
                Config.settings.sources.Remove(currentSource);

                List<VideoInfo> currentVideoInfos = ListVideoInfo.GetList();
                int nbrOrigVideoInfos = currentVideoInfos.Count();
                currentVideoInfos.RemoveAll(s => s.sourceAlias == currentSource.alias);
                int nbrRemovedVideoInfos = nbrOrigVideoInfos - currentVideoInfos.Count();
                ListVideoInfo.SetList(currentVideoInfos);

                // meh, but works
                FormMain formMain = (FormMain)this.Owner;
                SubFormListView subFormListView = formMain.GetSubFormListView();
                subFormListView.SetListViewInfos(ListVideoInfo.GetList());

                MyLog.Add("Removed " + currentSource.alias + " and it's " + nbrRemovedVideoInfos + " VideoItems");

                // datatable xml will be updated on main form close
                // settings xml will be updated on main form close

                currentSource = null;
                buttonRemoveSource.Enabled = false;
            }

        }

        private void buttonSourceBrowse_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog folderBrowserDialog = new FolderBrowserDialog();
            if (textBoxDirectory.Text != "" && textBoxDirectory.Text.Length > 2)
            {
                folderBrowserDialog.SelectedPath = textBoxDirectory.Text;
            }

            if (folderBrowserDialog.ShowDialog() == DialogResult.Cancel)
            {
                return;
            }
            else
            {
                textBoxDirectory.Text = folderBrowserDialog.SelectedPath;
                if (textBoxAlias.Text == "")
                {
                    string alias = folderBrowserDialog.SelectedPath.Substring(folderBrowserDialog.SelectedPath.LastIndexOf(@"\") + 1);
                    MyFormField.SetTextBoxText(textBoxAlias, MyFile.SafeFileName(alias));
                }
            }
        }

        private void listViewSource_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (scanning)
            {
                // revert to scanning source
                if (currentSource != null)
                {
                    ListViewItem listViewItem = listViewSource.FindItemWithText(currentSource.alias);
                    if (listViewItem != null)
                    {
                        listViewItem.Selected = true;
                    }
                }
                return;
            }

            if (listViewSource.SelectedItems.Count == 0)
            {
                ClearSourceForm();

                buttonRemoveSource.Enabled = false;
                buttonScanSource.Enabled = false;
                buttonAddSource.Enabled = true;
            }
            else
            {
                ListViewItem selectedItem = listViewSource.SelectedItems[0];
                string alias = selectedItem.SubItems[0].Text;

                ConfigSettings.Source source = Config.GetSourceByAlias(alias);
                if (source == null)
                {
                    return;
                }

                currentSource = source;

                MyFormField.SetTextBoxText(textBoxAlias, source.alias);
                MyFormField.SetComboBoxValue(comboBoxType, source.type);
                MyFormField.SetLabelText(labelLastScanned, source.lastScanned);
                MyFormField.SetTextBoxText(textBoxDirectory, source.directory);

                CalcStatsForSource(source);

                textBoxAlias.Enabled = false;
                textBoxDirectory.Enabled = false;
                comboBoxType.Enabled = false;

                buttonAddSource.Enabled = true;
                buttonSourceDirectory.Enabled = false;
                buttonRemoveSource.Enabled = true;
                buttonSaveSource.Enabled = false;
                buttonScanSource.Enabled = true;
                subFormProgressOptions.Text("Ready");
            }

        }

        private void tabControlSettings_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }


        private void buttonClose_Click(object sender, EventArgs e)
        {

            Close();
        }


        private void buttonScan_Click(object sender, EventArgs e)
        {
            if (currentSource == null)
            {
                return;
            }

            buttonSourceDirectory.Enabled = false;
            buttonSaveSource.Enabled = false;
            buttonScanSource.Enabled = false;
            buttonRemoveSource.Enabled = false;
            buttonAddSource.Enabled = false;

            // meh, but works
            FormMain formMain = (FormMain)this.Owner;
            LoadVideos loadVideos = formMain.GetLoadVideos();
            loadVideos.loadVideos_Completed += new EventHandler(LoadVideos_Completed);
            loadVideos.AddAccessToSubFormProgress(subFormProgressOptions);
            loadVideos.LoadFromDisk(currentSource);
        }

        protected void LoadVideos_Completed(object sender, EventArgs e)
        {


            currentSource.lastScanned = DateTime.UtcNow;
            MyFormField.SetLabelText(labelLastScanned, currentSource.lastScanned);
            ListViewItem listViewItem = listViewSource.FindItemWithText(currentSource.alias);
            if (listViewItem != null)
            {
                listViewItem.SubItems[2].Text = currentSource.lastScanned.ToLocalTime().ToString();
            }

            CalcStatsForSource(currentSource);

            int sourceIndex = Config.settings.sources.FindIndex(x => x.alias == currentSource.alias);
            Config.settings.sources[sourceIndex] = currentSource;


            buttonSourceDirectory.Enabled = true;
            buttonScanSource.Enabled = true;
            buttonRemoveSource.Enabled = true;
            buttonAddSource.Enabled = true;
            scanning = false;
        }


 



        private void CalcStatsForSource(ConfigSettings.Source source)
        {
            List<VideoInfo> listVideoInfos = ListVideoInfo.GetList();
            if (listVideoInfos == null)
            {
                return;
            }

            listVideoInfos = listVideoInfos.FindAll(x => x.sourceAlias == source.alias).ToList();
            if (listVideoInfos == null)
            {
                return;
            }

            int nbrVideos = listVideoInfos.Where(x => x.files != null && x.files.video != null).Count();

            // int nbrPosters = listVideoInfos.Where(x => x.files != null && x.files.poster != null).Count();
            // int nbrFanarts = listVideoInfos.Where(x => x.files != null && x.files.fanart != null).Count();
            // int nbrImages = listVideoInfos.Where(x => x.files != null && x.files.images != null).Count();

            // int nbrMBs = listVideoInfos.Where(x => x.files != null && x.files.mb != null).Count();
            // int nbrMVEs = listVideoInfos.Where(x => x.files != null && x.files.mve != null).Count();
            // int nbrXBMCs = listVideoInfos.Where(x => x.files != null && x.files.xbmc != null).Count();

            // int nbrOthers = listVideoInfos.Where(x => x.files != null && x.files.others != null).Count();

            int nbrFiles = listVideoInfos.Where(x => x.files != null).Sum(x => x.files.qty);

            // int nbrNonVideos = nbrImages + nbrMBs + nbrMVEs + nbrXBMCs + nbrOthers;
            int nbrNonVideos = nbrFiles - nbrVideos;


            labelVideoFileQty.Text = nbrVideos.ToString();


            labelOtherFilesQty.Text = nbrNonVideos.ToString();

        }

        private void ClearSourceForm()
        {
            MyFormField.SetTextBoxText(textBoxAlias, "");
            MyFormField.SetComboBoxValue(comboBoxType, VideoFileEnums.sourceType.defaultValue);
            comboBoxType.SelectedIndex = 0;
            MyFormField.SetTextBoxText(textBoxDirectory, "");
            MyFormField.SetLabelText(labelLastScanned, "-");

            MyFormField.SetLabelText(labelVideoFileQty, "-");
            MyFormField.SetLabelText(labelOtherFilesQty, "-");

            subFormProgressOptions.Text("Select a Source");
            subFormProgressOptions.Value(0);
          
            buttonRemoveSource.Enabled = false;
            buttonScanSource.Enabled = false;
        }

        /// <summary>
        /// auto adjust title column width
        /// </summary>
        public void ResizeColumns()
        {
            aliasWidth = listViewSource.Width - typeWidth - scannedWidth - MyDPI.ScaleDPIDimension(5);

            listViewSource.Columns[0].Width = aliasWidth;
            listViewSource.Columns[1].Width = typeWidth;
            listViewSource.Columns[2].Width = scannedWidth;
        }








    }
}
