using System.Text.Json;
using CookBook.Core.Recipes;
using CookBook.Core.Recipes.ValueObjects;
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

        builder
            .Property(e => e.PreparationTime)
            .HasConversion(
                preparationTime => JsonSerializer.Serialize(preparationTime, (JsonSerializerOptions)null),
                jsonContent => JsonSerializer.Deserialize<PreparationTime>(jsonContent, (JsonSerializerOptions)null));
 
        builder.Property(_ => _.Ingredients)
            .HasConversion(
                v => JsonSerializer.Serialize(v.Lines, (JsonSerializerOptions)null),
                v => JsonSerializer.Deserialize<Ingredients>(v, (JsonSerializerOptions)null));

        builder.Ignore(_ => _.Events);
    }
}