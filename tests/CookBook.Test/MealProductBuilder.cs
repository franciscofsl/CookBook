using CookBook.Core.Common.ValueObjects;
using CookBook.Core.Menus;
using CookBook.Core.Menus.ValueObjects;
using CookBook.Core.Recipes.ValueObjects;

namespace CookBook.Test;

public class MealProductBuilder
{
    private Name _name;
    private Price _price;
    private RecipeId _associatedRecipeId;
    private string _description;

    public static MealProductBuilder Create()
    {
        return new MealProductBuilder();
    }

    public MealProductBuilder SetName(Name name)
    {
        _name = name;
        return this;
    }

    public MealProductBuilder SetPrice(Price price)
    {
        _price = price;
        return this;
    }

    public MealProductBuilder SetAssociatedRecipeId(RecipeId associatedRecipeId)
    {
        _associatedRecipeId = associatedRecipeId;
        return this;
    }

    public MealProductBuilder SetDescription(string description)
    {
        _description = description;
        return this;
    }

    public MealProduct Build()
    {
        return MealProduct.Create(
            MealProductId.Create(), 
            _name ?? Name.Create("DefaultName"),
            _price ?? Price.Create(0.0m, Tax.Create(21)),  // Provide a default value if not set
            _associatedRecipeId ?? RecipeId.Create(),  // Provide a default value if not set
            _description
        );
    }
}