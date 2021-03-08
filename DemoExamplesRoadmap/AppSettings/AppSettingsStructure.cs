using Newtonsoft.Json;

namespace DemoExamplesRoadmap.AppSettings
{
    public class AppSettingsStructure
    {
        [JsonProperty("EmailAddresses")]
        public string[] EmailAddresses { get; set; }

        [JsonProperty("ConnectionStrings")]
        public string ConnectionStrings { get; set; }
    }
}
