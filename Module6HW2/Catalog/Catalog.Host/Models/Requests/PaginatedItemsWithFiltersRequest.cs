namespace Catalog.Host.Models.Requests;

public class PaginatedItemsWithFiltersRequest : PaginatedItemsRequest
{
    public string? Type { get; set; }
    public string? Brand { get; set; }
}