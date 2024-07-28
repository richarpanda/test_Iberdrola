using Manticora.Domain.Entities;
using Manticora.Domain.Interfaces;

namespace Manticora.Application.Services
{
    public class CharacterService : ICharacterService
    {
        private readonly ICharacterService _characterApiService;

        public CharacterService(ICharacterService characterApiService)
        {
            _characterApiService = characterApiService;
        }

        public async Task<List<Character>> GetCharactersAsync()
        {
            return await _characterApiService.GetCharactersAsync();
        }

        public async Task<Character> GetCharacterByIdAsync(int characterId)
        {
            return await _characterApiService.GetCharacterByIdAsync(characterId);
        }
    }
}