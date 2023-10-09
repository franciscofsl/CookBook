using CookBook.Core.Recipes.ValueObjects;
using Shouldly;

namespace CookBook.Domain.Tests.Recipes.ValueObjects;

public class PreparationTimeTest
{
    [Fact]
    public void Should_Build_Preparation_Time()
    {
        var preparationTime = PreparationTime.Create(3, 5);
        preparationTime.Hours.ShouldBe(3);
        preparationTime.Minutes.ShouldBe(5);
    }

    [Fact]
    public void Should_Throw_Exception_If_Hours_Is_Lower_Than_0()
    {
        var exception = Assert.Throws<ArgumentOutOfRangeException>(() => { _ = PreparationTime.Create(-1); });
        exception.ShouldNotBeNull();
    }

    [Fact]
    public void Should_Throw_Exception_If_Minutes_Is_Lower_Than_0()
    {
        var exception = Assert.Throws<ArgumentOutOfRangeException>(() => { _ = PreparationTime.Create(1, -1); });
        exception.ShouldNotBeNull();
    }

    [Fact]
    public void Should_Throw_Exception_If_Minutes_Is_Greater_Than_59()
    {
        var exception = Assert.Throws<ArgumentOutOfRangeException>(() => { _ = PreparationTime.Create(1, 60); });
        exception.ShouldNotBeNull();
    }

    [Fact]
    public void Should_Get_Atomic_Values()
    {
        var preparationTime = PreparationTime.Create(1, 5);
        foreach (var value in preparationTime.GetAtomicValues())
        {
            value.ShouldNotBeNull();
        }
    }

    [Fact]
    public void Should_Get_Time_Format_At_To_String_With_Hours()
    {
        const int hours = 2;
        const int minutes = 7;
        var preparationTime = PreparationTime.Create(hours, minutes);
        var timeAsString = preparationTime.ToString();
        timeAsString.ShouldBe($"{hours} h {minutes} min");
    }
}