using System;
using System.Collections.Generic;
using System.Text;

namespace Patterns.Strategy
{
    internal interface ILogSerializer
    {
        public bool SerializeLogs(string path, object graph);
        public object DeserializeLogs(string path);
    }
}
