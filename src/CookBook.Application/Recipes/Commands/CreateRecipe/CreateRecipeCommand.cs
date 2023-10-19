using CookBook.Core.Recipes;
using Sawnet.Application.Cqrs.Commands;

namespace CookBook.Application.Recipes.Commands.CreateRecipe;

public record CreateRecipeCommand : ICommand<Recipe>;