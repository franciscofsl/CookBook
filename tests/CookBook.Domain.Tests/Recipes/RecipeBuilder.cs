using CookBook.Core.Recipes.ValueObjects;

namespace CookBook.Domain.Tests.Recipes;

public class RecipeBuilder
{
    private RecipeTitle _title;
    private RecipeDescription _description;

    private RecipeBuilder()
    {
    }

    public RecipeBuilder SetTitle(RecipeTitle title)
    {
        _title = title;
        return this;
    }

    public RecipeBuilder SetDescription(RecipeDescription description)
    {
        _description = description;
        return this;
    }

    public static RecipeBuilder Create()
    {
        return new RecipeBuilder();
    }

    public Recipe Build()
    {
        var id = RecipeId.Create(Guid.NewGuid());
        var title = RecipeTitle.Create("Test Title");
        var description = RecipeDescription.Create("Recipe Description");
        return new Recipe(id, _title ?? title, _description ?? description);
    }
}