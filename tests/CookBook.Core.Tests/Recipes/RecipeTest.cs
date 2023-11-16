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
        recipe.Ratings.Should().NotBeNull();
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

    [Fact]
    public void Should_Update_Recipe_Title()
    {
        var recipe = RecipeBuilder.Create().Build();

        var updateInfo = new RecipeUpdateInfo("Title", recipe.Description, null, PreparationTime.MinTimeValue);
        var result = recipe.Update(updateInfo);

        result.Success.Should().BeTrue();
        recipe.Title.Value.Should().Be(updateInfo.Title);
    }

    [Fact]
    public void Should_Update_Recipe_Title_Empty_If_Recipe_Is_Not_Published()
    {
        var recipe = RecipeBuilder.Create().Build();

        var result = recipe.Update(RecipeUpdateInfo.Empty);

        result.Success.Should().BeTrue();
        recipe.Title.Value.Should().BeEmpty();
    }

    [Fact]
    public void Should_Not_Update_Recipe_Title_With_Empty_Value_If_Recipe_Is_Publish()
    {
        var recipe = RecipeBuilder.Create()
            .SetTitle(RecipeTitle.Create("Title"))
            .SetDescription(RecipeDescription.Create("Description"))
            .Build();

        recipe.Ingredients.AddIngredient("Milk");

        recipe.Publish();

        var result = recipe.Update(RecipeUpdateInfo.Empty);

        result.Success.Should().BeFalse();
        result.Error.Should().Be(RecipeErrors.NotHasTitle);
    }

    [Fact]
    public void Should_Update_Recipe_Title_When_Is_Publish()
    {
        var recipe = RecipeBuilder.Create()
            .SetTitle(RecipeTitle.Create("Title"))
            .SetDescription(RecipeDescription.Create("Description"))
            .Build();

        recipe.Ingredients.AddIngredient("Milk");

        recipe.Publish();

        var updateInfo = new RecipeUpdateInfo("New Title", recipe.Description, null, PreparationTime.MinTimeValue);
        var result = recipe.Update(updateInfo);

        result.Success.Should().BeTrue();
        recipe.Title.Value.Should().Be(updateInfo.Title);
    }

    [Fact]
    public void Should_Update_Recipe_Description()
    {
        var recipe = RecipeBuilder.Create().Build();

        var recipeInfo = new RecipeUpdateInfo(recipe.Title, "New Description", null, PreparationTime.MinTimeValue);
        var result = recipe.Update(recipeInfo);

        result.Success.Should().BeTrue();
        recipe.Description.Value.Should().Be(recipeInfo.Description);
    }

    [Fact]
    public void Should_Update_Recipe_Description_Empty_If_Recipe_Is_Not_Published()
    {
        var recipe = RecipeBuilder.Create().Build();

        var result = recipe.Update(RecipeUpdateInfo.Empty);

        result.Success.Should().BeTrue();
        recipe.Description.IsEmpty().Should().BeTrue();
    }

    [Fact]
    public void Should_Not_Update_Recipe_Description_With_Empty_Value_If_Recipe_Is_Publish()
    {
        var recipe = RecipeBuilder.Create()
            .SetTitle(RecipeTitle.Create("Title"))
            .SetDescription(RecipeDescription.Create("Description"))
            .Build();

        recipe.Ingredients.AddIngredient("Milk");

        recipe.Publish();

        var result = recipe.Update(new RecipeUpdateInfo(recipe.Title, null, null, PreparationTime.MinTimeValue));

        result.Success.Should().BeFalse();
        result.Error.Should().Be(RecipeErrors.NotHasDescription);
    }

    [Fact]
    public void Should_Update_Recipe_Description_When_Is_Publish()
    {
        var recipe = RecipeBuilder.Create()
            .SetTitle(RecipeTitle.Create("Title"))
            .SetDescription(RecipeDescription.Create("Description"))
            .Build();

        recipe.Ingredients.AddIngredient("Milk");

        recipe.Publish();

        var result =
            recipe.Update(new RecipeUpdateInfo(recipe.Title, "New description", null, PreparationTime.MinTimeValue));

        result.Success.Should().BeTrue();
        recipe.Description.Value.Should().Be("New description");
    }
}