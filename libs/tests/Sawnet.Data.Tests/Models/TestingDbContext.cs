using Microsoft.EntityFrameworkCore;
using Sawnet.Core.BaseTypes;
using Sawnet.Core.Events;
using Sawnet.Data.DbContexts;

namespace Sawnet.Data.Tests.Models;

public class TestingDbContext : SawnetDbContext<TestingDbContext>
{
    public TestingDbContext()
    {
    }

    public TestingDbContext(DbContextOptions<TestingDbContext> options, IDomainEventPublisher domainEventPublisher)
        : base(options, domainEventPublisher)
    {
    }

    public DbSet<SampleAggregate> SampleModels { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);
        modelBuilder.Entity<SampleAggregate>().HasKey(_ => _.Id);
        modelBuilder.Entity<SampleAggregate>().Property(x => x.Id)
            .HasConversion(x => x.Value, _ => (SampleId)_)
            .IsRequired();
    }
}

public record SampleId(Guid Id) : EntityId(Id)
{
    public static explicit operator SampleId(Guid id) => new(id);

    public static implicit operator Guid(SampleId id) => id.Value;
}

public class SampleAggregate : AggregateRoot<SampleId>
{
    public SampleAggregate(SampleId id) : base(id)
    {
        RaiseDomainEvent(new SampleModelCreated(this));
    }
}

public record SampleModelCreated(SampleAggregate Model) : IDomainEvent;