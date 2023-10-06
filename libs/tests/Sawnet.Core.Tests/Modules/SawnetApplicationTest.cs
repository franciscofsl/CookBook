using Microsoft.Extensions.DependencyInjection;
using Sawnet.Core.Modules;
using Shouldly;

namespace Sawnet.Core.Tests.Modules;

public class SawnetApplicationTest
{
    [Fact]
    public void AddSawnetApplication_Should_Return_Application()
    {
        var serviceCollection = new ServiceCollection();

        var application = serviceCollection.AddSawnetApplication<FakeApplication>();

        application.ShouldNotBeNull();
    }

    [ModulesToInclude(typeof(FakeModule))]
    private class FakeApplication : SawnetApplication
    {
        
    }

    private class FakeModule : SawnetModule
    {
        
    }
}