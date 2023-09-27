using Models;
using NHibernate.Setup.Mappings.BaseMappings;

namespace NHibernate.Setup.Mappings;

public class AmmunitionPropertyMapping : BaseMap<AmmunitionPropertyModel>
{
    public AmmunitionPropertyMapping() : base("ShipAmmunitionPropertiesCrossReference")
    {
        Map(x => x.ModifierValue);
        References(x => x.Property)
            .Column("ShipEquipmentPropertyId")
            .ForeignKey("Id");
    }
}
