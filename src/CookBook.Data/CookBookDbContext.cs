using CookBook.Core.Menus;
using Sawnet.Data.DbContexts;

namespace CookBook.Data;

public class CookBookDbContext : SawnetDbContext<CookBookDbContext>
{
    public CookBookDbContext()
    {
    }

    public CookBookDbContext(DbContextOptions<CookBookDbContext> options, IDomainEventPublisher domainEventPublisher)
        : base(options, domainEventPublisher)
    {
    }

    public DbSet<Recipe> Recipes { get; set; }
    
    public DbSet<Menu> Menus { get; set; }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}