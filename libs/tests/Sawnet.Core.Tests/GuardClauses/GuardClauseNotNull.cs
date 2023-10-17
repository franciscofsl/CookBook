using Sawnet.Core.GuardClauses;
using Shouldly;

namespace Sawnet.Core.Tests.GuardClauses;

public class GuardClauseNotNull
{
    [Fact]
    public void Should_Return_Not_Null_Object()
    {
        var anyStringObject = "Testing";

        var value = GuardClause.NotNull(anyStringObject, nameof(anyStringObject));

        value.ShouldBe(anyStringObject);
    }

    [Fact]
    public void Should_Throw_Exception_With_Null_Object()
    {
        string anyStringObject = null;
        
        Should.Throw<ArgumentException>(() => GuardClause.NotNull(anyStringObject, nameof(anyStringObject)))
            .Message.ShouldBe("Value cannot be null. (Parameter 'anyStringObject must not be null')");
    }
}