using Models;

namespace Contracts.Repository;

public interface IUserRepository : IRepositoryBase
{
    Task<UserModel> GetByEmailAsync(string email);
    Task<List<UserModel>> GetAllAsync();
}
