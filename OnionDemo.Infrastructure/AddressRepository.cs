using System.Net.Http.Json;
using OnionDemo.Application.IRepository;
using OnionDemo.Domain.ValueObjects;

namespace OnionDemo.Infrastructure;

public class AddressRepository : IAddressRepository
{
    private readonly HttpClient _httpClient;
    
    public AddressRepository(HttpClient httpClient)
    {
        _httpClient = httpClient;
    }

    public void NotifyBookMyHome(string addressKey, AddressValidationStatus status)
    {
        var response = _httpClient.PostAsJsonAsync("", new { addressKey, status }).Result;
        response.EnsureSuccessStatusCode();
    }
}