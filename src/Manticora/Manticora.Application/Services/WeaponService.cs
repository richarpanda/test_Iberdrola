using Manticora.Domain.Entities.Db;
using Manticora.Domain.Interfaces;

namespace Manticora.Application.Services
{
    public class WeaponService : IWeaponService
    {
        private readonly IWeaponRepository _weaponRepository;

        public WeaponService(IWeaponRepository weaponRepository)
        {
            _weaponRepository = weaponRepository;
        }

        public async Task<List<Weapon>> GetWeaponsAsync()
        {
            return await _weaponRepository.GetAllAsync();
        }

        public async Task<Weapon> GetWeaponByIdAsync(int weaponId)
        {
            return await _weaponRepository.GetByIdAsync(weaponId);
        }
    }
}
