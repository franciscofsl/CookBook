using Microsoft.Extensions.Configuration;

namespace CookBook.Data;

[ExcludeFromCodeCoverage]
[ModulesToInclude(typeof(EfCoreModule))]
public class CookBookDataModule : SawnetModule
{
    public override void ConfigureCustomServices(IServiceCollection services)
    {
        var serviceProvider = services.BuildServiceProvider();
        var configuration = serviceProvider.GetService<IConfiguration>();
        var connectionString = configuration?.GetConnectionString("DefaultConnection");

        if (!string.IsNullOrEmpty(connectionString))
        {
            services.AddDbContext<IDbContext, CookBookDbContext>(opt => opt.UseSqlServer(connectionString));
        }

        services.AddScoped<IRecipesRepository, RecipesRepository>();
    }
}