using FluentMigrator;

namespace Migrations;
[Migration(3)]
public class _2023_10_03_Additional_Ship_Stats : Migration
{
    public override void Up()
    {
        Alter.Table("Ships")
            .AddColumn("RolledHitPoints").AsInt32().NotNullable()
            .AddColumn("CurrentHitPoints").AsInt32().NotNullable()
            .AddColumn("TemporaryHitPoints").AsInt32().NotNullable()
            .AddColumn("RolledShieldPoints").AsInt32().NotNullable()
            .AddColumn("CurrentShieldPoints").AsInt32().NotNullable()
            .AddColumn("TemporaryShieldPoints").AsInt32().NotNullable();
    }
    public override void Down()
    {

    }
}
