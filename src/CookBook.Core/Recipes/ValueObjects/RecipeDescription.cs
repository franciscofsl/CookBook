namespace CookBook.Core.Recipes.ValueObjects;

public sealed record RecipeDescription : ValueObject
{
    public static readonly int MaxLenght = 250;
    public static readonly RecipeDescription Empty = Create(string.Empty);

    private RecipeDescription()
    {
    }

    public static RecipeDescription Create(string description)
    {
        return new RecipeDescription
        {
            Value = GuardClause.NotNull(description, nameof(description))
        };
    }

    public string Value { get; private init; }

    protected override IEnumerable<object> GetAtomicValues()
    {
        yield return Value;
    }

    public bool IsEmpty() => Value == string.Empty;

    public static implicit operator string(RecipeDescription description) => description?.Value;

    public static explicit operator RecipeDescription(string description) => Create(description);
}