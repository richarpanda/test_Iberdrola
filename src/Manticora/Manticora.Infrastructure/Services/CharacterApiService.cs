using System.Text.Json;
using Manticora.Domain.Entities;
using Manticora.Domain.Interfaces;
using Manticora.Infrastructure.Services.CharacterModels;
using System.Net.Http.Headers;

namespace Manticora.Infrastructure.Services
{
    public class CharacterApiService : ICharacterService
    {
        private readonly HttpClient _httpClient;

        public CharacterApiService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<CharacterPage> GetCharactersAsync(int page = 1)
        {
            var response = await _httpClient.GetAsync($"https://rickandmortyapi.com/api/character?page={page}");
            response.EnsureSuccessStatusCode();

            var jsonString = await response.Content.ReadAsStringAsync();
            var characterApiResponse = JsonSerializer.Deserialize<CharacterApiResponse>(jsonString, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

            var characters = characterApiResponse.Results.Select(c => new Character
            {
                CharacterId = c.Id,
                Name = c.Name,
                Status = c.Status,
                Species = c.Species,
                Type = c.Type,
                Gender = c.Gender,
                Origin = c.Origin.Name,
                Location = c.Location.Name,
                Image = c.Image,
                Episode = c.Episode,
                Url = c.Url,
                Created = c.Created,
                Gold = 100  // Default value for demonstration purposes
            }).ToList();

            return new CharacterPage
            {
                Characters = characters,
                TotalCount = characterApiResponse.Info.Count,
                TotalPages = characterApiResponse.Info.Pages,
                CurrentPage = page
            };
        }

        public async Task<Character> GetCharacterByIdAsync(int characterId)
        {
            var response = await _httpClient.GetAsync($"https://rickandmortyapi.com/api/character/{characterId}");
            response.EnsureSuccessStatusCode();

            var jsonString = await response.Content.ReadAsStringAsync();
            var characterApiModel = JsonSerializer.Deserialize<CharacterApiModel>(jsonString, new JsonSerializerOptions { PropertyNameCaseInsensitive = true });

            var character = new Character
            {
                CharacterId = characterApiModel.Id,
                Name = characterApiModel.Name,
                Status = characterApiModel.Status,
                Species = characterApiModel.Species,
                Type = characterApiModel.Type,
                Gender = characterApiModel.Gender,
                Origin = characterApiModel.Origin.Name,
                Location = characterApiModel.Location.Name,
                Image = characterApiModel.Image,
                Episode = characterApiModel.Episode,
                Url = characterApiModel.Url,
                Created = characterApiModel.Created,
                Gold = 100  // Default value for demonstration purposes
            };

            return character;
        }
    }
}
