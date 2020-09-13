using CookBook.BL.Context;
using CookBook.BL.Controller;
using CookBook.BL.Model;
using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Linq;

namespace CookBook.BL.Repository
{
    public class RecipeRepository : IRepository<Recipe>
    {
        private JsonContext db;
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
