using Models.BaseModels;

namespace Models;

public class ReactorModel : BaseModelWithName
{
    public virtual int Cost { get; set; }
    public virtual decimal FuelUseModifier { get; set; }
    public virtual string PowerDiceRecovery { get; set; } = string.Empty;
}
