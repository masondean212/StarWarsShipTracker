using Models.BaseModels;

namespace Models;

public class AmmunitionPropertyModel : BaseModel
{
    public virtual EquipmentPropertyModel Property { get; set; }
    public virtual int ModifierValue { get; set; }
}
