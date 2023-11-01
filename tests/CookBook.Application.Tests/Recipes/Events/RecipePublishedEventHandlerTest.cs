namespace CookBook.Application.Tests.Recipes.Events;

public class RecipePublishedEventHandlerTest
{
    [Fact]
    public async Task Should_Not_Handle_Event_With_Not_Published_Recipe()
    {
        var fakeLogger = Substitute.For<IFakeLogger>();
        var recipe = RecipeBuilder.Create().Build();

        var domainEvent = new RecipePublishedEventHandler(fakeLogger);

        var exception = await Assert.ThrowsAsync<DomainEventException>(async () =>
        {
            await domainEvent.Handle(new RecipePublished(recipe));
        });
        exception.Message.Should().Be("Can't notify published recipe if recipe is not published.");
    } 
}