using DemoExamplesRoadmap.AppSettings;
using Newtonsoft.Json;
using System;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace DemoExamplesRoadmap.LocalAppDataFolder
{
    public class LocalAppDataExample
    {
        private static readonly string LocalAppDataFolderPath = Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData);
        private string AssemblyName;

        public LocalAppDataExample(string assemblyName)
        {
            AssemblyName = assemblyName;
        }

        public LocalAppDataExample()
        {
            AssemblyName = System.Reflection.Assembly.GetEntryAssembly().GetName().Name;
        }

        public string AssemblyFolderPath()
        {
            string folderPath = Path.Combine(LocalAppDataFolderPath, AssemblyName);
            if (!Directory.Exists(folderPath))
            {
                Directory.CreateDirectory(folderPath);
            }

            return folderPath;
        }

        public async Task GetFileAsync(string fileName)
        {
            string fileDirectory = AssemblyFolderPath();
            if (!File.Exists($"{fileDirectory}\\" + fileName))
            {
                await CreateAppSettings($"{fileDirectory}\\" + fileName);
            }

            try
            {
                using (FileStream fstream = File.Open($"{fileDirectory}\\" + fileName, FileMode.Open))
                {
                    byte[] array = new byte[fstream.Length];
                    await fstream.ReadAsync(array, 0, array.Length);
                    string textFromFile = Encoding.Default.GetString(array);
                    Console.WriteLine($"Text from file: {textFromFile}");
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine("Error: ", exception);
            }
        }

        private async Task CreateAppSettings(string appSettingsPath)
        {
            AppSettingsStructure appSettingsStructure = new AppSettingsStructure();
            appSettingsStructure.EmailAddresses = new string[]
            {
                "email1@test.com",
                "email2@test.com",
                "email3@test.com"
            };
            appSettingsStructure.ConnectionStrings = "ConnectionStringToSQLDatabase";
            string appsettingsJson = JsonConvert.SerializeObject(appSettingsStructure, Formatting.Indented);

            try
            {
                using (StreamWriter sw = new StreamWriter(appSettingsPath, false, Encoding.Default))
                {
                    await sw.WriteAsync(appsettingsJson);
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine("Error: ", exception.Message);
            }
        }
    }
}
