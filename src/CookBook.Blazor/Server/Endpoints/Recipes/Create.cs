using CookBook.Application.Recipes.Commands.CreateRecipe;
using CookBook.Shared;
using CookBook.Shared.Recipes;
using Microsoft.AspNetCore.Mvc;
using Sawnet.Application.Cqrs.Commands;
using Sawnet.Server;
using Swashbuckle.AspNetCore.Annotations;

namespace CookBook.Blazor.Server.Endpoints.Recipes;

public class Create : BaseAsyncEndpoint.WithRequest<CreateRecipeDto>.WithResponse<RecipeDto>
{
    private readonly ICommandDispatcher _commandDispatcher;

    public Create(ICommandDispatcher commandDispatcher)
    {
        _commandDispatcher = commandDispatcher;
    }
    
    [SwaggerOperation(
        Summary = "Create recipe",
        Description = "Create a empty recipe",
        OperationId = "Recipe_Create",
        Tags = new[] { "Recipes" })]
    [HttpPost(ApiRoutes.Recipes)]
    public override async Task<ActionResult<RecipeDto>> HandleAsync([FromForm] CreateRecipeDto recipeId,
        CancellationToken cancellationToken = default)
    {
        var recipe = await _commandDispatcher.Dispatch(new CreateRecipeCommand());

        return new RecipeDto
        {
            Id = recipe.Id
        };
    }
}