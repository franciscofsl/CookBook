namespace CookBook.Core.Menus.ValueObjects;

public sealed record Name : ValueObject
{
    private const int MaxNameLength = 50;

    private Name()
    {
    }

    public string Value { get; private init; }

    public static Name Create(string value)
    {
        return new Name
        {
            Value = Ensure.HasMaxLength(value, MaxNameLength, nameof(Name))
        };
    }

    protected override IEnumerable<object> GetAtomicValues()
    {
        yield return Value;
    }

    public static explicit operator Name(string value) => Create(value);

    public static implicit operator string(Name name) => name.Value;
}