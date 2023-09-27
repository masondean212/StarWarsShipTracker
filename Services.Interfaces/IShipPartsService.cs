using DTOs;
using DTOs.ApiDTOs;

namespace Services.Interfaces;

public interface IShipPartsService
{
    Task<IEnumerable<ArmorDTO>> GetArmorList();
    Task<IEnumerable<ReactorDTO>> GetReactorList();
    Task<IEnumerable<PowerCouplingDTO>> GetPowerCouplingList();
    Task<IEnumerable<ShieldDTO>> GetShieldList();
    Task UpdateDatabaseAmmunitionFromApi(IEnumerable<ApiShipAmmunitionDTO> ApiResults);
    Task UpdateDatabaseWeaponsFromApi(IEnumerable<ApiShipWeaponDTO> ApiResults);
}
