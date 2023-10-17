using FluentMigrator;
using Services;

namespace Migrations;
[Migration(6)]
public class _2023_10_16_New_Fields_For_Ship_And_Users : Migration
{
    public override void Up()
    {
        Create.Table("DamageTypes")
            .WithColumn("Id").AsInt32().PrimaryKey().Identity().NotNullable()
            .WithColumn("Name").AsString(25).NotNullable();

        Create.Table("ShipDamageTypeReceivedMultiplierCrossReference")
            .WithColumn("Id").AsInt32().PrimaryKey().Identity().NotNullable()
            .WithColumn("ShipId").AsInt32().NotNullable()
            .WithColumn("DamageType").AsInt32().NotNullable()
            .WithColumn("Multiplier").AsInt32().NotNullable()
            .WithColumn("AdditionalInfo").AsString().Nullable();

        Alter.Table("Ships")
            .AddColumn("FlyingSpeed").AsInt32().NotNullable().WithDefaultValue(0)
            .AddColumn("TurningSpeed").AsInt32().NotNullable().WithDefaultValue(0);

        Create.Table("Users")
            .WithColumn("Id").AsInt32().PrimaryKey().Identity()
            .WithColumn("Username").AsString(50).NotNullable()
            .WithColumn("Email").AsString(100).NotNullable()
            .WithColumn("HashedPassword").AsString(500).NotNullable()
            .WithColumn("PasswordSalt").AsString(500).NotNullable()
            .WithColumn("CreatedAt").AsDateTime().NotNullable()
            .WithColumn("CreatedByUserId").AsInt32().ForeignKey("Users", "Id").Nullable()
            .WithColumn("DeactivatedAt").AsDateTime().Nullable()
            .WithColumn("DeactivatedByUserId").AsInt32().ForeignKey("Users", "Id").Nullable();

        Create.Table("Roles")
            .WithColumn("Id").AsInt32().PrimaryKey().Identity()
            .WithColumn("Name").AsString(50).NotNullable();

        Create.Table("UserRoles")
            .WithColumn("Id").AsInt32().PrimaryKey().Identity()
            .WithColumn("UserId").AsInt32().ForeignKey("Users", "Id").NotNullable()
            .WithColumn("RoleId").AsInt32().ForeignKey("Roles", "Id").NotNullable();

        Execute.Sql("INSERT INTO Roles (Name) VALUES ('Admin');");

        var cryptoService = new CryptoService();
        var salt = cryptoService.GenerateSalt();
        var hash = cryptoService.HashPassword("admin", salt);
        Execute.Sql($"INSERT INTO Users (Username, Email, HashedPassword, PasswordSalt, CreatedAt) VALUES ('admin', 'admin@example.com', '{hash}', '{salt}', GETDATE());");
        Execute.Sql("INSERT INTO UserRoles (UserId, RoleId) VALUES ((SELECT Id FROM Users WHERE Username = 'admin'), (SELECT Id FROM Roles WHERE Name = 'Admin'));");
    }
    public override void Down()
    {
        Delete.Table("UserRoles");
        Delete.Table("Roles");
        Delete.Table("Users");
        Delete.Table("ShipDamageTypeReceivedMultiplierCrossReference");
        Delete.Table("DamageTypes");
    }
}