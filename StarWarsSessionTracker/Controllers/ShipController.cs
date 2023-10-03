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
    public async Task<IEnumerable<ShipDTO>> GetShipDetails()
    {
        return await _shipServices.GetShipDetails();
    }
    [HttpGet("[action]")]
    public ShipDTO GetCurrentShip()
    {
        return new ShipDTO()
        {
            Id = 1,
            Name = "Sun Revenant",
            Tier = 1,
            Strength = 10,
            Dexterity = 10,
            Constitution = 16,
            Intelligence = 10,
            Wisdom = 14,
            Charisma = 16,
            RolledHitPoints = 43,
            CurrentHitPoints = 15,
            TemporaryHitPoints = 0,
            RolledShieldPoints = 32,
            CurrentShieldPoints = 16,
            TemporaryShieldPoints = 3,

            Size = new SizeDTO()
            {
                Id = 3,
                Name = "Medium",
                CostModifier = 2,
                MinimumWorkforce = 4,
                ModificationSlots = 30,
                MaxSuitesBase = 3,
                MaxSuitsConMultiplier = 1,
                SuiteCapacity = 0,
                BaseCargoCapacity = 25
            },
            Armor = new ArmorDTO()
            {
                Id = 3,
                Name = "Reinforced Armor",
                Cost = 3700,
                MaxAC = 10,
                DamageReduction = 6,
                Stealth = "Disadv."
            },
            Shield = new ShieldDTO()
            {
                Id = 1,
                Name = "Directional Shield",
                Cost = 4300,
                ShieldCapacity = 1,
                ShieldRegenCoef = 1
            },
            Reactor = new ReactorDTO()
            {
                Id = 1,
                Name = "Fuel Cell",
                Cost = 4500,
                FuelUseModifier = 1,
                PowerDiceRecovery = "1"
            },
            PowerCoupling = new PowerCouplingDTO()
            {
                Id = 3,
                Name = "Hub & Spoke Power Coupling",
                Cost = 5600,
                CentralStorageCapacity = 2,
                SystemStorageCapacity = 1
            },
            Skills = new List<SkillDTO>()
            {
                new SkillDTO() { Id = 16, 
                Name = "Saving Throw",
                Ability = "Dexterity",
                Proficiency = 1},
                new SkillDTO() { Id = 17,
                Name = "Saving Throw",
                Ability = "Constitution",
                Proficiency = 1},
                new SkillDTO() { Id = 7,
                Name = "Astrogation",
                Ability = "Intelligence",
                Proficiency = 1},
                new SkillDTO() { Id = 10,
                Name = "Scan",
                Ability = "Wisdom",
                Proficiency = 1},
                new SkillDTO() { Id = 9,
                Name = "Probe",
                Ability = "Intelligence",
                Proficiency = 1},
                new SkillDTO() { Id = 9,
                Name = "Swindle",
                Ability = "Charisma",
                Proficiency = 1}
            }
        };
    }
    [HttpGet("[action]")]
    public async Task<IEnumerable<ShipListItemDTO>> GetShipList()
    {
        return await _shipServices.GetShipList();
    }
}