namespace Manticora.Domain.Entities.Db
{
    public class Game
    {
        public int GameId { get; set; }
        public int AttackingNationId { get; set; }
        public int CityHealth { get; set; }
        public int ManticoraHealth { get; set; }
        public DateTime StartDateTime { get; set; }
        public string GameStatus { get; set; }
    }
}