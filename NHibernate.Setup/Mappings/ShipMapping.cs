using Models;
using NHibernate.Setup.Mappings.BaseMappings;

namespace NHibernate.Setup.Mappings;

public class ShipMapping : BaseMapWithName<ShipModel>
{
    public ShipMapping() : base("Ships")
    {
        Map(x => x.Tier);
        Map(x => x.Strength);
        Map(x => x.Dexterity);
        Map(x => x.Constitution);
        Map(x => x.Intelligence);
        Map(x => x.Wisdom);
        Map(x => x.Charisma);
        Map(x => x.RolledHitPoints);
        Map(x => x.CurrentHitPoints);
        Map(x => x.TemporaryHitPoints);
        Map(x => x.RolledShieldPoints);
        Map(x => x.CurrentShieldPoints);
        Map(x => x.TemporaryShieldPoints);

        References(x => x.Size)
            .Column("ShipSizeId")
            .ForeignKey("Id");
        References(x => x.Armor)
            .Column("ShipArmorId")
            .ForeignKey("Id");
        References(x => x.Shield)
            .Column("ShipShieldId")
            .ForeignKey("Id");
        References(x => x.Reactor)
            .Column("ShipReactorId")
            .ForeignKey ("Id");
        References(x => x.PowerCoupling)
            .Column("ShipPowerCouplingId")
            .ForeignKey("Id");
        HasManyToMany(x => x.InstalledFeatures)
            .Table("ShipFeatureCrossReference")
            .ParentKeyColumn("ShipId")
            .ChildKeyColumn("FeatureId");
        HasManyToMany(x => x.Skills)
            .Table("ShipSkillCrossreference")
            .ParentKeyColumn("ShipId")
            .ChildKeyColumn("SkillId");
    }
}
