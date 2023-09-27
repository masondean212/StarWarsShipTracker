using DTOs;
using Microsoft.AspNetCore.Mvc;
using Services.Interfaces;

namespace StarWarsSessionTracker.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ShipStandardPartsController : ControllerBase
{
    private readonly ILogger<ShipController> _logger;
    private readonly IShipPartsService _shipStandardPartsService;
    public ShipStandardPartsController(ILogger<ShipController> logger, IShipPartsService shipStandardPartsService)
    {
        _logger = logger;
        _shipStandardPartsService = shipStandardPartsService;
    }
    [HttpGet("[action]")]
    public async Task<IEnumerable<ReactorDTO>> GetReactorList()
    {
        return await _shipStandardPartsService.GetReactorList();
    }
    [HttpGet("[action]")]
    public async Task<IEnumerable<ShieldDTO>> GetShieldList()
    {
        return await _shipStandardPartsService.GetShieldList();
    }
    [HttpGet("[action]")]
    public async Task<IEnumerable<ArmorDTO>> GetArmorList()
    {
        return await _shipStandardPartsService.GetArmorList();
    }
    [HttpGet("[action]")]
    public async Task<IEnumerable<PowerCouplingDTO>> GetPowerCouplingList()
    {
        return await _shipStandardPartsService.GetPowerCouplingList();
    }
}
