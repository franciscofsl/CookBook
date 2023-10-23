using FluentAssertions;

namespace CookBook.Data.Tests.Recipes;

public class RecipesRepositoryTest : DataTest
{
    public RecipesRepositoryTest(CookBookDbFixture fixture) : base(fixture)
    {
    }

    [Fact]
    public async Task Should_Insert_Recipe()
    {
        var repository = GetRequiredService<IRecipesRepository>();
        var recipe = await repository.InsertAsync(new Recipe(new RecipeId(Guid.NewGuid())));
        recipe.Should().NotBeNull();
    }

    [Fact]
    public async Task Should_Delete_Recipe()
    {
        var repository = GetRequiredService<IRecipesRepository>();

        var recipe = await repository.InsertAsync(new Recipe(new RecipeId(Guid.NewGuid()))
        {
            Title = (RecipeTitle)"Title"
        });

        await repository.DeleteAsync(recipe);

        var deletedRecipe = await repository.GetAsync(recipe.Id);

        deletedRecipe.Should().BeNull();
    }
}