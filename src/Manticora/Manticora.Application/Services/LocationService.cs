using Manticora.Domain.Entities;
using Manticora.Domain.Interfaces;

using System.Collections.Generic;
using System.Threading.Tasks;

namespace Manticora.Application.Services
{
    public class LocationService
    {
        private readonly ILocationApiService _locationService;

        public LocationService(ILocationApiService locationService)
        {
            _locationService = locationService;
        }

        public async Task<List<Location>> GetLocationsAsync()
        {
            return await _locationService.GetLocationsAsync();
        }
    }
}
