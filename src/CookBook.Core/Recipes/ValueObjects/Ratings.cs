namespace CookBook.Core.Recipes.ValueObjects;

public record Ratings : ValueObject
{
    private readonly List<Score> _scores = new();

    private Ratings()
    {
    }

    public static Ratings Empty => new();

    public virtual IReadOnlyCollection<Score> Scores => _scores.AsReadOnly();

    public double CalculateAverage()
    {
        return Scores.Average(_ => _.Value);
    }

    public Score AddScore(int value, string message = null)
    {
        var score = Score.Create(value, message);
        _scores.Add(score);
        return score;
    }

    protected override IEnumerable<object> GetAtomicValues()
    {
        return Scores.Cast<object>();
    }
}