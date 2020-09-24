using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.Json;

namespace CookBook.BL.Context
{
    internal class JsonManager
    {
        public static void Save<T>(List<T> list, string nameFile) where T : class
        {
            string json = JsonSerializer.Serialize<List<T>>(list);
            File.WriteAllText(nameFile, json, Encoding.Unicode);
        }

        public static List<T> Load<T>(string nameFile) where T : class
        {
            if (File.Exists(nameFile))
            {
                string json = File.ReadAllText(nameFile, Encoding.Unicode);

                var data = JsonSerializer.Deserialize<List<T>>(json);
                return data;
            }
            else
            {
                Console.WriteLine("Файл не существует");
                return null;
            }
        }
    }
}