using CookBook.BL.Context;
using CookBook.BL.Controller;
using CookBook.BL.Model;
using System.Collections.Generic;

namespace CookBook.BL.Repository
{
    public class RecipeRepository : BaseRepository, IRepository<Recipe>
    {
        public RecipeRepository(JsonContext context) : base(context)
        {
        }

        public List<Recipe> GetAll()
        {
            return Db.Recipes;
        }

        public void Save()
        {
            Db.SaveRecipes();
        }
    }
}