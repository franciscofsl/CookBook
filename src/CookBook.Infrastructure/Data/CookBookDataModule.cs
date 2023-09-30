using CookBook.Core.Recipes;
using CookBook.Infrastructure.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Sawnet.Core.Modules;
using Sawnet.Infrastructure.Data;

namespace CookBook.Infrastructure.Data;

[ModulesToInclude(typeof(EfCoreModule))]
public class CookBookDataModule : SawnetModule
{
    public override void ConfigureCustomServices(IServiceCollection services)
    {
        services.AddDbContext<IDbContext, CookBookDbContext>(opt => opt.UseInMemoryDatabase("InMemoryDb"));
        services.AddTransient<IRecipesRepository, RecipesRepository>();
    }
}
