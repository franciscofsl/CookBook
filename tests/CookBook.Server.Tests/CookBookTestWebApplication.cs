using CookBook.Blazor.Server;
using CookBook.Infrastructure.Data;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Sawnet.Infrastructure.Data;

namespace CookBook.Server.Tests;

public class CookBookTestWebApplication : WebApplicationFactory<Program>
{
    protected override IHost CreateHost(IHostBuilder builder)
    {
        builder.ConfigureServices(services =>
        {
            services.AddDbContext<IDbContext, CookBookDbContext>(opt => opt.UseInMemoryDatabase("InMemoryDb"));
        });
        return base.CreateHost(builder);
    }
}