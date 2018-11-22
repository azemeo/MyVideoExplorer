using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.IO;
using System.Xml.Serialization;
using System.Runtime.Serialization;

namespace MyVideoExplorer
{



    /// <summary>
    /// used for video info
    /// </summary>
    [Serializable]
    [DataContract(Name = "VideoInfo")]
    public class VideoInfo
    {
        [DataMember(Name = "videoItem")]
        public VideoItem videoItem;
        [DataMember(Name = "files")]
        public VideoItemFiles files;

        [DataMember(EmitDefaultValue = false)]
        public string sourceAlias;      // video source alias
        [DataMember(EmitDefaultValue = false)]
        public string videoDirectory;   // where video stored, minus source path

        // app specific flags, but serialize        
        [DataMember(EmitDefaultValue = false)]
        public string hash;             // hash of current object; used to determine if object updated 
        // see CreateHash() title, year, tmdbid, imdbid
        [DataMember(EmitDefaultValue = false)]
        public DateTime added;          // when added
        [DataMember(EmitDefaultValue = false)]
        public DateTime updated;        // when updated by user edit, or rescan and diff detected, or download from website
        [DataMember(EmitDefaultValue = false)]
        public DateTime syncUp;         // when uploaded to website
        [DataMember(EmitDefaultValue = false)]
        public DateTime syncDown;       // when downloaded from website



        // app only flags, so dont serialize
        [NonSerialized]
        [XmlIgnore]
        public bool filter;             // whether item is filtered in teh list ie dont show 
        [NonSerialized]
        [XmlIgnore]
        public bool edited;             // whether item has been edited
        [NonSerialized]
        [XmlIgnore]
        public int index;               // current index in list .. for quick find, but not guaranteed
                                        // so validate with hash after find






        public void Initialize()
        {
            // initialize custom fields
            videoItem = new VideoItem();
            videoItem.actors = new List<VideoItemActor<string, string>> { };
            videoItem.directors = new List<VideoItemDirector<string>> { };
            videoItem.encoding = new VideoEncoding();
            videoItem.genres = new List<VideoItemGenre<string>> { };
            videoItem.tags = new List<VideoItemTag<string>> { };
            videoItem.watched = "NO";

            files = new VideoItemFiles();
            files.others = new List<VideoItemFile>();
            files.images = new List<VideoItemFile>();
        }

        public VideoItem MergeVideoItemWith(VideoInfo videoInfo)
        {
            return ListVideoInfo.MergeVideoItems(videoItem, videoInfo.videoItem);
        }

        public string GetFullName(VideoItemFile videoItemFile)
        {
            if (String.IsNullOrEmpty(videoDirectory))
            {
                return null;
            }
            if (videoItemFile == null || String.IsNullOrEmpty(videoItemFile.Name))
            {
                return null;
            }
            string fullName = videoDirectory;
            if (!String.IsNullOrEmpty(videoItemFile.SubDirectory))
            {
                fullName += @"\" + videoItemFile.SubDirectory;
            }
            fullName += @"\" + videoItemFile.Name;
            // MyLog.Add("VideoInfo GetFullName : " + fullName);
            return fullName;
        }

    }

    public class SortVideoInfo : IComparer<VideoInfo>
    {
        private string sortColumn;
        private int sortOrder;

        protected SortVideoInfo()
        {
        }

        public SortVideoInfo(string sortColumn, int sortOrder)
        {
            this.sortColumn = sortColumn;
            this.sortOrder = sortOrder;
        }

        public int Compare(VideoInfo x, VideoInfo y)
        {
            int compare = 0;

            if (x.videoItem == null || y.videoItem == null) {
                return compare;
            }
            if (x.files == null || y.files == null)
            {
                return compare;
            }

            switch (sortColumn)
            {
                case "LAST_PLAYED":
                    compare = x.videoItem.lastPlayed.CompareTo(y.videoItem.lastPlayed);
                    break;
                case "NUMBER_FILES":
                    compare = x.files.qty.CompareTo(y.files.qty);
                    break;
                case "PLAY_COUNT":
                    compare = x.videoItem.playCount.CompareTo(y.videoItem.playCount);
                    break;
                case "YEAR":
                    compare = x.videoItem.year.CompareTo(y.videoItem.year);
                    break;
                case "TITLE":
                default:
                    if (String.IsNullOrEmpty(x.videoItem.title) || String.IsNullOrEmpty(y.videoItem.title))
                    {
                        compare = 0;
                    }
                    else
                    {
                        compare = x.videoItem.title.CompareTo(y.videoItem.title);
                    }
                    break;
            }
            if (sortOrder == SortOrders.DESC)
            {
                compare *= -1;
            }
            return compare;
        }
    }

    public class VideoInfosScanSource
    {
        [NonSerialized]
        [XmlIgnore]
        public List<VideoInfo> videoInfos;
        [NonSerialized]
        [XmlIgnore]
        public string sourceAlias;
    }



}
