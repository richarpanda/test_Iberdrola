using Manticora.Domain.Entities;

namespace Manticora.Domain.Interfaces
{
    public interface ICharacterService
    {
        Task<List<Character>> GetCharactersAsync();
        Task<Character> GetCharacterByIdAsync(int characterId);
    }
}
