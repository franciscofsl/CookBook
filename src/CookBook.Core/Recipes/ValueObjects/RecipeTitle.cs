namespace CookBook.Core.Recipes.ValueObjects;

public sealed class RecipeTitle : ValueObject
{
    private RecipeTitle()
    {
        
    }
    
    private RecipeTitle(string title)
    {
        Title = GuardClauses.NotNullOrEmpty(title, nameof(title));
    }

    public static RecipeTitle Create(string title)
    {
        return new RecipeTitle(title);
    }

    public string Title { get; }

    public override IEnumerable<object> GetAtomicValues()
    {
        yield return Title;
    }

    public static implicit operator string(RecipeTitle title) => title.Title;

    public static explicit operator RecipeTitle(string title) => new RecipeTitle(title);
}
