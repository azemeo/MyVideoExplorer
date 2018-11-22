using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Xml.Serialization;
using System.Runtime.Serialization;

namespace MyVideoExplorer
{

    /// <summary>
    /// used for video information
    /// </summary>
    [Serializable]
    [DataContract(Name = "VideoItem")]
    public class VideoItem
    {
        [DataMember(EmitDefaultValue = false)]
        public string title;      // xbmc title, mb3 LocalTitle; user version, often same as tmdb, imdb version
        [DataMember]
        public int year;              // xbmc year, mb3 ProductionYear
        [DataMember(EmitDefaultValue = false)]
        public string movieset;         // xbmc set, mb3 Collection

        [DataMember(EmitDefaultValue = false)]
        public string upc;
        [DataMember(EmitDefaultValue = false)]
        public string tmdbId;           // xbmc tmdbid, mb3 TMDbId
        [DataMember(EmitDefaultValue = false)]
        public string imdbId;           // xbmc id, mb3 IMDbId
        [DataMember]
        public decimal imdbRating;      // 0 to 10; xbmc rating, mb3 IMDBrating
        [DataMember(EmitDefaultValue = false)]
        public string mpaa;             // xbmc mpaa, mb3 MPAARating
        [DataMember]
        public int runtime;           // minutes; xbmc runtime, mb3 RunningTime   

        [XmlArrayItem("genre")]
        [DataMember(Name = "genres", EmitDefaultValue = false)]
        public List<VideoItemGenre<string>> genres;         // xbmc multiple genre, mb3 Genres/Genre

        [XmlArrayItem("tag")]
        [DataMember(Name = "tags", EmitDefaultValue = false)]
        public List<VideoItemTag<string>> tags;           // xbmc multiple tag

        [DataMember(EmitDefaultValue = false)]
        public string tagline;          // xbmc tagline
        [DataMember(EmitDefaultValue = false)]
        public string plot;             // xbmc plot, mb3 Description

        [DataMember(EmitDefaultValue = false)]
        public DateTime lastPlayed;     // xbmc lastplayed
        [DataMember]
        public string watched;          // xbmc watched int; mve string YES NO
        [DataMember]
        public int playCount;           // xbmc playcount

        [XmlArrayItem("director")]
        [DataMember(Name = "directors", EmitDefaultValue = false)]
        public List<VideoItemDirector<string>> directors;  // xbmc multiple director


        [XmlArrayItem("actor")]
        [DataMember(Name = "actors", EmitDefaultValue = false)]
        public List<VideoItemActor<string, string>> actors; // xbmc multiple actor/role, mb3 Persons

        [DataMember]
        public int rating;              // 0 to 10
        [DataMember(EmitDefaultValue = false)]
        public string source;           // bluray, dvd, streaming, encoded
        [DataMember(EmitDefaultValue = false)]
        public string version;          // directors, extended, unrated
        [DataMember(EmitDefaultValue = false)]
        public string notes;
        [DataMember(EmitDefaultValue = false)]
        public string review;

        [DataMember(EmitDefaultValue = false)]
        public VideoEncoding encoding;       // ffmpeg ffprobe info


        public VideoItem()
        {
            // see VideoInfo.Initialize()
        }

    }

    // mimic keyValuePairs; class required for serialize as keyValuePairs not serialzable
    [Serializable]
    [DataContract(Name = "actor")]
    public class VideoItemActor<K, V>
    {
        [XmlArrayItem("name")]
        [DataMember(Name = "name")]
        public K name { get; set; }
        [XmlArrayItem("role")]
        [DataMember(Name = "role")]
        public V role { get; set; }

        public VideoItemActor() {}
        public VideoItemActor(K key, V val)
        {
            name = key;
            role = val;
        }
    }

    public class SortVideoItemActor : IComparer<VideoItemActor<string, string>>
    {
        public int Compare(VideoItemActor<string, string> x, VideoItemActor<string, string> y)
        {
            int compare = 0;
            if (x.name != null && y.name != null)
            {
                compare = x.name.CompareTo(y.name);
            }
            return compare;
        }
    }

    // mimic string; class required for serialize as list string serializes wordy and not customizable
    /*
    serialized mimic:
    <genres>
        <genre>
            <name>foo</name>    
    serialized list<string>
    <genres xmlns:d4p1="http://schemas.microsoft.com/2003/10/Serialization/Arrays" />
        <d4p1:string>awesome</d4p1:string>  

     */
    [Serializable]
    [DataContract(Name = "director")]
    public class VideoItemDirector<S>
    {
        [XmlArrayItem("name")]
        [DataMember(Name = "name")]
        public S name { get; set; }

        public VideoItemDirector() { }
        public VideoItemDirector(S key)
        {
            name = key;
        }
    }

    public class SortVideoItemDirector : IComparer<VideoItemDirector<string>>
    {
        public int Compare(VideoItemDirector<string> x, VideoItemDirector<string> y)
        {
            int compare = 0;
            if (x.name != null && y.name != null)
            {
                compare = x.name.CompareTo(y.name);
            }
            return compare;
        }
    }

    [Serializable]
    [DataContract(Name = "genre")]
    public class VideoItemGenre<S>
    {
        [XmlArrayItem("name")]
        [DataMember(Name = "name")]
        public S name { get; set; }

        public VideoItemGenre() { }
        public VideoItemGenre(S key)
        {
            name = key;
        }
    }

    public class SortVideoItemGenre : IComparer<VideoItemGenre<string>>
    {
        public int Compare(VideoItemGenre<string> x, VideoItemGenre<string> y)
        {
            int compare = 0;
            if (x.name != null && y.name != null)
            {
                compare = x.name.CompareTo(y.name);
            }
            return compare;
        }
    }

    [Serializable]
    [DataContract(Name = "tag")]
    public class VideoItemTag<S>
    {
        [XmlArrayItem("name")]
        [DataMember(Name = "name")]
        public S name { get; set; }

        public VideoItemTag() { }
        public VideoItemTag(S key)
        {
            name = key;
        }
    }

    public class SortVideoItemTag : IComparer<VideoItemTag<string>>
    {
        public int Compare(VideoItemTag<string> x, VideoItemTag<string> y)
        {
            int compare = 0;
            if (x.name != null && y.name != null)
            {
                compare = x.name.CompareTo(y.name);
            }
            return compare;
        }
    }



}
