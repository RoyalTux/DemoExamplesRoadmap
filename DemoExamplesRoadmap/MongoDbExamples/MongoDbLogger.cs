using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Threading.Tasks;
using System.Configuration;

namespace DemoExamplesRoadmap.MongoDbExamples
{
    public class MongoDbLogger
    {
        public async Task SaveLogsToMongoDb(LogMessage logs)
        {
            string configurationManager = ConfigurationManager.ConnectionStrings["MongoDb"].ConnectionString;
            MongoClient client = new MongoClient(configurationManager);
            var database = client.GetDatabase("DemoExamplesRoadmapLogs");
            var logMessages = database.GetCollection<LogMessage>("logMessages");
            await logMessages.InsertOneAsync(logs);
        }

        public async Task GetLogsFromMongoDb()
        {
            string configurationManager = ConfigurationManager.ConnectionStrings["MongoDb"].ConnectionString;
            MongoClient client = new MongoClient(configurationManager);
            var database = client.GetDatabase("DemoExamplesRoadmapLogs");
            var logMessages = database.GetCollection<LogMessage>("logMessages");
            var filter = new BsonDocument();
            var messages = await logMessages.Find(filter).ToListAsync();

            foreach (LogMessage message in messages)
            {
                int counter = 0;
                foreach (var item in message.Messages)
                {
                    ++counter;
                    Console.WriteLine("Log message #" + counter.ToString() + ": " + item);
                }
            }
        }
    }
}
