namespace CookBook.Data.Tests.Recipes;

public class RecipesRepositoryTest : DataTest
{ 
    public RecipesRepositoryTest(CookBookDbFixture fixture) : base(fixture)
    {
    }

    [Fact]
    public async Task Should_Insert_Recipe()
    {
        var repo = GetRequiredService<IRecipesRepository>();
        await repo.InsertAsync(new Recipe(new RecipeId(Guid.NewGuid())));
    }
}