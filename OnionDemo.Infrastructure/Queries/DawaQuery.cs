using Azure;
using OnionDemo.Application.Query;
using OnionDemo.Domain.ValueObjects;

namespace OnionDemo.Infrastructure.Queries;

public class DawaQuery : IDawaQuery
{
    private readonly HttpClient _httpClient;
    
    public DawaQuery(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }
    public string GetAddressData(string query)
    {
        var response = _httpClient.GetAsync($"https://api.dataforsyningen.dk/adresser?q={query}").Result;
        response.EnsureSuccessStatusCode();
        return response.Content.ReadAsStringAsync().Result;
    }

    public bool ValidateAddress(Address address)
    {
        throw new NotImplementedException();
    }
}