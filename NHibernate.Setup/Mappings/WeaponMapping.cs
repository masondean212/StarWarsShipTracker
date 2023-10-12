using Models;
using NHibernate.Setup.Mappings.BaseMappings;

namespace NHibernate.Setup.Mappings;

public class WeaponMapping : BaseMapWithName<WeaponModel>
{
    public WeaponMapping() : base("Weapons")
    {
        Map(x => x.Cost);
        Map(x => x.Damage);
        Map(x => x.DamageType);
        Map(x => x.SmallerShip);
        References(x => x.EquipmentCategory)
            .Column("EquipmentCategoryId")
            .ForeignKey("Id");
        HasMany(x => x.PropertiesCrossReference)
            .KeyColumn("WeaponId")
            .Cascade.AllDeleteOrphan()
            .Inverse();
    }
}
