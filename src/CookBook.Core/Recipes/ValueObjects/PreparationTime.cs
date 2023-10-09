using System.Text;

namespace CookBook.Core.Recipes.ValueObjects;

public class PreparationTime : ValueObject
{
    private const int MinTimeValue = 0;
    private const int MaxTimeValue = 59;

    private PreparationTime()
    {
    }

    public static PreparationTime Create(int? hours, int? minutes = null)
    {
        if (hours is < MinTimeValue)
        {
            throw new ArgumentOutOfRangeException(nameof(hours), "Hours not be lower than 0");
        }

        return new PreparationTime
        {
            Hours = hours,
            Minutes = GuardClause.CheckNullableRange(minutes, MinTimeValue, MaxTimeValue)
        };
    }

    public int? Hours { get; private init; }

    public int? Minutes { get; private init; }

    public override IEnumerable<object> GetAtomicValues()
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

        if (Minutes.HasValue)
        {
            builder.Append($"{Minutes} min");
        }

        return builder.ToString().Trim();
    }
}