﻿using CookBook.BL.Context;
using CookBook.BL.Model;
using System;
using System.Collections.Generic;
using System.Linq;

namespace CookBook.BL.Controller
{
    public class RecipeController : BaseController
    {
        public RecipeController(UnitOfWork unitOfWork) : base(unitOfWork)
        {
        }

        public List<Recipe> GetRecipes()
        {
            return UnitOfWork.RecipeRepository.GetAll();
        }

        public List<Recipe> GetSelectedRecipes(int numberSelectedCategory)
        {
            var recipesCategory = (from recipe in GetRecipes()
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
            UnitOfWork.Save();
        }

        public Recipe CreateRecipe()
        {
            Recipe recipe = new Recipe();
            Console.Write("Укажите название рецепта: ");
            recipe.Name = Console.ReadLine();
            Console.Write("Укажите описание: ");
            recipe.Description = Console.ReadLine();
            Console.Write("Выберите категорию рецепта: ");
            int idCategory;
            while (!int.TryParse(Console.ReadLine(), out idCategory))
            {
                Console.WriteLine("Не корректный выбор (введите число)");
                Console.Write("Повторите выбор: ");
            }
            recipe.IdCategory = idCategory;
            List<Ingredient> ingredients = new List<Ingredient>();
            while (true)
            {
                Ingredient ingredient = new Ingredient();
                Console.Write("Укажите название ингредиента: ");
                ingredient.Name = Console.ReadLine();
                Console.Write("Укажите количество ингредиента: ");
                double amountIngredient;
                while (!double.TryParse(Console.ReadLine(), out amountIngredient))
                {
                    Console.WriteLine("Не корректный выбор (введите число)");
                    Console.Write("Повторите выбор: ");
                }
                ingredient.Amount = amountIngredient;
                ingredients.Add(ingredient);
                Console.WriteLine("Нажмите ENTER для ввода еще одного ингредиента или любую другую кнопку для продолжения");
                if (Console.ReadKey().Key != ConsoleKey.Enter)
                    break;
            }
            recipe.Ingredients = ingredients;
            List<Step> steps = new List<Step>();
            int idStep = 0;
            while (true)
            {
                idStep++;
                Step step = new Step();
                step.Number = idStep;
                Console.Write("Инструкция к шагу приготовления: ");
                step.Instruction = Console.ReadLine();
                Console.WriteLine("Нажмите ENTER для следущей инструкции или любую другую кнопку для продолжения");
                steps.Add(step);
                if (Console.ReadKey().Key != ConsoleKey.Enter)
                    break;
            }
            recipe.Steps = steps;
            return recipe;
        }
    }
}