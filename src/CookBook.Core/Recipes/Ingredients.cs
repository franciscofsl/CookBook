using System.Collections;
using CookBook.Core.Recipes.Entities;

namespace CookBook.Core.Recipes;

public sealed class Ingredients : IEnumerable<Ingredient>
{
    private readonly List<Ingredient> _lines = new();

    public static Ingredients Empty => new();

    private Ingredients()
    {
    } 

    public Ingredient AddIngredient(string description)
    {
        var ingredient = Ingredient.CreateIngredient(description, GetNextOrder());
        _lines.Add(ingredient);
        return ingredient;
    }

    public Ingredient AddSection(string description)
    {
        var section = Ingredient.CreateSection(description, GetNextOrder());
        _lines.Add(section);
        return section;
    }

    private int GetNextOrder() => _lines.Count + 1;

    public IEnumerator<Ingredient> GetEnumerator()
    {
        return _lines.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}