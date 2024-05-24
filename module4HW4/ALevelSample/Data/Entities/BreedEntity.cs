using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace ALevelSample.Data.Entities;

public class BreedEntity
{
    public int Id { get; set; }

    [Column("breed_name")]
    public string BreedName { get; set; } = null!;

    public CategoryEntity? Category { get; set; }

    public List<PetEntity> Pets { get; set; } = new List<PetEntity>();

    [Column("category_id")]
    public int CategoryId { get; set; }
}