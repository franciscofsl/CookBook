namespace CookBook.Core.Tests.Recipes.ValueObjects;

public class RecipeIdTest
{
    [Fact]
    public void Create_With_Valid_Id_Should_Create_RecipeId()
    {
        var id = Guid.NewGuid();

        var recipeId = (RecipeId)id;

        recipeId.Should().NotBeNull();
        ((Guid)recipeId).Should().Be(id);
    }

    [Fact]
    public void ExplicitOperator_With_Valid_Guid_Should_Create_RecipeId()
    {
        var id = Guid.NewGuid();

        var recipeId = (RecipeId)id;

        recipeId.Should().NotBeNull();
        ((Guid)recipeId).Should().Be(id);
    }
}