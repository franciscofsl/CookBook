using CookBook.Test;
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
        var recipe = await repository.InsertAsync(Recipe.Create(RecipeId.Create(Guid.NewGuid())));
        recipe.Should().NotBeNull();
    }

    [Fact]
    public async Task Should_Delete_Recipe()
    {
        var repository = GetRequiredService<IRecipesRepository>();

        var recipe = await repository.InsertAsync(Recipe.Create(RecipeId.Create(Guid.NewGuid())));

        await repository.DeleteAsync(recipe);

        var deletedRecipe = await repository.GetAsync(recipe.Id);

        deletedRecipe.Should().BeNull();
    }

    [Fact]
    public async Task Should_Get_My_Recipes()
    {
        var repository = GetRequiredService<IRecipesRepository>();

        var recipe = RecipeBuilder
            .Create()
            .SetTitle((RecipeTitle)"Title")
            .SetDescription((RecipeDescription)"Description")
            .SetPreparationTime(4, 6)
            .Build();

        await repository.InsertAsync(recipe);

        var myRecipes = await repository.GetMyRecipesAsync();

        myRecipes.Should().HaveCountGreaterOrEqualTo(1);

        var createdRecipe = myRecipes.First(_ => _.Id == recipe.Id);

        createdRecipe.Title.Should().Be(recipe.Title);
    }
}