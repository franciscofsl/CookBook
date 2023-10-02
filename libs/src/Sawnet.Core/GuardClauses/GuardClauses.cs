namespace Sawnet.Core.GuardClauses;

public static class GuardClauses
{
    public static TObj NotNull<TObj>(TObj obj, string name)
    {
        if (obj is null)
        {
            throw new ArgumentNullException($"{name} must not be null");
        }
        return obj;
    }

    public static string NotNullOrEmpty(string title, string name)
    {
        NotNull(title, name);
        if (string.IsNullOrEmpty(title))
        {
            throw new ArgumentException($"{name} must not be empty");
        }

        return title;
    }
}
