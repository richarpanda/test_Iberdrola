using Microsoft.AspNetCore.Mvc;
using Manticora.Application.Services;
using Manticora.Domain.Entities;

namespace Manticora.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CharacterController : ControllerBase
    {
        private readonly CharacterService _characterService;

        public CharacterController(CharacterService characterService)
        {
            _characterService = characterService;
        }

        [HttpGet]
        public async Task<IActionResult> GetCharacters()
        {
            var characters = await _characterService.GetCharactersAsync();
            return Ok(characters);
        }

        [HttpGet("{characterId}")]
        public async Task<IActionResult> GetCharacter(int characterId)
        {
            var character = await _characterService.GetCharacterByIdAsync(characterId);
            return Ok(character);
        }
    }
}
