using CookBook.Application.Recipes.Commands.CreateRecipe;
using CookBook.Shared.Recipes;
using Microsoft.AspNetCore.Mvc;
using Sawnet.Application.Cqrs.Commands;
using Sawnet.Server;

namespace CookBook.Blazor.Server.Endpoints.Recipes;

public class CreateRecipe : BaseAsyncEndpoint.WithRequest<CreateRecipeDto>.WithResponse<RecipeDto>
{
    private readonly ICommandDispatcher _commandDispatcher;

    public CreateRecipe(ICommandDispatcher commandDispatcher)
    {
        _commandDispatcher = commandDispatcher;
    }

    [HttpPost(ApiRoutes.Recipes)]
    public override async Task<ActionResult<RecipeDto>> HandleAsync([FromForm] CreateRecipeDto request,
        CancellationToken cancellationToken = default)
    {
        var recipe = await _commandDispatcher.Dispatch(new CreateRecipeCommand
        {
            Title = request.Title,
            Description = request.Description
        });

        return new RecipeDto
        {
            Title = recipe.Title,
            Description = recipe.Description
        };
    }
}