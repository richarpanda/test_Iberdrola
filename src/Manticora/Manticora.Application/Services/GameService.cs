using Manticora.Domain.Entities.Db;
using Manticora.Domain.Interfaces;
using Manticora.Domain.ViewModels;

using Microsoft.EntityFrameworkCore;

public class GameService : IGameService
{
    private readonly ManticoraDbContext _context;
    private readonly ICharacterService _characterService;

    public GameService(ManticoraDbContext context, ICharacterService characterService)
    {
        _context = context;
        _characterService = characterService;
    }

    public async Task<Game> StartNewGameAsync(int attackingNationId)
    {
        try
        {
            var game = new Game
            {
                AttackingNationId = attackingNationId,
                CityHealth = 15,
                ManticoreHealth = 10,
                StartDateTime = DateTime.UtcNow,
                GameStatus = "active",
                Round = 1
            };

            _context.Games.Add(game);
            await _context.SaveChangesAsync();

            return game;
        }
        catch (Exception ex)
        {

            throw;
        }
    }

    public async Task<Game> GetGameStateAsync(int gameId)
    {
        return await _context.Games
            .Include(g => g.Attacks)
            .Include(g => g.Defenders)
            .FirstOrDefaultAsync(g => g.GameId == gameId);
    }

    public async Task<AttackResultViewModel> ProcessAttackAsync(int defenderId, int gameId, int weaponId)
    {
        var game = await _context.Games.FindAsync(gameId);
        var defender = await _context.Defenders.FindAsync(defenderId);
        var weapon = await _context.Weapons.FindAsync(weaponId);

        var random = new Random();
        var distanceToManticore = random.Next(1, 6) * 10; // Distance in multiples of 10 between 10 and 50

        int manticoreDamage = 0;
        int cityDamage = 0;
        string shotResult;

        if (weapon.Range > distanceToManticore)
        {
            manticoreDamage = 2;
            cityDamage = 1;
            shotResult = "Corto";
        }
        else if (weapon.Range == distanceToManticore)
        {
            manticoreDamage = 5;
            shotResult = "Directo";
        }
        else
        {
            cityDamage = 5;
            shotResult = "Largo";
        }

        game.ManticoreHealth -= manticoreDamage;
        game.CityHealth -= cityDamage;
        game.Round++;

        var attack = new Attack
        {
            GameId = gameId,
            DefenderId = defenderId,
            WeaponId = weaponId,
            Distance = distanceToManticore,
            ManticoreDamage = manticoreDamage,
            CityDamage = cityDamage,
            Round = game.Round,
            AttackDateTime = DateTime.UtcNow
        };

        _context.Attacks.Add(attack);
        await _context.SaveChangesAsync();

        var character = await _characterService.GetCharacterByIdAsync(defender.CharacterId);

        var result = new AttackResultViewModel
        {
            Round = game.Round,
            CityHealth = game.CityHealth,
            ManticoreHealth = game.ManticoreHealth,
            StatusMessage = $"Ronda {game.Round}: La Mantícora está a una distancia de {distanceToManticore}, el ataque con {weapon.Name} cubre una distancia de {weapon.Range} y fue un tiro {shotResult}. La ciudad recibió {cityDamage} puntos de daño y la Mantícora recibió {manticoreDamage} puntos de daño.",
            DefenderName = character.Name,
            WeaponName = weapon.Name,
            WeaponRange = weapon.Range,
            DistanceToManticore = distanceToManticore,
            ShotResult = shotResult
        };

        return result;
    }

    public async Task EndGameAsync(int gameId)
    {
        var game = await _context.Games.FindAsync(gameId);
        if (game != null)
        {
            game.GameStatus = "completed";
            await _context.SaveChangesAsync();
        }
    }
}
