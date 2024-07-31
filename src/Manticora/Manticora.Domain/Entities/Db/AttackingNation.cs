namespace Manticora.Domain.Entities.Db
{
    public class AttackingNation
    {
        public int AttackingNationId { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public string Dimension { get; set; }
        public int Population { get; set; }

        public virtual ICollection<Game> Games { get; set; }
    }
}
