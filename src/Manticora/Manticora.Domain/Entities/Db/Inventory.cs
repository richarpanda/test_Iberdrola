namespace Manticora.Domain.Entities.Db
{
    public class Inventory
    {
        public int InventoryId { get; set; }
        public int DefenderId { get; set; }
        public int WeaponId { get; set; }
        public int Quantity { get; set; }

        public virtual Defender Defender { get; set; }
        public virtual Weapon Weapon { get; set; }
    }

}