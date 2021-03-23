using DemoExamplesRoadmap.AppSettings;
using DemoExamplesRoadmap.EnvironmentVariables;
using DemoExamplesRoadmap.InputOutputViaFilesystem;
using DemoExamplesRoadmap.LocalAppDataFolder;
using DemoExamplesRoadmap.MongoDbExamples;
using System;
using System.Threading.Tasks;

namespace DemoExamplesRoadmap
{
    class Program
    {
        static async Task Main(string[] args)
        {
            FileStreamExample fileStreamExample = new FileStreamExample();
            await fileStreamExample.WriteFileAsync();
            await fileStreamExample.ReadFileAsync();
            fileStreamExample.WriteReadFileSeek();
            await fileStreamExample.ManualDisposingFileStreamAsync();

            StreamWriterReaderExample streamWriterReaderExample = new StreamWriterReaderExample();
            string testText = "hello world-Dima2020-23-03";
            await streamWriterReaderExample.WriteFileAsync(testText);
            await streamWriterReaderExample.ReadFileAsync();

            BinaryWriterReaderExample binaryWriterReaderExample = new BinaryWriterReaderExample();
            binaryWriterReaderExample.WriteFile();
            binaryWriterReaderExample.ReadFile();

            Console.WriteLine("\n\nEnvironment Variables Example:\n\n");

            EnvironmentVariablesExample environmentVariablesExample = new EnvironmentVariablesExample();
            environmentVariablesExample.DisplaySeveralEnvironmentVariables();

            Console.WriteLine("\n\nLocal App Data Example:\n\n");

            LocalAppDataExample localAppDataExample = new LocalAppDataExample();
            string assemblyFolderPath = localAppDataExample.AssemblyFolderPath();
            Console.WriteLine("Assembly folder path: " + assemblyFolderPath);
            string fileName = "appsettings.json";
            await localAppDataExample.GetFileAsync(fileName);

            Console.WriteLine("\n\nApp Settings Example:\n\n");

            AppSettingsExample appSettingsExample = new AppSettingsExample();
            await appSettingsExample.LogExample();

            Console.WriteLine("\n\nLogs from Mongo database:\n\n");
            MongoDbLogger mongoDbLogger = new MongoDbLogger();
            await mongoDbLogger.GetLogsFromMongoDb();
        }
    }
}
