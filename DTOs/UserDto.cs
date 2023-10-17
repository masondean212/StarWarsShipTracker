using DTOs.BaseDTOs;

namespace DTOs;

public class UserDto : BaseDTO
{
    public string Username { get; set; }
    public string Email { get; set; }
    public IList<RoleDto> Roles { get; set; }

}
