using System;
using System.IO;

namespace task1
{
    internal class OpenFile
    {
        public static string ReadText()
        {
            Console.Write("Введите путь к файлу с которым хотите работать: ");
            string path = Console.ReadLine();
            if (File.Exists(path))
            {
                string textStream = File.ReadAllText(path); // Считываем весь текс с текстового файла
                return textStream;
            }
            else
            {
                Console.WriteLine("Указаный файл не существует!");
                Console.ReadKey();
                return null;
            }
        }
    }
}