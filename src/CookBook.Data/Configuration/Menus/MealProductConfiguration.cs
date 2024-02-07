using CookBook.Core.Common.ValueObjects;
using CookBook.Core.Menus;
using CookBook.Core.Menus.ValueObjects;

namespace CookBook.Data.Configuration.Menus;

public class MealProductConfiguration : IEntityTypeConfiguration<MealProduct>
{
    public void Configure(EntityTypeBuilder<MealProduct> builder)
    {
        builder.ToTable("MealProducts");
        
        builder.HasKey(_ => _.Id);
        builder.Property(x => x.Id)
            .HasConversion(x => x.Value, _ => (MealProductId)_)
            .IsRequired();

        builder.Property(x => x.Name)
            .HasConversion(x => x.Value, _ => Name.Create(_))
            .HasMaxLength(60)
            .IsRequired();

        builder.Property(_ => _.Description).HasMaxLength(255);

        builder.OwnsOne(mp => mp.Price, price =>
        {
            price.Property(_ => _.Value).HasColumnName(nameof(Price)).IsRequired();

            price.OwnsOne(_ => _.Tax, taxBuilder =>
            {
                taxBuilder.Property(_ => _.Value).HasColumnName(nameof(Tax));
            });

            price.OwnsOne(p => p.Discount, discountBuilder =>
            {
                discountBuilder.Property(_ => _.Value).HasColumnName(nameof(Discount));
            });
        });
    }
}