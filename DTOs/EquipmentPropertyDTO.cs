using DTOs.BaseDTOs;

namespace DTOs;

public class EquipmentPropertyDTO : BaseDTOWithName
{
    public string Description { get; set; } = string.Empty;
    public int EquipmentPropertyId { get; set; }
    public int ModifierValue { get; set; }
}
