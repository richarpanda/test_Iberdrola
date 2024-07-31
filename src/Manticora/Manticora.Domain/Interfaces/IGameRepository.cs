using Manticora.Domain.Entities.Db;
using Manticora.Domain.ViewModels;

namespace Manticora.Domain.Interfaces
{
    public interface IGameRepository
    {
        Task<Game> GetGameAsync(int gameId);
        Task<AttackResult> ProcessAttackAsync(int defenderId, int gameId, int weaponId);
    }
}
