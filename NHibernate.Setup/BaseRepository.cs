using NHibernate;
using NHibernate.Linq;
using Contracts.Repository;

namespace NHibernate.Setup;

public class BaseRepository : IRepositoryBase
{
    protected ISession _session { get; set; }
    public BaseRepository(ISession session)
    {
        _session = session;
    }
    public async Task SaveAsync<T>(T t)
    {
        await _session.SaveAsync(t);
    }
    public async Task<T> GetAsync<T>(int id)
    {
        return await _session.GetAsync<T>(id);
    }
    public async Task<int> GetAsyncCount<T>()
    {
        return await _session.Query<T>().CountAsync();
    }
    public async Task<T> LoadAsync<T>(int id)
    {
        return await _session.LoadAsync<T>(id);
    }
}

