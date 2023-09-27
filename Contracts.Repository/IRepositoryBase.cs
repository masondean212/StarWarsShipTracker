namespace Contracts.Repository;

public interface IRepositoryBase
{
    public Task SaveAsync<T>(T t);
    public Task<T> GetAsync<T>(int id);
    public Task<int> GetAsyncCount<T>();
    public Task<T> LoadAsync<T>(int id);
}