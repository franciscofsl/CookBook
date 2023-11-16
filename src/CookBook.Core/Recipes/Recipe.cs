using CookBook.Core.Recipes.Events;
using CookBook.Core.Recipes.Records;
using CookBook.Core.Recipes.ValueObjects;
using Sawnet.Core.Results;

namespace CookBook.Core.Recipes;

public class Recipe : AggregateRoot<RecipeId>
{
    private Recipe()
    {
    }

    public static Recipe Create(RecipeId id)
    {
        return new Recipe
        {
            Id = id,
            Published = false,
            Title = RecipeTitle.Empty,
            Description = RecipeDescription.Empty,
            Ingredients = Ingredients.Empty,
            Ratings = Ratings.Empty,
            PreparationTime = PreparationTime.Empty
        };
    }

    public RecipeTitle Title { get; private set; }

    public RecipeDescription Description { get; private set; }

    public PreparationTime PreparationTime { get; private set; }

    public Ingredients Ingredients { get; init; }

    public Ratings Ratings { get; init; }

    public bool Published { get; private set; }

    public Result Publish()
    {
        if (CheckPublish() is { IsFailure: true } result)
        {
            return result;
        }

        Published = true;
        RaiseDomainEvent(new RecipePublished(this));

        return Result.Ok();
    }

    public Result Update(RecipeUpdateInfo updateInfo)
    {
        if (Published && CheckUpdateInfo(updateInfo) is { IsFailure : true } result)
        {
            return result;
        }

        Title = RecipeTitle.Create(updateInfo.Title);
        Description = RecipeDescription.Create(updateInfo.Description);
        PreparationTime = PreparationTime.Create(updateInfo.Hours, updateInfo.Minutes);

        return Result.Ok();
    }

    private Result CheckPublish()
    {
        if (Title.IsEmpty())
        {
            return Result.Failure(RecipeErrors.NotHasTitle);
        }

        if (Description.IsEmpty())
        {
            return Result.Failure(RecipeErrors.NotHasDescription);
        }

        if (!Ingredients.Lines.Any())
        {
            return Result.Failure(RecipeErrors.NotHasIngredients);
        }

        return Result.Ok();
    }

    private Result CheckUpdateInfo(RecipeUpdateInfo updateInfo)
    {
        if (string.IsNullOrEmpty(updateInfo.Title))
        {
            return Result.Failure(RecipeErrors.NotHasTitle);
        }

        if (string.IsNullOrEmpty(updateInfo.Description))
        {
            return Result.Failure(RecipeErrors.NotHasDescription);
        }

        return Result.Ok();
    }
}