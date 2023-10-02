using Sawnet.Core.Events;

namespace Sawnet.Core.BaseTypes;

public interface IEntityWithDomainEvents
{
    IReadOnlyList<IDomainEvent> Events { get; }

    void ClearDomainEvents();
}

public abstract class AggregateRoot<TKey> : IEntityWithDomainEvents
    where TKey : EntityId
{
    private List<IDomainEvent> _domainEvents = new();
    public TKey Id { get; }

    protected AggregateRoot()
    {
    }

    protected AggregateRoot(TKey id)
    {
        Id = id ?? throw new ArgumentNullException(nameof(id));
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