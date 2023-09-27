using Models;
using NHibernate.Setup.Mappings.BaseMappings;

namespace NHibernate.Setup.Mappings;

public class ShipFeatureMapping : BaseMapWithName<ShipFeatureModel>
{
    public ShipFeatureMapping() : base("ShipFeatures")
    {
        References(x => x.FeatureType)
            .Column("FeatureTypeId")
            .ForeignKey("Id");
        Map(x => x.Grade);
        Map(x => x.Prerequisites);
        Map(x => x.Description);
    }
}
