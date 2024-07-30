namespace Manticora.Domain.Entities
{
    public class Attack
    {
        public int AttackId { get; set; }
        public int GameId { get; set; }
        public int DefenderId { get; set; }
        public int WeaponId { get; set; }
        public int Distance { get; set; }
        public int ManticoraDamage { get; set; }
        public int CityDamage { get; set; }
        public int Round { get; set; }
        public DateTime AttackDateTime { get; set; }
    }

}
