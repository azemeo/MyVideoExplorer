using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel;
using System.Windows.Forms;
using System.IO;
using System.Collections;
using System.Data;
using System.Threading;

namespace MyVideoExplorer
{
    class BackgroundWorkerFilterSource
    {

        private BackgroundWorker backgroundWorker;
        private int percentComplete;
        private FilterInfo filterInfo;

        public void Initialize()
        {
            backgroundWorker = new BackgroundWorker();

            backgroundWorker.WorkerReportsProgress = true;
            backgroundWorker.WorkerSupportsCancellation = true;

            backgroundWorker.DoWork += new DoWorkEventHandler(DoWork);
            backgroundWorker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(RunWorkerCompleted);
            backgroundWorker.ProgressChanged += new ProgressChangedEventHandler(ProgressChanged);
        }

        public void Run(List<VideoInfo> videoInfos, FilterInfo filterInfo)
        {
            if (videoInfos == null)
            {
                return;
            }
            this.filterInfo = filterInfo;
            MyLog.Add("Applying filtering to " + videoInfos.Count.ToString() + " VideoItems");

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
            e.Result = FilterSource((List<VideoInfo>)e.Argument, e);
        }

        public void Abort()
        {
            if (backgroundWorker != null)
            {
                backgroundWorker.CancelAsync();
            }
        }

        // This event handler deals with the results of the background operation. 
        public event RunWorkerCompletedEventHandler backgroundWorkerFilterSource_RunWorkerCompleted;
        public void RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            // this.progressBar1.Value = e.ProgressPercentage;
            //bubble the event up
            if (this.backgroundWorkerFilterSource_RunWorkerCompleted != null)
            {
                this.backgroundWorkerFilterSource_RunWorkerCompleted(this, e);
            }


        }

        // This event handler updates the progress bar. 
        public event ProgressChangedEventHandler backgroundWorkerFilterSource_ProgressChanged;
        public void ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            // this.progressBar1.Value = e.ProgressPercentage;
            //bubble the event up
            if (this.backgroundWorkerFilterSource_ProgressChanged != null)
            {
                this.backgroundWorkerFilterSource_ProgressChanged(this, e);
            }
        }

        public List<VideoInfo> FilterSource(List<VideoInfo> videoInfos, DoWorkEventArgs doWorkEvent)
        {


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

            int nbrRows = videoInfos.Count;
            int processingRow = 0;

            percentComplete = 0;
            backgroundWorker.ReportProgress(percentComplete, "Applying Filters..");

            foreach (VideoInfo videoInfo in videoInfos)
            {

                processingRow++;

                // meh, smooth out progress update
                if (processingRow % 40 == 0)
                {
                    percentComplete = (int)Math.Floor((double)processingRow / (double)nbrRows * 100);
                    backgroundWorker.ReportProgress(percentComplete);

                    if (backgroundWorker.CancellationPending)
                    {
                        doWorkEvent.Cancel = true;
                        return null;
                    }
                }

                videoInfo.filter = VideoInfoFilter(videoInfo, filterInfo);              

            }

            percentComplete = 100;
            backgroundWorker.ReportProgress(percentComplete, "Completed filtering");

            // meh, so completed msg shows
            Thread.Sleep(500);


            return videoInfos;
        }

        private bool VideoItemFilterContainsString(string source, string filter, bool allowEmpty=false)
        {
            try
            {                    
                if (allowEmpty && filter != null && filter.Length > 0 && (source == null || source.Length == 0))
                {
                    return true;                
                }
                else if (filter != null && filter.Length > 0 && (source == null || source.Length == 0)) 
                {
                    // return true;
                }
                else if (filter != null && filter.Length > 0 && source != null && source.Length > 0)
                {
                    // if (!source.Contains(filter))
                    if (source.IndexOf(filter, StringComparison.OrdinalIgnoreCase) == -1) 
                    {
                        return true;
                    }
                }
            }
            catch (Exception e)
            {
                MyLog.Add("VideoItemFilterContainsString: " + e.ToString());
            }
            return false;
        }

        private bool VideoItemFilterEqualString(string source, string filter)
        {
            try
            {
                if (filter != null && filter.Length > 0 && source != null && source.Length > 0)
                {
                    if (!source.Equals(filter))
                    {
                        return true;
                    }
                }
            }
            catch (Exception e)
            {
                MyLog.Add("VideoItemFilterEqualString: " + e.ToString());
            }
            return false;
        }

        private bool VideoItemFilterBetweenInt(int source, int filterFrom, int filterTo)
        {
            try
            {
                if ((filterFrom > 0 || filterTo > 0) && source > 0)
                {
                    if (source < filterFrom || source > filterTo)
                    {
                        return true;
                    }
                }
            }
            catch (Exception e)
            {
                MyLog.Add("VideoItemFilterBetweenInt: " + e.ToString());
            }
            return false;
        }

        private bool VideoItemFilterWatched(string source, string filter)
        {
            try
            {
                if (String.IsNullOrEmpty(filter))
                {
                    // no filter
                } 
                else  if (filter == "ANY")
                {
                    // any
                }
                else if (filter.IndexOf("YES") != -1 && filter.IndexOf("NO") != -1) 
                {
                    // any
                }
                else if (filter != source)
                {
                    return true;
                }
            }
            catch (Exception e)
            {
                MyLog.Add("VideoItemFilterWatched: " + e.ToString());
            }
            return false;
        }

        /// <summary>
        /// filter video items
        /// </summary>
        /// <param name="videoItem"></param>
        /// <param name="filterInfo"></param>
        /// <returns>true, remove item; false, keep item</returns>
        private bool VideoInfoFilter(VideoInfo videoInfo, FilterInfo filterInfo)
        {
            if (videoInfo == null || videoInfo.videoItem == null)
            {
                return true;
            }
            VideoItem videoItem = videoInfo.videoItem;
            bool logFiltered = false; // for debug; log i/o slows down filter
            string message = "";

            if (filterInfo.filterType == 1)
            {
                // filter by combo boxes

                if (VideoItemFilterContainsString(videoItem.title, filterInfo.title))
                {
                    return true;
                }
                
                if (VideoItemFilterBetweenInt(videoItem.year, filterInfo.yearFrom, filterInfo.yearTo))
                {
                    return true;
                }

                if (VideoItemFilterBetweenInt(videoItem.playCount, filterInfo.playCountFrom, filterInfo.playCountTo))
                {
                    return true;
                }

                if (VideoItemFilterWatched(videoItem.watched, filterInfo.watched))
                {
                    return true;
                }

                if (VideoItemFilterEqualString(videoItem.source, filterInfo.source))
                {
                    return true;
                }

                if (VideoItemFilterEqualString(videoItem.mpaa, filterInfo.mpaa))
                {
                    return true;
                }

                // MyLog.Add("title"+videoItem.searchTitle+ " vtag:" + videoItem.tag + " ftag:"+ filterInfo.tag);
                if (videoItem.tags != null &&
                    VideoItemFilterContainsString(String.Join(",", videoItem.tags), filterInfo.tag, true))
                {
                    return true;
                }
            }
            else if (filterInfo.filterType == 0)
            {
                // filtler by tag cloud
                if (logFiltered) message = videoItem.title;
                if (VideoItemFilterContainsString(videoItem.title, filterInfo.title))
                {
                    if (logFiltered) MyLog.Add("FILTER : " + message + " title:" + videoItem.title + " filter:" + filterInfo.title);
                    return true;
                }

                if (!String.IsNullOrEmpty(filterInfo.year) && videoItem.year == 0)
                {
                    return true;
                }
                if (VideoItemFilterContainsString(filterInfo.year, videoItem.year.ToString()))
                {
                    if (logFiltered) MyLog.Add("FILTER : " + message + " year:" + videoItem.year + " filter:" + filterInfo.year);
                    return true;
                }

                if (VideoItemFilterContainsString(filterInfo.playCount, videoItem.playCount.ToString()))
                {
                    if (logFiltered) MyLog.Add("FILTER : " + message + " playCount:" + videoItem.playCount + " filter:" + filterInfo.playCount);
                    return true;
                }

                if (VideoItemFilterWatched(videoItem.watched, filterInfo.watched))
                {
                    if (logFiltered) MyLog.Add("FILTER : " + message + " watched:" + videoItem.watched + " filter:" + filterInfo.watched);
                    return true;
                }

                if (VideoItemFilterContainsString(filterInfo.source, videoItem.source))
                {
                    if (logFiltered) MyLog.Add("FILTER : " + message + " source:" + videoItem.source + " filter:" + filterInfo.source);
                    return true;
                }

                if (VideoItemFilterContainsString(filterInfo.sourceAlias, videoInfo.sourceAlias))
                {
                    if (logFiltered) MyLog.Add("FILTER : " + message + " sourceAlias:" + videoInfo.sourceAlias + " filter:" + filterInfo.sourceAlias);
                    return true;
                }

                if (VideoItemFilterContainsString(filterInfo.mpaa, videoItem.mpaa))
                {
                    if (logFiltered) MyLog.Add("FILTER : " + message + " mpaa:" + videoItem.mpaa + " filter:" + filterInfo.mpaa);
                    return true;
                }

                if (videoItem.tags != null)
                {
                    string tags = String.Join(",", videoItem.tags);
                    if (VideoItemFilterContainsString(filterInfo.tag, tags))
                    {
                        if (logFiltered) MyLog.Add("FILTER : " + message + " tags:" + tags + " filter:" + filterInfo.tag);
                        return true;
                    }
                }

            }
            return false;
        }


    }
}
