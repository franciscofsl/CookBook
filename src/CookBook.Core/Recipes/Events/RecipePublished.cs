using Sawnet.Core.Events;

namespace CookBook.Core.Recipes.Events;

public sealed record RecipePublished(Recipe Recipe) : IDomainEvent
{
}