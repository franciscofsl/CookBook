using System.ComponentModel.DataAnnotations;

namespace CookBook.Shared.Menus;

public class CreateMenuDto
{
    [Required] public string Name { get; set; }
}

public class MenuDto
{
    public Guid Id { get; set; }

    [Required] public string Name { get; set; }
}