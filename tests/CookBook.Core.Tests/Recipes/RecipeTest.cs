using CookBook.Core.Recipes.Events;
using CookBook.Test;

namespace CookBook.Core.Tests.Recipes;

public class RecipeTest
{
    [Fact]
    public void Should_Publish_Recipe()
    {
        var recipe = RecipeBuilder.Create().Build();
        
        recipe.IsDraft.Should().BeTrue();
        
        recipe.Publish();

        recipe.IsDraft.Should().BeFalse();
        recipe.Events.Should().Contain(_ => _ is RecipePublished);
    }
}