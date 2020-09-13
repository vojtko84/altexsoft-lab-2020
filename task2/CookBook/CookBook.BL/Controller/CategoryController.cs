using CookBook.BL.Context;
using CookBook.BL.Model;
using System;
using System.Collections.Generic;

namespace CookBook.BL.Controller
{
    public class CategoryController
    {
        private UnitOfWork unitOfWork;

        public CategoryController(UnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public List<Category> GetCategories()
        {
            return unitOfWork.CategoryRepository.GetAll();
        }

        public void ShowCategories()
        {
            Console.WriteLine("Категории:");
            foreach (var item in unitOfWork.CategoryRepository.GetAll())
            {
                Console.WriteLine($"{item.Id}. {item.Name}");
            }
        }
    }
}