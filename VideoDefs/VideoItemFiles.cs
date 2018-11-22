using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.IO;
using System.Xml.Serialization;
using System.Runtime.Serialization;
using System.Drawing;

namespace MyVideoExplorer
{
    /// <summary>
    /// used for file structure
    /// </summary>
    [Serializable]
    [DataContract(Name = "VideoItemFiles")]
    public class VideoItemFiles
    {
        [DataMember(Name = "mve", EmitDefaultValue = false)]
        public VideoItemFile mve;
        [DataMember(Name = "xbmc", EmitDefaultValue = false)]
        public VideoItemFile xbmc;
        [DataMember(Name = "mb", EmitDefaultValue = false)]
        public VideoItemFile mb;
        [DataMember(Name = "poster", EmitDefaultValue = false)]
        public VideoItemFile poster;
        [DataMember(Name = "fanart", EmitDefaultValue = false)]
        public VideoItemFile fanart;
        [DataMember(Name = "video", EmitDefaultValue = false)]
        public VideoItemFile video;
        [XmlArrayItem("image")]
        [DataMember(Name = "images")]
        public List<VideoItemFile> images;
        [XmlArrayItem("other")]
        [DataMember(Name = "others")]
        public List<VideoItemFile> others;
        [DataMember(Name = "qty")]
        public int qty;

        // app specific properties; not serialized
        [NonSerialized]
        [XmlIgnore]
        public Image posterThumbnail; 
    }

    [Serializable]
    [DataContract(Name = "VideoItemFile")]
    public class VideoItemFile
    {
        [DataMember(EmitDefaultValue = false)]
        public string Extension;
        /// <summary>
        /// Gets the path relative to the video directory; may be empty
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public string SubDirectory;
        [DataMember]
        public long Length;
        /// <summary>
        /// Gets the name of the file
        /// </summary>
        [DataMember(EmitDefaultValue = false)]
        public string Name;
        // http://stackoverflow.com/questions/10277741/how-can-fileinfo-lastwritetime-be-earlier-than-fileinfo-creationtime
        // [DataMember(EmitDefaultValue = false)]
        // public DateTime LastAccessTimeUtc;




        public void Set(string videoDirectory, FileInfo fileInfo) 
        {
            Extension = fileInfo.Extension;
            // adding SubDirectory and not FullName to reduce json/xml size
            // so fullName requires joining videoInfo.videoDirectory + subDirectory + Name
            // see videoInfo.GetFullName() or fileListInfo.GetFullName()
            SubDirectory = Path.GetDirectoryName(fileInfo.FullName).Replace(videoDirectory, "");
            Length = fileInfo.Length;
            Name = fileInfo.Name;

            // not using create/update/update times .. so not adding to reduce json/xml size

            // MyLog.Add("VideoItemFile Set : subdir:" + SubDirectory + " name:" + Name);
        }

        
    }


    public class VideoItemFileInfo
    {
        public VideoInfo videoInfo;
        public VideoItemFile videoItemFile;
        public long elapsed;

        public string GetFullName()
        {
            if (videoInfo == null || String.IsNullOrEmpty(videoInfo.videoDirectory))
            {
                return null;
            }
            if (videoItemFile == null || String.IsNullOrEmpty(videoItemFile.Name))
            {
                return null;
            }
            string fullName = videoInfo.videoDirectory;
            if (!String.IsNullOrEmpty(videoItemFile.SubDirectory))
            {
                fullName += @"\" + videoItemFile.SubDirectory;
            }
            fullName += @"\" + videoItemFile.Name;
            // MyLog.Add("VideoItemFileInfo GetFullName : " + fullName);
            return fullName;
        }

        public FileInfo GetFileInfo()
        {
            string fullName = GetFullName();
            if (fullName == null)
            {
                return null;
            }
            FileInfo fileInfo = MyFile.FileInfo(fullName);

            return fileInfo;
        }
    }
}
