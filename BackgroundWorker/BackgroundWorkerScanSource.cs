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
    public class BackgroundWorkerScanSource
    {
        public BackgroundWorker backgroundWorker;
        private int percentComplete;
        private ParseVideo parseVideo;

        private struct DirInfo
        {
            public DirectoryInfo directoryInfo;
            public int level;
        }

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

        public void Run(List<string> sources)
        {
            if (sources == null || sources.Count == 0)
            {
                MyLog.Add("No directories to scan");
                return;
            }
            MyLog.Add("Scanning directories: " + String.Join(", ", sources) + "");

            // Start the asynchronous operation.
            backgroundWorker.RunWorkerAsync(sources);
        }

        // This event handler is where the actual, potentially time-consuming work is done. 
        public void DoWork(object sender, DoWorkEventArgs e)
        {

            // Assign the result of the computation 
            // to the Result property of the DoWorkEventArgs 
            // object. This is will be available to the  
            // RunWorkerCompleted eventhandler.
            e.Result = ScanSource((List<string>)e.Argument, e);
        }

        // This event handler deals with the results of the background operation. 
        public event RunWorkerCompletedEventHandler backgroundWorkerScanSource_RunWorkerCompleted;
        public void RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            // bubble the event up
            var handler = backgroundWorkerScanSource_RunWorkerCompleted;
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
        public event ProgressChangedEventHandler backgroundWorkerScanSource_ProgressChanged;
        public void ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            // bubble the event up
            var handler = backgroundWorkerScanSource_ProgressChanged;
            if (handler != null)
            {
                handler(this, e);
            }
        }



        private Stack<DirInfo> getSubDirs(string source, int level) {
            Stack<DirInfo> dirNodes = new Stack<DirInfo>(1000);
            IEnumerable<string> rootSubDirs;
            string message;

            if (!Directory.Exists(source))
            {
                message = "Directory [" + source + "] does not exist";
                MyLog.Add(message);
                MessageBox.Show(message);

                return dirNodes;;
            }



            // add the folders (should be movies) under source as root
                
            try
            {
                // subDirs = Directory.getDirectories(currentDir));
                rootSubDirs = Directory.EnumerateDirectories(source);

            }
            catch (UnauthorizedAccessException e)
            {
                MyLog.Add(e.ToString());
                MessageBox.Show(e.Message);
                return dirNodes;;
            }
            catch (PathTooLongException e)
            {
                MyLog.Add(e.ToString());
                MessageBox.Show(e.Message);
                return dirNodes;;
            }
            catch (DirectoryNotFoundException e)
            {
                MyLog.Add(e.ToString());
                MessageBox.Show(e.Message);
                return dirNodes;;
            }

            DirectoryInfo directoryInfo;    
            DirInfo dirInfo = new DirInfo();
            foreach (string subDir in rootSubDirs)
            {
                directoryInfo = new DirectoryInfo(subDir);

                dirInfo.directoryInfo = directoryInfo;
                dirInfo.level = level;

                dirNodes.Push(dirInfo);
            }

            return dirNodes;
        }

        public List<VideoInfosScanSource> ScanSource(List<string> sources, DoWorkEventArgs doWorkEvent)
        {

            if (sources.Count() == 0)
            {
                throw new ArgumentException("sources cannot be empty", "sources");
            }

            ParseVideo parseVideo = new ParseVideo();
            

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
   


            // Data structure to hold names of subfolders to be examined for files.
            Stack<DirInfo> dirNodes = new Stack<DirInfo>(1000);

            List<VideoInfosScanSource> videoInfosScanSources = new List<VideoInfosScanSource>();

            percentComplete = 0;
            backgroundWorker.ReportProgress(percentComplete, "Processing sources..");



            // get the root dirs from each source
            int nbrSources = sources.Count();
            int processingSource = 0;
            foreach (string source in sources)
            {
                percentComplete = (int)Math.Floor((double)processingSource / (double)nbrSources * 100);
                backgroundWorker.ReportProgress(percentComplete, "Scanning source " + source + "..");

                List<VideoInfo> videoInfos = new List<VideoInfo>(10000);

                string sourceAlias = Config.SourceDirectory2Alias(source);

                IEnumerable<string> directories = MyFile.EnumerateDirectories(source, "*", SearchOption.AllDirectories);

                int nbrDirectories = directories.Count();
                int processingDirectory = 0;
                foreach (string directory in directories)
                {
                    MyLog.Add("Scanning: " + directory);

                    VideoInfo videoInfo = parseVideo.ReadDirectory(directory);

                    if (videoInfo == null || videoInfo.videoItem == null || videoInfo.videoItem.title == null ||
                         videoInfo.files == null || videoInfo.files.video == null)
                    {
                        processingDirectory++;
                        continue;
                    }

                    videoInfo.sourceAlias = sourceAlias;
                    videoInfo.videoDirectory = directory;

                    // see if any existing item or new
                    videoInfo.index = videoInfos.Count;
                    string hash = ListVideoInfo.CreateHash(videoInfo);
                    videoInfo.hash = hash;
                    VideoInfo foundVideoInfo = ListVideoInfo.FindVideoInfo("hash", hash);

                    bool bNew = false;
                    if (foundVideoInfo == null)
                    {
                        bNew = true;
                    }
                    if (bNew || foundVideoInfo.added == null || foundVideoInfo.added == DateTime.MinValue)
                    {
                        videoInfo.added = DateTime.UtcNow;
                    }
                    if (bNew || foundVideoInfo.updated == null || foundVideoInfo.updated == DateTime.MinValue)
                    {
                        videoInfo.updated = videoInfo.added;                        
                    }
                   
                    if (!bNew)
                    {
                        // TODO ? needed? found item in list, merge list item with scanned item, scanned item wins
                        videoInfo = ListVideoInfo.MergeVideoInfos(foundVideoInfo, videoInfo);
                    }

                    videoInfos.Add(videoInfo);

                    processingDirectory++;
                    if (processingDirectory % 1 == 0)
                    {
                        percentComplete = (int)Math.Floor((double)processingDirectory / (double)nbrDirectories * 100);
                        string progressMessage = "Scanned " + processingDirectory + " of " + nbrDirectories + " directories\n" + directory.Split(Path.DirectorySeparatorChar).Last() + "..";
                        // progressMessage = directory.Split(Path.DirectorySeparatorChar).Last() + "..";
                        backgroundWorker.ReportProgress(percentComplete, progressMessage);

                        // Thread.Sleep(1000); // dev

                        if (backgroundWorker.CancellationPending)
                        {
                            doWorkEvent.Cancel = true;
                            return null;
                        }
                    }
                    
                } // foreach directory


                VideoInfosScanSource videoInfosScanSource = new VideoInfosScanSource();
                videoInfosScanSource.videoInfos = videoInfos;
                videoInfosScanSource.sourceAlias = sourceAlias;

                videoInfosScanSources.Add(videoInfosScanSource);


                processingSource++;
            } // end foreach source

            // add items to main list .. but not here .. in completed event
            // ListVideoInfo.Clear();
            // ListVideoInfo.AddItems(videoInfos);
           

            

            percentComplete = 100;
            backgroundWorker.ReportProgress(percentComplete, "Completed scan");

            // meh, so completed msg shows
            Thread.Sleep(500);


            return videoInfosScanSources;
        }
    }
}
