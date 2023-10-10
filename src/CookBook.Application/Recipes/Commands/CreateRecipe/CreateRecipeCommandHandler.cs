using CookBook.Core.Recipes;
using CookBook.Core.Recipes.ValueObjects;
using Sawnet.Application.Cqrs.Commands;

namespace CookBook.Application.Recipes.Commands.CreateRecipe;

public class CreateRecipeCommandHandler : ICommandHandler<CreateRecipeCommand, Recipe>
{
    private readonly IRecipesRepository _recipesRepository;

    public CreateRecipeCommandHandler(IRecipesRepository recipesRepository)
    {
        _recipesRepository = recipesRepository;
    }

    public async Task<Recipe> Handle(CreateRecipeCommand command, CancellationToken token = default)
    {
        var title = RecipeTitle.Create(command.Title);
        var description = RecipeDescription.Create(command.Description);
        var recipe = new Recipe(RecipeId.Create(Guid.NewGuid()), title, description)
        {
            PreparationTime = PreparationTime.Create(command.Hours, command.Minutes)
        };
  
        if (command.SaveAsPublic)
        {
            recipe.Publish();
        }
        
        await _recipesRepository.InsertAsync(recipe);

        return recipe;
    }
}