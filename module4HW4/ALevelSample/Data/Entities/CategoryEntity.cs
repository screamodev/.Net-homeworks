using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace ALevelSample.Data.Entities;

public class CategoryEntity
{
    public int Id { get; set; }

    [Column("category_name")]
    public string CategoryName { get; set; } = null!;

    public List<PetEntity> Pets { get; set; } = new List<PetEntity>();

    public List<BreedEntity> Breeds { get; set; } = new List<BreedEntity>();
}