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

    public async Task<UserModel> GetByEmailAsync(string email)
    {
        return await _session.Query<UserModel>().SingleOrDefaultAsync(u => u.Email == email);
    }
}
