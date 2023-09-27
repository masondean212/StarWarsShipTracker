using DTOs.BaseDTOs;

namespace DTOs;

public class ShieldDTO : BaseDTOWithName
{
    public int Cost { get; set; }
    public decimal ShieldCapacity { get; set; }
    public decimal ShieldRegenCoef { get; set; }
}
