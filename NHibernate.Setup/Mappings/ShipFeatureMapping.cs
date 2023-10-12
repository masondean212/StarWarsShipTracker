using Models;
using NHibernate.Setup.Mappings.BaseMappings;

namespace NHibernate.Setup.Mappings;

public class ShipFeatureMapping : BaseMapWithName<FeatureModel>
{
    public ShipFeatureMapping() : base("Features")
    {
        References(x => x.FeatureType)
            .Column("FeatureTypeId")
            .ForeignKey("Id");
        Map(x => x.Grade);
        Map(x => x.Prerequisites);
        Map(x => x.Description);
    }
}
