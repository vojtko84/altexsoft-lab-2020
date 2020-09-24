using CookBook.BL.Context;

namespace CookBook.BL.Controller
{
    public abstract class BaseController
    {
        protected readonly IUnitOfWork UnitOfWork;

        public BaseController(UnitOfWork unitOfWork)
        {
            UnitOfWork = unitOfWork;
        }
    }
}