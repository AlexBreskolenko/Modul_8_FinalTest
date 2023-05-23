//Напишите программу, которая считает размер папки на диске (вместе со всеми вложенными папками и файлами).
 //На вход метод принимает URL директории, в ответ — размер в байтах.

class Program
{
    public static long SizeDirectory(string pathToDirectory)
    {
        long size = 0;
        //Создаем обьект 
        DirectoryInfo dirInfo = new DirectoryInfo(pathToDirectory);
        //Получаем все папки
        DirectoryInfo[] folder = dirInfo.GetDirectories();
        //Получаем все файлы
        FileInfo[] file = dirInfo.GetFiles();

        foreach (FileInfo f in file)
        {
            size += f.Length;
        }

        //Проходимся по всем папкам
        for (int i = 0; i < folder.Length; i++)
        {
            size += SizeDirectory(pathToDirectory + "\\" + folder[i].Name);
        }
        return size;
    }

    static void Main(string[] args)
    {
        string pathToDirectory;
        Console.Write("Введите путь к директории : ");
        pathToDirectory = Console.ReadLine();
        Console.WriteLine($"Размер : {SizeDirectory(pathToDirectory) } byte");
    }
}