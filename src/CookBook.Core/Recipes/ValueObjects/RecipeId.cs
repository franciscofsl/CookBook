namespace CookBook.Core.Recipes.ValueObjects;

public record RecipeId : EntityId
{
    private RecipeId()
    {
    }

    public static RecipeId Create(Guid? value = null)
    {
        return new RecipeId
        {
            Value = value ?? Guid.NewGuid()
        };
    }

    public static explicit operator RecipeId(Guid id) => Create(id);

    public static implicit operator Guid(RecipeId id) => id.Value;
}