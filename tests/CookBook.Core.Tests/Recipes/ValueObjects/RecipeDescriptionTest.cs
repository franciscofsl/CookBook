using CookBook.Core.Recipes.ValueObjects;
using Sawnet.Testing.Extensions;
using Shouldly;

namespace CookBook.Core.Tests.Recipes.ValueObjects;

public class RecipeDescriptionTest
{
    [Fact]
    public void Should_Create_Recipe_Description()
    {
        const string description = "Recipe Description";

        var recipeDescription = RecipeDescription.Create(description);

        recipeDescription.Description.ShouldBe(description);
    }

    [Fact]
    public void Should_Return_Atomic_Values()
    {
        const string description = "Recipe Description";

        var recipeDescription = RecipeDescription.Create(description);

        foreach (var value in recipeDescription.InvokeGetAtomicValues())
        {
            value.ShouldNotBeNull();
        }
    }

    [Fact]
    public void Should_Throw_Exception_If_Description_Is_Null()
    {
        var exception = Assert.Throws<ArgumentNullException>(() => RecipeDescription.Create(null));
        exception.Message.ShouldContain("description");
    }

    [Fact]
    public void Should_Throw_Exception_If_Description_Is_Empty()
    {
        var exception = Assert.Throws<ArgumentException>(() => RecipeDescription.Create(string.Empty));
        exception.Message.ShouldContain("description");
    }

    [Fact]
    public void Implicit_Conversion_To_String_Should_Return_Description()
    {
        const string descriptionValue = "Test Recipe";

        string recipeDescription = RecipeDescription.Create(descriptionValue);

        recipeDescription.ShouldBe(descriptionValue);
    }

    [Fact]
    public void ExplicitConversionFromString_ShouldCreateRecipeDescription()
    {
        const string descriptionValue = "Test Recipe";

        var recipeDescription = (RecipeDescription)descriptionValue;

        recipeDescription.Description.ShouldBe(descriptionValue);
    }
}
