using Models;
using NHibernate.Setup.Mappings.BaseMappings;

namespace NHibernate.Setup.Mappings;

public class EquipmentCategoryMapping : BaseMapWithName<EquipmentCategoryModel>
{
    public EquipmentCategoryMapping() : base("ShipEquipmentCategories")
    {
    }
}
