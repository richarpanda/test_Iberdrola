namespace Manticora.Domain.ViewModels
{
    public class BuyWeaponsViewModel
    {
        public List<CharacterViewModel> Characters { get; set; }
        public List<WeaponViewModel> Weapons { get; set; }
        public int SelectedDefenderId { get; set; }
        public string PurchasedWeaponName { get; set; }
    }
}