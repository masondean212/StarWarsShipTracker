using DTOs.ApiDTOs;
using Microsoft.AspNetCore.Mvc;
using Services;
using Services.Interfaces;

namespace StarWarsSessionTracker.Controllers;

[ApiController]
[Route("api/[controller]")]
public class DatabaseController : ControllerBase
{
    private readonly ILogger<ShipController> _logger;
    private readonly IShipFeatureServices _shipFeatureServices;
    private readonly IShipPartsService _shipPartsService;
    public DatabaseController(ILogger<ShipController> logger, IShipFeatureServices shipFeatureServices, IShipPartsService shipPartsService)
    {
        _logger = logger;
        _shipFeatureServices = shipFeatureServices;
        _shipPartsService = shipPartsService;
    }
    [HttpPost("[action]")]
    public async Task<string> UpdateStarShipFeatures(IEnumerable<ApiResultStarshipModificationsDTO> ApiResults)
    {
        await _shipFeatureServices.UpdateDatabaseFromApi(ApiResults);
        return "OK";
    }
    [HttpPost("[action]")]
    public async Task<string> UpdateStarShipAmmunition(IEnumerable<ApiShipAmmunitionDTO> ApiResults)
    {
        await _shipPartsService.UpdateDatabaseAmmunitionFromApi(ApiResults);
        return "OK";
    }
    [HttpPost("[action]")]
    public async Task<string> UpdateStarShipWeapons(IEnumerable<ApiShipWeaponDTO> ApiResults)
    {
        await _shipPartsService.UpdateDatabaseWeaponsFromApi(ApiResults);
        return "OK";
    }
}