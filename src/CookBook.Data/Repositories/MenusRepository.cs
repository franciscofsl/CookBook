using CookBook.Core.Menus;
using CookBook.Core.Menus.ValueObjects;
using Sawnet.Data.Repositories;

namespace CookBook.Data.Repositories;

public class MenusRepository : EfRepository<Menu, MenuId>, IMenusRepository
{
    public MenusRepository(IDbContext context)
        : base(context)
    {
    }
}