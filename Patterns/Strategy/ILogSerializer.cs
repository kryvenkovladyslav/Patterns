namespace Patterns.Strategy
{
    internal interface ILogSerializer
    {
        public bool SerializeLogs(string path, object graph);
        public object DeserializeLogs(string path);
    }
}
