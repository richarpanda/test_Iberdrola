namespace Manticora.Domain.Entities.Db
{
    public class Attack
    {
        public int AttackId { get; set; }
        public int GameId { get; set; }
        public int DefenderId { get; set; }
        public int WeaponId { get; set; }
        public int Distance { get; set; }
        public int ManticoreDamage { get; set; }
        public int CityDamage { get; set; }
        public int Round { get; set; }
        public DateTime AttackDateTime { get; set; }

        public virtual Game Game { get; set; }
        public virtual Defender Defender { get; set; }
        public virtual Weapon Weapon { get; set; }
    }
}