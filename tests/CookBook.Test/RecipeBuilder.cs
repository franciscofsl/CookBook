using CookBook.Core.Recipes;
using CookBook.Core.Recipes.ValueObjects;

namespace CookBook.Test;

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
        var id = (RecipeId)Guid.NewGuid();
        return new Recipe(id)
        {
            Title = _title,
            Description = _description
        };
    }
}