using CookBook.Application.Recipes.Queries.Get;
using CookBook.Core.Recipes.ValueObjects;

namespace CookBook.Application.Tests.Recipes.Queries;

public class GetRecipeQueryTest
{
    private readonly IRecipesRepository _recipesRepository;

    public GetRecipeQueryTest()
    {
        _recipesRepository = _recipesRepository = Substitute.For<IRecipesRepository>();
    }

    [Fact]
    public async Task Should_Get_Recipe()
    {
        var queryHandler = new GetRecipeQueryHandler(_recipesRepository);
        var recipe = RecipeBuilder.Create().Build();

        _recipesRepository.GetAsync(Arg.Any<RecipeId>()).Returns(recipe);

        var queryResult = await queryHandler.Handle(new GetRecipeQuery(recipe.Id));

        queryResult.Id.Should().Be(recipe.Id);
        queryResult.Description.Should().Be(recipe.Description);
        queryResult.Title.Should().Be(recipe.Title);
        queryResult.TotalHours.Should().Be(recipe.PreparationTime?.Hours);
        queryResult.TotalMinutes.Should().Be(recipe.PreparationTime?.Minutes);
    }
}