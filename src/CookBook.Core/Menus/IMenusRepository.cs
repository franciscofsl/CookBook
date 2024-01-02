using CookBook.Core.Menus.ValueObjects;
using Sawnet.Core.Contracts;

namespace CookBook.Core.Menus;

public interface IMenusRepository : IRepository<Menu, MenuId>
{
}