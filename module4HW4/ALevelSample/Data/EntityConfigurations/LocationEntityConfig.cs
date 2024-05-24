using ALevelSample.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ALevelSample.Data.EntityConfigurations;

public class LocationEntityConfig : IEntityTypeConfiguration<LocationEntity>
{
    public void Configure(EntityTypeBuilder<LocationEntity> builder)
    {
        builder.HasKey(h => h.Id);
        builder.Property(p => p.LocationName).IsRequired();

        builder.HasMany(h => h.Pets)
            .WithOne(h => h.Location)
            .HasForeignKey(h => h.LocationId)
            .OnDelete(DeleteBehavior.NoAction);
    }
}