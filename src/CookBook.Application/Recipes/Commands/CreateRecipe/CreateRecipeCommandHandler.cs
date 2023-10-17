using CookBook.Core.Recipes;
using CookBook.Core.Recipes.ValueObjects;
using Sawnet.Application.Cqrs.Commands;

namespace CookBook.Application.Recipes.Commands.CreateRecipe;

public class CreateRecipeCommandHandler : ICommandHandler<CreateRecipeCommand, Recipe>
{
    private readonly IRecipesRepository _recipesRepository;

    public CreateRecipeCommandHandler(IRecipesRepository recipesRepository)
    {
        _recipesRepository = recipesRepository;
    }

    public async Task<Recipe> Handle(CreateRecipeCommand command, CancellationToken token = default)
    {
        var recipe = new Recipe((RecipeId)Guid.NewGuid());
        await _recipesRepository.InsertAsync(recipe);
        return recipe;
    }
}