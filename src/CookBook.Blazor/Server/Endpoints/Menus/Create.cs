using CookBook.Application.Menus.Commands.Create;
using CookBook.Core.Menus;
using CookBook.Core.Recipes;
using CookBook.Shared;
using CookBook.Shared.Menus;
using Microsoft.AspNetCore.Mvc;
using Sawnet.Application.Cqrs.Commands;
using Sawnet.Server;
using Swashbuckle.AspNetCore.Annotations;

namespace CookBook.Blazor.Server.Endpoints.Menus;

public class Create : BaseAsyncEndpoint.WithRequest<CreateMenuDto>.WithResponse<MenuDto>
{
    private readonly ICommandDispatcher _commandDispatcher;

    public Create(ICommandDispatcher commandDispatcher)
    {
        _commandDispatcher = commandDispatcher;
    }
    
    [SwaggerOperation(
        Summary = "Create menu", 
        OperationId = "Menu_Create",
        Tags = new[] { "Menus" })]
    [HttpPost(ApiRoutes.Menus)]
    public override async Task<ActionResult<MenuDto>> HandleAsync([FromForm]CreateMenuDto createMenu,
        CancellationToken cancellationToken = new CancellationToken())
    {
        var result = await _commandDispatcher.Dispatch(new CreateMenuCommand
        {
            Name = createMenu.Name
        });
        if (result.Success)
        {
            return ToDto(result.Value);
        }

        return BadRequest(RecipeErrors.NotHasDescription);
    }

    private MenuDto ToDto(Menu menu)
    {
        return new MenuDto
        {
            Id = menu.Id,
            Name = menu.Name
        };
    }
}