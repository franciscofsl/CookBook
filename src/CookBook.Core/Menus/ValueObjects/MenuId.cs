namespace CookBook.Core.Menus.ValueObjects;

public sealed record MenuId : EntityId
{
    private MenuId()
    {
    }

    public static MenuId Create(Guid? value = default)
    {
        return new MenuId
        {
            Value = value ?? Guid.NewGuid()
        };
    }

    public static explicit operator MenuId(Guid id) => Create(id);

    public static implicit operator Guid(MenuId id) => id.Value;
}