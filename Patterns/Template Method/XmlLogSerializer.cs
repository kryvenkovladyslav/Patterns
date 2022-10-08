using System;
using System.IO;
using System.Xml.Serialization;

namespace Patterns.Template_Method
{
    public sealed class XmlLogSerializer : AbstractSerializer
    {
        private XmlSerializer serializer;

        public XmlLogSerializer(Type type) => serializer = new XmlSerializer(type);
        protected override object DeserializeStep(Stream stream)
        {
            return serializer.Deserialize(stream);
        }
        protected override void SerializeStep(Stream stream, object graph)
        {
            serializer.Serialize(stream, graph);
        }
    }
}
