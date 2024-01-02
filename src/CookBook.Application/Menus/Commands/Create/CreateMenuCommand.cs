using CookBook.Core.Menus;
using Sawnet.Application.Cqrs.Commands;

namespace CookBook.Application.Menus.Commands.Create;

public record CreateMenuCommand : ICommand<Menu>;