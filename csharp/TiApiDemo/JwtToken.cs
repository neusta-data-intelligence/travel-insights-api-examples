using System.Text.Json.Serialization;

namespace TiApiDemo;

public class JwtToken
{
    [JsonPropertyName("access_token")] public required string AccessToken { get; init; }
};