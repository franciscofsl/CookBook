using Microsoft.Extensions.DependencyInjection;
using Sawnet.Core.Modules;
using Shouldly;

namespace Sawnet.Core.Tests.Modules;

public class SawnetModuleTest
{
    [Fact]
    public void ConfigureCustomServices_Should_Not_Throw_Exception()
    {
        var module = new TestSawnetModule();

        Should.NotThrow(() => module.ConfigureCustomServices(new ServiceCollection()));
    }

    [Fact]
    public void ConfigureServices_Should_Not_Throw_Exception()
    {
        var module = new TestSawnetModule();

        Should.NotThrow(() => module.ConfigureServices(new ServiceCollection()));
    }

    [Fact]
    public void GetModules_With_Modules_To_Include_Attribute_Returns_Modules()
    {
        var module = new TestSawnetModuleWithAttribute();

        var modules = module.GetModules();

        modules.ShouldNotBeNull();
        modules.ShouldNotBeEmpty();
    }

    [Fact]
    public void ConfigureServices_Should_Not_Throw_Exception_With_Other_Module()
    {
        var module = new TestSawnetModuleWithAttribute();

        Should.NotThrow(() => module.ConfigureServices(new ServiceCollection()));
    }

    [Fact]
    public void GetModules_Without_Modules_To_Include_Attribute_Returns_Empty_List()
    {
        var module = new TestSawnetModule();

        var modules = module.GetModules();

        modules.ShouldBeEmpty();
    }

    private class TestSawnetModule : SawnetModule
    {
    }

    [ModulesToInclude(typeof(TestSawnetModule))]
    private class TestSawnetModuleWithAttribute : SawnetModule
    {
    }
}