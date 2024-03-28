using CookBook.Core.Recipes.Enums;
using CookBook.Core.Recipes.ValueObjects;

namespace CookBook.Core.Recipes.Entities;

public sealed class Ingredient : Entity<IngredientLineId>
{
    private Ingredient()
    {
    }

    internal static Ingredient CreateIngredient(string description, int order)
    {
        return new Ingredient
        {
            Description = description,
            Order = order,
            Type = IngredientType.Ingredient
        };
    }

    internal static Ingredient CreateSection(string description, int order)
    {
        return new Ingredient
        {
            Description = description,
            Order = order,
            Type = IngredientType.Section
        };
    }

    public IngredientType Type { get; private init; }

    public string Description { get; private init; }

    public int Order { get; private init; }
}