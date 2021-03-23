using System;
using System.IO;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DemoExamplesRoadmap.InputOutputViaFilesystem
{
    public class StreamWriterReaderExample : FileDeleter
    {
        string fileDirectory = $"{Path.GetDirectoryName(Assembly.GetEntryAssembly().Location)}\\";

        public async Task WriteFileAsync(string text)
        {
            try
            {
                using (StreamWriter sw = new StreamWriter($"{fileDirectory}note_4.txt", false, Encoding.Default))
                {
                    await sw.WriteLineAsync(text);
                }

                using (StreamWriter sw = new StreamWriter($"{fileDirectory}note_4.txt", true, Encoding.Default))
                {
                    await sw.WriteLineAsync("additional recording");
                    await sw.WriteAsync("more text");
                }

                Console.WriteLine("The text was written to a file.");
            }
            catch (Exception exception)
            {
                Console.WriteLine("Error: ", exception.Message);
            }
        }

        public async Task ReadFileAsync()
        {
            try
            {
                using (StreamReader sr = new StreamReader($"{fileDirectory}note_4.txt"))
                {
                    Console.WriteLine(await sr.ReadToEndAsync());
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine("Error: ", exception.Message);
            }

            DeleteFileIfExists(fileDirectory + "note_4.txt");
        }
    }
}
