using Models;
using NHibernate.Setup.Mappings.BaseMappings;

public class UserMapping : BaseMap<UserModel>
{
    public UserMapping() : base("Users")
    {
        Map(x => x.Username);
        Map(x => x.Email);
        Map(x => x.HashedPassword);
        Map(x => x.PasswordSalt);
        HasManyToMany(x => x.Roles)
            .Cascade.All()
            .Table("UserRoles")
            .ParentKeyColumn("UserId")
            .ChildKeyColumn("RoleId");
    }
}
