using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.ComponentModel;
using System.Windows.Forms;
using System.IO;
using System.Diagnostics;
using System.Threading;

namespace MyVideoExplorer
{

    class BackgroundWorkerRunFile
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

        public void Run(VideoItemFileInfo videoItemFileInfo)
        {
            // Start the asynchronous operation.
            backgroundWorker.RunWorkerAsync(videoItemFileInfo);
        }

        // This event handler is where the actual, potentially time-consuming work is done. 
        public void DoWork(object sender, DoWorkEventArgs e)
        {

            // Assign the result of the computation 
            // to the Result property of the DoWorkEventArgs 
            // object. This is will be available to the  
            // RunWorkerCompleted eventhandler.
            e.Result = RunFileWaitForExit((VideoItemFileInfo)e.Argument, e);
        }

        // This event handler deals with the results of the background operation. 
        public event RunWorkerCompletedEventHandler backgroundWorkerOpenFile_RunWorkerCompleted;
        public void RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            // bubble the event up
            if (this.backgroundWorkerOpenFile_RunWorkerCompleted != null)
            {
                this.backgroundWorkerOpenFile_RunWorkerCompleted(this, e);
            }


        }

        // This event handler updates the progress bar. 
        public event ProgressChangedEventHandler backgroundWorkerOpenFile_ProgressChanged;
        public void ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            // bubble the event up
            if (this.backgroundWorkerOpenFile_ProgressChanged != null)
            {
                this.backgroundWorkerOpenFile_ProgressChanged(this, e);
            }
        }

        private VideoItemFileInfo RunFileWaitForExit(VideoItemFileInfo videoItemFileInfo, DoWorkEventArgs doWorkEvent)
        {
            VideoItemFileInfo resultsVideoItemFileInfo = new VideoItemFileInfo();

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
                resultsVideoItemFileInfo.elapsed = 0;
                resultsVideoItemFileInfo.videoInfo = null;
                resultsVideoItemFileInfo.videoItemFile = null;
                return resultsVideoItemFileInfo;
            }

            Stopwatch stopwatch = Stopwatch.StartNew();

            percentComplete = 0;
            string playing = videoItemFileInfo.videoItemFile.Name;
            if (playing.Length > 30)
            {
                playing = playing.Substring(0, 30) + ".. ";
            }
            backgroundWorker.ReportProgress(percentComplete, "Playing\n" + playing +"..");

            FileInfo fileInfo = videoItemFileInfo.GetFileInfo();
            bool ret = MyFile.RunFile(fileInfo);

            percentComplete = 100;
            backgroundWorker.ReportProgress(percentComplete, "Finished playing\n" + playing);


            stopwatch.Stop();

            resultsVideoItemFileInfo.elapsed = (long)Math.Floor((decimal)stopwatch.ElapsedMilliseconds / 1000);
            resultsVideoItemFileInfo.videoInfo = videoItemFileInfo.videoInfo;
            resultsVideoItemFileInfo.videoItemFile = videoItemFileInfo.videoItemFile;

            // meh, so completed msg shows
            Thread.Sleep(500);

            return resultsVideoItemFileInfo;
        }


    }
}
