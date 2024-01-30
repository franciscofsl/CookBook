using CookBook.Application.Menus.Commands.Show;
using CookBook.Core.Menus;
using CookBook.Core.Menus.ValueObjects;

namespace CookBook.Application.Tests.Menus.Commands;

public class ShowMenuCommandHandlerTest
{
    private readonly IMenusRepository _repository = Substitute.For<IMenusRepository>();

    [Fact]
    public async Task Should_Make_Visible_Menu_If_Has_Meal_Products()
    {
        var menu = MenuBuilder.Create().Build();
        var mealProduct = MealProductBuilder.Create().Build();
        menu.MealProducts.Add(mealProduct);
        _repository.GetAsync(Arg.Any<MenuId>()).Returns(menu);

        var command = new ShowMenuCommand(menu.Id);
        var commandHandler = new ShowMenuCommandHandler(_repository);

        var result = await commandHandler.Handle(command);

        result.Success.Should().BeTrue();
        menu.Visible.Should().BeTrue();
    }

    [Fact]
    public async Task Should_Not_Make_Visible_Menu_If_Not_Has_Meal_Products()
    {
        var menu = MenuBuilder.Create().Build();
        _repository.GetAsync(Arg.Any<MenuId>()).Returns(menu);

        var command = new ShowMenuCommand(menu.Id);
        var commandHandler = new ShowMenuCommandHandler(_repository);

        var result = await commandHandler.Handle(command);

        result.IsFailure.Should().BeTrue();
        result.Error.Should().Be(Errors.NotHasMealProducts);
        menu.Visible.Should().BeFalse();
    }
}