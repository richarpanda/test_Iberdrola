using Manticora.Domain.Entities;

namespace Manticora.Domain.Interfaces
{
    public interface ICharacterService
    {
        Task<CharacterPage> GetCharactersAsync(int page = 1);
        Task<Character> GetCharacterByIdAsync(int characterId);
    }
}
