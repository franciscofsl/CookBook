using System.Net.Http.Json;
using System.Text.Json;
using CookBook.Shared;
using CookBook.Shared.Recipes;

namespace CookBook.Blazor.Client.Clients.Recipes;

public class RecipesClient
{
    private readonly HttpClient _client;

    public RecipesClient(HttpClient client)
    {
        _client = client;
    }

    public async Task<RecipeDto> CreateAsync()
    {
        var response = await _client.PostAsJsonAsync(ApiRoutes.Recipes, new CreateRecipeDto());

        return await response.Content.ReadFromJsonAsync<RecipeDto>();
    }

    public async Task<IReadOnlyList<RecipeForListDto>> GetMyRecipesAsync()
    {
        return await _client.GetFromJsonAsync<IReadOnlyList<RecipeForListDto>>(ApiRoutes.MyRecipes);
    }

    public async Task<RecipeDto> GetAsync(Guid recipeId)
    {
        return await _client.GetFromJsonAsync<RecipeDto>(ApiRoutes.RecipeById(recipeId));
    }
}