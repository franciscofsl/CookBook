using Sawnet.Application.Cqrs.Commands;
using Sawnet.Core.Results;

namespace CookBook.Application.Menus.Commands.Show;

public record ShowMenuCommand(Guid MenuId) : ICommand<Result>;