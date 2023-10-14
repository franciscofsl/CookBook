using Microsoft.Extensions.DependencyInjection;
using Sawnet.Core.Modules;
using Shouldly;

namespace Sawnet.Core.Tests.Modules;

public class ModulesToIncludeTests
{
    [Fact]
    public void Constructor_With_Valid_Module_Types_Creates_Modules_List()
    {
        var moduleType = typeof(TestSawnetModule);

        var attribute = new ModulesToIncludeAttribute(moduleType);

        attribute.Modules.ShouldNotBeNull();
        attribute.Modules.ShouldNotBeEmpty();
    }

    [Fact]
    public void Constructor_With_No_Module_Types_Throws_InvalidOperationException()
    {
        Should.Throw<InvalidOperationException>(() => new ModulesToIncludeAttribute());
    }
    
    [ModulesToInclude(typeof(TestSawnetModule))]
    private class TestSawnetModule : SawnetModule
    {
        public override void ConfigureCustomServices(IServiceCollection services)
        {
            base.ConfigureCustomServices(services);
        }
    }
}