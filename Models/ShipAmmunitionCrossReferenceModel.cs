using Models.BaseModels;

namespace Models;

public class ShipAmmunitionCrossReferenceModel : BaseModel
{
    public virtual ShipModel Ship { get; set; }
    public virtual AmmunitionModel Ammunition { get; set; }
    public virtual int Quantity { get; set; }

    public override bool Equals(object obj)
    {
        if (obj == null || GetType() != obj.GetType())
        {
            return false;
        }

        var other = (ShipAmmunitionCrossReferenceModel)obj;

        return Ammunition == other.Ammunition && Ship == other.Ship;
    }

    public override int GetHashCode()
    {
        unchecked
        {
            int hash = 17;
            hash = hash * 23 + (Ammunition != null ? Ammunition.GetHashCode() : 0);
            hash = hash * 23 + (Ship != null ? Ship.GetHashCode() : 0);
            return hash;
        }
    }
}
