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
        var commandHandler = new CreateRecipeCommandHandler(_recipesRepository);

        var result = await commandHandler.Handle(new CreateRecipeCommand());
        result.Published.Should().BeFalse();
    }
}