using Manticora.Domain.Entities.Db;

namespace Manticora.Domain.Interfaces
{
    public interface IInventoryRepository
    {
        Task AddAsync(Inventory inventory);
    }
}
