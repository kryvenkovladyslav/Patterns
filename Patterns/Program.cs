using System;
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
            LogEntry firstLog = new LogEntry(time, firstInformation);
            LogEntry secondLog = new LogEntry(time, secondInformation);
            Repository<LogEntry> repository = new Repository<LogEntry>(firstLog, secondLog);

            #region Strategy
            /*
            string xmlPath = @"C:\Games\Strategy.xml";
            string binaryPath = @"C:\Games\Strategy.dat";



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
            */
            #endregion

            #region Template Method

            string xmlPath = @"C:\Games\SerializerTemplateMethod.xml";
            string binaryPath = @"C:\Games\SerializerTemplateMethodWithDelegate.dat";
            var xmlLogSerializerTeplateMethod = new Template_Method.XmlLogSerializer(typeof(Repository<LogEntry>));

            var serializationResult = xmlLogSerializerTeplateMethod.Serialize(xmlPath, repository);
            Console.WriteLine(serializationResult);

            var deserializtionResult = (Repository<LogEntry>)xmlLogSerializerTeplateMethod.Deserialize(xmlPath);
            Console.WriteLine(deserializtionResult.Items[0].Information);

            var serializer = new Template_Method.Serializer();
            var binary = new BinaryLogSerializer();
            var result = serializer.Serialize(binaryPath, repository, binary.SerializeLogs);
            Console.WriteLine(result);

            #endregion





        }
    }
}
