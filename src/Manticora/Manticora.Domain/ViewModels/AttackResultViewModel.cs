namespace Manticora.Domain.ViewModels
{
    public class AttackResultViewModel
    {
        public int Round { get; set; }
        public int CityHealth { get; set; }
        public int ManticoreHealth { get; set; }
        public string StatusMessage { get; set; }
        public string DefenderName { get; set; }
        public string WeaponName { get; set; }
        public int WeaponRange { get; set; }
        public int DistanceToManticore { get; set; }
        public string ShotResult { get; set; }
    }
}
