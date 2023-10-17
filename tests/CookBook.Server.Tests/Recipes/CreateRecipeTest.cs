// Test only fails in git action

// using System.Net.Http.Json;
// using CookBook.Application.Recipes.Dtos;
// using CookBook.Blazor.Server.Endpoints;
// 
//
// namespace CookBook.Server.Tests.Recipes;
//
// public class CreateRecipeTest : IClassFixture<CookBookTestWebApplication>
// {
//     private readonly HttpClient _client;
//
//     public CreateRecipeTest(CookBookTestWebApplication factory)
//     {
//         _client = factory.CreateClient();
//     }
//
//     [Fact]
//     public async Task Should_Create_Recipe()
//     {
//         var createInput = new CreateRecipeDto
//         {
//             Title = "Recipe title",
//             Description = "Recipe description"
//         };
//
//         var response = await _client.PostAsJsonAsync(ApiRoutes.Recipes, createInput);
//
//         var createdRecipe = await response.Content.ReadFromJsonAsync<RecipeDto>();
//
//         createdRecipe.Title.Should().Be(createInput.Title);
//         createdRecipe.Description.Should().Be(createInput.Description);
//     }
//
//     [Fact]
//     public async Task Should_Write_In_Log_At_Create_Recipe()
//     {
//         var createInput = new CreateRecipeDto
//         {
//             Title = "Recipe title",
//             Description = "Recipe description"
//         };
//
//         await _client.PostAsJsonAsync(ApiRoutes.Recipes, createInput);
//
//         var logResult = await _client.GetFromJsonAsync<List<string>>(ApiRoutes.Logs);
//
//         logResult.ElementAt(0).Should().Be($"The recipe '{createInput.Title}' has been created.");
//     }
// }