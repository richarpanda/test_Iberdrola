using Manticora.Domain.Entities;

namespace Manticora.Domain.Interfaces
{
    public interface ILocationApiService
    {
        Task<List<Location>> GetLocationsAsync();
    }
}
