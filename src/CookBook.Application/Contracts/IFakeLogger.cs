namespace CookBook.Application.Contracts;

public interface IFakeLogger
{
    Task LogAsync(string content);
    
    Task<List<string>> GetLogs();
}