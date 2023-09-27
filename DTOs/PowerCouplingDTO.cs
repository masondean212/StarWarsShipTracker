using DTOs.BaseDTOs;

namespace DTOs;

public class PowerCouplingDTO : BaseDTOWithName
{
    public int Cost { get; set; }
    public int CentralStorageCapacity { get; set; }
    public int SystemStorageCapacity { get; set; }
}
