using System.Data;
using Contracts.Repository;
using Models;
using NHibernate;
using NHibernate.Linq;

namespace NHibernate.Setup;

public class UserRepository : BaseRepository, IUserRepository
{
    public UserRepository(ISession session) : base(session)
    {
    }

    public async Task<List<UserModel>> GetAllAsync()
    {
        return await _session.Query<UserModel>().ToListAsync();
    }

    public async Task<UserModel> GetByUserAsync(string username)
    {
        return await _session.Query<UserModel>().SingleOrDefaultAsync(u => u.Username == username);
    }
    public async Task<List<RoleModel>> GetRolesAsync()
    {
        return await _session.Query<RoleModel>().ToListAsync();
    }
}
