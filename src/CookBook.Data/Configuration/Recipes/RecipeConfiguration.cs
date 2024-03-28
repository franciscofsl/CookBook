namespace CookBook.Data.Configuration.Recipes;

public class RecipeConfiguration : IEntityTypeConfiguration<Recipe>
{
    public void Configure(EntityTypeBuilder<Recipe> builder)
    {
        builder.ToTable("Recipes");

        builder.HasKey(_ => _.Id);
        builder.Property(x => x.Id)
            .HasConversion(x => x.Value, _ => (RecipeId)_)
            .IsRequired();

        builder.OwnsOne(_ => _.Title)
            .Property(_ => _.Value)
            .HasColumnName(nameof(Recipe.Title))
            .HasConversion(_ => _.ToString(), _ => RecipeTitle.Create(_))
            .HasMaxLength(RecipeTitle.MaxLenght);

        builder.OwnsOne(_ => _.Description)
            .Property(_ => _.Value)
            .HasColumnName(nameof(Recipe.Description))
            .HasConversion(_ => _.ToString(), _ => RecipeDescription.Create(_))
            .HasMaxLength(RecipeDescription.MaxLenght);

        builder.OwnsOne(_ => _.PreparationTime, ownedNavigationBuilder => { ownedNavigationBuilder.ToJson(); });

        builder.HasMany(_ => _.Ingredients).WithOne().IsRequired();

        builder.Ignore(_ => _.Events);
    }
}