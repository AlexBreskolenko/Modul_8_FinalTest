using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

namespace FimalTask
{
    class Program
    {
        const string SettingsFileName = "C:\\Users\\abres\\Desktop\\Student";

        static void CreateFolder()
        {
            DirectoryInfo dir = new DirectoryInfo(SettingsFileName);

            if (!dir.Exists)
            {
                dir.Create();
                Console.WriteLine("Папка Student создана.");
            }
        }

        static void ReadFile()
        {
            BinaryFormatter binaryFormatter = new BinaryFormatter();

            using (var fs = new FileStream("C:\\Users\\abres\\Desktop\\Student\\Students.dat", FileMode.OpenOrCreate))
            {
                var newStudents = binaryFormatter.Deserialize(fs);
                Console.WriteLine($"{newStudents.Name} --- {newStudents.Group} --- {newStudents.DateOfBirth}");
            }
        }

        static void Main(string[] args)
        {
            CreateFolder();
            ReadFile();
        }
    }
}
