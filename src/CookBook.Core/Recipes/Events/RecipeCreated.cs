using Sawnet.Core.Events;

namespace CookBook.Core.Recipes.Events;

public sealed record RecipeCreated(Recipe Recipe) : IDomainEvent
{
}