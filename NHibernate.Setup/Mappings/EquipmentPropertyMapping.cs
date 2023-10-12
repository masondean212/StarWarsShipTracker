using Models;
using NHibernate.Setup.Mappings.BaseMappings;

namespace NHibernate.Setup.Mappings;

public class EquipmentPropertyMapping : BaseMapWithName<EquipmentPropertyModel>
{
    public EquipmentPropertyMapping() : base("EquipmentProperties")
    {
        Map(x => x.Description);
    }
}
