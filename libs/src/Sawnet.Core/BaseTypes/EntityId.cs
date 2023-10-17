﻿namespace Sawnet.Core.BaseTypes;

public abstract record EntityId(Guid Id) : ValueObject
{
    protected override IEnumerable<object> GetAtomicValues()
    {
        yield return Id;
    }
}