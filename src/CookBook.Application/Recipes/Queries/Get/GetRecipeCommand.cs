using CookBook.Shared.Recipes;
using Sawnet.Application.Cqrs.Queries;

namespace CookBook.Application.Recipes.Queries.Get;

public record GetRecipeCommand(Guid RecipeId) : IQueryRequest<RecipeDto>;