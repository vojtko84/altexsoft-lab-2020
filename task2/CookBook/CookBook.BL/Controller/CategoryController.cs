using CookBook.BL.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace CookBook.BL.Controller
{
    public class CategoryController
    {
        public List<Category> Categories { get; }
        private readonly string nameFile = "category.json";

        public CategoryController()
        {
            Categories = GetCategories();
        }

        public List<Category> GetCategories()
        {
            if (File.Exists(nameFile))
            {
                string json = File.ReadAllText(nameFile);

                var data = JsonSerializer.Deserialize<List<Category>>(json);
                return data;
            }
            else
            {
                Console.WriteLine("Файл не существует");
                return null;
            }
        }

        public void ShowCategories()
        {
            Console.WriteLine("Категории:");
            foreach (var item in Categories)
            {
                Console.WriteLine($"{item.Id}. {item.Name}");
            }
        }
    }
}