using System.Text;

namespace CookBook.Core.Recipes.ValueObjects;

public sealed record PreparationTime : ValueObject
{
    public const int MinTimeValue = 0;
    public const int MaxTimeValue = 59;

    public static readonly PreparationTime Empty = new();

    private PreparationTime()
    {
    }

    public static PreparationTime Create(int? hours, int minutes = MinTimeValue)
    {
        if (hours is < MinTimeValue)
        {
            throw new ArgumentOutOfRangeException(nameof(hours), "Hours not be lower than 0");
        }

        return new PreparationTime
        {
            Hours = hours,
            Minutes = Ensure.InRange(minutes, MinTimeValue, MaxTimeValue)
        };
    }

    public int? Hours { get; private init; }

    public int Minutes { get; private init; }

    protected override IEnumerable<object> GetAtomicValues()
    {
        yield return Hours;
        yield return Minutes;
    }

    public override string ToString()
    {
        var builder = new StringBuilder();
        if (Hours.HasValue)
        {
            builder.Append($"{Hours} h ");
        }

        if (Minutes > 0)
        {
            builder.Append($"{Minutes} min");
        }

        return builder.ToString().Trim();
    }
}