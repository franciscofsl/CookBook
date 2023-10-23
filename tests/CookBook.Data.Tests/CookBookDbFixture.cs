namespace CookBook.Data.Tests;

public class CookBookDbFixture : IDisposable
{
    private readonly IServiceProvider _serviceProvider;
    private bool _disposed;

    public CookBookDbFixture()
    {
        _serviceProvider = BuildServiceProvider();
        MigrateDbContext();
    }

    public TService GetRequiredService<TService>()
    {
        return _serviceProvider.GetRequiredService<TService>();
    }

    public void Dispose()
    {
        Dispose(disposing: true);
        GC.SuppressFinalize(this);
    }

    protected virtual void Dispose(bool disposing)
    {
        if (_disposed)
        {
            return;
        }

        if (disposing)
        {
            var dbContext = _serviceProvider.GetRequiredService<CookBookDbContext>();
            dbContext.Database.EnsureDeleted();
        }

        _disposed = true;
    }

    private void MigrateDbContext()
    {
        var dbContext = _serviceProvider.GetRequiredService<CookBookDbContext>();
        dbContext.Database.Migrate();
    }

    private IServiceProvider BuildServiceProvider()
    {
        var services = new ServiceCollection();
        var coreModule = new CookBookCoreModule();
        var dataModule = new CookBookDataModule();

        coreModule.ConfigureServices(services);
        dataModule.ConfigureServices(services);

        ConfigureDbContext(services);
        return services.BuildServiceProvider();
    }

    private void ConfigureDbContext(IServiceCollection services)
    {
        var descriptor = services
            .SingleOrDefault(d => d.ServiceType == typeof(DbContextOptions<CookBookDbContext>));

        if (descriptor != null)
        {
            services.Remove(descriptor);
        }

        var dbName = $"CookBookDb-{Guid.NewGuid()}";
        var connectionString =
            $"Server=localhost,1433;Database={dbName};User=sa;Password=SqlServer_Docker2023;MultipleActiveResultSets=true;TrustServerCertificate=True;";
        services.AddDbContext<IDbContext, CookBookDbContext>(opt => opt.UseSqlServer(connectionString));
    }
}