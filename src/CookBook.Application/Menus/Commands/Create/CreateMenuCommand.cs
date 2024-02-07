using CookBook.Core.Menus;
using Sawnet.Application.Cqrs.Commands;
using Sawnet.Core.Results;

namespace CookBook.Application.Menus.Commands.Create;

public record CreateMenuCommand : ICommand<Result<Menu>>
{
    public string Name { get; init; }
}