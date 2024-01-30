using CookBook.Core.Menus;
using CookBook.Core.Menus.ValueObjects;

namespace CookBook.Test;

public class MenuBuilder
{
    private Name _name;

    public static MenuBuilder Create()
    {
        return new MenuBuilder();
    }

    public MenuBuilder SetName(Name name)
    {
        _name = name;
        return this;
    }

    public Menu Build()
    {
        return Menu.Create(MenuId.Create(), _name ?? Name.Create("Summer"));
    }
}