using ALevelSample.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ALevelSample.Data.EntityConfigurations;

public class PetEntityConfig : IEntityTypeConfiguration<PetEntity>
{
    public void Configure(EntityTypeBuilder<PetEntity> builder)
    {
        builder.HasKey(h => h.Id);

        builder.HasOne(h => h.Category)
            .WithMany(h => h.Pets)
            .HasForeignKey(h => h.CategoryId)
            .OnDelete(DeleteBehavior.NoAction);

        builder.HasOne(h => h.Breed)
            .WithMany(h => h.Pets)
            .HasForeignKey(h => h.BreedId)
            .OnDelete(DeleteBehavior.NoAction);

        builder.HasOne(h => h.Location)
            .WithMany(h => h.Pets)
            .HasForeignKey(h => h.LocationId)
            .OnDelete(DeleteBehavior.NoAction);
    }
}