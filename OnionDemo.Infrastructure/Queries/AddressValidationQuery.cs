using Newtonsoft.Json;
using OnionDemo.Application.Query;
using OnionDemo.Domain.ValueObjects;

public class AddressValidationQuery : IAddressValidationQuery
{
    private readonly IHttpClientFactory _httpClientFactory;

    public AddressValidationQuery(IHttpClientFactory httpClientFactory)
    {
        _httpClientFactory = httpClientFactory;
    }

    public bool ValidateAddress(Address address)
    {
        if (string.IsNullOrWhiteSpace(address.Street) ||
            string.IsNullOrWhiteSpace(address.City) ||
            string.IsNullOrWhiteSpace(address.PostalCode))
        {
            return false;
        }

        var client = _httpClientFactory.CreateClient();
        var response = client.GetAsync($"https://api.dataforsyningen.dk/adresser?q={address.Street} {address.City} {address.PostalCode}").Result;

        if (!response.IsSuccessStatusCode)
        {
            return false;
        }

        var content = response.Content.ReadAsStringAsync().Result;
        // Assuming the API returns a JSON array of addresses
        var addresses = JsonConvert.DeserializeObject<List<Address>>(content);

        return addresses.Any();
    }
}