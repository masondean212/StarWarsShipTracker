using DTOs.BaseDTOs;

namespace DTOs;

public class SizeDTO : BaseDTOWithName
{
    public decimal CostModifier { get; set; }
    public int MinimumWorkforce { get; set; }
    public int ModificationSlots { get; set; }
    public int MaxSuitesBase { get; set; }
    public int MaxSuitsConMultiplier { get; set; }
    public int SuiteCapacity { get; set; }
    public int BaseCargoCapacity { get; set; }
}
