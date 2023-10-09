using CookBook.Application.Recipes.Commands.CreateRecipe;
using CookBook.Core.Recipes;
using NSubstitute;
using Shouldly;

namespace CookBook.Application.Tests.Recipes.Commands;

public class CreateRecipeCommandTest
{
    private readonly IRecipesRepository _recipesRepository;

    public CreateRecipeCommandTest()
    {
        _recipesRepository = _recipesRepository = Substitute.For<IRecipesRepository>();
    }

    [Fact]
    public async Task Should_Create_Recipe()
    {
        var command = new CreateRecipeCommand
        {
            Title = "My recipe",
            Description = "My recipe extended",
            Hours = 5,
            Minutes = 4
        };

        var commandHandler = new CreateRecipeCommandHandler(_recipesRepository);

        var result = await commandHandler.Handle(command);

        ((string)result.Title).ShouldBe(command.Title);
        ((string)result.Description).ShouldBe(command.Description);
        result.PreparationTime.Hours.ShouldBe(command.Hours);
        result.PreparationTime.Minutes.ShouldBe(command.Minutes);
    }

    [Fact]
    public async Task Should_Create_Recipe_As_Public()
    {
        var command = new CreateRecipeCommand
        {
            Title = "My recipe",
            Description = "My recipe extended",
            Hours = 5,
            Minutes = 4,
            SaveAsPublic = true
        };

        var commandHandler = new CreateRecipeCommandHandler(_recipesRepository);
        var recipe = await commandHandler.Handle(command);
        recipe.IsDraft.ShouldBeFalse();
    }
}