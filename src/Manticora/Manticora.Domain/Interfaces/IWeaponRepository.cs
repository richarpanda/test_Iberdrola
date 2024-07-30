using Manticora.Domain.Entities.Db;

namespace Manticora.Domain.Interfaces
{
    public interface IWeaponRepository
    {
        Task<Weapon> GetByIdAsync(int id);
        Task<List<Weapon>> GetAllAsync();
        Task AddAsync(Weapon weapon);
        Task UpdateAsync(Weapon weapon);
        Task DeleteAsync(int id);
    }
}
