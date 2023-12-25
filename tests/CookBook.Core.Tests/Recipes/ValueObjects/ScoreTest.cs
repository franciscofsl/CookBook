using Sawnet.Testing.Extensions;

namespace CookBook.Core.Tests.Recipes.ValueObjects;

public class ScoreTest
{
    [Fact]
    public void Should_Create_Score()
    {
        var score = Score.Create(1, "Message");

        score.Value.Should().Be(1);
        score.Message.Should().Be("Message");
    }

    [Fact]
    public void Should_Not_Create_Score_With_Minor_Value_Than_MinValue()
    {
        FluentActions
            .Invoking(() => { _ = Score.Create(Score.MinValue - 1); })
            .Should()
            .ThrowExactly<ArgumentOutOfRangeException>();
    }

    [Fact]
    public void Should_Not_Create_Score_With_Greater_Value_Than_MaxValue()
    {
        FluentActions
            .Invoking(() => { _ = Score.Create(Score.MaxValue + 1); })
            .Should()
            .ThrowExactly<ArgumentOutOfRangeException>();
    }

    [Fact]
    public void Should_Get_Atomic_Values()
    {
        var score = Score.Create(4);
        
        var atomicValues = score.InvokeGetAtomicValues();

        atomicValues.Should().NotBeNull();
    }
}