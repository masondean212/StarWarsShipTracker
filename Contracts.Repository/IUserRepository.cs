using System.Data;
using Models;

namespace Contracts.Repository;

public interface IUserRepository : IRepositoryBase
{
    Task<UserModel> GetByUserAsync(string username);
    Task<List<UserModel>> GetAllAsync();
    Task<List<RoleModel>> GetRolesAsync();
}
