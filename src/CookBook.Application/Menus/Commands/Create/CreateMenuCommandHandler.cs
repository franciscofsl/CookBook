using CookBook.Core.Menus;
using CookBook.Core.Menus.ValueObjects;
using Sawnet.Application.Cqrs.Commands;
using Sawnet.Application.Validators;
using Sawnet.Core.Results;

namespace CookBook.Application.Menus.Commands.Create;

public class CreateMenuCommandHandler : ICommandHandler<CreateMenuCommand, Result<Menu>>
{
    private readonly IMenusRepository _menusRepository;

    public CreateMenuCommandHandler(IMenusRepository menusRepository)
    {
        _menusRepository = menusRepository;
    }

    public async Task<Result<Menu>> Handle(CreateMenuCommand command, CancellationToken token = default)
    {
        var menu = Menu.Create(MenuId.Create(), Name.Create(command.Name));

        await _menusRepository.InsertAsync(menu);

        return Result.Ok(menu);
    }
}