using System;
using System.IO;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DemoExamplesRoadmap.InputOutputViaFilesystem
{
    public class FileStreamExample
    {
        string fileDirectory = Path.GetDirectoryName(Assembly.GetEntryAssembly().Location);

        public async Task WriteFileAsync()
        {
            DirectoryInfo dirInfo = new DirectoryInfo(fileDirectory);

            if (!dirInfo.Exists)
            {
                dirInfo.Create();
            }

            Console.WriteLine("Enter string for saving into file: ");
            string text = Console.ReadLine();
            try
            {
                using (FileStream fstream = new FileStream($"{dirInfo}\\note.txt", FileMode.OpenOrCreate))
                {
                    byte[] array = Encoding.Default.GetBytes(text);
                    await fstream.WriteAsync(array, 0, array.Length);
                    Console.WriteLine("The text was written to a file.");
                }
            }
            catch(Exception exception)
            {
                Console.WriteLine("Error: ", exception);
            }
        }

        public async Task ReadFileAsync()
        {
            try
            {
                using (FileStream fstream = File.OpenRead($"{fileDirectory}\\note.txt"))
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

            Console.ReadLine();
        }
    }
}
