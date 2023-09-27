using Models;
using NHibernate.Setup.Mappings.BaseMappings;

namespace NHibernate.Setup.Mappings;

public class FeatureTypeMapping : BaseMapWithName<FeatureTypeModel>
{
    public FeatureTypeMapping() : base("ShipFeatureTypes")
    {
        Map(x => x.BaseCost);
    }
}
