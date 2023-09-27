using DTOs.BaseDTOs;

namespace DTOs;

public class ShipFeatureDTO : BaseDTOWithName
{
    public FeatureTypeDTO FeatureType { get; set; }
    public int Grade { get; set; }
    public string Prerequisites { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
}
