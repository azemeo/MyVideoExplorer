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

    [Serializable]
    [DataContract(Name = "VideoInfo")]
    public class SyncSettings
    {


        // app specific flags, but serialize        
        [DataMember(EmitDefaultValue = false)]
        public Guid guid;

        [DataMember(EmitDefaultValue = false)]
        public string username;
        [DataMember(EmitDefaultValue = false)]
        public string password;      

        [DataMember(EmitDefaultValue = false)]
        public DateTime syncUp;         // when uploaded to website
        [DataMember(EmitDefaultValue = false)]
        public DateTime syncDown;       // when downloaded from website

        [DataMember(Name = "about")]
        public ConfigSettings.About about;


        public void Initialize()
        {
            guid = Guid.NewGuid();
            about = Config.GetConfigSettingsAbout();

        }

    }
}
