using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Xml;

namespace MyVideoExplorer
{
    class MyXMLDoc
    {

        public static List<string> GetMultipleNodeString(XmlDocument doc, string path)
        {
            List<string> result = new List<string> { };
            XmlNodeList nodes = doc.DocumentElement.SelectNodes(path);
            if (nodes != null && nodes.Count > 0)
            {
                int index = 0;
                foreach (XmlNode node in nodes)
                {
                    result.Add(node.InnerText);
                    index++;
                }
            }
            return result;
        }

        public static List<Dictionary<string, string>> GetMultipleNestedNodeString(XmlDocument doc, string path)
        {
            List<Dictionary<string, string>> result = new List<Dictionary<string, string>> { };
            XmlNodeList nodes = doc.DocumentElement.SelectNodes(path);
            if (nodes != null && nodes.Count > 0)
            {
                int index = 0;
                foreach (XmlNode node in nodes)
                {
                    Dictionary<string, string> childNodes = new Dictionary<string, string>();
                    foreach (XmlNode childNode in node.ChildNodes)
                    {
                        childNodes[childNode.Name] = childNode.InnerText;
                    }
                    result.Add(childNodes);
                    index++;
                }
            }
            return result;
        }

        /// <summary>
        /// select a single string node from a xml doc
        /// </summary>
        /// <param name="doc"></param>
        /// <param name="path"></param>
        /// <returns></returns>
        public static string GetSingleNodeString(XmlDocument doc, string path)
        {
            string result = null;
            if (doc == null)
            {
                return result;
            }
            XmlNode node = doc.DocumentElement.SelectSingleNode(path);
            if (node != null)
            {
                result = node.InnerText;
            }
            return result;
        }

        /// <summary>
        /// select a single int node from a xml doc
        /// </summary>
        /// <param name="doc"></param>
        /// <param name="path"></param>
        /// <returns></returns>
        public static int GetSingleNodeInt(XmlDocument doc, string path)
        {
            int result = 0;
            XmlNode node = doc.DocumentElement.SelectSingleNode(path);
            if (node != null)
            {
                if (node.InnerText == "false")
                {
                    result = 0;
                }
                else if (node.InnerText == "true")
                {
                    result = 1;
                }
                else
                {
                    try
                    {
                        result = Convert.ToInt32(node.InnerText);
                    }
                    catch (Exception e)
                    {
                        MyLog.Add(e.ToString());
                    }
                }
            }
            return result;
        }
        /// <summary>
        /// select a single int node from a xml doc
        /// </summary>
        /// <param name="doc"></param>
        /// <param name="path"></param>
        /// <returns></returns>
        public static decimal GetSingleNodeDecimal(XmlDocument doc, string path)
        {
            decimal result = 0;
            XmlNode node = doc.DocumentElement.SelectSingleNode(path);
            if (node != null)
            {
                try
                {
                    result = Convert.ToDecimal(node.InnerText);
                }
                catch (Exception e)
                {
                    MyLog.Add(e.ToString());
                }
            }
            return result;
        }

        /// <summary>
        /// select and set a single string node in a xml doc
        /// </summary>
        /// <param name="doc"></param>
        /// <param name="path"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public static void SetSingleNodeString(XmlDocument doc, string path, string value)
        {
            XmlNode node = doc.DocumentElement.SelectSingleNode(path);
            if (node != null)
            {
                node.InnerText = value;
            }
        }

        /// <summary>
        /// select and set a single string node in a xml doc
        /// </summary>
        /// <param name="doc"></param>
        /// <param name="path"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public static void SetSingleNodeDecimal(XmlDocument doc, string path, decimal value)
        {
            XmlNode node = doc.DocumentElement.SelectSingleNode(path);
            if (node != null)
            {
                try
                {
                    node.InnerText = value.ToString();
                }
                catch (Exception e)
                {
                    MyLog.Add(e.ToString());
                }
            }
        }

        /// <summary>
        /// select and set a single string node in a xml doc
        /// </summary>
        /// <param name="doc"></param>
        /// <param name="path"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        public static void SetSingleNodeInt(XmlDocument doc, string path, int value)
        {
            XmlNode node = doc.DocumentElement.SelectSingleNode(path);
            if (node != null)
            {
                try
                {
                    node.InnerText = value.ToString();
                }
                catch (Exception e)
                {
                    MyLog.Add(e.ToString());
                }
            }
        }

        public static XmlDocument LoadXml(string fileContents)
        {
            if (String.IsNullOrEmpty(fileContents))
            {
                return null;
            }
            XmlDocument doc = new XmlDocument();
            try
            {
                doc.LoadXml(fileContents);
            }
            catch (Exception e)
            {
                MyLog.Add(e.ToString());
                MyLog.Add("fileContents : "+fileContents);
                doc = null;
            }
            return doc;
        }

        public static bool SaveXML(XmlDocument doc, string fileName)
        {
            bool ret = true;
            try 
            { 
                XmlWriterSettings settings = new XmlWriterSettings();
                settings.Indent = true;
                using (XmlWriter writer = XmlWriter.Create(fileName, settings))
                {
                    doc.Save(writer);
                }                
            }
            catch (Exception e)
            {
                MyLog.Add(e.ToString());
                ret = false;
            }
            return ret;
        }
    }
}
