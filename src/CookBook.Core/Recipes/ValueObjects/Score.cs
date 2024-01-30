namespace CookBook.Core.Recipes.ValueObjects;

public sealed record Score : ValueObject
{
    public const int MinValue = 1;
    public const int MaxValue = 10;

    private Score()
    {
    }

    public static Score Create(int value, string message = null)
    {
        return new Score
        {
            Value = Ensure.InRange(value, MinValue, MaxValue),
            Message = message
        };
    }

    public int Value { get; init; }

    public string Message { get; init; }

    protected override IEnumerable<object> GetAtomicValues()
    {
        yield return Value;
    }
}