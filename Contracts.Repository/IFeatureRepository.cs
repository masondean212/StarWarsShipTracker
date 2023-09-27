using Models;

namespace Contracts.Repository;

public interface IFeatureRepository
{
    Task UpdateOrAddFeatures(ShipFeatureModel shipFeature);
    Task<IEnumerable<FeatureTypeModel>> GetTypeList();
    Task<ShipFeatureModel> GetFeatureFromName(string featureName);
}
