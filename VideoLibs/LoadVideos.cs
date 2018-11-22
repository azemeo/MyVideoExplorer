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
    public class LoadVideos
    {
        private Stopwatch stopwatch;
        private Stopwatch stopwatchBuildGalleryImages;
        private Stopwatch stopwatchCalcStats;

        private BackgroundWorkerScanSource backgroundWorkerScanSource;
        private BackgroundWorkerFilterSource backgroundWorkerFilterSource;
        private BuildGalleryImages buildGalleryImages;
        private CalcVideoInfoStats calcVideoInfoStats;

        // so this user control can update other user controls
        private SubFormListView subFormListView;
        private SubFormGallery subFormGallery;
        private SubFormVideoForm subFormVideoForm;
        private SubFormFilterForm subFormFilterForm;
        private SubFormProgress subFormProgress;

        public LoadVideos()
        {
            // scan file system for videos
            backgroundWorkerScanSource = new BackgroundWorkerScanSource();
            backgroundWorkerScanSource.Initialize();
            backgroundWorkerScanSource.backgroundWorkerScanSource_ProgressChanged += new ProgressChangedEventHandler(BackgroundWorker_ProgressChanged);
            backgroundWorkerScanSource.backgroundWorkerScanSource_RunWorkerCompleted += new RunWorkerCompletedEventHandler(BackgroundWorkerScanSource_RunWorkerCompleted);

            // filter existing list for videos
            backgroundWorkerFilterSource = new BackgroundWorkerFilterSource();
            backgroundWorkerFilterSource.Initialize();
            backgroundWorkerFilterSource.backgroundWorkerFilterSource_ProgressChanged += new ProgressChangedEventHandler(BackgroundWorker_ProgressChanged);
            backgroundWorkerFilterSource.backgroundWorkerFilterSource_RunWorkerCompleted += new RunWorkerCompletedEventHandler(BackgroundWorkerFilterSource_RunWorkerCompleted);

            // build gallery images for video items loaded
            buildGalleryImages = new BuildGalleryImages();
            buildGalleryImages.backgroundWorkerBuildGalleryImages_RunWorkerCompleted += new RunWorkerCompletedEventHandler(BackgroundWorkerBuildGalleryImages_RunWorkerCompleted);

            // calc stats for video items loaded
            calcVideoInfoStats = new CalcVideoInfoStats();
            calcVideoInfoStats.backgroundWorkerCalcStats_RunWorkerCompleted += new RunWorkerCompletedEventHandler(BackgroundWorkerCalcStats_RunWorkerCompleted);
        }

        public void AddAccessToSubForms(SubFormListView subFormListView, SubFormGallery subFormGallery, SubFormVideoForm subFormVideoForm, SubFormFilterForm subFormFilterForm, SubFormProgress subFormProgress)
        {
            this.subFormListView = subFormListView;
            this.subFormGallery = subFormGallery;
            this.subFormVideoForm = subFormVideoForm;
            this.subFormFilterForm = subFormFilterForm;
            this.subFormProgress = subFormProgress;

            buildGalleryImages.AddAccessToSubForms(subFormProgress);
            calcVideoInfoStats.AddAccessToSubForms(subFormProgress);
        }

        public void AddAccessToSubFormProgress(SubFormProgress subFormProgress)
        {
            this.subFormProgress = subFormProgress;

            buildGalleryImages.AddAccessToSubForms(subFormProgress);
            calcVideoInfoStats.AddAccessToSubForms(subFormProgress);
        }

        public void AddAccessToSubFormListView(SubFormListView subFormListView)
        {
            this.subFormListView = subFormListView;
        }

        public void AddAccessToSubFormGallery(SubFormGallery subFormGallery)
        {
            this.subFormGallery = subFormGallery;
        }

        public void LoadFromDisk()
        {
            LoadFromDisk(null);
        }
        /// <summary>
        /// load videos from disk into list
        /// </summary>
        /// <param name="source">source to load, or all if null</param>
        public void LoadFromDisk(ConfigSettings.Source source)
        {
            stopwatch = Stopwatch.StartNew(); // stopped when background worker completed

            subFormFilterForm.Enabled = false;
            subFormListView.Enabled = false;
            subFormVideoForm.Enabled = false;
            subFormGallery.Enabled = false;

            // TODO are these really needed here?
            //FilterInfo filterInfo = subFormFilterForm.GetFilterForm();
            //subFormListView.listViewColumnSorter.SortColumnIndex = FilterEnums.sortColumn.GetValueByKey(filterInfo.sortColumn);
            //subFormListView.listViewColumnSorter.SortOrderIndex = filterInfo.sortOrderIndex;

            List<string> directories = new List<string>();
            if (source != null) 
            {
                directories.Add(source.directory);
            } 
            else 
            {                
                foreach (ConfigSettings.Source settingsSource in Config.settings.sources)
                {
                    directories.Add(settingsSource.directory);
                }  
            }
            MyLog.Add("Scan sources " + String.Join(", ", directories) + " -->");
            backgroundWorkerScanSource.Run(directories);            
        }

        /// <summary>
        /// load videos from disk into list
        /// </summary>
        public void FilterListView()
        {
            stopwatch = Stopwatch.StartNew(); // stopped when background worker completed

            FilterInfo filterInfo = subFormFilterForm.GetFilterForm();
            subFormListView.listViewColumnSorter.sortColumnIndex = FilterEnums.sortColumn.GetValueByKey(filterInfo.sortColumn);
            subFormListView.listViewColumnSorter.sortOrderIndex = filterInfo.sortOrderIndex;


            subFormFilterForm.Enabled = false;
            subFormListView.Enabled = false;
            subFormVideoForm.Enabled = false;
            subFormGallery.Enabled = false;            


            MyLog.Add("Filter sources -->");
            // since static, no need to pass in .. but has allowed for conatiner to be replaced .. tree, datatabel, etc 
            backgroundWorkerFilterSource.Run(ListVideoInfo.GetList(), filterInfo);

        }

        public void RunCalcStats(object sender, RunWorkerCompletedEventArgs e)
        {

            MyLog.Add("Setting Stats");
            subFormProgress.Value(0);
            subFormProgress.Text("Setting Stats..");
            if (!CalcVideoInfoStats.Load())
            {
                stopwatchCalcStats = Stopwatch.StartNew(); // stopped when background worker completed
                calcVideoInfoStats.Calc(ListVideoInfo.GetList());
            }
            else
            {
                LoadVideos_Completed(sender, e);
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

        /// <summary>
        /// background process getting VideoInfos completed
        /// used for ScanSource and FilterSource
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void VideoInfos_RunWorkerCompleted(string action, string message, object sender, RunWorkerCompletedEventArgs e)
        {
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

                if (action == "scan")
                {
                    List<VideoInfosScanSource> videoInfosScanSources = (List<VideoInfosScanSource>)e.Result;

                    if (videoInfosScanSources == null)
                    {
                        MyLog.Add(message + " Null VideoItems");
                        MyLog.AddElapsed(stopwatch.Elapsed);
                        LoadVideos_Completed(sender, e);
                        return;
                    }

                    MyLog.Add(message);
                    MyLog.AddElapsed(stopwatch.Elapsed);

                    subFormProgress.Text("Applying..");
                    subFormProgress.Value(0);
                    int nbrAppliedSources = 0;
                    int nbrSourcesToApply = videoInfosScanSources.Count();
                    foreach (VideoInfosScanSource videoInfosScanSource in videoInfosScanSources) 
                    {

                        MyLog.Add("Applying " + videoInfosScanSource.sourceAlias + " with " +videoInfosScanSource.videoInfos.Count().ToString() + " VideoItems");

                        int progress = (int)Math.Floor((decimal)(nbrSourcesToApply - nbrAppliedSources) / nbrSourcesToApply * 100);
                        subFormProgress.Text("Applying " + videoInfosScanSource.sourceAlias + "..");
                        subFormProgress.Value(progress);

                        // sources scanned less than settings, 
                        // so remove scanned sources from existing list
                        // and replace with scanned list
                        List<VideoInfo> currentVideoInfos = ListVideoInfo.GetList();
                        if (currentVideoInfos == null)
                        {
                            ListVideoInfo.SetList(videoInfosScanSource.videoInfos);
                        } 
                        else 
                        {
                            currentVideoInfos.RemoveAll(s => s.sourceAlias == videoInfosScanSource.sourceAlias);

                            currentVideoInfos.AddRange(videoInfosScanSource.videoInfos);
                            ListVideoInfo.SetList(currentVideoInfos);
                        }
                        // videoInfos = videoInfos.Union(currentVideoInfos).ToList();

                        nbrAppliedSources++;
                    }

                }
                else // filter
                {
                    List<VideoInfo> videoInfos = (List<VideoInfo>)e.Result;

                    if (videoInfos == null)
                    {
                        MyLog.Add(message + " Null VideoItems");
                        MyLog.AddElapsed(stopwatch.Elapsed);
                        LoadVideos_Completed(sender, e);
                        return;
                    }

                    MyLog.Add(message + " " + videoInfos.Count().ToString() + " VideoItems");
                    MyLog.AddElapsed(stopwatch.Elapsed);
                    subFormProgress.Text("Applying..");
                    subFormProgress.Value(0);

                    ListVideoInfo.SetList(videoInfos);
                }

                MyLog.Add("Setting List");
                subFormProgress.Value(0);
                subFormProgress.Text("Setting List..");
                subFormListView.SetListViewInfos(ListVideoInfo.GetList());
                Application.DoEvents(); // meh, not needed but allow ui redraw


                if (Config.settings.gallery.enable)
                {
                    MyLog.Add("Building Gallery");
                    subFormProgress.Text("Building Gallery..");
                    subFormProgress.Value(0);
                    stopwatchBuildGalleryImages = Stopwatch.StartNew(); // stopped when background worker completed
                    // build to either create thumbnails or get existing thumbnails
                    // will call LoadVideos_Completed() via RunCalcStats() when done
                    buildGalleryImages.Build(ListVideoInfo.GetList());
                }
                else
                {
                    RunCalcStats(sender, e);
                }
            }
        }


        protected void BackgroundWorkerScanSource_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            // delete prior statsfile, if any, so stats will be re-calced
            string statsFile = MyFile.EnsureDataFile("stats", Config.settings.exportExt, "stats");
            if (statsFile != null)
            {
                MyFile.DeleteFile(statsFile);
            }
            VideoInfos_RunWorkerCompleted("scan", "Scanning done", sender, e);
        }

        protected void BackgroundWorkerFilterSource_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            VideoInfos_RunWorkerCompleted("filter", "Filtering done", sender, e);
        }

        protected void BackgroundWorkerBuildGalleryImages_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            // result of scan .. continue processing ..

            stopwatchBuildGalleryImages.Stop();
            MyLog.AddElapsed(stopwatchBuildGalleryImages.Elapsed);

            List<VideoInfo> videoInfos = (List<VideoInfo>)sender;

            if (videoInfos != null)
            {
                // set list again so get gallery thumbnails
                ListVideoInfo.SetList(videoInfos);

                MyLog.Add("Setting Gallery");
                subFormProgress.Value(0);
                subFormProgress.Text("Setting Gallery..");
                subFormGallery.SetPosters(ListVideoInfo.GetList());
            }

            RunCalcStats(sender, e);

        }

        protected void BackgroundWorkerCalcStats_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            stopwatchCalcStats.Stop();
            MyLog.AddElapsed(stopwatchCalcStats.Elapsed);

            VideoInfoStats videoInfoStatsResults = (VideoInfoStats)sender;

            if (videoInfoStatsResults != null)
            {
                CalcVideoInfoStats.Save();
            }

            LoadVideos_Completed(sender, e);
        }

        public event EventHandler loadVideos_Completed;
        private void LoadVideos_Completed(object sender, EventArgs e)
        {
            subFormProgress.Value(0);
            subFormProgress.Text("Ready");

            MyLog.Add("Ready");
            stopwatch.Stop();
            MyLog.AddElapsed("<-- in ", stopwatch.Elapsed);

            subFormFilterForm.Enabled = true;
            subFormListView.Enabled = true;
            subFormVideoForm.Enabled = true;
            subFormGallery.Enabled = true;

            // bubble the event up
            var handler = loadVideos_Completed;
            if (handler != null)
            {
                handler(this, e);
            }
        }

        public void AbortBackgroundWorkers()
        {
            if (backgroundWorkerScanSource != null)
            {
                backgroundWorkerScanSource.Abort();
            }
            if (backgroundWorkerFilterSource != null)
            {
                backgroundWorkerFilterSource.Abort();
            }
            if (buildGalleryImages != null)
            {
                buildGalleryImages.Abort();
            }
            if (calcVideoInfoStats != null)
            {
                calcVideoInfoStats.Abort();
            }

        }
    }
}
