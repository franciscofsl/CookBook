namespace CookBook.Core.Common.ValueObjects;

public sealed record Price : ValueObject
{
    private const decimal Min = 0;
    private const decimal Max = decimal.MaxValue;

    private Price()
    {
    }

    public decimal Value { get; private init; }

    public Tax Tax { get; private init; }

    public Discount Discount { get; private init; }

    public static Price Create(decimal value, Tax tax, Discount discount = null)
    {
        return new Price
        {
            Value = Ensure.InRange(value, Min, Max),
            Tax = Ensure.NotNull(tax, nameof(tax)),
            Discount = discount ?? Discount.Create()
        };
    }

    public decimal FinalPrice()
    {
        var valueWithTax = CalculateValueWithTax();
        var discountedValue = CalculateDiscountedValue();

        return valueWithTax * discountedValue;
    }

    private decimal CalculateValueWithTax()
    {
        return Value * (1 + Tax.Value / 100);
    }

    private decimal CalculateDiscountedValue()
    {
        return 1 - Discount.Value / 100;
    }

    protected override IEnumerable<object> GetAtomicValues()
    {
        yield return Value;
        yield return Tax;
        yield return Discount;
    }
}