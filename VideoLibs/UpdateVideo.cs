using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.IO;
using System.Xml;

namespace MyVideoExplorer
{
    class UpdateVideo
    {


        /// <summary>
        /// parse the MVE .mve file
        /// </summary>
        /// <param name="mveFile"></param>
        /// <returns></returns>
        public bool UpdateMVE(VideoInfo videoInfo)
        {
            if (!Config.settings.createMVE)
            {
                return false;
            }

            string videoInfoFile = videoInfo.videoDirectory + @"\movie.mve";
            bool ret = MySerialize.ToFile(Config.settings.exportFormat, videoInfoFile, videoInfo);
            string message = "mve video item to " + videoInfoFile;
            if (ret)
            {
                MyLog.Add("wrote " + videoInfoFile);
            }
            else
            {
                MyLog.Add("error writing to " + videoInfoFile);
            }
            return ret;
        }

        /// <summary>
        /// update the XBMC .nfo file
        /// </summary>
        /// <param name="videoItemFile"></param>
        /// <param name="videoItem"></param>
        /// <returns></returns>
        public bool UpdateXBMC(VideoInfo videoInfo)
        {
            // MyLog.Add("UpdateXBMC");

            string videoFullName = null;
            string fileContents = null;

            if (videoInfo.files == null || videoInfo.files.xbmc == null)
            {
                if (Config.settings.createXBMC)
                {                    
                    videoFullName = videoInfo.videoDirectory + @"\movie.nfo";
                    fileContents = GetDefaultXBMCxml();
                }
                else
                {
                    return false;
                }
            }
            else if (!Config.settings.updateXBMC)
            {
                return false;
            }
            else
            {
                videoFullName = videoInfo.GetFullName(videoInfo.files.xbmc);
                fileContents = MyFile.ReadAllText(videoFullName);
            }
            if (fileContents == null || videoFullName == null)
            {
                return false;
            }
            
            VideoItem videoItem = videoInfo.videoItem;


            XmlDocument doc = MyXMLDoc.LoadXml(fileContents);
            if (doc == null)
            {
                return false;
            }

            MyXMLDoc.SetSingleNodeString(doc, "/movie/title", videoItem.title);
            MyXMLDoc.SetSingleNodeString(doc, "/movie/plot", videoItem.plot);
            MyXMLDoc.SetSingleNodeString(doc, "/movie/set", videoItem.movieset);
            MyXMLDoc.SetSingleNodeString(doc, "/movie/tagline", videoItem.tagline);
            MyXMLDoc.SetSingleNodeString(doc, "/movie/id", videoItem.imdbId);
            MyXMLDoc.SetSingleNodeString(doc, "/movie/tmdbId", videoItem.tmdbId);
            MyXMLDoc.SetSingleNodeString(doc, "/movie/mpaa", videoItem.mpaa);

            MyXMLDoc.SetSingleNodeDecimal(doc, "/movie/rating", videoItem.imdbRating);

            MyXMLDoc.SetSingleNodeInt(doc, "/movie/year", videoItem.year);
            MyXMLDoc.SetSingleNodeInt(doc, "/movie/runtime", videoItem.runtime);
            MyXMLDoc.SetSingleNodeInt(doc, "/movie/playcount", videoItem.playCount);
            int watched = VideoFileEnums.watched.GetValueByKey(videoItem.watched);
            // either watched or not
            if (watched != 0 && watched != 1)
            {
                watched = 0; 
            }
            MyXMLDoc.SetSingleNodeInt(doc, "/movie/watched", watched);

            bool ret = MyXMLDoc.SaveXML(doc, videoFullName);

            if (ret)
            {
                MyLog.Add("wrote " + videoFullName);
            }
            else
            {
                MyLog.Add("error writing to " + videoFullName);
            }
            return ret;
        }

        private string GetDefaultXBMCxml()
        {
            string xml = @"
<movie>
    <title></title>
    <originaltitle></originaltitle>
    <set></set>
    <sorttitle></sorttitle>
    <rating></rating>
    <year></year>
    <top250></top250>
    <votes></votes>
    <outline></outline>
    <plot></plot>
    <tagline></tagline>
    <runtime></runtime>
    <thumb></thumb>
    <fanart></fanart>
    <mpaa></mpaa>
    <certification></certification>
    <id></id>
    <tmdbId></tmdbId>
    <trailer></trailer>
    <country></country>
    <premiered></premiered>
    <watched></watched>
    <playcount></playcount>
    <genre></genre>
    <studio></studio>
    <credits></credits>
    <director></director>
    <actor />
    <producer />
    <languages></languages>
</movie>";
            return xml;
        }



        /// <summary>
        /// update the MB .xml file
        /// </summary>
        /// <param name="videoItemFile"></param>
        /// <param name="videoItem"></param>
        /// <returns></returns>
        public bool UpdateMB(VideoInfo videoInfo)
        {
            string videoFullName = null;
            string fileContents = null;

            if (videoInfo.files == null || videoInfo.files.mb == null)
            {
                if (Config.settings.createMB)
                {
                    videoFullName = videoInfo.videoDirectory + @"\movie.xml";
                    fileContents = GetDefaultMBxml();
                }
                else
                {
                    return false;
                }
            }
            else if (!Config.settings.updateMB)
            {
                return false;
            } 
            else 
            {
                videoFullName = videoInfo.GetFullName(videoInfo.files.mb);
                fileContents = MyFile.ReadAllText(videoFullName);
            }
            if (fileContents == null || videoFullName == null)
            {
                return false;
            }
            VideoItem videoItem = videoInfo.videoItem;

            XmlDocument doc = MyXMLDoc.LoadXml(fileContents);
            if (doc == null)
            {
                return false;
            }

            MyXMLDoc.SetSingleNodeString(doc, "/Title/LocalTitle", videoItem.title);
            MyXMLDoc.SetSingleNodeString(doc, "/Title/Overview", videoItem.plot);
            MyXMLDoc.SetSingleNodeString(doc, "/Title/set", videoItem.movieset);
            MyXMLDoc.SetSingleNodeString(doc, "/Title/tagline", videoItem.tagline);
            MyXMLDoc.SetSingleNodeString(doc, "/Title/IMDB", videoItem.imdbId);
            MyXMLDoc.SetSingleNodeString(doc, "/Title/TMDbId", videoItem.tmdbId);
            MyXMLDoc.SetSingleNodeString(doc, "/Title/ContentRating", videoItem.mpaa);

            MyXMLDoc.SetSingleNodeDecimal(doc, "/Title/Rating", videoItem.imdbRating);

            MyXMLDoc.SetSingleNodeInt(doc, "/Title/ProductionYear", videoItem.year);
            MyXMLDoc.SetSingleNodeInt(doc, "/Title/RunningTime", videoItem.runtime);

            bool ret = MyXMLDoc.SaveXML(doc, videoFullName);
            if (ret)
            {
                MyLog.Add("wrote " + videoFullName);
            }
            else
            {
                MyLog.Add("error writing to " + videoFullName);
            }
            return ret;
        }

        private string GetDefaultMBxml()
        {
            string xml = @"
<Title>
  <ContentRating></ContentRating>
  <Added></Added>
  <LockData></LockData>
  <Overview></Overview>
  <LocalTitle>Alex Cross</LocalTitle>
  <PremiereDate></PremiereDate>
  <Trailers />
  <Metascore></Metascore>
  <AwardSummary></AwardSummary>
  <Budget></Budget>
  <Revenue></Revenue>
  <Rating></Rating>
  <VoteCount></VoteCount>
  <ProductionYear></ProductionYear>
  <RunningTime></RunningTime>
  <IMDB></IMDB>
  <TMDbId></TMDbId>
  <TMDbCollectionId></TMDbCollectionId>
  <Taglines />
  <Genres />
  <Studios />
  <PlotKeywords />
  <Persons />
</Title>";
            return xml;
        }
   
    }
}
