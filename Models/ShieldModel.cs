using Models.BaseModels;

namespace Models;

public class ShieldModel : BaseModelWithName
{
    public virtual int Cost { get; set; }
    public virtual decimal ShieldCapacity { get; set; }
    public virtual decimal ShieldRegenCoef { get; set; }
}
