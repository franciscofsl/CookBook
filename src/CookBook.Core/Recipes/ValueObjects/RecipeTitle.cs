﻿namespace CookBook.Core.Recipes.ValueObjects;

public sealed class RecipeTitle : ValueObject
{
    private RecipeTitle()
    {
    }

    public static RecipeTitle Create(string title)
    {
        return new RecipeTitle
        {
            Title = GuardClause.NotNullOrEmpty(title, nameof(title))
        };
    }

    public string Title { get; private init; }

    public override IEnumerable<object> GetAtomicValues()
    {
        yield return Title;
    }

    public static implicit operator string(RecipeTitle title) => title.Title;

    public static explicit operator RecipeTitle(string title) => Create(title);
}