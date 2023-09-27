using Models;
using NHibernate.Setup.Mappings.BaseMappings;

namespace NHibernate.Setup.Mappings;

public class ShieldMapping : BaseMapWithName<ShieldModel>
{
    public ShieldMapping() : base("ShipShields")
    {
        Map(x => x.Cost);
        Map(x => x.ShieldCapacity);
        Map(x => x.ShieldRegenCoef);
    }
}
