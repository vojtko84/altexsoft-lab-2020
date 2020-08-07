using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace task1
{
    internal class Folder
    {
        public static void ReadDir()
        {
            Console.Write("Введите путь к папке: ");
            string path = Console.ReadLine(); // Передаем путь
            Dictionary<int, Dir> dir = new Dictionary<int, Dir>(); // Создаем словарь
            if (Directory.Exists(path)) // Проверяем существует ли директория
            {
                Console.WriteLine("Подкаталоги:");
                string[] dirs = Directory.GetDirectories(path); // Получаем список каталогов
                IEnumerable<string> sortedDirs = dirs.OrderBy(i => i);
                int i = 0;
                foreach (string s in sortedDirs)
                {
                    ++i;
                    DirectoryInfo dirInfo = new DirectoryInfo(s); // Получаем информацию о каталоге
                    dir.Add(i, new Dir { Name = dirInfo.Name, Path = dirInfo.FullName }); // Добавляем в слварь номер по порядку и имя каталога и его полный путь
                }
                int j = 0;
                foreach (var s in dir.Values)
                {
                    Console.WriteLine($"{++j}. {s.Name}"); // Выводим имена каталогов
                }
                Console.WriteLine();
                Console.Write("Выберите папку по идентификатору: ");
                int id = Int32.Parse(Console.ReadLine());
                string userPath = dir[id].Path; // Выбираем каталог по порядковому номеру(передаем его путь)
                Console.WriteLine("Файлы:");
                string[] files = Directory.GetFiles(userPath); // Получаем все файлы каталога
                IEnumerable<string> sortedFiles = files.OrderBy(i => i);
                foreach (string s in sortedFiles)
                {
                    DirectoryInfo drInfo = new DirectoryInfo(s); // Получаем имена файлов
                    Console.WriteLine(drInfo.Name);
                }
            }
            else
            {
                Console.WriteLine("Указаный путь не существует");
            }
            Console.WriteLine("Для завершения нажмите любую кнопку");
            Console.ReadKey();
        }
    }

    internal class Dir
    {
        public string Name;
        public string Path;
    }
}