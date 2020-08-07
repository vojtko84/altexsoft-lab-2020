using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace task1
{
    internal class WordsReverse : OpenFile
    {
        public static void Read_3_String()
        {
            string textStream = ReadText();
            if (!String.IsNullOrEmpty(textStream))
            {
                string[] textArray = textStream.Split(new char[] { '.' }, StringSplitOptions.RemoveEmptyEntries); //Разбиваем текст на предложения
                string text3 = textArray[2]; // Находим третью строку
                Regex regex = new Regex(@"[^\w'\s]+", RegexOptions.Compiled);
                string replaceText = regex.Replace(text3, "").Trim();
                Regex regex1 = new Regex(@"\s+", RegexOptions.Compiled);
                string[] textArrayWord = regex1.Split(replaceText); //Разбиваем текст на слова
                string word;
                List<string> allWords = new List<string>();
                for (int i = 0; i < textArrayWord.Length; i++)
                {
                    word = new string(textArrayWord[i].ToCharArray().Reverse().ToArray()); // Меняем порядок букв в слове на обратный
                    allWords.Add(word);
                }
                Console.WriteLine();
                Console.WriteLine(String.Join(' ', allWords));
                Console.ReadKey();
            }
        }
    }
}