using Manticora.Domain.Entities;
using System.Text.Json.Serialization;

namespace Manticora.Infrastructure.Services.LocationModels
{
    public class LocationApiResponse
    {
        [JsonPropertyName("info")]
        public LocationInfo Info { get; set; }
        [JsonPropertyName("results")]
        public List<Location> Results { get; set; }
    }
}