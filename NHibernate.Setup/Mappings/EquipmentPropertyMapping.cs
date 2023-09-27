using Models;
using NHibernate.Setup.Mappings.BaseMappings;

namespace NHibernate.Setup.Mappings;

public class EquipmentPropertyMapping : BaseMapWithName<EquipmentPropertyModel>
{
    public EquipmentPropertyMapping() : base("ShipEquipmentProperties")
    {
        Map(x => x.Description);
    }
}
