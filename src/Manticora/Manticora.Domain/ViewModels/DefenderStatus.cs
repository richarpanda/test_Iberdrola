using Manticora.Domain.Entities.Db;

namespace Manticora.Domain.ViewModels
{
    public class DefenderStatus
    {
        public int DefenderId { get; set; }
        public string Name { get; set; }
        public string Species { get; set; }
        public string Type { get; set; }
        public string Gender { get; set; }
        public List<Weapon> Inventory { get; set; }
        public int RemainingShots { get; set; }
    }

}
