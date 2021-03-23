using System;
using System.IO;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DemoExamplesRoadmap.InputOutputViaFilesystem
{
    public class FileStreamExample : FileDeleter
    {
        string fileDirectory = $"{Path.GetDirectoryName(Assembly.GetEntryAssembly().Location)}\\";
        string testText = "hello world";

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
                using (FileStream fstream = new FileStream($"{dirInfo}note_1.txt", FileMode.OpenOrCreate))
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
                using (FileStream fstream = File.OpenRead($"{fileDirectory}note_1.txt"))
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

            DeleteFileIfExists(fileDirectory + "note_1.txt");
        }

        //change to async
        public void WriteReadFileSeek()
        {
            try
            {
                using (FileStream fstream = new FileStream($"{fileDirectory}note_2.txt", FileMode.OpenOrCreate))
                {
                    byte[] input = Encoding.Default.GetBytes(testText);
                    fstream.Write(input, 0, input.Length);
                    Console.WriteLine("The text was written to a file.");

                    fstream.Seek(-5, SeekOrigin.End); // minus 5 characters from the end of the stream

                    // read four characters from the current position
                    byte[] output = new byte[4];
                    fstream.Read(output, 0, output.Length);
                    string textFromFile = Encoding.Default.GetString(output);
                    Console.WriteLine($"Text from file: {textFromFile}");

                    string replaceText = "thing";
                    fstream.Seek(-5, SeekOrigin.End);
                    input = Encoding.Default.GetBytes(replaceText);
                    fstream.Write(input, 0, input.Length);

                    fstream.Seek(0, SeekOrigin.Begin);
                    output = new byte[fstream.Length];
                    fstream.Read(output, 0, output.Length);
                    textFromFile = Encoding.Default.GetString(output);
                    Console.WriteLine($"Text from file: {textFromFile}");
                }
            }
            catch(Exception exception)
            {
                Console.WriteLine("Error: ", exception);
            }

            DeleteFileIfExists(fileDirectory + "note_2.txt");
        }

        public async Task ManualDisposingFileStreamAsync()
        {
            FileStream fstream = null;
            try
            {
                fstream = new FileStream($"{fileDirectory}note_3.txt", FileMode.OpenOrCreate);
                byte[] array = Encoding.Default.GetBytes(testText);
                await fstream.WriteAsync(array, 0, array.Length);
                Console.WriteLine("The text was written to a file.");
            }
            catch (Exception exception)
            {
                Console.WriteLine("Error: ", exception);
            }
            finally
            {
                if (fstream != null)
                {
                    fstream.Close();
                    fstream.Dispose();
                    Console.WriteLine("fstream closed!");
                }
            }

            DeleteFileIfExists(fileDirectory + "note_3.txt");
        }
    }
}
