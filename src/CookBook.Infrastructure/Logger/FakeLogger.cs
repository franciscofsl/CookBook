using CookBook.Application.Contracts;

namespace CookBook.Infrastructure.Logger;

public class FakeLogger : IFakeLogger
{
    private readonly List<string> _logs = new();

    public Task LogAsync(string content)
    {
        _logs.Add(content);
        return Task.CompletedTask;
    }

    public Task<List<string>> GetLogs()
    {
        return Task.FromResult(_logs);
    }
}