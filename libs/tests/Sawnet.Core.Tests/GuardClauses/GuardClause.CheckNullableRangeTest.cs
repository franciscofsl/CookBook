using Sawnet.Core.GuardClauses;
using Shouldly;

namespace Sawnet.Core.Tests.GuardClauses;

public class GuardClauseCheckNullableRangeTest
{
    [Fact]
    public void CheckNullableRange_With_Valid_Range_Returns_Value()
    {
        var value = 5;
        var minValue = 1;
        var maxValue = 10;

        var result = GuardClause.CheckNullableRange(value, minValue, maxValue);

        result.ShouldBe(value);
    }

    [Fact]
    public void CheckNullableRange_With_Null_Value_Returns_Null()
    {
        int? value = null;
        var minValue = 1;
        var maxValue = 10;

        var result = GuardClause.CheckNullableRange(value, minValue, maxValue);

        result.ShouldBeNull();
    }

    [Fact]
    public void CheckNullableRange_With_Out_Of_Range_Value_Throws_ArgumentOutOfRangeException()
    {
        var value = 15;
        var minValue = 1;
        var maxValue = 10;

        Should.Throw<ArgumentOutOfRangeException>(() => GuardClause.CheckNullableRange(value, minValue, maxValue))
            .Message.ShouldContain($"The number must be between {minValue} and {maxValue}.");
    }

    [Fact]
    public void CheckNullableRange_With_Equal_Min_And_Max_Values_Returns_Value()
    {
        var value = 5;
        var minValue = 5;
        var maxValue = 5;

        var result = GuardClause.CheckNullableRange(value, minValue, maxValue);

        result.ShouldBe(value);
    }

    [Fact]
    public void CheckNullableRange_With_Min_Value_Greater_Than_Max_Value_ThrowsArgumentException()
    {
        var value = 5;
        var minValue = 10;
        var maxValue = 5;

        Should.Throw<ArgumentException>(() => GuardClause.CheckNullableRange(value, minValue, maxValue))
            .Message.ShouldContain("The number must be between 10 and 5. (Parameter 'value')");
    }
}