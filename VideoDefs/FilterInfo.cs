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
    /// used for filtering video items
    /// </summary>
    [Serializable]
    [DataContract(Name = "FilterInfo")]
    public class FilterInfo
    {
        [DataMember(Name = "filterType")]
        public int filterType;          // 0 criteria, 1 selects

        public FilterInfo()
        {
            filterType = 0;         // 0 criteria, 1 selects
            watched = "ANY";
        }

        [DataMember(EmitDefaultValue = false)]
        public string name;
        [DataMember(EmitDefaultValue = false)]
        public string description;

        [DataMember(EmitDefaultValue = false)]
        public string title;
        [DataMember(EmitDefaultValue = false)]
        public int yearFrom;
        [DataMember(EmitDefaultValue = false)]
        public int yearTo;
        [DataMember(EmitDefaultValue = false)]
        public string year;             // from criteria, comma seperated
        [DataMember(EmitDefaultValue = false)]
        public int playCountFrom;
        [DataMember(EmitDefaultValue = false)]
        public int playCountTo;
        [DataMember(EmitDefaultValue = false)]
        public string playCount;       // from criteria, comma seperated
        [DataMember(EmitDefaultValue = false)]
        public string watched;
        [DataMember(EmitDefaultValue = false)]
        public string sortColumn;
        [DataMember(EmitDefaultValue = false)]
        public int sortOrderIndex;

        [DataMember(EmitDefaultValue = false)]
        public string mpaa;             // xbmc mpaa, mb3 MPAARating

        [DataMember(EmitDefaultValue = false)]
        public string genre;            // comma separated; xbmc multiple genre, mb3 Genres/Genre
        [DataMember(EmitDefaultValue = false)]
        public string tag;              // comma separated; xbmc multiple tag

        [DataMember(EmitDefaultValue = false)]
        public string director;         // comma separated; xbmc multiple director
        [DataMember(EmitDefaultValue = false)]
        public string actor;            // comma separated; xbmc multiple actor/name, mb3 Persons

        [DataMember(EmitDefaultValue = false)]
        public int imdbRatingFrom;
        [DataMember(EmitDefaultValue = false)]
        public int imdbRatingTo;
        [DataMember(EmitDefaultValue = false)]
        public string imdbRating;       // from criteria, comma seperated
        [DataMember(EmitDefaultValue = false)]
        public int ratingFrom;
        [DataMember(EmitDefaultValue = false)]
        public int ratingTo;
        [DataMember(EmitDefaultValue = false)]
        public string rating;           // from criteria, comma seperated

        [DataMember(EmitDefaultValue = false)]
        public string height;           // from criteria, comma seperated
        [DataMember(EmitDefaultValue = false)]
        public string width;            // from criteria, comma seperated

        [DataMember(EmitDefaultValue = false)]
        public string source;           // bluray, dvd, streaming, encoded
        [DataMember(EmitDefaultValue = false)]
        public string version;          // directors, extended, unrated
        [DataMember(EmitDefaultValue = false)]
        public string sourceAlias;      // video source name

        [DataMember(Name = "about")]
        public ConfigSettings.About about;


    }

    public struct SortOrders
    {
        public const int ASC = 0;
        public const int DESC = 1;
    }

}


