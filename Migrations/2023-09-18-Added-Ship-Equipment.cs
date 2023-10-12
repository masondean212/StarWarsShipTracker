using FluentMigrator;

namespace Migrations;
[Migration(2)]
public class _2023_09_18_Added_Ship_Equipment : Migration
{
    public override void Up()
    {
        Create.Table("EquipmentCategories")
            .WithColumn("Id").AsInt32().PrimaryKey().Identity().NotNullable()
            .WithColumn("Name").AsString(25).NotNullable();

        Insert.IntoTable("EquipmentCategories").Row(new { Name = "Primary" });
        Insert.IntoTable("EquipmentCategories").Row(new { Name = "Secondary" });
        Insert.IntoTable("EquipmentCategories").Row(new { Name = "Tertiary" });
        Insert.IntoTable("EquipmentCategories").Row(new { Name = "Quaternary" });

        Create.Table("EquipmentProperties")
            .WithColumn("Id").AsInt32().PrimaryKey().Identity().NotNullable()
            .WithColumn("Name").AsString(25).NotNullable()
            .WithColumn("Description").AsString(1000).NotNullable();

        Insert.IntoTable("EquipmentProperties").Row(new { Name = "Ammunition", Description = "You can use a weapon that has the ammunition property to make a ranged attack only if you have ammunition to fire from the weapon. Each time you attack with the weapon, you expend one piece of ammunition.\r\n\r\nWeapons with the ammunition property come with a range in parentheses after the property. The range property varies based on the weapon type." });
        Insert.IntoTable("EquipmentProperties").Row(new { Name = "Auto", Description = "Automatic weapons only fire in burst or rapid mode." });
        Insert.IntoTable("EquipmentProperties").Row(new { Name = "Burst", Description = "A weapon that has the burst property can spray a 150-foot-cube area within range with shots. Each ship in the area must make a Dexterity saving throw (DC = 8 + your bonus to ranged ship attacks). On a failure, the ship takes the weapon’s normal damage. The ship takes no damage on a success. This produces an amount of heat or consumes an amount of ammunition as indicated by the burst number. If the ranged ship attack would have disadvantage, affected targets instead have advantage." });
        Insert.IntoTable("EquipmentProperties").Row(new { Name = "Constitution", Description = "A weapon with this special property requires more hull structure to securely hold and use and more cooling capacity to safely operate. While firing it, you have disadvantage on attack rolls unless you meet the Constitution requirement." });
        Insert.IntoTable("EquipmentProperties").Row(new { Name = "Dire", Description = "Before you make an attack with a weapon with the dire property, you can choose to suffer a penalty to the attack roll up to the dire number. If you do so and you hit with it, you gain the same bonus to the damage roll." });
        Insert.IntoTable("EquipmentProperties").Row(new { Name = "Explosive", Description = "When a ship is dealt damage by a weapon with the explosive property, creatures inside are forced to make a Constitution saving throw to maintain concentration. The DC for the check equals 10 or half the damage taken by the ship, whichever number is higher." });
        Insert.IntoTable("EquipmentProperties").Row(new { Name = "Heavy", Description = "When you hit with an attack roll with this weapon, you deal additional damage equal to half your Strength modifier (rounded up, minimum of +1). Heavy is incompatible with saturate." });
        Insert.IntoTable("EquipmentProperties").Row(new { Name = "Hidden", Description = "You have advantage on Charisma (Swindle) checks made to conceal a hidden weapon." });
        Insert.IntoTable("EquipmentProperties").Row(new { Name = "Homing", Description = "A weapon with the homing property gives disadvantage on saving throws made within normal range. Targets are not granted advantage on their saving throws for being at long range." });
        Insert.IntoTable("EquipmentProperties").Row(new { Name = "Ionizing", Description = "On a hit, the target must succeed on a DC 13 Constitution saving throw or it is ionized for 1 minute. As an action by a crewmember on their turn, the ship can repeat the saving throw, ending the effect early on a success. Ships larger than you have advantage on the saving throw." });
        Insert.IntoTable("EquipmentProperties").Row(new { Name = "Keen", Description = "When you make a weapon attack with a weapon with the keen property, the critical hit range increases by an amount equal to the keen number." });
        Insert.IntoTable("EquipmentProperties").Row(new { Name = "Melt", Description = "You may choose to forgo your proficiency bonus to your attack roll or suffer a penalty to the saving throw DC of the weapon equal to your proficiency bonus. If you do so, on a hit, you may add your proficiency bonus to the damage result." });
        Insert.IntoTable("EquipmentProperties").Row(new { Name = "Overheat", Description = "A limited number of shots can be made with a weapon that has the overheat property. A character must then cool the weapon using an action or a bonus action (the character’s choice). A weapon will naturally cool over a period of ten minutes of non-use." });
        Insert.IntoTable("EquipmentProperties").Row(new { Name = "Piercing", Description = "Before you make a weapon attack with a weapon with the piercing property, you can choose to gain a bonus to the attack roll up to the piercing number. If you do so, and you hit with it, you suffer an equivalent penalty to the damage roll." });
        Insert.IntoTable("EquipmentProperties").Row(new { Name = "Power", Description = "You can use a weapon that has this property to make a ranged attack without the use of ammunition. The weapon draws directly from the ship’s power source.\r\n\r\nWeapons with the power property come with a range in parentheses after the property. The range lists two numbers. The effect of these two numbers varies based on the weapon type." });
        Insert.IntoTable("EquipmentProperties").Row(new { Name = "Range", Description = "A weapon that can be used to make a ranged attack has a range shown in parentheses after the ammunition or thrown property. The range lists two numbers. The first is the weapon’s normal range in feet, and the second indicates the weapon’s maximum range. When attacking a target beyond normal range, you have disadvantage on the attack roll. You can’t attack a target beyond the weapon’s long range." });
        Insert.IntoTable("EquipmentProperties").Row(new { Name = "Rapid", Description = "A weapon that has the rapid property can unload on a single target. The target must make a Dexterity saving throw (DC = 8 + your bonus to ranged ship attacks). On a failed save, the target takes normal weapon damage, plus an additional amount equal to the weapon’s damage dice. On a success, the target takes no damage. This produces an amount of heat or consumes an amount of ammunition as indicated by the rapid number. If the ranged ship attack would have disadvantage, the target instead has advantage." });
        Insert.IntoTable("EquipmentProperties").Row(new { Name = "Reload", Description = "A limited number of shots can be made with a weapon that has the reload property. A crewmember must then reload it. Reloading a weapon takes 1 minute per ammunition" });
        Insert.IntoTable("EquipmentProperties").Row(new { Name = "Saturate", Description = "When making an attack with a weapon with saturate,\r\nyou use your choice of your Strength or Wisdom\r\nmodifier for the attack roll or save DC. Saturate is incompatible\r\nwith heavy." });
        Insert.IntoTable("EquipmentProperties").Row(new { Name = "Special", Description = "A weapon with the special property has unusual rules governing its use, explained in the weapon’s description (see “Special Weapons” later in this section)." });
        Insert.IntoTable("EquipmentProperties").Row(new { Name = "Vicious", Description = "Whenever you deal damage with a weapon with the vicious property and roll the maximum on a weapon damage die, you gain a bonus to damage equal to the vicious number." });
        Insert.IntoTable("EquipmentProperties").Row(new { Name = "Zone", Description = "Weapons with the zone property are activated with an action and persist until deactivated (no action required). The weapon creates a zone of difficult terrain within the firing arc and normal range of the weapon. Additionally, your ship has advantage on dexterity saving throws against tertiary weapons launched outside normal range of the weapon." });

        Create.Table("Weapons")
            .WithColumn("Id").AsInt32().PrimaryKey().Identity().NotNullable()
            .WithColumn("Name").AsString(50).NotNullable()
            .WithColumn("EquipmentCategoryId").AsInt32().ForeignKey("EquipmentCategories", "Id").NotNullable()
            .WithColumn("Cost").AsInt16().NotNullable()
            .WithColumn("Damage").AsString(50).NotNullable()
            .WithColumn("DamageType").AsString(50).Nullable()
            .WithColumn("SmallerShip").AsBoolean().NotNullable();

        Create.Table("WeaponPropertiesCrossReference")
            .WithColumn("Id").AsInt32().PrimaryKey().Identity().NotNullable()
            .WithColumn("WeaponId").AsInt32().ForeignKey("Weapons", "Id").NotNullable()
            .WithColumn("EquipmentPropertyId").AsInt32().ForeignKey("EquipmentProperties", "Id").NotNullable()
            .WithColumn("ModifierValue").AsInt16().Nullable();

        Create.Table("Ammunition")
            .WithColumn("Id").AsInt32().PrimaryKey().Identity().NotNullable()
            .WithColumn("Name").AsString(50).NotNullable()
            .WithColumn("EquipmentCategoryId").AsInt32().ForeignKey("EquipmentCategories", "Id").NotNullable()
            .WithColumn("Cost").AsInt16().NotNullable()
            .WithColumn("Damage").AsString(50).NotNullable()
            .WithColumn("Weight").AsInt16().NotNullable()
            .WithColumn("SpecialValue").AsString(1000).Nullable()
            .WithColumn("AssociatedWeaponId").AsInt32().ForeignKey("Weapons","Id").NotNullable();

        Create.Table("AmmunitionPropertiesCrossReference")
            .WithColumn("Id").AsInt32().PrimaryKey().Identity().NotNullable()
            .WithColumn("AmmunitionId").AsInt32().ForeignKey("Ammunition", "Id").NotNullable()
            .WithColumn("EquipmentPropertyId").AsInt32().ForeignKey("EquipmentProperties", "Id").NotNullable()
            .WithColumn("ModifierValue").AsInt16().Nullable();

    }
    public override void Down()
    {
        Delete.Table("EquipedAmmunition");
        Delete.Table("EquipedWeapons");
        Delete.Table("AmmunitionPropertiesCrossReference");
        Delete.Table("Ammunition");
        Delete.Table("WeaponPropertiesCrossReference");
        Delete.Table("Weapons");
        Delete.Table("EquipmentProperties");
        Delete.Table("EquipmentCategories");
    }
}
