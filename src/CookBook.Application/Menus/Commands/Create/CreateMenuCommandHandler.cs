using CookBook.Core.Menus;
using CookBook.Core.Menus.ValueObjects;
using Sawnet.Application.Cqrs.Commands;
using Sawnet.Application.Validators;
using Sawnet.Core.Results;

namespace CookBook.Application.Menus.Commands.Create;

public class CreateMenuCommandHandler : ICommandHandler<CreateMenuCommand, Result<Menu>>
{
    private readonly IMenusRepository _menusRepository;
    private readonly CreateMenuCommandValidator _createMenuCommandValidator;

    public CreateMenuCommandHandler(IMenusRepository menusRepository,
        CreateMenuCommandValidator createMenuCommandValidator)
    {
        _menusRepository = menusRepository;
        _createMenuCommandValidator = createMenuCommandValidator;
    }

    public async Task<Result<Menu>> Handle(CreateMenuCommand command, CancellationToken token = default)
    {
        var validationResult = await _createMenuCommandValidator.ValidateAsync(command, token);
        if (!validationResult.IsValid)
        {
            return validationResult.ToFailureResult<Menu>();
        }

        var menu = Menu.Create(MenuId.Create(), Name.Create(command.Name));

        await _menusRepository.InsertAsync(menu);

        return Result.Ok(menu);
    }
}