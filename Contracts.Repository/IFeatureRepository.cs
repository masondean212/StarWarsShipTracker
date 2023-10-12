using Models;

namespace Contracts.Repository;

public interface IFeatureRepository
{
    Task UpdateOrAddFeatures(FeatureModel shipFeature);
    Task<IEnumerable<FeatureTypeModel>> GetTypeList();
    Task<FeatureModel> GetFeatureFromName(string featureName);
}
