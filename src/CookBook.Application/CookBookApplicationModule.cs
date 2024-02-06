using System.Reflection;
using Sawnet.Application;

namespace CookBook.Application;

[ExcludeFromCodeCoverage]
[ModulesToInclude(typeof(CookBookCoreModule))]
public sealed class CookBookApplicationModule : SawnetApplicationModule
{
    protected override IReadOnlyList<Assembly> ValidatorsAssemblies => new[]
    {
        typeof(AssemblyReference).Assembly
    };

    public override void ConfigureCustomServices(IServiceCollection services)
    {
        base.ConfigureCustomServices(services);

        services.AddTransient<IDomainEventHandler<RecipePublished>, RecipePublishedEventHandler>();
    }
}