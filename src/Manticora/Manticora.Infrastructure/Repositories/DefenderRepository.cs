using Manticora.Domain.Entities.Db;
using Manticora.Domain.Interfaces;

using Microsoft.EntityFrameworkCore;

namespace Manticora.Infrastructure.Repositories
{
    public class DefenderRepository : IDefenderRepository
    {
        private readonly ManticoraDbContext _context;

        public DefenderRepository(ManticoraDbContext context)
        {
            _context = context;
        }

        public async Task<int> AddAsync(Defender defender)
        {
            try
            {
                _context.Defenders.Add(defender);
                await _context.SaveChangesAsync();
                return defender.DefenderId;
            }
            catch (Exception ex)
            {
                throw;
            }
        }

        public async Task<Defender> GetByIdAsync(int id)
        {
            return await _context.Defenders.FirstOrDefaultAsync(d => d.DefenderId == id);
        }

        public async Task UpdateAsync(Defender defender)
        {
            _context.Defenders.Update(defender);
            await _context.SaveChangesAsync();
        }

        public List<Weapon> GetWeaponsByDefenderIdAsync(int defenderId)
        {
            return _context.Inventories
            .Where(i => i.DefenderId == defenderId)
            .Select(i => i.Weapon)
            .ToList();
        }
    }
}
