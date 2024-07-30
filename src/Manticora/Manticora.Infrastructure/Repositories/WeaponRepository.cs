using Manticora.Domain.Entities.Db;
using Manticora.Domain.Interfaces;

using Microsoft.EntityFrameworkCore;

namespace Manticora.Infrastructure.Repositories
{
    public class WeaponRepository : IWeaponRepository
    {
        private readonly ManticoraDbContext _context;

        public WeaponRepository(ManticoraDbContext context)
        {
            _context = context;
        }

        public async Task<Weapon> GetByIdAsync(int id)
        {
            return await _context.Weapons.FirstOrDefaultAsync(w => w.WeaponId == id);
        }

        public async Task<List<Weapon>> GetAllAsync()
        {
            return await _context.Weapons.ToListAsync();
        }

        public async Task AddAsync(Weapon weapon)
        {
            _context.Weapons.Add(weapon);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Weapon weapon)
        {
            _context.Weapons.Update(weapon);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var weapon = await _context.Weapons.FindAsync(id);
            if (weapon != null)
            {
                _context.Weapons.Remove(weapon);
                await _context.SaveChangesAsync();
            }
        }
    }
}
