using System.Net.Http.Json;
using Microsoft.Extensions.Configuration;
using NeedleWork.Core.Services;
using NeedleWork.Infrastructure.Models;

namespace NeedleWork.Infrastructure.Services;

public class ViaCepService : IViaCepService
{
    private readonly string ViaCepUrl;
    private readonly IHttpClientFactory _factory;

    public ViaCepService(IConfiguration configuration, IHttpClientFactory factory)
    {
        _factory = factory;
        ViaCepUrl = configuration["ViaCep:Url"]!;
    }

    public async Task<ViaCepAddress?> GetAddressAsync(string cep)
    {
        HttpClient client = _factory.CreateClient();

        client.BaseAddress = new Uri(ViaCepUrl);

        ViaCepAddress? address = await client
            .GetFromJsonAsync<ViaCepAddress>($"{cep}/json");

        return address;
    }

}