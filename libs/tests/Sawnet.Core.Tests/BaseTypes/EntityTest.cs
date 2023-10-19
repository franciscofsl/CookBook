﻿namespace Sawnet.Core.Tests.BaseTypes;

public class EntityTest
{
    [Fact]
    public void Constructor_WithValidId_Should_Set_Id()
    {
        var entityId = new TestEntityId(Guid.NewGuid());

        var aggregateRoot = new TestEntity(entityId);

        aggregateRoot.Id.Should().Be(entityId);
    }

    [Fact]
    public void Constructor_WithNullId_Should_Throw_ArgumentNullException()
    {
        Assert.Throws<ArgumentNullException>(() => new TestEntity(null));
    }

    [Fact]
    public void Should_Create_Aggregate_Root_With_Empty_Builder()
    {
        var aggregateRoot = new TestEntity();
        aggregateRoot.Should().NotBeNull();
    }

    private class TestEntity : Entity<TestEntityId>
    {
        public TestEntity()
        {
        }

        public TestEntity(TestEntityId id) : base(id)
        {
        }
    }

    private record TestEntityId(Guid Id) : EntityId(Id);

    private class TestDomainEvent : IDomainEvent
    {
    }
}