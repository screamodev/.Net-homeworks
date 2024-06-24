using ALevelSample.Data.Entities;
using ALevelSample.Data.EntityConfigurations;
using Microsoft.EntityFrameworkCore;

namespace ALevelSample.Data;

public class ApplicationDbContext : DbContext
{
    public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
        : base(options)
    {
    }

    public DbSet<PetEntity> Pets { get; set; } = null!;
    public DbSet<BreedEntity> Breeds { get; set; } = null!;
    public DbSet<CategoryEntity> Categories { get; set; } = null!;
    public DbSet<LocationEntity> Locations { get; set; } = null!;

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new PetEntityConfig());
        modelBuilder.ApplyConfiguration(new LocationEntityConfig());
        modelBuilder.ApplyConfiguration(new BreedEntityConfig());
        modelBuilder.ApplyConfiguration(new CategoryEntityConfig());
        modelBuilder.UseHiLo();
    }
}