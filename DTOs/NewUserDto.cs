namespace DTOs;

public class NewUserDTO
{
    public string Username { get; set; }
    public string Password { get; set; }
    public List<RoleDTO> Roles { get; set; }

}
