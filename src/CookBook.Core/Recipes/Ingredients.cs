﻿using CookBook.Core.Recipes.Enums;
using CookBook.Core.Recipes.ValueObjects;

namespace CookBook.Core.Recipes;

public class Ingredients : ValueObject
{
    private readonly List<IngredientLine> _lines = new();

    public Ingredients()
    {
    }

    public virtual IReadOnlyCollection<IngredientLine> Lines => _lines.AsReadOnly();

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

    public override IEnumerable<object> GetAtomicValues()
    {
        return _lines;
    }
}