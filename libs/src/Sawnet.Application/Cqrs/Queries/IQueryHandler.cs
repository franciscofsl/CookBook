namespace Sawnet.Application.Cqrs.Queries;

public interface IQueryHandler<in TQuery, TResult>
    where TQuery : IQueryRequest<TResult>
    where TResult : class
{
    Task<TResult> Handle(TQuery query, CancellationToken cancellationToken = default);
}
