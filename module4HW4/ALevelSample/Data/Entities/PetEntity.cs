using System.ComponentModel.DataAnnotations.Schema;

namespace ALevelSample.Data.Entities;

public class PetEntity
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public int Age { get; set; }

    [Column("image_url")]
    public string? ImageUrl { get; set; }

    public string? Description { get; set; }

    public CategoryEntity? Category { get; set; }

    public BreedEntity? Breed { get; set; }

    public LocationEntity? Location { get; set; }

    [Column("category_id")]
    public int CategoryId { get; set; }

    [Column("breed_id")]
    public int BreedId { get; set; }

    [Column("location_id")]
    public int LocationId { get; set; }
}