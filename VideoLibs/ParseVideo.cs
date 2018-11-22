using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.IO;
using System.Diagnostics;
using System.Xml;
using System.Text.RegularExpressions;
using System.Threading;

namespace MyVideoExplorer
{
 

    class ParseVideo
    {

        string encodingFFProbeOutput;
        string encodingFFProbeError;

        /// <summary>
        /// parse the MVE .mve file
        /// </summary>
        /// <param name="mveFile"></param>
        /// <returns></returns>
        public VideoInfo ParseMVE(string mveFile)
        {
            VideoInfo videoInfo = new VideoInfo();
            videoInfo.Initialize();


            if (mveFile.StartsWith("<?xml"))
            {
                videoInfo.videoItem = (VideoItem)MyDeserialize.FromXMLFile(mveFile, videoInfo.videoItem);
            }
            else if (mveFile.StartsWith("{"))
            {
                videoInfo.videoItem = (VideoItem)MyDeserialize.FromJSONFile(mveFile, videoInfo.videoItem);
            }

            return videoInfo;
        }

        /// <summary>
        /// parse the XBMC .nfo file
        /// </summary>
        /// <param name="doc"></param>
        /// <returns></returns>
        public VideoInfo ParseXBMC(XmlDocument doc)
        {
            VideoInfo videoInfo = new VideoInfo();
            videoInfo.Initialize();

            List<string> innerTexts;

            videoInfo.videoItem.title = MyXMLDoc.GetSingleNodeString(doc, "/movie/title");

            videoInfo.videoItem.plot = MyXMLDoc.GetSingleNodeString(doc, "/movie/plot");

            videoInfo.videoItem.movieset = MyXMLDoc.GetSingleNodeString(doc, "/movie/set");
            videoInfo.videoItem.tagline = MyXMLDoc.GetSingleNodeString(doc, "/movie/tagline");

            videoInfo.videoItem.imdbId = MyXMLDoc.GetSingleNodeString(doc, "/movie/id");
            videoInfo.videoItem.tmdbId = MyXMLDoc.GetSingleNodeString(doc, "/movie/tmdbId");
            videoInfo.videoItem.mpaa = MyXMLDoc.GetSingleNodeString(doc, "/movie/mpaa");

            videoInfo.videoItem.imdbRating = MyXMLDoc.GetSingleNodeDecimal(doc, "/movie/rating");

            videoInfo.videoItem.year = MyXMLDoc.GetSingleNodeInt(doc, "/movie/year");
            videoInfo.videoItem.runtime = MyXMLDoc.GetSingleNodeInt(doc, "/movie/runtime");
            videoInfo.videoItem.playCount = MyXMLDoc.GetSingleNodeInt(doc, "/movie/playcount");
            int watched = MyXMLDoc.GetSingleNodeInt(doc, "/movie/watched");
            if (watched != 0 && watched != 1)
            {
                watched = 0;
            }
            videoInfo.videoItem.watched = VideoFileEnums.watched.GetKeyByValue(watched);

            videoInfo.videoItem.encoding = new VideoEncoding();
            videoInfo.videoItem.encoding.codec = MyXMLDoc.GetSingleNodeString(doc, "/movie/fileinfo/streamdetails/video/codec");
            videoInfo.videoItem.encoding.width = MyXMLDoc.GetSingleNodeInt(doc, "/movie/fileinfo/streamdetails/video/width");
            videoInfo.videoItem.encoding.height = MyXMLDoc.GetSingleNodeInt(doc, "/movie/fileinfo/streamdetails/video/height");


            innerTexts = MyXMLDoc.GetMultipleNodeString(doc, "/movie/director");
            videoInfo.videoItem.directors = new List<VideoItemDirector<string>> { };
            foreach (string innerText in innerTexts)
            {
                videoInfo.videoItem.directors.Add(new VideoItemDirector<string>(innerText));
            }

            innerTexts = MyXMLDoc.GetMultipleNodeString(doc, "/movie/genre");
            videoInfo.videoItem.genres = new List<VideoItemGenre<string>> { };
            foreach (string innerText in innerTexts)
            {
                videoInfo.videoItem.genres.Add(new VideoItemGenre<string>(innerText));
            }

            innerTexts = MyXMLDoc.GetMultipleNodeString(doc, "/movie/tag");
            videoInfo.videoItem.tags = new List<VideoItemTag<string>> { };
            foreach (string innerText in innerTexts)
            {
                videoInfo.videoItem.tags.Add(new VideoItemTag<string>(innerText));
            }



            videoInfo.videoItem.actors = new List<VideoItemActor<string, string>>();
            List<Dictionary<string, string>> actorInfos = MyXMLDoc.GetMultipleNestedNodeString(doc, "/movie/actor");
            foreach (Dictionary<string, string> actorInfo in actorInfos)
            {
                VideoItemActor<string, string> videoItemActor = new VideoItemActor<string, string>();
                foreach(KeyValuePair<string, string> info in actorInfo)
                {
                    switch (info.Key)
                    {
                        case "name":
                            videoItemActor.name = info.Value;
                            break;
                        case "role":
                            videoItemActor.role = info.Value;
                            break;
                        case "thumb":
                            break;
                        default:
                            break;
                    }
                }
                if (!String.IsNullOrEmpty(videoItemActor.name))
                {
                    videoInfo.videoItem.actors.Add(videoItemActor);
                }
            }

            return videoInfo;
        }

        /// <summary>
        /// parse the MB .xml file
        /// </summary>
        /// <param name="doc"></param>
        /// <returns></returns>
        public VideoInfo ParseMB(XmlDocument doc)
        {
            VideoInfo videoInfo = new VideoInfo();
            videoInfo.Initialize();

            videoInfo.videoItem.title = MyXMLDoc.GetSingleNodeString(doc, "/Title/LocalTitle");

            videoInfo.videoItem.plot = MyXMLDoc.GetSingleNodeString(doc, "/Title/Overview");

            videoInfo.videoItem.movieset = "";
            videoInfo.videoItem.tagline = MyXMLDoc.GetSingleNodeString(doc, "/Title/tagline");

            videoInfo.videoItem.imdbId = MyXMLDoc.GetSingleNodeString(doc, "/Title/IMDB");
            videoInfo.videoItem.tmdbId = MyXMLDoc.GetSingleNodeString(doc, "/Title/TMDbId");
            videoInfo.videoItem.mpaa = MyXMLDoc.GetSingleNodeString(doc, "/Title/ContentRating");

            videoInfo.videoItem.imdbRating = MyXMLDoc.GetSingleNodeDecimal(doc, "/Title/Rating");

            videoInfo.videoItem.year = MyXMLDoc.GetSingleNodeInt(doc, "/Title/ProductionYear");
            videoInfo.videoItem.runtime = MyXMLDoc.GetSingleNodeInt(doc, "/Title/RunningTime");


            videoInfo.videoItem.playCount = 0;
            videoInfo.videoItem.watched = "NO";

            return videoInfo;
        }

        public VideoInfo ParseOtherHandrake(string fileFullName, VideoItemFile videoItemFile)
        {
            VideoInfo videoInfo = new VideoInfo();
            videoInfo.Initialize();

            string contents = MyFile.ReadAllText(fileFullName);
            if (String.IsNullOrEmpty(contents))
            {
                return videoInfo;
            }

            Regex regexSize = new Regex(@"\+ Crop and Scale \(([0-9]{3,4}):([0-9]{3,4}):", RegexOptions.IgnoreCase);
            Match matchSize = regexSize.Match(contents);
            if (matchSize.Success && matchSize.Groups.Count == 3)
            {
                int width = 0;
                int.TryParse(matchSize.Groups[1].Value, out width);
                videoInfo.videoItem.encoding.width = width;
                int height = 0;
                int.TryParse(matchSize.Groups[2].Value, out height);
                videoInfo.videoItem.encoding.height = height;
            }

            if (contents.IndexOf("x264", StringComparison.OrdinalIgnoreCase) != -1)
            {
                videoInfo.videoItem.encoding.codec = "x264";
            }

            // hmm .. not alawys valid .. 
            // Regex regexBitrate = new Regex(@"\+ bitrate ([0-9]{3,5}) kbps", RegexOptions.IgnoreCase);
            // so try summing all track instead
            int bitrateVideoAudio = 0;
            Regex regexBitrate = new Regex(@"bytes, ([0-9]{3,5})\.[0-9]{2} kbps, fifo", RegexOptions.IgnoreCase);
            MatchCollection matchBitrates = regexBitrate.Matches(contents);
            foreach (Match matchBitrate in matchBitrates)
            {                
                if (matchBitrate.Success && matchBitrate.Groups.Count == 2)
                {                    
                    for (int index = matchBitrate.Groups.Count - 1; index >= 1; index--)
                    {
                        int bitrate = 0;
                        int.TryParse(matchBitrate.Groups[index].Value, out bitrate);
                        bitrateVideoAudio += bitrate;
                    }                    
                }                
            }
            // MyLog.Add(videoItemFile.FullName + " bitrate : " + bitrateVideoAudio.ToString());
            if (bitrateVideoAudio > 100)
            {
                videoInfo.videoItem.encoding.bitrate = bitrateVideoAudio * 1024;
            }


            return videoInfo;
        }

        public VideoInfo ParseOtherFileName(string fileFullName, VideoItemFile videoItemFile)
        {
            VideoInfo videoInfo = new VideoInfo();
            videoInfo.Initialize();

            if (videoItemFile.Name.IndexOf("dvd", StringComparison.OrdinalIgnoreCase) != -1)
            {
                videoInfo.videoItem.source = "DVD";
            }
            else if (videoItemFile.Name.IndexOf("bluray", StringComparison.OrdinalIgnoreCase) != -1)
            {
                videoInfo.videoItem.source = "Bluray";
            }
            else if (videoItemFile.Name.IndexOf("amazon", StringComparison.OrdinalIgnoreCase) != -1 ||
                videoItemFile.Name.IndexOf("hulu", StringComparison.OrdinalIgnoreCase) != -1 ||
                videoItemFile.Name.IndexOf("crackle", StringComparison.OrdinalIgnoreCase) != -1)
            {
                videoInfo.videoItem.source = "Stream";
            }

            if (videoItemFile.Name.IndexOf("extended", StringComparison.OrdinalIgnoreCase) != -1)
            {
                videoInfo.videoItem.version = "Extended";
            }
            else if (videoItemFile.Name.IndexOf("director", StringComparison.OrdinalIgnoreCase) != -1)
            {
                videoInfo.videoItem.version = "Director";
            }
            else if (videoItemFile.Name.IndexOf("unrated", StringComparison.OrdinalIgnoreCase) != -1)
            {
                videoInfo.videoItem.version = "Unrated";
            }
            else if (videoItemFile.Name.IndexOf("theater", StringComparison.OrdinalIgnoreCase) != -1)
            {
                videoInfo.videoItem.version = "Theater";
            }

            if (videoItemFile.Name.IndexOf("review", StringComparison.OrdinalIgnoreCase) != -1)
            {
                videoInfo.videoItem.notes += videoItemFile.Name.Replace(".txt", "");
            }
            if (videoItemFile.Name.IndexOf("notes", StringComparison.OrdinalIgnoreCase) != -1)
            {
                videoInfo.videoItem.notes += videoItemFile.Name.Replace(".txt", "");
            }
                
            return videoInfo;
        }

        /// <summary>
        /// try to get some video info from the directory
        /// </summary>
        /// <param name="directoryInfo"></param>
        /// <returns></returns>
        public VideoInfo ParseDirectory(DirectoryInfo directoryInfo)
        {
            VideoInfo videoInfo = new VideoInfo();
            videoInfo.Initialize();

            string title;
            int year = 0;
            int indexOfYear = directoryInfo.Name.IndexOf(" (");
            if (indexOfYear != -1)
            {
                title = directoryInfo.Name.Substring(0, indexOfYear);
                Match match = Regex.Match(directoryInfo.Name, @"\((\d+).?\)");
                try
                {
                    year = Convert.ToInt32(match.Groups[1].Value);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            else
            {
                title = directoryInfo.Name;
                year = 0;
            }
            videoInfo.videoItem = new VideoItem();
            videoInfo.videoItem.title = "(unknown) "+title;

            videoInfo.videoItem.year = year;

            videoInfo.videoItem.playCount = 0;
            videoInfo.videoItem.watched = "NO";

            // videoInfo.videoItem.plot = "(unknow) (from Directory)";

            return videoInfo;
        }

        public VideoInfo ParseVideoFile(VideoItemFile videoItemFile)
        {
            VideoInfo videoInfo = new VideoInfo();
            videoInfo.Initialize();

            string title;
            int year = 0;
            int indexOfYear = videoItemFile.Name.IndexOf(" (");
            if (indexOfYear != -1)
            {
                title = videoItemFile.Name.Substring(0, indexOfYear);
                Match match = Regex.Match(videoItemFile.Name, @"\((\d+).?\)");
                try
                {
                    year = Convert.ToInt32(match.Groups[1].Value);
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
            else
            {
                title = videoItemFile.Name;
                year = 0;
            }
            videoInfo.videoItem = new VideoItem();
            videoInfo.videoItem.title = title;

            videoInfo.videoItem.year = year;

            videoInfo.videoItem.playCount = 0;
            videoInfo.videoItem.watched = "NO";

            // videoInfo.videoItem.plot = "(unknow) (from Video file)";

            return videoInfo;
        }

        private string RunFFprobe(string videoFilePath)
        {
            Process process = null;
            string encoding = null;
            string error = null;

            if (!File.Exists(videoFilePath))
            {
                // MyLog.Add("Video not found " + fileInfo.FullName);
                return encoding;
            }

            string ffprobeExe = MyFile.EnsureDataFile("ffprobe", "exe", @"libs/ffmpeg/bin");
            if (!File.Exists(ffprobeExe))
            {
                // MyLog.Add("FFMPEG: not found " + ffprobeExe);
                return encoding;
            }


            try
            {
                encodingFFProbeError = "";
                encodingFFProbeOutput = "";

                string workingDirectory = MyFile.exeDirectory; // MyFile.exeDirectory + "/temp";  // MyFile.exeDirectory;
                string arguments = string.Format("-v warning -show_error -show_format -show_streams -print_format xml \"{0}\"", videoFilePath);

                // MyLog.Add("RunFFprobe: Start " + videoItemFile.FullName + ": \"" + ffprobeExe + "\" " + arguments);

                ProcessStartInfo startInfo = new ProcessStartInfo();
                startInfo.FileName = ffprobeExe;
                startInfo.Arguments = arguments;
                startInfo.CreateNoWindow = true;
                startInfo.RedirectStandardOutput = true;
                startInfo.RedirectStandardError = true; 
                startInfo.UseShellExecute = false;
                startInfo.WorkingDirectory = workingDirectory;

                process = new Process();
                process.StartInfo = startInfo;
                process.OutputDataReceived += RunFFprobe_Output;
                process.ErrorDataReceived += RunFFprobe_Error;
                // use this order of events to avoid deadlock
                // http://msdn.microsoft.com/en-us/library/system.diagnostics.process.standardoutput.aspx
                // http://msdn.microsoft.com/en-us/library/system.diagnostics.process.outputdatareceived%28v=vs.110%29.aspx
                process.Start();
                // StreamReader streamReaderError = process.StandardError;
                // encoding = process.StandardError.ReadToEnd();
                // process.BeginOutputReadLine();

                // encoding = process.StandardOutput.ReadToEnd(); // works, simplier


                process.BeginOutputReadLine();
                process.BeginErrorReadLine(); // so far doesnt seem to catch errors


                process.WaitForExit(5000);

                if (!String.IsNullOrEmpty(encodingFFProbeError))
                {
                    MyLog.Add("RunFFprobe: Error on " + videoFilePath + " : " + encodingFFProbeError);
                }
                encoding = encodingFFProbeOutput.Trim();

                // clean up temp folder occasionaly
                Random random = new Random();
                int chance = random.Next(0, 100);
                if (false && chance < 25)
                {
                    string[] ffprobeLogs = Directory.GetFiles(workingDirectory, "ffprobe*.log");
                    foreach (string ffprobeLog in ffprobeLogs)
                    {
                        File.Delete(ffprobeLog);
                    }
                }

            }
            catch (Exception e)
            {
                MyLog.Add("RunFFprobe: "+e.ToString());
            }


            // MyLog.Add("RunFFprobe: Finish " + videoItemFile.FullName + ": " + encoding);
            try
            {
                string status;
                if (process.ExitCode == 0)
                {
                    status = "Success";
                }
                else
                {
                    status = "Error";
                }
                MyLog.Add("RunFFprobe: " + status + " code:" + process.ExitCode.ToString() + " probed in:" + process.TotalProcessorTime.Milliseconds.ToString() + "ms");
            }
            catch (Exception)
            {

            }
            if (error != null)
            {
                MyLog.Add(error);
            }

            if (process != null)
            {
                process.Close();
            }

            // meh, throttle some
            Thread.Sleep(10);

            return encoding;
        }

        private void RunFFprobe_Output(object sender, DataReceivedEventArgs e)
        {
            string data = e.Data;
            if (!String.IsNullOrEmpty(data)) 
            {
                encodingFFProbeOutput += data + Environment.NewLine;
            }
        }

        private void RunFFprobe_Error(object sender, DataReceivedEventArgs e)
        {
            string data = e.Data;
            if (!String.IsNullOrEmpty(data))
            {
                encodingFFProbeError += data + Environment.NewLine;
            }
        }

        public VideoEncoding ParseFFprobe(string encoding)
        {
            VideoEncoding ffmprobe = new VideoEncoding();

            if (String.IsNullOrEmpty(encoding))
            {
                return ffmprobe;
            }

            // MyLog.Add("FFMPEG: xml " + encoding);

            try
            {
                XmlDocument doc = MyXMLDoc.LoadXml(encoding);
                if (doc == null)
                {
                    return ffmprobe;
                }

                string width = MyXMLDoc.GetSingleNodeString(doc, "/ffprobe/streams/stream[@codec_type='video']/@width");
                if (!String.IsNullOrEmpty(width))
                {
                    ffmprobe.width = Convert.ToInt32(width);
                }
                string height = MyXMLDoc.GetSingleNodeString(doc, "/ffprobe/streams/stream[@codec_type='video']/@height");
                if (!String.IsNullOrEmpty(height))
                {
                    ffmprobe.height = Convert.ToInt32(height);
                }
                string bitrate = MyXMLDoc.GetSingleNodeString(doc, "/ffprobe/format[@filename]/@bit_rate");
                if (!String.IsNullOrEmpty(bitrate))
                {
                    ffmprobe.bitrate = Convert.ToInt32(bitrate);
                }
                string codec = MyXMLDoc.GetSingleNodeString(doc, "/ffprobe/streams/stream[@codec_type='video']/@codec_name");
                if (!String.IsNullOrEmpty(codec))
                {
                    ffmprobe.codec = codec;
                }

                // MyLog.Add("FFMPEG: ffmprobe " + MySerialize.ToXML(ffmprobe));
            }
            catch (Exception e)
            {
                MyLog.Add("ParseFFprobe: " + e.ToString());
            }

            return ffmprobe;
        }






        /// <summary>
        /// read the video directory and try to parse video info
        /// such as XBMC, MB
        /// </summary>
        /// <param name="directory"></param>
        /// <returns></returns>
        public VideoInfo ReadDirectory(string directory)
        {

            bool parsedFile = false;
            VideoInfo videoInfo = new VideoInfo();
            videoInfo.Initialize();
            videoInfo.videoDirectory = directory;
            VideoInfo parsedVideoInfo = new VideoInfo();
            parsedVideoInfo.Initialize();
            parsedVideoInfo.videoDirectory = directory;

            IEnumerable<string> files = MyFile.EnumerateFiles(directory);

            if (files.Count() == 0)
            {
                // empty folder .. maybe a category folder, or movie placeholder
                return videoInfo;
            }


            // MyLog.Add("ReadDirectory: " + files.Count() + " files");
            foreach (string file in files)
            {
                FileInfo fileInfo = MyFile.FileInfo(file);

                if (fileInfo == null)
                {
                    continue;
                }
                VideoItemFile videoItemFile = new VideoItemFile();
                videoItemFile.Set(directory, fileInfo);

                // parse nfo/xml/file to get file info

                videoInfo.files.qty += 1;

                string fileExt = fileInfo.Extension.TrimStart('.');
                switch (fileExt)
                {
                    case "avi":
                    case "m4v":
                    case "mov":
                    case "mpg":
                    case "mkv":
                    case "mp4":
                    case "mpeg":
                        videoInfo.files.video = videoItemFile;

                        //if (videoInfo.videoItem.encoding == null)
                        //{
                        string encoding = RunFFprobe(videoInfo.GetFullName(videoInfo.files.video));
                            if (encoding != null)
                            {
                                videoInfo.videoItem.encoding = ParseFFprobe(encoding);
                            }                            
                        //}
                        break;
                    case "jpg":
                    case "jpeg":
                    case "png":
                        if (fileInfo.Name == "poster.jpg")
                        {
                            videoInfo.files.poster = videoItemFile;
                        }
                        else if (fileInfo.Name == "fanart.jpg")
                        {
                            videoInfo.files.fanart = videoItemFile;
                        }
                        videoInfo.files.images.Add(videoItemFile);
                        break;
                    case "mve":
                    case "nfo":
                    case "xml":
                        // TODO btr way to ensure which type parsing

                        string fileContents = MyFile.ReadAllText(fileInfo.FullName);
                        fileContents = fileContents.Trim(); 
                        if (String.IsNullOrEmpty(fileContents)) 
                        {                            
                            continue;
                        }
                        if (fileContents.StartsWith("<?xml"))
                        {
                            XmlDocument doc = MyXMLDoc.LoadXml(fileContents);
                            if (doc == null)
                            {
                                continue;
                            }



                            if (fileContents.Contains("<VideoInfo>"))
                            {
                                //if (parsedFile == false)
                                {
                                    parsedVideoInfo = ParseMVE(fileInfo.FullName);
                                    videoInfo.MergeVideoItemWith(parsedVideoInfo);
                                    // videoInfo.videoItem = parsedVideoInfo.videoItem;
                                }
                                videoInfo.files.mve = videoItemFile;

                                parsedFile = true;
                            }
                            if (fileContents.Contains("<Title>"))
                            {
                                //if (parsedFile == false)
                                {
                                    parsedVideoInfo = ParseMB(doc);
                                    videoInfo.MergeVideoItemWith(parsedVideoInfo);
                                    //videoInfo.videoItem = parsedVideoInfo.videoItem;
                                }
                                videoInfo.files.mb = videoItemFile;

                                parsedFile = true;
                            }
                            if (fileContents.Contains("<movie>"))
                            {
                                //if (parsedFile == false)
                                {
                                    parsedVideoInfo = ParseXBMC(doc);
                                    videoInfo.MergeVideoItemWith(parsedVideoInfo);
                                    //videoInfo.videoItem = parsedVideoInfo.videoItem;
                                }
                                videoInfo.files.xbmc = videoItemFile;

                                parsedFile = true;
                            }
                        }
                        else if (fileContents.StartsWith("{"))
                        {
                            //if (parsedFile == false)
                            {
                                parsedVideoInfo = ParseMVE(fileInfo.FullName);
                                videoInfo.MergeVideoItemWith(parsedVideoInfo);
                                // videoInfo.videoItem = parsedVideoInfo.videoItem;
                            }
                            videoInfo.files.mve = videoItemFile;

                            parsedFile = true;
                        }
                        
                        break;
                    case "txt":
                        if (videoItemFile.Name.StartsWith("handbrake"))
                        {
                            parsedVideoInfo = ParseOtherHandrake(videoInfo.GetFullName(videoItemFile), videoItemFile);
                            videoInfo.MergeVideoItemWith(parsedVideoInfo);
                        }
                        else
                        {
                            parsedVideoInfo = ParseOtherFileName(videoInfo.GetFullName(videoItemFile), videoItemFile);
                            videoInfo.MergeVideoItemWith(parsedVideoInfo);
                        } 

                        videoInfo.files.others.Add(videoItemFile);
                        break;
                    default:
                        videoInfo.files.others.Add(videoItemFile);
                        break;
                } // end switch ext
            } // end foreach file


            // couldnt parse nfo/xml and have video file in dir, so use video file for some basic info
            if (!parsedFile && videoInfo.files != null && videoInfo.files.video != null)
            {
                parsedVideoInfo = ParseVideoFile(videoInfo.files.video);
                videoInfo.MergeVideoItemWith(parsedVideoInfo);

                parsedFile = true;
            }
            /* .. no video file .. so skip
            // couldnt parse nfo/xml and have files in dir, so use dir for some basic info
            else if (!parsedFile && files.Count() > 0) 
            {
                DirectoryInfo directoryInfo = new DirectoryInfo(directory);
                parsedVideoInfo = ParseDirectory(directoryInfo);
                videoInfo.MergeVideoItemWith(parsedVideoInfo);                

                parsedFile = true;
            }
            */

            if (videoInfo.videoItem.title == null || videoInfo.files == null || videoInfo.files.video == null)
            {
                videoInfo = null;
            }
            else
            {
                // sanitize some data

                // remove (year) from title .. bad prior parse mb, xbmc
                videoInfo.videoItem.title = Regex.Replace(videoInfo.videoItem.title, @"\([0-9]{4}\)$", "");
            }

            return videoInfo;
        }


    }
}
