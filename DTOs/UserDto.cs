using DTOs.BaseDTOs;

namespace DTOs;

public class UserDTO : BaseDTO
{
    public string Username { get; set; }
    public int DefaultShipId { get; set; }
    public IList<RoleDTO> Roles { get; set; }

}
