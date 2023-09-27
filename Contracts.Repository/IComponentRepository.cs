using Models;

namespace Contracts.Repository;

public interface IComponentRepository : IRepositoryBase
{
    Task<IEnumerable<ReactorModel>> GetReactorListAsync();
    Task<IEnumerable<ShieldModel>> GetShieldListAsync();
    Task<IEnumerable<PowerCouplingModel>> GetPowerCouplingListAsync();
    Task<IEnumerable<ArmorModel>> GetArmorListAsync();
    Task AddOrUpdateWeaponRepository(WeaponModel weapon);
    Task<WeaponModel> GetWeaponFromName(string featureName);
    public Task AddOrUpdateAmmunitionRepository(AmmunitionModel ammunition);
    public Task<AmmunitionModel> GetAmmunitionFromName(string ammunition, WeaponModel weapon);
    public Task<IEnumerable<EquipmentCategoryModel>> GetCategoryListAsync();
    public Task<IEnumerable<EquipmentPropertyModel>> GetPropertyListAsync();
    public Task<IEnumerable<WeaponModel>> GetWeaponListAsync();
}
