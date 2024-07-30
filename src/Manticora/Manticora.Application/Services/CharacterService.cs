﻿using Manticora.Domain.Entities;
using Manticora.Domain.Interfaces;

namespace Manticora.Application.Services
{
    public class CharacterService : ICharacterService
    {
        private readonly ICharacterApiService _characterApiService;

        public CharacterService(ICharacterApiService characterApiService)
        {
            _characterApiService = characterApiService;
        }

        public async Task<Character> GetCharacterByIdAsync(int characterId)
        {
            return await _characterApiService.GetCharacterByIdAsync(characterId);
        }

        public async Task<CharacterPage> GetCharactersAsync(int page = 1)
        {
            return await _characterApiService.GetCharactersAsync(page);
        }
    }
}