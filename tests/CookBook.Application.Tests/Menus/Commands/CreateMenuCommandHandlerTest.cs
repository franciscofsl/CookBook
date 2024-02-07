using CookBook.Application.Menus.Commands.Create;
using CookBook.Core.Menus;

namespace CookBook.Application.Tests.Menus.Commands;

public class CreateMenuCommandHandlerTest
{
    private readonly IMenusRepository _repository = Substitute.For<IMenusRepository>();

    [Fact]
    public async Task Should_Create_Menu()
    {
        var command = new CreateMenuCommand
        {
            Name = "Summer Menu"
        };

        var commandHandler = new CreateMenuCommandHandler(_repository, new CreateMenuCommandValidator());

        var result = await commandHandler.Handle(command);

        result.Success.Should().BeTrue();

        var createdMenu = result.Value;

        createdMenu.Name.Value.Should().Be(command.Name);
    }

    [Fact]
    public async Task Should_Not_Create_Menu_With_Null_Name()
    {
        var command = new CreateMenuCommand
        {
            Name = null
        };

        var commandHandler = new CreateMenuCommandHandler(_repository, new CreateMenuCommandValidator());

        var result = await commandHandler.Handle(command);
        
        result.IsFailure.Should().BeTrue();
    }
}