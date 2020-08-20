using CookBook.BL.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Json;

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
            var jsonFormatter = new DataContractJsonSerializer(typeof(List<Category>));

            using (var file = new FileStream(nameFile, FileMode.Open))
            {
                var data = jsonFormatter.ReadObject(file) as List<Category>;
                return data;
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