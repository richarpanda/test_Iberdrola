using Manticora.Domain.Entities.Db;
using Manticora.Domain.Interfaces;

namespace Manticora.Application.Services
{
    public class DefenderService : IDefenderService
    {
        private readonly IDefenderRepository _defenderRepository;
        private readonly IWeaponRepository _weaponRepository;
        private readonly IInventoryRepository _inventoryRepository;

        public DefenderService(IDefenderRepository defenderRepository, IWeaponRepository weaponRepository, IInventoryRepository inventoryRepository)
        {
            _defenderRepository = defenderRepository;
            _weaponRepository = weaponRepository;
            _inventoryRepository = inventoryRepository;
        }

        public async Task<int> AddDefenderAsync(int characterId, int gold)
        {
            
            var defender = new Defender
            {
                CharacterId = characterId,
                Gold = gold
            };

            return await _defenderRepository.AddAsync(defender);
        }

        public async Task BuyWeaponAsync(int defenderId, int weaponId)
        {
            var defender = await _defenderRepository.GetByIdAsync(defenderId);
            var weapon = await _weaponRepository.GetByIdAsync(weaponId);

            if (defender == null || weapon == null)
            {
                throw new ArgumentException("Defender or weapon not found");
            }

            if (defender.Gold < weapon.Cost)
            {
                throw new InvalidOperationException("Not enough gold to buy this weapon");
            }

            defender.Gold -= weapon.Cost;
            await _defenderRepository.UpdateAsync(defender);

            var inventory = new Inventory
            {
                DefenderId = defenderId,
                WeaponId = weaponId,
                Quantity = 1
            };
            await _inventoryRepository.AddAsync(inventory);
        }

        public async Task<List<Weapon>> GetWeaponsByDefenderIdAsync(int defenderId)
        {
            return await _defenderRepository.GetWeaponsByDefenderIdAsync(defenderId);
        }

        public async Task UpdateCharacterGoldAsync(int defenderId, int newGoldAmount)
        {
            var defender = await _defenderRepository.GetByIdAsync(defenderId);
            if (defender != null)
            {
                defender.Gold = newGoldAmount;
                await _defenderRepository.UpdateAsync(defender);
            }
        }
    }
}
