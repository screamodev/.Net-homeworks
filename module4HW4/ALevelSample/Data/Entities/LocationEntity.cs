using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace ALevelSample.Data.Entities;

public class LocationEntity
{
    public int Id { get; set; }

    [Column("location_name")]
    public string LocationName { get; set; } = null!;

    public List<PetEntity> Pets { get; set; } = null!;
}