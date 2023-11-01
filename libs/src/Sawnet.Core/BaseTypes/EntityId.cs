namespace Sawnet.Core.BaseTypes;

public abstract record EntityId(Guid Value) : ValueObject
{
    protected override IEnumerable<object> GetAtomicValues() => Enumerable.Repeat((object)Value, 1);
}