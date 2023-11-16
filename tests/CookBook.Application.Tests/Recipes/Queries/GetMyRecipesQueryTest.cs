using CookBook.Application.Recipes.Queries.GetMyRecipes;
using CookBook.Core.Recipes.Records;

namespace CookBook.Application.Tests.Recipes.Queries;

public class GetMyRecipesQueryTest
{
    private readonly IRecipesRepository _recipesRepository;

    public GetMyRecipesQueryTest()
    {
        _recipesRepository = _recipesRepository = Substitute.For<IRecipesRepository>();
    }

    [Fact]
    public async Task Should_Get_My_Recipes()
    {
        var queryHandler = new GetMyRecipesQueryHandler(_recipesRepository);
        var recipe = RecipeBuilder.Create().Build();

        _recipesRepository.GetMyRecipesAsync().Returns(new List<MyRecipeRecord>()
        {
            new(recipe.Id, recipe.Title)
        });

        var queryResult = await queryHandler.Handle(new GetMyRecipesQuery());

        queryResult.Should().HaveCount(1);
    }
}