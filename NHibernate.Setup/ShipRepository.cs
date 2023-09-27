using Contracts.Repository;
using DTOs;
using Models;
using NHibernate.Linq;
using AutoMapper;

namespace NHibernate.Setup;

public class ShipRepository : BaseRepository, IShipRepository
{
    public ShipRepository(ISession session) : base(session)
    {
    }
    public async Task<IEnumerable<ShipModel>> GetAllAsync()
    {
        return await _session.Query<ShipModel>().ToListAsync();
    }
}
