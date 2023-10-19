namespace Sawnet.Core.Tests.BaseTypes;

public class AggregateRootTest
{
    [Fact]
    public void Constructor_WithValidId_Should_Set_Id()
    {
        var entityId = new TestEntityId(Guid.NewGuid());

        var aggregateRoot = new TestAggregateRoot(entityId);

        aggregateRoot.Id.Should().Be(entityId);
    }

    [Fact]
    public void Constructor_WithNullId_Should_Throw_ArgumentNullException()
    {
        Assert.Throws<ArgumentNullException>(() => new TestAggregateRoot(null));
    }

    [Fact]
    public void RaiseDomainEvent_Should_Add_Event_To_Events_List()
    {
        var aggregateRoot = new TestAggregateRoot(new TestEntityId(Guid.NewGuid()));
        var domainEvent = new TestDomainEvent();

        InvokeRaiseDomainEvent(aggregateRoot, domainEvent);

        aggregateRoot.Events.Should().Contain(domainEvent);
    }

    [Fact]
    public void ClearDomainEvents_Should_Clear_Events_List()
    {
        var aggregateRoot = new TestAggregateRoot(new TestEntityId(Guid.NewGuid()));

        InvokeRaiseDomainEvent(aggregateRoot, new TestDomainEvent());
        aggregateRoot.ClearDomainEvents();

        aggregateRoot.Events.Should().BeEmpty();
    }

    [Fact]
    public void Should_Create_Aggregate_Root_With_Empty_Builder()
    {
        var aggregateRoot = new TestAggregateRoot();
        aggregateRoot.Should().NotBeNull();
    }

    private static void InvokeRaiseDomainEvent(TestAggregateRoot aggregateRoot, TestDomainEvent domainEvent)
    {
        var methodInfo =
            typeof(AggregateRoot<TestEntityId>).GetMethod("RaiseDomainEvent",
                BindingFlags.Instance | BindingFlags.NonPublic);
        methodInfo.Invoke(aggregateRoot, new object[] { domainEvent });
    }

    private class TestAggregateRoot : AggregateRoot<TestEntityId>
    {
        public TestAggregateRoot()
        {
        }

        public TestAggregateRoot(TestEntityId id) : base(id)
        {
        }
    }

    private record TestEntityId(Guid Id) : EntityId(Id);

    private class TestDomainEvent : IDomainEvent
    {
    }
}