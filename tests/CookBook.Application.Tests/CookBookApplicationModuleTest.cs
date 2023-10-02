using Sawnet.Core.Modules;

namespace CookBook.Application.Tests;

[ModulesToInclude(typeof(CookBookApplicationModule))]
public class CookBookApplicationModuleTest : SawnetApplication
{
}