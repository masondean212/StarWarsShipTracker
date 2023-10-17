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
            .WithColumn("Name").AsString(25).NotNullable()
            .WithColumn("Description").AsString().NotNullable();

        InsertIntoDamageTypes();

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
    private void InsertIntoDamageTypes()
    {
        var table = Insert.IntoTable("DamageTypes");
        table.Row(new { Name = "Acid", Description = "Acid damage is less effective against shields,\r\ndealing only half damage to shields." });
        table.Row(new { Name = "Cold", Description = "Cold damage is less effective against shields,\r\ndealing only half damage to shields." });
        table.Row(new { Name = "Energy", Description = "The most common type of damage, it deals normal damage to hull and shields." });
        table.Row(new { Name = "Fire", Description = "Fire damage is less effective against shields,\r\ndealing only half damage to shields." });
        table.Row(new { Name = "Force", Description = "Deals normal damage to hull and shields." });
        table.Row(new { Name = "Ion", Description = "Ion damage is less effective against hull,\r\ndealing only half damage to hull. Ion damage cannot destroy ships. Instead, ion damage that reduces a ship to zero hull points causes the ship to become disabled and stable." });
        table.Row(new { Name = "Kinetic", Description = "Deals normal damage to hull and shields.\r\nAdditionally, when ships collide with each other or debris, they deal kinetic damage." });
        table.Row(new { Name = "Lightning", Description = "Lightning damage is less effective against hull,\r\ndealing only half damage to hull." });
        table.Row(new { Name = "Necrotic", Description = "Necrotic damage is less effective against ships,\r\ndealing only half damage to hull and shields." });
        table.Row(new { Name = "Poison", Description = "Poison damage is ineffective against ships, dealing no damage to hull or shields." });
        table.Row(new { Name = "Psychic", Description = "Psychic damage is ineffective against ships, dealing no damage to hull or shields." });
        table.Row(new { Name = "Sonic", Description = "Deals normal damage to hull and shields when in an atmosphere, but does no damage in space." });
        table.Row(new { Name = "True", Description = "True damage is not dealt by any specific source. Instead, effects that prevent or redirect damage cannot be used to counter the damage caused by true damage." });
    }
}