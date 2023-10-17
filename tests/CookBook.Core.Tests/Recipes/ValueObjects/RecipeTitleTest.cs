using CookBook.Core.Recipes.ValueObjects;
using Sawnet.Testing.Extensions;
using Shouldly;

namespace CookBook.Core.Tests.Recipes.ValueObjects;

public class RecipeTitleTest
{
    [Fact]
    public void Should_Create_Recipe_Title()
    {
        const string title = "Recipe Title";

        var recipeTitle = RecipeTitle.Create(title);

        recipeTitle.Title.ShouldBe(title);
    }

    [Fact]
    public void Should_Return_Atomic_Values()
    {
        const string title = "Recipe Title";

        var recipeTitle = RecipeTitle.Create(title);

        foreach (var value in recipeTitle.InvokeGetAtomicValues())
        {
            value.ShouldNotBeNull();
        }
    }

    [Fact]
    public void Should_Throw_Exception_If_Title_Is_Null()
    {
        var exception = Assert.Throws<ArgumentNullException>(() => RecipeTitle.Create(null));
        exception.Message.ShouldContain("title");
    }

    [Fact]
    public void Should_Throw_Exception_If_Title_Is_Empty()
    {
        var exception = Assert.Throws<ArgumentException>(() => RecipeTitle.Create(string.Empty));
        exception.Message.ShouldContain("title");
    }

    [Fact]
    public void Implicit_Conversion_To_String_Should_Return_Title()
    {
        const string titleValue = "Test Recipe";

        string recipeTitle = RecipeTitle.Create(titleValue);

        recipeTitle.ShouldBe(titleValue);
    }

    [Fact]
    public void ExplicitConversionFromString_ShouldCreateRecipeTitle()
    {
        const string titleValue = "Test Recipe";

        var recipeTitle = (RecipeTitle)titleValue;

        recipeTitle.Title.ShouldBe(titleValue);
    }
}