using CookBook.Application.Contracts;

namespace CookBook.Infrastructure.Logger;

public class FakeLoggerModule : SawnetModule
{
    public override void ConfigureCustomServices(IServiceCollection services)
    {
        services.AddSingleton<IFakeLogger, FakeLogger>();
    }
}