namespace Sawnet.Core.GuardClauses;

public static partial class GuardClause
{
    public static int CheckRange(int? value, int minValue, int maxValue)
    {
        if (value.HasValue && (value < minValue || value > maxValue))
        {
            throw new ArgumentOutOfRangeException(nameof(value),
                $"The number must be between {minValue} and {maxValue}.");
        }

        return value ?? throw new ArgumentNullException(nameof(value),
            "The value cannot be null.");
    }
}