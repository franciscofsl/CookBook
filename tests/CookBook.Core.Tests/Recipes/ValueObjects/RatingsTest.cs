namespace CookBook.Core.Tests.Recipes.ValueObjects;

public class RatingsTest
{
    [Fact]
    public void Should_Create_Ratings()
    {
        var ratings = Ratings.Empty;

        ratings.Scores.Should().NotBeNull();
    }

    [Fact]
    public void Should_Add_Score()
    {
        var ratings = Ratings.Empty;

        for (var i = Score.MinValue; i < Score.MaxValue + 1; i++)
        {
            ratings.AddScore(i);
        }

        ratings.Scores.Should().HaveCount(10);
        ratings.Scores.MaxBy(_ => _.Value).Value.Should().Be(10);
    }

    [Fact]
    public void Should_Add_Score_With_Message()
    {
        var ratings = Ratings.Empty;

        var score = ratings.AddScore(1, "Message");
        var firstScore = ratings.Scores.First();

        score.Value.Should().Be(firstScore.Value);
        score.Message.Should().Be(firstScore.Message);
    }

    [Fact]
    public void Should_Calculate_Average()
    {
        var ratings = Ratings.Empty;

        ratings.AddScore(3);
        ratings.AddScore(5);
        ratings.AddScore(7);

        var average = ratings.CalculateAverage();

        average.Should().Be(5.0);
    }

    [Fact]
    public void Should_Get_Atomic_Values()
    {
        var ratings = Ratings.Empty;

        var atomicValues = ratings.InvokeGetAtomicValues();

        atomicValues.Should().HaveCount(0);
    }
}