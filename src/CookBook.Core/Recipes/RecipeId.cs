namespace CookBook.Core.Recipes;

public class RecipeId : EntityId
{
    private RecipeId(Guid id) : base(id)
    {
    }

    public static RecipeId Create(Guid id)
    {
        return new RecipeId(id);
    }

    public static explicit operator RecipeId(Guid id) => new(id);
}