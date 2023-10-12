using DTOs.BaseDTOs;

namespace DTOs;

public class AmmunitionDTO : BaseDTOWithName
{
    public int Cost { get; set; }
    public string Damage { get; set; }
    public int Weight { get; set; }
    public EquipmentCategoryDTO EquipmentCategory { get; set; }
    public WeaponDTO LaunchingWeapon { get; set; }
    public IEnumerable<AmmunitionPropertyDTO> Properties { get; set; }
}
