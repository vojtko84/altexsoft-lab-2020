using CookBook.BL.Repository;

namespace CookBook.BL.Context
{
    public class UnitOfWork : IUnitOfWork
    {
        private JsonContext db;
        private CategoryRepository categoryRepository;
        private RecipeRepository recipeRepository;
        private IngredientRepository ingredientRepository;

        public UnitOfWork(JsonContext db)
        {
            this.db = db;
        }

        public CategoryRepository CategoryRepository
        {
            get
            {
                categoryRepository = new CategoryRepository(db);
                return categoryRepository;
            }
        }

        public RecipeRepository RecipeRepository
        {
            get
            {
                recipeRepository = new RecipeRepository(db);
                return recipeRepository;
            }
        }

        public IngredientRepository IngredientRepository
        {
            get
            {
                ingredientRepository = new IngredientRepository(db);
                return ingredientRepository;
            }
        }

        public void Save()
        {
            RecipeRepository.Save();
            IngredientRepository.Save();
        }
    }
}