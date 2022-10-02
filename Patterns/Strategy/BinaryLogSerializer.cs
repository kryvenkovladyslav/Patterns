using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace Patterns.Strategy
{
    internal sealed class BinaryLogSerializer : ILogSerializer
    {
        private readonly BinaryFormatter binaryFormatter;
        public BinaryLogSerializer() => binaryFormatter = new BinaryFormatter();
        public object DeserializeLogs(string path)
        {
            object result = null;
            if (File.Exists(path))
            {
                using (FileStream file = File.Open(path, FileMode.Open, FileAccess.Read))
                {
                    result = binaryFormatter.Deserialize(file);
                }
            }
            return result;
        }

        public bool SerializeLogs(string path, object graph)
        {
            using (FileStream stream = File.Open(path, FileMode.Create, FileAccess.Write))
            {
                binaryFormatter.Serialize(stream, graph);

                return File.Exists(path) ? true : false;
            }
        }
    }
}
