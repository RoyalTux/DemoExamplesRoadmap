using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System.Collections.Generic;

namespace DemoExamplesRoadmap.AppSettings
{
    public class AppExample
    {
        private readonly IConfigurationRoot _config;
        private readonly ILogger<AppExample> _logger;

        public AppExample(IConfigurationRoot config, ILoggerFactory loggerFactory)
        {
            _logger = loggerFactory.CreateLogger<AppExample>();
            _config = config;
        }

        public void Run()
        {
            List<string> emailAddresses = _config.GetSection("EmailAddresses").Get<List<string>>();
            foreach (string emailAddress in emailAddresses)
            {
                _logger.LogInformation("Email address: {@EmailAddress}", emailAddress);
            }
        }
    }
}
