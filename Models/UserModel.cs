using Models.BaseModels;

namespace Models;

public class UserModel : BaseModel
{
    public virtual string Username { get; set; }
    public virtual string Email { get; set; }
    public virtual string HashedPassword { get; set; }
    public virtual string PasswordSalt { get; set; }
    public virtual string BossyOrder { get; set; }
    public virtual IList<RoleModel> Roles { get; set; }
    
}
