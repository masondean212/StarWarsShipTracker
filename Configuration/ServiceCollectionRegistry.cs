using Microsoft.Extensions.DependencyInjection;
using Services;
using Services.Interfaces;
using Contracts.Repository;
using NHibernate.Setup;

namespace Configuration;

public class ServiceCollectionRegistry
{
    public static void RegisterScopedServices(IServiceCollection services)
    {
        services.AddScoped<IShipServices, ShipServices>();
        services.AddScoped<IShipPartsService, ShipPartsService>();
        services.AddScoped<IShipFeatureServices, ShipFeatureServices>();
        services.AddScoped<IUnitOfWork, UnitOfWork>();
        services.AddScoped<IUserService, UserService>();
        services.AddScoped<ICryptoService, CryptoService>();
    }
    public static void RegisterScopedRepositories(IServiceCollection services)
    {
        services.AddScoped<IShipRepository, ShipRepository>();
        services.AddScoped<IComponentRepository, ComponentRepository>();
        services.AddScoped<IFeatureRepository, FeatureRepository>();
        services.AddScoped<IUserRepository, UserRepository>();
    }
}
