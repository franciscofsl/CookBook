using CookBook.Core.Recipes;
using CookBook.Core.Recipes.ValueObjects;
using Sawnet.Application.Cqrs.Commands;
using Sawnet.Application.Validators;
using Sawnet.Core.Results;

namespace CookBook.Application.Recipes.Commands.UpdateRecipe;

public class UpdateRecipeCommandHandler : ICommandHandler<UpdateRecipeCommand, Result<Recipe>>
{
    private readonly IRecipesRepository _recipesRepository;
    private readonly UpdateRecipeCommandValidator _validator;

    public UpdateRecipeCommandHandler(IRecipesRepository recipesRepository, UpdateRecipeCommandValidator validator)
    {
        _recipesRepository = recipesRepository;
        _validator = validator;
    }

    public async Task<Result<Recipe>> Handle(UpdateRecipeCommand command, CancellationToken token = default)
    {
        var validationResult = await _validator.ValidateAsync(command, token);
        if (!validationResult.IsValid)
        {
            return validationResult.ToFailureResult<Recipe>();
        }

        var recipe = await _recipesRepository.GetAsync(RecipeId.Create(command.RecipeId));

        recipe.Title = RecipeTitle.Create(command.Title);
        recipe.Description = RecipeDescription.Create(command.Description);
        recipe.PreparationTime = PreparationTime.Create(command.Hours, command.Minutes);

        await _recipesRepository.UpdateAsync(recipe);

        return Result.Ok(recipe);
    }
}