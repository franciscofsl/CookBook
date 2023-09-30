using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.Hosting;
using CookBook.Blazor.Server;
using CookBook.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection.Extensions;
using Sawnet.Infrastructure.Data;

namespace CookBook.Server.Tests;

public class CookBookTestWebApplication : WebApplicationFactory<Program>
{
    protected override IHost CreateHost(IHostBuilder builder)
    {
        return base.CreateHost(builder);
    }
}