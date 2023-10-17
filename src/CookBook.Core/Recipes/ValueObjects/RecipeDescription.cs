namespace CookBook.Core.Recipes.ValueObjects;

public sealed record RecipeDescription : ValueObject
{
    private RecipeDescription()
    {
    }

    public static RecipeDescription Create(string description)
    {
        return new RecipeDescription
        {
            Description = GuardClause.NotNullOrEmpty(description, nameof(description))
        };
    }

    public string Description { get; private init; }

    protected override IEnumerable<object> GetAtomicValues()
    {
        yield return Description;
    }

    public static implicit operator string(RecipeDescription description) => description?.Description;

    public static explicit operator RecipeDescription(string description) => Create(description);
}