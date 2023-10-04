using System.Text.Json.Serialization;

namespace NeedleWork.Infrastructure.Models;

public class ViaCepAddress
{
    [JsonPropertyName("cep")]
    public string Cep { get; init; } = string.Empty;
    
    [JsonPropertyName("logradouro")]
    public string Street { get; init; } = string.Empty;

    [JsonPropertyName("bairro")]
    public string Neighborhood { get; init; } = string.Empty;

    [JsonPropertyName("uf")]
    public string State { get; init; } = string.Empty;
    
    [JsonPropertyName("localidade")]
    public string City { get; init; } = string.Empty;
}