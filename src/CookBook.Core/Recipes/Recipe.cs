using CookBook.Core.Recipes.Events;
using CookBook.Core.Recipes.ValueObjects;

namespace CookBook.Core.Recipes;

public class Recipe : AggregateRoot<RecipeId>
{
    private Recipe()
    {
    }

    public Recipe(RecipeId id, RecipeTitle title, RecipeDescription description)
        : base(id)
    {
        Title = GuardClause.NotNull(title, nameof(title));
        Description = GuardClause.NotNull(description, nameof(description));
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