namespace Catalog.Host.Models.Requests;

public class PaginatedItemsByBrandRequest : PaginatedItemsRequest
{
    public string Brand { get; set; } = null!;
}