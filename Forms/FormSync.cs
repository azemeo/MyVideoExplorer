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
using System.Text.RegularExpressions;
using System.Net;
using System.Threading;

namespace MyVideoExplorer
{
    public partial class FormSync : Form
    {
        private int nameWidth = 150;
        private int qtyWidth = 45;
        private int sizeWidth = 50;

        private string apiKey = "ABC123";
        private string apiURL = "http://127.0.0.1/myvideoexplorer/upload.php";

        public FormSync()
        {
            InitializeComponent();
        }



        private void FormSync_Load(object sender, EventArgs e)
        {
            listViewSyncUp.View = View.Details;
            listViewSyncUp.FullRowSelect = true;
            listViewSyncUp.Sorting = SortOrder.Ascending;
            listViewSyncUp.HideSelection = false; // keep selection highlighted (grey) on blur

            listViewSyncUp.Columns.Clear();
            listViewSyncUp.Columns.Add("Name", nameWidth, HorizontalAlignment.Left);
            listViewSyncUp.Columns.Add("Qty", qtyWidth, HorizontalAlignment.Center);
            listViewSyncUp.Columns.Add("Size", sizeWidth, HorizontalAlignment.Right);


            // meh .. seems have to use resizing events
            // listViewSyncUp.AutoResizeColumn(0, ColumnHeaderAutoResizeStyle.ColumnContent);

            ResizeColumns();

            ListVideoInfo.Save();

            Sync.Load();
            if (Sync.syncSettings.syncUp == DateTime.MinValue)
            {
                MyFormField.SetLabelText(labelLastSyncUp, "Not yet");
            }
            else
            {
                MyFormField.SetLabelText(labelLastSyncUp, Sync.syncSettings.syncUp);
            }

            SetList();
        }

        private void tabPageSyncUp_Click(object sender, EventArgs e)
        {

        }


        private void buttonSyncUp_Click(object sender, EventArgs e)
        {
            if (listViewSyncUp.SelectedItems.Count == 0) 
            {
                MessageBox.Show("Select a Video Source to Sync Up");
                return;
            }

            ListViewItem selectedItem = listViewSyncUp.SelectedItems[0];
            FileInfo selectedFileInfo = (FileInfo)selectedItem.Tag;
            if (selectedFileInfo == null)
            {
                return;
            }

            SyncUpVideoSource(selectedFileInfo);


            Sync.syncSettings.syncUp = DateTime.UtcNow;
            MyFormField.SetLabelText(labelLastSyncUp, Sync.syncSettings.syncUp);

            Sync.Save();

        }



        private void toolStripMenuItemOpenFolder_Click(object sender, EventArgs e)
        {
            // item unselected, so ignore
            if (listViewSyncUp.SelectedItems.Count == 0)
            {
                return;
            }

            FileInfo fileInfo = (FileInfo)listViewSyncUp.SelectedItems[0].Tag;
            if (fileInfo == null)
            {
                return;
            }
            string directory = fileInfo.DirectoryName;

            MyFile.OpenDirectory(directory);
        }

        private void toolStripMenuItemOpen_Click(object sender, EventArgs e)
        {
            // item unselected, so ignore
            if (listViewSyncUp.SelectedItems.Count == 0)
            {
                return;
            }

            FileInfo fileInfo = (FileInfo)listViewSyncUp.SelectedItems[0].Tag;
            if (fileInfo == null)
            {
                return;
            }

            MyFile.RunFile(fileInfo);
        }





        public bool SetList()
        {

            listViewSyncUp.SuspendLayout();

            listViewSyncUp.Items.Clear();

            // string syncFile;
            string fileSize;
            FileInfo fileInfo;
            ListViewItem listViewItem;

            /*
            // get sync info
            syncFile = @"sync\sync." + Config.settings.exportExt;
            fileInfo = MyFile.FileInfo(syncFile);
            if (fileInfo == null)
            {
                Sync.Save();
                fileInfo = MyFile.FileInfo(syncFile);
                if (fileInfo == null)
                {
                    MessageBox.Show("Unable to create [" + syncFile + "]");
                    MyLog.Add("Unable to create [" + syncFile + "]");
                    return false;
                }
            }
            listViewItem = new ListViewItem("Sync");
            listViewItem.SubItems.Add("-");
            fileSize = Convert.ToString(MyFile.FormatSize(fileInfo.Length));
            listViewItem.SubItems.Add(fileSize);
            listViewItem.Tag = fileInfo;

            listViewSyncUp.Items.Add(listViewItem);
            */

            // get all sources
            IEnumerable<string> files = MyFile.EnumerateFiles("data", "videos_*." + Config.settings.exportExt);
            Regex regexIgnoreBackups = new Regex(@"\.[0-9]\." + Config.settings.exportExt);
            foreach (string file in files)
            {
                if (regexIgnoreBackups.IsMatch(file))
                {
                    continue;
                }
                fileInfo = MyFile.FileInfo(file);
                if (fileInfo == null)
                {
                    continue;
                }
                string source = file.Replace(@"data\videos_", "").Replace("." + Config.settings.exportExt, "");
                int qty = CalcStatsForSource(source);
                if (qty == 0)
                {
                    MyLog.Add("Source [" + source + "] seems to have 0 videos, skipping");
                    continue;
                }
                listViewItem = new ListViewItem(source);
                listViewItem.SubItems.Add(qty.ToString());
                fileSize = Convert.ToString(MyFile.FormatSize(fileInfo.Length));
                listViewItem.SubItems.Add(fileSize);
                listViewItem.Tag = fileInfo;

                listViewSyncUp.Items.Add(listViewItem);
            }


            ResizeColumns();


            listViewSyncUp.ResumeLayout();

            return true;
        }

        private int CalcStatsForSource(string sourceAlias)
        {
            List<VideoInfo> listVideoInfos = ListVideoInfo.GetList();
            if (listVideoInfos == null)
            {
                return 0;
            }

            listVideoInfos = listVideoInfos.FindAll(x => x.sourceAlias == sourceAlias).ToList();
            if (listVideoInfos == null)
            {
                return 0;
            }

            int nbrVideos = listVideoInfos.Where(x => x.files != null && x.files.video != null).Count();


            return nbrVideos;

        }

        public void ResizeColumns()
        {
            nameWidth = listViewSyncUp.Width - MyDPI.ScaleDPIDimension(qtyWidth) - MyDPI.ScaleDPIDimension(sizeWidth) - MyDPI.ScaleDPIDimension(5);

            // count is fall back in case extern call doesnt work
            int nbrItems = listViewSyncUp.Items.Count;
            if (MyUser32_GetWindow.IsVerticalScrollbarVisible(listViewSyncUp.Handle) || nbrItems > 10)
            {
                nameWidth -= MyDPI.ScaleDPIDimension(20);
            }

            listViewSyncUp.Columns[0].Width = nameWidth;
            listViewSyncUp.Columns[1].Width = MyDPI.ScaleDPIDimension(qtyWidth);
            listViewSyncUp.Columns[2].Width = MyDPI.ScaleDPIDimension(sizeWidth);
        }




        public bool SyncUpVideoSource(FileInfo sourceFileInfo)
        {
            // clean up old uploads
            IEnumerable<string> files = MyFile.EnumerateFiles(@"sync", "*.gz");
            foreach (string file in files)
            {
                MyFile.DeleteFile(file);
            }

            // compress file, video source
            string compressedFile = @"sync\" + MyFile.SafeFileName(sourceFileInfo.Name);
            if (!MyFile.Compress(sourceFileInfo.FullName, compressedFile))
            {
                return false;
            }

            // rename file so has 'rand' key/iv
            Random random = new Random();
            int rand = random.Next(0, MyEncrypt.sharedKeys.Length - 1);
            string uploadFile = compressedFile.Replace("." + Config.settings.exportExt, "-" + rand + "." + Config.settings.exportExt);
            File.Move(compressedFile + ".gz", uploadFile + ".gz");



            string key = MyEncrypt.sharedKeys[rand];
            string iv = MyEncrypt.GenerateIV();
            string delimiter = "#";

            // now encrypt compressed file contents
            string fileContents = MyFile.ReadAllBinaryToString(uploadFile + ".gz");

            string contentsHeader = "{";
            contentsHeader += "\"apiKey\":\"" + this.apiKey + "\", ";
            contentsHeader += "\"iv\":\"" + iv + "\", ";
            contentsHeader += "\"sync\":" + MySerialize.ToJSON(Sync.syncSettings);
            contentsHeader += "}";

            contentsHeader = Convert.ToBase64String(Encoding.UTF8.GetBytes(contentsHeader));
            


            fileContents = MyEncrypt.EncryptRJ256(key, iv, fileContents);
            if (fileContents == null)
            {
                return false;
            }

            contentsHeader = MyEncrypt.EncryptRJ256(key, iv, contentsHeader);

            string contentsToEncode = contentsHeader + delimiter + fileContents;

            // write base64 encoded file
            File.WriteAllText(uploadFile + ".enc", contentsToEncode);


            // log it
            FileInfo encodedFileInfo = MyFile.FileInfo(uploadFile + ".enc");
            if (encodedFileInfo == null)
            {
                return false;
            }
            MyLog.Add(String.Format("Encrypted {0} to {1}", encodedFileInfo.Name, MyFile.FormatSize(encodedFileInfo.Length)));


            // test decrypt

            fileContents = MyFile.ReadAllText(uploadFile + ".enc");

            string[] fileParts = fileContents.Split(new string[] { delimiter }, StringSplitOptions.None);

            fileContents = MyEncrypt.DecryptRJ256(key, iv, fileParts[1]);

            

            MyFile.DeleteFile(uploadFile + ".gz");
            MyFile.WriteAllBinaryFromString(uploadFile + ".gz", fileContents);








            // post encoded file to website

            string url = apiURL;
            List<KeyValuePair<string, string>> headers = new List<KeyValuePair<string, string>> { };
            headers.Add(new KeyValuePair<string, string>("api-key", apiKey));
            headers.Add(new KeyValuePair<string, string>("access-token", iv));
            Upload(url, uploadFile + ".enc", headers);



            return true;

        }


        public void Upload(string url, string fileName, List<KeyValuePair<string, string>> headers)
        {
            WebClient webClient = new WebClient();

            // add event handlers for completed and progress changed
            webClient.UploadProgressChanged += new UploadProgressChangedEventHandler(UploadProgressChanged);
            webClient.UploadFileCompleted += new UploadFileCompletedEventHandler(UploadFileCompleted);

            webClient.Headers.Add("user-agent", Config.settings.about.product + " " + Config.settings.about.version);
            foreach (KeyValuePair<string, string> header in headers)
            {
                webClient.Headers.Add(header.Key, header.Value);
            }
            Uri uri = new Uri(url);
            
            string sync = MySerialize.ToJSON(Sync.syncSettings);
            

            MyLog.Add("Upload to uri:" + uri.ToString() + " sync:" + sync + " file:" + fileName);


            int progress = 0;
            subFormProgressSyncUp.Value(progress);
            subFormProgressSyncUp.Text("Uploading..");

            webClient.UploadFileAsync(uri, fileName);

        }

        public void UploadProgressChanged(object sender, UploadProgressChangedEventArgs e)
        {
            int progress = e.ProgressPercentage;
            subFormProgressSyncUp.Value(progress);
        }

        public void UploadFileCompleted(object sender, UploadFileCompletedEventArgs e)
        {
            int progress = 100;
            subFormProgressSyncUp.Value(progress);

            string message;
            if (e.Error != null)
            {
                if (e.Error is WebException)
                {
                    message = ((WebException)e.Error).Message;
                    MyLog.Add("Web Exception " + message);
                }
                else
                {
                    message = e.Error.Message;
                    MyLog.Add("Web Exception " + message);
                }
            }
            else if (e.Cancelled)
            {
                message = "File cancelled";
                MyLog.Add("File cancelled");
            }
            else
            {
                message = Encoding.UTF8.GetString(e.Result);
                MyLog.Add("File completed " + message);
            }

            // meh, so completed msg shows
            Thread.Sleep(500);

            progress = 0;
            subFormProgressSyncUp.Value(progress);
            subFormProgressSyncUp.Text(message);

            MyLog.Add("Upload completed: "+message );
        }


    }

}
