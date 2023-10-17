using CookBook.Application.Recipes.Queries.Get;
using CookBook.Shared;
using CookBook.Shared.Recipes;
using Microsoft.AspNetCore.Mvc;
using Sawnet.Application.Cqrs.Queries;
using Sawnet.Server;
using Swashbuckle.AspNetCore.Annotations;

namespace CookBook.Blazor.Server.Endpoints.Recipes;

public class Get : BaseAsyncEndpoint
    .WithRequest<Guid>
    .WithResponse<RecipeDto>
{
    private readonly IQueryDispatcher _queryDispatcher;

    public Get(IQueryDispatcher queryDispatcher)
    {
        _queryDispatcher = queryDispatcher;
    }

    [SwaggerOperation(
        Summary = "Get a recipe",
        Description = "Get recipe by id",
        OperationId = "Recipe_Get",
        Tags = new[] { "Recipes" })]
    [HttpGet(ApiRoutes.Recipes)]
    public override async Task<ActionResult<RecipeDto>> HandleAsync([FromQuery] Guid recipeId,
        CancellationToken cancellationToken = default)
    {
        var recipeDto = await _queryDispatcher.Dispatch(new GetRecipeQuery(recipeId));

        return Ok(recipeDto);
    }
}