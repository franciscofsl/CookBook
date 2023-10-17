using CookBook.Core.Recipes.Enums;

namespace CookBook.Core.Recipes.ValueObjects;

public sealed record IngredientLine : ValueObject
{
    private IngredientLine()
    {
    }

    internal static IngredientLine CreateIngredient(string description, int order)
    {
        return new IngredientLine
        {
            Description = description,
            Order = order,
            Type = IngredientType.Ingredient
        };
    }

    internal static IngredientLine CreateSection(string description, int order)
    {
        return new IngredientLine
        {
            Description = description,
            Order = order,
            Type = IngredientType.Section
        };
    }

    public IngredientType Type { get; private init; }

    public string Description { get; private init; }

    public int Order { get; private init; }

    protected override IEnumerable<object> GetAtomicValues()
    {
        yield return Type;
        yield return Description;
        yield return Order;
    }
}