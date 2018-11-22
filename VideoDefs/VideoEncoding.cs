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
    [DataContract]
    public class VideoEncoding
    {
        [DataMember]
        public int bitrate;             // b/s
        [DataMember(EmitDefaultValue = false)]
        public string codec;            // codec used; h264

        [DataMember]
        public int width;
        [DataMember]
        public int height;              

    }

}
