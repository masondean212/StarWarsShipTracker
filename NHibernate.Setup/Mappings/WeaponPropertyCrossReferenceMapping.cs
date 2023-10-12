using Models;
using NHibernate.Setup.Mappings.BaseMappings;

namespace NHibernate.Setup.Mappings;

public class WeaponPropertyCrossReferenceMapping : BaseMap<WeaponPropertyCrossReferenceModel>
{
    public WeaponPropertyCrossReferenceMapping() : base("WeaponPropertiesCrossReference")
    {
        Map(x => x.ModifierValue);
        CompositeId()
        .KeyReference(x => x.Property, "EquipmentPropertyId")
        .KeyReference(x => x.Weapon, "WeaponId");
    }
}
