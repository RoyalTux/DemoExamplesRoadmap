using System;
using System.IO;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DemoExamplesRoadmap.InputOutputViaFilesystem
{
    public class StreamWriterReaderExample : DeleteFiles
    {
        string fileDirectory = Path.GetDirectoryName(Assembly.GetEntryAssembly().Location);
        string testText = "hello world";

        public async Task WriteFileAsync()
        {
            try
            {
                using (StreamWriter sw = new StreamWriter($"{fileDirectory}\\note_4.txt", false, Encoding.Default))
                {
                    await sw.WriteLineAsync(testText);
                }

                using (StreamWriter sw = new StreamWriter($"{fileDirectory}\\note_4.txt", true, Encoding.Default))
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
                using (StreamReader sr = new StreamReader($"{fileDirectory}\\note_4.txt"))
                {
                    Console.WriteLine(await sr.ReadToEndAsync());
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine("Error: ", exception.Message);
            }

            DeleteFileIfExists(fileDirectory + "\\note_4.txt");
        }
    }
}
