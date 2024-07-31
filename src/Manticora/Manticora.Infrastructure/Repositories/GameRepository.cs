using Manticora.Domain.Entities.Db;
using Manticora.Domain.Interfaces;
using Manticora.Domain.ViewModels;

using Microsoft.EntityFrameworkCore;

namespace Manticora.Infrastructure.Repositories
{
    public class GameRepository : IGameRepository
    {
        private readonly ManticoraDbContext _context;

        public GameRepository(ManticoraDbContext context)
        {
            _context = context;
        }

        public async Task<Game> GetGameAsync(int gameId)
        {
            return await _context.Games
                .Include(g => g.Defenders)
                .ThenInclude(d => d.Inventories)
                .ThenInclude(i => i.Weapon)
                .Include(g => g.Attacks)
                .FirstOrDefaultAsync(g => g.GameId == gameId);
        }

        public async Task<AttackResult> ProcessAttackAsync(int defenderId, int gameId, int weaponId)
        {
            var game = await _context.Games
                .Include(g => g.Defenders)
                .ThenInclude(d => d.Inventories)
                .FirstOrDefaultAsync(g => g.GameId == gameId);

            var defender = game.Defenders.FirstOrDefault(d => d.DefenderId == defenderId);
            var weapon = defender.Inventories.FirstOrDefault(i => i.WeaponId == weaponId).Weapon;

            var distance = new Random().Next(1, 6) * 10;

            int manticoreDamage;
            int cityDamage;
            string shotType;

            if (weapon.Range < distance)
            {
                manticoreDamage = 0;
                cityDamage = 5;
                shotType = "Short";
            }
            else if (weapon.Range > distance)
            {
                manticoreDamage = 2;
                cityDamage = 1;
                shotType = "Long";
            }
            else
            {
                manticoreDamage = 5;
                cityDamage = 0;
                shotType = "Direct";
            }

            game.ManticoreHealth -= manticoreDamage;
            game.CityHealth -= cityDamage;
            game.Round++;

            await _context.SaveChangesAsync();

            return new AttackResult
            {
                Round = game.Round,
                CityHealth = game.CityHealth,
                ManticoreHealth = game.ManticoreHealth,
                StatusMessage = $"The Manticore is at a distance of {distance}. The attack with {weapon.Name} covered a distance of {weapon.Range} and was a {shotType} shot. The city received {cityDamage} points of damage. The Manticore received {manticoreDamage} points of damage."
            };
        }
    }
}
