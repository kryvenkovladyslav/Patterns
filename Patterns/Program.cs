using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;
using Patterns.Strategy;

namespace Patterns
{
    class Program
    {
        static void Main(string[] args)
        {
            DateTime time = DateTime.Now;
            string firstInformation = "first log";
            string secondInformation = "second log";
            string xmlPath = @"C:\Games\Strategy.xml";
            string binaryPath = @"C:\Games\Strategy.dat";


            LogEntry firstLog = new LogEntry(time, firstInformation);
            LogEntry secondLog = new LogEntry(time, secondInformation);
            Repository<LogEntry> repository = new Repository<LogEntry>(firstLog, secondLog);

            LogsSerializer logsSerializer = new LogsSerializer(new XmlLogSerializer(typeof(Repository<LogEntry>)));
            logsSerializer.Serialize(xmlPath, repository);

            var deserializedRepository = logsSerializer.Deserialize(xmlPath) as Repository<LogEntry>;
            if (deserializedRepository != null)
                Console.WriteLine(deserializedRepository.Items[1].Information);


            logsSerializer.LogSerializer = new BinaryLogSerializer();
            logsSerializer.Serialize(binaryPath, repository);
            deserializedRepository = logsSerializer.Deserialize(binaryPath) as Repository<LogEntry>;
            if (deserializedRepository != null)
                Console.WriteLine(deserializedRepository.Items[0].Information);


        }
    }
}
