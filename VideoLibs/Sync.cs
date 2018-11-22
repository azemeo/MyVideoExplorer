using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.IO;

namespace MyVideoExplorer
{
    class Sync
    {

        public static SyncSettings syncSettings = new SyncSettings();

        public static bool Load()
        {
            bool ret = true;



            string syncFile = MyFile.EnsureDataFile("sync", Config.settings.exportExt, "sync");
            if (File.Exists(syncFile))
            {
                // load settings                
                syncSettings = (SyncSettings)MyDeserialize.FromFile(Config.settings.exportFormat, syncFile, syncSettings);

                if (syncSettings.guid == null || syncSettings.about == null)
                {
                    syncSettings.Initialize();
                }
            }
            else
            {
                syncSettings.Initialize();
            }
 

            return ret;
        }

        public static bool Save()
        {


            string syncFile = MyFile.EnsureDataFile("sync", Config.settings.exportExt, "sync");

            if (syncFile == null)
            {
                return false;
            }

            MyLog.RotateFiles(syncFile);

            // save new settings
            MySerialize.ToFile(Config.settings.exportFormat, syncFile, syncSettings);

            return true;
        }
    }
}
