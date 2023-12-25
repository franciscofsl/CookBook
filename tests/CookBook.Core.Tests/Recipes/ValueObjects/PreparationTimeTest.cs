using Sawnet.Testing.Extensions;

namespace CookBook.Core.Tests.Recipes.ValueObjects;

public class PreparationTimeTest
{
    [Fact]
    public void Should_Build_Preparation_Time()
    {
        var preparationTime = PreparationTime.Create(3, 5);
        preparationTime.Hours.Should().Be(3);
        preparationTime.Minutes.Should().Be(5);
    }

    [Fact]
    public void Should_Throw_Exception_If_Hours_Is_Lower_Than_0()
    {
        var exception = Assert.Throws<ArgumentOutOfRangeException>(() => { _ = PreparationTime.Create(-1); });
        exception.Should().NotBeNull();
    }

    [Fact]
    public void Should_Throw_Exception_If_Minutes_Is_Lower_Than_0()
    {
        var exception = Assert.Throws<ArgumentOutOfRangeException>(() => { _ = PreparationTime.Create(1, -1); });
        exception.Should().NotBeNull();
    }

    [Fact]
    public void Should_Throw_Exception_If_Minutes_Is_Greater_Than_59()
    {
        var exception = Assert.Throws<ArgumentOutOfRangeException>(() => { _ = PreparationTime.Create(1, 60); });
        exception.Should().NotBeNull();
    }

    [Fact]
    public void Should_Get_Atomic_Values()
    {
        var preparationTime = PreparationTime.Create(1, 5);
        foreach (var value in preparationTime.InvokeGetAtomicValues())
        {
            value.Should().NotBeNull();
        }
    }

    [Fact]
    public void Should_Get_Time_Format_At_To_String_With_Hours()
    {
        const int hours = 2;
        const int minutes = 7;
        var preparationTime = PreparationTime.Create(hours, minutes);
        var timeAsString = preparationTime.ToString();
        timeAsString.Should().Be($"{hours} h {minutes} min");
    }
}