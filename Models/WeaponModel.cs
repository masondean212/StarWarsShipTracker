using Models.BaseModels;

namespace Models;

public class WeaponModel : BaseModelWithName
{
    public virtual int Cost { get; set; }
    public virtual string Damage { get; set; } = string.Empty;
    public virtual bool SmallerShip { get; set; }
    public virtual EquipmentCategoryModel? EquipmentCategory { get; set; }
    public virtual IEnumerable<WeaponPropertyModel>? Properties { get; set; }
}
