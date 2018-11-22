using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Windows.Forms;
using System.Diagnostics;

namespace MyVideoExplorer
{
    class MyLink
    {
        private static bool OpenURL(string url)
        {
            bool ret = true;

            // overly simple check if a url
            if (!url.Contains("."))
            {
                return false;
            }
            // make sure at least http prepended
            if (!url.Contains("://"))
            {
                url = "http://" + url;
            }


            try
            {
                // try to open in default browser
                Process.Start(url);
            }
            catch (Exception)
            {
                try
                {
                    // default browser didnt work, so fall back to ie
                    ProcessStartInfo startInfo = new ProcessStartInfo("IExplore.exe", url);
                    Process.Start(startInfo);
                    startInfo = null;
                }
                catch (Exception)
                {
                    // nothing to do
                    ret = false;
                }
            }
            return ret;
        }

        public static void OpenLink(string link)
        {
            string url = link;
            OpenURL(url);
        }

        public static void OpenLink(LinkLabel linkLabel, LinkLabelLinkClickedEventArgs e)
        {
            string url;
            if (e.Link.LinkData != null)
            {
                url = e.Link.LinkData.ToString();
            }
            else
            {
                url = linkLabel.Text.Substring(e.Link.Start, e.Link.Length);
            }

            OpenURL(url);

        }
    }
}
