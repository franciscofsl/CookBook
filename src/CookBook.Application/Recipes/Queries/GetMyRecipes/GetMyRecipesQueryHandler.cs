using CookBook.Core.Recipes;
using CookBook.Shared.Recipes;
using Sawnet.Application.Cqrs.Queries;

namespace CookBook.Application.Recipes.Queries.GetMyRecipes;

public class GetMyRecipesQueryHandler : IQueryHandler<GetMyRecipesQuery, IReadOnlyList<RecipeForListDto>>
{
    private readonly IRecipesRepository _recipesRepository;

    public GetMyRecipesQueryHandler(IRecipesRepository recipesRepository)
    {
        _recipesRepository = recipesRepository;
    }

    public async Task<IReadOnlyList<RecipeForListDto>> Handle(GetMyRecipesQuery query,
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