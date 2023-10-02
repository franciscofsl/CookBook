using Microsoft.Extensions.DependencyInjection;
using Sawnet.Core.Events;
using Sawnet.Core.Modules;

namespace Sawnet.Core;

public class DddModule : SawnetModule
{
    public override void ConfigureCustomServices(IServiceCollection services)
    {
        services.AddScoped<IDomainEventPublisher, DomainEventPublisher>(); 
    }
}