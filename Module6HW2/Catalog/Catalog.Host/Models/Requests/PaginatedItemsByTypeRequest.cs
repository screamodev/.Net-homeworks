namespace Catalog.Host.Models.Requests;

public class PaginatedItemsByTypeRequest : PaginatedItemsRequest
{
    public string Type { get; set; } = null!;
}