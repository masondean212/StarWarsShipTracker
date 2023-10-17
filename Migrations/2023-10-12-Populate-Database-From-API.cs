using DTOs.ApiDTOs;
using FluentMigrator;
using System.Data.SqlClient;
using System.Text.Json;

namespace Migrations;
[Migration(5)]
public class _2023_10_12_Populate_Database_From_API : Migration
{
    public override void Up()
    {
        using (var client = new HttpClient())
        {
            string apiUrl = "https://sw5eapi.azurewebsites.net/api/starshipModification";

            var response = client.GetAsync(apiUrl).Result;

            if (response.IsSuccessStatusCode)
            {
                var content = response.Content.ReadAsStringAsync().Result;
                var result = JsonSerializer.Deserialize<IEnumerable<ApiResultStarshipModificationsDTO>>(content);
                InsertStarshipModificationsToDatabase(result);
                
            }
            else
            {
                throw new Exception($"API request failed with status code: {response.StatusCode}");
            }
        }
        var weaponList = InsertWeaponsIntoDatabase();
        InsertAmmunitionIntoDatabase(weaponList);
        InsertDefaultShip();
    }
    public override void Down()
    {
    }
    private void InsertDefaultShip()
    {
            Insert.IntoTable("Ships").Row(new
            {
                Name = "Default",
                SizeId = 3,
                ArmorId = 1,
                ShieldId = 1,
                ReactorId = 1,
                PowerCouplingId = 1,
                Tier = 0,
                Strength = 10,
                Dexterity = 10,
                Constitution = 10,
                Intelligence = 10,
                Wisdom = 10,
                Charisma = 10,
                RolledHitPoints = 0,
                CurrentHitPoints = 0,
                TemporaryHitPoints = 0,
                RolledShieldPoints = 0,
                CurrentShieldPoints = 0,
                TemporaryShieldPoints = 0
            });
        Insert.IntoTable("ShipWeaponCrossReference").Row(new { ShipId = 1, WeaponId = 1 });
        Insert.IntoTable("ShipFeatureCrossReference").Row(new { ShipId = 1, FeatureId = 1 });
    }
    private void InsertStarshipModificationsToDatabase(IEnumerable<ApiResultStarshipModificationsDTO> modifications)
    {
        var featureTypes = GetFeatureTypeMappingFromDatabase();
        foreach (var modification in modifications)
        {
            Insert.IntoTable("Features").Row(new
            {
                Name = modification.name,
                Grade = modification.grade,
                Description = modification.content,
                Prerequisites = String.Join(",", modification.prerequisites),
                FeatureTypeId = featureTypes[modification.type]
            });
        }
    }
    private Dictionary<string, int> GetFeatureTypeMappingFromDatabase()
    {
        var featureTypeMapping = new Dictionary<string, int>();
        using (SqlConnection connection = new SqlConnection("Data Source=.\\SQLEXPRESS;Database=DBStarWars;Trusted_Connection=yes;"))
        {
            connection.Open();
            string sqlQuery = "SELECT Id, Name FROM FeatureTypes";

            using (SqlCommand command = new SqlCommand(sqlQuery, connection))
            {
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        featureTypeMapping.Add(reader.GetString(1), reader.GetInt32(0));
                    }
                }
            }
        }
        return featureTypeMapping;
    }
    private Dictionary<string, int> InsertWeaponsIntoDatabase()
    {
        var weaponJsonString = @"[{ ""name"": ""Assault laser cannon"",""cost"": 4150,""damage"": ""2d6 energy"",""category"": ""Primary"",""properties"": [{ ""name"": ""Power(range 1200 / 4800)""},{ ""name"": ""constitution 15""},{ ""name"": ""overheat 2""}],""smallerShip"": true},
            { ""name"": ""Blaster cannon"",""cost"": 4000,""damage"": ""1d8 energy"",""category"": ""Primary"",""properties"": [{ ""name"": ""Power(range 600 / 2400)""},{ ""name"": ""hidden""},{ ""name"": ""overheat 18""},{ ""name"": ""rapid 9""}],""smallerShip"": true},
            { ""name"": ""Burst laser cannon"",""cost"": 4500,""damage"": ""2d4 energy"",""category"": ""Primary"",""properties"": [{ ""name"": ""Power(range 200 / 800)""},{ ""name"": ""auto""},{ ""name"": ""burst 1""},{ ""name"": ""overheat 2""},{ ""name"": ""saturate""}],""smallerShip"": true},
            { ""name"": ""Double laser cannon"",""cost"": 4500,""damage"": ""2d4 energy"",""category"": ""Primary"",""properties"": [{ ""name"": ""Power(range 800 / 3200)""},{ ""name"": ""overheat 8""}],""smallerShip"": true},
            { ""name"": ""Heavy blaster cannon"",""cost"": 4150,""damage"": ""1d8 energy"",""category"": ""Primary"",""properties"": [{ ""name"": ""Power(range 600 / 2400)""},{ ""name"": ""heavy""},{ ""name"": ""overheat 12""}],""smallerShip"": true},
            { ""name"": ""Heavy ion cannon"",""cost"": 4150,""damage"": ""1d10 ion"",""category"": ""Primary"",""properties"": [{ ""name"": ""Power(range 1000 / 4000)""},{ ""name"": ""constitution 17""},{ ""name"": ""heavy""},{ ""name"": ""ionizing""},{ ""name"": ""overheat 4""}],""smallerShip"": true},
            { ""name"": ""Heavy laser cannon"",""cost"": 4150,""damage"": ""1d12 energy"",""category"": ""Primary"",""properties"": [{ ""name"": ""Power(range 1200 / 4800)""},{ ""name"": ""constitution 15""},{ ""name"": ""heavy""},{ ""name"": ""overheat 2""}],""smallerShip"": true},
            { ""name"": ""Ion cannon"",""cost"": 6100,""damage"": ""2d4 ion"",""category"": ""Primary"",""properties"": [{ ""name"": ""Power(range 800 / 3200)""},{ ""name"": ""constitution 13""},{ ""name"": ""ionizing""},{ ""name"": ""overheat 8""}],""smallerShip"": true},
            { ""name"": ""Laser cannon"",""cost"": 4000,""damage"": ""1d10 energy"",""category"": ""Primary"",""properties"": [{ ""name"": ""Power(range 1000 / 4000)""},{ ""name"": ""constitution 11""},{ ""name"": ""overheat 4""}],""smallerShip"": true},
            { ""name"": ""Light ion cannon"",""cost"": 6100,""damage"": ""1d8 ion"",""category"": ""Primary"",""properties"": [{ ""name"": ""Power(range 800 / 3200)""},{ ""name"": ""overheat 16""}],""smallerShip"": true},
            { ""name"": ""Light laser cannon"",""cost"": 4100,""damage"": ""1d8 energy"",""category"": ""Primary"",""properties"": [{ ""name"": ""Power(range 800 / 3200)""},{ ""name"": ""overheat 16""}],""smallerShip"": true},
            { ""name"": ""Quad laser cannon"",""cost"": 4400,""damage"": ""2d4 energy"",""category"": ""Primary"",""properties"": [{ ""name"": ""Power(range 800 / 3200)""},{ ""name"": ""constitution 13""},{ ""name"": ""overheat 8""},{ ""name"": ""rapid 2""}],""smallerShip"": true},
            { ""name"": ""Quad pulse laser"",""cost"": 4400,""damage"": ""1d6 energy"",""category"": ""Primary"",""properties"": [{ ""name"": ""Power(range 400 / 1600)""},{ ""name"": ""overheat 16""},{ ""name"": ""rapid 4""}],""smallerShip"": true},
            { ""name"": ""Plasburst laser cannon"",""cost"": 4000,""damage"": ""1d8 energy"",""category"": ""Primary"",""properties"": [{ ""name"": ""Power(range 600 / 2400)""},{ ""name"": ""burst 12""},{ ""name"": ""overheat 12""}],""smallerShip"": true},
            { ""name"": ""Pulse laser cannon"",""cost"": 2500,""damage"": ""1d4 energy"",""category"": ""Primary"",""properties"": [{ ""name"": ""Power(range 500 / 2000)""},{ ""name"": ""keen 1""},{ ""name"": ""piercing 1""},{ ""name"": ""overheat 20""}],""smallerShip"": true},
            { ""name"": ""Rapid - fire laser cannon"",""cost"": 4600,""damage"": ""1d6 energy"",""category"": ""Primary"",""properties"": [{ ""name"": ""Power(range 400 / 1600)""},{ ""name"": ""auto""},{ ""name"": ""burst 16""},{ ""name"": ""overheat 16""},{ ""name"": ""rapid 4""}],""smallerShip"": true},
            { ""name"": ""Slug cannon"",""cost"": 4000,""damage"": ""1d8 kinetic"",""category"": ""Primary"",""properties"": [{ ""name"": ""Power(range 600 / 2400)""},{ ""name"": ""constitution 11""},{ ""name"": ""dire 1""},{ ""name"": ""overheat 4""}],""smallerShip"": true},
            { ""name"": ""Sparkler ion cannon"",""cost"": 6100,""damage"": ""1d4 ion"",""category"": ""Primary"",""properties"": [{ ""name"": ""Power(range 200 / 800)""},{ ""name"": ""auto""},{ ""name"": ""burst 1""},{ ""name"": ""ionizing""},{ ""name"": ""overheat 1""},{ ""name"": ""saturate""}],""smallerShip"": true},
            { ""name"": ""Thermite cannon"",""cost"": 6300,""damage"": ""1d12 fire"",""category"": ""Primary"",""properties"": [{ ""name"": ""Power(range 1200 / 4800)""},{ ""name"": ""constitution 17""},{ ""name"": ""melt""},{ ""name"": ""overheat 2""}],""smallerShip"": true},
            { ""name"": ""Twin auto-blaster"",""cost"": 4400,""damage"": ""1d4 energy"",""category"": ""Primary"",""properties"": [{ ""name"": ""Power(range 250 / 1000)""},{ ""name"": ""auto""},{ ""name"": ""burst 10""},{ ""name"": ""hidden""},{ ""name"": ""overheat 20""},{ ""name"": ""rapid 5""}],""smallerShip"": true},
            { ""name"": ""Twin laser cannon"",""cost"": 4400,""damage"": ""1d8 energy"",""category"": ""Primary"",""properties"": [{ ""name"": ""Power(range 600 / 2400)""},{ ""name"": ""constitution 11""},{ ""name"": ""rapid 3""},{ ""name"": ""overheat 12""}],""smallerShip"": true},
            { ""name"": ""Ion railgun"",""cost"": 5700,""damage"": ""1d10 ion"",""category"": ""Secondary"",""properties"": [{ ""name"": ""Power(range 1000 / 4000)""},{ ""name"": ""constitution 17""},{ ""name"": ""ionizing""},{ ""name"": ""overheat 4""}],""smallerShip"": true},
            { ""name"": ""Particle beam"",""cost"": 5750,""damage"": ""2d4 energy"",""category"": ""Secondary"",""properties"": [{ ""name"": ""Power(range 800 / 3200)""},{ ""name"": ""constitution 11""},{ ""name"": ""overheat 4""}],""smallerShip"": true},
            { ""name"": ""Slug railgun"",""cost"": 5150,""damage"": ""1d12 kinetic"",""category"": ""Secondary"",""properties"": [{ ""name"": ""Power(range 1200 / 4800)""},{ ""name"": ""constitution 15""},{ ""name"": ""overheat 2""}],""smallerShip"": true},
            { ""name"": ""Thermite railgun"",""cost"": 5400,""damage"": ""1d10 fire"",""category"": ""Secondary"",""properties"": [{ ""name"": ""Power(range 1200 / 4800)""},{ ""name"": ""constitution 17""},{ ""name"": ""melt""},{ ""name"": ""overheat 2""}],""smallerShip"": true},
            { ""name"": ""Turbolaser"",""cost"": 5000,""damage"": ""1d10 energy"",""category"": ""Secondary"",""properties"": [{ ""name"": ""Power(range 1000 / 4000)""},{ ""name"": ""constitution 13""},{ ""name"": ""overheat 4""}],""smallerShip"": true},
            { ""name"": ""Cluster pod launcher"",""cost"": 6000,""damage"": "" - "",""category"": ""Tertiary"",""properties"": [{ ""name"": ""Ammunition""},{ ""name"": ""reload 12""}],""smallerShip"": true},
            { ""name"": ""Missile launcher"",""cost"": 6250,""damage"": "" - "",""category"": ""Tertiary"",""properties"": [{ ""name"": ""Ammunition""},{ ""name"": ""reload 4""}],""smallerShip"": true},
            { ""name"": ""Torpedo launcher"",""cost"": 6900,""damage"": "" - "",""category"": ""Tertiary"",""properties"": [{ ""name"": ""Ammunition""}],""smallerShip"": true},
            { ""name"": ""Bomb deployer"",""cost"": 8000,""damage"": "" - "",""category"": ""Quaternary"",""properties"": [{ ""name"": ""Ammunition""},{ ""name"": ""reload 4""}],""smallerShip"": true},
            { ""name"": ""Blaster point-defense"",""cost"": 4000,""damage"": ""3d4 energy"",""category"": ""Primary"",""properties"": [{ ""name"": ""Power(range 200 / 800)""},{ ""name"": ""saturate""},{ ""name"": ""zone""}],""smallerShip"": false},
            { ""name"": ""Ion cannon point - defense"",""cost"": 5500,""damage"": ""2d6 ion"",""category"": ""Primary"",""properties"": [{ ""name"": ""Power(range 300 / 1200)""},{ ""name"": ""ionizing""},{ ""name"": ""saturate""},{ ""name"": ""zone""}],""smallerShip"": false},
            { ""name"": ""Laser cannon point - defense"",""cost"": 6000,""damage"": ""3d6 energy"",""category"": ""Primary"",""properties"": [{ ""name"": ""Power(range 300 / 1200)""},{ ""name"": ""saturate""},{ ""name"": ""zone""}],""smallerShip"": false},
            { ""name"": ""Ordnance point-defense"",""cost"": 6000,""damage"": ""2d6 kinetic"",""category"": ""Primary"",""properties"": [{ ""name"": ""Power(range 300 / 1200)""},{ ""name"": ""explosive""},{ ""name"": ""saturate""},{ ""name"": ""zone""}],""smallerShip"": false},
            { ""name"": ""Assault turbolaser battery"",""cost"": 4150,""damage"": ""6d6 energy"",""category"": ""Secondary"",""properties"": [{ ""name"": ""Power(range 1200 / 4800)""},{ ""name"": ""constitution 15""},{ ""name"": ""overheat 2""}],""smallerShip"": false},
            { ""name"": ""Burst turbolaser battery"",""cost"": 4500,""damage"": ""6d4 energy"",""category"": ""Secondary"",""properties"": [{ ""name"": ""Power(range 200 / 800)""},{ ""name"": ""auto""},{ ""name"": ""burst 1""},{ ""name"": ""overheat 2""},{ ""name"": ""saturate""}],""smallerShip"": false},
            { ""name"": ""Double turbolaser battery"",""cost"": 4500,""damage"": ""6d4 energy"",""category"": ""Secondary"",""properties"": [{ ""name"": ""Power(range 800 / 3200)""},{ ""name"": ""overheat 8""}],""smallerShip"": false},
            { ""name"": ""Heavy ion battery"",""cost"": 4150,""damage"": ""3d10 ion"",""category"": ""Secondary"",""properties"": [{ ""name"": ""Power(range 1000 / 4000)""},{ ""name"": ""constitution 17""},{ ""name"": ""heavy""},{ ""name"": ""ionizing""},{ ""name"": ""overheat 4""}],""smallerShip"": false},
            { ""name"": ""Heavy ion railgun"",""cost"": 5700,""damage"": ""3d10 ion"",""category"": ""Secondary"",""properties"": [{ ""name"": ""Power(range 2000 / 8000)""},{ ""name"": ""constitution 19""},{ ""name"": ""ionizing""},{ ""name"": ""overheat 4""}],""smallerShip"": false},
            { ""name"": ""Heavy gun battery"",""cost"": 4000,""damage"": ""4d10 kinetic"",""category"": ""Secondary"",""properties"": [{ ""name"": ""Power(range 400 / 1600)""},{ ""name"": ""constitution 17""},{ ""name"": ""overheat 1""},{ ""name"": ""vicious 1""}],""smallerShip"": false},
            { ""name"": ""Heavy slug railgun"",""cost"": 5150,""damage"": ""3d12 kinetic"",""category"": ""Secondary"",""properties"": [{ ""name"": ""Power(range 2400 / 9600)""},{ ""name"": ""constitution 17""},{ ""name"": ""overheat 2""}],""smallerShip"": false},
            { ""name"": ""Heavy thermite railgun"",""cost"": 5400,""damage"": ""3d10 fire"",""category"": ""Secondary"",""properties"": [{ ""name"": ""Power(range 2400 / 9600)""},{ ""name"": ""constitution 19""},{ ""name"": ""melt""},{ ""name"": ""overheat 2""}],""smallerShip"": false},
            { ""name"": ""Heavy turbolaser battery"",""cost"": 4150,""damage"": ""3d12 energy"",""category"": ""Secondary"",""properties"": [{ ""name"": ""Power(range 1200 / 4800)""},{ ""name"": ""constitution 15""},{ ""name"": ""heavy""},{ ""name"": ""overheat 2""}],""smallerShip"": false},
            { ""name"": ""Ion battery"",""cost"": 6100,""damage"": ""6d4 ion"",""category"": ""Secondary"",""properties"": [{ ""name"": ""Power(range 800 / 3200)""},{ ""name"": ""constitution 13""},{ ""name"": ""ionizing""},{ ""name"": ""overheat 8""}],""smallerShip"": false},
            { ""name"": ""Light ion battery"",""cost"": 6100,""damage"": ""3d8 ion"",""category"": ""Secondary"",""properties"": [{ ""name"": ""Power(range 800 / 3200)""},{ ""name"": ""overheat 16""}],""smallerShip"": false},
            { ""name"": ""Light turbolaser battery"",""cost"": 4100,""damage"": ""3d8 energy"",""category"": ""Secondary"",""properties"": [{ ""name"": ""Power(range 800 / 3200)""},{ ""name"": ""overheat 16""}],""smallerShip"": false},
            { ""name"": ""Long - range turbolaser battery"",""cost"": 4000,""damage"": ""3d10 energy"",""category"": ""Secondary"",""properties"": [{ ""name"": ""Power(range 2400 / 9600)""},{ ""name"": ""constitution 15""},{ ""name"": ""overheat 2""}],""smallerShip"": false},
            { ""name"": ""Quad turbolaser battery"",""cost"": 4400,""damage"": ""6d4 energy"",""category"": ""Secondary"",""properties"": [{ ""name"": ""Power(range 800 / 3200)""},{ ""name"": ""constitution 13""},{ ""name"": ""overheat 8""},{ ""name"": ""rapid 2""}],""smallerShip"": false},
            { ""name"": ""Quad pulse turbolaser battery"",""cost"": 4400,""damage"": ""2d6 energy"",""category"": ""Secondary"",""properties"": [{ ""name"": ""Power(range 400 / 1600)""},{ ""name"": ""overheat 16""},{ ""name"": ""rapid 4""}],""smallerShip"": false},
            { ""name"": ""Particle Cannon"",""cost"": 5750,""damage"": ""6d4 energy"",""category"": ""Secondary"",""properties"": [{ ""name"": ""Power(range 1600 / 6400)""},{ ""name"": ""constitution 13""},{ ""name"": ""overheat 4""}],""smallerShip"": false},
            { ""name"": ""Plasburst turbolaser battery"",""cost"": 4000,""damage"": ""3d8 energy"",""category"": ""Secondary"",""properties"": [{ ""name"": ""Power(range 600 / 2400)""},{ ""name"": ""burst 12""},{ ""name"": ""overheat 12""}],""smallerShip"": false},
            { ""name"": ""Pulse turbolaser battery"",""cost"": 2500,""damage"": ""3d4 energy"",""category"": ""Secondary"",""properties"": [{ ""name"": ""Power(range 500 / 2000)""},{ ""name"": ""keen 1""},{ ""name"": ""piercing 1""},{ ""name"": ""overheat 20""}],""smallerShip"": false},
            { ""name"": ""Rapid - fire turbolaser battery"",""cost"": 4600,""damage"": ""3d6 energy"",""category"": ""Secondary"",""properties"": [{ ""name"": ""Power(range 400 / 1600)""},{ ""name"": ""auto""},{ ""name"": ""burst 16""},{ ""name"": ""overheat 16""},{ ""name"": ""rapid 4""}],""smallerShip"": false},
            { ""name"": ""Thermite battery"",""cost"": 6300,""damage"": ""3d12 fire"",""category"": ""Secondary"",""properties"": [{ ""name"": ""Power(range 1200 / 4800)""},{ ""name"": ""constitution 17""},{ ""name"": ""melt""},{ ""name"": ""overheat 2""}],""smallerShip"": false},
            { ""name"": ""Turbolaser battery"",""cost"": 4000,""damage"": ""3d10 energy"",""category"": ""Secondary"",""properties"": [{ ""name"": ""Power(range 1000 / 4000)""},{ ""name"": ""constitution 11""},{ ""name"": ""overheat 4""}],""smallerShip"": false},
            { ""name"": ""Twin turbolaser battery"",""cost"": 4400,""damage"": ""2d8 energy"",""category"": ""Secondary"",""properties"": [{ ""name"": ""Power(range 600 / 2400)""},{ ""name"": ""constitution 11""},{ ""name"": ""rapid 3""},{ ""name"": ""overheat 12""}],""smallerShip"": false},
            { ""name"": ""Assault cluster pod launcher"",""cost"": 6000,""damage"": "" - "",""category"": ""Tertiary"",""properties"": [{ ""name"": ""Ammunition""},{ ""name"": ""reload 24""}],""smallerShip"": false},
            { ""name"": ""Assault missile launcher"",""cost"": 6250,""damage"": "" - "",""category"": ""Tertiary"",""properties"": [{ ""name"": ""Ammunition""},{ ""name"": ""reload 8""}],""smallerShip"": false},
            { ""name"": ""Assault torpedo launcher"",""cost"": 6900,""damage"": "" - "",""category"": ""Tertiary"",""properties"": [{ ""name"": ""Ammunition""}],""smallerShip"": false},
            { ""name"": ""Bomb layer"",""cost"": 8000,""damage"": "" - "",""category"": ""Quaternary"",""properties"": [{ ""name"": ""Ammunition""},{ ""name"": ""reload 8""}],""smallerShip"": false}
            ]";
        IEnumerable<ApiShipWeaponDTO> weapons = JsonSerializer.Deserialize<IEnumerable<ApiShipWeaponDTO>>(weaponJsonString);
        var equipmentCategory = GetEquipmentCategoryMappingFromDatabase();
        var properties = GetPropertyMappingFromDatabase();
        var currentWeaponId = 1;
        var weaponListToReturn = new Dictionary<string, int>();
        foreach (var weapon in weapons)
        {
            Insert.IntoTable("Weapons").Row(new
            {
                Name = weapon.name,
                EquipmentCategoryId = equipmentCategory[weapon.category.ToLower()],
                Cost = weapon.cost,
                Damage = weapon.DamageValue(),
                DamageType = weapon.DamageType(),
                SmallerShip = weapon.smallerShip
            });
            foreach (var property in weapon.properties)
            {
                Insert.IntoTable("WeaponPropertiesCrossReference").Row(new 
                { 
                    WeaponId = currentWeaponId, 
                    EquipmentPropertyId = properties[property.Name.ToLower()], 
                    ModifierValue = property.ModifierValue 
                });
            }
            weaponListToReturn.Add(weapon.name.ToLower(), currentWeaponId);
            currentWeaponId++;
        }
        return weaponListToReturn;
    }
    private void InsertAmmunitionIntoDatabase(Dictionary<string,int> weapons)
    {
        var ammunitionJsonString = @"[{ ""name"": ""Adv. cluster missile"", ""associatedWeapon"": ""Cluster pod launcher"", ""cost"": 200, ""damage"": ""3d6 kinetic"", ""weight"": 20, ""category"": ""tertiary"", ""properties"": [{ ""name"": ""(Range 600/2400)"" }, { ""name"": ""auto"" }, { ""name"": ""burst 6"" }, { ""name"": ""explosive"" }, { ""name"": ""rapid 6"" }], ""special"": """" },
            { ""name"": ""Adv. homing cluster missile"", ""associatedWeapon"": ""Cluster pod launcher"", ""cost"": 250, ""damage"": ""3d6 kinetic"", ""weight"": 25, ""category"": ""tertiary"", ""properties"": [{ ""name"": ""(Range 600/2400)"" }, { ""name"": ""auto"" }, { ""name"": ""burst 6"" }, { ""name"": ""explosive"" }, { ""name"": ""homing"" }, { ""name"": ""rapid 6"" }], ""special"": """" },
            { ""name"": ""Cluster missile"", ""associatedWeapon"": ""Cluster pod launcher"", ""cost"": 100, ""damage"": ""3d4 kinetic"", ""weight"": 10, ""category"": ""tertiary"", ""properties"": [{ ""name"": ""(Range 600/2400)"" }, { ""name"": ""auto"" }, { ""name"": ""burst 6"" }, { ""name"": ""explosive"" }, { ""name"": ""rapid 6"" }], ""special"": """" },
            { ""name"": ""Homing cluster missile"", ""associatedWeapon"": ""Cluster pod launcher"", ""cost"": 150, ""damage"": ""3d4 kinetic"", ""weight"": 15, ""category"": ""tertiary"", ""properties"": [{ ""name"": ""(Range 600/2400)"" }, { ""name"": ""auto"" }, { ""name"": ""burst 6"" }, { ""name"": ""explosive"" }, { ""name"": ""homing"" }, { ""name"": ""rapid 6"" }], ""special"": """" },
            { ""name"": ""Nano cluster rocket"", ""associatedWeapon"": ""Cluster pod launcher"", ""cost"": 100, ""damage"": ""1d4 kinetic"", ""weight"": 10, ""category"": ""tertiary"", ""properties"": [{ ""name"": ""(Range 800/3200)"" }, { ""name"": ""explosive"" }, { ""name"": ""homing"" }], ""special"": """" },
            { ""name"": ""Adv. concussion missile"", ""associatedWeapon"": ""Missile launcher"", ""cost"": 1250, ""damage"": ""2d10 energy"", ""weight"": 125, ""category"": ""tertiary"", ""properties"": [{ ""name"": ""(Range 800/3200)"" }, { ""name"": ""auto"" }, { ""name"": ""burst 1"" }, { ""name"": ""explosive"" }, { ""name"": ""rapid 1"" }], ""special"": """" },
            { ""name"": ""Concussion missile"", ""associatedWeapon"": ""Missile launcher"", ""cost"": 750, ""damage"": ""2d8 energy"", ""weight"": 75, ""category"": ""tertiary"", ""properties"": [{ ""name"": ""(Range 600/2400)"" }, { ""name"": ""auto"" }, { ""name"": ""burst 1"" }, { ""name"": ""explosive"" }, { ""name"": ""rapid 1"" }], ""special"": """" },
            { ""name"": ""Conner net (missile)"", ""associatedWeapon"": ""Missile launcher"", ""cost"": 850, ""damage"": ""-"", ""weight"": 85, ""category"": ""tertiary"", ""properties"": [{ ""name"": ""(Range 600/2400)"" }, { ""name"": ""special"" }], ""special"": ""On a failed saving throw for a missile or upon detonation for a mine, a conner net deploys on the target, which must make a Constitution saving throw (DC 15). On a failed save, the ship is stunned for 1 minute. As an action on each of their turns, a crewmember can have the ship repeat the saving throw, ending the effect on a success."" },
            { ""name"": ""Discord missile"", ""associatedWeapon"": ""Missile launcher"", ""cost"": 850, ""damage"": ""-"", ""weight"": 85, ""category"": ""tertiary"", ""properties"": [{ ""name"": ""(Range 600/2400)"" }, { ""name"": ""special"" }], ""special"": ""On a failed saving throw, the missile deploys pistoeka sabotage or - buzz - droids on the target. At the end of each of the target ship - s turns, the target ship gains one level of system damage if the target is medium or smaller [large or smaller]. As an action on each of their turns, a crewmember can have the ship attempt their choice of a dexterity or constitution saving throw (DC 15), ending the effect on a success."" },
            { ""name"": ""Proton rocket"", ""associatedWeapon"": ""Missile launcher"", ""cost"": 950, ""damage"": ""10d4 kinetic"", ""weight"": 95, ""category"": ""tertiary"", ""properties"": [{ ""name"": ""(Range 200/800)"" }, { ""name"": ""explosive"" }, { ""name"": ""vicious 1"" }], ""special"": """" },
            { ""name"": ""Ion pulse missile"", ""associatedWeapon"": ""Missile launcher"", ""cost"": 700, ""damage"": ""2d10 ion"", ""weight"": 70, ""category"": ""tertiary"", ""properties"": [{ ""name"": ""(Range 1000/4000)"" }, { ""name"": ""ionizing"" }], ""special"": """" },
            { ""name"": ""Silent thunder missile"", ""associatedWeapon"": ""Missile launcher"", ""cost"": 1500, ""damage"": ""4d10 energy"", ""weight"": 150, ""category"": ""tertiary"", ""properties"": [{ ""name"": ""(Range 1200/4800)"" }, { ""name"": ""explosive"" }], ""special"": """" },
            { ""name"": ""S-thread tracer"", ""associatedWeapon"": ""Missile launcher"", ""cost"": 1500, ""damage"": ""-"", ""weight"": 50, ""category"": ""tertiary"", ""properties"": [{ ""name"": ""(Range 1200/4800)"" }, { ""name"": ""special"" }], ""special"": ""On a failed saving throw, the missile latches an S-thread tracer onto the target. When making an Intelligence (Probe) check to detect the S-threaded ship’s hyperspace travel, its angle of departure can be detected on a roll of 15 instead of 25."" },
            { ""name"": ""Advanced proton torpedo"", ""associatedWeapon"": ""Torpedo launcher"", ""cost"": 850, ""damage"": ""2d12 energy"", ""weight"": 85, ""category"": ""tertiary"", ""properties"": [{ ""name"": ""(Range 800/3200)"" }, { ""name"": ""explosive"" }, { ""name"": ""keen 1"" }], ""special"": """" },
            { ""name"": ""Flechette torpedo"", ""associatedWeapon"": ""Torpedo launcher"", ""cost"": 850, ""damage"": ""-"", ""weight"": 85, ""category"": ""tertiary"", ""properties"": [{ ""name"": ""(Range 600/2400)"" }, { ""name"": ""special"" }], ""special"": ""A Flechette torpedo detonates at a point within range, creating a 200 (400) foot cube of difficult terrain. Any ship entering or starting their turn in this area must succeed at a Dexterity saving throw (DC 15) or take 1d8 [2d8] kinetic damage."" },
            { ""name"": ""Homing torpedo"", ""associatedWeapon"": ""Torpedo launcher"", ""cost"": 250, ""damage"": ""1d12 energy"", ""weight"": 25, ""category"": ""tertiary"", ""properties"": [{ ""name"": ""(Range 1200/4800)"" }, { ""name"": ""explosive"" }, { ""name"": ""homing"" }], ""special"": """" },
            { ""name"": ""Plasma torpedo"", ""associatedWeapon"": ""Torpedo launcher"", ""cost"": 700, ""damage"": ""2d12 ion"", ""weight"": 70, ""category"": ""tertiary"", ""properties"": [{ ""name"": ""(Range 1200/4800)"" }, { ""name"": ""vicious 1"" }], ""special"": """" },
            { ""name"": ""Proton torpedo"", ""associatedWeapon"": ""Torpedo launcher"", ""cost"": 650, ""damage"": ""2d10 energy"", ""weight"": 65, ""category"": ""tertiary"", ""properties"": [{ ""name"": ""(Range 1200/4800)"" }, { ""name"": ""explosive"" }, { ""name"": ""keen 1"" }], ""special"": """" },
            { ""name"": ""Thermite torpedo"", ""associatedWeapon"": ""Torpedo launcher"", ""cost"": 700, ""damage"": ""2d10 fire"", ""weight"": 70, ""category"": ""tertiary"", ""properties"": [{ ""name"": ""(Range 1200/4800)"" }, { ""name"": ""melt"" }, { ""name"": ""keen 1"" }], ""special"": """" },
            { ""name"": ""Adv. cluster missile"", ""associatedWeapon"": ""Assault Cluster pod launcher"", ""cost"": 200, ""damage"": ""6d6 kinetic"", ""weight"": 40, ""category"": ""tertiary"", ""properties"": [{ ""name"": ""(Range 600/2400)"" }, { ""name"": ""auto"" }, { ""name"": ""burst 6"" }, { ""name"": ""explosive"" }, { ""name"": ""rapid 6"" }], ""special"": """" },
            { ""name"": ""Adv. homing cluster missile"", ""associatedWeapon"": ""Assault Cluster pod launcher"", ""cost"": 250, ""damage"": ""6d6 kinetic"", ""weight"": 50, ""category"": ""tertiary"", ""properties"": [{ ""name"": ""(Range 600/2400)"" }, { ""name"": ""auto"" }, { ""name"": ""burst 6"" }, { ""name"": ""explosive"" }, { ""name"": ""homing"" }, { ""name"": ""rapid 6"" }], ""special"": """" },
            { ""name"": ""Cluster missile"", ""associatedWeapon"": ""Assault Cluster pod launcher"", ""cost"": 100, ""damage"": ""6d4 kinetic"", ""weight"": 20, ""category"": ""tertiary"", ""properties"": [{ ""name"": ""(Range 600/2400)"" }, { ""name"": ""auto"" }, { ""name"": ""burst 6"" }, { ""name"": ""explosive"" }, { ""name"": ""rapid 6"" }], ""special"": """" },
            { ""name"": ""Homing cluster missile"", ""associatedWeapon"": ""Assault Cluster pod launcher"", ""cost"": 150, ""damage"": ""6d4 kinetic"", ""weight"": 30, ""category"": ""tertiary"", ""properties"": [{ ""name"": ""(Range 600/2400)"" }, { ""name"": ""auto"" }, { ""name"": ""burst 6"" }, { ""name"": ""explosive"" }, { ""name"": ""homing"" }, { ""name"": ""rapid 6"" }], ""special"": """" },
            { ""name"": ""Nano cluster rocket"", ""associatedWeapon"": ""Assault Cluster pod launcher"", ""cost"": 100, ""damage"": ""2d4 kinetic"", ""weight"": 20, ""category"": ""tertiary"", ""properties"": [{ ""name"": ""(Range 800/3200)"" }, { ""name"": ""explosive"" }, { ""name"": ""homing"" }], ""special"": """" },
            { ""name"": ""Adv. concussion missile"", ""associatedWeapon"": ""Assault Missile launcher"", ""cost"": 1250, ""damage"": ""4d10 energy"", ""weight"": 250, ""category"": ""tertiary"", ""properties"": [{ ""name"": ""(Range 800/3200)"" }, { ""name"": ""auto"" }, { ""name"": ""burst 1"" }, { ""name"": ""explosive"" }, { ""name"": ""rapid 1"" }], ""special"": """" },
            { ""name"": ""Concussion missile"", ""associatedWeapon"": ""Assault Missile launcher"", ""cost"": 750, ""damage"": ""4d8 energy"", ""weight"": 150, ""category"": ""tertiary"", ""properties"": [{ ""name"": ""(Range 600/2400)"" }, { ""name"": ""auto"" }, { ""name"": ""burst 1"" }, { ""name"": ""explosive"" }, { ""name"": ""rapid 1"" }], ""special"": """" },
            { ""name"": ""Conner net (missile)"", ""associatedWeapon"": ""Assault Missile launcher"", ""cost"": 850, ""damage"": ""-"", ""weight"": 170, ""category"": ""tertiary"", ""properties"": [{ ""name"": ""(Range 600/2400)"" }, { ""name"": ""special"" }], ""special"": ""On a failed saving throw for a missile or upon detonation for a mine, a conner net deploys on the target, which must make a Constitution saving throw (DC 15). On a failed save, the ship is stunned for 1 minute. As an action on each of their turns, a crewmember can have the ship repeat the saving throw, ending the effect on a success."" },
            { ""name"": ""Discord missile"", ""associatedWeapon"": ""Assault Missile launcher"", ""cost"": 850, ""damage"": ""-"", ""weight"": 170, ""category"": ""tertiary"", ""properties"": [{ ""name"": ""(Range 600/2400)"" }, { ""name"": ""special"" }], ""special"": ""On a failed saving throw, the missile deploys pistoeka sabotage or - buzz - droids on the target. At the end of each of the target ship - s turns, the target ship gains one level of system damage if the target is medium or smaller [large or smaller]. As an action on each of their turns, a crewmember can have the ship attempt their choice of a dexterity or constitution saving throw (DC 15), ending the effect on a success."" },
            { ""name"": ""Proton rocket"", ""associatedWeapon"": ""Assault Missile launcher"", ""cost"": 950, ""damage"": ""20d4 kinetic"", ""weight"": 190, ""category"": ""tertiary"", ""properties"": [{ ""name"": ""(Range 200/800)"" }, { ""name"": ""explosive"" }, { ""name"": ""vicious 1"" }], ""special"": """" },
            { ""name"": ""Ion pulse missile"", ""associatedWeapon"": ""Assault Missile launcher"", ""cost"": 700, ""damage"": ""4d10 ion"", ""weight"": 140, ""category"": ""tertiary"", ""properties"": [{ ""name"": ""(Range 1000/4000)"" }, { ""name"": ""ionizing"" }], ""special"": """" },
            { ""name"": ""Silent thunder missile"", ""associatedWeapon"": ""Assault Missile launcher"", ""cost"": 1500, ""damage"": ""8d10 energy"", ""weight"": 300, ""category"": ""tertiary"", ""properties"": [{ ""name"": ""(Range 1200/4800)"" }, { ""name"": ""explosive"" }], ""special"": """" },
            { ""name"": ""S-thread tracer"", ""associatedWeapon"": ""Assault Missile launcher"", ""cost"": 1500, ""damage"": ""-"", ""weight"": 100, ""category"": ""tertiary"", ""properties"": [{ ""name"": ""(Range 1200/4800)"" }, { ""name"": ""special"" }], ""special"": ""On a failed saving throw, the missile latches an S-thread tracer onto the target. When making an Intelligence (Probe) check to detect the S-threaded ship’s hyperspace travel, its angle of departure can be detected on a roll of 15 instead of 25."" },
            { ""name"": ""Advanced proton torpedo"", ""associatedWeapon"": ""Assault Torpedo launcher"", ""cost"": 850, ""damage"": ""4d12 energy"", ""weight"": 170, ""category"": ""tertiary"", ""properties"": [{ ""name"": ""(Range 800/3200)"" }, { ""name"": ""explosive"" }, { ""name"": ""keen 1"" }], ""special"": """" },
            { ""name"": ""Flechette torpedo"", ""associatedWeapon"": ""Assault Torpedo launcher"", ""cost"": 850, ""damage"": ""-"", ""weight"": 170, ""category"": ""tertiary"", ""properties"": [{ ""name"": ""(Range 600/2400)"" }, { ""name"": ""special"" }], ""special"": ""A Flechette torpedo detonates at a point within range, creating a 200 (400) foot cube of difficult terrain. Any ship entering or starting their turn in this area must succeed at a Dexterity saving throw (DC 15) or take 1d8 [2d8] kinetic damage."" },
            { ""name"": ""Homing torpedo"", ""associatedWeapon"": ""Assault Torpedo launcher"", ""cost"": 250, ""damage"": ""2d12 energy"", ""weight"": 50, ""category"": ""tertiary"", ""properties"": [{ ""name"": ""(Range 1200/4800)"" }, { ""name"": ""explosive"" }, { ""name"": ""homing"" }], ""special"": """" },
            { ""name"": ""Plasma torpedo"", ""associatedWeapon"": ""Assault Torpedo launcher"", ""cost"": 700, ""damage"": ""4d12 ion"", ""weight"": 140, ""category"": ""tertiary"", ""properties"": [{ ""name"": ""(Range 1200/4800)"" }, { ""name"": ""vicious 1"" }], ""special"": """" },
            { ""name"": ""Proton torpedo"", ""associatedWeapon"": ""Assault Torpedo launcher"", ""cost"": 650, ""damage"": ""4d10 energy"", ""weight"": 130, ""category"": ""tertiary"", ""properties"": [{ ""name"": ""(Range 1200/4800)"" }, { ""name"": ""explosive"" }, { ""name"": ""keen 1"" }], ""special"": """" },
            { ""name"": ""Thermite torpedo"", ""associatedWeapon"": ""Assault Torpedo launcher"", ""cost"": 700, ""damage"": ""4d10 fire"", ""weight"": 140, ""category"": ""tertiary"", ""properties"": [{ ""name"": ""(Range 1200/4800)"" }, { ""name"": ""melt"" }, { ""name"": ""keen 1"" }], ""special"": """" },
            { ""name"": ""Bomblets"", ""associatedWeapon"": ""Bomb deployer"", ""cost"": 1200, ""damage"": ""-"", ""weight"": 16, ""category"": ""quaternary"", ""properties"": [{ ""name"": ""special"" }], ""special"": ""When a bomblet detonates, each ship within 50 feet must make a Dexterity saving throw (DC 15). A ship takes 1d10 energy damage on a failed save, or half as much on a successful one."" },
            { ""name"": ""Conner net (mine)"", ""associatedWeapon"": ""Bomb deployer"", ""cost"": 2000, ""damage"": ""-"", ""weight"": 30, ""category"": ""quaternary"", ""properties"": [{ ""name"": ""special"" }], ""special"": ""On a failed saving throw for a missile or upon detonation for a mine, a conner net deploys on the target, which must make a Constitution saving throw (DC 15). On a failed save, the ship is stunned for 1 minute. As an action on each of their turns, a crewmember can have the ship repeat the saving throw, ending the effect on a success."" },
            { ""name"": ""EMP bomb"", ""associatedWeapon"": ""Bomb deployer"", ""cost"": 2300, ""damage"": ""-"", ""weight"": 45, ""category"": ""quaternary"", ""properties"": [{ ""name"": ""special"" }], ""special"": ""When an EMP bomb detonates, each ship within 150 feet must make a Constitution saving throw (DC 15). On a failed save, a ship is stunned for 1 minute. As an action on each of their turns, a crewmember can have the ship repeat the saving throw, ending the effect on a success."" },
            { ""name"": ""Glop bomb"", ""associatedWeapon"": ""Bomb deployer"", ""cost"": 2000, ""damage"": ""-"", ""weight"": 30, ""category"": ""quaternary"", ""properties"": [{ ""name"": ""special"" }], ""special"": ""When a glop bomb detonates, each ship within 50 feet must make a Dexterity saving throw (DC 15). On a failed save, a ship is blinded for 1 minute. As an action on each of their turns, a crewmember can have the ship repeat the saving throw, ending the effect on a success. Ships larger than you have advantage on their saving throw."" },
            { ""name"": ""Gravity bomb"", ""associatedWeapon"": ""Bomb deployer"", ""cost"": 2200, ""damage"": ""-"", ""weight"": 40, ""category"": ""quaternary"", ""properties"": [{ ""name"": ""special"" }], ""special"": ""Rather than exploding on contact, gravity bombs detonate any time a ship comes within range of it. When a gravity bomb detonates, it attaches itself to the closest ship hull within 50 feet, creating a mass shadow centered on the ship with a radius of 50 feet that lasts for 10 minutes. A ship can attempt to dislodge the gravity bomb at the beginning of each ship turn by making a Strength saving throw (DC 15). Any Large or smaller ships with an attached gravity bomb are unable to activate their hyperdrives."" },
            { ""name"": ""Gravity mine"", ""associatedWeapon"": ""Bomb deployer"", ""cost"": 2000, ""damage"": ""-"", ""weight"": 30, ""category"": ""quaternary"", ""properties"": [{ ""name"": ""special"" }], ""special"": ""Rather than exploding on contact, gravity mines detonate any time a ship comes within range of it. When a gravity mine detonates, it creates a mass shadow centered on the point of detonation with a radius of 50 feet that lasts for 10 minutes. Any ships touching this mass shadow are unable to activate their hyperdrives."" },
            { ""name"": ""Proton bomb"", ""associatedWeapon"": ""Bomb deployer"", ""cost"": 2100, ""damage"": ""-"", ""weight"": 32, ""category"": ""quaternary"", ""properties"": [{ ""name"": ""special"" }], ""special"": ""When a proton bomb detonates, each ship within 100 feet must make a Dexterity saving throw (DC 15). A ship takes 4d10 energy damage on a failed save, or half as much on a successful one."" },
            { ""name"": ""Proximity mine"", ""associatedWeapon"": ""Bomb deployer"", ""cost"": 2200, ""damage"": ""-"", ""weight"": 32, ""category"": ""quaternary"", ""properties"": [{ ""name"": ""special"" }], ""special"": ""Rather than exploding on contact, proximity mines detonate any time a ship comes within range of it. When a proximity mine detonates, each ship within 100 feet must make a Dexterity saving throw (DC 15). A ship takes 2d10 fire damage on a failed save, or half as much on a successful one."" },
            { ""name"": ""Pulse bomb"", ""associatedWeapon"": ""Bomb deployer"", ""cost"": 2300, ""damage"": ""-"", ""weight"": 35, ""category"": ""quaternary"", ""properties"": [{ ""name"": ""special"" }], ""special"": ""When a pulse bomb detonates, each ship within 200 feet must make a Constitution saving throw (DC 15). A ship takes 2d10 ion damage on a failed save, or half as much on a successful one. Additionally, on a failed save, it is ionized for 1 minute. As an action on each of their turns, a crewmember can have the ship repeat the saving throw, ending the effect on a success. Ships larger than you have advantage on their saving throw."" },
            { ""name"": ""Seismic charge"", ""associatedWeapon"": ""Bomb deployer"", ""cost"": 2000, ""damage"": ""-"", ""weight"": 30, ""category"": ""quaternary"", ""properties"": [{ ""name"": ""special"" }], ""special"": ""When a seismic charge detonates, each ship within 150 feet must make a Dexterity saving throw (DC 15). A ship takes 1d10 kinetic damage on a failed save, or half as much on a successful one."" },
            { ""name"": ""Bomblets"", ""associatedWeapon"": ""Bomb layer"", ""cost"": 2400, ""damage"": ""-"", ""weight"": 32, ""category"": ""quaternary"", ""properties"": [{ ""name"": ""special"" }], ""special"": ""When a bomblet detonates, each ship within 100 feet must make a Dexterity saving throw (DC 15). A ship takes 2d10 energy damage on a failed save, or half as much on a successful one."" },
            { ""name"": ""Conner net (mine)"", ""associatedWeapon"": ""Bomb layer"", ""cost"": 4000, ""damage"": ""-"", ""weight"": 60, ""category"": ""quaternary"", ""properties"": [{ ""name"": ""special"" }], ""special"": ""On a failed saving throw for a missile or upon detonation for a mine, a conner net deploys on the target, which must make a Constitution saving throw (DC 15). On a failed save, the ship is stunned for 1 minute. As an action on each of their turns, a crewmember can have the ship repeat the saving throw, ending the effect on a success."" },
            { ""name"": ""EMP bomb"", ""associatedWeapon"": ""Bomb layer"", ""cost"": 4600, ""damage"": ""-"", ""weight"": 90, ""category"": ""quaternary"", ""properties"": [{ ""name"": ""special"" }], ""special"": ""When an EMP bomb detonates, each ship within 300 feet must make a Constitution saving throw (DC 15). On a failed save, a ship is stunned for 1 minute. As an action on each of their turns, a crewmember can have the ship repeat the saving throw, ending the effect on a success."" },
            { ""name"": ""Glop bomb"", ""associatedWeapon"": ""Bomb layer"", ""cost"": 4000, ""damage"": ""-"", ""weight"": 60, ""category"": ""quaternary"", ""properties"": [{ ""name"": ""special"" }], ""special"": ""When a glop bomb detonates, each ship within 100 feet must make a Dexterity saving throw (DC 15). On a failed save, a ship is blinded for 1 minute. As an action on each of their turns, a crewmember can have the ship repeat the saving throw, ending the effect on a success. Ships larger than you have advantage on their saving throw."" },
            { ""name"": ""Gravity bomb"", ""associatedWeapon"": ""Bomb layer"", ""cost"": 4400, ""damage"": ""-"", ""weight"": 80, ""category"": ""quaternary"", ""properties"": [{ ""name"": ""special"" }], ""special"": ""Rather than exploding on contact, gravity bombs detonate any time a ship comes within range of it. When a gravity bomb detonates, it attaches itself to the closest ship hull within 100 feet, creating a mass shadow centered on the ship with a radius of 50 feet that lasts for 10 minutes. A ship can attempt to dislodge the gravity bomb at the beginning of each ship turn by making a Strength saving throw (DC 15). Any Gargantuan or smaller ships with an attached gravity bomb are unable to activate their hyperdrives."" },
            { ""name"": ""Gravity mine"", ""associatedWeapon"": ""Bomb layer"", ""cost"": 4000, ""damage"": ""-"", ""weight"": 60, ""category"": ""quaternary"", ""properties"": [{ ""name"": ""special"" }], ""special"": ""Rather than exploding on contact, gravity mines detonate any time a ship comes within range of it. When a gravity mine detonates, it creates a mass shadow centered on the point of detonation with a radius of 100 feet that lasts for 10 minutes. Any ships touching this mass shadow are unable to activate their hyperdrives."" },
            { ""name"": ""Proton bomb"", ""associatedWeapon"": ""Bomb layer"", ""cost"": 4200, ""damage"": ""-"", ""weight"": 65, ""category"": ""quaternary"", ""properties"": [{ ""name"": ""special"" }], ""special"": ""When a proton bomb detonates, each ship within 200 feet must make a Dexterity saving throw (DC 15). A ship takes 8d10 energy damage on a failed save, or half as much on a successful one."" },
            { ""name"": ""Proximity mine"", ""associatedWeapon"": ""Bomb layer"", ""cost"": 4400, ""damage"": ""-"", ""weight"": 65, ""category"": ""quaternary"", ""properties"": [{ ""name"": ""special"" }], ""special"": ""Rather than exploding on contact, proximity mines detonate any time a ship comes within range of it. When a proximity mine detonates, each ship within 200 feet must make a Dexterity saving throw (DC 15). A ship takes 4d10 fire damage on a failed save, or half as much on a successful one."" },
            { ""name"": ""Pulse bomb"", ""associatedWeapon"": ""Bomb layer"", ""cost"": 4600, ""damage"": ""-"", ""weight"": 70, ""category"": ""quaternary"", ""properties"": [{ ""name"": ""special"" }], ""special"": ""When a pulse bomb detonates, each ship within 400 feet must make a Constitution saving throw (DC 15). A ship takes 4d10 ion damage on a failed save, or half as much on a successful one. Additionally, on a failed save, it is ionized for 1 minute. As an action on each of their turns, a crewmember can have the ship repeat the saving throw, ending the effect on a success. Ships larger than you have advantage on their saving throw."" },
            { ""name"": ""Seismic charge"", ""associatedWeapon"": ""Bomb layer"", ""cost"": 4000, ""damage"": ""-"", ""weight"": 60, ""category"": ""quaternary"", ""properties"": [{ ""name"": ""special"" }], ""special"": ""When a seismic charge detonates, each ship within 300 feet must make a Dexterity saving throw (DC 15). A ship takes 2d10 kinetic damage on a failed save, or half as much on a successful one."" }
        ]";
        IEnumerable<ApiShipAmmunitionDTO> ammunitionList = JsonSerializer.Deserialize<IEnumerable<ApiShipAmmunitionDTO>>(ammunitionJsonString);
        var equipmentCategory = GetEquipmentCategoryMappingFromDatabase();
        var properties = GetPropertyMappingFromDatabase();
        var currentAmmunitionId = 1;
        foreach (var ammunition in ammunitionList)
        {
            Insert.IntoTable("Ammunition").Row(new
            {
                Name = ammunition.name,
                EquipmentCategoryId = equipmentCategory[ammunition.category.ToLower()],
                Cost = ammunition.cost,
                Damage = ammunition.damage,
                Weight = ammunition.weight,
                SpecialValue = ammunition.special,
                AssociatedWeaponId = weapons[ammunition.associatedWeapon.ToLower()]
            });
            foreach (var property in ammunition.properties)
            {
                Insert.IntoTable("AmmunitionPropertiesCrossReference").Row(new
                {
                    AmmunitionId = currentAmmunitionId,
                    EquipmentPropertyId = properties[property.Name.ToLower()],
                    ModifierValue = property.ModifierValue
                });
            }
            currentAmmunitionId++;
        }
    }
    private Dictionary<string, int> GetEquipmentCategoryMappingFromDatabase()
    {
        var equipmentCategoryMapping = new Dictionary<string, int>();
        using (SqlConnection connection = new SqlConnection("Data Source=.\\SQLEXPRESS;Database=DBStarWars;Trusted_Connection=yes;"))
        {
            connection.Open();
            string sqlQuery = "SELECT Id, Name FROM EquipmentCategories";

            using (SqlCommand command = new SqlCommand(sqlQuery, connection))
            {
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        equipmentCategoryMapping.Add(reader.GetString(1).ToLower(), reader.GetInt32(0));
                    }
                }
            }
            connection.Close();
        }
        return equipmentCategoryMapping;
    }
    private Dictionary<string, int> GetPropertyMappingFromDatabase()
    {
        var propertyMapping = new Dictionary<string, int>();
        using (SqlConnection connection = new SqlConnection("Data Source=.\\SQLEXPRESS;Database=DBStarWars;Trusted_Connection=yes;"))
        {
            connection.Open();
            string sqlQuery = "SELECT Id, Name FROM EquipmentProperties";

            using (SqlCommand command = new SqlCommand(sqlQuery, connection))
            {
                using (SqlDataReader reader = command.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        propertyMapping.Add(reader.GetString(1).ToLower(), reader.GetInt32(0));
                    }
                }
            }
            connection.Close();
        }
        return propertyMapping;
    }
}
