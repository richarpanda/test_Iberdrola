using Manticora.Domain.Entities;

namespace Manticora.Domain.Interfaces
{
    public interface ILocationService
    {
        Task<List<Location>> GetLocationsAsync();
    }
}
