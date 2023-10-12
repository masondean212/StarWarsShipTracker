using Models.BaseModels;

namespace Models;

public class FeatureModel : BaseModelWithName
{
    public virtual FeatureTypeModel FeatureType { get; set; }
    public virtual int Grade { get; set; }
    public virtual string Prerequisites { get; set; } = string.Empty;
    public virtual string Description { get; set; } = string.Empty;
}
