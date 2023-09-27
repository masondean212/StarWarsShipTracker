using Contracts.Repository;
using Models;
using NHibernate.Linq;

namespace NHibernate.Setup;

public class ComponentRepository : BaseRepository, IComponentRepository
{
    public ComponentRepository(ISession session) : base(session)
    {
    }

    public async Task<IEnumerable<WeaponModel>> GetWeaponListAsync()
    {
        return await _session.Query<WeaponModel>().ToListAsync();
    }
    public async Task<IEnumerable<ArmorModel>> GetArmorListAsync()
    {
        return await _session.Query<ArmorModel>().ToListAsync();
    }
    public async Task<IEnumerable<PowerCouplingModel>> GetPowerCouplingListAsync()
    {
        return await _session.Query<PowerCouplingModel>().ToListAsync();
    }
    public async Task<IEnumerable<ReactorModel>> GetReactorListAsync()
    {
        return await _session.Query<ReactorModel>().ToListAsync();
    }
    public async Task<IEnumerable<ShieldModel>> GetShieldListAsync()
    {
        return await _session.Query<ShieldModel>().ToListAsync();
    }
    public async Task<IEnumerable<EquipmentPropertyModel>> GetEquipmentPropertiesAsync()
    {
        return await _session.Query<EquipmentPropertyModel>().ToListAsync();
    }
    public async Task<IEnumerable<EquipmentCategoryModel>> GetEquipmentCategoriesAsync()
    {
        return await _session.Query<EquipmentCategoryModel>().ToListAsync();
    }
    public async Task AddOrUpdateWeaponRepository(WeaponModel weapon)
    {
        await _session.SaveOrUpdateAsync(weapon);
    }
    public async Task<WeaponModel> GetWeaponFromName(string weapon)
    {
        return await _session.Query<WeaponModel>().FirstOrDefaultAsync(f => f.Name == weapon);
    }
    public async Task AddOrUpdateAmmunitionRepository(AmmunitionModel ammunition)
    {
        await _session.SaveOrUpdateAsync(ammunition);
    }
    public async Task AddOrUpdateWeaponPropertyRepository(AmmunitionModel ammunition)
    {
        await _session.SaveOrUpdateAsync(ammunition);
    }
    public async Task<AmmunitionModel> GetAmmunitionFromName(string ammunition, WeaponModel weapon)
    {
        return await _session.Query<AmmunitionModel>().FirstOrDefaultAsync(f => f.Name == ammunition && f.LaunchingWeapon == weapon);
    }
    public async Task<IEnumerable<EquipmentCategoryModel>> GetCategoryListAsync()
    {
        return await _session.Query<EquipmentCategoryModel>().ToListAsync();
    }
    public async Task<IEnumerable<EquipmentPropertyModel>> GetPropertyListAsync()
    {
        return await _session.Query<EquipmentPropertyModel>().ToListAsync();
    }
}