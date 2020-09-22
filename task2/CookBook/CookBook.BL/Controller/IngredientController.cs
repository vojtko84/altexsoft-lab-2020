using CookBook.BL.Context;
using CookBook.BL.Model;
using System;
using System.Collections.Generic;

namespace CookBook.BL.Controller
{
    public class IngredientController : BaseController
    {
        public IngredientController(UnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public List<Ingredient> GetAllIngredients()
        {
            List<Ingredient> ingredients = new List<Ingredient>();
            foreach (var recipe in unitOfWork.RecipeRepository.GetAll())
            {
                var ingredient = recipe.Ingredients;
                foreach (var item in ingredient)
                {
                    ingredients.Add(item);
                }
            }
            return ingredients;
        }

        public void SaveIngredients()
        {
            unitOfWork.Save();
        }

        public void ShowAllIngredients()
        {
            foreach (var item in unitOfWork.IngredientRepository.GetAll())
            {
                Console.WriteLine($"-{item.Name}.");
            }
            Console.ReadLine();
        }
    }
}