using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;


namespace task1
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Выберите один из методов:\n" +
                    "1. Считать файл и удалить в нем слово/символ.\n" +
                    "2. Считать файл и вывести количество слов, а также вывести каждое 10-е слово.\n" +
                    "3. Считать файл и вывести 3-ю строку со словами в обратном порядке.\n" +
                    "4. Вывести имена папок и фалов в папке.\n" +
                    "5. Закрыть программу.");
                Console.Write("Ваш выбор: ");
                string userChoise = Console.ReadLine();
                switch (userChoise)
                    {
                        case "1":
                            Change_Text();
                            break;
                        case "2":
                            Read_Write_Text();
                            break;
                        case "3":
                            Read_3_String();
                            break;
                        case "4":
                            ReadDir();
                            break;
                        case "5":
                            return;
                        default:
                        Console.WriteLine("Вы ввели некоректный номер метода!");
                        Console.ReadKey();
                        break;
                    }

                
            }

            Change_Text();
            Read_Write_Text();
            Read_3_String();
            ReadDir();
        }

        static string ReadText()
        {
            StreamReader stream = new StreamReader(@"F:\altexsoft-lab\altexsoft-lab-2020\task1\test_text.txt"); // Передаем путь к считываемому файлу 
            string textStream = stream.ReadToEnd(); // Считываем весь текс с текстового файла
            return textStream;
        }



        static void Change_Text()
        {
            string textStream = ReadText();
            Console.Write("Введите слово или символ который необходимо удалить: ");
            string word = Console.ReadLine();
            if (String.IsNullOrEmpty(word)) // Проверяем введена ли пустая строка
            {
                Console.WriteLine("Пустая строка");
            }
            else
            {
                if (textStream.Contains(word) == true) // Проверяем существует ли введенное слово
                {
                    string textReplace = textStream.Replace(word, ""); //Сохраняем результат удаления слова
                    Console.WriteLine(textReplace); // Показываем измененный текст
                    Console.Write("Записать текст в файл? (y/n): ");
                    string answer = Console.ReadLine().ToLower();
                    if (answer == "y")
                    {

                        string writePath = @"F:\altexsoft-lab\altexsoft-lab-2020\task1\test_text_replace.txt"; // Путь к новому файлу

                        try
                        {
                            using (StreamWriter sw = new StreamWriter(writePath, false, System.Text.Encoding.Default)) //Записуем измененный текст в файл(новый или перезаписываем существующий)
                            {
                                sw.WriteLine(textReplace);
                            }

                            Console.WriteLine("Запись выполнена в файл: " + writePath);
                        }
                        catch (Exception e)
                        {
                            Console.WriteLine(e.Message);
                        }
                    }
                }
                else
                {
                    Console.WriteLine("Нет такого слова");
                }
            }
            Console.WriteLine("Для завершения нажмите любую кнопку");
            Console.ReadKey();
        }


        static void Read_Write_Text()
        {
            string textStream = ReadText();
            string[] textArray = textStream.Split(new char[] { ' ', '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries); //Разбиваем текст на слова
            string word;
            List<string> allWords = new List<string>(); // Создаем список


            for (int i = 0, j = i + 1; i < textArray.Length; j++, i++)
            {
                if (j % 10 == 0) //Находим каждое 10 слово
                {
                    textArray[i] = textArray[i].Trim(new char[] { '.', ',', '?', '"', '(', ')' }); //Убираем спец символы
                    //Console.Write(textArray[i] + ", "); //Выводим в одну строку каждое 10 слово через запятую
                    word = textArray[i];
                    allWords.Add(word); // Добавляем в список слово
                }

            }
            Console.WriteLine(String.Join(',', allWords)); // Объеденяем строку с разделителеи
            Console.WriteLine(); //Переходим на новую строку
            Console.WriteLine("Количество слов: " + textArray.Length); //Выводим общее количество слов в тексте
            Console.ReadKey();
        }


        static void Read_3_String()
        {
            string textStream = ReadText();
            string[] textArray = textStream.Split(new char[] { '.' }, StringSplitOptions.RemoveEmptyEntries); //Разбиваем текст на предложения
            string text3 = textArray[2]; // Находим третью строку
            textArray = text3.Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries); // Разбиваем на строки
            for (int i = 0; i < textArray.Length; i++)
            {
                textArray[i] = textArray[i].Trim(new char[] { '.', ',', '?', '"', '(', ')' }); //Убираем спец символы
                textArray[i] = new string(textArray[i].ToCharArray().Reverse().ToArray()); // Меняем порядок букв в слове на обратный
                Console.Write(textArray[i] + " ");
            }
            Console.WriteLine();
            Console.ReadKey();
        }


        static void ReadDir()
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
                string userPath = dir[id].Path;// Выбираем каталог по порядковому номеру(передаем его путь)
                Console.WriteLine("Файлы:");
                string[] files = Directory.GetFiles(userPath); // Получаем все файлы каталога
                IEnumerable<string> sortedFiles = files.OrderBy(i => i);
                foreach (string s in sortedFiles)
                {
                    DirectoryInfo drInfo = new DirectoryInfo(s);  // Получаем имена файлов
                    Console.WriteLine(drInfo.Name);
                }

            }
            else
            {
                Console.WriteLine("Указаный путь не существует");
            }
            Console.ReadKey();
        }
    }
    class Dir
    {
        public string Name;
        public string Path;

    }
}

        