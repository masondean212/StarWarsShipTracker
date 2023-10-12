using DTOs.BaseDTOs;

namespace DTOs;

public class ShipAmmunitionDTO : BaseDTO
{
    public AmmunitionDTO Ammunition { get; set; }
    public int Quantity { get; set; }
}
