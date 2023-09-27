using Models.BaseModels;

namespace Models;

public class ArmorModel : BaseModelWithName
{
    public virtual int Cost { get; set; }
    public virtual int MaxAC { get; set; }
    public virtual int DamageReduction { get; set; }
    public virtual string Stealth { get; set; } = string.Empty;
}
