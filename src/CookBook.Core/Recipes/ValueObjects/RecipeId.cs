namespace CookBook.Core.Recipes.ValueObjects;

public class RecipeId : EntityId
{
    private RecipeId()
    {
    }

    public static RecipeId Create(Guid? id = null)
    {
        return new RecipeId
        {
            Id = id ?? Guid.NewGuid()
        };
    }

    public static explicit operator RecipeId(Guid id) => Create(id);

    public static implicit operator Guid(RecipeId id) => id.Id;
}