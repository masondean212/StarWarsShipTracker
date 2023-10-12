using FluentMigrator;
namespace Migrations;
[Migration(1)]
public class _2023_09_17_Initial_Schema : Migration
{
    public override void Up()
    {
        Create.Table("Skills")
            .WithColumn("Id").AsInt32().PrimaryKey().Identity().NotNullable()
            .WithColumn("Name").AsString(25).NotNullable()
            .WithColumn("Ability").AsString(25).NotNullable();

        Insert.IntoTable("Skills").Row(new { Name = "Boost", Ability = "Strength" });
        Insert.IntoTable("Skills").Row(new { Name = "Ram", Ability = "Strength" });
        Insert.IntoTable("Skills").Row(new { Name = "Hide", Ability = "Dexterity" });
        Insert.IntoTable("Skills").Row(new { Name = "Maneuvering", Ability = "Dexterity" });
        Insert.IntoTable("Skills").Row(new { Name = "Patch", Ability = "Constitution" });
        Insert.IntoTable("Skills").Row(new { Name = "Regulation", Ability = "Constitution" });
        Insert.IntoTable("Skills").Row(new { Name = "Astrogation", Ability = "Intelligence" });
        Insert.IntoTable("Skills").Row(new { Name = "Data", Ability = "Intelligence" });
        Insert.IntoTable("Skills").Row(new { Name = "Probe", Ability = "Intelligence" });
        Insert.IntoTable("Skills").Row(new { Name = "Scan", Ability = "Wisdom" });
        Insert.IntoTable("Skills").Row(new { Name = "Impress", Ability = "Charisma" });
        Insert.IntoTable("Skills").Row(new { Name = "Interfere", Ability = "Charisma" });
        Insert.IntoTable("Skills").Row(new { Name = "Menace", Ability = "Charisma" });
        Insert.IntoTable("Skills").Row(new { Name = "Swindle", Ability = "Charisma" });
        Insert.IntoTable("Skills").Row(new { Name = "Saving Throw", Ability = "Strength" });
        Insert.IntoTable("Skills").Row(new { Name = "Saving Throw", Ability = "Dexterity" });
        Insert.IntoTable("Skills").Row(new { Name = "Saving Throw", Ability = "Constitution" });
        Insert.IntoTable("Skills").Row(new { Name = "Saving Throw", Ability = "Intelligence" });
        Insert.IntoTable("Skills").Row(new { Name = "Saving Throw", Ability = "Wisdom" });
        Insert.IntoTable("Skills").Row(new { Name = "Saving Throw", Ability = "Charisma" });

        Create.Table("ShipSkillCrossReference")
            .WithColumn("Id").AsInt32().PrimaryKey().Identity().NotNullable()
            .WithColumn("ShipId").AsInt32().NotNullable()
            .WithColumn("SkillId").AsInt32().NotNullable()
            .WithColumn("Proficiency").AsInt32().NotNullable();
    }
    public override void Down()
    {
        Delete.Table("ShipSkillCrossReference");
        Delete.Table("Skills");
    }
}