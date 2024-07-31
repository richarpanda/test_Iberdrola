using Manticora.Domain.Entities;
using Manticora.Domain.Interfaces;
using Manticora.Domain.ViewModels;

namespace Manticora.Application.Services
{
    public class CharacterService : ICharacterService
    {
        private readonly ICharacterApiService _characterApiService;

        public CharacterService(ICharacterApiService characterApiService)
        {
            _characterApiService = characterApiService;
        }

        public async Task<CharacterViewModel> GetCharacterByIdAsync(int characterId)
        {
            return await _characterApiService.GetCharacterByIdAsync(characterId);
        }

        public async Task<CharacterPage> GetCharactersAsync(int page = 1)
        {
            return await _characterApiService.GetCharactersAsync(page);
        }
    }
}