using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Sawnet.Core.BaseTypes;

namespace Sawnet.Infrastructure.Data.Extensions;

public static class ModelConfigurationExtensions
{
    public static void ConfigureComplexPrimaryKey<TModel, TKey>(this EntityTypeBuilder<TModel> builder)
        where TKey : EntityId
        where TModel : AggregateRoot<TKey>
    {
        builder.Property(x => x.Id)
            .HasConversion(x => x.Id, _ => _ as TKey)
            .IsRequired();
    }
}