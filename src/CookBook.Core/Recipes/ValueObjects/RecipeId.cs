namespace CookBook.Core.Recipes.ValueObjects;

public record RecipeId(Guid Id) : EntityId(Id)
{
    public static explicit operator RecipeId(Guid id) => new(id);

    public static implicit operator Guid(RecipeId id) => id.Value;
}