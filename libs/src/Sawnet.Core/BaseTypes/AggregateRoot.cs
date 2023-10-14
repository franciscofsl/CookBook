using Sawnet.Core.Events;
using Sawnet.Core.GuardClauses;

namespace Sawnet.Core.BaseTypes;

public abstract class AggregateRoot<TKey> : IEntityWithDomainEvents
    where TKey : EntityId
{
    private readonly List<IDomainEvent> _domainEvents = new();

    public TKey Id { get; }

    protected AggregateRoot()
    {
    }

    protected AggregateRoot(TKey id)
    {
        Id = GuardClause.NotNull(id, nameof(id));
    }

    public IReadOnlyList<IDomainEvent> Events => _domainEvents.AsReadOnly();

    protected void RaiseDomainEvent(IDomainEvent domainEvent)
    {
        _domainEvents.Add(domainEvent);
    }

    public void ClearDomainEvents()
    {
        _domainEvents.Clear();
    }
}