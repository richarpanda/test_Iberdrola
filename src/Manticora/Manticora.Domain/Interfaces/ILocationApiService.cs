using Manticora.Domain.Entities.Db;

namespace Manticora.Domain.Interfaces
{
    public interface ILocationApiService
    {
        Task<AttackingNation> GetRandomLocationAsync();
    }
}
