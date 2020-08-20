using CookBook.BL.Controller;
using CookBook.BL.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization.Json;

namespace CookBook.CMD
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            CategoryController categoryController = new CategoryController();
            RecipeController recipeController = new RecipeController();

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
            }
            List<Ingredient> allingredients = new List<Ingredient>();
            allingredients = GetAllIngredients(recipeController);
            SaveIngredients(allingredients);
            Console.WriteLine("Показать ингредиенты которые использовались в рецептах?(y/n)");
            string choiceShowIngredient = Console.ReadLine();
            if (choiceShowIngredient.ToUpper() == "Y")
            {
                ShowAllIngredients(allingredients);
            }

            Console.WriteLine("");

            static int GetNumberCategory(CategoryController categoryController)
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
                } while (numberSelectedCategory > categoryController.Categories.Count);
                return numberSelectedCategory;
            }
            static int GetNumberRecipe(RecipeController recipeController, int numberSelectedCategory)
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
            static Recipe CreateRecipe(RecipeController recipeController)
            {
                Console.WriteLine("Создать рецепт");
                Recipe recipe = recipeController.CreateRecipe();
                recipeController.Recipes.Add(recipe);
                recipeController.SaveRecipes();
                return recipe;
            }
            static List<Ingredient> GetAllIngredients(RecipeController recipeController)
            {
                List<Ingredient> Ingredients = new List<Ingredient>();

                foreach (var recipe in recipeController.Recipes)
                {
                    var ingredients = recipe.Ingredients;
                    foreach (var item in ingredients)
                    {
                        Ingredients.Add(item);
                    }
                }

                return Ingredients;
            }
            static void SaveIngredients(List<Ingredient> allIngredients)
            {
                var jsonFormatter = new DataContractJsonSerializer(typeof(List<Ingredient>));
                using (var file = new FileStream("ingredient.json", FileMode.Create))
                {
                    jsonFormatter.WriteObject(file, allIngredients);
                }
            }
            static void ShowAllIngredients(List<Ingredient> allingredients)
            {
                foreach (var item in allingredients)
                {
                    Console.WriteLine($"-{item.Name}.");
                }
                Console.ReadLine();
            }
        }
    }
}