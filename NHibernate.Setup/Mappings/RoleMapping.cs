using Models;
using NHibernate.Setup.Mappings.BaseMappings;

public class RoleMapping : BaseMapWithName<RoleModel>
{
    public RoleMapping() : base("Roles")
    {
        HasManyToMany(x => x.Users)
            .Cascade.All()
            .Inverse()
            .Table("UserRoles")
            .ParentKeyColumn("RoleId")
            .ChildKeyColumn("UserId");
    }
}
