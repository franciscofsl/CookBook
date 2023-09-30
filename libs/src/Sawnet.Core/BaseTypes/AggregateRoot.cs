namespace Sawnet.Core.BaseTypes;

public abstract class AggregateRoot<TKey> where TKey : EntityId
{
    public TKey Id { get; }

    protected AggregateRoot()
    {
        
    }

    protected AggregateRoot(TKey id)
    {
        Id = id ?? throw new ArgumentNullException(nameof(id));
    }
}