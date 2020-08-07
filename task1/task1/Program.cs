using System;

namespace task1
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            foreach (var i in args)
            {
                UserChoies(i);
            }
            if (args.Length == 0)
            {
                Console.WriteLine("Выберите один из методов:\n" +
                               "1. Считать файл и удалить в нем слово/символ.\n" +
                               "2. Считать файл и вывести количество слов, а также вывести каждое 10-е слово.\n" +
                               "3. Считать файл и вывести 3-ю строку со словами в обратном порядке.\n" +
                               "4. Вывести имена папок и фалов в папке.");
                Console.Write("Ваш выбор: ");
                string userChoise = Console.ReadLine();
                if (userChoise == "1" || userChoise == "2" || userChoise == "3" || userChoise == "4")
                {
                    UserChoies(userChoise);
                }
                else
                {
                    Console.WriteLine("Введен некорректный номер метода!");
                    Console.ReadKey();
                }
            }
        }

        private static void UserChoies(string userChoise)
        {
            switch (userChoise)
            {
                case "1":
                    ChangeText.Change_Text();
                    break;

                case "2":
                    WordCounter.Read_Write_Text();
                    break;

                case "3":
                    WordsReverse.Read_3_String();
                    break;

                case "4":
                    Folder.ReadDir();
                    break;
            }
        }
    }
}