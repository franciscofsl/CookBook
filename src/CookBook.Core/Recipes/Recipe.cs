using System.Diagnostics.CodeAnalysis;
using CookBook.Core.Recipes.Events;
using CookBook.Core.Recipes.ValueObjects;
using Sawnet.Core.Results;

namespace CookBook.Core.Recipes;

public class Recipe : AggregateRoot<RecipeId>
{
    [ExcludeFromCodeCoverage]
    private Recipe()
    {
    }

    public Recipe(RecipeId id)
        : base(id)
    {
        IsDraft = true;
        PreparationTime = PreparationTime.Empty;
        Ingredients = Ingredients.Empty;
    }

    public RecipeTitle Title { get; set; }

    public RecipeDescription Description { get; set; }

    public PreparationTime PreparationTime { get; set; }

    public Ingredients Ingredients { get; set; }

    public bool IsDraft { get; private set; }

    public Result Publish()
    {
        var checkResult = CheckPublish();

        if (checkResult.IsFailure)
        {
            return checkResult;
        }

        IsDraft = false;
        RaiseDomainEvent(new RecipePublished(this));

        return Result.Ok();
    }

    private Result CheckPublish()
    {
        if (Title is null)
        {
            return Result.Failure(RecipeErrors.NotHasTitle);
        }

        if (Description is null)
        {
            return Result.Failure(RecipeErrors.NotHasDescription);
        }

        if (!Ingredients.Lines.Any())
        { 
            return Result.Failure(RecipeErrors.NotHasIngredients);
        }

        return Result.Ok();
    }
}