namespace CookBook.Application;

[ExcludeFromCodeCoverage]
[ModulesToInclude(typeof(CqrsModule),
    typeof(CookBookCoreModule))]
public class CookBookApplicationModule : SawnetModule
{
    public override void ConfigureCustomServices(IServiceCollection services)
    {
        services.AddTransient<IDomainEventHandler<RecipePublished>, RecipePublishedEventHandler>();
    }
}