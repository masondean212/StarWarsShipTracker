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
            .Column("SizeId")
            .ForeignKey("Id");
        References(x => x.Armor)
            .Column("ArmorId")
            .ForeignKey("Id");
        References(x => x.Shield)
            .Column("ShieldId")
            .ForeignKey("Id");
        References(x => x.Reactor)
            .Column("ReactorId")
            .ForeignKey ("Id");
        References(x => x.PowerCoupling)
            .Column("PowerCouplingId")
            .ForeignKey("Id");
        HasManyToMany(x => x.InstalledFeatures)
            .Table("ShipFeatureCrossReference")
            .ParentKeyColumn("ShipId")
            .ChildKeyColumn("FeatureId");
        HasManyToMany(x => x.Weapons)
            .Table("ShipWeaponCrossReference")
            .ParentKeyColumn("ShipId")
            .ChildKeyColumn("WeaponId");
        HasMany(x => x.SkillCrossReference)
            .KeyColumn("ShipId")
            .Cascade.AllDeleteOrphan()
            .Inverse();
        HasMany(x => x.AmmunitionCrossReference)
            .KeyColumn("ShipId")
            .Cascade.AllDeleteOrphan()
            .Inverse();
    }
}
