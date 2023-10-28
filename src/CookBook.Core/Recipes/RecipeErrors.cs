using Sawnet.Core.Results;

namespace CookBook.Core.Recipes;

public static class RecipeErrors
{
    public static readonly Error NotHasTitle = new("Recipes.NotHasTitle", "Title is required");
    public static readonly Error NotHasDescription = new("Recipes.NotHasDescription", "Description is required");

    public static readonly Error NotHasIngredients =
        new("Recipes.NotHasIngredients", "The recipe must have at least one ingredient");
}