﻿using CookBook.Application.Contracts;

namespace CookBook.Application.Recipes.Events;

[ExcludeFromCodeCoverage]
public class RecipePublishedEventHandler : IDomainEventHandler<RecipePublished>
{
    private readonly IFakeLogger _fakeLogger;

    public RecipePublishedEventHandler(IFakeLogger fakeLogger)
    {
        _fakeLogger = fakeLogger;
    }

    public async Task Handle(RecipePublished domainEvent, CancellationToken token = default)
    {
        if (domainEvent.Recipe.IsDraft)
        {
            throw new DomainEventException("Can't notify published recipe if recipe is draft.");
        }
        
        var emailContent = $"The recipe '{domainEvent.Recipe.Title.Title}' has been published.";

        await _fakeLogger.LogAsync(emailContent);
    }
}