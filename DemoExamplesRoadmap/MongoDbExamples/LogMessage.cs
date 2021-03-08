using MongoDB.Bson.Serialization.Attributes;
using System.Collections.Generic;

namespace DemoExamplesRoadmap.MongoDbExamples
{
    [BsonIgnoreExtraElements]
    public class LogMessage
    {
        public LogMessage()
        {
            Messages = new List<string>();
        }

        public List<string> Messages { get; set; }
    }
}
