using System;
using System.IO;
using System.Xml.Serialization;

namespace Patterns.Strategy
{
    internal class XmlLogSerializer : ILogSerializer
    {
        private readonly XmlSerializer xmlSerializer;

        public XmlLogSerializer(Type type) => xmlSerializer = new XmlSerializer(type);
        public object DeserializeLogs(string path)
        {
            object result = null;
            if (File.Exists(path))
            {
                using (FileStream file = File.Open(path, FileMode.Open, FileAccess.Read))
                {
                    result = xmlSerializer.Deserialize(file);
                }
            }
            return result;
        }
        public bool SerializeLogs(string path, object graph)
        {
            using (FileStream stream = File.Open(path, FileMode.Create, FileAccess.Write))
            {
                xmlSerializer.Serialize(stream, graph);

                return File.Exists(path) ? true : false;
            }  
        }
    }
}
