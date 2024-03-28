using CookBook.Core.Common.ValueObjects;

namespace CookBook.Core.Tests.Common.ValueObjects;

public class TaxTests
{
    [Theory]
    [InlineData(-1)]
    [InlineData(110)]
    public void Create_WithInvalidValue_ShouldThrowException(decimal value)
    {
        Action act = () => Tax.Create(value);
        act.Should().Throw<ArgumentException>();
    }

    [Fact]
    public void Create_WithValidValue_ShouldSucceed()
    {
        var value = 10m;

        var tax = Tax.Create(value);

        tax.Value.Should().Be(value);
    }
}