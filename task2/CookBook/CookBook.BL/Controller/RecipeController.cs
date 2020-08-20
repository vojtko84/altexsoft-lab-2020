using CookBook.BL.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Json;

namespace CookBook.BL.Controller
{
    public class RecipeController
    {
        public List<Recipe> Recipes { get; set; }
        private readonly string nameFile = "recipe.json";

        public RecipeController()
        {
            Recipes = GetRecipes();
        }

        public List<Recipe> GetRecipes()
        {
            var jsonFormatter = new DataContractJsonSerializer(typeof(List<Recipe>));

            using (var file = new FileStream(nameFile, FileMode.Open))
            {
                var data = jsonFormatter.ReadObject(file) as List<Recipe>;
                return data;
            }
        }

        public List<Recipe> GetSelectedRecipes(int numberSelectedCategory)
        {
            var recipesCategory = (from recipe in Recipes
                                   where recipe.IdCategory == numberSelectedCategory
                                   select recipe).ToList<Recipe>();
            return recipesCategory;
        }

        public void ShowRecipesCategory(int numberSelectedCategory)
        {
            var recipesCategory = GetSelectedRecipes(numberSelectedCategory);
            Console.WriteLine("Рецепты:");
            for (int i = 0; i < recipesCategory.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {recipesCategory[i].Name}");
            }
        }

        public void ShowSelectedRecipe(int numberSelectedRecipe, int numberSelectedCategory)
        {
            var rerecipesCategory = GetSelectedRecipes(numberSelectedCategory);
            Console.Clear();

            Console.WriteLine($"Название: {rerecipesCategory[numberSelectedRecipe - 1].Name}");
            Console.WriteLine($"Описание: {rerecipesCategory[numberSelectedRecipe - 1].Description}");
            Console.WriteLine("Ингредиенты:");
            foreach (var item in rerecipesCategory[numberSelectedRecipe - 1].Ingredients)
            {
                Console.WriteLine($"{item.Name}: {item.Amount}");
            }
            Console.WriteLine("Шаги приготовления:");
            foreach (var item in rerecipesCategory[numberSelectedRecipe - 1].Steps)
            {
                Console.WriteLine($"{item.Number}. {item.Instruction}");
            }
        }

        public void SaveRecipes()
        {
            var jsonFormatter = new DataContractJsonSerializer(typeof(List<Recipe>));
            using (var file = new FileStream(nameFile, FileMode.Create))
            {
                jsonFormatter.WriteObject(file, Recipes);
            }
        }

        public Recipe CreateRecipe()
        {
            Console.Write("Укажите название рецепта: ");
            string name = Console.ReadLine();
            Console.Write("Укажите описание: ");
            string description = Console.ReadLine();
            Console.Write("Выберите категорию рецепта: ");
            int idCategory = int.Parse(Console.ReadLine());
            List<Ingredient> ingredients = new List<Ingredient>();
            while (true)
            {
                Console.Write("Укажите название ингредиента: ");
                string nameIngredient = Console.ReadLine();
                Console.Write("Укажите количество ингредиента: ");
                double amountIngredient = double.Parse(Console.ReadLine());
                Ingredient ingredient = new Ingredient(nameIngredient, amountIngredient);
                ingredients.Add(ingredient);
                Console.WriteLine("Нажмите ENTER для ввода еще одного ингредиента или любую другую кнопку для продолжения");
                if (Console.ReadKey().Key != ConsoleKey.Enter)
                    break;
            }
            List<Step> steps = new List<Step>();
            int idStep = 0;
            while (true)
            {
                idStep++;
                Console.Write("Инструкция к шагу приготовления: ");
                string stepInstruction = Console.ReadLine();
                Console.WriteLine("Нажмите ENTER для следущей инструкции или любую другую кнопку для продолжения");
                Step step = new Step(idStep, stepInstruction);
                steps.Add(step);
                if (Console.ReadKey().Key != ConsoleKey.Enter)
                    break;
            }
            Recipe recipe = new Recipe(name, idCategory, description, ingredients, steps);
            return recipe;
        }
    }
}