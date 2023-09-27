using DTOs.BaseDTOs;

namespace DTOs;

public class ShipDTO : BaseDTOWithName
{
    public SizeDTO Size { get; set; }
    public ArmorDTO Armor { get; set; }
    public ShieldDTO Shield { get; set; }
    public ReactorDTO Reactor { get; set; }
    public PowerCouplingDTO PowerCoupling { get; set; }
    public int Tier { get; set; }
    public int Stength { get; set; }
    public int Dexterity { get; set; }
    public int Constitution { get; set; }
    public int Intelligence { get; set; }
    public int Wisdom { get; set; }
    public int Charisma { get; set; }
    public IEnumerable<ShipFeatureDTO> InstalledFeatures { get; set; }
}
