using Manticora.Domain.Entities.Db;
using Manticora.Domain.ViewModels;

namespace Manticora.Domain.Interfaces
{
    public interface IGameService
    {
        Task<Game> StartNewGameAsync(int attackingNationId);
        Task<Game> GetGameStateAsync(int gameId);
        Task<AttackResultViewModel> ProcessAttackAsync(int defenderId, int gameId, int weaponId);
        Task EndGameAsync(int gameId);
    }

}
