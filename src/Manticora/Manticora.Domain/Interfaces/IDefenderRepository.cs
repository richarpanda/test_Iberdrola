using Manticora.Domain.Entities.Db;

namespace Manticora.Domain.Interfaces
{
    public interface IDefenderRepository
    {
        Task<int> AddAsync(Defender defender);
        Task<Defender> GetByIdAsync(int id);
        Task UpdateAsync(Defender defender);
        Task<List<Weapon>> GetWeaponsByDefenderIdAsync(int defenderId);
    }
}