using static System.Net.Mime.MediaTypeNames;

namespace DTOs.ApiDTOs;

public class ApiShipWeaponDTO
{
    public string name { get; set; }
    public int cost { get; set; }
    public string damage { get; set; }
    public string category { get; set; }
    public bool smallerShip { get; set; }
    public IEnumerable<ApiProperties>? properties { get; set; }

    public string DamageValue()
    {
        if (damage.Contains(" "))
        {
            var spaceLocation = damage.IndexOf(" ");
            return damage.Substring(0, spaceLocation);
            
        }
        else
        {
            return damage;
        }
    }
    public string? DamageType()
    {
        if (damage.Contains(" "))
        {
            var spaceLocation = damage.IndexOf(" ");
            return damage.Substring(spaceLocation);

        }
        else
        {
            return null;
        }
        
    }
}
