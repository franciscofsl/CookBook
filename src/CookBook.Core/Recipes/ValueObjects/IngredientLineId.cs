namespace CookBook.Core.Recipes.ValueObjects;

public record IngredientLineId : EntityId
{
    private IngredientLineId()
    {
    }

    public static IngredientLineId Create(Guid? value = null)
    {
        return new IngredientLineId
        {
            Value = value ?? Guid.NewGuid()
        };
    }

    public static explicit operator IngredientLineId(Guid id) => Create(id);

    public static implicit operator Guid(IngredientLineId id) => id.Value;
}