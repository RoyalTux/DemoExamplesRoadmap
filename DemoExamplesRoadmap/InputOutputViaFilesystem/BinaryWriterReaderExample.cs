using System;
using System.IO;
using System.Reflection;

namespace DemoExamplesRoadmap.InputOutputViaFilesystem
{
    struct User
    {
        public string userName;
        public string userHobby;
        public int userAge;

        public User(string name, string hobby, int age)
        {
            userName = name;
            userHobby = hobby;
            userAge = age;
        }
    }

    public class BinaryWriterReaderExample : DeleteFiles
    {
        string fileDirectory = Path.GetDirectoryName(Assembly.GetEntryAssembly().Location);
        User[] users = new User[2];

        public void WriteFile()
        {
            users[0] = new User("Vasya", "Walking", 33);
            users[1] = new User("Patya", "Dancing", 44);

            try
            {
                using (BinaryWriter writer = new BinaryWriter(File.Open($"{fileDirectory}\\note_5.txt", FileMode.OpenOrCreate)))
                {
                    foreach (User user in users)
                    {
                        writer.Write(user.userName);
                        writer.Write(user.userHobby);
                        writer.Write(user.userAge);
                    }
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine("Error: ", exception.Message);
            }
        }

        public void ReadFile()
        {
            try
            {
                using (BinaryReader reader = new BinaryReader(File.Open($"{fileDirectory}\\note_5.txt", FileMode.Open)))
                {
                    while (reader.PeekChar() > -1)
                    {
                        string userName = reader.ReadString();
                        string userHobby = reader.ReadString();
                        int userAge = reader.ReadInt32();

                        Console.WriteLine("Name: {0}  Hobby: {1}  Age {2}", userName, userHobby, userAge);
                    }
                }
            }
            catch (Exception exception)
            {
                Console.WriteLine("Error: ", exception.Message);
            }

            DeleteFileIfExists(fileDirectory + "\\note_5.txt");
        }
    }
}
