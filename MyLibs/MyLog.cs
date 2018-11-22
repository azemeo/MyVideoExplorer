using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.IO;
using System.Windows.Forms;
using System.Diagnostics;

namespace MyVideoExplorer
{
    class MyLog
    {
        public static string logFile;

        public static bool RotateFiles(string file)
        {
            try
            {
                string directory = Path.GetDirectoryName(file);
                if (directory == null)
                {
                    return false;
                }
                string fileNameNoExt = Path.GetFileNameWithoutExtension(file);
                if (fileNameNoExt == null)
                {
                    return false;
                }
                string ext = Path.GetExtension(file); // .xml

                if (ext == null)
                {
                    ext = "";
                }
                string newFile = directory + @"\" + fileNameNoExt;


                RotateFile(newFile + ".2" + ext, newFile + ".3" + ext);
                RotateFile(newFile + ".1" + ext, newFile + ".2" + ext);
                RotateFile(file, newFile + ".1" + ext);
            }
            catch (Exception e)
            {
                if (file.IndexOf(".log") != -1)
                {
                    MyLog.Add(e.ToString());
                }
            }


            return true;
        }

        private static bool RotateFile(string file, string backupFile)
        {
            try
            {
                if (File.Exists(file))
                {
                    File.Copy(file, backupFile, true);
                }
            }
            catch (Exception e)
            {
                if (file.IndexOf(".log") != -1)
                {
                    MyLog.Add(e.ToString());
                }
            }

            return true;
        }

        public static bool RotateLogs(string file)
        {
            if (File.Exists(file))
            {
                // rotate log, if bigger than X KB
                int rotateLogSize = 250 * 1024;
                FileInfo logFileInfo = MyFile.FileInfo(file);
                if (logFileInfo.Length >= rotateLogSize)
                {
                    RotateFiles(file);

                    MyFile.DeleteFile(file);
                    return true;
                }
            }

            return false;
        }


        /// <summary>
        /// log message to the log file
        /// always log exceptions e.ToString() so can debug/fix
        /// </summary>
        /// <param name="message"></param>
        public static void Add(string message)
        {
            if (logFile == null)
            {
                logFile = MyFile.EnsureDataFile("mve", "log", "logs");
            }

            try
            {
                string privateMemorySize;
                using (Process currentProcess = Process.GetCurrentProcess())
                {
                    privateMemorySize = MyFile.FormatSize(currentProcess.PrivateMemorySize64);
                }

                using (StreamWriter streamWriter = File.AppendText(logFile))
                {
                    streamWriter.WriteLine("{0} | {1} | {2} | ", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss.ff"), privateMemorySize, message);
                }
            }
            catch (Exception e)
            {
                if (Application.OpenForms.Count > 0)
                {
                    MessageBox.Show("Unable to write to log [" + e.Message + "]");
                }
            }

            // check if should rotate logs; but only check occasionaly, to reduce io checks
            Random random = new Random();
            if (random.Next(1, 100) < 20)
            {
                RotateLogs(logFile);
            }
        }

        public static void AddElapsed(TimeSpan elapsed)
        {
            AddElapsed(null, elapsed);
        }
        public static void AddElapsed(string message, TimeSpan elapsed) 
        {
            string elapsedTime = String.Format("{0:00}:{1:00}:{2:00}.{3:00}", elapsed.Hours, elapsed.Minutes, elapsed.Seconds, elapsed.Milliseconds / 10);

            if (String.IsNullOrEmpty(message))
            {
                message = "in ";
            }
            Add(message + elapsedTime);
        }


    }
}
