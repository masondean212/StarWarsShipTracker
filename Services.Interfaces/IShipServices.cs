using DTOs;

namespace Services.Interfaces;

public interface IShipServices
{
    Task<IEnumerable<ShipDTO>> GetShipDetails();
    Task<IEnumerable<ShipListItemDTO>> GetShipList();
}
