using System.Collections;
using CookBook.Core.Common.ValueObjects;
using CookBook.Core.Menus.ValueObjects;
using CookBook.Core.Recipes.ValueObjects;
using Sawnet.Core.Results;

namespace CookBook.Core.Menus;

public class MealProducts : IEnumerable<MealProduct>
{
    public static MealProducts Empty = new();

    private readonly HashSet<MealProduct> _mealProducts = new();

    public void Add(MealProduct mealProduct)
    {
        Ensure.NotNull(mealProduct, nameof(mealProduct));

        _mealProducts.Add(mealProduct);
    }

    public void Remove(MealProductId mealProductId)
    {
        _mealProducts.RemoveWhere(_ => _.Id == mealProductId);
    }

    public IEnumerator<MealProduct> GetEnumerator()
    {
        return _mealProducts.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}