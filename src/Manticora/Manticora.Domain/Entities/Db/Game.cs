namespace Manticora.Domain.Entities.Db
{
    public class Game
    {
        public int GameId { get; set; }
        public int AttackingNationId { get; set; }
        public int CityHealth { get; set; }
        public int ManticoreHealth { get; set; }
        public DateTime StartDateTime { get; set; }
        public string GameStatus { get; set; }
        public int Round { get; set; }

        public virtual AttackingNation AttackingNation { get; set; }
        public virtual ICollection<Defender> Defenders { get; set; }
        public virtual ICollection<Attack> Attacks { get; set; }
    }

}