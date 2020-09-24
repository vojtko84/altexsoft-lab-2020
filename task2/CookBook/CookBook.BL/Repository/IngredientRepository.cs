using CookBook.BL.Context;
using CookBook.BL.Controller;
using CookBook.BL.Model;
using System.Collections.Generic;

namespace CookBook.BL.Repository
{
    public class IngredientRepository : BaseRepository, IRepository<Ingredient>
    {
        public IngredientRepository(JsonContext context) : base(context)
        {
        }

        public List<Ingredient> GetAll()
        {
            return Db.Ingredients;
        }

        public void Save()
        {
            Db.SaveIngredients();
        }
    }
}