using CookBook.Core.Recipes;
using CookBook.Core.Recipes.Records;
using CookBook.Core.Recipes.ValueObjects;

namespace CookBook.Test;

public class RecipeBuilder
{
    private RecipeTitle _title = RecipeTitle.Empty;
    private RecipeDescription _description = RecipeDescription.Empty;
    private PreparationTime _preparationTime = PreparationTime.Empty;

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


    public RecipeBuilder SetPreparationTime(int? hours, int minutes)
    {
        _preparationTime = PreparationTime.Create(hours, minutes);
        return this;
    }

    public static RecipeBuilder Create()
    {
        return new RecipeBuilder();
    }

    public Recipe Build()
    {
        var id = (RecipeId)Guid.NewGuid();
        var recipe = Recipe.Create(id);

        recipe.Update(new RecipeUpdateInfo(_title, _description, _preparationTime.Hours, _preparationTime.Minutes));

        return recipe;
    }
}