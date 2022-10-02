using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;

namespace Patterns.Strategy
{
    [Serializable, XmlRoot("Root")]
    public sealed class Repository<T>
    {
        [XmlElement("Element")]
        private List<T> items;
        
        public List<T> Items
        {
            get => items;
        }

        public Repository() => items = new List<T>();
        public Repository(params T[] array) => items = new List<T>(array);
        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();

            foreach (var item in items)
            {
                stringBuilder.Append(item + "\n");
            }

            return stringBuilder.ToString();
        }
    }
}
