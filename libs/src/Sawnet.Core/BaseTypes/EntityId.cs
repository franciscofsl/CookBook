namespace Sawnet.Core.BaseTypes;

public abstract class EntityId : ValueObject
{
    public Guid Id { get; protected init; }
    
    public override bool Equals(object obj)
    {
        if (obj is EntityId id)
        {
            return Id == id.Id;
        }
        return false;
    }

    public override int GetHashCode()
    {
        return Id.GetHashCode();
    }

    public override IEnumerable<object> GetAtomicValues()
    {
        yield return Id;
    }
}
