using System;
using System.IO;


namespace task1
{
    class Program
    {
        static void Main(string[] args)
        {
            StreamReader stream = new StreamReader(@"F:\altexsoft-lab\altexsoft-lab-2020\task1\test_text.txt"); // Передаем путь к считываемому файлу 
            string textStream = stream.ReadToEnd(); // Считываем весь текс с текстового файла
            Change_Text(textStream);
            Read_Write_Text(textStream);
        }


       
        static void Change_Text(string textStream)
        {
            Console.Write("Введите слово или символ который необходимо удалить: ");
            string word = Console.ReadLine(); 
            if (textStream.Contains(word) == true) // Проверяем существует ли введенное слово
            {
                string textReplace = textStream.Replace(word, ""); //Сохраняем результат удаления слова
                Console.WriteLine(textReplace);
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
            Console.WriteLine("Для завершения нажмите любую кнопку");
            Console.ReadKey();
        }


        static void Read_Write_Text(string textStream)
        {
            string[] textArray = textStream.Split(new char[] { ' ', '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries); //Разбиваем текст на слова
                                    
            for (int i = 0, j = i + 1; i < textArray.Length; j++, i++)
             {
                if (j%10 == 0) //Находим каждое 10 слово
                {
                    textArray[i] = textArray[i].Trim(new char[] { '.', ',', '?', '"', '(', ')' }); //Убираем спец символы
                    Console.Write(textArray[i] + ", "); //Выводим в одну строку каждое 10 слово через запятую
                }
                
             }
            Console.WriteLine(); //Переходим на новую строку
            Console.WriteLine("Количество слов: " + textArray.Length); //Выводим общее количество слов в тексте
            Console.ReadKey();
        }
    }
}
