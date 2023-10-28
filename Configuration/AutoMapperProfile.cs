using AutoMapper;
using DTOs;
using Models;

namespace Configuration;

public class AutoMapperProfile : Profile
{
    public AutoMapperProfile() 
    {
        CreateMap<ShipModel, ShipDTO>();
        CreateMap<SizeModel,SizeDTO>();
        CreateMap<ArmorModel, ArmorDTO>();
        CreateMap<ShieldModel, ShieldDTO>();
        CreateMap<ReactorModel, ReactorDTO>();
        CreateMap<PowerCouplingModel, PowerCouplingDTO>();
        CreateMap<FeatureModel, ShipFeatureDTO>();
        CreateMap<FeatureTypeModel, FeatureTypeDTO>();
        CreateMap<WeaponModel, WeaponDTO>();
        CreateMap<WeaponModel, WeaponDTO>();
        CreateMap<UserModel, UserDTO>();
        CreateMap<RoleModel, RoleDTO>();
    }
}
