using Models;
using NHibernate.Setup.Mappings.BaseMappings;

namespace NHibernate.Setup.Mappings;

public class AmmunitionMapping : BaseMapWithName<AmmunitionModel>
{
    public AmmunitionMapping() : base("ShipAmmunition")
    {
        Map(x => x.Cost);
        Map(x => x.Damage);
        Map(x => x.Weight);
        References(x => x.EquipmentCategory)
            .Column("EquipmentCategoryId")
            .ForeignKey("Id");
        References(x => x.LaunchingWeapon)
            .Column("AssociatedShipWeaponId")
            .ForeignKey("Id");
        HasManyToMany(x => x.Properties)
            .Table("ShipAmmunitionPropertiesCrossReference")
            .ParentKeyColumn("ShipAmmunitionId")
            .ChildKeyColumn("Id");
    }
}
