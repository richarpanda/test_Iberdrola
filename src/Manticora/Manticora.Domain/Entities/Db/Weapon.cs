using System.Text.Json.Serialization;

namespace Manticora.Domain.Entities.Db
{
    public class Weapon
    {
        public int WeaponId { get; set; }
        public string Name { get; set; }
        public int Cost { get; set; }
        public int Range { get; set; }

        [JsonIgnore]
        public virtual ICollection<Inventory> Inventories { get; set; }
        public virtual ICollection<Attack> Attacks { get; set; }
    }


}