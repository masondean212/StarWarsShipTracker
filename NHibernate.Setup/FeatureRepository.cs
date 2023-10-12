using Contracts.Repository;
using DTOs;
using Models;
using NHibernate.Linq;

namespace NHibernate.Setup;

public class FeatureRepository : BaseRepository, IFeatureRepository
{
    public FeatureRepository(ISession session) : base(session)
    {
    }
    public async Task UpdateOrAddFeatures(FeatureModel shipFeature)
    {
        await _session.SaveOrUpdateAsync(shipFeature);
    }
    public async Task<IEnumerable<FeatureTypeModel>> GetTypeList()
    {
        return await _session.Query<FeatureTypeModel>().ToListAsync();
    }
    public async Task<FeatureModel> GetFeatureFromName(string featureName)
    {
        return await _session.Query<FeatureModel>().FirstOrDefaultAsync(f => f.Name == featureName);
    }
}
