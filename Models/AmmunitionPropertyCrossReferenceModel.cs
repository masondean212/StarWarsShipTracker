using Models.BaseModels;

namespace Models;

public class AmmunitionPropertyCrossReferenceModel : BaseModel
{
    public virtual EquipmentPropertyModel Property { get; set; }
    public virtual AmmunitionModel Ammunition { get; set; }
    public virtual int ModifierValue { get; set; }
    public override bool Equals(object obj)
    {
        if (obj == null || GetType() != obj.GetType())
        {
            return false;
        }

        var other = (AmmunitionPropertyCrossReferenceModel)obj;

        return Ammunition == other.Ammunition && Property == other.Property;
    }

    public override int GetHashCode()
    {
        unchecked
        {
            int hash = 17;
            hash = hash * 23 + (Ammunition != null ? Ammunition.GetHashCode() : 0);
            hash = hash * 23 + (Property != null ? Property.GetHashCode() : 0);
            return hash;
        }
    }
}
