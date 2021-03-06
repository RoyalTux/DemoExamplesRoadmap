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
        }
    }
}
