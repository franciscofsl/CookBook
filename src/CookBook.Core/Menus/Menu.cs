using CookBook.Core.Menus.ValueObjects;

namespace CookBook.Core.Menus;

public sealed class Menu : AggregateRoot<MenuId>
{
    private Menu()
    {
    }

    public static Menu Create(MenuId id)
    {
        return new Menu
        {
            Id = id
        };
    }
}