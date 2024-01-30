namespace CookBook.Core.Common.ValueObjects;

public sealed record Tax : ValueObject
{
    private const decimal Min = 0;
    private const decimal Max = 100;

    private Tax()
    {
    }

    public decimal Value { get; private init; }

    public static Tax Create(decimal value)
    {
        return new Tax
        {
            Value = Ensure.InRange(value, Min, Max)
        };
    }

    protected override IEnumerable<object> GetAtomicValues()
    {
        yield return Value;
    }
}