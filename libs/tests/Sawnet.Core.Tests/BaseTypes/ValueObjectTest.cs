namespace Sawnet.Core.Tests.BaseTypes;

public class ValueObjectTest
{
    [Fact]
    public void Get_Hash_Code_Should_Be_Consistent()
    {
        var valueObject1 = new TestValueObject();
        var valueObject2 = new TestValueObject();

        var hashCode1 = valueObject1.GetHashCode();
        var hashCode2 = valueObject2.GetHashCode();

        hashCode1.Should().Be(hashCode2);
    }

    [Fact]
    public void Equals_ShouldReturnTrueForEqualObjects()
    {
        var valueObject1 = new TestValueObject();
        var valueObject2 = new TestValueObject();

        var areEqual = valueObject1.Equals(valueObject2);

        areEqual.Should().BeTrue();
    }

    [Fact]
    public void Equals_ShouldReturnFalseForDifferentObjects()
    {
        var valueObject1 = new TestValueObject();
        var valueObject2 = new TestValueObject();
        
        valueObject2.Increment();

        var areEqual = valueObject1.Equals(valueObject2);

        areEqual.Should().BeFalse();
    }
}

public record TestValueObject : ValueObject
{
    private int _atomicValue = 42;

    protected override IEnumerable<object> GetAtomicValues()
    {
        yield return _atomicValue;
    }

    public void Increment()
    {
        // Simulate modification of atomic value for testing inequality
        _atomicValue++;
    }
}