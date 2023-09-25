namespace Sawnet.Application.Cqrs.Queries;

public interface IQueryDispatcher
{
    Task<TQueryResult> Dispatch<TQueryResult>(IQueryRequest<TQueryResult> commandRequest) where TQueryResult : class;
}
