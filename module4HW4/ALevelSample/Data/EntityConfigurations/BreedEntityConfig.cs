using ALevelSample.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ALevelSample.Data.EntityConfigurations;

public class BreedEntityConfig : IEntityTypeConfiguration<BreedEntity>
{
    public void Configure(EntityTypeBuilder<BreedEntity> builder)
    {
        builder.HasKey(h => h.Id);
        builder.Property(p => p.BreedName).IsRequired();

        builder.HasOne(h => h.Category)
            .WithMany(h => h.Breeds)
            .HasForeignKey(h => h.CategoryId)
            .OnDelete(DeleteBehavior.Cascade);
    }
}