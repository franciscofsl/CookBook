using CookBook.Core.Common.ValueObjects;
using CookBook.Core.Menus.ValueObjects;
using CookBook.Core.Recipes.ValueObjects;

namespace CookBook.Core.Menus;

public sealed class MealProduct : Entity<MealProductId>
{
    private MealProduct()
    {
        
    }
    
    public Name Name { get; set; }

    public Price Price { get; set; }

    public RecipeId AssociatedRecipeId { get; set; }

    public string Description { get; set; }

    public static MealProduct Create(MealProductId mealProductId, Name name, Price price, RecipeId associatedRecipeId,
        string description)
    {
        return new MealProduct
        {
            Id = Ensure.NotNull(mealProductId, nameof(mealProductId)),
            Name = Ensure.NotNull(name, nameof(name)),
            Description = description,
            Price = Ensure.NotNull(price, nameof(price)),
            AssociatedRecipeId = associatedRecipeId
        };
    }
}