namespace DTOs.ApiDTOs;

public class ApiShipAmmunitionDTO
{
    public string name { get; set; }
    public int cost { get; set; }
    public string damage { get; set; }
    public string category { get; set; }
    public string associatedWeapon { get; set; }
    public int weight { get; set; }
    public string special { get; set; }
    public IEnumerable<ApiProperties>? properties { get; set; }

}
