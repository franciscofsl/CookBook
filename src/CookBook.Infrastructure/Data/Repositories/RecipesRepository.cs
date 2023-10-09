using CookBook.Core.Recipes;
using CookBook.Core.Recipes.ValueObjects;
using Sawnet.Infrastructure.Data;

namespace CookBook.Infrastructure.Data.Repositories;

public class RecipesRepository : EfRepository<Recipe, RecipeId>, IRecipesRepository
{
    public RecipesRepository(IDbContext context)
        : base(context)
    {
    }
}
