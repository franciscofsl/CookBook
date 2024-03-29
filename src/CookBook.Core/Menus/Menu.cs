using CookBook.Core.Menus.ValueObjects;
using Sawnet.Core.Results;

namespace CookBook.Core.Menus;

public sealed class Menu : AggregateRoot<MenuId>
{
    private readonly List<MealProduct> _mealProducts = new();

    private Menu()
    {
    }

    public Name Name { get; private set; }

    public IReadOnlyCollection<MealProduct> MealProducts => _mealProducts.AsReadOnly();

    public bool Visible { get; private set; }

    public static Menu Create(MenuId id, Name name)
    {
        return new Menu
        {
            Id = Ensure.NotNull(id, nameof(id)),
            Name = Ensure.NotNull(name, nameof(name))
        };
    }

    public Result Show()
    {
        if (!MealProducts.Any())
        {
            return Result.Failure(Errors.NotHasMealProducts);
        }

        Visible = true;
        return Result.Ok();
    }

    public void Hide()
    {
        Visible = false;
    }

    public void AddMealProduct(MealProduct mealProduct)
    {
        _mealProducts.Add(mealProduct);
    }
}