using CookBook.Core.Recipes;
using CookBook.Core.Recipes.ValueObjects;
using CookBook.Shared.Recipes;
using Sawnet.Application.Cqrs.Queries;

namespace CookBook.Application.Recipes.Queries.Get;

public class GetRecipeCommandHandler : IQueryHandler<GetRecipeCommand, RecipeDto>
{
    private readonly IRecipesRepository _recipesRepository;

    public GetRecipeCommandHandler(IRecipesRepository recipesRepository)
    {
        _recipesRepository = recipesRepository;
    }

    public async Task<RecipeDto> Handle(GetRecipeCommand command, CancellationToken cancellationToken = default)
    {
        var recipeId = RecipeId.Create(command.RecipeId);
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