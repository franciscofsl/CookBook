using Microsoft.Extensions.DependencyInjection;

namespace Sawnet.Core.Modules;

[AttributeUsage(AttributeTargets.Class)]
public class ModulesToIncludeAttribute : Attribute
{
    private readonly List<SawnetModule> _modules = new List<SawnetModule>();

    public ModulesToIncludeAttribute(params Type[] modulesTypes)
    {
        if (modulesTypes is null || !modulesTypes.Any())
            throw new InvalidOperationException("No module has been configured in the \"ModulesToInclude\" attribute");

        foreach (var moduleType in modulesTypes)
        {
            var moduleInstance = Activator.CreateInstance(moduleType) as SawnetModule;
            _modules.Add(moduleInstance);
        }
    }

    public IReadOnlyList<SawnetModule> Modules => _modules.AsReadOnly();
}

public static class ModulesToIncludeExtensions
{
    public static void ConfigureSafeServices(this ModulesToIncludeAttribute modulesToIncludeAttribute,
        IServiceCollection services)
    {
        if (modulesToIncludeAttribute is null)
        {
            return;
        }

        foreach (var module in modulesToIncludeAttribute.Modules)
        {
            module.ConfigureServices(services);
        }
    }
}