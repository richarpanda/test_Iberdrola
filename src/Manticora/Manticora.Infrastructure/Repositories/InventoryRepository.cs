using Manticora.Domain.Entities.Db;
using Manticora.Domain.Interfaces;

namespace Manticora.Infrastructure.Repositories
{
    public class InventoryRepository : IInventoryRepository
    {
        private readonly ManticoraDbContext _context;

        public InventoryRepository(ManticoraDbContext context)
        {
            _context = context;
        }

        public async Task AddAsync(Inventory inventory)
        {
            _context.Inventories.Add(inventory);
            await _context.SaveChangesAsync();
        }
    }
}
