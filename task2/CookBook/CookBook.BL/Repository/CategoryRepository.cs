using CookBook.BL.Context;
using CookBook.BL.Controller;
using CookBook.BL.Model;
using System.Collections.Generic;

namespace CookBook.BL.Repository
{
    public class CategoryRepository : IRepository<Category>
    {
        private JsonContext db;

        public CategoryRepository(JsonContext context)
        {
            this.db = context;
        }

        public List<Category> GetAll()
        {
            return db.Categories;
        }
    }
}