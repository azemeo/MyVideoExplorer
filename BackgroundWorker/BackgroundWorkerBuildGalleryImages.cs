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
using System.Drawing;

namespace MyVideoExplorer
{
    class BackgroundWorkerBuildGalleryImages
    {
        public BackgroundWorker backgroundWorker;
        private int percentComplete;


        public void Initialize()
        {
            backgroundWorker = new BackgroundWorker();

            backgroundWorker.WorkerReportsProgress = true;
            backgroundWorker.WorkerSupportsCancellation = true;

            backgroundWorker.DoWork += new DoWorkEventHandler(DoWork);
            backgroundWorker.RunWorkerCompleted += new RunWorkerCompletedEventHandler(RunWorkerCompleted);
            backgroundWorker.ProgressChanged += new ProgressChangedEventHandler(ProgressChanged);


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
            e.Result = BuildImages((List<VideoInfo>)e.Argument, e);
        }

        // This event handler deals with the results of the background operation. 
        public event RunWorkerCompletedEventHandler backgroundWorkerBuildGalleryImages_RunWorkerCompleted;
        public void RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {

            // bubble the event up
            var handler = backgroundWorkerBuildGalleryImages_RunWorkerCompleted;
            if (handler != null)
            {
                handler(this, e);
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
        public event ProgressChangedEventHandler backgroundWorkerBuildGalleryImages_ProgressChanged;
        public void ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            // bubble the event up
            var handler = backgroundWorkerBuildGalleryImages_ProgressChanged;
            if (handler != null)
            {
                handler(this, e);
            }
        }


        public List<VideoInfo> BuildImages(List<VideoInfo> videoInfos, DoWorkEventArgs doWorkEvent)
        {

            if (BuildGalleryImages.ThumbnailsAlreadySet())
            {
                return videoInfos;
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

            int nbrVideoInfos = videoInfos.Count();
            int nbrPosters = 0;
            foreach (VideoInfo videoInfo in videoInfos)
            {

                if (videoInfo.filter)
                {
                    if (videoInfo.files.posterThumbnail != null)
                    {
                        videoInfo.files.posterThumbnail.Dispose();
                    }
                    continue;
                }

                // no files or no video, so skip
                if (videoInfo.files == null || videoInfo.files.video == null)
                {
                    continue;
                }

                GalleryImageThumbnailInfo galleryImageThumbnailInfo = BuildGalleryImages.GetCachedThumbnail(videoInfo);
                videoInfo.files.posterThumbnail = galleryImageThumbnailInfo.thumbnail;

                nbrPosters++;

                // Thread.Sleep(1000); // dev


                // meh, smooth out update progress
                if (nbrPosters % 10 == 0)
                {
                    percentComplete = 100 - (int)Math.Floor((decimal)(nbrVideoInfos - nbrPosters) / nbrVideoInfos * 100);
                    string progressMessage = "";
                    if (galleryImageThumbnailInfo.fromCache)
                    {
                        progressMessage += "Using Gallery cache";
                    }
                    else if (galleryImageThumbnailInfo.createdCache)
                    {
                        progressMessage += "Creating Gallery cache";
                    }
                    else
                    {
                        progressMessage += "Building Gallery";
                    }
                    progressMessage += "..";

                    backgroundWorker.ReportProgress(percentComplete, progressMessage);

                    if (backgroundWorker.CancellationPending)
                    {
                        doWorkEvent.Cancel = true;
                        return null;
                    }
                }

            }



            percentComplete = 100;
            backgroundWorker.ReportProgress(percentComplete, "Completed Gallery");

            // meh, so completed shows
            Thread.Sleep(500);


            return videoInfos;
        }




    }
}
