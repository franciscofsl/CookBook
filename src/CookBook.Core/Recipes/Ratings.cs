using System.Collections;
using CookBook.Core.Recipes.ValueObjects;

namespace CookBook.Core.Recipes;

public sealed class Ratings : IEnumerable<Score>
{
    private readonly List<Score> _scores = new();

    private Ratings()
    {
    }

    public static Ratings Empty => new();

    public IReadOnlyCollection<Score> Scores => _scores.AsReadOnly();

    public double Average()
    {
        return Scores.Average(_ => _.Value);
    }

    public Score AddScore(int value, string message = null)
    {
        var score = Score.Create(value, message);
        _scores.Add(score);
        return score;
    }

    public IEnumerator<Score> GetEnumerator()
    {
        return _scores.GetEnumerator();
    }

    IEnumerator IEnumerable.GetEnumerator()
    {
        return GetEnumerator();
    }
}