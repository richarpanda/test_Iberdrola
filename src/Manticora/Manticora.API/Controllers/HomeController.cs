using Manticora.API.Models;
using Manticora.Domain.Entities;
using Manticora.Domain.Interfaces;
using Manticora.Domain.ViewModels;

using Microsoft.AspNetCore.Mvc;

using Newtonsoft.Json;

using System.Diagnostics;

namespace Manticora.API.Controllers
{
    public class HomeController : Controller
    {
        private readonly ICharacterService _characterService;
        private readonly IDefenderService _defenderService;
        private readonly IWeaponService _weaponService;

        public HomeController(ICharacterService characterService, IDefenderService defenderService, IWeaponService weaponService)
        {
            _characterService = characterService;
            _defenderService = defenderService;
            _weaponService = weaponService;
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

        [HttpPost]
        public async Task<IActionResult> SelectCharacters(List<int> selectedCharacterIds)
        {
            if (selectedCharacterIds == null || selectedCharacterIds.Count != 2)
            {
                ModelState.AddModelError("", "Debe seleccionar exactamente dos personajes.");
                return RedirectToAction("SelectCharacter");
            }

            List<Character> characterList = new List<Character>();

            foreach (var characterId in selectedCharacterIds)
            {
                var defenderId = await _defenderService.AddDefenderAsync(characterId, 100);
                characterList.Add(new Character() { CharacterId = characterId, DefenderId = defenderId });
            }

            var viewModel = new BuyWeaponsViewModel
            {
                Characters = characterList
            };
            TempData["BuyWeaponsViewModel"] = JsonConvert.SerializeObject(viewModel);

            return RedirectToAction("BuyWeapons");
        }

        public async Task<IActionResult> BuyWeapons(BuyWeaponsViewModel viewModel)
        {
            if (TempData["SelectedDefenderId"] != null)
            {
                viewModel.SelectedDefenderId = (int)TempData["SelectedDefenderId"];
            }

            var buyWeaponsViewModel = new BuyWeaponsViewModel();
            if (TempData["BuyWeaponsViewModel"] != null)
                buyWeaponsViewModel = JsonConvert.DeserializeObject<BuyWeaponsViewModel>((string)TempData["BuyWeaponsViewModel"]);

            if (viewModel == null || viewModel.Characters == null || viewModel.Characters.Count == 0)
            {
                viewModel = new BuyWeaponsViewModel();
                viewModel.Characters = new List<Character>();
                foreach (var characterId in buyWeaponsViewModel.Characters.Select(c => c.CharacterId))
                {
                    var character = new Character();
                    character = await _characterService.GetCharacterByIdAsync(characterId);
                    character.DefenderId = buyWeaponsViewModel.Characters.Where(x => x.CharacterId == characterId).FirstOrDefault().DefenderId;

                    viewModel.Characters.Add(character);
                }
                viewModel.Weapons = await _weaponService.GetWeaponsAsync();
            }
            TempData["BuyWeaponsViewModel"] = TempData["BuyWeaponsViewModel"];

            return View(viewModel);
        }


        [HttpPost]
        public async Task<IActionResult> BuyWeapon(int selectedDefenderId, int selectedWeaponId)
        {
            if (selectedDefenderId <= 0 || selectedWeaponId <= 0)
            {
                TempData["Errors"] = "Debe seleccionar un defensor y un arma.";
                var viewModel = await GetBuyWeaponsViewModelAsync();
                return View("BuyWeapons", viewModel);
            }

            var weapon = await _weaponService.GetWeaponByIdAsync(selectedWeaponId);
            var character = await _characterService.GetCharacterByIdAsync(selectedDefenderId);

            if (character.Gold < weapon.Cost)
            {
                TempData["Errors"] = "No tiene suficiente oro para comprar esta arma.";
                var viewModel = await GetBuyWeaponsViewModelAsync();
                return View("BuyWeapons", viewModel);
            }

            try
            {
                await _defenderService.BuyWeaponAsync(selectedDefenderId, selectedWeaponId);
                await _defenderService.UpdateCharacterGoldAsync(selectedDefenderId, character.Gold - weapon.Cost);

                TempData["SelectedDefenderId"] = selectedDefenderId;
                TempData["PurchasedWeaponName"] = weapon.Name;

                var viewModel = await GetBuyWeaponsViewModelAsync();
                viewModel.SelectedDefenderId = selectedDefenderId;
                viewModel.PurchasedWeaponName = weapon.Name;

                return View("BuyWeapons", viewModel);
            }
            catch (Exception ex)
            {
                TempData["Errors"] = "Hubo un problema al realizar la compra. Intente de nuevo.";
                var viewModel = await GetBuyWeaponsViewModelAsync();
                viewModel.SelectedDefenderId = selectedDefenderId;
                viewModel.PurchasedWeaponName = weapon.Name;
                return View("BuyWeapons", viewModel);
            }
        }


        private async Task<BuyWeaponsViewModel> GetBuyWeaponsViewModelAsync()
        {
            var buyWeaponsViewModel = new BuyWeaponsViewModel();

            if (TempData["BuyWeaponsViewModel"] != null)
            {
                buyWeaponsViewModel = JsonConvert.DeserializeObject<BuyWeaponsViewModel>((string)TempData["BuyWeaponsViewModel"]);
            }

            if (buyWeaponsViewModel.Characters == null || buyWeaponsViewModel.Characters.Count == 0)
            {
                buyWeaponsViewModel.Characters = new List<Character>();
            }

            var characters = new List<Character>();

            foreach (var characterId in buyWeaponsViewModel.Characters.Select(c => c.CharacterId).Distinct())
            {
                var character = await _characterService.GetCharacterByIdAsync(characterId);
                if (character != null)
                {
                    character.DefenderId = buyWeaponsViewModel.Characters.FirstOrDefault(x => x.CharacterId == characterId)?.DefenderId ?? 0;
                    characters.Add(character);
                }
            }
            buyWeaponsViewModel.Characters = characters;
            buyWeaponsViewModel.Weapons = await _weaponService.GetWeaponsAsync();

            // Mantener el nombre del arma comprada en el ViewModel si está disponible
            if (TempData["PurchasedWeaponName"] != null)
            {
                buyWeaponsViewModel.PurchasedWeaponName = (string)TempData["PurchasedWeaponName"];
            }

            TempData["BuyWeaponsViewModel"] = JsonConvert.SerializeObject(buyWeaponsViewModel);

            return buyWeaponsViewModel;
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
