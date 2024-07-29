using Manticora.API.Models;
using Manticora.Domain.Interfaces;

using Microsoft.AspNetCore.Mvc;

using System.Diagnostics;

namespace Manticora.API.Controllers
{
    public class HomeController : Controller
    {
        private readonly ICharacterService _characterService;

        public HomeController(ICharacterService characterService)
        {
            _characterService = characterService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> SelectCharacter(int page = 1)
        {
            var characterPage = await _characterService.GetCharactersAsync(page);
            return View(characterPage);
        }

        public IActionResult BuyWeapons()
        {
            return View();
        }

        public IActionResult GetLocation()
        {
            return View();
        }

        public IActionResult StartRounds()
        {
            return View();
        }

        public IActionResult Summary()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
