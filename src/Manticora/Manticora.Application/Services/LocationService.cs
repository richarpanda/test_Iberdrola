using Manticora.Domain.Entities;
using Manticora.Domain.Entities.Db;
using Manticora.Domain.Interfaces;

namespace Manticora.Application.Services
{
    public class LocationService
    {
        private readonly ILocationApiService _locationService;

        public LocationService(ILocationApiService locationService)
        {
            _locationService = locationService;
        }

        public async Task<AttackingNation> GetLocationsAsync()
        {
            return await _locationService.GetRandomLocationAsync();
        }
    }
}
