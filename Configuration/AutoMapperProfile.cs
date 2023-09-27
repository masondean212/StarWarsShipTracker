using AutoMapper;
using DTOs;
using Models;

namespace Configuration;

public class AutoMapperProfile : Profile
{
    public AutoMapperProfile() 
    {
        CreateMap<ShipModel, ShipDTO>();
        CreateMap<ArmorModel, ArmorDTO>();
        CreateMap<ShieldModel, ShieldDTO>();
        CreateMap<ReactorModel, ReactorDTO>();
        CreateMap<PowerCouplingModel, PowerCouplingDTO>();
        CreateMap<ShipFeatureModel, ShipFeatureDTO>();
    }
}
