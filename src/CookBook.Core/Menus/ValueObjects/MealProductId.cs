namespace CookBook.Core.Menus.ValueObjects;

public sealed record MealProductId : EntityId
{
    private MealProductId()
    {
    }

    public static MealProductId Create(Guid? value = default)
    {
        return new MealProductId
        {
            Value = value ?? Guid.NewGuid()
        };
    }

    public static explicit operator MealProductId(Guid id) => Create(id);

    public static implicit operator Guid(MealProductId id) => id.Value;
}