using CookBook.Core.Recipes;
using CookBook.Shared.Recipes;
using Sawnet.Application.Cqrs.Queries;

namespace CookBook.Application.Recipes.Queries.GetMyRecipes;

public class GetMyRecipesCommandHandler : IQueryHandler<GetMyRecipesCommand, IReadOnlyList<RecipeForListDto>>
{
    private readonly IRecipesRepository _recipesRepository;

    public GetMyRecipesCommandHandler(IRecipesRepository recipesRepository)
    {
        _recipesRepository = recipesRepository;
    }

    public async Task<IReadOnlyList<RecipeForListDto>> Handle(GetMyRecipesCommand command,
        CancellationToken cancellationToken = default)
    {
        var myRecipes = await _recipesRepository.GetMyRecipesAsync();

        return myRecipes
            .Select(_ => new RecipeForListDto
            {
                Id = _.Id,
                Title = _.Title
            })
            .ToList();
    }
}