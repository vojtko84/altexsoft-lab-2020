using CookBook.BL.Context;
using CookBook.BL.Controller;
using CookBook.BL.Model;
using System.Collections.Generic;

namespace CookBook.BL.Repository
{
    public class CategoryRepository : BaseRepository, IRepository<Category>
    {
        public CategoryRepository(JsonContext context) : base(context)
        {
        }

        public List<Category> GetAll()
        {
            return Db.Categories;
        }
    }
}