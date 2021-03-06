using System;
using System.IO;

namespace DemoExamplesRoadmap.InputOutputViaFilesystem
{
    public class DeleteFiles
    {
        public void DeleteFileIfExists(string fileLocation)
        {
            try
            {
                if (File.Exists(fileLocation))
                {
                    File.Delete(fileLocation);
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine("Error: ", exception.Message);
            }
        }
    }
}
