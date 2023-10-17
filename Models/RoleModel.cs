using Models.BaseModels;

namespace Models;

public class RoleModel : BaseModelWithName
{
    public virtual IList<UserModel> Users { get; set; }
}
