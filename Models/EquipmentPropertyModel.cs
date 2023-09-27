using Models.BaseModels;

namespace Models;

public class EquipmentPropertyModel : BaseModelWithName
{
    public virtual string Description { get; set; } = string.Empty;
}
