using Models;
using NHibernate.Setup.Mappings.BaseMappings;

namespace NHibernate.Setup.Mappings;

public class PowerCouplingMapping : BaseMapWithName<PowerCouplingModel>
{
    public PowerCouplingMapping() : base("PowerCouplings")
    {
        Map(x => x.Cost);
        Map(x => x.CentralStorageCapacity);
        Map(x => x.SystemStorageCapacity);
    }
}
