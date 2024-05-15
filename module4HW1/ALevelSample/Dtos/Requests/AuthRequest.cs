using Newtonsoft.Json;

namespace ALevelSample.Dtos.Requests;

public class AuthRequest
{
    [JsonProperty(PropertyName = "email")]
    public string Email { get; set; }
    [JsonProperty(PropertyName = "password")]
    public string Password { get; set; }
}