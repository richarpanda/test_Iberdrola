﻿using Manticora.Domain.Entities;
using Manticora.Domain.ViewModels;

namespace Manticora.Domain.Interfaces
{
    public interface ICharacterService
    {
        Task<CharacterPage> GetCharactersAsync(int page = 1);
        Task<CharacterViewModel> GetCharacterByIdAsync(int characterId);
    }
}
