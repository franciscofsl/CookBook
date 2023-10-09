using CookBook.Core.Recipes;
using Sawnet.Application.Cqrs.Commands;

namespace CookBook.Application.Recipes.Commands.CreateRecipe;

public class CreateRecipeCommand : ICommandRequest<Recipe>
{
    public string Title { get; set; }

    public string Description { get; set; }

    public int? Hours { get; set; }

    public int? Minutes { get; set; }
    
    public bool SaveAsPublic { get; set; }
}