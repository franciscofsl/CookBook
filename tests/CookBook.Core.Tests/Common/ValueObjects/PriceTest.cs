using CookBook.Core.Common.ValueObjects;

public class PriceTests
{
    [Fact]
    public void Create_WithValidValues_ShouldSucceed()
    {
        var value = 50m;
        var tax = Tax.Create(10m);
        var discount = Discount.Create(5m);

        var price = Price.Create(value, tax, discount);

        price.Value.Should().Be(value);
        price.Tax.Should().Be(tax);
        price.Discount.Should().Be(discount);
    }

    [Theory]
    [InlineData(-1, 10, 5)]
    [InlineData(50, -1, 5)]
    [InlineData(50, 10, -1)]
    public void Create_WithInvalidValues_ShouldThrowException(decimal value, decimal tax, decimal discount)
    {
        Action act = () => Price.Create(value, Tax.Create(tax), Discount.Create(discount));
        act.Should().Throw<ArgumentException>();
    }

    [Fact]
    public void Create_WithNullTax_ShouldThrowException()
    {
        Action act = () => Price.Create(50m, null);
        act.Should().Throw<ArgumentNullException>();
    }

    [Fact]
    public void Create_WithNullDiscount_ShouldSetDefaultDiscount()
    {
        var value = 50m;
        var tax = Tax.Create(10m);

        var price = Price.Create(value, tax);

        price.Discount.Value.Should().Be(0m);
    }

    [Fact]
    public void CalculateFinalPrice_ShouldReturnCorrectValue()
    {
        var value = 100m;
        var tax = Tax.Create(10m);
        var discount = Discount.Create(5m);

        var price = Price.Create(value, tax, discount);
        var finalPrice = price.FinalPrice();

        finalPrice.Should().Be(104.5m);
    }

}

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