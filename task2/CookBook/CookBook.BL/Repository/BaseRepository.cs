using CookBook.BL.Context;

namespace CookBook.BL.Repository
{
    public abstract class BaseRepository
    {
        protected readonly JsonContext Db;

        public BaseRepository(JsonContext context)
        {
            Db = context;
        }
    }
}