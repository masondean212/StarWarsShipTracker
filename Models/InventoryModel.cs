using Models.BaseModels;

namespace Models;

public class InventoryModel : BaseModelWithName
{
    public virtual ShipModel Ship { get; set; }
    public virtual CharacterModel Character { get; set; }
    public virtual decimal Quantity { get; set; }
    public virtual string Note { get; set; } = string.Empty;
}
