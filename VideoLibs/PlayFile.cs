using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Windows.Forms;
using System.IO;
using System.Diagnostics;
using System.ComponentModel;

namespace MyVideoExplorer
{
    class PlayFile
    {
        private BackgroundWorkerRunFile backgroundWorkerOpenFile;

        // so this user control can update other user controls
        private SubFormVideoForm subFormVideoForm;
        private SubFormProgress subFormProgress;

        public PlayFile()
        {
            // open file, monitor state
            backgroundWorkerOpenFile = new BackgroundWorkerRunFile();
            backgroundWorkerOpenFile.Initialize();
            backgroundWorkerOpenFile.backgroundWorkerOpenFile_ProgressChanged += new ProgressChangedEventHandler(BackgroundWorker_ProgressChanged);
            backgroundWorkerOpenFile.backgroundWorkerOpenFile_RunWorkerCompleted += new RunWorkerCompletedEventHandler(BackgroundWorkerRunFile_RunWorkerCompleted);
        }

        public void AddAccessToSubForms(SubFormVideoForm subFormVideoForm, SubFormProgress subFormProgress)
        {
            this.subFormVideoForm = subFormVideoForm;
            this.subFormProgress = subFormProgress;
        }

        public bool Play(VideoInfo videoInfo, VideoItemFile videoItemFile)
        {
            bool ret = false;
            // if playing video, mark video item as played/watched
            // TODO btr way to normalize if a file is a video file
            string fileExt = videoItemFile.Extension.TrimStart('.');
            switch (fileExt)
            {
                case "avi":
                case "m4v":
                case "mov":
                case "mpg":
                case "mkv":
                case "mp4":
                case "mpeg":
                    // run as background so can wait w/o blocking ui
                    // after X secs timeout, mark as played/watched
                    // .. but requires UseShellEx = false which requires more config/settings to specify video player
                    // so for now, meh runs as background thread w/o wait          
                    VideoItemFileInfo videoItemFileInfo = new VideoItemFileInfo();
                    videoItemFileInfo.videoInfo = videoInfo;
                    videoItemFileInfo.videoItemFile = videoItemFile;
                    backgroundWorkerOpenFile.Run(videoItemFileInfo);
                    break;
                default:
                    string fullName = videoInfo.GetFullName(videoItemFile);
                    FileInfo fileInfo = MyFile.FileInfo(fullName);
                    if (fileInfo == null)
                    {
                        // MessageBox.Show("Error trying to open file\n"+fullName+"\nView log for details");
                        ret = false;
                    }
                    else
                    {
                        ret = MyFile.RunFile(fileInfo);
                    }
                    break;
            }

            return ret;
        }


        public event EventHandler<VideoItemFileInfo> playFile_Completed;
        protected void BackgroundWorkerRunFile_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            VideoItemFileInfo resultsVideoItemFileInfo = null;
            // First, handle the case where an exception was thrown. 
            if (e.Error != null)
            {
                MyLog.Add(e.Error.ToString());
                subFormProgress.Text(e.Error.Message);
            }
            else if (e.Cancelled)
            {
                // Next, handle the case where the user canceled the operation. 
                // Note that due to a race condition in the DoWork event handler, the Cancelled 
                // flag may not have been set, even though CancelAsync was called.
                subFormProgress.Text("Canceled");
            }
            else
            {
                // Finally, handle the case where the operation  succeeded.                
                resultsVideoItemFileInfo = (VideoItemFileInfo)e.Result;
                if (resultsVideoItemFileInfo != null)
                {
                    MyLog.Add("Played: " + resultsVideoItemFileInfo.videoItemFile.Name + " for " + resultsVideoItemFileInfo.elapsed + "s");
                }
                else
                {
                    MyLog.Add("Played: no results: " + e.ToString());
                }


                long elapsed = resultsVideoItemFileInfo.elapsed;

                // kinda simple check to make sure updating video that was played
                if (subFormVideoForm.selectedVideoInfo.files != null && 
                    subFormVideoForm.selectedVideoInfo.files.video != null &&
                    resultsVideoItemFileInfo.videoItemFile != null &&
                    subFormVideoForm.selectedVideoInfo.files.video.Name == resultsVideoItemFileInfo.videoItemFile.Name)
                {
                    subFormProgress.Text("Done playing..");

                    // MyLog.Add("elapsed:"+elapsed+" watchedAfter:" + (Config.settings.watchedAfter));

                    // if played for more than X minutes, assumed "watched"
                    if (Config.settings.markWatched && elapsed > Config.settings.watchedAfter)
                    {
                        subFormProgress.Value(90);
                        subFormProgress.Text("Updating watched..");

                        subFormVideoForm.SetWatched();

                        subFormVideoForm.SaveForm();
                    }

                    subFormProgress.Value(0);
                    subFormProgress.Text("Ready");
                }

                subFormProgress.Value(0);
                subFormProgress.Text("Ready");
            }

            // bubble the event up
            EventHandler<VideoItemFileInfo> handler = this.playFile_Completed;
            if (handler != null)
            {
                MessageBox.Show("bubble");
                handler(this, resultsVideoItemFileInfo);
            }

        }

        /// <summary>
        /// update progress of background worker
        /// used for ScanSource and FilterSource
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void BackgroundWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            int progress = e.ProgressPercentage;
            string message = (string)e.UserState;

            subFormProgress.Value(progress);
            if (message == null)
            {
                message = "progresss " + progress.ToString() + "%";
            }
            subFormProgress.Text(message);
        }
    }
}
