namespace DTOs.ApiDTOs;

public class ApiShipWeaponDTO
{
    public string Name { get; set; }
    public int Cost { get; set; }
    public string Damage { get; set; }
    public string Category { get; set; }
    public bool SmallerShip { get; set; }
    public IEnumerable<ApiProperties>? Properties { get; set; }

}
