﻿using Microsoft.Extensions.DependencyInjection;
using Sawnet.Core.Events;
using Shouldly;

namespace Sawnet.Core.Tests.Events;

public class DomainEventPublisherTest
{
    private const string ExceptionMessage = "My exception";

    [Fact]
    public async Task Should_Retrieve_Valid_Domain_Event_Handler_By_Event()
    {
        var serviceCollection = new ServiceCollection();
        var dddModule = new DddModule();
        dddModule.ConfigureCustomServices(serviceCollection);
        serviceCollection.AddTransient<IDomainEventHandler<TestDomainEvent>, TestDomainEventHandler>();

        var serviceProvider = serviceCollection.BuildServiceProvider();

        var domainEventPublisher = serviceProvider.GetRequiredService<IDomainEventPublisher>();

        await Should.NotThrowAsync(async () => { await domainEventPublisher.Publish(new TestDomainEvent()); });
    }

    [Fact]
    public async Task Should_Throw_Domain_Exception_In_Handler()
    {
        var serviceCollection = new ServiceCollection();
        var dddModule = new DddModule();
        dddModule.ConfigureCustomServices(serviceCollection);
        serviceCollection.AddTransient<IDomainEventHandler<TestDomainEvent>, TestDomainEventHandler>();

        var serviceProvider = serviceCollection.BuildServiceProvider();

        var domainEventPublisher = serviceProvider.GetRequiredService<IDomainEventPublisher>();

        var exception = await Assert.ThrowsAsync<DomainEventException>(async () =>
        {
            await domainEventPublisher.Publish(new TestDomainEvent(true));
        });

        exception.Message.ShouldBe(ExceptionMessage);
    }

    public record TestDomainEvent(bool ThrowException = false) : IDomainEvent;

    public class TestDomainEventHandler : IDomainEventHandler<TestDomainEvent>
    {
        public Task Handle(TestDomainEvent domainEvent, CancellationToken token = default)
        {
            if (domainEvent.ThrowException)
            {
                throw new DomainEventException(ExceptionMessage);
            }

            return Task.CompletedTask;
        }
    }
}