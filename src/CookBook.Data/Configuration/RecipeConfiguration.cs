namespace CookBook.Data.Configuration;

public class RecipeConfiguration : IEntityTypeConfiguration<Recipe>
{
    public void Configure(EntityTypeBuilder<Recipe> builder)
    {
        builder.Property(x => x.Id)
            .HasConversion(x => x.Id, _ => (RecipeId)_)
            .IsRequired();

        builder.OwnsOne(_ => _.Title);
        builder.OwnsOne(_ => _.Description);

        builder.OwnsOne(_ => _.PreparationTime, ownedNavigationBuilder => { ownedNavigationBuilder.ToJson(); });

        builder.OwnsOne(_ => _.Ingredients, ownedNavigationBuilder =>
        {
            ownedNavigationBuilder.ToJson();
            ownedNavigationBuilder.OwnsMany(si => si.Lines);
        });

        builder.Ignore(_ => _.Events);
    }
}