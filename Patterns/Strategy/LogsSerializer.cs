namespace Patterns.Strategy
{
    internal sealed class LogsSerializer
    {
        private ILogSerializer logSerializer;
        
        public ILogSerializer LogSerializer
        {
            get => logSerializer;
            set => logSerializer = value;
        }

        public LogsSerializer(ILogSerializer logSerializer) => LogSerializer = logSerializer;
        public bool Serialize(string path, object graph) => LogSerializer.SerializeLogs(path, graph);
        public object Deserialize(string path) => LogSerializer.DeserializeLogs(path);
    }
}
