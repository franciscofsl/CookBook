using CookBook.Application.Recipes.Queries.GetMyRecipes;
using CookBook.Shared;
using CookBook.Shared.Recipes;
using Microsoft.AspNetCore.Mvc;
using Sawnet.Application.Cqrs.Queries;
using Sawnet.Server;
using Swashbuckle.AspNetCore.Annotations;

namespace CookBook.Blazor.Server.Endpoints.Recipes;

public class GetMyRecipes : BaseAsyncEndpoint.WithoutRequest.WithResponse<IReadOnlyList<RecipeForListDto>>
{
    private readonly IQueryDispatcher _queryDispatcher;

    public GetMyRecipes(IQueryDispatcher queryDispatcher)
    {
        _queryDispatcher = queryDispatcher;
    }

    [SwaggerOperation(
        Summary = "Get my recipes",
        Description = "Get all user recipes",
        OperationId = "Recipe_MyRecipes",
        Tags = new[] { "Recipes" })]
    [HttpGet(ApiRoutes.MyRecipes)]
    public override async Task<ActionResult<IReadOnlyList<RecipeForListDto>>> HandleAsync(CancellationToken cancellationToken = default)
    {
        var myRecipes = await _queryDispatcher.Dispatch(new GetMyRecipesQuery());

        return Ok(myRecipes);
    }
}