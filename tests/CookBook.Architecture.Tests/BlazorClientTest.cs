namespace CookBook.Architecture.Tests;

public class BlazorClientTest
{
    [Fact]
    public void Presentation_Should_Not_Have_Dependency_On_Other_Projects()
    {
        var assembly = typeof(Blazor.Client.AssemblyReference).Assembly;

        var otherProjects = new[]
        {
            Namespaces.Infrastructure,
            Namespaces.Core,
            Namespaces.Application,
            Namespaces.Server
        };

        var result = Types
            .InAssembly(assembly)
            .ShouldNot()
            .HaveDependencyOnAny(otherProjects)
            .GetResult();

        result.IsSuccessful.Should().BeTrue();
    }
}