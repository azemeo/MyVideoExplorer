using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


using System.IO;
using System.Windows.Forms;
using System.Threading;
using System.Xml;
using System.Diagnostics;
using System.IO.Compression;

namespace MyVideoExplorer
{
    class MyFile
    {
        /// <summary>
        /// full path to exe
        /// </summary>
        public static string exePath;
        /// <summary>
        /// full path to ex directory
        /// </summary>
        public static string exeDirectory;

        public static void SetAppInfo()
        {
            // where are we
            exePath = System.Reflection.Assembly.GetExecutingAssembly().Location;
            exeDirectory = System.IO.Path.GetDirectoryName(exePath);


        }

        /// <summary>
        /// returns the human-readable file size for an arbitrary, 64-bit file size
        /// </summary>
        /// <param name="size">size in bytes</param>
        /// <param name="precision">how many decimal places to show, -1 for minimal</param>
        /// <param name="forceUnits">force units to be returned</param>
        /// <param name="withUnits">return units label</param>
        /// <returns></returns>
        public static string FormatSize(long size, int precision=-1, string forceUnits=null, bool withUnits=true)
        {
            string sign = (size < 0 ? "-" : "");
            double readable = (size < 0 ? -size : size);
            int defaultPrecision;
            string suffix;
            if (size >= 0x1000000000000000 && (forceUnits == null || forceUnits == "EB")) // Exabyte
            {
                suffix = "EB";
                readable = (double)(size >> 50);
                defaultPrecision = 1;
            }
            else if (size >= 0x4000000000000 && (forceUnits == null || forceUnits == "PB")) // Petabyte
            {
                suffix = "PB";
                readable = (double)(size >> 40);
                defaultPrecision = 1;
            }
            else if (size >= 0x10000000000 && (forceUnits == null || forceUnits == "TB")) // Terabyte
            {
                suffix = "TB";
                readable = (double)(size >> 30);
                defaultPrecision = 1;
            }
            else if (size >= 0x40000000 && (forceUnits == null || forceUnits == "MB")) // Gigabyte
            {
                suffix = "GB";
                readable = (double)(size >> 20);
                defaultPrecision = 1;
            }
            else if (size >= 0x100000 && (forceUnits == null || forceUnits == "MB")) // Megabyte
            {
                suffix = "MB";
                readable = (double)(size >> 10);
                defaultPrecision = 0;
            }
            else if (size >= 0x400 && (forceUnits == null || forceUnits == "KB")) // Kilobyte
            {
                suffix = "KB";
                readable = (double)size;
                defaultPrecision = 0;
            }
            else
            {
                suffix = "B";
                readable = (double)size * 1024;
                defaultPrecision = 0;
            }
            readable = readable / 1024;

            if (precision == -1)
            {
                precision = defaultPrecision;
            }
            string format = "0";
            if (precision > 0)
            {
                format += ".".PadRight(precision + 1, '#');
            }

            string formatted = sign + readable.ToString(format);
            if (withUnits)
            {
                formatted += " " + suffix;
            }

            return formatted;
        }


 

        public static string EnsureDataFile(string name, string extension, string subDir, string appendName=null)
        {

            if (String.IsNullOrEmpty(exePath))
            {
                SetAppInfo();
            }

            subDir = MyFile.SafeDirectory(subDir);
            string dataDirectory = exeDirectory + @"\" + subDir;
            if (!Directory.Exists(dataDirectory))
            {
                try
                {
                    Directory.CreateDirectory(dataDirectory);
                }
                catch (Exception e)
                {
                    if (subDir.IndexOf("log") != -1)
                    {
                        MyLog.Add(e.ToString());
                    } 
                    else if (Application.OpenForms.Count > 0)
                    {
                        MessageBox.Show("Unable to create the data directory [" + dataDirectory + "]");
                    }
                    return null;
                }
            }

            if (appendName != null)
            {
                appendName = "_" + appendName;

                appendName = MyFile.SafeFileName(appendName);
            }


            string file = dataDirectory + @"\" + name + appendName + "." + extension;

            return file;
        }

        public static string EnsureDirectoryExists(string directory)
        {

            directory = MyFile.SafeDirectory(directory);
            if (!Directory.Exists(directory))
            {
                try
                {
                    Directory.CreateDirectory(directory);
                }
                catch (Exception e)
                {
                    if (directory.IndexOf("log") != -1)
                    {
                        MyLog.Add(e.ToString());
                    }
                    else if (Application.OpenForms.Count > 0)
                    {
                        MessageBox.Show("Unable to create the directory [" + directory + "]");
                    }
                    return null;
                }
            }

            return directory;
        }


        public static bool DeleteFile(string file)
        {
            bool ret = false;
            try
            {
                if (File.Exists(file))
                {
                    File.Delete(file);
                    ret = true;
                }
            }
            catch (Exception e)
            {
                MyLog.Add(e.ToString());
            }
            return ret;
        }

        public static string SafeFileName(string fileName)
        {
            return String.Concat(fileName.Split(Path.GetInvalidFileNameChars()));
        }

        public static string SafeDirectory(string directory)
        {
            return String.Concat(directory.Split(Path.GetInvalidPathChars()));
        }

        public static string ReadAllText(string fileName)
        {
            string fileContents = null;
            try
            {
                fileContents = File.ReadAllText(fileName);
            }
            catch (Exception e)
            {
                MyLog.Add(e.ToString());
            }
            return fileContents;
        }

        public static string ReadAllBinaryToString(string fileName)
        {
            string contents = null;
            using (FileStream fileStream = new FileStream(fileName, FileMode.Open))
            {
                using (BinaryReader binaryReader = new BinaryReader(fileStream))
                {
                    byte[] bytes = binaryReader.ReadBytes((int)fileStream.Length);
                    contents = Convert.ToBase64String(bytes);
                }
            }
            return contents;
        }

        public static bool WriteAllBinaryFromString(string fileName, string fileContents)
        {
            byte[] bytes = Convert.FromBase64String(fileContents);
            using (FileStream fileStream = new FileStream(fileName, FileMode.Create))
            {
                using (BinaryWriter binaryWriter = new BinaryWriter(fileStream))
                {
                    binaryWriter.Write(bytes);
                }
            }

            return true;
        }

        public static FileInfo FileInfo(string file)
        {
            if (!File.Exists(file))
            {
                MyLog.Add("File ["+file+"] does not exist");
                return null;
            }
            try
            {
                FileInfo fileInfo = new FileInfo(file);
                return fileInfo;
            }
            catch (System.IO.FileNotFoundException e)
            {
                // If file was deleted by a separate application then just continue.
                MyLog.Add(e.ToString());
                return null;
            }
            catch (UnauthorizedAccessException e)
            {
                // no access to system file
                MyLog.Add(e.ToString());
                return null;
            }
            catch (Exception e)
            {
                // other
                MyLog.Add(e.ToString());
                return null;
            }
        }

        public static IEnumerable<string> EnumerateFiles(string directory, string searchPattern=null, SearchOption searchOption = SearchOption.TopDirectoryOnly)
        {
            IEnumerable<string> files = Enumerable.Empty<string>(); // or new string[]{};

            if (!Directory.Exists(directory))
            {
                MyLog.Add("Directory [" + directory + "] does not exist");
                return files;
            }

            try
            {
                // files = Directory.GetFiles(currentDir); // blocks .. boo
                if (searchPattern == null)
                {
                    files = Directory.EnumerateFiles(directory);
                }
                else
                {
                    files = Directory.EnumerateFiles(directory, searchPattern, searchOption); // does not block .. yea
                }
            }
            catch (System.IO.DirectoryNotFoundException e)
            {
                MyLog.Add(e.ToString());
                return files;
            }
            catch (UnauthorizedAccessException e)
            {
                MyLog.Add(e.ToString());
                return files;
            }
            catch (Exception e)
            {
                MyLog.Add(e.ToString());
                return files;
            }

            return files;
        }

        public static IEnumerable<string> EnumerateDirectories(string directory, string searchPattern = null, SearchOption searchOption = SearchOption.TopDirectoryOnly)
        {
            IEnumerable<string> directories = Enumerable.Empty<string>(); // or new string[]{};

            if (!Directory.Exists(directory))
            {
                MyLog.Add("Directory [" + directory + "] does not exist");
                return directories;
            }

            try
            {
                // directories = Directory.getDirectories(directory); // blocks .. boo
                if (searchPattern == null)
                {
                    directories = Directory.EnumerateDirectories(directory);
                } 
                else 
                {
                    directories = Directory.EnumerateDirectories(directory, searchPattern, searchOption); // does not block .. yea
                }

            }
            catch (DirectoryNotFoundException e)
            {
                MyLog.Add(e.ToString());
                return directories;
            }
            catch (PathTooLongException e)
            {
                MyLog.Add(e.ToString());
                MessageBox.Show(e.Message);
                return directories;
            }
            catch (UnauthorizedAccessException e)
            {
                MyLog.Add(e.ToString());
                return directories;
            }
            catch (Exception e)
            {
                MyLog.Add(e.ToString());
                return directories;
            }

            return directories;
        }

        public static long DirectorySize(string directory, string searchPattern=null)
        {
            long size = 0;
            IEnumerable<string> files = MyFile.EnumerateFiles(directory, searchPattern);
            if (files.Count() == 0)
            {
                return size;
            }

            foreach (string file in files)
            {
                FileInfo fileInfo = MyFile.FileInfo(file);

                if (fileInfo == null)
                {
                    continue;
                }
                size += fileInfo.Length;
            }
            return size;
        }


        public static bool OpenDirectory(string directory)
        {
            bool ret = true;
            if (!Directory.Exists(directory))
            {
                ret = false;
                MyLog.Add("Directory does not exist: " + directory);
                return ret;
            }
            Process.Start(directory);
            return ret;
        }

        public static bool RunFile(FileInfo fileInfo)
        {
            return RunFile(fileInfo.FullName);
        }
        public static bool RunFile(string fullName)
        {
            bool ret = true;

            if (!File.Exists(fullName))
            {
                ret = false;
                MyLog.Add("File does not exist: " + fullName);
                return ret;
            }

            Process process = null;
            try
            {
                process = new Process();
                ProcessStartInfo processStartInfo = new ProcessStartInfo();
                processStartInfo.FileName = fullName;
                processStartInfo.UseShellExecute = true;
                process.StartInfo = processStartInfo;
                process.Start();
                process.WaitForExit();
            }
            catch (Exception e)
            {
                MyLog.Add(e.ToString());
                ret = false;
            }

            if (process != null)
            {
                process.Close();
            }

            if (ret)
            {
                MyLog.Add("Ran " + fullName);
            }
            else
            {
                MyLog.Add("Errored running :" + fullName);
            }
            return ret;
        }

        public static bool Compress(string source, string target)
        {
            return Compress(source, target, ".gz");
        }
        public static bool Compress(string source, string target, string targetExt)
        {
            FileInfo sourceFileInfo = MyFile.FileInfo(source);
            if (sourceFileInfo == null)
            {
                return false;
            }
            try
            {
                using (FileStream originalFileStream = sourceFileInfo.OpenRead())
                {
                    using (FileStream compressedFileStream = File.Create(target + targetExt))
                    {
                        using (GZipStream compressionStream = new GZipStream(compressedFileStream, CompressionMode.Compress))
                        {
                            originalFileStream.CopyTo(compressionStream);
                            MyLog.Add(String.Format("Compressed {0} from {1} to {2}", sourceFileInfo.Name, MyFile.FormatSize(sourceFileInfo.Length), MyFile.FormatSize(compressedFileStream.Length)));
                        }
                    }
                }
            }
            catch (Exception e)
            {
                MyLog.Add(e.ToString());
                return false;
            }
            return true;
        }

        public static bool Decompress(string source)
        {
            FileInfo sourceFileInfo = MyFile.FileInfo(source);
            if (sourceFileInfo == null)
            {
                return false;
            }
            try
            {
                using (FileStream originalFileStream = sourceFileInfo.OpenRead())
                {
                    string currentFileName = sourceFileInfo.FullName;
                    string newFileName = currentFileName.Remove(currentFileName.Length - sourceFileInfo.Extension.Length);

                    using (FileStream decompressedFileStream = File.Create(newFileName))
                    {
                        using (GZipStream decompressionStream = new GZipStream(originalFileStream, CompressionMode.Decompress))
                        {
                            decompressionStream.CopyTo(decompressedFileStream);
                            MyLog.Add(String.Format("Decompressed {0} from {1} to {2}", sourceFileInfo.Name, MyFile.FormatSize(sourceFileInfo.Length), MyFile.FormatSize(decompressionStream.Length)));
                        }
                    }
                }
            }
            catch (Exception e)
            {
                MyLog.Add(e.ToString());
                return false;
            }
            return true;
        }

    }
}
