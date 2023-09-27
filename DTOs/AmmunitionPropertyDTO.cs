using DTOs.BaseDTOs;

namespace DTOs;

public class AmmunitionPropertyDTO : BaseDTO
{
    public virtual EquipmentPropertyDTO Property { get; set; }
    public virtual int ModifierValue { get; set; }
}
