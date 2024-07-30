using Manticora.Domain.Entities.Db;

namespace Manticora.Domain.Interfaces
{
    public interface IDefenderService
    {
        Task<int> AddDefenderAsync(int characterId, int gold);
        Task BuyWeaponAsync(int defenderId, int weaponId);
        Task UpdateCharacterGoldAsync(int defenderId, int newGoldAmount);
        Task<List<Weapon>> GetWeaponsByDefenderIdAsync(int defenderId);
    }
}