using Models;
using NHibernate.Setup.Mappings.BaseMappings;

namespace NHibernate.Setup.Mappings;

public class WeaponPropertyMapping : BaseMap<WeaponPropertyModel>
{
    public WeaponPropertyMapping() : base("ShipWeaponPropertiesCrossReference")
    {
        Map(x => x.ModifierValue);
        References(x => x.Property)
            .Column("ShipEquipmentPropertyId")
            .ForeignKey("Id");
    }
}
