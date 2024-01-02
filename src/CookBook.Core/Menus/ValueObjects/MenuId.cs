namespace CookBook.Core.Menus.ValueObjects;

public record MenuId : EntityId
{
    private MenuId()
    {
    }

    public static MenuId Create(Guid value)
    {
        return new MenuId
        {
            Value = value
        };
    }

    public static explicit operator MenuId(Guid id) => Create(id);

    public static implicit operator Guid(MenuId id) => id.Value;
}