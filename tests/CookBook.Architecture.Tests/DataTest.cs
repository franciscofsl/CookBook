using System.Diagnostics.CodeAnalysis;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Migrations;
using Sawnet.Core.Contracts;

namespace CookBook.Architecture.Tests;

public class DataTest
{
    [Fact]
    public void IRepository_Implementations_Should_End_With_Repository()
    {
        var assembly = typeof(Data.AssemblyReference).Assembly;

        var result = Types
            .InAssembly(assembly)
            .That()
            .ImplementInterface(typeof(IRepository<,>))
            .Should()
            .HaveNameEndingWith("Repository")
            .GetResult();

        Assert.True(result.IsSuccessful);
    }

    [Fact]
    public void EF_Migrations_Should_Be_Excluded_From_Code_Coverage()
    {
        var assembly = typeof(Data.AssemblyReference).Assembly;

        var result = Types
            .InAssembly(assembly)
            .That()
            .Inherit(typeof(Migration))
            .Should()
            .HaveCustomAttribute(typeof(ExcludeFromCodeCoverageAttribute))
            .GetResult();

        result.IsSuccessful.Should().BeTrue();
    }

    [Fact]
    public void EF_Snapshot_Should_Be_Excluded_From_Code_Coverage()
    {
        var assembly = typeof(Data.AssemblyReference).Assembly;

        var result = Types
            .InAssembly(assembly)
            .That()
            .Inherit(typeof(ModelSnapshot))
            .Should()
            .HaveCustomAttribute(typeof(ExcludeFromCodeCoverageAttribute))
            .GetResult();

        result.IsSuccessful.Should().BeTrue();
    }
}