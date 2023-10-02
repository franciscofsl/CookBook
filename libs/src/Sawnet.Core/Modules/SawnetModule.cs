using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace Sawnet.Core.Modules;

public abstract class SawnetModule
{
    public virtual void ConfigureCustomServices(IServiceCollection services)
    {
        
    }

    public void ConfigureServices(IServiceCollection services)
    {
        ConfigureCustomServices(services);
        var modules = GetModules();
        
        foreach (var module in modules)
        {
            module.ConfigureServices(services);
        }
    }
    
    private IReadOnlyList<SawnetModule> GetModules()
    {
        var modulesToIncludeAttribute = GetType().GetCustomAttribute<ModulesToInclude>();

        return modulesToIncludeAttribute?.Modules ?? Enumerable.Empty<SawnetModule>().ToList();
    }
}
