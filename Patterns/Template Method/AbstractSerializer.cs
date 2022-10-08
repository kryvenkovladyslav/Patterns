using System.IO;

namespace Patterns.Template_Method
{
    public abstract class AbstractSerializer
    {
        public AbstractSerializer() { }
        public bool Serialize(string path, object graph)
        {
            using (FileStream stream = File.Open(path, FileMode.Create, FileAccess.Write))
            {
                this.SerializeStep(stream, graph);

                return File.Exists(path) ? true : false;
            }
        }
        public object Deserialize(string path)
        {
            object result = null;
            if (File.Exists(path))
            {
                using (FileStream stream = File.Open(path, FileMode.Open, FileAccess.Read))
                {
                    result = DeserializeStep(stream);
                }
            }
            return result;
        }
        protected abstract void SerializeStep(Stream stream, object graph);
        protected abstract object DeserializeStep(Stream stream);
    }
}
