using Contracts.Repository;
using DTOs.ApiDTOs;
using Models;
using Services.Interfaces;

namespace Services;

public class ShipFeatureServices : IShipFeatureServices
{
    private readonly IFeatureRepository _featureRepository;
    private readonly IUnitOfWork _unitOfWork;
    public ShipFeatureServices(IFeatureRepository featureRepository, IUnitOfWork unitOfWork) 
    {
        _featureRepository = featureRepository;
        _unitOfWork = unitOfWork;
    }
    public async Task UpdateDatabaseFromApi(IEnumerable<ApiResultStarshipModificationsDTO> ApiResults)
    {
        _unitOfWork.Begin();
        var featureTypeModelList = await _featureRepository.GetTypeList();
        foreach(var apiResult in ApiResults)
        {
            var matchingFeature = await _featureRepository.GetFeatureFromName(apiResult.Name);
            if (matchingFeature == null)
            {
                await _featureRepository.UpdateOrAddFeatures(new FeatureModel()
                {
                    Name = apiResult.Name,
                    Grade = apiResult.Grade,
                    Description = apiResult.Content,
                    Prerequisites = String.Join(",", apiResult.Prerequisites),
                    FeatureType = GetFeatureType(apiResult.Type, featureTypeModelList)
                });
            }
            else
            {
                matchingFeature.Name = apiResult.Name;
                matchingFeature.Grade = apiResult.Grade;
                matchingFeature.Description = apiResult.Content;
                matchingFeature.Prerequisites = String.Join(",", apiResult.Prerequisites);
                await _featureRepository.UpdateOrAddFeatures(matchingFeature);
            }
            
        }
        _unitOfWork.Commit();
    }
    private FeatureTypeModel GetFeatureType(string featureString, IEnumerable<FeatureTypeModel> featureTypes) 
    {
        return featureTypes.Where(feature => feature.Name == featureString).First();
    }
}
