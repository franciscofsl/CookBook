using Sawnet.Core.Results;

namespace CookBook.Core.Menus;

public static class Errors
{
    public static readonly Error NotHasMealProducts =
        new("Menus.NotHasMealProducts", "The menu must have at least one meal product.");
}