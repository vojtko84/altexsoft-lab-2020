using CookBook.BL.Context;
using CookBook.BL.Controller;
using CookBook.BL.Model;
using System.Collections.Generic;

namespace CookBook.BL.Repository
{
    public class IngredientRepository : IRepository<Ingredient>
    {
        private JsonContext db;

        public IngredientRepository(JsonContext context)
        {
            this.db = context;
        }

        public List<Ingredient> GetAll()
        {
            return db.Ingredients;
        }

        public void Save()
        {
            db.SaveIngredients();
        }
    }
}