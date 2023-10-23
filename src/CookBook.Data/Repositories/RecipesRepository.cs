using CookBook.Core.Recipes.Records;

namespace CookBook.Data.Repositories;

public class RecipesRepository : EfRepository<Recipe, RecipeId>, IRecipesRepository
{
    public RecipesRepository(IDbContext context)
        : base(context)
    {
    }

    public async Task<IReadOnlyList<MyRecipeRecord>> GetMyRecipesAsync()
    {
        var query = await GetQueryableAsync();

        return await query
            .AsNoTracking()
            .Select(_ => new MyRecipeRecord(_.Id, _.Title))
            .ToListAsync();
    }
}