using Manticora.Domain.Entities.Db;

namespace Manticora.Domain.Interfaces
{
    public interface IWeaponService
    {
        Task<List<Weapon>> GetWeaponsAsync();
        Task<Weapon> GetWeaponByIdAsync(int weaponId);
    }
}