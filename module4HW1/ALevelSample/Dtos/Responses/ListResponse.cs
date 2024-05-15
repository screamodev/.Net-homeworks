using System.Collections.Generic;
using Newtonsoft.Json;

namespace ALevelSample.Dtos.Responses;

public class ListResponse<T>
    where T : class
{
    public List<T> Data { get; set; }
    public int Page { get; set; }
    [JsonProperty(PropertyName = "per_page")]
    public int PerPage { get; set; }
    public int Total { get; set; }
    [JsonProperty(PropertyName = "total_pages")]
    public int TotalPages { get; set; }
}