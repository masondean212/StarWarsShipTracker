using DTOs;
using Microsoft.AspNetCore.Mvc;
using Services.Interfaces;
using System.Numerics;

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
    public async Task<ShipDTO> GetCurrentShip()
    {
        var shipDTO = await _shipServices.GetShipDetails(1);
        return shipDTO;
    }
    [HttpGet("[action]")]
    public async Task<IEnumerable<ShipSummaryDTO>> GetShipList()
    {
        return await _shipServices.GetShipList();
    }
}