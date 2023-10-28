using CookBook.Application;
using CookBook.Data;
using CookBook.Infrastructure.Logger;
using Sawnet.Core.Modules;

namespace CookBook.Blazor.Server;

[ModulesToInclude(typeof(CookBookDataModule),
    typeof(CookBookApplicationModule),
    typeof(FakeLoggerModule))]
public class CookBookApplication : SawnetApplication
{
}