using CookBook.Core.Recipes.Entities;

namespace CookBook.Data.Configuration.Recipes;

public class IngredientConfiguration : IEntityTypeConfiguration<Ingredient>
{
    public void Configure(EntityTypeBuilder<Ingredient> builder)
    {
        builder.ToTable("Ingredients");

        builder.HasKey(_ => _.Id);
        builder.Property(x => x.Id)
            .HasConversion(x => x.Value, _ => (IngredientLineId)_)
            .IsRequired();

        builder.Ignore(_ => _.Events);
    }
}