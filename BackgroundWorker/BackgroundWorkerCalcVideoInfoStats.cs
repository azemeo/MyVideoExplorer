using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel;
using System.Windows.Forms;
using System.IO;
using System.Data;
using System.Threading;

namespace MyVideoExplorer
{
    class BackgroundWorkerCalcStats
    {
        public BackgroundWorker backgroundWorker;
        private int percentComplete;
        private ParseVideo parseVideo;


        public void Initialize()
        {
            backgroundWorker = new BackgroundWorker();

            backgroundWorker.WorkerReportsProgress = true;
            backgroundWorker.WorkerSupportsCancellation = true;

            backgroundWorker.DoWork += new DoWorkEventHandler(DoWork);
            backgroundWorker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(RunWorkerCompleted);
            backgroundWorker.ProgressChanged += new ProgressChangedEventHandler(ProgressChanged);


            parseVideo = new ParseVideo();

        }

        public void Run(List<VideoInfo> videoInfos)
        {
            // Start the asynchronous operation.
            backgroundWorker.RunWorkerAsync(videoInfos);
        }

        // This event handler is where the actual, potentially time-consuming work is done. 
        public void DoWork(object sender, DoWorkEventArgs e)
        {

            // Assign the result of the computation 
            // to the Result property of the DoWorkEventArgs 
            // object. This is will be available to the  
            // RunWorkerCompleted eventhandler.
            e.Result = CalcVideoInfoStats((List<VideoInfo>)e.Argument, e);
        }

        // This event handler deals with the results of the background operation. 
        public event RunWorkerCompletedEventHandler backgroundWorkerCalcStats_RunWorkerCompleted;
        public void RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {

            //bubble the event up
            if (this.backgroundWorkerCalcStats_RunWorkerCompleted != null)
            {
                this.backgroundWorkerCalcStats_RunWorkerCompleted(this, e);
            }


        }

        public void Abort()
        {
            if (backgroundWorker != null)
            {
                backgroundWorker.CancelAsync();
            }
        }

        // This event handler updates the progress bar. 
        public event ProgressChangedEventHandler backgroundWorkerCalcStats_ProgressChanged;
        public void ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            // this.progressBar1.Value = e.ProgressPercentage;
            //bubble the event up
            if (this.backgroundWorkerCalcStats_ProgressChanged != null)
            {
                this.backgroundWorkerCalcStats_ProgressChanged(this, e);
            }
        }


        public VideoInfoStats CalcVideoInfoStats(List<VideoInfo> videoInfos, DoWorkEventArgs doWorkEvent)
        {

            VideoInfoStats videoInfoStats = new VideoInfoStats();

            if (videoInfos == null)
            {
                return null;
            }

            // Abort the operation if the user has canceled. 
            // Note that a call to CancelAsync may have set  
            // CancellationPending to true just after the 
            // last invocation of this method exits, so this  
            // code will not have the opportunity to set the  
            // DoWorkEventArgs.Cancel flag to true. This means 
            // that RunWorkerCompletedEventArgs.Cancelled will 
            // not be set to true in your RunWorkerCompleted 
            // event handler. This is a race condition. 

            if (backgroundWorker.CancellationPending)
            {
                doWorkEvent.Cancel = true;
                return null;
            }

            // all the dictionary to custom list object is due to wanting to xml serialze data
            // see VideInfoStats.cs for more info .. Dictionary doesnt serialzie nicely
            Dictionary<string, int> statsS;
            Dictionary<int, int> statsI;
            Dictionary<decimal, int> statsD;

            // lists
            percentComplete = 0;
            backgroundWorker.ReportProgress(percentComplete, "Calc stats..");
            statsS = videoInfos.Where(x => x.videoItem.actors != null).SelectMany(x => x.videoItem.actors).Where(s => s.name != null).GroupBy(s => s.name.Trim()).ToDictionary(g => g.Key, g => g.Count());
            videoInfoStats.actor = new List<VideoInfoStatsQty<string, int>>();
            foreach (KeyValuePair<string, int> stat in statsS)
            {
                videoInfoStats.actor.Add(new VideoInfoStatsQty<string, int>(stat.Key, stat.Value));
            }

            percentComplete = 5;
            backgroundWorker.ReportProgress(percentComplete, "Calc stats..");
            statsS = videoInfos.Where(x => x.videoItem.directors != null).SelectMany(x => x.videoItem.directors).Where(s => s.name != null).GroupBy(s => s.name.Trim()).ToDictionary(g => g.Key, g => g.Count());
            videoInfoStats.director = new List<VideoInfoStatsQty<string, int>>();
            foreach (KeyValuePair<string, int> stat in statsS)
            {
                videoInfoStats.director.Add(new VideoInfoStatsQty<string, int>(stat.Key, stat.Value));
            }

            percentComplete = 10;
            backgroundWorker.ReportProgress(percentComplete, "Calc stats..");
            statsS = videoInfos.Where(x => x.videoItem.genres != null).SelectMany(x => x.videoItem.genres).Where(s => s.name != null).GroupBy(s => s.name.Trim()).ToDictionary(g => g.Key, g => g.Count());
            videoInfoStats.genre = new List<VideoInfoStatsQty<string, int>>();
            foreach (KeyValuePair<string, int> stat in statsS)
            {
                videoInfoStats.genre.Add(new VideoInfoStatsQty<string, int>(stat.Key, stat.Value));
            }

            percentComplete = 15;
            backgroundWorker.ReportProgress(percentComplete, "Calc stats..");
            statsS = videoInfos.Where(x => x.videoItem.tags != null).SelectMany(x => x.videoItem.tags).Where(s => s.name != null).GroupBy(s => s.name.Trim()).ToDictionary(g => g.Key, g => g.Count());
            videoInfoStats.tag = new List<VideoInfoStatsQty<string, int>>();
            foreach (KeyValuePair<string, int> stat in statsS)
            {
                videoInfoStats.tag.Add(new VideoInfoStatsQty<string, int>(stat.Key, stat.Value));
            }

            if (backgroundWorker.CancellationPending)
            {
                doWorkEvent.Cancel = true;
                return null;
            }


            // string
            percentComplete = 20;
            backgroundWorker.ReportProgress(percentComplete, "Calc stats..");
            statsS = videoInfos.Where(x => x.videoItem.mpaa != null).GroupBy(x => x.videoItem.mpaa).ToDictionary(x => x.Key, x => x.Count());
            videoInfoStats.mpaa = new List<VideoInfoStatsQty<string, int>>();
            foreach (KeyValuePair<string, int> stat in statsS)
            {
                videoInfoStats.mpaa.Add(new VideoInfoStatsQty<string, int>(stat.Key, stat.Value));
            }

            percentComplete = 25;
            backgroundWorker.ReportProgress(percentComplete, "Calc stats..");
            statsS = videoInfos.Where(x => x.videoItem.source != null).GroupBy(x => x.videoItem.source).ToDictionary(x => x.Key, x => x.Count());
            videoInfoStats.source = new List<VideoInfoStatsQty<string, int>>();
            foreach (KeyValuePair<string, int> stat in statsS)
            {
                videoInfoStats.source.Add(new VideoInfoStatsQty<string, int>(stat.Key, stat.Value));
            }

            percentComplete = 30;
            backgroundWorker.ReportProgress(percentComplete, "Calc stats..");
            statsS = videoInfos.Where(x => x.sourceAlias != null).GroupBy(x => x.sourceAlias).ToDictionary(x => x.Key, x => x.Count());
            videoInfoStats.sourceAlias = new List<VideoInfoStatsQty<string, int>>();
            foreach (KeyValuePair<string, int> stat in statsS)
            {
                videoInfoStats.sourceAlias.Add(new VideoInfoStatsQty<string, int>(stat.Key, stat.Value));
            }

            percentComplete = 35;
            backgroundWorker.ReportProgress(percentComplete, "Calc stats..");
            statsS = videoInfos.Where(x => x.videoItem.version != null).GroupBy(x => x.videoItem.version).ToDictionary(x => x.Key, x => x.Count());
            videoInfoStats.version = new List<VideoInfoStatsQty<string, int>>();
            foreach (KeyValuePair<string, int> stat in statsS)
            {
                videoInfoStats.version.Add(new VideoInfoStatsQty<string, int>(stat.Key, stat.Value));
            }

            percentComplete = 40;
            backgroundWorker.ReportProgress(percentComplete, "Calc stats..");
            statsS = videoInfos.Where(x => x.videoItem.watched != null).GroupBy(x => x.videoItem.watched).ToDictionary(x => x.Key, x => x.Count());
            videoInfoStats.watched = new List<VideoInfoStatsQty<string, int>>();
            foreach (KeyValuePair<string, int> stat in statsS)
            {
                videoInfoStats.watched.Add(new VideoInfoStatsQty<string, int>(stat.Key, stat.Value));
            }
            //foreach (VideoInfo videoInfo in videoInfos)
            //{
            //    MyLog.Add("STATS : " + videoInfo.videoItem.searchTitle + " - " + videoInfo.videoItem.watched);
            //}


            if (backgroundWorker.CancellationPending)
            {
                doWorkEvent.Cancel = true;
                return null;
            }


            // int, decimal
            percentComplete = 45;
            backgroundWorker.ReportProgress(percentComplete, "Calc stats..");
            statsI = videoInfos.GroupBy(x => x.videoItem.encoding.height).ToDictionary(x => x.Key, x => x.Count());
            videoInfoStats.height = new List<VideoInfoStatsQty<int, int>>();
            foreach (KeyValuePair<int, int> stat in statsI)
            {
                videoInfoStats.height.Add(new VideoInfoStatsQty<int, int>(stat.Key, stat.Value));
            }

            percentComplete = 45;
            backgroundWorker.ReportProgress(percentComplete, "Calc stats..");
            statsD = videoInfos.GroupBy(x => x.videoItem.imdbRating).ToDictionary(x => x.Key, x => x.Count());
            videoInfoStats.imdbRating = new List<VideoInfoStatsQty<decimal, int>>();
            foreach (KeyValuePair<decimal, int> stat in statsD)
            {
                videoInfoStats.imdbRating.Add(new VideoInfoStatsQty<decimal, int>(stat.Key, stat.Value));
            }

            percentComplete = 50;
            backgroundWorker.ReportProgress(percentComplete, "Calc stats..");
            statsI = videoInfos.GroupBy(x => x.videoItem.playCount).ToDictionary(x => x.Key, x => x.Count());
            videoInfoStats.playCount = new List<VideoInfoStatsQty<int, int>>();
            foreach (KeyValuePair<int, int> stat in statsI)
            {
                videoInfoStats.playCount.Add(new VideoInfoStatsQty<int, int>(stat.Key, stat.Value));
            }

            percentComplete = 55;
            backgroundWorker.ReportProgress(percentComplete, "Calc stats..");
            statsI = videoInfos.GroupBy(x => x.videoItem.rating).ToDictionary(x => x.Key, x => x.Count());
            videoInfoStats.rating = new List<VideoInfoStatsQty<int, int>>();
            foreach (KeyValuePair<int, int> stat in statsI)
            {
                videoInfoStats.rating.Add(new VideoInfoStatsQty<int, int>(stat.Key, stat.Value));
            }


            if (backgroundWorker.CancellationPending)
            {
                doWorkEvent.Cancel = true;
                return null;
            }


            percentComplete = 60;
            backgroundWorker.ReportProgress(percentComplete, "Calc stats..");
            statsI = videoInfos.GroupBy(x => x.videoItem.runtime).ToDictionary(x => x.Key, x => x.Count());
            videoInfoStats.runtime = new List<VideoInfoStatsQty<int, int>>();
            foreach (KeyValuePair<int, int> stat in statsI)
            {
                videoInfoStats.runtime.Add(new VideoInfoStatsQty<int, int>(stat.Key, stat.Value));
            }

            percentComplete = 65;
            backgroundWorker.ReportProgress(percentComplete, "Calc stats..");
            statsI = videoInfos.GroupBy(x => x.videoItem.encoding.width).ToDictionary(x => x.Key, x => x.Count());
            videoInfoStats.width = new List<VideoInfoStatsQty<int, int>>();
            foreach (KeyValuePair<int, int> stat in statsI)
            {
                videoInfoStats.width.Add(new VideoInfoStatsQty<int, int>(stat.Key, stat.Value));
            }

            percentComplete = 65;
            backgroundWorker.ReportProgress(percentComplete, "Calc stats..");
            statsI = videoInfos.GroupBy(x => x.videoItem.year).ToDictionary(x => x.Key, x => x.Count());
            videoInfoStats.year = new List<VideoInfoStatsQty<int, int>>();
            foreach (KeyValuePair<int, int> stat in statsI)
            {
                videoInfoStats.year.Add(new VideoInfoStatsQty<int, int>(stat.Key, stat.Value));
            }


            percentComplete = 100;
            backgroundWorker.ReportProgress(percentComplete, "Completed stats");

            // meh, so completed shows
            Thread.Sleep(500);


            return videoInfoStats;
        }
    }
}
