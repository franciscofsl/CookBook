using CookBook.Infrastructure.Data;
using Sawnet.Application.Cqrs;
using Sawnet.Core.Modules;

namespace CookBook.Application;

[ModulesToInclude(typeof(CqrsModule),
    typeof(CookBookDataModule))]
public class CookBookApplication : SawnetApplication
{

}
