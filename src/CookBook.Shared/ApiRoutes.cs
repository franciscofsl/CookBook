namespace CookBook.Shared;

public static class ApiRoutes
{
    public const string Common = "api";

    public const string Recipes = $"{Common}/Recipes";
    
    public const string Menus = $"{Common}/Menus";

    public static string RecipeById(Guid recipeId) => $"{Common}/Recipes?recipeId={recipeId}";

    public const string MyRecipes = $"{Common}/My-Recipes";

    public const string Logs = $"{Common}/Logs";
}