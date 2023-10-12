using Models;
using NHibernate.Setup.Mappings.BaseMappings;

namespace NHibernate.Setup.Mappings;

public class SizeMapping : BaseMapWithName<SizeModel>
{
    public SizeMapping() : base("Sizes")
    {
        Map(x => x.CostModifier);
        Map(x => x.MinimumWorkforce);
        Map(x => x.ModificationSlots);
        Map(x => x.MaxSuitesBase);
        Map(x => x.MaxSuitesConMultiplier);
        Map(x => x.SuiteCapacity);
        Map(x => x.BaseCargoCapacity);
    }
}
