using System.Text.Json.Serialization;

namespace Manticora.Domain.Entities.Db
{
    public class Defender
    {
        public int DefenderId { get; set; }
        public int CharacterId { get; set; }
        public int Gold { get; set; }

        [JsonIgnore]
        public virtual ICollection<Inventory> Inventories { get; set; }
        public virtual ICollection<Attack> Attacks { get; set; }
    }

}
