using Manticora.Domain.Entities.Db;
using Manticora.Domain.Entities;

namespace Manticora.Domain.ViewModels
{
    public class BuyWeaponsViewModel
    {
        public List<Character> Characters { get; set; }
        public List<Weapon> Weapons { get; set; }
        public int SelectedDefenderId { get; set; }
        public string PurchasedWeaponName { get; set; }
    }
}