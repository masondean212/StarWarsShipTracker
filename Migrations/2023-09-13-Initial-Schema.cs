using FluentMigrator;
namespace Migrations;
[Migration(0)]
public class _2023_09_13_Initial_Schema : Migration
{
    public override void Up()
    {
        //general size details
        Create.Table("ShipSizes")
            .WithColumn("Id").AsInt32().PrimaryKey().Identity().NotNullable()
            .WithColumn("Name").AsString(10).NotNullable()
            .WithColumn("CostModifier").AsDecimal(4, 1).NotNullable()
            .WithColumn("MinimumWorkforce").AsInt16().NotNullable()
            .WithColumn("ModificationSlots").AsInt16().NotNullable()
            .WithColumn("MaxSuitesBase").AsInt16().NotNullable()
            .WithColumn("MaxSuitesConMultiplier").AsInt16().NotNullable()
            .WithColumn("SuiteCapacity").AsInt16().NotNullable()
            .WithColumn("BaseCargoCapacity").AsInt32().NotNullable();

        Insert.IntoTable("ShipSizes").Row(new { Name = "Tiny", CostModifier = 0.5, MinimumWorkforce = 1, ModificationSlots = 10,
                                                    SuiteCapacity = 0, MaxSuitesBase = 0, MaxSuitesConMultiplier = 0, BaseCargoCapacity = 0});
        Insert.IntoTable("ShipSizes").Row(new { Name = "Small", CostModifier = 1, MinimumWorkforce = 2, ModificationSlots = 20,
                                                    SuiteCapacity = 1, MaxSuitesBase = -1, MaxSuitesConMultiplier = 1, BaseCargoCapacity = 2});
        Insert.IntoTable("ShipSizes").Row(new { Name = "Medium", CostModifier = 2, MinimumWorkforce = 4, ModificationSlots = 30,
                                                    SuiteCapacity = 0, MaxSuitesBase = 3, MaxSuitesConMultiplier = 1, BaseCargoCapacity = 25});
        Insert.IntoTable("ShipSizes").Row(new { Name = "Large", CostModifier = 5, MinimumWorkforce = 10, ModificationSlots = 50,
                                                    SuiteCapacity = 0, MaxSuitesBase = 3, MaxSuitesConMultiplier = 2, BaseCargoCapacity = 500});
        Insert.IntoTable("ShipSizes").Row(new { Name = "Huge", CostModifier = 50, MinimumWorkforce = 100, ModificationSlots = 60,
                                                    SuiteCapacity = 0, MaxSuitesBase = 6, MaxSuitesConMultiplier = 3, BaseCargoCapacity = 10000});
        Insert.IntoTable("ShipSizes").Row(new { Name = "Gargantuan", CostModifier = 500, MinimumWorkforce = 1000, ModificationSlots = 70,
                                                    SuiteCapacity = 0, MaxSuitesBase = 10, MaxSuitesConMultiplier = 4, BaseCargoCapacity = 200000});

        Create.Table("ShipArmors")
            .WithColumn("Id").AsInt32().PrimaryKey().Identity().NotNullable()
            .WithColumn("Name").AsString(50).NotNullable()
            .WithColumn("Cost").AsInt32().NotNullable()
            .WithColumn("MaxAC").AsInt16().NotNullable()
            .WithColumn("DamageReduction").AsInt16().NotNullable()
            .WithColumn("Stealth").AsString(7).Nullable();

        Insert.IntoTable("ShipArmors").Row(new { Name = "Lightweight Armor", Cost = 3100, MaxAC = 50, DamageReduction = 0});
        Insert.IntoTable("ShipArmors").Row(new { Name = "Deflection Armor", Cost = 3450, MaxAC = 12, DamageReduction = 3});
        Insert.IntoTable("ShipArmors").Row(new { Name = "Reinforced Armor", Cost = 3700, MaxAC = 10, DamageReduction = 6, Stealth = "Disadv."});

        Create.Table("ShipShields")
            .WithColumn("Id").AsInt32().PrimaryKey().Identity().NotNullable()
            .WithColumn("Name").AsString(50).NotNullable()
            .WithColumn("Cost").AsInt32().NotNullable()
            .WithColumn("ShieldCapacity").AsDecimal(5,4).NotNullable()
            .WithColumn("ShieldRegenCoef").AsDecimal(5,4).NotNullable();

        Insert.IntoTable("ShipShields").Row(new { Name = "Directional Shield", Cost = 4300, ShieldCapacity = 1.0, ShieldRegenCoef = 1.0 });
        Insert.IntoTable("ShipShields").Row(new { Name = "Fortress Shield", Cost = 4650, ShieldCapacity = 1.5, ShieldRegenCoef = 1 / 1.5 });
        Insert.IntoTable("ShipShields").Row(new { Name = "Quick-Charge Shield", Cost = 4900, ShieldCapacity = 1 / 1.5, ShieldRegenCoef = 1.5 });

        Create.Table("ShipReactors")
            .WithColumn("Id").AsInt32().PrimaryKey().Identity().NotNullable()
            .WithColumn("Name").AsString(50).NotNullable()
            .WithColumn("Cost").AsInt32().NotNullable()
            .WithColumn("FuelUseModifier").AsDecimal(3,1).NotNullable()
            .WithColumn("PowerDiceRecovery").AsString(10).NotNullable();

        Insert.IntoTable("ShipReactors").Row(new { Name = "Fuel Cell Reactor", Cost = 4500, FuelUseModifier = 1, PowerDiceRecovery = "1" });
        Insert.IntoTable("ShipReactors").Row(new { Name = "Ionization Reactor", Cost = 5100, FuelUseModifier = 0.5, PowerDiceRecovery = "1d2-1" });
        Insert.IntoTable("ShipReactors").Row(new { Name = "Power Core Reactor", Cost = 5750, FuelUseModifier = 1.5, PowerDiceRecovery = "1d2" });

        Create.Table("ShipPowerCouplings")
            .WithColumn("Id").AsInt32().PrimaryKey().Identity().NotNullable()
            .WithColumn("Name").AsString(50).NotNullable()
            .WithColumn("Cost").AsInt32().NotNullable()
            .WithColumn("CentralStorageCapacity").AsInt32().NotNullable()
            .WithColumn("SystemStorageCapacity").AsInt32().NotNullable();

        Insert.IntoTable("ShipPowerCouplings").Row(new { Name = "Direct Power Coupling", Cost = 4100, CentralStorageCapacity = 4, SystemStorageCapacity = 0 });
        Insert.IntoTable("ShipPowerCouplings").Row(new { Name = "Distributed Power Coupling", Cost = 5100, CentralStorageCapacity = 0, SystemStorageCapacity = 2 });
        Insert.IntoTable("ShipPowerCouplings").Row(new { Name = "Hub & Spoke Power Coupling", Cost = 5600, CentralStorageCapacity = 2, SystemStorageCapacity = 1 });

        Create.Table("Ships")
            .WithColumn("Id").AsInt32().PrimaryKey().Identity().NotNullable()
            .WithColumn("Name").AsString(50).NotNullable()
            .WithColumn("ShipSizeId").AsInt32().ForeignKey("ShipSizes", "Id").NotNullable()
            .WithColumn("ShipArmorId").AsInt32().ForeignKey("ShipArmors", "Id").NotNullable()
            .WithColumn("ShipShieldId").AsInt32().ForeignKey("ShipShields", "Id").NotNullable()
            .WithColumn("ShipReactorId").AsInt32().ForeignKey("ShipReactors", "Id").NotNullable()
            .WithColumn("ShipPowerCouplingId").AsInt32().ForeignKey("ShipPowerCouplings", "Id").NotNullable()
            .WithColumn("Tier").AsInt16().NotNullable()
            .WithColumn("Strength").AsInt16().NotNullable()
            .WithColumn("Dexterity").AsInt16().NotNullable()
            .WithColumn("Constitution").AsInt16().NotNullable()
            .WithColumn("Intelligence").AsInt16().NotNullable()
            .WithColumn("Wisdom").AsInt16().NotNullable()
            .WithColumn("Charisma").AsInt16().NotNullable();

        Create.Table("ShipFeatureTypes")
            .WithColumn("Id").AsInt32().PrimaryKey().Identity().NotNullable()
            .WithColumn("Name").AsString(20).NotNullable()
            .WithColumn("BaseCost").AsInt32().NotNullable();

        Insert.IntoTable("ShipFeatureTypes").Row(new { Name = "Engineering", BaseCost = 3500 });
        Insert.IntoTable("ShipFeatureTypes").Row(new { Name = "Operation", BaseCost = 3500 });
        Insert.IntoTable("ShipFeatureTypes").Row(new { Name = "Suite", BaseCost = 5000 });
        Insert.IntoTable("ShipFeatureTypes").Row(new { Name = "Universal", BaseCost = 4000 });
        Insert.IntoTable("ShipFeatureTypes").Row(new { Name = "Weapon", BaseCost = 3000 });

        Create.Table("ShipFeatures")
            .WithColumn("Id").AsInt32().PrimaryKey().Identity().NotNullable()
            .WithColumn("Name").AsString(50).NotNullable()
            .WithColumn("FeatureTypeId").AsInt32().NotNullable()
            .WithColumn("Grade").AsInt16().NotNullable()
            .WithColumn("Prerequisites").AsString(100).NotNullable()
            .WithColumn("Description").AsCustom("varchar(max)").NotNullable();

        Create.Table("ShipFeatureCrossReference")
            .WithColumn("Id").AsInt32().PrimaryKey().Identity().NotNullable()
            .WithColumn("ShipId").AsInt32().ForeignKey("Ships", "Id").NotNullable()
            .WithColumn("FeatureId").AsInt32().ForeignKey("ShipFeatures", "Id").NotNullable();

        Create.Table("Characters")
            .WithColumn("Id").AsInt32().PrimaryKey().Identity().NotNullable()
            .WithColumn("Name").AsString(50).NotNullable();

        Create.Table("Inventories")
            .WithColumn("Id").AsInt32().PrimaryKey().Identity().NotNullable()
            .WithColumn("ShipId").AsInt32().ForeignKey("Ships","Id").Nullable()
            .WithColumn("CharacterId").AsInt32().ForeignKey("Characters", "Id").Nullable()
            .WithColumn("Name").AsString().NotNullable()
            .WithColumn("Quantity").AsDecimal(10, 2).NotNullable()
            .WithColumn("Note").AsCustom("varchar(max)").NotNullable();

        Create.Table("ShipSizeFeaturesByTier")
            .WithColumn("Id").AsInt32().PrimaryKey().Identity().NotNullable()
            .WithColumn("ShipSizeId").AsInt32().ForeignKey("ShipSizes", "Id").NotNullable()
            .WithColumn("Tier").AsInt16().NotNullable()
            .WithColumn("HullShieldDie").AsString().NotNullable()
            .WithColumn("Order").AsInt16().NotNullable()
            .WithColumn("AbilityName").AsString(50).NotNullable()
            .WithColumn("Description").AsCustom("varchar(max)").Nullable();
    }
    public override void Down()
    {
        Delete.Table("ShipSizeFeaturesByTier");
        Delete.Table("Inventories");
        Delete.Table("Characters");
        Delete.Table("ShipFeatureCrossReference");
        Delete.Table("ShipFeatures");
        Delete.Table("ShipFeatureTypes");
        Delete.Table("ShipPowerCouplings");
        Delete.Table("ShipReactors");
        Delete.Table("ShipShields");
        Delete.Table("ShipArmor");
        Delete.Table("Ships");
        Delete.Table("ShipSizes");
    }
}