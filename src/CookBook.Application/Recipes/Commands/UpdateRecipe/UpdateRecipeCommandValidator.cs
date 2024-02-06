using CookBook.Core.Recipes;
using FluentValidation;
using Sawnet.Application.Validators;

namespace CookBook.Application.Recipes.Commands.UpdateRecipe;

public class UpdateRecipeCommandValidator : SawnetValidator<UpdateRecipeCommand>
{
    public UpdateRecipeCommandValidator()
    {
        RuleFor(_ => _.Title)
            .NotEmpty()
            .WithError(RecipeErrors.NotHasTitle);

        RuleFor(_ => _.Description)
            .NotEmpty()
            .WithError(RecipeErrors.NotHasDescription);
    }
}