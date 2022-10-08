using System;

namespace Patterns.Template_Method
{
    public sealed class Serializer
    {
        public bool Serialize(string path, object graph, Func<string, object, bool> function)
        {
            return function.Invoke(path, graph);
        }
    }
}
