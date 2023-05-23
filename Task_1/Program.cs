using System;
using System.IO;

class Program
{
    //Метод создания каталога и удаление его по времени
    public static void CreateFolder()
    {
        DirectoryInfo createFolder = new DirectoryInfo("C:\\Users\\abres\\Desktop\\NewFolder");
        
        //Если папки не существует то создаем ее
        if(!createFolder.Exists)
        {
            createFolder.Create();
            Console.WriteLine("Папка NewFolder создана.");
        }

        TimeSpan ts30 = TimeSpan.FromMinutes(30);

        //Время создания папки
        var startTime = createFolder.CreationTime;
        //Текущее время
        var endTime = DateTime.Now;

        var result = endTime - startTime;
        Console.WriteLine(result);

        if (result > ts30)
        {
            createFolder.Delete(true);
            Console.WriteLine("Директория удалена.");
        }

    }

    static void Main(string[] args)
    {
        CreateFolder();
    }
}