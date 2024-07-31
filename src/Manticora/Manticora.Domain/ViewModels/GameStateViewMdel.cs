namespace Manticora.Domain.ViewModels
{
    public class GameStateViewMdel
    {
        public int GameId { get; set; }
        public int Round { get; set; }
        public int ManticoreHealth { get; set; }
        public int CityHealth { get; set; }
        public string AttackingNationName { get; set; }
        public string AttackingNationType { get; set; }
        public string AttackingNationDimension { get; set; }
        public int AttackingNationPopulation { get; set; }
        public List<DefenderStatus> Defenders { get; set; }
    }
}
