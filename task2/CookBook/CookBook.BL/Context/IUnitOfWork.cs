using CookBook.BL.Repository;

namespace CookBook.BL.Context
{
    public interface IUnitOfWork
    {
        CategoryRepository CategoryRepository { get; }
        RecipeRepository RecipeRepository { get; }
        IngredientRepository IngredientRepository { get; }

        void Save();
    }
}