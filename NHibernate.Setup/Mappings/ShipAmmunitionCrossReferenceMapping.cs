using Models;
using NHibernate.Setup.Mappings.BaseMappings;

namespace NHibernate.Setup.Mappings;

public class ShipAmmunitionCrossReferenceMapping : BaseMap<ShipAmmunitionCrossReferenceModel>
{
    public ShipAmmunitionCrossReferenceMapping() : base("ShipAmmunitionCrossReference")
    {
        Map(x => x.Quantity);
        CompositeId()
        .KeyReference(x => x.Ship, "ShipId")
        .KeyReference(x => x.Ammunition, "AmmunitionId");
    }
}
