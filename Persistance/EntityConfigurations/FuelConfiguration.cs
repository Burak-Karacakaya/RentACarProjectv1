using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistance.EntityConfigurations;

public class FuelConfiguration : IEntityTypeConfiguration<Fuel>
{
    public void Configure(EntityTypeBuilder<Fuel> builder)
    {
        builder.ToTable("Fuels").HasKey(b => b.Id);

        builder.Property(b => b.Id).HasColumnName("Id").IsRequired();
        builder.Property(b => b.Id).HasColumnName("Name").IsRequired();
        builder.Property(b => b.Id).HasColumnName("CreatedDate").IsRequired();
        builder.Property(b => b.Id).HasColumnName("UpdatedDate");
        builder.Property(b => b.Id).HasColumnName("DeletedDate");

        builder.HasIndex(indexExpression: b => b.Name,name: "UK_Fuels_Name").IsUnique();
        builder.HasMany(b => b.Models);
        builder.HasQueryFilter(b => !b.DeletedDate.HasValue);
    }
}