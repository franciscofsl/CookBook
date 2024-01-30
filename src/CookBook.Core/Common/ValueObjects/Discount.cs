namespace CookBook.Core.Common.ValueObjects;

public sealed record Discount : ValueObject
{
    private const decimal Min = 0;
    private const decimal Max = 100;

    public decimal Value { get; private init; }

    public static Discount Create(decimal value = 0m)
    {
        return new Discount
        {
            Value = Ensure.InRange(value, Min, Max)
        };
    }

    protected override IEnumerable<object> GetAtomicValues()
    {
        yield return Value;
    }
}