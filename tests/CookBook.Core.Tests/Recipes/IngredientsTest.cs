using CookBook.Core.Recipes.Enums;

namespace CookBook.Core.Tests.Recipes;

public class IngredientsTest
{
    [Fact]
    public void Should_Add_Ingredient()
    {
        const string milk = "Milk";
        var ingredients = Ingredients.Empty;

        var ingredientLine = ingredients.AddIngredient(milk);

        ingredientLine.Description.Should().Be(milk);
        ingredientLine.Order.Should().Be(1);
        ingredientLine.Type.Should().Be(IngredientType.Ingredient);

        ingredients.Lines.Should().Contain(_ => _.Description == milk);
    }

    [Fact]
    public void Should_Add_Section()
    {
        const string section = "For milk";
        var ingredients = Ingredients.Empty;

        var ingredientLine = ingredients.AddSection(section);

        ingredientLine.Description.Should().Be(section);
        ingredientLine.Order.Should().Be(1);
        ingredientLine.Type.Should().Be(IngredientType.Section);

        ingredients.Lines.Should().Contain(_ => _.Description == section);
    }

    [Fact]
    public void Should_Add_Sections_And_Ingredients_In_Order()
    {
        var ingredients = Ingredients.Empty;

        var section = ingredients.AddSection("New Section");
        var milk = ingredients.AddIngredient("Milk");
        var fish = ingredients.AddIngredient("Fish");

        section.Order.Should().Be(1);
        milk.Order.Should().Be(2);
        fish.Order.Should().Be(3);
    }

    [Fact]
    public void Should_Get_Ingredient_Line_Atomic_Values()
    {
        var ingredients = Ingredients.Empty;
        var section = ingredients.AddSection("New Section");

        foreach (var getAtomicValue in section.InvokeGetAtomicValues())
        {
            getAtomicValue.Should().NotBeNull();
        }
    }
}