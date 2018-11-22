using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Windows.Forms;
using System.IO;
using System.Diagnostics;
using System.ComponentModel;
using System.Threading;

namespace MyVideoExplorer
{


    class CalcVideoInfoStats
    {
        private static VideoInfoStats videoInfoStats;
        private BackgroundWorkerCalcStats backgroundWorkerCalcStats;

        // so this user control can update other user controls
        private SubFormProgress subFormProgress;

        public CalcVideoInfoStats()
        {
            // open file, monitor state
            backgroundWorkerCalcStats = new BackgroundWorkerCalcStats();
            backgroundWorkerCalcStats.Initialize();
            backgroundWorkerCalcStats.backgroundWorkerCalcStats_ProgressChanged += new ProgressChangedEventHandler(BackgroundWorkerCalcStats_ProgressChanged);
            backgroundWorkerCalcStats.backgroundWorkerCalcStats_RunWorkerCompleted += new RunWorkerCompletedEventHandler(BackgroundWorkerCalcStats_RunWorkerCompleted);
        }

        public void AddAccessToSubForms(SubFormProgress subFormProgress)
        {
            this.subFormProgress = subFormProgress;
        }

        public bool Calc(List<VideoInfo> videoInfos)
        {
            backgroundWorkerCalcStats.Run(videoInfos);

            return true;
        }

        public void Abort()
        {
            if (backgroundWorkerCalcStats != null)
            {
                backgroundWorkerCalcStats.Abort();
            }
        }

        public static VideoInfoStats GetStats()
        {
            return videoInfoStats;
        }

        public event RunWorkerCompletedEventHandler backgroundWorkerCalcStats_RunWorkerCompleted;
        protected void BackgroundWorkerCalcStats_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            VideoInfoStats videoInfoStatsResults = new VideoInfoStats();

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
                videoInfoStatsResults = (VideoInfoStats)e.Result;
                if (videoInfoStatsResults != null) {
                    videoInfoStats = videoInfoStatsResults;
                }

                subFormProgress.Text("Ready");
                subFormProgress.Value(0);
            }

            // bubble the event up
            var handler = backgroundWorkerCalcStats_RunWorkerCompleted;
            if (handler != null)
            {
                handler(videoInfoStatsResults, e);
            }
        }

        /// <summary>
        /// update progress of background worker
        /// used for ScanSource and FilterSource
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void BackgroundWorkerCalcStats_ProgressChanged(object sender, ProgressChangedEventArgs e)
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



        public static bool Load()
        {
            bool ret = false;
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();

            // MyLog.Add("Loading VideoItemStats");

            string dataFile = MyFile.EnsureDataFile("stats", Config.settings.exportExt, "stats");
            if (dataFile == null)
            {
                return false;
            }

            // keep a backup of settings
            if (File.Exists(dataFile))
            {
                videoInfoStats = new VideoInfoStats();
                videoInfoStats = (VideoInfoStats)MyDeserialize.FromFile(Config.settings.exportFormat, dataFile, videoInfoStats);

                string fromFIle = "from " + dataFile.Replace(MyFile.exeDirectory, "");
                FileInfo fileInfo = MyFile.FileInfo(dataFile);
                if (fileInfo != null)
                {
                    fromFIle += " " + MyFile.FormatSize(fileInfo.Length);
                }
                MyLog.Add("Loaded VideoInfoStats " + fromFIle);

                if (videoInfoStats != null && videoInfoStats.year != null && videoInfoStats.year.Count() > 0)
                {
                    ret = true;
                }
            }
            else
            {
                // MyLog.Add("No VideoInfoStats to load ");
            }

            stopWatch.Stop();

            if (ret)
            {
                MyLog.AddElapsed(stopWatch.Elapsed);
            }

            return ret;
        }

        public static bool Save()
        {

            string dataFile = MyFile.EnsureDataFile("stats", Config.settings.exportExt, "stats");
            if (dataFile == null)
            {
                return false;
            }

            MyLog.RotateFiles(dataFile);

            MySerialize.ToFile(Config.settings.exportFormat, dataFile, videoInfoStats);

            return true;
        }
    }
}
