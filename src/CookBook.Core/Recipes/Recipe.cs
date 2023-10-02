using CookBook.Core.Recipes.ValueObjects;

namespace CookBook.Core.Recipes;

public class Recipe : AggregateRoot<RecipeId>
{
    private Recipe()
    {
    }

    public Recipe(RecipeId id, RecipeTitle title, RecipeDescription description)
        : base(id)
    {
        Title = GuardClauses.NotNull(title, nameof(title));
        Description = GuardClauses.NotNull(description, nameof(description));
    }

    public RecipeTitle Title { get; private set; }

    public RecipeDescription Description { get; private set; }
}