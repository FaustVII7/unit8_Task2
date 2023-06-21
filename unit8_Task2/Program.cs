using System;
using System.IO;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            Console.WriteLine("Введите путь до папки:");
            string path = Console.ReadLine();

            if (!Directory.Exists(path))
            {
                Console.WriteLine("Папки по заданному пути не существует.");
                return;
            }

            long size = GetDirectorySize(new DirectoryInfo(path));
            Console.WriteLine("Размер папки: " + size + " байт");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Ошибка: {ex.Message}") ;
        }
    }

    static long GetDirectorySize(DirectoryInfo dir)
    {
        long size = 0;

        foreach (FileInfo file in dir.GetFiles())
        {
            size += file.Length;
        }

        foreach (DirectoryInfo subDir in dir.GetDirectories())
        {
            size += GetDirectorySize(subDir);
        }

        return size;
    }
}
