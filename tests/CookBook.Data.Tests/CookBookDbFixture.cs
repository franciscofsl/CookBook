using Sawnet.Core.Modules;
using Sawnet.Data.Tests;

namespace CookBook.Data.Tests;

[ModulesToInclude(typeof(CookBookCoreModule),
    typeof(CookBookDataModule))]
public class CookBookDbFixture : SawnetDbFixture<CookBookDbContext>
{
}