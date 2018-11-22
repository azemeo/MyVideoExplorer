using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Xml.Serialization;
using System.Runtime.Serialization;

namespace MyVideoExplorer
{
    [Serializable]
    [DataContract(Name = "VideoInfoStats")]
    public class VideoInfoStats
    {
        [DataMember(Name = "actor")]
        public List<VideoInfoStatsQty<string, int>> actor;  
        [DataMember(Name = "director")]
        public List<VideoInfoStatsQty<string, int>> director;
        [DataMember(Name = "genre")]
        public List<VideoInfoStatsQty<string, int>> genre;
        [DataMember(Name = "mpaa")]
        public List<VideoInfoStatsQty<string, int>> mpaa;
        [DataMember(Name = "source")]
        public List<VideoInfoStatsQty<string, int>> source;
        [DataMember(Name = "sourceAlias")]
        public List<VideoInfoStatsQty<string, int>> sourceAlias;
        [DataMember(Name = "tag")]
        public List<VideoInfoStatsQty<string, int>> tag;
        [DataMember(Name = "version")]
        public List<VideoInfoStatsQty<string, int>> version;
        [DataMember(Name = "watched")]
        public List<VideoInfoStatsQty<string, int>> watched;

        [DataMember(Name = "height")]
        public List<VideoInfoStatsQty<int, int>> height;
        [DataMember(Name = "imdbRating")]
        public List<VideoInfoStatsQty<decimal, int>> imdbRating; 
        [DataMember(Name = "playCount")]
        public List<VideoInfoStatsQty<int, int>> playCount;  
        [DataMember(Name = "rating")]
        public List<VideoInfoStatsQty<int, int>> rating;
        [DataMember(Name = "runtime")]
        public List<VideoInfoStatsQty<int, int>> runtime;
        [DataMember(Name = "width")]
        public List<VideoInfoStatsQty<int, int>> width;
        [DataMember(Name = "year")]
        public List<VideoInfoStatsQty<int, int>> year;

    }

    // mimic dictionary; class required for serialize as dictionary not usefully serialzable
    /*
    serialized mimic:
    <director>
    <stat>
      <key>Glenn Ford</key>
      <value>1</value>
    </stat>
    serialized dictionary:
    <director xmlns:d2p1="http://schemas.microsoft.com/2003/10/Serialization/Arrays">
    <d2p1:KeyValueOfstringint>
      <d2p1:Key>Delmer Daves</d2p1:Key>
      <d2p1:Value>1</d2p1:Value>
    </d2p1:KeyValueOfstringint>
    */
    [Serializable]
    [DataContract(Name = "stat")]
    public class VideoInfoStatsQty<K, V>
    {
        [XmlArrayItem("key")]
        [DataMember(Name = "key")]
        public K Key { get; set; }
        [XmlArrayItem("value")]
        [DataMember(Name = "value")]
        public V Value { get; set; }

        public VideoInfoStatsQty() { }
        public VideoInfoStatsQty(K key, V val)
        {
            Key = key;
            Value = val;
        }
    }
}
