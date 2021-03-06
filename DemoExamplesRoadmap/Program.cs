using DemoExamplesRoadmap.InputOutputViaFilesystem;
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
            await streamWriterReaderExample.WriteFileAsync();
            await streamWriterReaderExample.ReadFileAsync();

            BinaryWriterReaderExample binaryWriterReaderExample = new BinaryWriterReaderExample();
            binaryWriterReaderExample.WriteFile();
            binaryWriterReaderExample.ReadFile();
        }
    }
}
