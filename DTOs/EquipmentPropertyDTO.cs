using DTOs.BaseDTOs;

namespace DTOs;

public class EquipmentPropertyDTO : BaseDTOWithName
{
    public virtual string Description { get; set; } = string.Empty;
}
