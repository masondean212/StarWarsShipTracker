using AutoMapper;
using Contracts.Repository;
using DTOs;
using DTOs.ApiDTOs;
using Models;
using Services.Interfaces;
using System;

namespace Services;

public class ShipPartsService : IShipPartsService
{
    private readonly IComponentRepository _componentRepository;
    private readonly IMapper _mapper;
    private readonly IUnitOfWork _unitOfWork;
    public ShipPartsService(IComponentRepository componentRepository, IMapper mapper, IUnitOfWork unitOfWork)
    {
        _componentRepository = componentRepository;
        _mapper = mapper;
        _unitOfWork = unitOfWork;
    }
    public async Task<IEnumerable<ArmorDTO>> GetArmorList()
    {
        var armorList = await _componentRepository.GetArmorListAsync();
        return armorList.Select(armor => _mapper.Map<ArmorDTO>(armor));
    }
    public async Task<IEnumerable<PowerCouplingDTO>> GetPowerCouplingList()
    {
        var couplingList = await _componentRepository.GetPowerCouplingListAsync();
        return couplingList.Select(coupling => _mapper.Map<PowerCouplingDTO>(coupling));
    }
    public async Task<IEnumerable<ReactorDTO>> GetReactorList()
    {
        var reactorList = await _componentRepository.GetReactorListAsync();
        return reactorList.Select(reactor => _mapper.Map<ReactorDTO>(reactor));
    }
    public async Task<IEnumerable<ShieldDTO>> GetShieldList()
    {
        var shieldList = await _componentRepository.GetShieldListAsync();
        return shieldList.Select(shield => _mapper.Map<ShieldDTO>(shield));
    }
    public async Task UpdateDatabaseWeaponsFromApi(IEnumerable<ApiShipWeaponDTO> ApiResults)
    {
        _unitOfWork.Begin();
        var categoryModelList = await _componentRepository.GetCategoryListAsync();
        var propertyModelList = await _componentRepository.GetPropertyListAsync();
        foreach (var apiResult in ApiResults)
        {
            var matchingFeature = await _componentRepository.GetWeaponFromName(apiResult.Name);
            String damage;
            var damageType = String.Empty;
            if (apiResult.Damage.Contains(" "))
            {
                var spaceLocation = apiResult.Damage.IndexOf(" ");
                damage = apiResult.Damage.Substring(0, spaceLocation);
                damageType = apiResult.Damage.Substring(spaceLocation);
            }
            else
            {
                damage = apiResult.Damage;
            }
            if (matchingFeature == null)
            {
                var newWeapon = new WeaponModel()
                {
                    Name = apiResult.Name,
                    Cost = apiResult.Cost,
                    Damage = damage,
                    DamageType = damageType,
                    SmallerShip = apiResult.SmallerShip,
                    EquipmentCategory = GetCategory(apiResult.Category, categoryModelList),
                    PropertiesCrossReference = GetWeaponPropertyList(apiResult.Properties, propertyModelList)
                };
                foreach (var property in newWeapon.PropertiesCrossReference)
                {
                    property.Weapon = newWeapon;
                }
                await _componentRepository.AddOrUpdateWeaponRepository(newWeapon);
            }
            else
            {
                matchingFeature.Name = apiResult.Name;
                matchingFeature.Cost = apiResult.Cost;
                matchingFeature.Damage = apiResult.Damage;
                matchingFeature.EquipmentCategory = GetCategory(apiResult.Category, categoryModelList);
                matchingFeature.PropertiesCrossReference = GetWeaponPropertyList(apiResult.Properties, propertyModelList);
                foreach (var property in matchingFeature.PropertiesCrossReference)
                {
                    property.Weapon = matchingFeature;
                }
                await _componentRepository.AddOrUpdateWeaponRepository(matchingFeature);
            }
        }
        _unitOfWork.Commit();
    }
    public IEnumerable<WeaponPropertyCrossReferenceModel>? GetWeaponPropertyList(IEnumerable<ApiProperties> apiPropertyList, IEnumerable<EquipmentPropertyModel> fullPropertyModelList)
    {
        var propertyModelList = new List<WeaponPropertyCrossReferenceModel>();
        foreach (var property in apiPropertyList)
        {
            var newWeaponProperty = new WeaponPropertyCrossReferenceModel();
            if (property.Name.Contains(" "))
            {
                if (property.Name.StartsWith("Power"))
                {
                    var startingPlace = property.Name.IndexOf("e ");
                    newWeaponProperty.Property = GetProperty("Power", fullPropertyModelList);
                    newWeaponProperty.ModifierValue = int.Parse(property.Name.Substring(startingPlace + 2, property.Name.IndexOf("/") - startingPlace - 2));
                }
                else
                {
                    var startingPlace = property.Name.IndexOf(" ");
                    newWeaponProperty.Property = GetProperty(property.Name.Substring(0, startingPlace), fullPropertyModelList);
                    newWeaponProperty.ModifierValue = int.Parse(property.Name.Substring(startingPlace + 1));
                }
            }
            else
            {
                newWeaponProperty.Property = GetProperty(property.Name, fullPropertyModelList);
                newWeaponProperty.ModifierValue = 0;
            }
            propertyModelList.Add(newWeaponProperty);
        }
        return propertyModelList;
    }
    public async Task UpdateDatabaseAmmunitionFromApi(IEnumerable<ApiShipAmmunitionDTO> ApiResults)
    {
        _unitOfWork.Begin();
        var categoryModelList = await _componentRepository.GetCategoryListAsync();
        var propertyModelList = await _componentRepository.GetPropertyListAsync();
        var weaponModelList = await _componentRepository.GetWeaponListAsync();
        foreach (var apiResult in ApiResults)
        {
            var matchingFeature = await _componentRepository.GetAmmunitionFromName(apiResult.Name, GetWeapon(apiResult.AssociatedWeapon, weaponModelList));
            if (matchingFeature == null)
            {
                
                    

                var newAmmunition = new AmmunitionModel()
                {
                    Name = apiResult.Name,
                    Cost = apiResult.Cost,
                    Damage = apiResult.Damage,
                    Weight = apiResult.Weight,
                    SpecialValue = apiResult.Special,
                    EquipmentCategory = GetCategory(apiResult.Category, categoryModelList),
                    LaunchingWeapon = GetWeapon(apiResult.AssociatedWeapon, weaponModelList),
                    PropertiesCrossReference = GetAmmunitionPropertyList(apiResult.Properties, propertyModelList)
                };
                foreach (var property in newAmmunition.PropertiesCrossReference)
                {
                    property.Ammunition = newAmmunition;
                }
                await _componentRepository.AddOrUpdateAmmunitionRepository(newAmmunition);
            }
            else
            {
                matchingFeature.Name = apiResult.Name;
                matchingFeature.Cost = apiResult.Cost;
                matchingFeature.Damage = apiResult.Damage;
                matchingFeature.Weight = apiResult.Weight;
                matchingFeature.EquipmentCategory = GetCategory(apiResult.Category, categoryModelList);
                matchingFeature.LaunchingWeapon = GetWeapon(apiResult.AssociatedWeapon, weaponModelList);
                matchingFeature.PropertiesCrossReference = GetAmmunitionPropertyList(apiResult.Properties, propertyModelList);
                foreach (var property in matchingFeature.PropertiesCrossReference)
                {
                    property.Ammunition = matchingFeature;
                }
                await _componentRepository.AddOrUpdateAmmunitionRepository(matchingFeature);
            }

        }
        _unitOfWork.Commit();
    }
    public IEnumerable<AmmunitionPropertyCrossReferenceModel>? GetAmmunitionPropertyList(IEnumerable<ApiProperties> apiPropertyList, IEnumerable<EquipmentPropertyModel> fullPropertyModelList)
    {
        var propertyModelList = new List<AmmunitionPropertyCrossReferenceModel>();
        foreach (var property in apiPropertyList)
        {
            if (property.Name.Contains(" "))
            {
                var spacePlace = property.Name.IndexOf(" ");
                if (property.Name.StartsWith("(Range"))
                {
                    propertyModelList.Add(new AmmunitionPropertyCrossReferenceModel()
                    {
                        Property = GetProperty("Range", fullPropertyModelList),
                        ModifierValue = int.Parse(property.Name.Substring(spacePlace + 1, property.Name.IndexOf("/") - spacePlace - 1))
                    });
                }
                else
                {
                    propertyModelList.Add(new AmmunitionPropertyCrossReferenceModel()
                    {
                        Property = GetProperty(property.Name.Substring(0,spacePlace), fullPropertyModelList),
                        ModifierValue = int.Parse(property.Name.Substring(spacePlace + 1))
                    });
                }
            }
            else
            {
                propertyModelList.Add(new AmmunitionPropertyCrossReferenceModel()
                {
                    Property = GetProperty(property.Name, fullPropertyModelList),
                    ModifierValue = 0
                });
            }
        }
        return propertyModelList;
    }
    private EquipmentPropertyModel GetProperty(string property, IEnumerable<EquipmentPropertyModel> propertyList)
    {
        var holder = propertyList.Where(feature => feature.Name.ToLower() == property.ToLower()).First();
        return holder;
    }
    private EquipmentCategoryModel GetCategory(string category, IEnumerable<EquipmentCategoryModel> categoryList)
    {
        return categoryList.Where(feature => feature.Name.ToLower() == category.ToLower()).First();
    }
    private WeaponModel GetWeapon(string weapon, IEnumerable<WeaponModel> weaponList)
    {
        return weaponList.Where(feature => feature.Name.ToLower() == weapon.ToLower()).First();
    }
}
