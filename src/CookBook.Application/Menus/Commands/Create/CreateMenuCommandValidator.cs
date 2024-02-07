using FluentValidation;
using Sawnet.Application.Validators;

namespace CookBook.Application.Menus.Commands.Create;

public class CreateMenuCommandValidator : SawnetValidator<CreateMenuCommand>
{
    public CreateMenuCommandValidator()
    {
        RuleFor(_ => _.Name).NotEmpty();
    }
}