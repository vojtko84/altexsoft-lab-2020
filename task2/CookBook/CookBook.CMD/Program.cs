using CookBook.BL.Context;
using CookBook.BL.Controller;
using CookBook.BL.Model;
using System;
using System.Collections.Generic;

namespace CookBook.CMD
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            JsonContext jsonContext = new JsonContext();
            UnitOfWork unitOfWork = new UnitOfWork(jsonContext);
            CategoryController categoryController = new CategoryController(unitOfWork);
            RecipeController recipeController = new RecipeController(unitOfWork);
            IngredientController ingredientController = new IngredientController(unitOfWork);

            categoryController.ShowCategories();

            int numberSelectedCategory = GetNumberCategory(categoryController);

            recipeController.ShowRecipesCategory(numberSelectedCategory);

            int numberSelectedRecipe = GetNumberRecipe(recipeController, numberSelectedCategory);

            recipeController.ShowSelectedRecipe(numberSelectedRecipe, numberSelectedCategory);

            Console.WriteLine("Хотите создать свой рецепт?(y/n)");
            string choiceCreateRecipe = Console.ReadLine();
            if (choiceCreateRecipe.ToUpper() == "Y")
            {
                CreateRecipe(recipeController);
                jsonContext.Ingredients = ingredientController.GetAllIngredients();
                ingredientController.SaveIngredients();
            }

            Console.WriteLine("Показать ингредиенты которые использовались в рецептах?(y/n)");
            string choiceShowIngredient = Console.ReadLine();
            if (choiceShowIngredient.ToUpper() == "Y")
            {
                ingredientController.ShowAllIngredients();
            }

            Console.WriteLine("");
        }

        private static int GetNumberCategory(CategoryController categoryController)
        {
            int numberSelectedCategory;

            do
            {
                Console.Write("Выберете категорию: ");
                while (!int.TryParse(Console.ReadLine(), out numberSelectedCategory))
                {
                    Console.WriteLine("Не корректный выбор (введите число)");
                    Console.Write("Повторите выбор: ");
                }
            } while (numberSelectedCategory > categoryController.GetCategories().Count);
            return numberSelectedCategory;
        }

        private static int GetNumberRecipe(RecipeController recipeController, int numberSelectedCategory)
        {
            List<Recipe> recipesCategory = recipeController.GetSelectedRecipes(numberSelectedCategory);
            int numberSelectedCRecipe;
            do
            {
                Console.Write("Выберете рецепт: ");
                while (!int.TryParse(Console.ReadLine(), out numberSelectedCRecipe))
                {
                    Console.WriteLine("Не корректный выбор (введите число)");
                    Console.Write("Повторите выбор: ");
                }
            } while (numberSelectedCRecipe > recipesCategory.Count);
            return numberSelectedCRecipe;
        }

        private static Recipe CreateRecipe(RecipeController recipeController)
        {
            Console.WriteLine("Создать рецепт");
            Recipe recipe = recipeController.CreateRecipe();
            recipeController.GetRecipes().Add(recipe);
            recipeController.SaveRecipes();
            return recipe;
        }
    }
}