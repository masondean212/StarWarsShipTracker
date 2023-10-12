using Models;
using NHibernate.Setup.Mappings.BaseMappings;

namespace NHibernate.Setup.Mappings;

public class AmmunitionMapping : BaseMapWithName<AmmunitionModel>
{
    public AmmunitionMapping() : base("Ammunition")
    {
        Map(x => x.Cost);
        Map(x => x.Damage);
        Map(x => x.Weight);
        Map(x => x.SpecialValue);
        References(x => x.EquipmentCategory)
            .Column("EquipmentCategoryId")
            .ForeignKey("Id");
        References(x => x.LaunchingWeapon)
            .Column("AssociatedWeaponId")
            .ForeignKey("Id");
        HasMany(x => x.PropertiesCrossReference)
            .KeyColumn("AmmunitionId")
            .Cascade.AllDeleteOrphan()
            .Inverse();
    }
}
