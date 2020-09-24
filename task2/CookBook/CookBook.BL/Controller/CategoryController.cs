using CookBook.BL.Context;
using CookBook.BL.Model;
using System;
using System.Collections.Generic;

namespace CookBook.BL.Controller
{
    public class CategoryController : BaseController
    {
        public CategoryController(UnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        public List<Category> GetCategories()
        {
            return UnitOfWork.CategoryRepository.GetAll();
        }

        public void ShowCategories()
        {
            Console.WriteLine("Категории:");
            foreach (var item in UnitOfWork.CategoryRepository.GetAll())
            {
                Console.WriteLine($"{item.Id}. {item.Name}");
            }
        }
    }
}