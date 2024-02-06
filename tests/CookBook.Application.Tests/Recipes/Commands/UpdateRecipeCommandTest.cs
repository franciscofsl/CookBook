using CookBook.Application.Recipes.Commands.UpdateRecipe;
using CookBook.Core.Recipes.ValueObjects;

namespace CookBook.Application.Tests.Recipes.Commands;

public class UpdateRecipeCommandTest
{
    private readonly IRecipesRepository _recipesRepository;

    public UpdateRecipeCommandTest()
    {
        _recipesRepository = _recipesRepository = Substitute.For<IRecipesRepository>();
    }

    [Fact]
    public async Task Should_Not_Update_Recipe_Title_With_Empty_Value_If_Recipe_Is_Publish()
    {
        var recipe = RecipeBuilder.Create()
            .SetTitle(RecipeTitle.Create("Title"))
            .SetDescription(RecipeDescription.Create("Description"))
            .Build();

        recipe.Ingredients.AddIngredient("Milk");

        recipe.Publish();

        _recipesRepository.GetAsync(Arg.Any<RecipeId>()).Returns(recipe);

        var handler = new UpdateRecipeCommandHandler(_recipesRepository, new UpdateRecipeCommandValidator());
        var command = new UpdateRecipeCommand(recipe.Id, string.Empty, null, null, PreparationTime.MinTimeValue);
        var result = await handler.Handle(command);

        result.Success.Should().BeFalse();
        result.Error.Should().Be(RecipeErrors.NotHasTitle);
    }

    [Fact]
    public async Task Should_Update_Recipe_Title_When_Is_Publish()
    {
        var recipe = RecipeBuilder.Create()
            .SetTitle(RecipeTitle.Create("Title"))
            .SetDescription(RecipeDescription.Create("Description"))
            .Build();

        recipe.Ingredients.AddIngredient("Milk");

        recipe.Publish();

        _recipesRepository.GetAsync(Arg.Any<RecipeId>()).Returns(recipe);

        var handler = new UpdateRecipeCommandHandler(_recipesRepository, new UpdateRecipeCommandValidator());
        var command = new UpdateRecipeCommand(recipe.Id, "New Title", recipe.Description, null,
            PreparationTime.MinTimeValue);
        var result = await handler.Handle(command);

        result.Success.Should().BeTrue();
        recipe.Title.Value.Should().Be(command.Title);
    }

    [Fact]
    public async Task Should_Update_Recipe_Description()
    {
        var recipe = RecipeBuilder.Create().Build();
        _recipesRepository.GetAsync(Arg.Any<RecipeId>()).Returns(recipe);

        var handler = new UpdateRecipeCommandHandler(_recipesRepository, new UpdateRecipeCommandValidator());
        var command = new UpdateRecipeCommand(recipe.Id, "Title", "Description", null, PreparationTime.MinTimeValue);
        var result = await handler.Handle(command);

        result.Success.Should().BeTrue();
        recipe.Description.Value.Should().Be(command.Description);
    }

    [Fact]
    public async Task Should_Update_Recipe_Description_When_Is_Publish()
    {
        var recipe = RecipeBuilder.Create()
            .SetTitle(RecipeTitle.Create("Title"))
            .SetDescription(RecipeDescription.Create("Description"))
            .Build();

        recipe.Ingredients.AddIngredient("Milk");

        recipe.Publish();

        _recipesRepository.GetAsync(Arg.Any<RecipeId>()).Returns(recipe);

        var handler = new UpdateRecipeCommandHandler(_recipesRepository, new UpdateRecipeCommandValidator());
        var command = new UpdateRecipeCommand(recipe.Id, recipe.Title, "New description", null,
            PreparationTime.MinTimeValue);
        var result = await handler.Handle(command);

        result.Success.Should().BeTrue();
        recipe.Description.Value.Should().Be(command.Description);
    }
}