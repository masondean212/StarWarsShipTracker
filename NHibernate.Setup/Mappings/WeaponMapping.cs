using Models;
using NHibernate.Setup.Mappings.BaseMappings;

namespace NHibernate.Setup.Mappings;

public class WeaponMapping : BaseMapWithName<WeaponModel>
{
    public WeaponMapping() : base("ShipWeapons")
    {
        Map(x => x.Cost);
        Map(x => x.Damage);
        Map(x => x.SmallerShip);
        References(x => x.EquipmentCategory)
            .Column("EquipmentCategoryId")
            .ForeignKey("Id");
        HasManyToMany(x => x.Properties)
            .Table("ShipWeaponPropertiesCrossReference")
            .ParentKeyColumn("ShipWeaponId")
            .ChildKeyColumn("ShipEquipmentPropertyId");
    }
}
