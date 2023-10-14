using CookBook.Application.Contracts;
using CookBook.Application.Recipes.Events;
using CookBook.Core.Recipes.Events;
using CookBook.Test;
using NSubstitute;
using Sawnet.Core.Events;
using Shouldly;

namespace CookBook.Application.Tests.Recipes.Events;

public class RecipePublishedEventHandlerTest
{
    [Fact]
    public async Task Should_Not_Handle_Event_With_Draft_Recipe()
    {
        var fakeLogger = Substitute.For<IFakeLogger>();
        var recipe = RecipeBuilder.Create().Build();

        var domainEvent = new RecipePublishedEventHandler(fakeLogger);

        var exception = await Assert.ThrowsAsync<DomainEventException>(async () =>
        {
            await domainEvent.Handle(new RecipePublished(recipe));
        });
        exception.Message.ShouldBe("Can't notify published recipe if recipe is draft.");
    } 
}