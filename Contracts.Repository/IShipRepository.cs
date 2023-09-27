using Models;

namespace Contracts.Repository;

public interface IShipRepository : IRepositoryBase
{
    public Task<IEnumerable<ShipModel>> GetAllAsync();
}
