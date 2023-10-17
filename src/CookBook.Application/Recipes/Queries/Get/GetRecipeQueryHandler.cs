using CookBook.Core.Recipes;
using CookBook.Core.Recipes.ValueObjects;
using CookBook.Shared.Recipes;
using Sawnet.Application.Cqrs.Queries;

namespace CookBook.Application.Recipes.Queries.Get;

public class GetRecipeQueryHandler : IQueryHandler<GetRecipeQuery, RecipeDto>
{
    private readonly IRecipesRepository _recipesRepository;

    public GetRecipeQueryHandler(IRecipesRepository recipesRepository)
    {
        _recipesRepository = recipesRepository;
    }

    public async Task<RecipeDto> Handle(GetRecipeQuery query, CancellationToken cancellationToken = default)
    {
        var recipeId = (RecipeId)query.RecipeId;
        var recipe = await _recipesRepository.GetAsync(recipeId);

        return new RecipeDto
        {
            Id = recipe.Id,
            Title = recipe.Title,
            Description = recipe.Description,
            TotalHours = recipe.PreparationTime.Hours,
            TotalMinutes = recipe.PreparationTime.Minutes
        };
    }
}