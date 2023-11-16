using System.Collections;
using CookBook.Core.Recipes.ValueObjects;

namespace CookBook.Core.Recipes;

public sealed class Ingredients : IEnumerable<IngredientLine>
{
    private readonly List<IngredientLine> _lines = new();

    public static Ingredients Empty => new();

    private Ingredients()
    {
    }

    public IReadOnlyCollection<IngredientLine> Lines => _lines.AsReadOnly();

    public IngredientLine AddIngredient(string description)
    {
        var ingredient = IngredientLine.CreateIngredient(description, GetNextOrder());
        _lines.Add(ingredient);
        return ingredient;
    }

    public IngredientLine AddSection(string description)
    {
        var section = IngredientLine.CreateSection(description, GetNextOrder());
        _lines.Add(section);
        return section;
    }

    private int GetNextOrder() => _lines.Count + 1;

    public IEnumerator<IngredientLine> GetEnumerator()
    {
        return _lines.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}