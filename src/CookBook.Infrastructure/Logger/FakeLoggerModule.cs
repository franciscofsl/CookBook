using CookBook.Application.Contracts;
using Microsoft.Extensions.DependencyInjection;
using Sawnet.Core.Modules;

namespace CookBook.Infrastructure.Logger;

public class FakeLoggerModule : SawnetModule
{
    public override void ConfigureCustomServices(IServiceCollection services)
    {
        services.AddSingleton<IFakeLogger, FakeLogger>();
    }
}