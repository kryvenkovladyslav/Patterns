using System;

namespace Patterns.Strategy
{
    [Serializable]
    public sealed class LogEntry
    {
        private DateTime time;
        private string information;

        public DateTime Time
        {
            get => time;
            set => time = value;
        }
        public string Information
        {
            get => information;
            set => information = value;
        }

        public LogEntry() { }
        public LogEntry(DateTime time, string information) => (Time, Information) = (time, information);
    }
}
