namespace CookBook.Core.Recipes.ValueObjects;

public sealed record RecipeTitle : ValueObject
{
    public static readonly int MaxLenght = 80;
    public static readonly RecipeTitle Empty = Create(string.Empty);

    private RecipeTitle()
    {
    }

    public static RecipeTitle Create(string title)
    {
        return new RecipeTitle
        {
            Value = Ensure.NotNull(title, nameof(title))
        };
    }

    public string Value { get; private init; }

    protected override IEnumerable<object> GetAtomicValues()
    {
        yield return Value;
    }

    public static implicit operator string(RecipeTitle title) => title?.Value;

    public static explicit operator RecipeTitle(string title) => Create(title);

    public bool IsEmpty() => Value == string.Empty;
}