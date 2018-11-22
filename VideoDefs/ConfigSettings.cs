using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Xml;
using System.Xml.Serialization;
using System.Runtime.Serialization;
using System.Drawing;

namespace MyVideoExplorer
{
    /// <summary>
    /// configuration settings for app
    /// will be serialized to/from xml
    /// </summary>
    [Serializable]
    [DataContract]
    public class ConfigSettings
    {
        // main window position
        [DataContractAttribute(Name = "window")]
        public class Window
        {
            [DataMember]
            public int left;
            [DataMember]
            public int top;
            [DataMember]
            public int height;
            [DataMember]
            public int width;
            [DataMember]
            public bool maximized;
        }

        // video sources
        [DataContractAttribute(Name = "source")]
        public class Source
        {
            [DataMember]
            public string alias;
            [DataMember]
            public string directory;
            [DataMember]
            public DateTime lastScanned;
            [DataMember]
            public string type;
        }

        // gallery settings
        [DataContractAttribute(Name = "gallery")]
        public class Gallery
        {
            [DataMember]
            public bool enable;

            [NonSerialized]
            [XmlIgnore]
            public Color backColor;

            [DataMember]
            public bool cachePosterThumbnails;

            [DataMember(Name = "backColor")]
            public string BackColorAsHTML
            {
                get { try { return ColorTranslator.ToHtml(backColor); } catch (Exception) { return Color.SlateBlue.ToString(); } }
                set { try { backColor = ColorTranslator.FromHtml(value); } catch (Exception) { backColor = Color.SlateBlue; } }
            }
        }

        [DataContractAttribute(Name = "about")]
        public class About
        {
            [DataMember]
            public DateTime modifiedDate;
            [DataMember]
            public string version;
            [DataMember]
            public string buildDate;
            [DataMember]
            public string product;
        }

        [DataMember]
        public bool markWatched;
        [DataMember]
        public bool createMB;
        [DataMember]
        public bool createMVE;
        [DataMember]
        public bool createXBMC;
        [DataMember]
        public bool updateMB;
        [DataMember]
        public bool updateXBMC;
        [DataMember]
        public int watchedAfter;

        [DataMember]
        public Gallery gallery = new Gallery();

        [XmlArrayItem("source")]
        [DataMember(Name = "sources")]
        public List<Source> sources = new List<Source>();

        [DataMember]
        public Window window = new Window();

        [DataMember]
        public About about = new About();

        // app only flags, so dont serialize
        [NonSerialized]
        public string exportFormat;
        [NonSerialized]
        public string exportExt; 
    }
}
