using System.Reflection;
using CookBook.Core.Recipes;
using Microsoft.EntityFrameworkCore;
using Sawnet.Infrastructure.Data;

namespace CookBook.Infrastructure.Data;

public class CookBookDbContext : DbContext, IDbContext
{
    public CookBookDbContext(DbContextOptions options) : base(options)
    {
    }
    
    public DbSet<Recipe> Recipes { get; set; }
    
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }
}
