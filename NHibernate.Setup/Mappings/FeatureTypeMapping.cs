using Models;
using NHibernate.Setup.Mappings.BaseMappings;

namespace NHibernate.Setup.Mappings;

public class FeatureTypeMapping : BaseMapWithName<FeatureTypeModel>
{
    public FeatureTypeMapping() : base("FeatureTypes")
    {
        Map(x => x.BaseCost);
    }
}
