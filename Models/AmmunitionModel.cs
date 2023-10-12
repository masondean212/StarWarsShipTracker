using Models.BaseModels;

namespace Models;

public class AmmunitionModel : BaseModelWithName
{
    public virtual int Cost { get; set; }
    public virtual string? Damage { get; set; }
    public virtual int Weight { get; set; }
    public virtual string? SpecialValue { get; set; }
    public virtual EquipmentCategoryModel EquipmentCategory { get; set; }
    public virtual WeaponModel LaunchingWeapon { get; set; }
    public virtual IEnumerable<AmmunitionPropertyCrossReferenceModel> PropertiesCrossReference { get; set; }
}
