using CookBook.Application.Recipes.Dtos;
using CookBook.Blazor.Server.Endpoints;
using Shouldly;
using System.Net.Http.Json;

namespace CookBook.Server.Tests.Recipes;

public class CreateRecipeTest : IClassFixture<CookBookTestWebApplication>
{
    private readonly HttpClient _client;

    public CreateRecipeTest(CookBookTestWebApplication factory)
    {
        _client = factory.CreateClient();
    }

    [Fact]
    public async Task Should_Create_Recipe()
    {
        var createInput = new CreateRecipeDto
        {
            Title = "Recipe title",
            Description = "Recipe description"
        };

        var response = await _client.PostAsJsonAsync(ApiRoutes.Recipes, createInput);

        var createdRecipe = await response.Content.ReadFromJsonAsync<RecipeDto>();

        createdRecipe.Title.ShouldBe(createInput.Title);
        createdRecipe.Description.ShouldBe(createInput.Description);
    }
}