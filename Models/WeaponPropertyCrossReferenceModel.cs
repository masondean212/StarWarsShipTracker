using Models.BaseModels;

namespace Models;

public class WeaponPropertyCrossReferenceModel : BaseModel
{
    public virtual EquipmentPropertyModel Property { get; set; }
    public virtual WeaponModel Weapon { get; set; }
    public virtual int ModifierValue { get; set; }

    public override bool Equals(object obj)
    {
        if (obj == null || GetType() != obj.GetType())
        {
            return false;
        }

        var other = (WeaponPropertyCrossReferenceModel)obj;

        return Weapon == other.Weapon && Property == other.Property;
    }

    public override int GetHashCode()
    {
        unchecked
        {
            int hash = 17;
            hash = hash * 23 + (Weapon != null ? Weapon.GetHashCode() : 0);
            hash = hash * 23 + (Property != null ? Property.GetHashCode() : 0);
            return hash;
        }
    }
}
