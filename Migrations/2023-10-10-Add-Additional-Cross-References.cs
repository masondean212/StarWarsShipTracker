using FluentMigrator;

namespace Migrations;
[Migration(4)]
public class _2023_10_10_Add_Additional_Cross_References : Migration
{
    public override void Up()
    {
        Create.Table("ShipWeaponCrossReference")
            .WithColumn("Id").AsInt32().PrimaryKey().Identity().NotNullable()
            .WithColumn("ShipId").AsInt32().ForeignKey("Ships", "Id").NotNullable()
            .WithColumn("WeaponId").AsInt32().ForeignKey("Weapons", "Id").NotNullable();

        Create.Table("ShipAmmunitionCrossReference")
            .WithColumn("Id").AsInt32().PrimaryKey().Identity().NotNullable()
            .WithColumn("ShipId").AsInt32().ForeignKey("Ships", "Id").NotNullable()
            .WithColumn("AmmunitionId").AsInt32().ForeignKey("Ammunition", "Id").NotNullable()
            .WithColumn("Quantity").AsInt32().NotNullable();
    }
    public override void Down()
    {
        Delete.Table("ShipWeaponCrossReference");
    }
}
