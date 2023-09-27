using DTOs.BaseDTOs;

namespace DTOs;

public class AmmunitionDTO : BaseDTOWithName
{
    public virtual int Cost { get; set; }
    public virtual string Damage { get; set; }
    public virtual int Weight { get; set; }
    public virtual EquipmentCategoryDTO EquipmentCategory { get; set; }
    public virtual WeaponDTO LaunchingWeapon { get; set; }
    public virtual IEnumerable<AmmunitionPropertyDTO> Properties { get; set; }
}
