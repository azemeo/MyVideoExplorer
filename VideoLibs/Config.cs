using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Xml;
using System.Xml.Serialization;
using System.IO;
using System.Diagnostics;
using System.Reflection;
using System.Windows.Forms;
using System.Runtime.Serialization;
using System.Drawing;

namespace MyVideoExplorer
{


    public class Config
    {
        public static ConfigSettings settings = new ConfigSettings();

        public static bool Load(Form mainForm)
        {
            bool ret = true;

            // app non configurable, so far, settings
            settings.exportFormat = "json";
            settings.exportExt = "json"; // chicken egg


            string configFile = MyFile.EnsureDataFile("settings", settings.exportExt, "config");
            bool bLoadDefaults = false;
            if (File.Exists(configFile))
            {
                // load settings                
                settings = (ConfigSettings)MyDeserialize.FromFile(settings.exportFormat, configFile, settings);
            }
            else
            {
                bLoadDefaults = true;
                ret = false;
            }
            if (settings == null || settings.sources == null || settings.window == null || settings.gallery == null) 
            {
                bLoadDefaults = true;
                ret = false;
            }
            else
            {
                if (settings.window.left > 0 &&
                    settings.window.top > 0 &&
                    settings.window.height > 0 &&
                    settings.window.width > 0)
                {
                    // restore position/size
                    mainForm.Left = settings.window.left;
                    mainForm.Top = settings.window.top;
                    mainForm.Height = settings.window.height;
                    mainForm.Width = settings.window.width;
                }

                if (settings.window.maximized == true)
                {
                    // restore to maximized state
                    mainForm.WindowState = FormWindowState.Maximized;
                }
            }

            // could not load settings, so set minimal defaults
            if (bLoadDefaults)
            {
                // meh, check all for defaults
            }

            // ensure other settings exist, else default
            if (settings == null)
            {
                settings = new ConfigSettings();
                bLoadDefaults = true;
            }
            if (settings.sources == null)
            {
                settings.sources = new List<ConfigSettings.Source>(); ;   
            }

            if (settings.gallery == null)
            {
                settings.gallery = new ConfigSettings.Gallery();
                bLoadDefaults = true; 
            }
            if (settings.gallery.backColor == Color.Empty)
            {
                settings.gallery.backColor = Color.DarkSlateBlue;
            }

            if (bLoadDefaults)
            {
                settings.gallery.enable = false;
                settings.gallery.cachePosterThumbnails = true;
            }

            // app non configurable, so far, settings
            settings.exportFormat = "json";
            settings.exportExt = "json";

            return ret;
        }

        public static bool Save(Form formMain)
        {
            // save main window size/position
            settings.window.left = formMain.Left;
            settings.window.top = formMain.Top;
            settings.window.height = formMain.Height;
            settings.window.width = formMain.Width;

            // save maximized state
            settings.window.maximized = formMain.WindowState == FormWindowState.Maximized ? true : false;

            // set modified, version
            settings.about = GetConfigSettingsAbout();

            string configFile = MyFile.EnsureDataFile("settings", settings.exportExt, "config");

            if (configFile == null)
            {
                return false;
            }

            MyLog.RotateFiles(configFile);

            // save new settings
            MySerialize.ToFile(settings.exportFormat, configFile, settings);

            return true;
        }

        public static string SourceDirectory2Alias(string directory)
        {

            foreach (ConfigSettings.Source source in settings.sources)
            {
                if (directory.StartsWith(source.directory))
                {
                    return source.alias;
                }
            }
            return null;
        }

        public static ConfigSettings.Source GetSourceByAlias(string alias)
        {
            if (String.IsNullOrEmpty(alias))
            {
                return null;
            }

            foreach (ConfigSettings.Source source in settings.sources)
            {
                if (source == null || source.alias == null)
                {
                    continue;
                }
                if (source.alias == alias)
                {
                    return source;
                }
            }
            return null;
        }

        public static ConfigSettings.About GetConfigSettingsAbout()
        {
            ConfigSettings.About about = new ConfigSettings.About();
            about.modifiedDate = DateTime.UtcNow;

            FileVersionInfo versionInfo = GetVersionInfo();
            Version version = GetVersion();
            string buildDate = GetBuildDate();
            about.version = version.ToString();
            about.buildDate = buildDate;
            about.product = versionInfo.ProductName;

            return about;
        }


        public static string GetAboutInfo() 
        {
            string about = "";
            FileVersionInfo versionInfo = GetVersionInfo();
            Version version = GetVersion();
            string buildDate = GetBuildDate();

            about += versionInfo.ProductName + "\n";
            about += versionInfo.LegalCopyright + "\n";
            about += "\n";
            about += "Version: " + version.ToString() + "\n";
            about += "Build: " + buildDate + "\n";

            return about;
        }

        public static FileVersionInfo GetVersionInfo()
        {
            FileVersionInfo versionInfo = FileVersionInfo.GetVersionInfo(Assembly.GetEntryAssembly().Location);
            return versionInfo;
        }

        public static Version GetVersion()
        {
            System.Reflection.Assembly assembly = System.Reflection.Assembly.GetExecutingAssembly();
            System.Reflection.AssemblyName assemblyName = assembly.GetName();
            Version version = assemblyName.Version;
            return version;
        }

        public static string GetBuildDate()
        {
            string buildDate = Properties.Resources.BuildDate;
            if (!String.IsNullOrEmpty(buildDate))
            {
                buildDate = buildDate.Trim();
            }
            return buildDate;
        }

    }
}
