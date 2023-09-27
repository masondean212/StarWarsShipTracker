using Models;
using NHibernate.Setup.Mappings.BaseMappings;

namespace NHibernate.Setup.Mappings;

public class InventoryMapping : BaseMapWithName<InventoryModel>
{
    public InventoryMapping() : base("Inventories")
    {
        References(x => x.Ship)
            .Column("ShipId")
            .ForeignKey("Id");
        References(x => x.Character)
            .Column("CharacterId")
            .ForeignKey("Id");
        Map(x => x.Quantity);
        Map(x => x.Note);
    }
}
