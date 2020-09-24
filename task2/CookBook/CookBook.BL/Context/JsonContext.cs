using CookBook.BL.Model;
using System.Collections.Generic;

namespace CookBook.BL.Context
{
    public class JsonContext
    {
        public List<Category> Categories { get; set; }
        public List<Recipe> Recipes { get; set; }
        public List<Ingredient> Ingredients { get; set; }
        private readonly string categoryNameFile = "category.json";
        private readonly string recipeNameFile = "recipe.json";
        private readonly string ingridientNameFile = "ingredient.json";

        public JsonContext()
        {
            Categories = JsonManager.Load<Category>(categoryNameFile);
            Recipes = JsonManager.Load<Recipe>(recipeNameFile);
            Ingredients = JsonManager.Load<Ingredient>(ingridientNameFile);
        }

        public void SaveRecipes()
        {
            JsonManager.Save(Recipes, recipeNameFile);
        }

        public void SaveIngredients()
        {
            JsonManager.Save(Ingredients, ingridientNameFile);
        }
    }
}