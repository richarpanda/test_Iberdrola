using Manticora.Domain.Entities.Db;
using Manticora.Domain.Interfaces;
using Manticora.Infrastructure.Services.LocationModels;
using System.Text.Json;

public class LocationApiService : ILocationApiService
{
    private readonly HttpClient _httpClient;
    private readonly ManticoraDbContext _context;

    public LocationApiService(HttpClient httpClient, ManticoraDbContext context)
    {
        _httpClient = httpClient;
        _context = context;
    }

    public async Task<AttackingNation> GetRandomLocationAsync()
    {
        var response = await _httpClient.GetAsync("https://rickandmortyapi.com/api/location");
        response.EnsureSuccessStatusCode();
        var jsonString = await response.Content.ReadAsStringAsync();
        var locations = JsonSerializer.Deserialize<LocationApiResponse>(jsonString);

        var random = new Random();
        var selectedLocation = locations.Results[random.Next(locations.Results.Count)];

        var attackingNation = new AttackingNation
        {
            Name = selectedLocation.Name,
            Type = selectedLocation.Type,
            Dimension = selectedLocation.Dimension,
            Population = selectedLocation.Residents.Count
        };

        _context.AttackingNations.Add(attackingNation);
        await _context.SaveChangesAsync();

        return attackingNation;
    }
}