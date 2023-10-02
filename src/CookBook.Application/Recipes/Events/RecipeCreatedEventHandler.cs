using CookBook.Application.Contracts;
using CookBook.Core.Recipes.Events;
using Sawnet.Core.Events;

namespace CookBook.Application.Recipes.Events;

public class RecipeCreatedEventHandler : IDomainEventHandler<RecipeCreated>
{
    private readonly IFakeLogger _fakeLogger;

    public RecipeCreatedEventHandler(IFakeLogger fakeLogger)
    {
        _fakeLogger = fakeLogger;
    }

    public async Task Handle(RecipeCreated domainEvent, CancellationToken token = default)
    {
        var emailContent = $"The recipe '{domainEvent.Recipe.Title.Title}' has been created.";

        await _fakeLogger.LogAsync(emailContent);
    }
}