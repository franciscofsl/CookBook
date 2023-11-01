using CookBook.Core.Recipes;
using Sawnet.Application.Cqrs.Commands;
using Sawnet.Core.Results;

namespace CookBook.Application.Recipes.Commands.UpdateRecipe;

public record UpdateRecipeCommand(Guid RecipeId, string Title, string Description, int? Hours, int Minutes)
    : ICommand<Result<Recipe>>;