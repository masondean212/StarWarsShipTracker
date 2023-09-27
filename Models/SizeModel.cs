using Models.BaseModels;

namespace Models;

public class SizeModel : BaseModelWithName
{
    public virtual decimal CostModifier { get; set; }
    public virtual int MinimumWorkforce { get; set; }
    public virtual int ModificationSlots { get; set; }
    public virtual int MaxSuitesBase { get; set; }
    public virtual int MaxSuitsConMultiplier { get; set;}
    public virtual int SuiteCapacity { get; set; }
    public virtual int BaseCargoCapacity { get; set; }
}
