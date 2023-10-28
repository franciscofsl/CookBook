namespace CookBook.Data;

public class CookBookDbContext : DbContext, IDbContext
{
    private readonly IDomainEventPublisher _publisher;

    public CookBookDbContext()
    {
    }

    public CookBookDbContext(DbContextOptions options, IDomainEventPublisher publisher) : base(options)
    {
        _publisher = publisher;
    }

    public DbSet<Recipe> Recipes { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        if (!optionsBuilder.IsConfigured)
        {
            optionsBuilder.UseSqlServer(
                "Server=localhost,1434;Database=CookBook;User=sa;Password=SqlServer_Docker2023;MultipleActiveResultSets=true;TrustServerCertificate=True;");
        }
    }

    public override async Task<int> SaveChangesAsync(CancellationToken cancellationToken = new())
    {
        var result = await base.SaveChangesAsync(cancellationToken);
        await DispatchDomainEvents();
        return result;
    }

    public override int SaveChanges()
    {
        var result = base.SaveChanges();
        DispatchDomainEvents().GetAwaiter().GetResult();
        return result;
    }

    private async Task DispatchDomainEvents()
    {
        var domainEventEntities = ChangeTracker.Entries<IEntityWithDomainEvents>()
            .Select(po => po.Entity)
            .Where(po => po.Events.Any())
            .ToArray();

        foreach (var entity in domainEventEntities)
        {
            foreach (var entityEvents in entity.Events)
            {
                await _publisher.Publish(entityEvents);
            }

            entity.ClearDomainEvents();
        }
    }
}