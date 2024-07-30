namespace Manticora.Domain.Entities.Db
{
    public class Inventory
    {
        public int InventoryId { get; set; }
        public int DefenderId { get; set; }
        public int WeaponId { get; set; }
        public int Quantity { get; set; }
        public Defender Defender { get; set; }
        public Weapon Weapon { get; set; }
    }
}