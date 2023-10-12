using DTOs.ApiDTOs;
using DTOs.BaseDTOs;

namespace DTOs;

public class WeaponDTO : BaseDTOWithName
{
    public int Cost { get; set; }
    public string Damage { get; set; }
    public string DamageType { get; set; }
    public EquipmentCategoryDTO Category { get; set; }
    public bool SmallerShip { get; set; }
    public IEnumerable<EquipmentPropertyDTO>? Properties { get; set; }
}
