using CookBook.BL.Context;
using CookBook.BL.Controller;
using CookBook.BL.Model;
using System.Collections.Generic;

namespace CookBook.BL.Repository
{
    public class RecipeRepository : BaseRepository, IRepository<Recipe>
    {
        public RecipeRepository(JsonContext context)
        {
            this.db = context;
        }

        public List<Recipe> GetAll()
        {
            return db.Recipes;
        }

        public void Save()
        {
            db.SaveRecipes();
        }
    }
}