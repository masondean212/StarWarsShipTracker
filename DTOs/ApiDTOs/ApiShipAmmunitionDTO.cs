namespace DTOs.ApiDTOs;

public class ApiShipAmmunitionDTO
{
    public string Name { get; set; }
    public int Cost { get; set; }
    public string Damage { get; set; }
    public string Category { get; set; }
    public string AssociatedWeapon { get; set; }
    public int Weight { get; set; }
    public string Special { get; set; }
    public IEnumerable<ApiProperties> Properties { get; set; }

}
