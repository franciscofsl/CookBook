using Sawnet.Core.Modules;

namespace CookBook.Data.Tests;

[ModulesToInclude(typeof(CookBookCoreModule),
    typeof(CookBookDataModule))]
public class CookBookDbFixture : SawnetDbFixture<CookBookDbContext>
{
}