using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.IO;
using System.Xml;
using System.Xml.Serialization;
using System.Web.Script.Serialization;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization.Json;
using System.Drawing;

namespace MyVideoExplorer
{
    class MySerialize
    {

   

        public static byte[] ToByteArray(object obj)
        {
            if (obj == null)
            {
                return null;
            }
             try
            {
                BinaryFormatter formatter = new BinaryFormatter();
                using (MemoryStream memory = new MemoryStream())
                {
                    formatter.Serialize(memory, obj);
                    return memory.ToArray();
                }
             }
             catch (Exception e)
            {
                MyLog.Add(e.ToString());
                return null;
            }
        }

        public static bool ToFile(string format, string file, object obj)
        {
            switch (format)
            {
                case "json":
                    return ToJSONFile(file, obj);
                case "xml":
                    return ToXMLFile(file, obj);
            }
            return false;
        }

        public static string ToXML(object obj)
        {
             if (obj == null)
            {
                return null;
            }
             try
            {
                // XmlSerializer serializer = new XmlSerializer(obj.GetType());
                DataContractSerializer serializer = new DataContractSerializer(obj.GetType());
                using (StringWriter stringWriter = new StringWriter())
                {
                    using (XmlTextWriter xmlTextWriter = new XmlTextWriter(stringWriter))
                    {
                        xmlTextWriter.Formatting = Formatting.Indented; // indent the Xml so it's human readable
                        serializer.WriteObject(xmlTextWriter, obj);
                        xmlTextWriter.Flush();
                        return stringWriter.ToString();
                    }
                }
             }
             catch (Exception e)
            {
                MyLog.Add(e.ToString());
                return null;
            }
        }

        public static bool ToXMLFile(string file, object obj)
        {
            if (obj == null)
            {
                return false;
            }
            try
            {
                string xml = ToXML(obj);
                if (xml == null) {
                    return false;
                }
                File.WriteAllText(file, xml);
            }
            catch (Exception e)
            {
                MyLog.Add(e.ToString());
                return false;
            }
            return true;
        }

        public static string ToJSON(object obj)
        {
            if (obj == null)
            {
                return null;
            }
            try
            {
                bool ownsStream = true;
                bool indent = true;
                DataContractJsonSerializerSettings jsonSerializerSettings = new DataContractJsonSerializerSettings();
                // convert "/Date(1329159196126)/" to "2014-08-06T01:51:31Z"
                jsonSerializerSettings.DateTimeFormat = new DateTimeFormat("yyyy-MM-dd'T'HH:mm:ssZ");

                DataContractJsonSerializer jsonSerializer = new DataContractJsonSerializer(obj.GetType(), jsonSerializerSettings);
                using (MemoryStream memoryStream = new MemoryStream())
                {
                    using (XmlDictionaryWriter jsonWriter = JsonReaderWriterFactory.CreateJsonWriter(memoryStream, Encoding.UTF8, ownsStream, indent))
                    {
                        jsonSerializer.WriteObject(jsonWriter, obj);
                        jsonWriter.Flush();
                        return Encoding.UTF8.GetString(memoryStream.GetBuffer(), 0, (int)memoryStream.Length);
                    }
                }


            }
            catch (Exception e)
            {
                MyLog.Add(e.ToString());
                return null;
            }
        }

        public static bool ToJSONFile(string file, object obj)
        {
            if (obj == null)
            {
                return false;
            }
            try
            {
                string json = ToJSON(obj);
                if (json == null)
                {
                    return false;
                }
                File.WriteAllText(file, json);
         
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
