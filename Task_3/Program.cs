/*
 Доработайте программу из задания 1, используя ваш метод из задания 2.

При запуске программа должна:

1.Показать, сколько весит папка до очистки. Использовать метод из задания 2. 
2.Выполнить очистку.
3.Показать сколько файлов удалено и сколько места освобождено.
4.Показать, сколько папка весит после очистки.
 */
class Program
{
    //Метод который возвращает размер папки(директории)
    public static long SizeDirectory(string pathToDirectory)
    {
        long size = 0;

        //Создаем обьект 
        DirectoryInfo dirInfo = new DirectoryInfo(pathToDirectory);

        //Проверяем введён ли верный путь
        if (dirInfo.Exists)
        {
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
        }
        else
        {
            Console.WriteLine("Введён неверный путь.");
        }
        return size;
    }

    //Метод создания каталога
    public static void CreateFolder(string path)
    {
        DirectoryInfo createFolder = new DirectoryInfo(path);

        //Если папки не существует то создаем ее
        if (!createFolder.Exists)
        {
            createFolder.Create();
            Console.WriteLine("Папка создана.");
        }
    }

    //Метод удаление файлов и папок внутри каталога
    static void DeleteFolder(ref long size,ref int countFile ,ref int countDir ,string path) 
    {
        DirectoryInfo directoryInfo = new DirectoryInfo(path);

        foreach (FileInfo f in directoryInfo.GetFiles())
        {
            size += f.Length;
            f.Delete();
            countFile++;
            
        }

        foreach(DirectoryInfo dir in  directoryInfo.GetDirectories())
        {
            foreach (FileInfo f in dir.GetFiles())
            {
                size += f.Length;
                countFile++;
            }
            dir.Delete(true);
            countDir++;
        }
    }

    static void Main(string[] args)
    {
        Console.Write("Введите путь и для создания папки : ");
        string path = Console.ReadLine();

        Console.Write("Введите имя папки : ");
        string name = Console.ReadLine();

        CreateFolder(path + "\\" + name);

        long originalSize = SizeDirectory(path + "\\" + name);
        Console.WriteLine($"Исходный размер : {originalSize} байт");

        int countFile = 0;
        int countDir = 0;
        long size = 0;

        DeleteFolder(ref size,ref countFile ,ref countDir ,path + "\\" + name);
        Console.WriteLine($"Удалено папок : {countDir} \nУдалено файлов : {countFile}\nРазмер удаленных файлов : {size} байт");

        long currentSize = originalSize - size;
        Console.WriteLine($"Текущий размер : {currentSize} байт");
    }
}