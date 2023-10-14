using CookBook.Shared.Recipes;
using Sawnet.Application.Cqrs.Queries;

namespace CookBook.Application.Recipes.Queries.GetMyRecipes;

public record GetMyRecipesCommand : IQueryRequest<IReadOnlyList<RecipeForListDto>>;