using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.IO;
using System.Windows.Forms;
using System.Reflection;
using System.Security.Cryptography;
using System.Xml.Serialization;
using System.Diagnostics;
using System.Threading;

namespace MyVideoExplorer
{


    class ListVideoInfo
    {

        private static List<VideoInfo> listVideoInfos;
        // private static PropertyInfo[] propertyInfos;
        // private static FieldInfo[] fieldInfos;

        public static bool CreateList()
        {
            listVideoInfos = new List<VideoInfo>(10000);

            // propertyInfos = typeof(VideoItem).GetProperties();
            // fieldInfos = typeof(VideoItem).GetFields();

            return true;
        }


        public static List<VideoInfo> GetList()
        {
            return listVideoInfos;
        }

        public static void SetList(List<VideoInfo> videoInfos)
        {
            if (listVideoInfos != null)
            {
                lock (listVideoInfos)
                {
                    listVideoInfos = new List<VideoInfo>(videoInfos);
                }
            }
            else
            {
                listVideoInfos = new List<VideoInfo>(videoInfos);
            }
        }


        public static bool Clear()
        {
            bool ret = false;
            if (listVideoInfos != null)
            {
                listVideoInfos.Clear();
                ret = true;
            }
            return ret;
        }

        public static bool AddItem(VideoInfo videoInfo)
        {
            bool ret = false;
            if (videoInfo != null && listVideoInfos != null)
            {
                listVideoInfos.Add(videoInfo);
                ret = true;
            }
            return ret;
        }

        public static bool AddItems(List<VideoInfo> videoInfos)
        {
            bool ret = false;
            if (videoInfos != null && listVideoInfos != null)
            {
                listVideoInfos.AddRange(videoInfos);
                ret = true;
            } 
            return ret;
        }

        public static bool IsEmpty()
        {
            return listVideoInfos == null || listVideoInfos.Count == 0 ? true : false;
        }

        public static VideoItem MergeVideoItems(VideoItem vi1, VideoItem vi2)
        {
            if (vi1 == null || vi2 == null)
            {
                return vi1;
            }

            if (vi2.actors != null && vi2.actors.Count() != 0)
            {
                vi1.actors = vi2.actors;
            }
            if (vi2.directors != null && vi2.directors.Count() != 0)
            {
                vi1.directors = vi2.directors;
            }
            if (vi2.encoding != null)
            {
                if (vi1.encoding == null)
                {
                    vi1.encoding = vi2.encoding;
                }
                else
                {
                    if (vi2.encoding.bitrate != 0)
                    {
                        vi1.encoding.bitrate = vi2.encoding.bitrate;                             
                    }
                    if (vi2.encoding.codec != null)
                    {
                        vi1.encoding.codec = vi2.encoding.codec;
                    }
                    if (vi2.encoding.height != 0)
                    {
                        vi1.encoding.height = vi2.encoding.height;
                    }
                    if (vi2.encoding.width != 0)
                    {
                        vi1.encoding.width = vi2.encoding.width;
                    }
                }
            }
            if (vi2.genres != null && vi2.genres.Count() != 0)
            {
                vi1.genres = vi2.genres;
            }
            if (vi2.imdbId != null)
            {
                vi1.imdbId = vi2.imdbId;
            }
            if (vi2.imdbRating != 0)
            {
                vi1.imdbRating = vi2.imdbRating;
            }
            if (vi2.lastPlayed != DateTime.MinValue)
            {
                vi1.lastPlayed = vi2.lastPlayed;
            }
            if (vi2.movieset != null)
            {
                vi1.movieset = vi2.movieset;
            }
            if (vi2.mpaa != null)
            {
                vi1.mpaa = vi2.mpaa;
            }
            if (vi2.notes != null)
            {
                vi1.notes = vi2.notes;
            }
            if (vi2.playCount != 0)
            {
                vi1.playCount = vi2.playCount;
            }
            if (vi2.plot != null)
            {
                vi1.plot = vi2.plot;
            }
            if (vi2.rating != 0)
            {
                vi1.rating = vi2.rating;
            }
            if (vi2.review != null)
            {
                vi1.review = vi2.review;
            }
            if (vi2.title != null)
            {
                vi1.title = vi2.title;
            }
            if (vi2.source != null)
            {
                vi1.source = vi2.source;
            }
            if (vi2.tagline != null)
            {
                vi1.tagline = vi2.tagline;
            }
            if (vi2.tags != null && vi2.tags.Count() != 0)
            {
                vi1.tags = vi2.tags;
            }
            if (vi2.tmdbId != null)
            {
                vi1.tmdbId = vi2.tmdbId;
            }
            if (vi2.version != null)
            {
                vi1.version = vi2.version;
            }
            if (vi2.watched != null)
            {
                vi1.watched = vi2.watched;
            }
            if (vi2.year != 0)
            {
                vi1.year = vi2.year;
            }

            return vi1;
        }

        public static VideoInfo MergeVideoInfos(VideoInfo vi1, VideoInfo vi2)
        {
            vi1.videoItem = MergeVideoItems(vi1.videoItem, vi2.videoItem);

            return vi1;
        }

        /*
        public static VideoItem MergeVideoItemsFIELDS(VideoItem vi1, VideoItem vi2)
        {
            if (vi1 == null || vi2 == null)
            {
                return vi1;
            }
            foreach (FieldInfo fieldInfo in fieldInfos)
            {
                

                if (fieldInfo.FieldType == typeof(VideoEncoding))
                {

                }
                var value = fieldInfo.GetValue(vi1);
                if (value == null || value.ToString() == "" || value.ToString() == "0" || value.ToString() == "1/1/0001 12:00:00 AM")
                {                    

                    value = fieldInfo.GetValue(vi2);
                    
                    if (value != null && value.ToString() != "" && value.ToString() != "0" && value.ToString() != "1/1/0001 12:00:00 AM")
                    {
                        MyLog.Add("vi2: " + fieldInfo.Name + " " + value.ToString());

                        fieldInfo.SetValue(vi1, value);
                    }
                }
                else
                {
                    MyLog.Add("vi1: " + fieldInfo.Name + " " + value.ToString());
                }
            }

            return vi1;
        }

        public static VideoItem MergeVideoItemsPROPS(VideoItem vi1, VideoItem vi2)
        {
            foreach (PropertyInfo propertyInfo in propertyInfos)
            {
                var value = propertyInfo.GetValue(vi1);
                if (value == null || value.ToString() == "" || value.ToString() == "1/1/0001 12:00:00 AM")
                {
                    value = propertyInfo.GetValue(vi2);
                    if (value != null && value.ToString() != "" && value.ToString() != "1/1/0001 12:00:00 AM")
                    {
                        propertyInfo.SetValue(vi1, value);
                    }
                }
            }

            return vi1;
        }
        */



        /// <summary>
        /// create unique identifier for video
        /// </summary>
        /// <param name="videoItem"></param>
        /// <returns>string hash</returns>
        public static string CreateHash(VideoInfo videoInfo)
        {
            string hash = null;
            if (videoInfo == null || videoInfo.videoItem == null)
            {
                return hash;
            }
            try
            {
                SHA256 sha256 = SHA256Managed.Create();

                // properites which are part of hash
                string hashKey = videoInfo.videoItem.title;
                hashKey += videoInfo.videoItem.year.ToString();
                hashKey += videoInfo.videoItem.tmdbId;
                hashKey += videoInfo.videoItem.imdbId;

                byte[] hashKeyByte = System.Text.Encoding.UTF8.GetBytes(hashKey);

                byte[] hashByte = sha256.ComputeHash(hashKeyByte);

                hash = BitConverter.ToString(hashByte);
                hash = hash.Replace("-", "");
            }
            catch (Exception e)
            {
                MyLog.Add(e.ToString());
            }

            return hash;
        }

        public static bool UpdateVideoInfoList(VideoInfo videoInfo)
        {
            if (videoInfo.index >= 0 && videoInfo.index < listVideoInfos.Count)
            {
                if (listVideoInfos[videoInfo.index].videoDirectory == videoInfo.videoDirectory && 
                    listVideoInfos[videoInfo.index].videoItem.title == videoInfo.videoItem.title)
                {
                    listVideoInfos[videoInfo.index] = videoInfo;
                    return true;
                }
            }
            return false;
        }

        public static VideoInfo FindVideoInfo(string column, string value)
        {
            VideoInfo videoInfo = null;

            if (IsEmpty())
            {
                return videoInfo;
            }
            try
            {

                switch (column)
                {
                    case "hash":
                        videoInfo = listVideoInfos.FirstOrDefault(o => o.hash == value);
                        break;
                    case "index":
                        int index = Convert.ToInt32(value);
                        if (index >= 0 && index < listVideoInfos.Count)
                        {
                            videoInfo = listVideoInfos[index];
                        }
                        break;
                    case "plot":
                        videoInfo = listVideoInfos.FirstOrDefault(o => o.videoItem.plot.Contains(value));
                        break;
                    case "searchTitle":
                        videoInfo = listVideoInfos.FirstOrDefault(o => o.videoItem.title == value);
                        break;
                    case "sortTitle":
                        videoInfo = listVideoInfos.FirstOrDefault(o => o.videoItem.title == value);
                        break;
                    case "year":
                        videoInfo = listVideoInfos.FirstOrDefault(o => o.videoItem.year == Convert.ToInt32(value));
                        break;
                }

            }
            catch (Exception e)
            {
                MyLog.Add(e.ToString());
            }

            if (videoInfo == null)
            {
                // MessageBox.Show("Could not find the [" + column + "] of [" + value + "]");
            }
            return videoInfo;
        }

        /// <summary>
        /// ensure some fields are set in listVideoItems
        /// </summary>
        /// <returns></returns>
        public static bool EnsureVideoInfos()
        {
            int index = 0;
            foreach (VideoInfo videoInfo in listVideoInfos)
            {

                // may not be neccessary to re-calc hash .. prob somewhat expensive to do
                string hash = ListVideoInfo.CreateHash(videoInfo);
                listVideoInfos[index].hash = hash;

                // set index; used for quick search
                listVideoInfos[index].index = index;
                index++;
            }
            return true;
        }

        public static bool SettingsOkToSaveVideoInfo()
        {
            if (Config.settings.createMB ||
                Config.settings.createMVE ||
                Config.settings.createXBMC ||
                Config.settings.updateMB ||
                Config.settings.updateXBMC)
            {
                return true;
            }
            else
            {
                return false;
            }
            
        }

        public static bool SaveVideoInfo(VideoInfo videoInfo)
        {
            // MyLog.Add("SaveVideoInfo");

            listVideoInfos[videoInfo.index] = videoInfo;

            UpdateVideo updateVideo = new UpdateVideo();

            updateVideo.UpdateMVE(videoInfo);

            updateVideo.UpdateXBMC(videoInfo);
            
            updateVideo.UpdateMB(videoInfo);


            // delete prior statsfile, if any, so stats will be re-calced
            string statsFile = MyFile.EnsureDataFile("stats", Config.settings.exportExt, "stats");
            if (statsFile != null)
            {
                MyFile.DeleteFile(statsFile);
            }


            return true;
        }


        public static bool Load()
        {
            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();

            MyLog.Add("Loading VideoItems -->");

            int nbrVideoInfos;
            FileInfo fileInfo;
            CreateList();
            foreach (ConfigSettings.Source source in Config.settings.sources)
            {
                string dataFile = MyFile.EnsureDataFile("videos", Config.settings.exportExt, "data", source.alias);
                if (dataFile == null)
                {
                    continue;
                }

                // keep a backup of settings
                if (File.Exists(dataFile))
                {
                    fileInfo = MyFile.FileInfo(dataFile);
                    List<VideoInfo> loadVideoInfos = (List<VideoInfo>)MyDeserialize.FromFile(Config.settings.exportFormat, dataFile, listVideoInfos);
                    if (loadVideoInfos == null)
                    {
                        MyLog.Add("Unable to load VideoInfos from " + dataFile);
                        continue;
                    }
                    AddItems(loadVideoInfos);

                    string fromFile = "from " + dataFile.Replace(MyFile.exeDirectory, "");
                    if (fileInfo != null)
                    {
                        fromFile += " " + MyFile.FormatSize(fileInfo.Length);
                    }

                    if (loadVideoInfos == null)
                    {
                        nbrVideoInfos = 0;
                    }
                    else
                    {
                        nbrVideoInfos = loadVideoInfos.Count();
                    }
                    MyLog.Add("Loaded " + nbrVideoInfos + " VideoItems " + fromFile);
                }
            }

            EnsureVideoInfos();

            stopWatch.Stop();


            if (listVideoInfos == null)
            {
                nbrVideoInfos = 0;
            }
            else
            {
                nbrVideoInfos = listVideoInfos.Count();
            }

            MyLog.AddElapsed("<-- in ", stopWatch.Elapsed);

            bool loaded = nbrVideoInfos > 0 ? true : false;
            return loaded;
        }

        public static bool Save()
        {
            if (listVideoInfos == null)
            {
                return false;
            }

            Stopwatch stopWatch = new Stopwatch();
            stopWatch.Start();
            MyLog.Add("Saving VideoItems -->");

            foreach (ConfigSettings.Source settingsSource in Config.settings.sources)
            {
                string dataFile = MyFile.EnsureDataFile("videos", Config.settings.exportExt, "data", settingsSource.alias);
                if (dataFile == null)
                {
                    continue;
                }

                List<VideoInfo> saveVideoInfos = new List<VideoInfo>(listVideoInfos.Count());
                saveVideoInfos = listVideoInfos.Where(x => x.sourceAlias == settingsSource.alias && x.videoItem != null && x.videoItem.title != null).OrderBy(x => x.videoItem.title).ToList();

               
                if (saveVideoInfos == null)
                {
                    continue;
                }
                int nbrVideoInfos = saveVideoInfos.Count();
                if (nbrVideoInfos == 0)
                {
                    continue;
                }

                MyLog.RotateFiles(dataFile);
                MySerialize.ToFile(Config.settings.exportFormat, dataFile, saveVideoInfos);


                FileInfo fileInfo = MyFile.FileInfo(dataFile);
                string toFile = "to " + dataFile.Replace(MyFile.exeDirectory, "");
                if (fileInfo != null)
                {
                    toFile += " " + MyFile.FormatSize(fileInfo.Length);
                }
                MyLog.Add("Saved " + nbrVideoInfos + " VideoItems " + toFile);
            }

            stopWatch.Stop();
            MyLog.AddElapsed("<-- in ", stopWatch.Elapsed);

            return true;
        }
    }
}
