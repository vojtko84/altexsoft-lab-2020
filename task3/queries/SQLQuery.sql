SELECT dbo.Recipe.Name, dbo.Recipe.Description, dbo.Ingredient.Name 
FROM dbo.Recipe
JOIN dbo.RecipeIngredient
ON dbo.RecipeIngredient.RecipeId = dbo.Recipe.Id
JOIN dbo.Ingredient
ON  dbo.Ingredient.Id = dbo.RecipeIngredient.IngredientId
WHERE dbo.Recipe.Id IN (SELECT TOP 3 dbo.Recipe.Id FROM dbo.Recipe
WHERE dbo.Recipe.CategoryId = 3)