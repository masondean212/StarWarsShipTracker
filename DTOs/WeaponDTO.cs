using DTOs.ApiDTOs;
using DTOs.BaseDTOs;

namespace DTOs;

public class WeaponDTO : BaseDTOWithName
{
    public int Cost { get; set; }
    public string Damage { get; set; }
    public EquipmentCategoryDTO Category { get; set; }
    public bool SmallerShip { get; set; }
    public IEnumerable<ApiProperties>? Properties { get; set; }
}
