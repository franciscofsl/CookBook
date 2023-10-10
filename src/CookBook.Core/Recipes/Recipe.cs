using CookBook.Core.Recipes.Events;
using CookBook.Core.Recipes.ValueObjects;

namespace CookBook.Core.Recipes;

public class Recipe : AggregateRoot<RecipeId>
{
    private Recipe()
    {
    }

    public Recipe(RecipeId id)
        : base(id)
    {
        IsDraft = true;
    }

    public RecipeTitle Title { get; private set; }

    public RecipeDescription Description { get; private set; }

    public PreparationTime PreparationTime { get; set; }
    
    public Ingredients Ingredients { get; set; }

    public bool IsDraft { get; private set; }

    public void Publish()
    {
        IsDraft = false;
        RaiseDomainEvent(new RecipePublished(this));
    }
}