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
using System.Drawing;

namespace MyVideoExplorer
{
    public class GalleryImageThumbnailInfo
    {
        public Image thumbnail;
        public bool fromCache;
        public bool createdCache;
    }

    class BuildGalleryImages
    {
        private BackgroundWorkerBuildGalleryImages backgroundWorkerBuildGalleryImages;

        // so this user control can update other user controls
        private SubFormProgress subFormProgress;

        public BuildGalleryImages()
        {
            // open file, monitor state
            backgroundWorkerBuildGalleryImages = new BackgroundWorkerBuildGalleryImages();
            backgroundWorkerBuildGalleryImages.Initialize();
            backgroundWorkerBuildGalleryImages.backgroundWorkerBuildGalleryImages_ProgressChanged += new ProgressChangedEventHandler(BackgroundWorkerBuildGalleryImages_ProgressChanged);
            backgroundWorkerBuildGalleryImages.backgroundWorkerBuildGalleryImages_RunWorkerCompleted += new RunWorkerCompletedEventHandler(BackgroundWorkerBuildGalleryImages_RunWorkerCompleted);
        }

        public void AddAccessToSubForms(SubFormProgress subFormProgress)
        {
            this.subFormProgress = subFormProgress;
        }

        public bool Build(List<VideoInfo> videoInfos)
        {
            backgroundWorkerBuildGalleryImages.Run(videoInfos);

            return true;
        }

        public void Abort()
        {
            if (backgroundWorkerBuildGalleryImages != null)
            {
                backgroundWorkerBuildGalleryImages.Abort();
            }
        }

        public event RunWorkerCompletedEventHandler backgroundWorkerBuildGalleryImages_RunWorkerCompleted;
        protected void BackgroundWorkerBuildGalleryImages_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            List<VideoInfo> videoInfos = null;

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
                videoInfos = (List<VideoInfo>)e.Result;

                subFormProgress.Text("Ready");
                subFormProgress.Value(0);
            }

            // bubble the event up
            var handler = backgroundWorkerBuildGalleryImages_RunWorkerCompleted;
            if (handler != null)
            {
                handler(videoInfos, e);
            }
        }

        /// <summary>
        /// update progress of background worker
        /// used for ScanSource and FilterSource
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void BackgroundWorkerBuildGalleryImages_ProgressChanged(object sender, ProgressChangedEventArgs e)
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


        public static bool ThumbnailsAlreadySet() 
        {
            List<VideoInfo> videoInfos = ListVideoInfo.GetList();
            int nbrThumbnails = videoInfos.Where(x => x.files.posterThumbnail != null).Count();

            long thumbnailCachesize = MyFile.DirectorySize(@"cache\gallery", "poster*.jpg");

            bool thumbnailsSet;

            // if thumbnails set in list (nbrThumbnails > 0), but cache empty (thumbnailCachesize == 0)
            // assume intent is to rebuild app thumbnails, so thumbnailsSet = false

            // so thumbnails set only if set in list and set in cache
            if (nbrThumbnails > 0 && thumbnailCachesize > 0)
            {
                thumbnailsSet = true;
            }
            else
            {
                thumbnailsSet = false;
            }
            return thumbnailsSet;
        }


        public static GalleryImageThumbnailInfo GetCachedThumbnail(VideoInfo videoInfo)
        {
            GalleryImageThumbnailInfo galleryImageThumbnailInfo = new GalleryImageThumbnailInfo();
            galleryImageThumbnailInfo.fromCache = false;
            galleryImageThumbnailInfo.createdCache = false;
            galleryImageThumbnailInfo.thumbnail = null;

            Image thumbnail = null;
            string cachedThumbnailFullName = MyFile.EnsureDataFile("poster_" + videoInfo.hash, "jpg", @"cache\gallery");
            if (Config.settings.gallery.cachePosterThumbnails && File.Exists(cachedThumbnailFullName))
            {
                // use file stream so files not locked
                FileStream fileStream = new FileStream(cachedThumbnailFullName, FileMode.Open, FileAccess.Read);
                thumbnail = Image.FromStream(fileStream);
                fileStream.Close();
                // thumbnail = Image.FromFile(cachedThumbnailFile); // locks file

                galleryImageThumbnailInfo.fromCache = true;
            }
            else if (videoInfo.files.poster == null)
            {
                thumbnail = null;
            }
            else
            {
                VideoItemFile videoItemFile = videoInfo.files.poster;
                string posterFullName = videoInfo.GetFullName(videoItemFile);

                // skip images smaller than y or larger than x
                if (videoItemFile.Length < 100)
                {
                    MyLog.Add("Get Thumbnail: Skipping " + posterFullName + " " + MyFile.FormatSize(videoItemFile.Length));
                    thumbnail = null;
                }
                if (videoItemFile.Length > 5 * 1048576)
                {
                    MyLog.Add("Get Thumbnail: Skipping " + posterFullName + " " + MyFile.FormatSize(videoItemFile.Length));
                    thumbnail = null;
                }

                try
                {
                    if (!File.Exists(posterFullName))
                    {
                        thumbnail = null;
                    }
                    else
                    {
                        // size of thumbails .. TODO make a config setting
                        thumbnail = MyImage.GetThumbnail(posterFullName, 165, 250, Color.Black);
                        if (Config.settings.gallery.cachePosterThumbnails && thumbnail != null)
                        {
                            // clone image so files not locked
                            if (MyImage.SaveJpgImage((Image)thumbnail.Clone(), cachedThumbnailFullName))
                            {
                                galleryImageThumbnailInfo.createdCache = true;
                            }
                        }
                    }
                }
                catch (OutOfMemoryException)
                {
                    // Image.FromFile will throw this if file is invalid/corrupted; Don't ask me why
                    MyLog.Add("Invalid Image; Unable to read " + posterFullName + " " + MyFile.FormatSize(videoItemFile.Length));
                    thumbnail = null;
                }
                catch (Exception ei)
                {
                    MyLog.Add(ei.ToString());
                    thumbnail = null;
                }
            }

            galleryImageThumbnailInfo.thumbnail = thumbnail;
            return galleryImageThumbnailInfo;
        }
    }
}
