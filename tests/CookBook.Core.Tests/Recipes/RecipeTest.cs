using CookBook.Core.Recipes.Events;
using CookBook.Core.Recipes.Records;
using CookBook.Test;

namespace CookBook.Core.Tests.Recipes;

public class RecipeTest
{
    [Fact]
    public void Should_Create_Recipe()
    {
        var id = Guid.Empty;
        var recipe = Recipe.Create(RecipeId.Create(id));

        recipe.Id.Value.Should().Be(id);
        recipe.Title.Should().Be(RecipeTitle.Empty);
        recipe.Description.Should().Be(RecipeDescription.Empty);
        recipe.Ingredients.Should().NotBeNull();
        recipe.PreparationTime.Should().NotBeNull();
    }

    [Fact]
    public void Should_Publish_Recipe()
    {
        var recipe = RecipeBuilder.Create()
            .SetTitle((RecipeTitle)"Title")
            .SetDescription((RecipeDescription)"Description")
            .Build();

        recipe.Ingredients.AddIngredient("Milk");

        recipe.Published.Should().BeFalse();

        recipe.Publish();

        recipe.Published.Should().BeTrue();
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