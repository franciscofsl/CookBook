namespace CookBook.Core.Recipes;

public class RecipeId : EntityId
{
    public static RecipeId Create(Guid id)
    {
        return new RecipeId
        {
            Id = id
        };
    }

    public static explicit operator RecipeId(Guid id) => Create(id);
}