using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace task1
{
    internal class WordCounter : OpenFile
    {
        public static void Read_Write_Text()
        {
            string textStream = ReadText();
            if (!String.IsNullOrEmpty(textStream))
            {
                Regex regex = new Regex(@"[^\w'\s]+", RegexOptions.Compiled);
                string replaceText = regex.Replace(textStream, "").Trim();
                Regex regex1 = new Regex(@"\s+", RegexOptions.Compiled);
                string[] textArray = regex1.Split(replaceText.Trim()); //Разбиваем текст на слова
                string word;
                List<string> allWords = new List<string>(); // Создаем список
                for (int i = 0, j = i + 1; i < textArray.Length; j++, i++)
                {
                    if (j % 10 == 0) //Находим каждое 10 слово
                    {
                        word = textArray[i];
                        allWords.Add(word); // Добавляем в список слово
                    }
                }
                Console.WriteLine("Количество слов в тексте: " + textArray.Length); //Выводим общее количество слов в тексте
                Console.WriteLine(); //Переходим на новую строку
                Console.WriteLine(String.Join(',', allWords)); // Объеденяем строку с разделителеи
                Console.WriteLine();
                Console.WriteLine("Для завершения нажмите любую кнопку");
                Console.ReadKey();
            }
        }
    }
}