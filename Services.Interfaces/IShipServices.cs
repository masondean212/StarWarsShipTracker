using DTOs;

namespace Services.Interfaces;

public interface IShipServices
{
    Task<ShipDTO> GetShipDetails(int id);
    Task<IEnumerable<ShipSummaryDTO>> GetShipList();
}
