using CookBook.Core.Recipes;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CookBook.Infrastructure.Data.Configuration;

public class RecipeConfiguration : IEntityTypeConfiguration<Recipe>
{
    public void Configure(EntityTypeBuilder<Recipe> builder)
    {
        builder.Property(x => x.Id)
            .HasConversion(x => x.Id, _ => (RecipeId)_)
            .IsRequired();

        builder.OwnsOne(_ => _.Title);
        builder.OwnsOne(_ => _.Description);
    }
}