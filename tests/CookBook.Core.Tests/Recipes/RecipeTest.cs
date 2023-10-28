using CookBook.Core.Recipes.Events;
using CookBook.Test;

namespace CookBook.Core.Tests.Recipes;

public class RecipeTest
{
    [Fact]
    public void Should_Publish_Recipe()
    {
        var recipe = RecipeBuilder.Create()
            .SetTitle((RecipeTitle)"Title")
            .SetDescription((RecipeDescription)"Description")
            .Build();

        recipe.Ingredients.AddIngredient("Milk");

        recipe.IsDraft.Should().BeTrue();

        recipe.Publish();

        recipe.IsDraft.Should().BeFalse();
        recipe.Events.Should().Contain(_ => _ is RecipePublished);
    }

    [Fact]
    public void Should_Not_Publish_Recipe_Without_Title()
    {
        var recipe = RecipeBuilder.Create().Build();

        var result = recipe.Publish();

        result.Error.Should().Be(RecipeErrors.NotHasTitle);
    }

    [Fact]
    public void Should_Not_Publish_Recipe_Without_Description()
    {
        var recipe = RecipeBuilder.Create()
            .SetTitle((RecipeTitle)"Title")
            .Build();

        var result = recipe.Publish();

        result.Error.Should().Be(RecipeErrors.NotHasDescription);
    }

    [Fact]
    public void Should_Not_Publish_Recipe_Without_Ingredients()
    {
        var recipe = RecipeBuilder.Create()
            .SetTitle((RecipeTitle)"Title")
            .SetDescription((RecipeDescription)"Description")
            .Build();

        var result = recipe.Publish();

        result.Error.Should().Be(RecipeErrors.NotHasIngredients);
    }
}