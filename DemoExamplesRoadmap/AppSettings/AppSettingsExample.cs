using DemoExamplesRoadmap.LocalAppDataFolder;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Serilog;
using System;
using System.Threading.Tasks;

namespace DemoExamplesRoadmap.AppSettings
{
    public class AppSettingsExample
    {
        private IConfigurationRoot configuration;
        private LocalAppDataExample localAppDataExample = new LocalAppDataExample();

        public void LogExample()
        {
            Log.Logger = new LoggerConfiguration()
                 .WriteTo.Console(Serilog.Events.LogEventLevel.Debug)
                 .MinimumLevel.Debug()
                 .Enrich.FromLogContext()
                 .CreateLogger();

            try
            {
                Logging();
            }
            catch (Exception exception)
            {
                Console.WriteLine("Error: ", exception);
            }
        }

        private void Logging()
        {
            // Create service collection
            Log.Information("Creating service collection");
            ServiceCollection serviceCollection = new ServiceCollection();
            ConfigureServices(serviceCollection);

            // Create service provider
            Log.Information("Building service provider");
            IServiceProvider serviceProvider = serviceCollection.BuildServiceProvider();

            // Print connection string to demonstrate configuration object is populated
            Console.WriteLine(configuration.GetConnectionString("DataConnection"));

            try
            {
                Log.Information("Starting service");
                serviceProvider.GetService<AppExample>().Run();
                Log.Information("Ending service");
            }
            catch (Exception exception)
            {
                Log.Fatal(exception, "Error running service");
                throw exception;
            }
            finally
            {
                Log.CloseAndFlush();
            }
        }

        private void ConfigureServices(IServiceCollection serviceCollection)
        {
            string appDataPath = localAppDataExample.AssemblyFolderPath();

            // Add logging
            serviceCollection.AddSingleton(LoggerFactory.Create(builder =>
            {
                builder.AddSerilog(dispose: true);
            }));

            serviceCollection.AddLogging();

            // Build configuration 
            // Directory.GetParent(AppContext.BaseDirectory).FullName -> path to \bin\Debug\netcoreapp3.1
            configuration = new ConfigurationBuilder()
                .SetBasePath(appDataPath)
                .AddJsonFile("appsettings.json", false)
                .Build();

            // Add access to generic IConfigurationRoot
            serviceCollection.AddSingleton(configuration);

            // Add app
            serviceCollection.AddTransient<AppExample>();
        }
    }
}
