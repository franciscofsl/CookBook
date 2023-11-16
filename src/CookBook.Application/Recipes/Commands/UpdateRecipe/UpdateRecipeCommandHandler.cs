using CookBook.Core.Recipes;
using CookBook.Core.Recipes.Records;
using CookBook.Core.Recipes.ValueObjects;
using Sawnet.Application.Cqrs.Commands;
using Sawnet.Core.Results;

namespace CookBook.Application.Recipes.Commands.UpdateRecipe;

public class UpdateRecipeCommandHandler : ICommandHandler<UpdateRecipeCommand, Result<Recipe>>
{
    private readonly IRecipesRepository _recipesRepository;

    public UpdateRecipeCommandHandler(IRecipesRepository recipesRepository)
    {
        _recipesRepository = recipesRepository;
    }

    public async Task<Result<Recipe>> Handle(UpdateRecipeCommand command, CancellationToken token = default)
    {
        var recipe = await _recipesRepository.GetAsync(RecipeId.Create(command.RecipeId));

        var result = recipe
            .Update(new RecipeUpdateInfo(command.Title, command.Description, command.Hours, command.Minutes));

        return result.Success
            ? Result.Ok(recipe)
            : Result.Failure<Recipe>(result.Error);
    }
}