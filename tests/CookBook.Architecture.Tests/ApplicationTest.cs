namespace CookBook.Architecture.Tests;

public class ApplicationTest
{
    [Fact]
    public void Application_Should_Not_Have_Dependency_On_Other_Projects()
    {
        var assembly = typeof(Application.AssemblyReference).Assembly;

        var otherProjects = new[]
        {
            Namespaces.Infrastructure,
            Namespaces.Presentation,
            Namespaces.Server
        };

        var testResult = Types
            .InAssembly(assembly)
            .ShouldNot()
            .HaveDependencyOnAny(otherProjects)
            .GetResult();

        testResult.IsSuccessful.Should().BeTrue();
    }

    #region Commands

    [Fact]
    public void ICommand_Implementations_Should_End_With_Command()
    {
        var assembly = typeof(Application.AssemblyReference).Assembly;

        var result = Types
            .InAssembly(assembly)
            .That()
            .ImplementInterface(typeof(ICommand<>))
            .Should()
            .HaveNameEndingWith("Command")
            .GetResult();

        result.FailingTypeNames.Should().BeNullOrEmpty();
    }

    [Fact]
    public void ICommandHandler_Implementations_Should_End_With_CommandHandler()
    {
        var assembly = typeof(Application.AssemblyReference).Assembly;

        var result = Types
            .InAssembly(assembly)
            .That()
            .ImplementInterface(typeof(ICommandHandler<,>))
            .Should()
            .HaveNameEndingWith("CommandHandler")
            .GetResult();

        result.FailingTypeNames.Should().BeNullOrEmpty();
    }

    #endregion

    #region Queries

    [Fact]
    public void IQuery_Implementations_Should_End_With_Query()
    {
        var assembly = typeof(Application.AssemblyReference).Assembly;

        var result = Types
            .InAssembly(assembly)
            .That()
            .ImplementInterface(typeof(IQuery<>))
            .Should()
            .HaveNameEndingWith("Query")
            .GetResult();

        result.FailingTypeNames.Should().BeNullOrEmpty();
    }

    [Fact]
    public void IQueryHandler_Implementations_Should_End_With_QueryHandler()
    {
        var assembly = typeof(Application.AssemblyReference).Assembly;

        var result = Types
            .InAssembly(assembly)
            .That()
            .ImplementInterface(typeof(IQueryHandler<,>))
            .Should()
            .HaveNameEndingWith("QueryHandler")
            .GetResult();

        result.FailingTypeNames.Should().BeNullOrEmpty();
    }

    #endregion

    #region Events

    [Fact]
    public void IDomainEventHandler_Implementations_Should_End_With_EventHandler()
    {
        var assembly = typeof(Application.AssemblyReference).Assembly;

        var result = Types
            .InAssembly(assembly)
            .That()
            .ImplementInterface(typeof(IDomainEventHandler<>))
            .Should()
            .HaveNameEndingWith("EventHandler")
            .GetResult();

        result.FailingTypeNames.Should().BeNullOrEmpty();
    }

    #endregion
}