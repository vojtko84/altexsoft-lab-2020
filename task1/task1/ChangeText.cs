using System;
using System.IO;

namespace task1
{
    internal class ChangeText : OpenFile
    {
        public static void Change_Text()
        {
            string textStream = ReadText();
            if (!String.IsNullOrEmpty(textStream))
            {
                Console.Write("Введите слово или символ который необходимо удалить: ");
                string word = Console.ReadLine();
                if (String.IsNullOrEmpty(word)) // Проверяем введена ли пустая строка
                {
                    Console.WriteLine("Вы ввели пустую строку");
                }
                else
                {
                    if (textStream.Contains(word)) // Проверяем существует ли введенное слово
                    {
                        string textReplace = textStream.Replace(word, ""); //Сохраняем результат удаления слова
                        Console.WriteLine(textReplace); // Показываем измененный текст
                        Console.Write("Записать текст в файл? (y/n): ");
                        string answer = Console.ReadLine().ToLower();
                        if (answer == "y")
                        {
                            Console.Write("Введите путь куда хотите сохранить файл: ");
                            string writePath = (Console.ReadLine()); // Путь к новому файлу
                            string writePathFile = writePath + "test_text_replace.txt";
                            try
                            {
                                using (StreamWriter sw = new StreamWriter(writePathFile, false, System.Text.Encoding.Default)) //Записуем измененный текст в файл(новый или перезаписываем существующий)
                                {
                                    sw.WriteLine(textReplace);
                                    sw.Close();
                                }
                                Console.WriteLine("Запись выполнена в файл: " + writePathFile);
                            }
                            catch (Exception e)
                            {
                                Console.WriteLine(e.Message);
                            }
                        }
                    }
                    else
                    {
                        Console.WriteLine("В тексте нет такого слова");
                    }
                }

                Console.WriteLine("Для завершения нажмите любую кнопку");
                Console.ReadKey();
            }
        }
    }
}