using Sawnet.Core.BaseTypes;

namespace CookBook.Architecture.Tests;

public class CoreTest
{
    [Fact]
    public void Core_Should_Not_Have_Dependency_Of_Other_Projects()
    {
        var assembly = typeof(Core.AssemblyReference).Assembly;

        var otherProjects = new[]
        {
            Namespaces.Application,
            Namespaces.Infrastructure,
            Namespaces.Presentation,
            Namespaces.Server
        };

        var result = Types
            .InAssembly(assembly)
            .ShouldNot()
            .HaveDependencyOnAny(otherProjects)
            .GetResult();

        result.IsSuccessful.Should().BeTrue();
    }

    [Fact]
    public void All_Value_Objects_Should_Be_Sealed_Records()
    {
        var assembly = typeof(Core.AssemblyReference).Assembly;

        var result = Types
            .InAssembly(assembly)
            .That()
            .Inherit(typeof(ValueObject))
            .Should()
            .BeSealed()
            .GetResult();

        result.IsSuccessful.Should().BeTrue();
    }
}