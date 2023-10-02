using CookBook.Core.Recipes.ValueObjects;
using Shouldly;

namespace CookBook.Domain.Tests.Recipes;

public class RecipeTest
{
    [Fact]
    public void Should_Create_Recipe()
    {
        var recipeTitle = RecipeTitle.Create("Recipe title");
        var recipeDescription = RecipeDescription.Create("Recipe description");

        var recipe = RecipeBuilder
            .Create()
            .SetTitle(recipeTitle)
            .SetDescription(recipeDescription)
            .Build();
        
        recipe.Title.ShouldBe(recipeTitle);
        recipe.Description.ShouldBe(recipeDescription);
    }

    [Fact]
    public void Should_Not_Create_Recipe_With_Null_Title()
    {
        var exception = Assert.Throws<ArgumentNullException>(() =>
        {
            _ = new Recipe(RecipeId.Create(Guid.NewGuid()), null, null);
        });
        exception.ShouldNotBeNull();
    }

    [Fact]
    public void Should_Not_Create_Recipe_With_Null_Description()
    {
        var exception = Assert.Throws<ArgumentNullException>(() =>
        {
            _ = new Recipe(RecipeId.Create(Guid.NewGuid()), RecipeTitle.Create("Title"), null);
        });
        exception.ShouldNotBeNull();
    }
}