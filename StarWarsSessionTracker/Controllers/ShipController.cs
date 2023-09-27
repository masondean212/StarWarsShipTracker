using DTOs;
using Microsoft.AspNetCore.Mvc;
using Services.Interfaces;

namespace StarWarsSessionTracker.Controllers;

[ApiController]
[Route("api/[controller]")]
public class ShipController : ControllerBase
{
    private readonly ILogger<ShipController> _logger;
    private readonly IShipServices _shipServices;

    public ShipController(ILogger<ShipController> logger, IShipServices shipServices)
    {
        _logger = logger;
        _shipServices = shipServices;
    }

    [HttpGet("[action]")]
    public async Task<IEnumerable<ShipDTO>> GetShipDetails()
    {
        return await _shipServices.GetShipDetails();
    }
    [HttpGet("[action]")]
    public async Task<IEnumerable<ShipListItemDTO>> GetShipList()
    {
        return await _shipServices.GetShipList();
    }
}