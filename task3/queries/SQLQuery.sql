WITH  Category_CTE AS
(
	SELECT * FROM dbo.Category
	WHERE dbo.Category.Id = 3
	UNION ALL
	SELECT dbo.Category.Id, dbo.Category.Name, dbo.Category.ParentId FROM dbo.Category
	JOIN Category_CTE ON dbo.Category.ParentId = Category_CTE.Id
)
SELECT x.Name, dbo.Ingredient.Name FROM
(
	SELECT TOP 3 dbo.Recipe.* FROM dbo.Recipe
	JOIN Category_CTE ON dbo.Recipe.CategoryId = Category_CTE.Id
	ORDER BY Recipe.CategoryId
) AS x
JOIN dbo.RecipeIngredient ON x.Id = dbo.RecipeIngredient.RecipeId
JOIN dbo.Ingredient ON dbo.RecipeIngredient.IngredientId = dbo.Ingredient.Id