using CookBook.Core.Menus;
using CookBook.Core.Menus.ValueObjects;
using Sawnet.Application.Cqrs.Commands;

namespace CookBook.Application.Menus.Commands.Create;

public class CreateMenuCommandHandler : ICommandHandler<CreateMenuCommand, Menu>
{
    private readonly IMenusRepository _menusRepository;

    public CreateMenuCommandHandler(IMenusRepository menusRepository)
    {
        _menusRepository = menusRepository;
    }

    public async Task<Menu> Handle(CreateMenuCommand command, CancellationToken token = default)
    {
        var menu = Menu.Create((MenuId)Guid.NewGuid());

        await _menusRepository.InsertAsync(menu);
        
        return menu;
    }
}