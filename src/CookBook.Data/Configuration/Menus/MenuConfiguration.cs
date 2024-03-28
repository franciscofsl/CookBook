using CookBook.Core.Menus;
using CookBook.Core.Menus.ValueObjects;

namespace CookBook.Data.Configuration.Menus;

public class MenuConfiguration : IEntityTypeConfiguration<Menu>
{
    public void Configure(EntityTypeBuilder<Menu> builder)
    {
        builder.HasKey(_ => _.Id);
        builder.Property(x => x.Id)
            .HasConversion(x => x.Value, _ => (MenuId)_)
            .IsRequired();

        builder.Property(x => x.Name)
            .HasConversion(x => x.Value, _ => Name.Create(_))
            .IsRequired();

        builder.HasMany(_ => _.MealProducts).WithOne().IsRequired();
    }
}