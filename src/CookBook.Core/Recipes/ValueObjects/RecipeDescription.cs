namespace CookBook.Core.Recipes.ValueObjects;

public sealed class RecipeDescription : ValueObject
{
    private RecipeDescription()
    {
    }

    private RecipeDescription(string description)
    {
        Description = GuardClauses.NotNullOrEmpty(description, nameof(description));
    }

    public static RecipeDescription Create(string recipeDescription)
    {
        return new RecipeDescription(recipeDescription);
    }

    public string Description { get; }

    public override IEnumerable<object> GetAtomicValues()
    {
        yield return Description;
    }

    public static implicit operator string(RecipeDescription description) => description.Description;

    public static explicit operator RecipeDescription(string description) => new RecipeDescription(description);
}