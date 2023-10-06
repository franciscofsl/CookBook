using Sawnet.Core.GuardClauses;
using Shouldly;

namespace Sawnet.Core.Tests.GuardClauses;

public class GuardClauseNotNullOrEmpty
{
    [Fact]
    public void Should_Return_Not_Null_String()
    {
        var anyStringObject = "Testing";

        var value = GuardClause.NotNullOrEmpty(anyStringObject, nameof(anyStringObject));

        value.ShouldBe(anyStringObject);
    }
    
    [Fact]
    public void Should_Return_Not_Empty_String()
    {
        var anyStringObject = "Testing";

        var value = GuardClause.NotNullOrEmpty(anyStringObject, nameof(anyStringObject));

        value.ShouldBe(anyStringObject);
    }

    [Fact]
    public void Should_Throw_Exception_With_Null_String()
    {
        string anyStringObject = null;
        
        Should.Throw<ArgumentException>(() => GuardClause.NotNullOrEmpty(anyStringObject, nameof(anyStringObject)))
            .Message.ShouldBe("Value cannot be null. (Parameter 'anyStringObject must not be null')");
    }

    [Fact]
    public void Should_Throw_Exception_With_Empty_String()
    {
        var anyStringObject = string.Empty;
        
        Should.Throw<ArgumentException>(() => GuardClause.NotNullOrEmpty(anyStringObject, nameof(anyStringObject)))
            .Message.ShouldBe("anyStringObject must not be empty");
    }
}