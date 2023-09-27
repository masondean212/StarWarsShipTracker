using DTOs.BaseDTOs;

namespace DTOs;

public class ArmorDTO : BaseDTOWithName
{
    public int Cost { get; set; }
    public int MaxAC { get; set; }
    public int DamageReduction { get; set; }
    public string Stealth { get; set; } = string.Empty;
}
