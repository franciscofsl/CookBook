using CookBook.Application.Recipes.Events;
using CookBook.Core;
using CookBook.Core.Recipes.Events;
using Microsoft.Extensions.DependencyInjection;
using Sawnet.Application.Cqrs;
using Sawnet.Core.Events;
using Sawnet.Core.Modules;

namespace CookBook.Application;

[ModulesToInclude(typeof(CqrsModule),
    typeof(CookBookCoreModule))]
public class CookBookApplicationModule : SawnetModule
{
    public override void ConfigureCustomServices(IServiceCollection services)
    {
        services.AddTransient<IDomainEventHandler<RecipePublished>, RecipePublishedEventHandler>();
    }
}