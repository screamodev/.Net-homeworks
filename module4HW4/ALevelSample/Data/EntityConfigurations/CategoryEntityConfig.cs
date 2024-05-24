using System.Collections;
using ALevelSample.Data.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ALevelSample.Data.EntityConfigurations;

public class CategoryEntityConfig : IEntityTypeConfiguration<CategoryEntity>
{
    public void Configure(EntityTypeBuilder<CategoryEntity> builder)
    {
        builder.HasKey(h => h.Id);
        builder.Property(p => p.CategoryName).IsRequired();

        builder.HasMany(h => h.Pets)
            .WithOne(h => h.Category)
            .HasForeignKey(h => h.CategoryId)
            .OnDelete(DeleteBehavior.NoAction);

        builder.HasMany(h => h.Breeds)
            .WithOne(h => h.Category)
            .HasForeignKey(h => h.CategoryId)
            .OnDelete(DeleteBehavior.NoAction);
    }
}