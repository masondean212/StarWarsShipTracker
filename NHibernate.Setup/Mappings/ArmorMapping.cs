using Models;
using NHibernate.Setup.Mappings.BaseMappings;

namespace NHibernate.Setup.Mappings;

public class ArmorMapping : BaseMapWithName<ArmorModel>
{
    public ArmorMapping() : base("ShipArmors")
    {
        Map(x => x.Cost);
        Map(x => x.MaxAC);
        Map(x => x.DamageReduction);
        Map(x => x.Stealth);
    }
}
