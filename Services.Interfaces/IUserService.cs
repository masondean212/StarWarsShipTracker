using DTOs;

namespace Services.Interfaces;

public interface IUserService
{
    Task<UserDTO?> AuthenticateAsync(string email, string password);
    Task<UserDTO?> GetByIdAsync(int id);
    Task<List<UserDTO>> GetAllAsync();
    Task<UserDTO?> CreateAsync(NewUserDTO dto);
    Task UpdateAsync(UserDTO dto);
    Task<List<RoleDTO>> GetRolesAsync();

}
