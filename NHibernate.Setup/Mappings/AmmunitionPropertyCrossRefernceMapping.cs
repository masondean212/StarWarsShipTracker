using Models;
using NHibernate.Setup.Mappings.BaseMappings;

namespace NHibernate.Setup.Mappings;

public class AmmunitionPropertyCrossRefernceMapping : BaseMap<AmmunitionPropertyCrossReferenceModel>
{
    public AmmunitionPropertyCrossRefernceMapping() : base("AmmunitionPropertiesCrossReference")
    {
        Map(x => x.ModifierValue);
        CompositeId()
        .KeyReference(x => x.Ammunition, "AmmunitionId")
        .KeyReference(x => x.Property, "EquipmentPropertyId");
    }
}
