using CookBook.Core.Recipes.ValueObjects;

namespace CookBook.Core.Recipes.Records;

public record RecipeUpdateInfo
{
    public static readonly RecipeUpdateInfo Empty = new(string.Empty, string.Empty, null, PreparationTime.MinTimeValue);

    public RecipeUpdateInfo(string title, string description, int? hours, int minutes)
    {
        Title = title ?? string.Empty;
        Description = description ?? string.Empty;
        Hours = hours;
        Minutes = minutes;
    }

    public string Title { get; }

    public string Description { get; }

    public int? Hours { get; }

    public int Minutes { get; }
}