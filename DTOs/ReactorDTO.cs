using DTOs.BaseDTOs;

namespace DTOs;

public class ReactorDTO : BaseDTOWithName
{
    public int Cost { get; set; }
    public decimal FuelUseModifier { get; set; }
    public string PowerDiceRecovery { get; set; } = string.Empty;
}
