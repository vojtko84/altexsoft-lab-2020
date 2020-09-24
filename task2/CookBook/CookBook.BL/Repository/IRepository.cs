using System.Collections.Generic;

namespace CookBook.BL.Controller
{
    public interface IRepository<T> where T : class
    {
        List<T> GetAll();
    }
}