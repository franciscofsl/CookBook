using CookBook.Core.Common.ValueObjects;

namespace CookBook.Core.Tests.Common.ValueObjects;

public class DiscountTests
{
    [Theory]
    [InlineData(-1)] 
    [InlineData(110)]
    public void Create_WithInvalidValue_ShouldThrowException(decimal value)
    {
        Action act = () => Discount.Create(value);
        act.Should().Throw<ArgumentException>();
    }

    [Fact]
    public void Create_WithValidValue_ShouldSucceed()
    {
        var value = 5m;

        var discount = Discount.Create(value);

        discount.Value.Should().Be(value);
    }
}