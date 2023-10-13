using Contracts.Repository;
using DTOs;
using Services.Interfaces;
using AutoMapper;
using Models;
using AutoMapper.Features;

namespace Services;

public class ShipServices : IShipServices
{
    private readonly IShipRepository _shipRepository;
    private readonly IMapper _mapper;
    public ShipServices(IShipRepository shipRepository, IMapper mapper) 
    {
        _shipRepository = shipRepository;
        _mapper = mapper;
    }
    public async Task<ShipDTO> GetShipDetails(int id)
    {
        var shipModel = await _shipRepository.GetAsync<ShipModel>(id);
        return MapToShipDTO(shipModel);
    }

    public async Task<IEnumerable<ShipListItemDTO>> GetShipList()
    {
        var shipList = await _shipRepository.GetAllAsync();
        return shipList.Select(ship => new ShipListItemDTO()
                                        {
                                            Id = ship.Id,
                                            Name = ship.Name,
                                        }).ToList();
    }
    private ShipDTO MapToShipDTO(ShipModel ship)
    {
        var weaponList = MapWeaponList(ship.Weapons);
        var featureList = MapFeatureList(ship.InstalledFeatures);
        var shipDTO = new ShipDTO()
        {
            Id = ship.Id,
            Name = ship.Name,
            Tier = ship.Tier,
            Strength = ship.Strength,
            Dexterity = ship.Dexterity,
            Constitution = ship.Constitution,
            Intelligence = ship.Intelligence,
            Wisdom = ship.Wisdom,
            Charisma = ship.Charisma,
            RolledHitPoints = ship.RolledHitPoints,
            CurrentHitPoints = ship.CurrentHitPoints,
            TemporaryHitPoints = ship.TemporaryHitPoints,
            RolledShieldPoints = ship.RolledShieldPoints,
            CurrentShieldPoints = ship.CurrentShieldPoints,
            TemporaryShieldPoints = ship.TemporaryShieldPoints,

            Size = _mapper.Map<SizeDTO>(ship.Size),
            Armor = _mapper.Map<ArmorDTO>(ship.Armor),
            Shield = _mapper.Map<ShieldDTO>(ship.Shield),
            Reactor = _mapper.Map<ReactorDTO>(ship.Reactor),
            PowerCoupling = _mapper.Map<PowerCouplingDTO>(ship.PowerCoupling),
            Weapons = weaponList,
            Skills = MapSkillList(ship.SkillCrossReference),
            InstalledFeatures = featureList
        };
        return shipDTO;
    }
    private IEnumerable<ShipFeatureDTO> MapFeatureList(IEnumerable<FeatureModel> features)
    {
        var featuresList = new List<ShipFeatureDTO>();
        foreach (var feature in features)
        {
            featuresList.Add(_mapper.Map<ShipFeatureDTO>(feature));
        }
        return featuresList;
    }
    private IEnumerable<WeaponDTO> MapWeaponList(IEnumerable<WeaponModel> weapons)
    {
        var weaponList = new List<WeaponDTO>();
        foreach (var weapon in weapons)
        {
            var weaponDto = _mapper.Map<WeaponDTO>(weapon);
            weaponDto.Properties = GetPropertyDtoListFromWeaponModel(weapon.PropertiesCrossReference);
            weaponList.Add(weaponDto);
        }
        return weaponList;
    }
    private IEnumerable<EquipmentPropertyDTO> GetPropertyDtoListFromWeaponModel(IEnumerable<WeaponPropertyCrossReferenceModel> properties)
    {
        var propertyDtoList = new List<EquipmentPropertyDTO>();
        foreach (var property in properties)
        {
            propertyDtoList.Add(new EquipmentPropertyDTO()
            {
                Id = property.Id,
                Name = property.Property.Name,
                Description = property.Property.Description,
                EquipmentPropertyId = property.Property.Id,
                ModifierValue = property.ModifierValue
            });
        }
        return propertyDtoList;
    }
    private IEnumerable<SkillDTO> MapSkillList(IEnumerable<ShipSkillCrossReferenceModel> shipSkillCrossReferences)
    {
        var skillList = new List<SkillDTO>();
        foreach (var skill in shipSkillCrossReferences)
        {
            skillList.Add(new SkillDTO()
            {
                Id = skill.Id,
                SkillId = skill.Skill.Id,
                Name = skill.Skill.Name,
                Ability = skill.Skill.Ability,
                Proficiency = skill.Proficiency          
            });
        }
        return skillList;
    }
}

