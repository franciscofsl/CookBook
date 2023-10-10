using CookBook.Core.Recipes;
using CookBook.Infrastructure.Data.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Sawnet.Core.Modules;
using Sawnet.Infrastructure.Data;

namespace CookBook.Infrastructure.Data;

[ModulesToInclude(typeof(EfCoreModule))]
public class CookBookDataModule : SawnetModule
{
    public override void ConfigureCustomServices(IServiceCollection services)
    {
        var serviceProvider = services.BuildServiceProvider();
        var configuration = serviceProvider.GetRequiredService<IConfiguration>();
        var connectionString = configuration.GetConnectionString("DefaultConnection");
        services.AddDbContext<IDbContext, CookBookDbContext>(opt => opt.UseSqlServer(connectionString));

        services.AddTransient<IRecipesRepository, RecipesRepository>();
    }
}
