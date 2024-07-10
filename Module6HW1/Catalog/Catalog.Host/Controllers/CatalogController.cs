using Microsoft.AspNetCore.Mvc;

namespace Catalog.Host.Controllers;

[ApiController]
[Route("[controller]")]
public class CatalogController : ControllerBase
{
    private static readonly string[] Products = new[]
    {
        "Apple", "Watermelon", "Melon", "Pickle", "Tomato", "Pear", 
        "Coconut", "Onion"
    };

    [HttpGet]
    public IEnumerable<Product> Get()
    {
        return Enumerable.Range(1, 5).Select(index => new Product
            {
                Name = Products[Random.Shared.Next(Products.Length)],
                Price = Random.Shared.Next(0, 55),
            })
            .ToArray();
    }
}