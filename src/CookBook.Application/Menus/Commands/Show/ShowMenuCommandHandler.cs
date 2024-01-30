using CookBook.Core.Menus;
using CookBook.Core.Menus.ValueObjects;
using Sawnet.Application.Cqrs.Commands;
using Sawnet.Core.Results;

namespace CookBook.Application.Menus.Commands.Show;

public sealed class ShowMenuCommandHandler : ICommandHandler<ShowMenuCommand, Result>
{
    private readonly IMenusRepository _menusRepository;

    public ShowMenuCommandHandler(IMenusRepository menusRepository)
    {
        _menusRepository = menusRepository;
    }

    public async Task<Result> Handle(ShowMenuCommand command, CancellationToken token = default)
    {
        var menu = await _menusRepository.GetAsync(MenuId.Create(command.MenuId));

        var result = menu.Show();

        if (result.IsFailure)
        {
            return result;
        }

        await _menusRepository.UpdateAsync(menu);

        return Result.Ok();
    }
}