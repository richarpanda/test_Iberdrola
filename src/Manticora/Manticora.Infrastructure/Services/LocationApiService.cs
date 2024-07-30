using Manticora.Domain.Entities;
using Manticora.Domain.Interfaces;

using System.Text.Json;
using System.Text.Json.Serialization;

namespace Manticora.Infrastructure.Services
{
    public class LocationApiService : ILocationApiService
    {
        private readonly HttpClient _httpClient;

        public LocationApiService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<List<Location>> GetLocationsAsync()
        {
            var response = await _httpClient.GetAsync("https://rickandmortyapi.com/api/location");
            response.EnsureSuccessStatusCode();

            var jsonString = await response.Content.ReadAsStringAsync();
            var locationResponse = JsonSerializer.Deserialize<LocationResponse>(jsonString, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

            return locationResponse.Results;
        }
    }

    public class LocationResponse
    {
        [JsonPropertyName("results")]
        public List<Location> Results { get; set; }
    }
}
