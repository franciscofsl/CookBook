namespace CookBook.Core.Tests.Recipes.ValueObjects;

public class RecipeDescriptionTest
{
    [Fact]
    public void Should_Create_Recipe_Description()
    {
        const string description = "Recipe Description";

        var recipeDescription = RecipeDescription.Create(description);

        recipeDescription.Value.Should().Be(description);
    }

    [Fact]
    public void Should_Return_Atomic_Values()
    {
        const string description = "Recipe Description";

        var recipeDescription = RecipeDescription.Create(description);

        foreach (var value in recipeDescription.InvokeGetAtomicValues())
        {
            value.Should().NotBeNull();
        }
    }

    [Fact]
    public void Should_Throw_Exception_If_Description_Is_Null()
    {
        var exception = Assert.Throws<ArgumentNullException>(() => RecipeDescription.Create(null));
        exception.Message.Should().Contain("description");
    }
    
    [Fact]
    public void Implicit_Conversion_To_String_Should_Return_Description()
    {
        const string descriptionValue = "Test Recipe";

        string recipeDescription = RecipeDescription.Create(descriptionValue);

        recipeDescription.Should().Be(descriptionValue);
    }

    [Fact]
    public void ExplicitConversionFromString_ShouldCreateRecipeDescription()
    {
        const string descriptionValue = "Test Recipe";

        var recipeDescription = (RecipeDescription)descriptionValue;

        recipeDescription.Value.Should().Be(descriptionValue);
    }
}
