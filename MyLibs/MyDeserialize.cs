using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.IO;
using System.Xml;
using System.Xml.Serialization;
using System.Web.Script.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization.Json;
using System.Runtime.Serialization;

namespace MyVideoExplorer
{
    class MyDeserialize
    {
        public static object FromByteArray(byte[] byteArray)
        {
            if (byteArray == null)
            {
                return null;
            }
            using (MemoryStream memory = new MemoryStream())
            {
                BinaryFormatter formatter = new BinaryFormatter();
                memory.Write(byteArray, 0, byteArray.Length);
                memory.Seek(0, SeekOrigin.Begin);
                var obj = formatter.Deserialize(memory);
                return obj;
            }
        }

        public static object FromFile(string format, string file, object obj)
        {
            switch (format)
            {
                case "json":
                    return FromJSONFile(file, obj);
                case "xml":
                    return FromXMLFile(file, obj);
            }
            return null;
        }

        public static object FromXML(string xml, object obj)
        {
            if (String.IsNullOrEmpty(xml))
            {
                return null;
            }
            try
            {
                if (obj == null)
                {
                    return null;
                }
                using (XmlReader xmlReader = XmlReader.Create(new StringReader(xml)))
                {
                    DataContractSerializer dataContractSerializer = new DataContractSerializer(obj.GetType());
                    return dataContractSerializer.ReadObject(xmlReader);
                }
            }
            catch (Exception e)
            {
                MyLog.Add(e.ToString());
                return null;
            }
        }

        public static object FromXMLFile(string file, object obj)
        {
            if (!File.Exists(file))
            {
                return null;
            }
            try
            {
                if (obj == null)
                {
                    return null;
                }
                string xml = File.ReadAllText(file);
                if (String.IsNullOrEmpty(xml))
                {
                    return null;
                }
                return FromXML(xml, obj);

            }
            catch (Exception e)
            {
                MyLog.Add(e.ToString());
                return null;
            }
        }
        
        public static object FromJSON(string json, object obj)
        {
            if (String.IsNullOrEmpty(json))
            {
                return null;
            }
            if (obj == null)
            {
                return null;
            }
            try
            {
                using (MemoryStream memoryStream = new MemoryStream())
                {
                    byte[] jsonBytes = Encoding.UTF8.GetBytes(json);
                    memoryStream.Write(jsonBytes, 0, jsonBytes.Length);
                    memoryStream.Seek(0, SeekOrigin.Begin);
                    using (XmlDictionaryReader jsonReader = JsonReaderWriterFactory.CreateJsonReader(memoryStream, Encoding.UTF8, XmlDictionaryReaderQuotas.Max, null))
                    {
                        DataContractJsonSerializerSettings jsonSerializerSettings = new DataContractJsonSerializerSettings();
                        // convert "2014-08-06T01:51:31Z" to DateTime()
                        jsonSerializerSettings.DateTimeFormat = new DateTimeFormat("yyyy-MM-dd'T'HH:mm:ssZ");

                        DataContractJsonSerializer jsonSerializer = new DataContractJsonSerializer(obj.GetType(), jsonSerializerSettings);
                        return jsonSerializer.ReadObject(jsonReader);

                    }
                }
            }
            catch (Exception e)
            {
                MyLog.Add(e.ToString());
                return null;
            }
        }

        public static object FromJSONFile(string file, object obj)
        {
            if (!File.Exists(file))
            {
                return null;
            }
            try
            {
                if (obj == null)
                {
                    return null;
                }
                string json = File.ReadAllText(file);
                if (String.IsNullOrEmpty(json))
                {
                    return null;
                }
                return FromJSON(json, obj);

            }
            catch (Exception e)
            {
                MyLog.Add(e.ToString());
                return null;
            }
        }


    }
}
